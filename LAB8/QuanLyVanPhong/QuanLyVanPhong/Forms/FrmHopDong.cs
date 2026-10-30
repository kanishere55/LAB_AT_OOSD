using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace QuanLyVanPhong.Forms {
    public sealed class FrmHopDong : ModuleForm {
        
        public FrmHopDong() : base("Khách hàng và hợp đồng thuê văn phòng") {

            var kh=Page("Khách hàng",new[]{F("Mã khách hàng",Txt("mkh","",20)),F("Tên công ty",Txt("ten","",150)),F("Mã số thuế",Txt("mst","",30)),F("Người đại diện",Txt("dd","",120)),F("Điện thoại",Txt("dt","",20)),F("Địa chỉ",Txt("dc","",250))},new[]{A("Thêm khách hàng",()=>S.Them("KhachHang",new[]{"MaKH","TenCongTy","MaSoThue","NguoiDaiDien","DienThoai","DiaChi"},V("mkh"),V("ten"),V("mst"),V("dd"),V("dt"),V("dc")))});
            var ds=Txt("ds","P202",1000);ds.Multiline=true;ds.Height=40;ds.ScrollBars=ScrollBars.Vertical;
            var hd=Page("Ký hợp đồng",new[]{F("Số hợp đồng",Txt("hd",NewId("HD"),20)),F("Khách hàng",Combo("kh")),F("Ngày ký",Date("ky")),F("Bắt đầu thuê",Date("tu",new DateTime(DateTime.Today.Year,DateTime.Today.Month,1).AddMonths(1))),F("Số tháng thuê (ít nhất 6)",Num("thang",6)),F("Phòng thuê: mỗi dòng một mã",ds),F("Điều khoản hợp đồng",Txt("dk","Tiền thuê không gồm dịch vụ; thu trước 6 tháng, từ tháng 7 thu đầu tháng; dịch vụ thu cuối tháng.",2000)),F("Hình thức trả trước",Combo("ht",new[]{"Chuyển khoản","Tiền mặt"})),F("Người thu tiền",Txt("nt","Kế toán",120)),F("Xác nhận tiền trả trước",Check("nhan"))},new[]{A("Ký và ghi thu 6 tháng",()=>S.KyHopDong(V("hd"),V("kh"),D("ky"),D("tu"),(int)N("thang"),V("dk"),B("nhan"),V("ht"),V("nt"),S.DocPhong(V("ds"),false))),A("Tạo số mới",()=>Set("hd",NewId("HD")))});
            ((CheckBox)Fields["nhan"]).Text="Đã nhận đủ tiền 6 tháng";
            var ct=Page("Phòng và thời hạn thuê",new[]{F("Hợp đồng cần xem",Combo("xhd"))},new[]{A("Xem chi tiết",RefreshData)});
            Reload=()=>{Bind("kh",S.Chon("KhachHang"));Bind("xhd",S.Chon("HopDong"));kh.DataSource=S.DS("KhachHang");hd.DataSource=S.DS("HopDong");ct.DataSource=S.ChiTietThue(V("xhd"));};

        }
    }
}
