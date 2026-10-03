using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyCuaHangOnline
{
    public partial class FrmChiTietSanPham : Form
    {
        private AppContext app;
        public FrmChiTietSanPham() { InitializeComponent(); }
        private SanPham product;
        public FrmChiTietSanPham(AppContext context, string code) : this()
        {
            app = context; product = app.Products.Get(code);
            if (product == null) throw new ArgumentException("Không tìm thấy sản phẩm.");
            txtMaSP.Text = product.MaSP; txtTenSP.Text = product.TenSP;
            txtNhom.Text = app.Products.Groups().Single(x => x.MaNhom == product.MaNhom).TenNhom;
            txtNSX.Text = product.NhaSanXuat; txtGia.Text = product.GiaHienHanh.ToString("N0");
            txtTinhTrang.Text = product.ConHang ? "Còn hàng" : "Hết hàng";
            txtMoTa.Text = product.MoTa; txtThongSo.Text = product.ThongSo;
            cboHinhAnh.Items.AddRange(product.HinhAnh.Select((p, i) => (object)("Ảnh " + (i + 1))).ToArray());
            if (cboHinhAnh.Items.Count == 0) cboHinhAnh.Items.Add("Không có ảnh");
            cboHinhAnh.SelectedIndex = 0; LoadImage();
            cboHinhAnh.SelectedIndexChanged += (s, e) => LoadImage();
            FormClosed += (s, e) => { if (picSanPham.Image != null) picSanPham.Image.Dispose(); };
        }
        private void LoadImage()
        {
            if (picSanPham.Image != null) { picSanPham.Image.Dispose(); picSanPham.Image = null; }
            if (product.HinhAnh.Count == 0) return;
            string path = Path.Combine(Application.StartupPath, product.HinhAnh[cboHinhAnh.SelectedIndex]);
            if (File.Exists(path)) { using (var original = Image.FromFile(path)) picSanPham.Image = new Bitmap(original); }
        }
        private void btnThem_Click(object sender, EventArgs e) { FormHelper.Run(this, () => { app.Cart.Add(product.MaSP, (int)nudSoLuong.Value); MessageBox.Show(this, "Đã thêm sản phẩm vào giỏ.", "e-SHOPPING"); }); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }

    }
}
