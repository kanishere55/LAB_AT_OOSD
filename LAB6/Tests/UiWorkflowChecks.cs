using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using QuanLyHoSoBenhAn.Data;
using QuanLyHoSoBenhAn.Forms;

internal static class UiWorkflowChecks
{
    static readonly string RunId = Guid.NewGuid().ToString("N").Substring(0, 7);
    static string Id(string s)
    {
        return s + "_" + RunId;
    }

    static readonly List<string> Results = new List<string>
    {
        "Ma,NoiDung,KetQua"
    };
    static int fails;
    static IEnumerable<Control> All(Control p)
    {
        foreach (Control c in p.Controls)
        {
            yield return c;
            foreach (var ch in All(c))
                yield return ch;
        }
    }

    static void Tab(ModuleForm f, int i)
    {
        ((TabControl)typeof(ModuleForm).GetField("Tabs", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(f)).SelectedIndex = i;
        Application.DoEvents();
    }

    static void Set(ModuleForm f, string k, object v)
    {
        var c = f.Fields[k];
        if (c is ComboBox && ((ComboBox)c).DataSource != null)
            ((ComboBox)c).SelectedValue = v;
        else if (c is DateTimePicker)
            ((DateTimePicker)c).Value = (DateTime)v;
        else if (c is NumericUpDown)
            ((NumericUpDown)c).Value = Convert.ToDecimal(v);
        else if (c is CheckBox)
            ((CheckBox)c).Checked = (bool)v;
        else
            c.Text = Convert.ToString(v);
    }

    static void Click(ModuleForm f, string text)
    {
        bool found = false;
        foreach (var c in All(f))
            if (c is Button && c.Text == text && c.Visible)
            {
                ((Button)c).PerformClick();
                found = true;
                break;
            }

        if (!found)
            throw new Exception("Không tìm thấy nút " + text);
        Application.DoEvents();
        var status = (Label)typeof(ModuleForm).GetField("Status", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(f);
        if (status.ForeColor == Color.Firebrick)
            throw new Exception(status.Text);
    }

    static void Check(string id, string title, Action work)
    {
        try
        {
            work();
            Results.Add(id + ",\"" + title + "\",PASS");
            Console.WriteLine("PASS " + id + " " + title);
        }
        catch (Exception e)
        {
            fails++;
            Results.Add(id + ",\"" + title + "\",FAIL");
            Console.WriteLine("FAIL " + id + " " + e.Message);
        }
    }

    static void Exists(string table, string key, string value)
    {
        if (Convert.ToInt32(Db.Query("SELECT COUNT(*) FROM " + table + " WHERE " + key + "=@v", Db.P("v", value)).Rows[0][0]) != 1)
            throw new Exception("Không tìm thấy dữ liệu ghi từ Form.");
    }

    [STAThread]
    static int Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var connection = new SqlConnectionStringBuilder(Db.ConnectionString) { InitialCatalog = "QuanLyHoSoBenhAn_Test" };
        if (args.Length > 1) connection.DataSource = args[1];
        Db.ConnectionString = connection.ConnectionString;
        using (var f = new FrmBenhNhan())
        {
            f.Show();
            Application.DoEvents();
            Set(f, "bn", Id("BN"));
            Set(f, "ten", "Bệnh nhân kiểm thử Form");
            Set(f, "dc", "Địa chỉ mẫu");
            Set(f, "dt", "0900000088");
            Set(f, "dk", Id("DK"));
            Set(f, "hs", Id("HS"));
            Set(f, "thu", Id("LP"));
            Set(f, "ngay", new DateTime(2026, 10, 16));
            Set(f, "sinh", new DateTime(2000, 1, 1));
            typeof(FrmBenhNhan).GetField("photo", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(f, Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+aLTkAAAAASUVORK5CYII="));
            Check("U01", "Nút đăng ký cấp hồ sơ ghi vào SQL", () =>
            {
                Click(f, "Đăng ký + cấp hồ sơ");
                Exists("HoSoBenhAn", "MaHoSo", Id("HS"));
            });
            Check("U02", "Nút cập nhật thông tin bệnh nhân", () =>
            {
                Set(f, "dc", "Địa chỉ sau cập nhật");
                Click(f, "Cập nhật nhân thân");
            });
            Tab(f, 1);
            Check("U03", "Nút thu lệ phí năm tiếp theo", () =>
            {
                Set(f, "bnphi", Id("BN"));
                Set(f, "maphi", Id("LPnext"));
                Set(f, "tu", new DateTime(2027, 10, 16));
                Click(f, "Ghi nhận thu lệ phí");
                Exists("PhieuThuLePhi", "MaThuLePhi", Id("LPnext"));
            });
            f.Close();
        }

        using (var f = new FrmKhamBenh())
        {
            f.Show();
            Application.DoEvents();
            Set(f, "ma", Id("PK"));
            Set(f, "hs", Id("HS"));
            Set(f, "bs", "BS01");
            Set(f, "khoa", "K01");
            Set(f, "ngay", new DateTime(2026, 10, 16));
            Check("U04", "Nút lập phiếu khám", () =>
            {
                Click(f, "Lập phiếu khám");
                Exists("PhieuKham", "MaPhieuKham", Id("PK"));
            });
            Tab(f, 1);
            Set(f, "phieu", Id("PK"));
            Set(f, "tc", "Triệu chứng mẫu");
            Set(f, "kl", "Kết luận mẫu");
            Check("U05", "Nút lưu nội dung khám", () => Click(f, "Lưu nội dung khám"));
            f.Close();
        }

        using (var f = new FrmXetNghiem())
        {
            f.Show();
            Application.DoEvents();
            Set(f, "ma", Id("CD"));
            Set(f, "phieu", Id("PK"));
            Set(f, "loai", "XN01");
            Set(f, "ngay", new DateTime(2026, 10, 16, 8, 0, 0));
            Check("U06", "Nút lập chỉ định xét nghiệm", () =>
            {
                Click(f, "Lập chỉ định");
                Exists("ChiDinhXetNghiem", "MaChiDinh", Id("CD"));
            });
            Tab(f, 1);
            Set(f, "cd", Id("CD"));
            Set(f, "tra", new DateTime(2026, 10, 16, 9, 0, 0));
            Set(f, "kq", "Kết quả mẫu");
            Check("U07", "Nút ghi kết quả xét nghiệm", () => Click(f, "Lưu kết quả"));
            f.Close();
        }

        using (var f = new FrmToaThuoc())
        {
            f.Show();
            Application.DoEvents();
            Set(f, "ma", Id("TOA"));
            Set(f, "phieu", Id("PK"));
            Set(f, "bs", "BS01");
            Set(f, "thuoc", "T01");
            Set(f, "lieu", "Liều mẫu");
            Set(f, "cach", "Cách dùng mẫu");
            Set(f, "sl", 2);
            Check("U08", "Nút thêm dòng và lưu toa nhiều bảng", () =>
            {
                Click(f, "Thêm dòng thuốc");
                Click(f, "Lưu toa và chi tiết");
                Exists("ToaThuoc", "MaToa", Id("TOA"));
                Exists("ChiTietToaThuoc", "MaToa", Id("TOA"));
            });
            f.Close();
        }

        using (var f = new FrmHoanTat())
        {
            f.Show();
            Application.DoEvents();
            Set(f, "phieu", Id("PK"));
            Set(f, "xv", true);
            Set(f, "tt", true);
            Check("U09", "Nút lưu thủ tục và hoàn tất điều trị", () =>
            {
                Click(f, "Lưu xác nhận thủ tục");
                Click(f, "Hoàn tất và ghi lịch sử");
                if (!Convert.ToBoolean(Db.Query("SELECT DaHoanTat FROM PhieuKham WHERE MaPhieuKham=@m", Db.P("m", Id("PK"))).Rows[0][0]))
                    throw new Exception("Chưa hoàn tất.");
            });
            f.Close();
        }

        using (var f = new FrmLichHen())
        {
            f.Show();
            Application.DoEvents();
            Set(f, "ma", Id("LH"));
            Set(f, "hs", Id("HS"));
            Set(f, "ngay", new DateTime(2027, 1, 10, 8, 0, 0));
            Check("U10", "Nút đặt hẹn định kỳ", () =>
            {
                Click(f, "Đặt hẹn mới");
                Exists("LichHen", "MaHen", Id("LH"));
            });
            f.Close();
        }

        using (var f = new FrmKhamBenh())
        {
            f.Show();
            Application.DoEvents();
            Set(f, "ma", Id("PKdk"));
            Set(f, "hs", Id("HS"));
            Set(f, "bs", "BS01");
            Set(f, "khoa", "K02");
            Set(f, "ngay", new DateTime(2027, 1, 10, 8, 0, 0));
            Set(f, "loai", "Định kỳ");
            Set(f, "hen", Id("LH"));
            Check("U11", "Nút tiếp nhận theo lịch định kỳ miễn phí", () =>
            {
                Click(f, "Lập phiếu khám");
                Exists("PhieuKham", "MaPhieuKham", Id("PKdk"));
            });
            f.Close();
        }

        using (var f = new FrmDanhMuc())
        {
            f.Show();
            Application.DoEvents();
            Set(f, "Khoam", Id("Khoa"));
            Set(f, "Khoat", "Khoa kiểm thử " + RunId);
            Check("U12", "Nút thêm và cập nhật danh mục", () =>
            {
                Click(f, "Thêm mới");
                Set(f, "Khoat", "Khoa đã sửa " + RunId);
                Click(f, "Lưu chỉnh sửa");
                Exists("Khoa", "MaKhoa", Id("Khoa"));
            });
            f.Close();
        }

        File.WriteAllLines(args[0], Results, System.Text.Encoding.UTF8);
        Console.WriteLine("UI WORKFLOW: " + (Results.Count - 1 - fails) + " PASS, " + fails + " FAIL");
        return fails == 0 ? 0 : 1;
    }
}
