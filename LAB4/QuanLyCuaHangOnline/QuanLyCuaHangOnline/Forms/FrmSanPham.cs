using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyCuaHangOnline
{
    public partial class FrmSanPham : Form
    {
        private AppContext app;
        public FrmSanPham() { InitializeComponent(); }
        private List<NhomSanPham> groups;
        public FrmSanPham(AppContext context) : this()
        {
            app = context; groups = app.Products.Groups();
            cboNhom.Items.Add("Tất cả nhóm");
            cboNhom.Items.AddRange(groups.Select(x => (object)x.TenNhom).ToArray());
            cboNhom.SelectedIndex = 0; LoadRows();
            cboNhom.SelectedIndexChanged += (s, e) => FormHelper.Run(this, LoadRows);
            txtTuKhoa.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; FormHelper.Run(this, LoadRows); } };
        }
        private string SelectedCode()
        {
            if (dgvSanPham.CurrentRow == null) throw new ArgumentException("Chọn một sản phẩm.");
            return (string)dgvSanPham.CurrentRow.Cells["MaSP"].Value;
        }
        public void LoadRows()
        {
            string group = cboNhom.SelectedIndex == 0 ? null : groups[cboNhom.SelectedIndex - 1].MaNhom;
            dgvSanPham.DataSource = app.Products.Search(group, txtTuKhoa.Text).Select(p => new { p.MaSP, p.TenSP, p.NhaSanXuat, DonGia = p.GiaHienHanh, TrangThai = p.ConHang ? "Còn hàng" : "Hết hàng" }).ToList();
            FormHelper.FormatGrid(dgvSanPham);
        }
        private void btnTim_Click(object sender, EventArgs e) { FormHelper.Run(this, LoadRows); }
        private void btnChiTiet_Click(object sender, EventArgs e) { FormHelper.Run(this, () => { using (var f = new FrmChiTietSanPham(app, SelectedCode())) f.ShowDialog(this); }); }
        private void btnThem_Click(object sender, EventArgs e) { FormHelper.Run(this, () => { app.Cart.Add(SelectedCode(), (int)nudSoLuong.Value); MessageBox.Show(this, "Đã thêm sản phẩm vào giỏ.", "e-SHOPPING"); }); }

    }
}
