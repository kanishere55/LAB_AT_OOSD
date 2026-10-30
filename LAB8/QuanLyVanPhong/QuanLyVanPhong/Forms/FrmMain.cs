using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyVanPhong.Forms
{
    public sealed class FrmMain : Form
    {
        public FrmMain()
        {
            Text = "Quản lý cho thuê văn phòng cao ốc";
            Name = "FrmMain";
            Font = new Font("Segoe UI", 12);
            ClientSize = new Size(920, 790);
            MinimumSize = new Size(800, 720);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = SystemColors.Control;
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(55, 20, 55, 25),
                RowCount = 6,
                ColumnCount = 2
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 120));
            for (int i = 1; i < 6; i++)
                root.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            var title = new Label
            {
                Text = "CHO THUÊ VĂN PHÒNG",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 25, FontStyle.Bold)
            };
            root.Controls.Add(title, 0, 0);
            root.SetColumnSpan(title, 2);
            string[] labels =
            {
                "Danh mục tầng - phòng",
                "Khách hàng - hợp đồng",
                "Thanh toán tiền thuê",
                "Dịch vụ - hóa đơn",
                "Gia hạn thuê phòng",
                "Nhân viên - thẻ giữ xe",
                "Kiểm tra - xử phạt",
                "Thống kê - công nợ"
            };
            Func<Form>[] forms =
            {
                () => new FrmDanhMuc(),
                () => new FrmHopDong(),
                () => new FrmThanhToan(),
                () => new FrmDichVu(),
                () => new FrmGiaHan(),
                () => new FrmNhanVien(),
                () => new FrmKiemTra(),
                () => new FrmThongKe()
            };
            for (int i = 0; i < 8; i++)
            {
                int j = i;
                var b = new Button
                {
                    Text = labels[i],
                    Dock = DockStyle.Fill,
                    Margin = new Padding(10, 12, 10, 12),
                    Font = new Font("Segoe UI", 15)
                };
                b.Click += (s, e) =>
                {
                    using (var f = forms[j]())
                        f.ShowDialog(this);
                };
                root.Controls.Add(b, i % 2, i / 2 + 1);
            }

            var exit = new Button
            {
                Text = "Thoát",
                Dock = DockStyle.Fill,
                Margin = new Padding(190, 12, 190, 12),
                Font = new Font("Segoe UI", 15)
            };
            exit.Click += (s, e) => Close();
            root.Controls.Add(exit, 0, 5);
            root.SetColumnSpan(exit, 2);
            Controls.Add(root);
        }
    }
}
