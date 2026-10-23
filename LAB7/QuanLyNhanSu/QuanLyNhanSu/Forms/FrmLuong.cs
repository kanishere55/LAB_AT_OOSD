using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public sealed class FrmLuong : ModuleForm
    {
        public FrmLuong() : base("Bảng lương - thống kê")
        {
            Page("Lập bảng lương", new[] { F("Mã bảng lương", Txt("bl", NewId("BL"), 20)), F("Tháng", Num("thang", 10)), F("Năm", Num("nam", 2026)), F("Ngày lập", Date("ngay")), F("Ngày công chuẩn tháng", Num("cong", 26, 2)), F("Giờ chuẩn mỗi ngày", Num("gio", 8, 2)) }, new[] { A("Tính và lưu bảng lương", () =>
            {
                S.LapBangLuong(new[] { "MaBL", "Thang", "Nam", "NgayLap", "Cong", "GioNgay" }, V("bl"), (int)N("thang"), (int)N("nam"), D("ngay"), N("cong"), N("gio"));
            }) });
            Page("Chi tiết lương", new[] { F("Mã bảng lương cần xem", Txt("xbl", "BL092026", 20)) }, new[] { A("Xem chi tiết", () =>
            {
                ;
            }), A("Xuất CSV", () =>
            {
                using (var dlg = new SaveFileDialog
                {
                    Filter = "CSV|*.csv",
                    FileName = "BangLuong.csv"
                }

                )
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        var t = S.Luong(V("xbl"));
                        var sb = new System.Text.StringBuilder();
                        sb.AppendLine(string.Join(",", System.Linq.Enumerable.Select(System.Linq.Enumerable.Cast<DataColumn>(t.Columns), c => c.ColumnName)));
                        foreach (DataRow r in t.Rows)
                            sb.AppendLine(string.Join(",", System.Linq.Enumerable.Select(r.ItemArray, x => ((char)34) + Convert.ToString(x).Replace(((char)34).ToString(), new string ((char)34, 2)) + ((char)34))));
                        System.IO.File.WriteAllText(dlg.FileName, sb.ToString(), System.Text.Encoding.UTF8);
                    }
                };
            }) });
            Page("Thống kê tháng", new[] { F("Tổng hợp theo bảng lương", Txt("note", "Chọn Tải lại để xem các bảng đã lập")) }, new[] { A("Tải lại", () =>
            {
                ;
            }) });
            Reload = () =>
            {
                Tables[0].DataSource = S.DS("BangLuong");
                Tables[1].DataSource = S.Luong(V("xbl"));
                Tables[2].DataSource = S.ThongKe();
            };
        }
    }
}
