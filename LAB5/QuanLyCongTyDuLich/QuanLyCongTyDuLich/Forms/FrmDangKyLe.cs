using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCongTyDuLich.Services;

namespace QuanLyCongTyDuLich.Forms
{
    public partial class FrmDangKyLe : Form
    {
        private readonly DangKyLeService svc = new DangKyLeService();

        public FrmDangKyLe()
        {
            InitializeComponent();
        }

        private void FrmDangKyLe_Load(object sender, EventArgs e)
        {
            FormHelper.Nap(cboChuyen, new ChuyenLeService().LayChuyenMo(), "HienThi", "MaChuyen");
            FormHelper.Nap(cboDiemBan, new DanhMucService().LayDiemBan(), "TenDiemBan", "MaDiemBan");
            Tai();
            TinhTien(sender, e);
        }

        private void Tai()
        {
            dgv.DataSource = svc.LayDanhSach();
            // Giữ 9 cột như Hình P.30; Service vẫn trả đủ thông tin.
            dgv.Columns["NgayVe"].Visible = false;
            dgv.Columns["DienThoai"].Visible = false;
            FormHelper.KichThuocBangThayDoi(dgv, EventArgs.Empty);
        }

        private void TinhTien(object sender, EventArgs e)
        {
            var r = cboChuyen.SelectedItem as DataRowView;
            lblThanhTien.Text = r == null ? "0 đ" : (Convert.ToDecimal(r["DonGiaKhach"]) * numNguoi.Value).ToString("N0") + " đ";
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.DangKy(txtSo.Text, FormHelper.Gia(cboChuyen), FormHelper.Gia(cboDiemBan), txtTen.Text, txtDT.Text, (int)numNguoi.Value))) Tai();
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
