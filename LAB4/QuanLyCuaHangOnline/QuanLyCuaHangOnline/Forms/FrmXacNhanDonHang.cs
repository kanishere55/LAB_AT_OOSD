using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyCuaHangOnline
{
    public partial class FrmXacNhanDonHang : Form
    {
        private AppContext app;
        public FrmXacNhanDonHang() { InitializeComponent(); }
        public FrmXacNhanDonHang(AppContext context, DonHang order) : this()
        {
            app = context;
            lblMaDon.Text = "Đơn hàng #" + order.MaDH + " - " + order.ThoiDiem.ToString("dd/MM/yyyy HH:mm:ss");
            lblNguoiMua.Text = "Người mua: " + order.NguoiMua.HoTen;
            lblNguoiNhan.Text = "Người nhận: " + order.NguoiNhan.HoTen + " - " + order.NguoiNhan.DienThoai + Environment.NewLine + "Địa chỉ: " + order.NguoiNhan.DiaChi;
            lblTongTien.Text = "Tổng thanh toán: " + order.Quote.TongTien.ToString("N0") + " đ";
            lblThanhToan.Text = "Thanh toán: " + order.LoaiThe + " **** " + order.BonSoCuoi + " - " + order.MaGiaoDich;
            dgvChiTiet.DataSource = order.Quote.Items.Select(i => new { i.MaSP, i.TenSP, i.SoLuong, i.DonGia, i.ThanhTien }).ToList();
            FormHelper.FormatGrid(dgvChiTiet);
            lblEmail.Text = "Email xác nhận: " + (order.EmailStatus == "DaGui" ? "Đã ghi nhận gửi (mô phỏng)" : order.EmailStatus == "LoiGui" ? "Gửi chưa thành công" : order.EmailStatus);
        }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }

    }
}
