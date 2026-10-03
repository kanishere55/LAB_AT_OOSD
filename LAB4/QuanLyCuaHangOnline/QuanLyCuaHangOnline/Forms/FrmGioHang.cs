using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyCuaHangOnline
{
    public partial class FrmGioHang : Form
    {
        private AppContext app;
        public FrmGioHang() { InitializeComponent(); }
        public FrmGioHang(AppContext context) : this()
        {
            app = context; Reload();
            dgvGioHang.SelectionChanged += (s, e) => { if (dgvGioHang.CurrentRow != null) nudSoLuong.Value = Math.Min(999, (int)dgvGioHang.CurrentRow.Cells["SoLuong"].Value); };
        }
        private string SelectedCode()
        {
            if (dgvGioHang.CurrentRow == null) throw new ArgumentException("Chọn sản phẩm trong giỏ.");
            return (string)dgvGioHang.CurrentRow.Cells["MaSP"].Value;
        }
        public void Reload()
        {
            dgvGioHang.DataSource = app.Session.Cart.Items.Select(i => new { i.MaSP, i.TenSP, i.SoLuong, i.DonGia, i.ThanhTien }).ToList();
            FormHelper.FormatGrid(dgvGioHang);
            lblTienHang.Text = "Tiền hàng: " + app.Session.Cart.TienHang.ToString("N0") + " đ";
        }
        private void btnCapNhat_Click(object sender, EventArgs e) { FormHelper.Run(this, () => { app.Cart.Update(SelectedCode(), (int)nudSoLuong.Value); Reload(); }); }
        private void btnXoa_Click(object sender, EventArgs e) { FormHelper.Run(this, () => { app.Cart.Remove(SelectedCode()); Reload(); }); }
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            FormHelper.Run(this, () =>
            {
                if (app.Session.Cart.Items.Count == 0) throw new ArgumentException("Giỏ hàng trống.");
                if (app.Session.Customer == null) { using (var f = new FrmTaiKhoan(app)) f.ShowDialog(this); }
                if (app.Session.Customer == null) return;
                try { using (var f = new FrmCheckout(app)) f.ShowDialog(this); } finally { Reload(); }
            });
        }

    }
}
