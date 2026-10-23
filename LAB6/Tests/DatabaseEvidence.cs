using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyHoSoBenhAn.Data;
using QuanLyHoSoBenhAn.Forms;

internal static class DatabaseEvidence
{
    static void Show(DataTable data, string title, string path)
    {
        using (var f = new Form
        {
            Text = "SQL Server - QuanLyHoSoBenhAn",
            ClientSize = new Size(1240, 790),
            Font = new Font("Segoe UI", 11),
            StartPosition = FormStartPosition.CenterScreen
        }

        )
        {
            var grid = ModuleForm.Grid();
            grid.DataSource = data;
            f.Controls.Add(grid);
            f.Controls.Add(new Label { Text = title + "\nQuanLyHoSoBenhAn • Kết quả truy vấn metadata • " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), Dock = DockStyle.Top, Height = 78, Padding = new Padding(12), ForeColor = Color.White, BackColor = Color.FromArgb(30, 73, 115), Font = new Font("Segoe UI", 13, FontStyle.Bold) });
            f.Show();
            Application.DoEvents();
            using (var b = new Bitmap(f.Width, f.Height))
            {
                f.DrawToBitmap(b, new Rectangle(0, 0, f.Width, f.Height));
                b.Save(path, ImageFormat.Png);
            }

            f.Close();
        }

        var csv = new StringBuilder();
        foreach (DataColumn c in data.Columns)
            csv.Append('"').Append(c.ColumnName).Append("\",");
        csv.AppendLine();
        foreach (DataRow r in data.Rows)
        {
            foreach (var v in r.ItemArray)
                csv.Append('"').Append(Convert.ToString(v).Replace("\"", "\"\"")).Append("\",");
            csv.AppendLine();
        }

        File.WriteAllText(Path.ChangeExtension(path, ".csv"), csv.ToString(), Encoding.UTF8);
    }

    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Show(Db.Query(@"SELECT t.name [Bảng],COUNT(c.column_id) [Số cột],(SELECT SUM(p.rows) FROM sys.partitions p WHERE p.object_id=t.object_id AND p.index_id IN(0,1)) [Số dòng],(SELECT STRING_AGG(cc.name,', ') FROM sys.index_columns ic JOIN sys.columns cc ON cc.object_id=ic.object_id AND cc.column_id=ic.column_id JOIN sys.indexes ix ON ix.object_id=ic.object_id AND ix.index_id=ic.index_id WHERE ix.is_primary_key=1 AND ic.object_id=t.object_id) [Khóa chính] FROM sys.tables t JOIN sys.columns c ON c.object_id=t.object_id GROUP BY t.object_id,t.name ORDER BY t.name"), "CSDL gồm 13 bảng nghiệp vụ và khóa chính", Path.Combine(args[0], "10_Database_Tables.png"));
        Show(Db.Query(@"SELECT OBJECT_NAME(f.parent_object_id) [Bảng con],COL_NAME(c.parent_object_id,c.parent_column_id) [Cột FK],OBJECT_NAME(f.referenced_object_id) [Bảng cha],COL_NAME(c.referenced_object_id,c.referenced_column_id) [Cột được tham chiếu] FROM sys.foreign_keys f JOIN sys.foreign_key_columns c ON c.constraint_object_id=f.object_id ORDER BY [Bảng con],f.name,c.constraint_column_id"), "Các liên kết khóa ngoại được tạo trong SQL Server", Path.Combine(args[0], "11_Database_ForeignKeys.png"));
    }
}
