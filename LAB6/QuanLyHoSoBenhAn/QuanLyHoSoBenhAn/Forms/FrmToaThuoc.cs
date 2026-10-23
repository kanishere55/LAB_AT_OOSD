using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using QuanLyHoSoBenhAn.Services;

namespace QuanLyHoSoBenhAn.Forms
{
    public sealed class FrmToaThuoc : ModuleForm
    {
        DataTable lines = HoSoService.DongToa();
        DataGridView list;
        public FrmToaThuoc() : base("Toa thuốc • Lập toa, lưu chi tiết và xuất toa")
        {
            var g = Page("Lập toa mới", new[] { F("Mã toa", Txt("ma", NewId("TOA"), 20)), F("Phiếu khám đã có kết luận", Combo("phieu")), F("Bác sĩ kê toa", Combo("bs")), F("Thuốc trong danh mục", Combo("thuoc")), F("Số lượng", Num("sl", 1)), F("Liều dùng", Txt("lieu", "", 150)), F("Cách dùng", Txt("cach", "", 150)), F("Lời dặn", Txt("dan")) }, new[] { A("Thêm dòng thuốc", () =>
            {
                HoSoService.Required(V("lieu"), "liều dùng");
                HoSoService.Required(V("cach"), "cách dùng");
                if (N("sl") <= 0)
                    throw new ArgumentException("Số lượng phải lớn hơn 0.");
                lines.Rows.Add(lines.Rows.Count + 1, V("thuoc"), (int)N("sl"), V("lieu"), V("cach"));
            }), A("Bỏ dòng chọn", () =>
            {
                if (gRow != null)
                {
                    lines.Rows.Remove(gRow);
                    gRow = null;
                    for (int i = 0; i < lines.Rows.Count; i++)
                        lines.Rows[i][0] = i + 1;
                }
            }), A("Lưu toa và chi tiết", () => S.LapToa(V("ma"), V("phieu"), V("bs"), V("dan"), lines)), A("Toa mới", () =>
            {
                Set("ma", NewId("TOA"));
                lines.Clear();
                Set("dan", "");
            }), A("Tải lại", () =>
            {
            }) });
            g.DataSource = lines;
            g.Columns[0].HeaderText = "STT";
            g.Columns[1].HeaderText = "Mã thuốc";
            g.Columns[2].HeaderText = "Số lượng";
            g.Columns[3].HeaderText = "Liều dùng";
            g.Columns[4].HeaderText = "Cách dùng";
            g.CellClick += (s, e) => gRow = Row(g);
            list = Page("Toa đã lưu", new[] { F("Mã toa cần xem / in", Txt("xem", "", 20)) }, new[] { A("Xem toa thuốc", () => Preview()), A("Xuất TXT", () =>
            {
                using (var dlg = new SaveFileDialog
                {
                    Filter = "Văn bản UTF-8|*.txt",
                    FileName = V("xem") + ".txt"
                }

                )
                    if (dlg.ShowDialog() == DialogResult.OK)
                        File.WriteAllText(dlg.FileName, S.XuatToa(V("xem")), System.Text.Encoding.UTF8);
            }), A("Tải lại", () =>
            {
            }) });
            list.CellClick += (s, e) =>
            {
                var r = Row(list);
                if (r != null)
                    Set("xem", r["Mã toa"]);
            };
            ((ComboBox)Fields["phieu"]).SelectedIndexChanged += (s, e) =>
            {
                if (V("phieu") == "")
                    return;
                var t = S.ChiTietKham(V("phieu"));
                if (t.Rows.Count > 0)
                    Set("bs", t.Rows[0]["MaBacSi"]);
            };
            Reload = () =>
            {
                Bind("bs", S.DanhMuc("BacSi"));
                Bind("phieu", S.ChonPhieu());
                Bind("thuoc", S.DanhMuc("Thuoc"));
                list.DataSource = S.Toa();
                if (V("xem") == "" && list.Rows.Count > 0)
                    Set("xem", list.Rows[0].Cells[0].Value);
            };
        }

        DataRow gRow;
        void Preview()
        {
            string text = S.XuatToa(V("xem"));
            using (var f = new Form
            {
                Text = "Toa thuốc " + V("xem"),
                Size = new Size(780, 680),
                StartPosition = FormStartPosition.CenterParent
            }

            )
            {
                var content = new TextBox
                {
                    Text = text,
                    Multiline = true,
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    ScrollBars = ScrollBars.Both,
                    Font = new Font("Segoe UI", 12)
                };
                var print = new Button
                {
                    Text = "Xem trước khi in",
                    Dock = DockStyle.Bottom,
                    Height = 40
                };
                print.Click += (s, e) =>
                {
                    using (var document = new PrintDocument())
                    using (var preview = new PrintPreviewDialog
                    {
                        Document = document,
                        Width = 1000,
                        Height = 800
                    }

                    )
                    {
                        document.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                        int offset = 0;
                        document.BeginPrint += (o, b) => offset = 0;
                        document.PrintPage += (o, p) =>
                        {
                            int chars, ls;
                            var area = p.MarginBounds;
                            using (var font = new Font("Segoe UI", 11))
                            {
                                p.Graphics.MeasureString(text.Substring(offset), font, area.Size, StringFormat.GenericTypographic, out chars, out ls);
                                p.Graphics.DrawString(text.Substring(offset, chars), font, Brushes.Black, area, StringFormat.GenericTypographic);
                                offset += chars;
                                p.HasMorePages = offset < text.Length;
                            }
                        };
                        preview.ShowDialog(f);
                    }
                };
                f.Controls.Add(content);
                f.Controls.Add(print);
                f.ShowDialog(this);
            }
        }
    }
}
