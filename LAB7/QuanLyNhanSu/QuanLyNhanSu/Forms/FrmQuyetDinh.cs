using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public sealed class FrmQuyetDinh : ModuleForm
    {
        public FrmQuyetDinh() : base("Quyết định lương - chức vụ")
        {
            Page("Quyết định lương", new[] { F("Số quyết định", Txt("lqd", NewId("QL"), 20)), F("Nhân viên", Combo("lnv")), F("Ngày hiệu lực", Date("lngay")), F("Lương cơ bản", Num("lcb", 8000000)), F("Phụ cấp lương", Num("lpc", 1000000)), F("Phụ cấp độc hại", Num("ldh", 500000)) }, new[] { A("Lưu quyết định lương", () =>
            {
                S.Them("QuyetDinhLuong", new[] { "SoQD", "MaNV", "NgayHieuLuc", "LuongCoBan", "PhuCapLuong", "PhuCapDocHai" }, new object[] { V("lqd"), V("lnv"), D("lngay"), N("lcb"), N("lpc"), N("ldh") });
            }) });
            Page("Quyết định chức vụ", new[] { F("Số quyết định", Txt("cqd", NewId("QC"), 20)), F("Nhân viên", Combo("cnv")), F("Chức vụ", Combo("cv")), F("Ngày hiệu lực", Date("cngay")), F("Phụ cấp chức vụ", Num("cpc", 500000)) }, new[] { A("Lưu bổ nhiệm", () =>
            {
                S.Them("QuyetDinhChucVu", new[] { "SoQD", "MaNV", "MaCV", "NgayHieuLuc", "PhuCap" }, new object[] { V("cqd"), V("cnv"), V("cv"), D("cngay"), N("cpc") });
            }) });
            Reload = () =>
            {
                Bind("lnv", S.NhanVien());
                Bind("cnv", S.NhanVien());
                Bind("cv", S.ChucVu());
                Tables[0].DataSource = S.DS("QuyetDinhLuong");
                Tables[1].DataSource = S.DS("QuyetDinhChucVu");
            };
        }
    }
}
