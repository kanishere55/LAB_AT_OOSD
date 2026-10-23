using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public sealed class FrmChamCong : ModuleForm
    {
        public FrmChamCong() : base("Kế hoạch - chấm công")
        {
            Page("Kế hoạch tuần", new[] { F("Mã kế hoạch", Txt("kh", NewId("KH"), 20)), F("Phòng ban", Combo("pb")), F("Thứ Hai đầu tuần", Date("tuan", DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek + 6) % 7))), F("Trưởng phòng lập", Txt("truong", "", 120)) }, new[] { A("Lưu kế hoạch", () =>
            {
                S.Them("KeHoachTuan", new[] { "MaKH", "MaPB", "DauTuan", "NguoiLap" }, new object[] { V("kh"), V("pb"), D("tuan"), V("truong") });
            }) });
            Page("Phân công ca", new[] { F("Mã kế hoạch", Txt("pkh", "KH001", 20)), F("Nhân viên", Combo("pnv")), F("Ngày làm việc", Date("pngay")), F("Ca làm", Combo("pca")), F("Giờ phụ trội dự kiến", Num("pgio", 2, 2)) }, new[] { A("Phân công", () =>
            {
                S.PhanCong(new[] { "MaKH", "MaNV", "Ngay", "MaCa", "Gio" }, V("pkh"), V("pnv"), D("pngay"), V("pca"), N("pgio"));
            }) });
            Page("Chấm công thực tế", new[] { F("Nhân viên", Combo("cnv")), F("Ngày làm việc", Date("cngay")), F("Ca làm", Combo("cca")), F("Giờ thực hiện", Num("cgio", 8, 2)), F("Ban chấm công ghi", Txt("nguoi", "", 120)) }, new[] { A("Ghi chấm công", () =>
            {
                S.GhiChamCong(new[] { "MaNV", "Ngay", "MaCa", "Gio", "Nguoi" }, V("cnv"), D("cngay"), V("cca"), N("cgio"), V("nguoi"));
            }) });
            Reload = () =>
            {
                Bind("pb", S.PhongBan());
                Bind("pnv", S.NhanVien());
                Bind("cnv", S.NhanVien());
                Bind("pca", S.Ca());
                Bind("cca", S.Ca());
                Tables[0].DataSource = S.DS("KeHoachTuan");
                Tables[1].DataSource = S.DS("PhanCongCa");
                Tables[2].DataSource = S.DS("ChamCong");
            };
        }
    }
}
