using System;
using System.Windows.Forms;

namespace QuanLyHoSoBenhAn.Forms
{
    public sealed class FrmKhamBenh : ModuleForm
    {
        public FrmKhamBenh() : base("Tiếp nhận • Lập phiếu và ghi nhận khám bệnh")
        {
            var a = Page("Tiếp nhận khám", new[] { F("Mã phiếu khám", Txt("ma", NewId("PK"), 20)), F("Hồ sơ bệnh án", Combo("hs")), F("Bác sĩ phụ trách", Combo("bs")), F("Khoa điều trị", Combo("khoa")), F("Ngày giờ khám", Date("ngay", null, true)), F("Loại khám", Combo("loai", new[] { "Điều trị", "Định kỳ" })), F("Mã hẹn định kỳ (có thể để trống)", Txt("hen", "", 20)), F("Phí khám (định kỳ = 0)", Num("phi")) }, new[] { A("Lập phiếu khám", () => S.LapPhieu(V("ma"), V("hs"), V("bs"), V("khoa"), D("ngay"), V("loai"), V("hen"), N("phi"))), A("Mã phiếu mới", () => Set("ma", NewId("PK"))), A("Tải lại", () =>
            {
            }) });
            ((ComboBox)Fields["loai"]).SelectedIndexChanged += (s, e) =>
            {
                if (V("loai") == "Định kỳ")
                    Set("phi", 0);
                Fields["phi"].Enabled = V("loai") != "Định kỳ";
            };
            var b = Page("Nội dung khám", new[] { F("Phiếu đang điều trị", Combo("phieu")), F("Triệu chứng", Txt("tc")), F("Thân nhiệt (°C, 0 = chưa ghi)", Num("nhiet", 0, 1)), F("Huyết áp", Txt("ha", "", 30)), F("Kết luận", Txt("kl")), F("Diễn biến bệnh", Txt("db")), F("Phản ứng phụ", Txt("pu")), F("Hiệu quả điều trị", Txt("hq")) }, new[] { A("Nạp nội dung phiếu", () => LoadExam()), A("Lưu nội dung khám", () => S.GhiKham(V("phieu"), V("tc"), N("nhiet") == 0 ? (decimal? )null : N("nhiet"), V("ha"), V("kl"), V("db"), V("pu"), V("hq"))), A("Tải lại", () =>
            {
            }) });
            a.CellClick += (s, e) =>
            {
                var r = Row(a);
                if (r == null)
                    return;
                Set("phieu", r["Mã phiếu"]);
                LoadExam();
                Tabs.SelectedIndex = 1;
            };
            Reload = () =>
            {
                Bind("hs", S.HoSo());
                Bind("bs", S.DanhMuc("BacSi"));
                Bind("khoa", S.DanhMuc("Khoa"));
                Bind("phieu", S.ChonPhieu());
                a.DataSource = S.PhieuKham();
                b.DataSource = S.PhieuKham(true);
            };
        }

        void LoadExam()
        {
            var t = S.ChiTietKham(V("phieu"));
            if (t.Rows.Count == 0)
                return;
            var r = t.Rows[0];
            string[] fields =
            {
                "tc",
                "nhiet",
                "ha",
                "kl",
                "db",
                "pu",
                "hq"
            };
            string[] cols =
            {
                "TrieuChung",
                "ThanNhiet",
                "HuyetAp",
                "KetLuan",
                "DienBien",
                "PhanUngPhu",
                "HieuQuaDieuTri"
            };
            for (int i = 0; i < fields.Length; i++)
                Set(fields[i], r[cols[i]]);
        }
    }
}
