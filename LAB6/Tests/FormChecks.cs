using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using QuanLyHoSoBenhAn.Forms;
using QuanLyHoSoBenhAn.Services;

internal static class FormChecks
{
    static int checks, failures;
    static readonly List<string> Log = new List<string>
    {
        "ManHinh,KichThuoc,NoiDung,KetQua"
    };
    static void Assert(bool ok, string screen, string size, string detail)
    {
        checks++;
        if (!ok)
            failures++;
        Log.Add(Csv(screen) + "," + Csv(size) + "," + Csv(detail) + "," + (ok ? "PASS" : "FAIL"));
    }

    static string Csv(string value)
    {
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }

    static IEnumerable<Control> Controls(Control root)
    {
        foreach (Control c in root.Controls)
        {
            yield return c;
            foreach (var cc in Controls(c))
                yield return cc;
        }
    }

    static void Inspect(Form f, string key)
    {
        string size = f.ClientSize.Width + "x" + f.ClientSize.Height;
        var module = f as ModuleForm;
        if (module != null)
        {
            foreach (var pair in module.Fields)
            {
                var c = pair.Value;
                if (c.Visible)
                    Assert(f.RectangleToScreen(f.ClientRectangle).Contains(c.RectangleToScreen(c.ClientRectangle)), key, size, "VungNhap_" + pair.Key);
            }
        }

        foreach (Control c in Controls(f))
        {
            var g = c as DataGridView;
            if (g == null || !g.Visible || g.Columns.Count == 0)
                continue;
            int width = 0;
            foreach (DataGridViewColumn col in g.Columns)
                if (col.Visible)
                    width += col.Width;
            Assert(width <= g.ClientSize.Width + 2, key, size, "TatCaCotNamTrongBang");
            Assert(g.ColumnHeadersVisible && g.ColumnHeadersHeight >= 22, key, size, "TieuDeCot");
            Assert(g.DataSource != null, key, size, "DuLieuTuSQL");
        }
    }

    static void Capture(Form f, string path)
    {
        Application.DoEvents();
        using (var bitmap = new Bitmap(f.Width, f.Height))
        {
            f.DrawToBitmap(bitmap, new Rectangle(0, 0, f.Width, f.Height));
            bitmap.Save(path, ImageFormat.Png);
        }
    }

    static void CheckMainHeader(Form f)
    {
        foreach (Control c in Controls(f))
        {
            var label = c as Label;
            if (label == null || !label.Text.Contains("\n")) continue;
            var available = new Size(label.ClientSize.Width - label.Padding.Horizontal, int.MaxValue);
            var needed = TextRenderer.MeasureText(label.Text, label.Font, available, TextFormatFlags.WordBreak);
            Assert(needed.Height <= label.ClientSize.Height - label.Padding.Vertical, "01_Main", f.ClientSize.ToString(), "HaiDongTieuDeKhongBiCat");
        }
    }

    static void ClickRow(DataGridView g, int row)
    {
        if (g.Rows.Count <= row)
            return;
        g.CurrentCell = g.Rows[row].Cells[0];
        typeof(DataGridView).GetMethod("OnCellClick", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(g, new object[] { new DataGridViewCellEventArgs(0, row) });
    }

    [STAThread]
    static int Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        string output = args.Length > 0 ? args[0] : "Evidence";
        Directory.CreateDirectory(output);
        using (var main = new FrmMain())
        {
            main.Show();
            Application.DoEvents();
            main.LoadSummary();
            Inspect(main, "01_Main");
            CheckMainHeader(main);
            var originalSize = main.ClientSize;
            main.Size = main.MinimumSize;
            Application.DoEvents();
            CheckMainHeader(main);
            main.ClientSize = originalSize;
            Application.DoEvents();
            Capture(main, Path.Combine(output, "01_Main.png"));
            main.Close();
        }

        Func<ModuleForm>[] factories =
        {
            () => new FrmBenhNhan(),
            () => new FrmKhamBenh(),
            () => new FrmXetNghiem(),
            () => new FrmToaThuoc(),
            () => new FrmLichHen(),
            () => new FrmHoanTat(),
            () => new FrmLichSu(),
            () => new FrmDanhMuc()
        };
        int index = 2;
        foreach (var factory in factories)
        {
            using (var f = factory())
            {
                f.Show();
                Application.DoEvents();
                f.RefreshData();
                var status = (Label)typeof(ModuleForm).GetField("Status", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(f);
                Assert(status.ForeColor != Color.Firebrick, f.Name, "default", "TaiSQLThanhCong");
                if (status.ForeColor == Color.Firebrick)
                    Console.WriteLine(f.Name + ": " + status.Text);
                var tabs = (TabControl)typeof(ModuleForm).GetField("Tabs", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(f);
                if (f is FrmBenhNhan)
                    ClickRow(f.Tables[0], 0);
                if (f is FrmKhamBenh)
                {
                    for (int r = 0; r < f.Tables[0].Rows.Count; r++)
                        if (Convert.ToString(f.Tables[0].Rows[r].Cells[0].Value) == "PK002")
                        {
                            ClickRow(f.Tables[0], r);
                            break;
                        }
                }

                if (f is FrmXetNghiem)
                    ClickRow(f.Tables[0], 0);
                if (f is FrmLichHen)
                    ClickRow(f.Tables[0], 0);
                if (f is FrmHoanTat)
                    ClickRow(f.Tables[0], 0);
                if (f is FrmLichSu)
                {
                    for (int r = 0; r < f.Tables[0].Rows.Count; r++)
                        if (Convert.ToString(f.Tables[0].Rows[r].Cells[0].Value) == "PK001")
                        {
                            ClickRow(f.Tables[0], r);
                            break;
                        }

                    tabs.SelectedIndex = 2;
                    Application.DoEvents();
                    foreach (var c in Controls(f))
                        if (c is Button && c.Text == "Xem các dòng thuốc")
                        {
                            ((Button)c).PerformClick();
                            break;
                        }
                    for (int r = 0; r < f.Tables[0].Rows.Count; r++)
                        if (Convert.ToString(f.Tables[0].Rows[r].Cells[0].Value) == "PK001")
                        {
                            ClickRow(f.Tables[0], r);
                            break;
                        }
                }

                if (f is FrmToaThuoc)
                {
                    f.Fields["lieu"].Text = "Liều mẫu của bài thực hành";
                    f.Fields["cach"].Text = "Cách dùng mẫu của bài thực hành";
                    ((NumericUpDown)f.Fields["sl"]).Value = 10;
                    foreach (var c in Controls(f))
                        if (c is Button && c.Text == "Thêm dòng thuốc")
                        {
                            ((Button)c).PerformClick();
                            break;
                        }
                }

                for (int t = 0; t < tabs.TabPages.Count; t++)
                {
                    tabs.SelectedIndex = t;
                    Application.DoEvents();
                    if (f is FrmDanhMuc)
                        ClickRow(f.Tables[t], 0);
                    string key = index.ToString("00") + "_" + f.Name + "_" + (t + 1);
                    Inspect(f, key);
                    Capture(f, Path.Combine(output, key + ".png"));
                    var original = f.ClientSize;
                    f.Size = f.MinimumSize;
                    Application.DoEvents();
                    Inspect(f, key);
                    f.ClientSize = original;
                    Application.DoEvents();
                }

                f.Close();
            }

            index++;
        }

        File.WriteAllLines(Path.Combine(output, "FormResults.csv"), Log, System.Text.Encoding.UTF8);
        Console.WriteLine("FORM CHECKS: " + checks + " checks, " + failures + " failures");
        return failures == 0 ? 0 : 1;
    }
}
