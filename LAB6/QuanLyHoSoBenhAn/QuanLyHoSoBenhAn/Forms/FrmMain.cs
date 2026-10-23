using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyHoSoBenhAn.Services;
using QuanLyHoSoBenhAn.Data;

namespace QuanLyHoSoBenhAn.Forms
{
    public sealed class FrmMain : Form
    {
        public FrmMain()
        {
            Text = "LAB6 - Quản lý hồ sơ bệnh án";
            Name = "FrmMain";
            Font = new Font("Segoe UI", 11);
            ClientSize = new Size(1180, 760);
            MinimumSize = new Size(1050, 700);
            StartPosition = FormStartPosition.CenterScreen;
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                ColumnCount = 1,
                RowCount = 4
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 112));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 210));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            root.Controls.Add(new Label { Text = "QUẢN LÝ HỒ SƠ BỆNH ÁN\nNguyễn Thành Can • 1250080021 • LAB6", Dock = DockStyle.Fill, BackColor = Color.FromArgb(30, 73, 115), ForeColor = Color.White, Padding = new Padding(18), Font = new Font("Segoe UI", 17, FontStyle.Bold) }, 0, 0);
            var nav = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 2
            };
            for (int i = 0; i < 4; i++)
                nav.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            for (int i = 0; i < 2; i++)
                nav.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            string[] names =
            {
                "Bệnh nhân và lệ phí",
                "Tiếp nhận và khám bệnh",
                "Xét nghiệm",
                "Lập và xem toa thuốc",
                "Lịch khám định kỳ",
                "Hoàn tất đợt điều trị",
                "Tra cứu lịch sử bệnh án",
                "Danh mục"
            };
            Func<Form>[] forms =
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
            for (int i = 0; i < names.Length; i++)
            {
                int index = i;
                var b = new Button
                {
                    Text = names[i],
                    Dock = DockStyle.Fill,
                    Margin = new Padding(4),
                    BackColor = Color.FromArgb(230, 240, 250),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };
                b.Click += (s, e) =>
                {
                    using (var f = forms[index]())
                        f.ShowDialog(this);
                    LoadSummary();
                };
                nav.Controls.Add(b, i % 4, i / 4);
            }

            root.Controls.Add(nav, 0, 1);
            summary = ModuleForm.Grid();
            root.Controls.Add(summary, 0, 2);
            status = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Đang kết nối SQL Server...",
                Padding = new Padding(0, 6, 0, 0)
            };
            root.Controls.Add(status, 0, 3);
            Controls.Add(root);
            Shown += (s, e) => LoadSummary();
        }

        DataGridView summary;
        Label status;
        public void LoadSummary()
        {
            try
            {
                summary.DataSource = new HoSoService().TongHop();
                status.Text = "Đã kết nối SQL Server • QuanLyHoSoBenhAn • " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                status.ForeColor = Color.DarkGreen;
            }
            catch (Exception e)
            {
                status.Text = "Không kết nối được CSDL: " + Db.Friendly(e);
                status.ForeColor = Color.Firebrick;
            }
        }
    }
}
