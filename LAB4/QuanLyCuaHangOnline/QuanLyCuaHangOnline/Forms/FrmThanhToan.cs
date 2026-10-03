using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyCuaHangOnline
{
    public partial class FrmThanhToan : Form
    {
        private AppContext app;
        public FrmThanhToan() { InitializeComponent(); }
        private NguoiNhan recipient;
        private CheckoutQuote quote;
        private readonly Guid requestKey = Guid.NewGuid();
        public FrmThanhToan(AppContext context, NguoiNhan receiver, CheckoutQuote accepted) : this()
        {
            app = context; recipient = receiver; quote = accepted; UpdateQuote();
            cboLoaiThe.SelectedIndexChanged += (s, e) => FormHelper.Run(this, UpdateQuote);
        }
        private string CardType() { return cboLoaiThe.SelectedIndex == 3 ? "AmEx" : cboLoaiThe.Text; }
        private void UpdateQuote()
        {
            btnXacNhan.Enabled = false;
            quote = app.Checkout.Quote(recipient, CardType());
            lblPhiThe.Text = "Phụ phí sử dụng thẻ: " + quote.PhiThe.ToString("N0") + " đ";
            lblTongTien.Text = "Số tiền thanh toán: " + quote.TongTien.ToString("N0") + " đ";
            btnXacNhan.Enabled = true;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            FormHelper.Run(this, () =>
            {
                btnXacNhan.Enabled = false;
                try
                {
                    var card = new CardInfo
                    {
                        LoaiThe = CardType(),
                        SoThe = txtSoThe.Text.Trim(),
                        ChuThe = txtChuThe.Text.Trim(),
                        HetHan = dtpHetHan.Value,
                        CSV = txtCSV.Text.Trim()
                    };
                    var order = app.Checkout.Place(requestKey, recipient, card, quote);
                    txtSoThe.Clear(); txtCSV.Clear(); txtChuThe.Clear();
                    using (var f = new FrmXacNhanDonHang(app, order)) f.ShowDialog(this);
                    DialogResult = DialogResult.OK; Close();
                }
                finally { btnXacNhan.Enabled = true; }
            });
        }

    }
}
