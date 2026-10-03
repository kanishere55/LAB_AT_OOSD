using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyCuaHangOnline
{
    public partial class FrmCheckout : Form
    {
        private AppContext app;
        public FrmCheckout() { InitializeComponent(); }
        public FrmCheckout(AppContext context) : this()
        {
            app = context;
            var customer = app.Session.Customer;
            if (customer == null) throw new ArgumentException("Cần đăng nhập trước khi đặt hàng.");
            lblNguoiMua.Text = "Người mua: " + customer.HoTen;
            txtHoTen.Text = customer.HoTen; txtDiaChi.Text = customer.DiaChi; txtDienThoai.Text = customer.DienThoai;
            Preview();
            cboKhuVuc.SelectedIndexChanged += (s, e) => FormHelper.Run(this, Preview);
            cboLoaiGiao.SelectedIndexChanged += (s, e) => FormHelper.Run(this, Preview);
        }
        private NguoiNhan Recipient()
        {
            return new NguoiNhan
            {
                HoTen = txtHoTen.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                KhuVuc = new[] { "NoiThanh", "NgoaiThanh", "TinhKhac" }[cboKhuVuc.SelectedIndex],
                LoaiGiao = new[] { "Thuong", "Nhanh", "TrongNgay" }[cboLoaiGiao.SelectedIndex]
            };
        }
        public void Preview()
        {
            btnThanhToan.Enabled = false; lblTongTien.Text = ""; lblPhiGiao.Text = "";
            var quote = app.Checkout.Quote(Recipient(), "VISA");
            lblTienHang.Text = "Tiền hàng: " + quote.TienHang.ToString("N0") + " đ";
            lblPhiGiao.Text = "Phí giao hàng: " + quote.PhiGiao.ToString("N0") + " đ";
            lblTongTien.Text = "Tổng tạm tính: " + (quote.TienHang + quote.PhiGiao).ToString("N0") + " đ";
            btnThanhToan.Enabled = true;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            FormHelper.Run(this, () =>
            {
                var recipient = Recipient(); var quote = app.Checkout.Quote(recipient, "VISA");
                using (var f = new FrmThanhToan(app, recipient, quote))
                {
                    f.ShowDialog(this);
                    if (f.DialogResult == DialogResult.OK) { DialogResult = DialogResult.OK; Close(); }
                }
            });
        }

    }
}
