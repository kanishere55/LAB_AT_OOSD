using System;
using System.Data;
using System.Windows.Forms;
using QuanLyThuVien.Services;
namespace QuanLyThuVien.Forms
{
    public partial class FrmSach : Form
    {
        private readonly SachService service = new SachService();
        private readonly DanhMucService danhMuc = new DanhMucService();
        public FrmSach() { InitializeComponent(); }
        private void FrmSach_Load(object sender, EventArgs e)
        {
            cboTheLoai.DataSource = danhMuc.LayTheLoai(); cboTheLoai.DisplayMember = "TenTheLoai"; cboTheLoai.ValueMember = "MaTheLoai";
            cboNXB.DataSource = danhMuc.LayNhaXuatBan(); cboNXB.DisplayMember = "MaNhaXuatBan"; cboNXB.ValueMember = "MaNhaXuatBan";
            TaiDuLieu(); LamMoi();
        }
        private void TaiDuLieu()
        {
            dgvSach.DataSource = service.LayDanhSach(txtTim.Text.Trim());
            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private DauSach LayDuLieuForm()
        {
            return new DauSach
            {
                MaDauSach = txtMa.Text.Trim(), TenSach = txtTen.Text.Trim(),
                NamXuatBan = (int)numNam.Value, SoLuongHienCo = (int)numSoLuong.Value,
                MaTheLoai = cboTheLoai.SelectedValue == null ? "" : cboTheLoai.SelectedValue.ToString(),
                MaNhaXuatBan = cboNXB.SelectedValue == null ? "" : cboNXB.SelectedValue.ToString()
            };
        }
        private void HienKetQua(KetQuaXuLy kq)
        {
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK, kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (kq.ThanhCong) { TaiDuLieu(); LamMoi(); }
        }
        private void btnThem_Click(object sender, EventArgs e) { HienKetQua(service.Luu(LayDuLieuForm(), false)); }
        private void btnCapNhat_Click(object sender, EventArgs e) { HienKetQua(service.Luu(LayDuLieuForm(), true)); }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text)) return;
            if (MessageBox.Show("Xóa đầu sách đang chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                HienKetQua(service.Xoa(txtMa.Text.Trim()));
        }
        private void btnLamMoi_Click(object sender, EventArgs e) { LamMoi(); }
        private void btnTim_Click(object sender, EventArgs e) { TaiDuLieu(); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
        private void LamMoi()
        {
            txtMa.Clear(); txtTen.Clear(); numNam.Value = DateTime.Today.Year; numSoLuong.Value = 0;
            txtMa.ReadOnly = false; txtMa.Focus(); btnThem.Enabled = true; btnCapNhat.Enabled = false; btnXoa.Enabled = false;
        }
        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow == null || dgvSach.CurrentRow.DataBoundItem == null) return;
            DataRowView r = dgvSach.CurrentRow.DataBoundItem as DataRowView; if (r == null) return;
            txtMa.Text = Convert.ToString(r["MaDauSach"]); txtTen.Text = Convert.ToString(r["TenSach"]);
            numNam.Value = Convert.ToDecimal(r["NamXuatBan"]); numSoLuong.Value = Convert.ToDecimal(r["SoLuongHienCo"]);
            cboTheLoai.SelectedValue = Convert.ToString(r["MaTheLoai"]); cboNXB.SelectedValue = Convert.ToString(r["MaNhaXuatBan"]);
            txtMa.ReadOnly = true; btnThem.Enabled = false; btnCapNhat.Enabled = true; btnXoa.Enabled = true;
        }
    }
}
