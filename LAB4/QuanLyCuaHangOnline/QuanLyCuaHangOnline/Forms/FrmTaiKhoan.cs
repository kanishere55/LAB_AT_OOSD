using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyCuaHangOnline
{
    public partial class FrmTaiKhoan : Form
    {
        private AppContext app;
        public FrmTaiKhoan() { InitializeComponent(); }
        public FrmTaiKhoan(AppContext context) : this() { app = context; }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FormHelper.Run(this, () => { app.Session.Customer = app.Account.Login(txtUser.Text.Trim(), txtPass.Text); txtPass.Clear(); DialogResult = DialogResult.OK; Close(); });
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FormHelper.Run(this, () =>
            {
                var customer = new KhachHang
                {
                    HoTen = txtHoTen.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    GiayTo = txtGiayTo.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    TenDangNhap = txtUsername.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };
                app.Session.Customer = app.Account.Register(customer, txtPassword.Text);
                txtPassword.Clear(); DialogResult = DialogResult.OK; Close();
            });
        }

    }
}
