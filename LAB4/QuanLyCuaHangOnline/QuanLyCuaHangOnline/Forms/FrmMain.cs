using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyCuaHangOnline
{
    public partial class FrmMain : Form
    {
        private AppContext app;
        public FrmMain() { InitializeComponent(); }
        public FrmMain(AppContext context) : this()
        {
            app = context;
            Activated += (s, e) => lblSession.Text = app.Session.Customer == null ? "Chưa đăng nhập" : "Khách hàng: " + app.Session.Customer.HoTen;
        }
        private void btnSanPham_Click(object sender, EventArgs e) { FormHelper.Run(this, () => { using (var f = new FrmSanPham(app)) f.ShowDialog(this); }); }
        private void btnGioHang_Click(object sender, EventArgs e) { FormHelper.Run(this, () => { using (var f = new FrmGioHang(app)) f.ShowDialog(this); }); }
        private void btnTaiKhoan_Click(object sender, EventArgs e) { FormHelper.Run(this, () => { using (var f = new FrmTaiKhoan(app)) f.ShowDialog(this); }); }
        private void btnDatHang_Click(object sender, EventArgs e)
        {
            FormHelper.Run(this, () =>
            {
                if (app.Session.Cart.Items.Count == 0) throw new ArgumentException("Giỏ hàng trống. Hãy chọn sản phẩm trước.");
                if (app.Session.Customer == null) { using (var f = new FrmTaiKhoan(app)) f.ShowDialog(this); }
                if (app.Session.Customer != null) { using (var f = new FrmCheckout(app)) f.ShowDialog(this); }
            });
        }
        private void btnThoat_Click(object sender, EventArgs e) { Close(); }

    }
}
