using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuanLyCongTyDuLich.Data;
using QuanLyCongTyDuLich.Forms;
using QuanLyCongTyDuLich.Services;

class Tests
{
    static int pass, fail;
    static void Check(string id, bool condition, string detail)
    {
        Console.WriteLine((condition ? "PASS " : "FAIL ") + id + " | " + detail);
        if (condition) pass++; else fail++;
    }
    static void Result(string id, KetQuaXuLy result, bool expected)
    { Check(id, result.ThanhCong == expected, result.ThongBao); }
    static int Count(string sql) { return Convert.ToInt32(Db.Scalar(sql)); }
    static List<ThanhVienDoanItem> Members(int count)
    {
        var result = new List<ThanhVienDoanItem>();
        for (int i=1;i<=count;i++) result.Add(new ThanhVienDoanItem { HoTen="Khách thử " + i, NgaySinh=new DateTime(1990,1,1), SoGiayTo="TEST"+i });
        return result;
    }
    static KetQuaXuLy Register(string id, int count, bool insurance, decimal deposit, int members)
    {
        return new DangKyDoanService().DangKy(id,"DK03","Trường THPT Lê Quý Đôn","110 Nguyễn Thị Minh Khai","0283930001","Nguyễn Thị Hoa",
            "T003",new DateTime(2027,1,5),count,"110 Nguyễn Thị Minh Khai",insurance,deposit,Members(members));
    }
    static void Business()
    {
        var dm=new DanhMucService(); var tour=new TourService(); var trip=new ChuyenLeService(); var single=new DangKyLeService();
        var group=new DangKyDoanService();var guide=new PhanCongService();var finish=new KetThucService();var stats=new ThongKeService();
        Console.WriteLine("SQL Server: " + Db.ConnectionString);
        Result("TC01",dm.ThemHDV("HDV04","Hướng dẫn viên thử","0900000004",9000000),true);
        Result("TC02",tour.ThemTour("T004","Phú Quốc 3 ngày 2 đêm",3,2,5500000,"TP.HCM - Phú Quốc - TP.HCM"),true);
        Result("TC03",tour.ThemDiemDung("T001",2,"Cần Thơ",false,true,true,3,""),false);
        Result("TC04",trip.ThemChuyen("CL004","T001",new DateTime(2026,12,15),"Nhà Văn hóa Thanh Niên"),true);
        Check("TC04-DATE",Convert.ToDateTime(Db.Scalar("SELECT NgayVe FROM ChuyenLe WHERE MaChuyen='CL004'"))==new DateTime(2026,12,17),"Ngày về = ngày đi + số ngày - 1");
        Result("TC05",single.DangKy("DKL003","CL002","DB01","Hoàng Văn Phúc","0912000003",4),true);
        Check("TC05-MONEY",Convert.ToDecimal(Db.Scalar("SELECT ThanhTien FROM DangKyLe WHERE SoDKLe='DKL003'"))==10000000,"Thu ngay 10.000.000 đ");
        Result("TC06",single.DangKy("BAD06","CL002","DB01","Khách","0900000000",12),false);
        Result("TC07",single.DangKy("BAD07","CL001","DB01","Khách","0900000000",3),false);
        Result("TC09",Register("BAD09",12,false,30000000,0),false);
        Result("TC10",Register("BAD10",15,true,30000000,14),false);
        Result("TC11",Register("BAD11",15,false,0,0),false);
        Result("TC08",Register("DD003",15,true,30000000,15),true);
        Check("TC08-DATA",Count("SELECT COUNT(*) FROM ThanhVienDoan WHERE SoDKDoan='DD003'")==15 && Convert.ToDecimal(Db.Scalar("SELECT TongTienDuKien FROM DangKyDoan WHERE SoDKDoan='DD003'"))==133500000,
            "15 thành viên bảo hiểm; tổng 133.500.000 đ");
        Result("EX-ROLLBACK",Register("DD003",15,true,30000000,15),false);
        Check("EX-ROLLBACK-DATA",Count("SELECT COUNT(*) FROM ThanhVienDoan WHERE SoDKDoan='DD003'")==15,"Lập trùng phiếu rollback; danh sách giữ nguyên");
        Result("EX-CANCEL-ASSIGN",guide.PhanCong("PC_CANCEL","HDV03","DOAN","DD002",1500000),true);
        Result("TC12",group.HuyDangKy("DD002"),true);
        Check("TC12-DATA",Count("SELECT COUNT(*) FROM PhanCongHDV WHERE SoDKDoan='DD002'")==0 && Convert.ToString(Db.Scalar("SELECT TrangThai FROM DangKyDoan WHERE SoDKDoan='DD002'"))==QuyDinh.HuyMatCoc,"Gỡ phân công, giữ cọc và trạng thái hủy");
        Result("TC13",guide.PhanCong("PC004","HDV01","LE","CL002",1500000),true);
        Result("TC14",guide.PhanCong("BAD14","HDV02","LE","CL002",1500000),false);
        Result("TC15",guide.PhanCong("BAD15","HDV02","DOAN","DD001",1500000),false);
        var salary=stats.LuongHDV(9,2026);
        Check("TC23",salary.Rows.Cast<DataRow>().Where(r=>Convert.ToString(r["MaHDV"])=="HDV01").All(r=>Convert.ToDecimal(r["TongLuong"])==10500000)
            && Convert.ToDecimal(salary.Rows.Cast<DataRow>().First(r=>Convert.ToString(r["MaHDV"])=="HDV02")["TongLuong"])==11500000
            && Convert.ToDecimal(salary.Rows.Cast<DataRow>().First(r=>Convert.ToString(r["MaHDV"])=="HDV03")["TongLuong"])==10500000,"Lương 9/2026: 10,5 / 11,5 / 10,5 triệu trên dữ liệu mẫu");
        Result("TC16",guide.PhanCong("PC005","HDV01","DOAN","DD001",1500000),true);
        Result("TC17",finish.ThanhToanDoan("BAD17","DD001",new DateTime(2026,9,15),50000000,""),false);
        Result("TC19",finish.ThanhToanDoan("BAD19","DD003",new DateTime(2026,10,9),1000000,""),false);
        Result("TC18",finish.ThanhToanDoan("TT001","DD001",new DateTime(2026,9,15),40000000,"Chuyển khoản"),true);
        Check("TC18-DATA",Convert.ToString(Db.Scalar("SELECT TrangThai FROM DangKyDoan WHERE SoDKDoan='DD001'"))==QuyDinh.HoanTatThanhToan,"Thanh toán và đổi trạng thái trong cùng transaction");
        Result("TC20",finish.GuiKhaoSat("KS002","DOAN","DD001",new DateTime(2026,9,15)),true);
        Result("TC21",finish.GuiKhaoSat("BAD21","LE","DKL002",new DateTime(2026,10,9)),false);
        Result("TC22",finish.GhiPhanHoi("KS002",new DateTime(2026,9,16),4,"Lịch trình hợp lý"),true);
        var summary=stats.TongHop(new DateTime(2026,1,1),new DateTime(2026,10,1));
        Check("TC24",summary.Rows.Count==5 && Convert.ToInt32(summary.Rows[0]["SoLuong"])==2 && Convert.ToDecimal(summary.Rows[0]["GiaTri"])==12500000,"5 chỉ số; 2 phiếu lẻ, 12.500.000 đ trong kỳ mẫu");
        Result("EX-SURVEY-DUP",finish.GuiKhaoSat("BADKS","DOAN","DD001",new DateTime(2026,9,17)),false);
        Result("EX-RATING",finish.GhiPhanHoi("KS002",new DateTime(2026,9,16),6,""),false);
        Result("EX-RESPONSE-DATE",finish.GhiPhanHoi("KS002",new DateTime(2026,9,14),4,""),false);
        Result("EX-DEPOSIT",Register("BADC",15,false,200000000,0),false);
        Result("EX-HOTEL",tour.ThemDiemDung("T002",4,"Khách sạn",false,true,true,1,""),false);
        Result("EX-INACTIVE",guide.PhanCong("BADHDV","NO_HDV","DOAN","DD003",1500000),false);
        Result("EX-FUTURE",finish.GuiKhaoSat("BADF","LE","DKL002",new DateTime(2027,1,1)),false);
        Result("EX-PAID-AGAIN",finish.ThanhToanDoan("BADTT","DD001",new DateTime(2026,9,16),1,""),false);
        Check("EX-NO-BAD-DATA",Count("SELECT COUNT(*) FROM DangKyLe WHERE SoDKLe LIKE 'BAD%'")==0 && Count("SELECT COUNT(*) FROM DangKyDoan WHERE SoDKDoan LIKE 'BAD%'")==0
            && Count("SELECT COUNT(*) FROM PhanCongHDV WHERE MaPC LIKE 'BAD%'")==0 && Count("SELECT COUNT(*) FROM ThanhToanDoan WHERE SoTT LIKE 'BAD%'")==0,
            "Các giao dịch bị từ chối không sinh dữ liệu");
    }
    static void ValidateBounds(Control parent, string name)
    {
        foreach(Control c in parent.Controls)
        {
            if(c is TabPage || c is DataGridView || c is GroupBox || c is TabControl || c is Label || c is Button || c is TextBox || c is ComboBox || c is NumericUpDown || c is DateTimePicker || c is CheckBox)
            {
                if (!(c is TabPage) && (c.Left<0 || c.Top<0 || c.Right>parent.ClientSize.Width+2 || c.Bottom>parent.ClientSize.Height+2))
                    Check("UI-BOUNDS",false,name+" / "+c.Name+" vượt vùng hiển thị");
                if(c is GroupBox || c is TabPage || c is TabControl) ValidateBounds(c,name);
            }
        }
    }
    static void Capture(Form form, string filename, string directory)
    {
        Application.DoEvents();
        using(var bitmap=new Bitmap(form.Width,form.Height))
        { form.DrawToBitmap(bitmap,new Rectangle(Point.Empty,form.Size));bitmap.Save(Path.Combine(directory,filename+".png")); }
    }
    static void ValidateTableText(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            var grid=control as DataGridView;
            if (grid==null) { if(control.Visible)ValidateTableText(control); continue; }
            if (!grid.Visible) continue;
            bool readable=true;
            int total=0;
            foreach(DataGridViewColumn column in grid.Columns)
            {
                if(!column.Visible)continue;
                total+=column.Width;
                int header=TextRenderer.MeasureText(column.HeaderText,grid.Font).Width+16;
                if(column.Width<header)readable=false;
                foreach(DataGridViewRow row in grid.Rows)
                {
                    if(row.IsNewRow)continue;
                    var cell=row.Cells[column.Index];
                    string value=Convert.ToString(cell.FormattedValue);
                    var padding=cell.InheritedStyle.Padding;
                    var size=TextRenderer.MeasureText(value,cell.InheritedStyle.Font??grid.Font,
                        new Size(Math.Max(1,column.Width-padding.Horizontal-8),int.MaxValue),TextFormatFlags.WordBreak);
                    if(row.Height<size.Height+padding.Vertical+2)readable=false;
                }
            }
            if(total>grid.ClientSize.Width-grid.RowHeadersWidth-2)readable=false;
            Check("UI-TEXT-"+grid.FindForm().Name+"-"+grid.Name,readable,"Đủ độ rộng tiêu đề, chiều cao nội dung, các cột nằm trong bảng");
        }
    }
    static void Forms(string directory)
    {
        Directory.CreateDirectory(directory);Application.EnableVisualStyles();Application.SetCompatibleTextRenderingDefault(false);
        Func<Form>[] factories={ ()=>new FrmMain(),()=>new FrmDanhMuc(),()=>new FrmTour(),()=>new FrmChuyenLe(),()=>new FrmDangKyLe(),()=>new FrmDangKyDoan(),()=>new FrmPhanCongHDV(),()=>new FrmKetThucKhaoSat(),()=>new FrmLuongThongKe() };
        foreach(var factory in factories)
        using(var form=factory())
        {
            form.ShowInTaskbar=false;form.Opacity=0;form.Show();Application.DoEvents();
            var fields=form.Controls.Find("txtMa",true);if(fields.Length>0) fields[0].Text=form is FrmTour ? "T004" : "CL004";
            if(form is FrmLuongThongKe)
            {
                ((NumericUpDown)form.Controls.Find("numThang",true)[0]).Value=9;
                ((Button)form.Controls.Find("btnLuong",true)[0]).PerformClick();
                var statisticsTabs=form.Controls.OfType<TabControl>().First();
                statisticsTabs.SelectedIndex=1;
                ((Button)form.Controls.Find("btnTongHop",true)[0]).PerformClick();
                if(((DataGridView)form.Controls.Find("dgvTongHop",true)[0]).Rows.Count!=5)
                    throw new Exception("Nút thống kê chưa nạp đủ 5 chỉ số.");
                statisticsTabs.SelectedIndex=0;
            }
            ValidateBounds(form,form.Name);
            var tabs=form.Controls.OfType<TabControl>().FirstOrDefault();
            if(tabs==null){Capture(form,form.Name,directory);ValidateTableText(form);}
            else for(int i=0;i<tabs.TabCount;i++){tabs.SelectedIndex=i;Capture(form,form.Name+"_Tab"+i,directory);ValidateTableText(form);}
            if(form is FrmTour)
            {
                tabs.SelectedIndex=0;
                var grid=(DataGridView)form.Controls.Find("dgvTour",true)[0];
                var data=(DataTable)grid.DataSource;
                data.Rows[0]["MoTa"]=string.Join(" ",Enumerable.Repeat("Hành trình TP.HCM - Mỹ Tho - Cần Thơ, tham quan văn hóa, nghỉ khách sạn và trở về TP.HCM.",8));
                Application.DoEvents();
                Capture(form,"FrmTour_NoiDungDai",directory);
                ValidateTableText(form);
                Check("UI-WRAP",grid.Rows[0].Height>grid.Rows[1].Height,"Mô tả dài tự xuống dòng và tăng chiều cao hàng");
            }
            Check("UI-"+form.Name,true,"Mở Form, nạp Service/SQL, dựng ảnh và kiểm tra vùng control");
            form.Close();
        }
    }
    [STAThread] static int Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture=new CultureInfo("vi-VN");
        Console.OutputEncoding=System.Text.Encoding.UTF8;
        try { if(args.Length>0 && args[0]=="forms")Forms(args[1]);else Business(); }
        catch(Exception e){ Check("UNHANDLED",false,e.ToString()); }
        Console.WriteLine("RESULT: "+pass+" passed; "+fail+" failed");return fail==0?0:1;
    }
}
