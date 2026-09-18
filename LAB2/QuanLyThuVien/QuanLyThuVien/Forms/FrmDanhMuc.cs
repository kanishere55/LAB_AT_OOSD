using System;
using System.Data;
using System.Windows.Forms;
using QuanLyThuVien.Services;
namespace QuanLyThuVien.Forms
{
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService service = new DanhMucService();
        public FrmDanhMuc() { InitializeComponent(); }
        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            cboNVPhai.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            if (cboNVPhai.Items.Count > 0) cboNVPhai.SelectedIndex = 0;
            TaiTatCa(); LamMoiNV(); LamMoiTL(); LamMoiNXB();
        }
        private void TaiTatCa()
        {
            dgvNV.DataSource = service.LayNhanVien(); dgvTL.DataSource = service.LayTheLoai(); dgvNXB.DataSource = service.LayNhaXuatBan();
            dgvNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvTL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ShowResult(KetQuaXuLy kq)
        {
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thông báo" : "Lỗi", MessageBoxButtons.OK,
                kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (kq.ThanhCong) TaiTatCa();
        }
        private void btnNVThem_Click(object sender, EventArgs e)
        {
            ShowResult(service.LuuNhanVien(new NhanVien { MaNhanVien=txtNVMa.Text.Trim(), Ho=txtNVHo.Text.Trim(),
                Ten=txtNVTen.Text.Trim(), Phai=Convert.ToString(cboNVPhai.SelectedItem), NgaySinh=dtNVNgaySinh.Value,
                ChucVu=txtNVChucVu.Text.Trim(), SoDienThoai=txtNVSDT.Text.Trim() }, false));
        }
        private void btnNVCapNhat_Click(object sender, EventArgs e)
        {
            ShowResult(service.LuuNhanVien(new NhanVien { MaNhanVien=txtNVMa.Text.Trim(), Ho=txtNVHo.Text.Trim(),
                Ten=txtNVTen.Text.Trim(), Phai=Convert.ToString(cboNVPhai.SelectedItem), NgaySinh=dtNVNgaySinh.Value,
                ChucVu=txtNVChucVu.Text.Trim(), SoDienThoai=txtNVSDT.Text.Trim() }, true));
        }
        private void btnNVXoa_Click(object sender, EventArgs e) { if (XacNhanXoa()) ShowResult(service.Xoa("NhanVien","MaNhanVien",txtNVMa.Text.Trim())); }
        private void btnNVMoi_Click(object sender, EventArgs e) { LamMoiNV(); }
        private void dgvNV_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = dgvNV.CurrentRow == null ? null : dgvNV.CurrentRow.DataBoundItem as DataRowView; if (r == null) return;
            txtNVMa.Text=Convert.ToString(r["MaNhanVien"]); txtNVHo.Text=Convert.ToString(r["Ho"]);
            txtNVTen.Text=Convert.ToString(r["Ten"]); cboNVPhai.SelectedItem=Convert.ToString(r["Phai"]);
            dtNVNgaySinh.Value=Convert.ToDateTime(r["NgaySinh"]); txtNVChucVu.Text=Convert.ToString(r["ChucVu"]);
            txtNVSDT.Text=Convert.ToString(r["SoDienThoai"]); txtNVMa.ReadOnly=true; btnNVThem.Enabled=false; btnNVCapNhat.Enabled=true; btnNVXoa.Enabled=true;
        }
        private void LamMoiNV() { txtNVMa.Clear(); txtNVHo.Clear(); txtNVTen.Clear(); txtNVChucVu.Clear(); txtNVSDT.Clear();
            dtNVNgaySinh.Value=DateTime.Today.AddYears(-25); txtNVMa.ReadOnly=false; btnNVThem.Enabled=true; btnNVCapNhat.Enabled=false; btnNVXoa.Enabled=false; }
        private void btnTLThem_Click(object sender, EventArgs e) { ShowResult(service.LuuTheLoai(txtTLMa.Text,txtTLTen.Text,false)); }
        private void btnTLCapNhat_Click(object sender, EventArgs e) { ShowResult(service.LuuTheLoai(txtTLMa.Text,txtTLTen.Text,true)); }
        private void btnTLXoa_Click(object sender, EventArgs e) { if (XacNhanXoa()) ShowResult(service.Xoa("TheLoai","MaTheLoai",txtTLMa.Text.Trim())); }
        private void btnTLMoi_Click(object sender, EventArgs e) { LamMoiTL(); }
        private void dgvTL_SelectionChanged(object sender, EventArgs e) { DataRowView r=dgvTL.CurrentRow==null?null:dgvTL.CurrentRow.DataBoundItem as DataRowView; if(r==null)return;
            txtTLMa.Text=Convert.ToString(r["MaTheLoai"]); txtTLTen.Text=Convert.ToString(r["TenTheLoai"]); txtTLMa.ReadOnly=true;
            btnTLThem.Enabled=false; btnTLCapNhat.Enabled=true; btnTLXoa.Enabled=true; }
        private void LamMoiTL() { txtTLMa.Clear(); txtTLTen.Clear(); txtTLMa.ReadOnly=false; btnTLThem.Enabled=true; btnTLCapNhat.Enabled=false; btnTLXoa.Enabled=false; }
        private void btnNXBThem_Click(object sender, EventArgs e) { ShowResult(service.LuuNhaXuatBan(txtNXBMa.Text,txtNXBDiaChi.Text,txtNXBSDT.Text,false)); }
        private void btnNXBCapNhat_Click(object sender, EventArgs e) { ShowResult(service.LuuNhaXuatBan(txtNXBMa.Text,txtNXBDiaChi.Text,txtNXBSDT.Text,true)); }
        private void btnNXBXoa_Click(object sender, EventArgs e) { if (XacNhanXoa()) ShowResult(service.Xoa("NhaXuatBan","MaNhaXuatBan",txtNXBMa.Text.Trim())); }
        private void btnNXBMoi_Click(object sender, EventArgs e) { LamMoiNXB(); }
        private void dgvNXB_SelectionChanged(object sender, EventArgs e) { DataRowView r=dgvNXB.CurrentRow==null?null:dgvNXB.CurrentRow.DataBoundItem as DataRowView; if(r==null)return;
            txtNXBMa.Text=Convert.ToString(r["MaNhaXuatBan"]); txtNXBDiaChi.Text=Convert.ToString(r["DiaChi"]);
            txtNXBSDT.Text=Convert.ToString(r["SoDienThoai"]); txtNXBMa.ReadOnly=true; btnNXBThem.Enabled=false; btnNXBCapNhat.Enabled=true; btnNXBXoa.Enabled=true; }
        private void LamMoiNXB() { txtNXBMa.Clear(); txtNXBDiaChi.Clear(); txtNXBSDT.Clear(); txtNXBMa.ReadOnly=false;
            btnNXBThem.Enabled=true; btnNXBCapNhat.Enabled=false; btnNXBXoa.Enabled=false; }
        private bool XacNhanXoa() { return MessageBox.Show("Xóa dữ liệu đang chọn?", "Xác nhận", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)==DialogResult.Yes; }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
