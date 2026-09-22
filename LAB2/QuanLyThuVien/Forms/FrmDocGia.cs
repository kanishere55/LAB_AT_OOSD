using System;
using System.Data;
using System.Windows.Forms;
using QuanLyThuVien.Services;
namespace QuanLyThuVien.Forms
{
    public partial class FrmDocGia : Form
    {
        private readonly DocGiaService service = new DocGiaService();
        public FrmDocGia() { InitializeComponent(); }
        private void FrmDocGia_Load(object sender, EventArgs e)
        {
            cboPhai.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            if (cboPhai.Items.Count > 0) cboPhai.SelectedIndex = 0;
            dtNgayCap.Value = DateTime.Today; dtHan.Value = DateTime.Today.AddYears(1);
            TaiDuLieu(); LamMoi();
        }
        private void TaiDuLieu()
        {
            dgvDocGia.DataSource = service.LayDanhSach();
            dgvDocGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private DocGia LayForm()
        {
            return new DocGia
            {
                MaDocGia = txtMa.Text.Trim(), Ho = txtHo.Text.Trim(), Ten = txtTen.Text.Trim(),
                NgaySinh = dtNgaySinh.Value.Date, Phai = Convert.ToString(cboPhai.SelectedItem),
                SoDienThoai = txtSDT.Text.Trim(), DiaChi = txtDiaChi.Text.Trim(),
                Email = txtEmail.Text.Trim(), Anh3x4 = txtAnh.Text.Trim()
            };
        }
        private void ShowResult(KetQuaXuLy kq)
        {
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK, kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (kq.ThanhCong) { TaiDuLieu(); LamMoi(); }
        }
        private void btnThem_Click(object sender, EventArgs e) { ShowResult(service.Luu(LayForm(), false)); }
        private void btnCapNhat_Click(object sender, EventArgs e) { ShowResult(service.Luu(LayForm(), true)); }
        private void btnCapThe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text)) { MessageBox.Show("Vui lòng chọn độc giả."); return; }
            ShowResult(service.CapThe(txtMa.Text.Trim(), dtNgayCap.Value, dtHan.Value, chkLePhi.Checked));
        }
        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text)) { MessageBox.Show("Vui lòng chọn độc giả."); return; }
            ShowResult(service.GiaHanThe(txtMa.Text.Trim(), dtHan.Value, chkLePhi.Checked));
        }
        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoi(); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
        private void LamMoi()
        {
            txtMa.Clear(); txtHo.Clear(); txtTen.Clear(); txtSDT.Clear(); txtDiaChi.Clear(); txtEmail.Clear(); txtAnh.Clear();
            dtNgaySinh.Value = DateTime.Today.AddYears(-18); dtNgayCap.Value = DateTime.Today; dtHan.Value = DateTime.Today.AddYears(1); chkLePhi.Checked = true;
            txtMa.ReadOnly = false; btnThem.Enabled = true; btnCapNhat.Enabled = false; txtMa.Focus();
        }
        private void dgvDocGia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDocGia.CurrentRow == null || dgvDocGia.CurrentRow.DataBoundItem == null) return;
            DataRowView r = dgvDocGia.CurrentRow.DataBoundItem as DataRowView; if (r == null) return;
            txtMa.Text = Convert.ToString(r["MaDocGia"]); txtHo.Text = Convert.ToString(r["Ho"]); txtTen.Text = Convert.ToString(r["Ten"]);
            if (r["NgaySinh"] != DBNull.Value) dtNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
            cboPhai.SelectedItem = Convert.ToString(r["Phai"]); txtSDT.Text = Convert.ToString(r["SoDienThoai"]); txtDiaChi.Text = Convert.ToString(r["DiaChi"]);
            txtEmail.Text = Convert.ToString(r["Email"]); txtAnh.Text = Convert.ToString(r["Anh3x4"]);
            if (r["NgayCap"] != DBNull.Value) dtNgayCap.Value = Convert.ToDateTime(r["NgayCap"]);
            if (r["HanSuDung"] != DBNull.Value) dtHan.Value = Convert.ToDateTime(r["HanSuDung"]);
            chkLePhi.Checked = r["DaDongLePhi"] != DBNull.Value && Convert.ToBoolean(r["DaDongLePhi"]);
            txtMa.ReadOnly = true; btnThem.Enabled = false; btnCapNhat.Enabled = true;
        }
    }
}
