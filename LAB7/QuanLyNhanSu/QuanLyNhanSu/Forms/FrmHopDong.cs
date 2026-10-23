using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public sealed class FrmHopDong : ModuleForm
    {
        public FrmHopDong() : base("Hợp đồng - bảo hiểm")
        {
            Page("Ký hợp đồng", new[] { F("Số hợp đồng", Txt("hd", NewId("HD"), 20)), F("Nhân viên đạt thử việc", Combo("nv")), F("Loại hợp đồng", Combo("loai", new[] { "Dài hạn", "Ngắn hạn" })), F("Ngày ký", Date("ky")), F("Ngày hiệu lực", Date("tu")), F("Ngày hết hạn (ngắn hạn)", Date("den", DateTime.Today.AddYears(1))), F("Điều khoản", Txt("dk", "", 1000)), F("Mã hồ sơ bảo hiểm", Txt("bh", NewId("BH"), 20)), F("Số BHYT", Txt("yt", "", 30)), F("Số BHXH", Txt("xh", "", 30)), F("Mức đóng bảo hiểm", Num("muc", 8000000)), F("Tỷ lệ BHYT (0–1)", Num("tyt", 0.015m, 4)), F("Tỷ lệ BHXH (0–1)", Num("txh", 0.08m, 4)) }, new[] { A("Ký và lưu bảo hiểm", () =>
            {
                S.KyHopDong(new[] { "SoHD", "MaNV", "Loai", "NgayKy", "TuNgay", "DenNgay", "DieuKhoan", "SoBH", "YT", "XH", "MucDong", "TyLeYT", "TyLeXH" }, V("hd"), V("nv"), V("loai"), D("ky"), D("tu"), V("loai") == "Dài hạn" ? (object)null : D("den"), V("dk"), V("bh"), V("yt"), V("xh"), N("muc"), N("tyt"), N("txh"));
            }) });
            Page("Hồ sơ BHYT - BHXH", new[] { F("Nhân viên tra cứu", Combo("xnv")) }, new[] { A("Tải lại", () =>
            {
                ;
            }) });
            Reload = () =>
            {
                Bind("nv", S.NhanVien());
                Bind("xnv", S.NhanVien());
                Tables[0].DataSource = S.DS("HopDong");
                Tables[1].DataSource = S.HoSoBaoHiem(V("xnv"));
            };
        }
    }
}
