using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public sealed class FrmKhenThuong : ModuleForm
    {
        public FrmKhenThuong() : base("Khen thưởng - kỷ luật")
        {
            Page("Khen thưởng", new[] { F("Số quyết định", Txt("q0", NewId("Q0"), 20)), F("Ngày quyết định", Date("d0")), F("Đối tượng", Combo("o0", new[] { "Cá nhân", "Phòng ban" })), F("Nhân viên", Combo("n0")), F("Phòng ban", Combo("b0")), F("Nội dung", Txt("nd0", "", 1000)), F("Tổng tiền", Num("tong0", 300000)), F("Giám đốc ký", Txt("ky0", "", 120)), F("Cách xử lý tiền", Combo("cach0", new[] { "Qua lương", "Trực tiếp" })), F("Số phiếu chi", Txt("p0", NewId("P0"), 20)), F("Phân bổ: MaNV;SoTien mỗi dòng", Txt("ds0", "NV001;300000", 2000)) }, new[] { A("Lưu quyết định và chứng từ", () =>
            {
                S.LapKhenThuong(V("q0"), D("d0"), V("o0") == "Cá nhân" ? V("n0") : null, V("o0") == "Phòng ban" ? V("b0") : null, V("nd0"), N("tong0"), V("ky0"), V("cach0"), V("p0"), S.DocDanhSach(V("ds0"), true));
            }), A("Tải lại", () =>
            {
                ;
            }) });
            Page("Kỷ luật", new[] { F("Số quyết định", Txt("q1", NewId("Q1"), 20)), F("Ngày quyết định", Date("d1")), F("Đối tượng", Combo("o1", new[] { "Cá nhân", "Phòng ban" })), F("Nhân viên", Combo("n1")), F("Phòng ban", Combo("b1")), F("Nội dung", Txt("nd1", "", 1000)), F("Tổng tiền", Num("tong1", 300000)), F("Giám đốc ký", Txt("ky1", "", 120)), F("Cách xử lý tiền", Combo("cach1", new[] { "Qua lương", "Trực tiếp" })), F("Số phiếu thu", Txt("p1", NewId("P1"), 20)), F("Phân bổ: MaNV;SoTien mỗi dòng", Txt("ds1", "NV001;300000", 2000)) }, new[] { A("Lưu quyết định và chứng từ", () =>
            {
                S.LapKyLuat(new[] { "SoQD", "Ngay", "MaNV", "MaPB", "NoiDung", "Tong", "NguoiKy", "Cach", "SoPhieu", "DS" }, V("q1"), D("d1"), V("o1") == "Cá nhân" ? V("n1") : null, V("o1") == "Phòng ban" ? V("b1") : null, V("nd1"), N("tong1"), V("ky1"), V("cach1"), V("p1"), S.DocDanhSach(V("ds1"), true));
            }), A("Tải lại", () =>
            {
                ;
            }) });
            foreach (string key in new[]
            {
                "ds0",
                "ds1",
                "ds"
            }

            )
            {
                if (Fields.ContainsKey(key))
                {
                    var box = (TextBox)Fields[key];
                    box.Multiline = true;
                    box.Height = 42;
                    box.ScrollBars = ScrollBars.Vertical;
                }
            }

            Reload = () =>
            {
                Bind("n0", S.NhanVien());
                Bind("b0", S.PhongBan());
                Tables[0].DataSource = S.DS("QuyetDinhKhenThuong");
                Bind("n1", S.NhanVien());
                Bind("b1", S.PhongBan());
                Tables[1].DataSource = S.DS("QuyetDinhKyLuat");
            };
        }
    }
}
