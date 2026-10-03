using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using QuanLyCuaHangOnline;
public class LabTests {
 static int passed,failed;static SqlRepository repo;static AppSession s;static CartService cart;static AccountService account;static CheckoutService checkout;static ProductCatalogAdapter catalog;static EmailGatewayAdapter emailGateway;
 static void Test(string id,string title,Action action){try{action();passed++;Console.WriteLine(id+"|"+title+"|PASS");}catch(Exception e){failed++;Console.WriteLine(id+"|"+title+"|FAIL: "+e.Message);}}
 static void Yes(bool value){if(!value)throw new Exception("Assertion failed");}
 static void Reject(Action action){try{action();}catch(ArgumentException){return;}throw new Exception("Expected validation error");}
 static object Scalar(string sql){using(var c=repo.Open())using(var cmd=c.CreateCommand()){cmd.CommandText=sql;return cmd.ExecuteScalar();}}
 static void Execute(string sql){using(var c=repo.Open())using(var cmd=c.CreateCommand()){cmd.CommandText=sql;cmd.ExecuteNonQuery();}}
 static CardInfo Card(string type="VISA",string csv="123"){return new CardInfo{LoaiThe=type,SoThe=type=="AmEx"?"378282246310005":"4111111111111111",CSV=csv,ChuThe="LAB TEST",HetHan=DateTime.Today.AddYears(2)};}
 static NguoiNhan N(){return new NguoiNhan{HoTen="Người nhận khác",DiaChi="25 Lê Lợi",DienThoai="0907654321",KhuVuc="NoiThanh",LoaiGiao="Nhanh"};}
 static KhachHang Customer(string user,string email){return new KhachHang{HoTen="Khách hàng kiểm thử",NgaySinh=new DateTime(2005,1,1),GiayTo="TEST04",DiaChi="12 Nguyễn Văn Bảo",DienThoai="0901234567",TenDangNhap=user,Email=email};}
 public static int Main(){Console.OutputEncoding=System.Text.Encoding.UTF8;repo=new SqlRepository();s=new AppSession();catalog=new ProductCatalogAdapter(repo);cart=new CartService(catalog,s);account=new AccountService(repo);emailGateway=new EmailGatewayAdapter();checkout=new CheckoutService(s,catalog,repo,new PaymentGatewayAdapter(),new EmailService(repo,emailGateway));string user="test04_"+DateTime.Now.ToString("yyyyMMddHHmmss");KhachHang kh=null;DonHang order=null;
 Test("TC01","Danh mục và nhiều ảnh",()=>{Yes(catalog.Groups().Count==3);Yes(catalog.Get("SP01").HinhAnh.Count==2);});
 Test("TC02","Lọc nhóm và tìm kiếm",()=>{Yes(catalog.Search("DIENTU","Tai nghe").Count==1);Yes(catalog.Search("DOCHOI","Tai nghe").Count==0);});
 Test("TC03","Thêm trùng mã gộp số lượng",()=>{cart.Add("SP01",1);cart.Add("SP01",2);Yes(s.Cart.Items.Count==1&&s.Cart.Items[0].SoLuong==3);});
 Test("TC04","Không thêm số lượng âm hoặc hết hàng",()=>{Reject(()=>cart.Add("SP01",-1));Reject(()=>cart.Add("SP04",1));});
 Test("TC05","Cập nhật 0 xóa sản phẩm",()=>{cart.Update("SP01",0);Yes(s.Cart.Items.Count==0);});
 Test("TC06","Giỏ trống bị chặn",()=>{s.Customer=Customer("dummy",null);Reject(()=>checkout.Quote(N(),"VISA"));s.Customer=null;});
 Test("TC07","Chưa đăng nhập bị chặn",()=>{cart.Add("SP01",2);Reject(()=>checkout.Quote(N(),"VISA"));});
 Test("TC08","Đăng ký và salt/hash đúng độ dài",()=>{kh=account.Register(Customer(user,"test@example.test"),"Lab04Pass!");Yes(kh.MaKH>0&&kh.Salt.Length==16&&kh.MatKhauHash.Length==32);s.Customer=kh;});
 Test("TC09","Tên đăng nhập trùng khác hoa thường",()=>{Reject(()=>account.Register(Customer(user.ToUpperInvariant(),null),"Lab04Pass!"));});
 Test("TC10","Đăng nhập đúng sai",()=>{Yes(account.Login(user,"Lab04Pass!").MaKH==kh.MaKH);Reject(()=>account.Login(user,"SaiMatKhau"));});
 Test("TC11","Mật khẩu ngắn và email sai",()=>{Reject(()=>account.Register(Customer(user+"x",null),"123"));Reject(()=>account.Register(Customer(user+"x","khong-phai-email"),"Lab04Pass!"));});
 Test("TC12","Mốc chuyển nhanh 999999 và 1000000",()=>{Yes(CheckoutService.Shipping(999999,"Nhanh",40000)==40000);Yes(CheckoutService.Shipping(1000000,"Nhanh",40000)==0);});
 Test("TC13","Mốc trong ngày 4999999 và 5000000",()=>{Yes(CheckoutService.Shipping(4999999,"TrongNgay",80000)==80000);Yes(CheckoutService.Shipping(5000000,"TrongNgay",80000)==0);});
 Test("TC14","Loại thường vẫn dùng phí cấu hình",()=>{Yes(CheckoutService.Shipping(5000000,"Thuong",20000)==20000);});
 Test("TC15","Tỉnh khác chưa hỗ trợ trong ngày",()=>{var n=N();n.KhuVuc="TinhKhac";n.LoaiGiao="TrongNgay";Reject(()=>checkout.Quote(n,"VISA"));});
 Test("TC16","VISA Master Discover đủ 16 số CSV 3",()=>{foreach(var type in new[]{"VISA","Master","Discover"})CheckoutService.ValidateCard(Card(type),DateTime.Today);var c=Card();c.SoThe="123";Reject(()=>CheckoutService.ValidateCard(c,DateTime.Today));});
 Test("TC17","AmEx đủ 15 số CSV 4",()=>{CheckoutService.ValidateCard(Card("AmEx","1234"),DateTime.Today);Reject(()=>CheckoutService.ValidateCard(Card("AmEx","123"),DateTime.Today));});
 Test("TC18","Thẻ hết hạn và còn hạn trong tháng",()=>{var c=Card();c.HetHan=DateTime.Today.AddMonths(-1);Reject(()=>CheckoutService.ValidateCard(c,DateTime.Today));c.HetHan=DateTime.Today;CheckoutService.ValidateCard(c,DateTime.Today);});
 Test("TC19","Người nhận khác và tổng tiền đúng",()=>{var q=checkout.Quote(N(),"VISA");Yes(q.TienHang==1000000&&q.PhiGiao==0&&q.TongTien==1000000&&N().HoTen!=kh.HoTen);});
 Test("TC20","Thanh toán từ chối không tạo đơn",()=>{int before=(int)Scalar("SELECT COUNT(*) FROM dbo.DonHang");Reject(()=>checkout.Place(Guid.NewGuid(),N(),Card("VISA","000"),checkout.Quote(N(),"VISA")));Yes((int)Scalar("SELECT COUNT(*) FROM dbo.DonHang")==before&&s.Cart.Items.Count==1);});
 Test("TC21","Thanh toán thành công lưu toàn bộ đơn",()=>{order=checkout.Place(Guid.NewGuid(),N(),Card(),checkout.Quote(N(),"VISA"));Yes(order.MaDH>0&&s.Cart.Items.Count==0);var read=repo.FindOrder(order.MaYeuCau);Yes(read.Quote.Items.Count==1&&read.Quote.TongTien==1000000&&read.BonSoCuoi=="1111"&&read.NguoiNhan.HoTen==N().HoTen);});
 Test("TC22","Email không có thông tin thẻ",()=>{string body=(string)Scalar("SELECT NoiDung FROM dbo.EmailXacNhan WHERE MaDH="+order.MaDH);Yes(!body.Contains("4111111111111111")&&!body.Contains("VISA")&&!body.Contains("1111")&&!body.Contains("CSV")&&body.Contains("Người nhận khác"));});
 Test("TC23","Gửi lại mã yêu cầu trả cùng đơn",()=>{var d=checkout.Place(order.MaYeuCau,N(),Card(),null);Yes(d.MaDH==order.MaDH);});
 Test("TC24","Rollback khi ghi thanh toán lỗi",()=>{var clone=new DonHang{MaYeuCau=Guid.NewGuid(),NguoiMua=kh,NguoiNhan=N(),Quote=order.Quote,ThoiDiem=DateTime.Now,LoaiThe="VISA",BonSoCuoi="1111",MaGiaoDich=order.MaGiaoDich};int before=(int)Scalar("SELECT COUNT(*) FROM dbo.DonHang");bool rejected=false;try{repo.SaveOrder(clone);}catch(SqlException){rejected=true;}Yes(rejected&&(int)Scalar("SELECT COUNT(*) FROM dbo.DonHang")==before&&repo.FindOrder(clone.MaYeuCau)==null);});
 Test("TC25","CHECK không cho số lượng bằng 0",()=>{bool rejected=false;try{Execute("UPDATE dbo.ChiTietDonHang SET SoLuong=0 WHERE MaDH="+order.MaDH);}catch(SqlException){rejected=true;}Yes(rejected);});
 Test("TC26","Email lỗi vẫn giữ đơn thành công",()=>{cart.Add("SP03",1);emailGateway.SimulateFailure=true;var d=checkout.Place(Guid.NewGuid(),N(),Card(),checkout.Quote(N(),"VISA"));Yes(d.EmailStatus=="LoiGui"&&repo.FindOrder(d.MaYeuCau)!=null);emailGateway.SimulateFailure=false;});
 Test("TC27","Không email không tạo bản ghi email",()=>{s.Customer=account.Register(Customer(user+"no",null),"Lab04Pass!");cart.Add("SP01",1);var d=checkout.Place(Guid.NewGuid(),N(),Card(),checkout.Quote(N(),"VISA"));Yes((int)Scalar("SELECT COUNT(*) FROM dbo.EmailXacNhan WHERE MaDH="+d.MaDH)==0);s.Customer=kh;});
 Test("TC28","SQL tham số không bị chèn lệnh",()=>{Reject(()=>account.Login("' OR 1=1--","x"));Yes(catalog.Search(null,"%'; DROP TABLE dbo.DonHang;--").Count==0);});
 Test("TC29","Giá thay đổi cần xác nhận lại",()=>{Execute("INSERT catalog.SanPham VALUES('TEST01','DIENTU',N'Test',N'Lab',N'Test',N'Test',100000,1)");try{cart.Add("TEST01",1);Execute("UPDATE catalog.SanPham SET GiaHienHanh=120000 WHERE MaSP='TEST01'");Reject(()=>checkout.Quote(N(),"VISA"));Yes(checkout.Quote(N(),"VISA").TienHang==120000);}finally{Execute("DELETE catalog.SanPham WHERE MaSP='TEST01'");s.Cart.Items.Clear();}});
 Test("TC30","Hết hàng trước thanh toán bị chặn",()=>{Execute("INSERT catalog.SanPham VALUES('TEST01','DIENTU',N'Test',N'Lab',N'Test',N'Test',100000,1)");try{cart.Add("TEST01",1);Execute("UPDATE catalog.SanPham SET ConHang=0 WHERE MaSP='TEST01'");Reject(()=>checkout.Quote(N(),"VISA"));}finally{Execute("DELETE catalog.SanPham WHERE MaSP='TEST01'");s.Cart.Items.Clear();}});
 Test("TC31","Đơn cũ giữ giá khi danh mục đổi",()=>{Execute("INSERT catalog.SanPham VALUES('TEST01','DIENTU',N'Test',N'Lab',N'Test',N'Test',100000,1)");try{cart.Add("TEST01",1);var d=checkout.Place(Guid.NewGuid(),N(),Card(),checkout.Quote(N(),"VISA"));Execute("UPDATE catalog.SanPham SET GiaHienHanh=180000 WHERE MaSP='TEST01'");Yes(repo.FindOrder(d.MaYeuCau).Quote.Items[0].DonGia==100000);}finally{Execute("DELETE catalog.SanPham WHERE MaSP='TEST01'");s.Cart.Items.Clear();}});
 Test("TC32","Phụ phí thẻ cấu hình cộng vào tổng",()=>{var cfg=System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);try{cfg.AppSettings.Settings["Fee_VISA"].Value="10000";cfg.Save();System.Configuration.ConfigurationManager.RefreshSection("appSettings");cart.Add("SP01",2);var q=checkout.Quote(N(),"VISA");Yes(q.PhiThe==10000&&q.TongTien==1010000);}finally{cfg.AppSettings.Settings["Fee_VISA"].Value="0";cfg.Save();System.Configuration.ConfigurationManager.RefreshSection("appSettings");s.Cart.Items.Clear();}});
 Test("TC33","Tìm theo nhà sản xuất",()=>{var p=catalog.Get("SP01");Yes(catalog.Search("DIENTU",p.NhaSanXuat).Any(x=>x.MaSP==p.MaSP));});
 Test("TC34","Sửa thẻ sau từ chối và không ghi trùng",()=>{cart.Add("SP01",1);var key=Guid.NewGuid();var q=checkout.Quote(N(),"VISA");int before=(int)Scalar("SELECT COUNT(*) FROM dbo.DonHang");Reject(()=>checkout.Place(key,N(),Card("VISA","000"),q));Yes((int)Scalar("SELECT COUNT(*) FROM dbo.DonHang")==before);var d=checkout.Place(key,N(),Card(),q);Yes(d.MaDH>0&&(int)Scalar("SELECT COUNT(*) FROM dbo.DonHang")==before+1);Yes(checkout.Place(key,N(),Card(),null).MaDH==d.MaDH);});
 Console.WriteLine("TOTAL|"+passed+" passed, "+failed+" failed");return failed==0?0:1;
 }
}

