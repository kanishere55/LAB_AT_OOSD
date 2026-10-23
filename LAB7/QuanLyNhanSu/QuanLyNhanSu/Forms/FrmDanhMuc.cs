using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public sealed class FrmDanhMuc : ModuleForm
    {
        public FrmDanhMuc() : base("Danh mục phòng ban, chức vụ và ca làm")
        {
            Page("Phòng ban", new[] { F("Mã", Txt("m0", "", 20)), F("Tên", Txt("t0", "", 120)) }, new[] { A("Thêm danh mục", () =>
            {
                S.Them("PhongBan", new[] { "MaPB", "TenPB" }, new object[] { V("m0"), V("t0") });
            }), A("Tải lại", () =>
            {
                ;
            }) });
            Page("Chức vụ", new[] { F("Mã", Txt("m1", "", 20)), F("Tên", Txt("t1", "", 120)) }, new[] { A("Thêm danh mục", () =>
            {
                S.Them("ChucVu", new[] { "MaCV", "TenCV" }, new object[] { V("m1"), V("t1") });
            }), A("Tải lại", () =>
            {
                ;
            }) });
            Page("Ca làm", new[] { F("Mã", Txt("m2", "", 20)), F("Tên", Txt("t2", "", 120)), F("Giờ bắt đầu (HH:mm)", Txt("bd", "08:00")), F("Giờ kết thúc (HH:mm)", Txt("kt", "17:00")), F("Số giờ quy đổi", Num("gio", 8, 2)) }, new[] { A("Thêm danh mục", () =>
            {
                S.Them("CaLam", new[] { "MaCa", "TenCa", "GioBatDau", "GioKetThuc", "SoGio" }, new object[] { V("m2"), V("t2"), TimeSpan.Parse(V("bd")), TimeSpan.Parse(V("kt")), N("gio") });
            }), A("Tải lại", () =>
            {
                ;
            }) });
            Reload = () =>
            {
                Tables[0].DataSource = S.DS("PhongBan");
                Tables[1].DataSource = S.DS("ChucVu");
                Tables[2].DataSource = S.DS("CaLam");
            };
        }
    }
}
