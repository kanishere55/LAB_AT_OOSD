using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyHoSoBenhAn.Forms
{
    public sealed class FrmLichSu : ModuleForm
    {
        DataGridView exams, tests, rx, detail;
        string selected = "";
        public FrmLichSu() : base("Tra cứu • Lịch sử khám, xét nghiệm và điều trị")
        {
            exams = Page("Các lần khám", new[] { F("Hồ sơ bệnh án", Combo("hs")), F("Lọc tìm BN / hồ sơ / điện thoại", Txt("tim", "", 100)) }, new[] { A("Tra cứu lịch sử", () =>
            {
            }), A("Tìm hồ sơ", () =>
            {
                var t = S.BenhNhan(V("tim"));
                if (t.Rows.Count == 0)
                    throw new ArgumentException("Không tìm thấy bệnh nhân.");
                Set("hs", t.Rows[0]["Mã hồ sơ"]);
            }), A("Xem nội dung lần khám", () =>
            {
                var r = Row(exams);
                if (r == null)
                    return;
                var p = S.ChiTietKham(Convert.ToString(r["Mã phiếu"])).Rows[0];
                MessageBox.Show(this, "Triệu chứng: " + p["TrieuChung"] + "\nThân nhiệt: " + p["ThanNhiet"] + "\nHuyết áp: " + p["HuyetAp"] + "\nKết luận: " + p["KetLuan"] + "\nDiễn biến: " + p["DienBien"] + "\nPhản ứng phụ: " + p["PhanUngPhu"] + "\nHiệu quả: " + p["HieuQuaDieuTri"], "Nội dung khám");
            }) });
            tests = Page("Xét nghiệm lần khám được chọn", new Tuple<string, Control>[0], new[] { A("Tải lại", () =>
            {
            }) });
            rx = Page("Toa thuốc theo hồ sơ", new Tuple<string, Control>[0], new[] { A("Xem các dòng thuốc", () =>
            {
                var r = Row(rx);
                if (r == null)
                    return;
                selected = Convert.ToString(r["Mã toa"]);
                detail.DataSource = S.ChiTietToa(selected);
                Tabs.SelectedIndex = 3;
            }) });
            detail = Page("Chi tiết toa đã chọn", new Tuple<string, Control>[0], new[] { A("Tải lại", () =>
            {
            }) });
            exams.CellClick += (s, e) =>
            {
                var r = Row(exams);
                if (r == null)
                    return;
                tests.DataSource = S.XetNghiem(Convert.ToString(r["Mã phiếu"]));
            };
            Reload = () =>
            {
                Bind("hs", S.HoSo());
                exams.DataSource = S.LichSu(V("hs"));
                rx.DataSource = S.Toa(V("hs"));
                var r = Row(exams);
                tests.DataSource = S.XetNghiem(r == null ? "__none__" : Convert.ToString(r["Mã phiếu"]));
                detail.DataSource = S.ChiTietToa(selected);
            };
        }
    }
}
