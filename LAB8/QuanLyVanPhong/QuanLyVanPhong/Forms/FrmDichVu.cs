using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace QuanLyVanPhong.Forms {
    public sealed class FrmDichVu : ModuleForm {
        
        public FrmDichVu() : base("Ghi sử dụng dịch vụ và lập hóa đơn cuối tháng") {

            var sd=Page("Sử dụng dịch vụ",new[]{F("Mã lần sử dụng",Txt("sd",NewId("SD"),20)),F("Hợp đồng",Combo("hd")),F("Phòng",Combo("phong")),F("Dịch vụ",Combo("dv")),F("Ngày sử dụng",Date("ngay")),F("Số lượng",Num("sl",100,2))},new[]{A("Ghi sử dụng",()=>S.Proc("GhiDichVu",new[]{"MaSD","SoHD","MaPhong","MaDV","Ngay","SoLuong"},V("sd"),V("hd"),V("phong"),V("dv"),D("ngay"),N("sl"))),A("Mã sử dụng mới",()=>Set("sd",NewId("SD")))});
            var bill=Page("Hóa đơn cuối tháng",new[]{F("Mã hóa đơn dịch vụ",Txt("hddv",NewId("DV"),20)),F("Hợp đồng",Combo("bhd")),F("Phòng",Combo("bp")),F("Tháng",Num("thang",9)),F("Năm",Num("nam",2026)),F("Ngày lập (cuối tháng trở đi)",Date("lap"))},new[]{A("Lập hóa đơn",()=>S.Proc("LapHoaDonDichVu",new[]{"MaHDDV","SoHD","MaPhong","Thang","Nam","NgayLap"},V("hddv"),V("bhd"),V("bp"),(int)N("thang"),(int)N("nam"),D("lap")))});
            var ct=Page("Chi tiết hóa đơn",new[]{F("Mã hóa đơn cần xem",Txt("xhd","DV092026",20))},new[]{A("Xem chi tiết",RefreshData)});
            Reload=()=>{Bind("hd",S.Chon("HopDong"));Bind("bhd",S.Chon("HopDong"));Bind("phong",S.Chon("Phong"));Bind("bp",S.Chon("Phong"));Bind("dv",S.Chon("DichVu"));sd.DataSource=S.DS("SuDungDichVu");bill.DataSource=S.DS("HoaDonDichVu");ct.DataSource=S.ChiTietHoaDon(V("xhd"));};

        }
    }
}
