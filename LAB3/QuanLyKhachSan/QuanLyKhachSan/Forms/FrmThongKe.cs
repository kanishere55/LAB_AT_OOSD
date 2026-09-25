using System;
using System.Windows.Forms;
using System.Globalization;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    public partial class FrmThongKe : Form
    {
        readonly ThongKeService s = new ThongKeService();

        public FrmThongKe()
        {
            InitializeComponent();
            ApplyReferenceLayout();
        }

        private void btnTK_Click(object a, EventArgs e)
        {
            if (dtDen.Value.Date < dtTu.Value.Date)
            {
                MessageBox.Show("Đến ngày không được trước từ ngày.");
                return;
            }

            var tongHop = s.TongHop(dtTu.Value, dtDen.Value);
            dgvTongHop.DataSource = tongHop;
            dgvDV.DataSource = s.DichVu(dtTu.Value, dtDen.Value);
            if (tongHop.Rows.Count > 0)
            {
                var row = tongHop.Rows[0];
                var vi = CultureInfo.GetCultureInfo("vi-VN");
                lblPhieuDat.Text = "Phiếu đặt: " + row["SoPhieuDat"];
                lblDangO.Text = "Đang ở: " + row["DangO"];
                lblHoaDon.Text = "Hóa đơn: " + row["SoHoaDon"];
                lblDoanhThu.Text = "Doanh thu HĐ: " + Convert.ToDecimal(row["DoanhThuHoaDon"]).ToString("N0", vi) + " đ";
                lblDenBu.Text = "Tổng đền bù: " + Convert.ToDecimal(row["TongDenBu"]).ToString("N0", vi) + " đ";
            }
        }

        private void btnDong_Click(object a, EventArgs e)
        {
            Close();
        }
    }
}
