namespace QuanLyKhachSan.Forms
{
    partial class FrmDanhMuc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            dgvHeaderStyle.ForeColor = System.Drawing.Color.Black;
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabKhuVuc = new System.Windows.Forms.TabPage();
            this.btnThemKhu = new System.Windows.Forms.Button();
            this.txtKhuTen = new System.Windows.Forms.TextBox();
            this.lblKhuTen = new System.Windows.Forms.Label();
            this.txtKhuMa = new System.Windows.Forms.TextBox();
            this.lblKhuMa = new System.Windows.Forms.Label();
            this.dgvKhu = new System.Windows.Forms.DataGridView();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.txtNVSDT = new System.Windows.Forms.TextBox();
            this.lblNVSDT = new System.Windows.Forms.Label();
            this.txtNVVaiTro = new System.Windows.Forms.TextBox();
            this.lblNVVaiTro = new System.Windows.Forms.Label();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.lblNVTen = new System.Windows.Forms.Label();
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.lblNVMa = new System.Windows.Forms.Label();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.tabLoaiTN = new System.Windows.Forms.TabPage();
            this.btnThemLoaiTN = new System.Windows.Forms.Button();
            this.txtLoaiTen = new System.Windows.Forms.TextBox();
            this.lblLoaiTen = new System.Windows.Forms.Label();
            this.txtLoaiMa = new System.Windows.Forms.TextBox();
            this.lblLoaiMa = new System.Windows.Forms.Label();
            this.dgvLoaiTN = new System.Windows.Forms.DataGridView();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.numDVGia = new System.Windows.Forms.NumericUpDown();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.lblDVGia = new System.Windows.Forms.Label();
            this.txtDVDVT = new System.Windows.Forms.TextBox();
            this.lblDVDVT = new System.Windows.Forms.Label();
            this.txtDVTen = new System.Windows.Forms.TextBox();
            this.lblDVTen = new System.Windows.Forms.Label();
            this.txtDVMa = new System.Windows.Forms.TextBox();
            this.lblDVMa = new System.Windows.Forms.Label();
            this.dgvDV = new System.Windows.Forms.DataGridView();
            this.tabQuyDinh = new System.Windows.Forms.TabPage();
            this.numQDTien = new System.Windows.Forms.NumericUpDown();
            this.lblQDTien = new System.Windows.Forms.Label();
            this.txtQDMucDo = new System.Windows.Forms.TextBox();
            this.lblQDMucDo = new System.Windows.Forms.Label();
            this.cboQDLoai = new System.Windows.Forms.ComboBox();
            this.lblQDLoai = new System.Windows.Forms.Label();
            this.btnThemQD = new System.Windows.Forms.Button();
            this.txtQDMa = new System.Windows.Forms.TextBox();
            this.lblQDMa = new System.Windows.Forms.Label();
            this.dgvQD = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabKhuVuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).BeginInit();
            this.tabNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.tabLoaiTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTN)).BeginInit();
            this.tabDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDVGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            this.tabQuyDinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQDTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKhuVuc);
            this.tabControl1.Controls.Add(this.tabNhanVien);
            this.tabControl1.Controls.Add(this.tabLoaiTN);
            this.tabControl1.Controls.Add(this.tabDichVu);
            this.tabControl1.Controls.Add(this.tabQuyDinh);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 3;
            this.tabControl1.Size = new System.Drawing.Size(890, 470);
            this.tabControl1.TabIndex = 0;
            // 
            // tabKhuVuc
            // 
            this.tabKhuVuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabKhuVuc.Controls.Add(this.btnThemKhu);
            this.tabKhuVuc.Controls.Add(this.txtKhuTen);
            this.tabKhuVuc.Controls.Add(this.lblKhuTen);
            this.tabKhuVuc.Controls.Add(this.txtKhuMa);
            this.tabKhuVuc.Controls.Add(this.lblKhuMa);
            this.tabKhuVuc.Controls.Add(this.dgvKhu);
            this.tabKhuVuc.Location = new System.Drawing.Point(4, 30);
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.Size = new System.Drawing.Size(882, 436);
            this.tabKhuVuc.TabIndex = 0;
            this.tabKhuVuc.Text = "Khu vực";
            // 
            // btnThemKhu
            // 
            this.btnThemKhu.Location = new System.Drawing.Point(745, 14);
            this.btnThemKhu.Name = "btnThemKhu";
            this.btnThemKhu.Size = new System.Drawing.Size(110, 32);
            this.btnThemKhu.TabIndex = 5;
            this.btnThemKhu.Text = "Thêm";
            this.btnThemKhu.UseVisualStyleBackColor = true;
            this.btnThemKhu.Click += new System.EventHandler(this.btnThemKhu_Click);
            // 
            // txtKhuTen
            // 
            this.txtKhuTen.Location = new System.Drawing.Point(340, 16);
            this.txtKhuTen.Name = "txtKhuTen";
            this.txtKhuTen.Size = new System.Drawing.Size(260, 29);
            this.txtKhuTen.TabIndex = 4;
            // 
            // lblKhuTen
            // 
            this.lblKhuTen.AutoSize = true;
            this.lblKhuTen.Location = new System.Drawing.Point(265, 19);
            this.lblKhuTen.Name = "lblKhuTen";
            this.lblKhuTen.Size = new System.Drawing.Size(69, 21);
            this.lblKhuTen.TabIndex = 3;
            this.lblKhuTen.Text = "Tên khu:";
            // 
            // txtKhuMa
            // 
            this.txtKhuMa.Location = new System.Drawing.Point(85, 16);
            this.txtKhuMa.Name = "txtKhuMa";
            this.txtKhuMa.Size = new System.Drawing.Size(150, 29);
            this.txtKhuMa.TabIndex = 2;
            // 
            // lblKhuMa
            // 
            this.lblKhuMa.AutoSize = true;
            this.lblKhuMa.Location = new System.Drawing.Point(15, 19);
            this.lblKhuMa.Name = "lblKhuMa";
            this.lblKhuMa.Size = new System.Drawing.Size(64, 21);
            this.lblKhuMa.TabIndex = 1;
            this.lblKhuMa.Text = "Mã khu:";
            // 
            // dgvKhu
            // 
            this.dgvKhu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhu.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhu.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvKhu.EnableHeadersVisualStyles = false;
            this.dgvKhu.GridColor = System.Drawing.Color.LightGray;
            this.dgvKhu.Location = new System.Drawing.Point(15, 60);
            this.dgvKhu.Name = "dgvKhu";
            this.dgvKhu.RowHeadersWidth = 51;
            this.dgvKhu.RowTemplate.Height = 28;
            this.dgvKhu.Size = new System.Drawing.Size(850, 360);
            this.dgvKhu.TabIndex = 0;
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabNhanVien.Controls.Add(this.btnThemNV);
            this.tabNhanVien.Controls.Add(this.txtNVSDT);
            this.tabNhanVien.Controls.Add(this.lblNVSDT);
            this.tabNhanVien.Controls.Add(this.txtNVVaiTro);
            this.tabNhanVien.Controls.Add(this.lblNVVaiTro);
            this.tabNhanVien.Controls.Add(this.txtNVTen);
            this.tabNhanVien.Controls.Add(this.lblNVTen);
            this.tabNhanVien.Controls.Add(this.txtNVMa);
            this.tabNhanVien.Controls.Add(this.lblNVMa);
            this.tabNhanVien.Controls.Add(this.dgvNV);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 30);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Size = new System.Drawing.Size(882, 436);
            this.tabNhanVien.TabIndex = 1;
            this.tabNhanVien.Text = "Nhân viên";
            // 
            // btnThemNV
            // 
            this.btnThemNV.Location = new System.Drawing.Point(755, 14);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(100, 32);
            this.btnThemNV.TabIndex = 9;
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.UseVisualStyleBackColor = true;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // txtNVSDT
            // 
            this.txtNVSDT.Location = new System.Drawing.Point(615, 16);
            this.txtNVSDT.Name = "txtNVSDT";
            this.txtNVSDT.Size = new System.Drawing.Size(120, 29);
            this.txtNVSDT.TabIndex = 8;
            // 
            // lblNVSDT
            // 
            this.lblNVSDT.AutoSize = true;
            this.lblNVSDT.Location = new System.Drawing.Point(570, 19);
            this.lblNVSDT.Name = "lblNVSDT";
            this.lblNVSDT.Size = new System.Drawing.Size(41, 21);
            this.lblNVSDT.TabIndex = 7;
            this.lblNVSDT.Text = "SĐT:";
            // 
            // txtNVVaiTro
            // 
            this.txtNVVaiTro.Location = new System.Drawing.Point(435, 16);
            this.txtNVVaiTro.Name = "txtNVVaiTro";
            this.txtNVVaiTro.Size = new System.Drawing.Size(120, 29);
            this.txtNVVaiTro.TabIndex = 6;
            // 
            // lblNVVaiTro
            // 
            this.lblNVVaiTro.AutoSize = true;
            this.lblNVVaiTro.Location = new System.Drawing.Point(375, 19);
            this.lblNVVaiTro.Name = "lblNVVaiTro";
            this.lblNVVaiTro.Size = new System.Drawing.Size(58, 21);
            this.lblNVVaiTro.TabIndex = 5;
            this.lblNVVaiTro.Text = "Vai trò:";
            // 
            // txtNVTen
            // 
            this.txtNVTen.Location = new System.Drawing.Point(215, 16);
            this.txtNVTen.Name = "txtNVTen";
            this.txtNVTen.Size = new System.Drawing.Size(145, 29);
            this.txtNVTen.TabIndex = 4;
            // 
            // lblNVTen
            // 
            this.lblNVTen.AutoSize = true;
            this.lblNVTen.Location = new System.Drawing.Point(155, 19);
            this.lblNVTen.Name = "lblNVTen";
            this.lblNVTen.Size = new System.Drawing.Size(59, 21);
            this.lblNVTen.TabIndex = 3;
            this.lblNVTen.Text = "Họ tên:";
            // 
            // txtNVMa
            // 
            this.txtNVMa.Location = new System.Drawing.Point(60, 16);
            this.txtNVMa.Name = "txtNVMa";
            this.txtNVMa.Size = new System.Drawing.Size(80, 29);
            this.txtNVMa.TabIndex = 2;
            // 
            // lblNVMa
            // 
            this.lblNVMa.AutoSize = true;
            this.lblNVMa.Location = new System.Drawing.Point(15, 19);
            this.lblNVMa.Name = "lblNVMa";
            this.lblNVMa.Size = new System.Drawing.Size(35, 21);
            this.lblNVMa.TabIndex = 1;
            this.lblNVMa.Text = "Mã:";
            // 
            // dgvNV
            // 
            this.dgvNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNV.BackgroundColor = System.Drawing.Color.White;
            this.dgvNV.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvNV.EnableHeadersVisualStyles = false;
            this.dgvNV.GridColor = System.Drawing.Color.LightGray;
            this.dgvNV.Location = new System.Drawing.Point(15, 60);
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.RowHeadersWidth = 51;
            this.dgvNV.RowTemplate.Height = 28;
            this.dgvNV.Size = new System.Drawing.Size(850, 360);
            this.dgvNV.TabIndex = 0;
            // 
            // tabLoaiTN
            // 
            this.tabLoaiTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabLoaiTN.Controls.Add(this.btnThemLoaiTN);
            this.tabLoaiTN.Controls.Add(this.txtLoaiTen);
            this.tabLoaiTN.Controls.Add(this.lblLoaiTen);
            this.tabLoaiTN.Controls.Add(this.txtLoaiMa);
            this.tabLoaiTN.Controls.Add(this.lblLoaiMa);
            this.tabLoaiTN.Controls.Add(this.dgvLoaiTN);
            this.tabLoaiTN.Location = new System.Drawing.Point(4, 30);
            this.tabLoaiTN.Name = "tabLoaiTN";
            this.tabLoaiTN.Size = new System.Drawing.Size(882, 436);
            this.tabLoaiTN.TabIndex = 2;
            this.tabLoaiTN.Text = "Loại tiện nghi";
            // 
            // btnThemLoaiTN
            // 
            this.btnThemLoaiTN.Location = new System.Drawing.Point(745, 14);
            this.btnThemLoaiTN.Name = "btnThemLoaiTN";
            this.btnThemLoaiTN.Size = new System.Drawing.Size(110, 32);
            this.btnThemLoaiTN.TabIndex = 5;
            this.btnThemLoaiTN.Text = "Thêm";
            this.btnThemLoaiTN.UseVisualStyleBackColor = true;
            this.btnThemLoaiTN.Click += new System.EventHandler(this.btnThemLoaiTN_Click);
            // 
            // txtLoaiTen
            // 
            this.txtLoaiTen.Location = new System.Drawing.Point(340, 16);
            this.txtLoaiTen.Name = "txtLoaiTen";
            this.txtLoaiTen.Size = new System.Drawing.Size(260, 29);
            this.txtLoaiTen.TabIndex = 4;
            // 
            // lblLoaiTen
            // 
            this.lblLoaiTen.AutoSize = true;
            this.lblLoaiTen.Location = new System.Drawing.Point(265, 19);
            this.lblLoaiTen.Name = "lblLoaiTen";
            this.lblLoaiTen.Size = new System.Drawing.Size(68, 21);
            this.lblLoaiTen.TabIndex = 3;
            this.lblLoaiTen.Text = "Tên loại:";
            // 
            // txtLoaiMa
            // 
            this.txtLoaiMa.Location = new System.Drawing.Point(85, 16);
            this.txtLoaiMa.Name = "txtLoaiMa";
            this.txtLoaiMa.Size = new System.Drawing.Size(150, 29);
            this.txtLoaiMa.TabIndex = 2;
            // 
            // lblLoaiMa
            // 
            this.lblLoaiMa.AutoSize = true;
            this.lblLoaiMa.Location = new System.Drawing.Point(15, 19);
            this.lblLoaiMa.Name = "lblLoaiMa";
            this.lblLoaiMa.Size = new System.Drawing.Size(65, 21);
            this.lblLoaiMa.TabIndex = 1;
            this.lblLoaiMa.Text = "Mã loại:";
            // 
            // dgvLoaiTN
            // 
            this.dgvLoaiTN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiTN.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoaiTN.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvLoaiTN.EnableHeadersVisualStyles = false;
            this.dgvLoaiTN.GridColor = System.Drawing.Color.LightGray;
            this.dgvLoaiTN.Location = new System.Drawing.Point(15, 60);
            this.dgvLoaiTN.Name = "dgvLoaiTN";
            this.dgvLoaiTN.RowHeadersWidth = 51;
            this.dgvLoaiTN.RowTemplate.Height = 28;
            this.dgvLoaiTN.Size = new System.Drawing.Size(850, 360);
            this.dgvLoaiTN.TabIndex = 0;
            // 
            // tabDichVu
            // 
            this.tabDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabDichVu.Controls.Add(this.numDVGia);
            this.tabDichVu.Controls.Add(this.btnThemDV);
            this.tabDichVu.Controls.Add(this.lblDVGia);
            this.tabDichVu.Controls.Add(this.txtDVDVT);
            this.tabDichVu.Controls.Add(this.lblDVDVT);
            this.tabDichVu.Controls.Add(this.txtDVTen);
            this.tabDichVu.Controls.Add(this.lblDVTen);
            this.tabDichVu.Controls.Add(this.txtDVMa);
            this.tabDichVu.Controls.Add(this.lblDVMa);
            this.tabDichVu.Controls.Add(this.dgvDV);
            this.tabDichVu.Location = new System.Drawing.Point(4, 30);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Size = new System.Drawing.Size(882, 436);
            this.tabDichVu.TabIndex = 3;
            this.tabDichVu.Text = "Dịch vụ";
            // 
            // numDVGia
            // 
            this.numDVGia.Location = new System.Drawing.Point(620, 16);
            this.numDVGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numDVGia.Name = "numDVGia";
            this.numDVGia.Size = new System.Drawing.Size(120, 29);
            this.numDVGia.TabIndex = 9;
            // 
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(760, 14);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(105, 32);
            this.btnThemDV.TabIndex = 8;
            this.btnThemDV.Text = "Thêm";
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // lblDVGia
            // 
            this.lblDVGia.AutoSize = true;
            this.lblDVGia.Location = new System.Drawing.Point(545, 19);
            this.lblDVGia.Name = "lblDVGia";
            this.lblDVGia.Size = new System.Drawing.Size(68, 21);
            this.lblDVGia.TabIndex = 7;
            this.lblDVGia.Text = "Đơn giá:";
            // 
            // txtDVDVT
            // 
            this.txtDVDVT.Location = new System.Drawing.Point(425, 16);
            this.txtDVDVT.Name = "txtDVDVT";
            this.txtDVDVT.Size = new System.Drawing.Size(105, 29);
            this.txtDVDVT.TabIndex = 6;
            this.txtDVDVT.Text = "Suất";
            // 
            // lblDVDVT
            // 
            this.lblDVDVT.AutoSize = true;
            this.lblDVDVT.Location = new System.Drawing.Point(300, 19);
            this.lblDVDVT.Name = "lblDVDVT";
            this.lblDVDVT.Size = new System.Drawing.Size(124, 21);
            this.lblDVDVT.TabIndex = 5;
            this.lblDVDVT.Text = "Đơn vị / Vai trò:";
            // 
            // txtDVTen
            // 
            this.txtDVTen.Location = new System.Drawing.Point(170, 16);
            this.txtDVTen.Name = "txtDVTen";
            this.txtDVTen.Size = new System.Drawing.Size(120, 29);
            this.txtDVTen.TabIndex = 4;
            this.txtDVTen.Text = "Ăn sáng";
            // 
            // lblDVTen
            // 
            this.lblDVTen.AutoSize = true;
            this.lblDVTen.Location = new System.Drawing.Point(130, 19);
            this.lblDVTen.Name = "lblDVTen";
            this.lblDVTen.Size = new System.Drawing.Size(36, 21);
            this.lblDVTen.TabIndex = 3;
            this.lblDVTen.Text = "Tên:";
            // 
            // txtDVMa
            // 
            this.txtDVMa.Location = new System.Drawing.Point(50, 16);
            this.txtDVMa.Name = "txtDVMa";
            this.txtDVMa.Size = new System.Drawing.Size(70, 29);
            this.txtDVMa.TabIndex = 2;
            this.txtDVMa.Text = "DV01";
            // 
            // lblDVMa
            // 
            this.lblDVMa.AutoSize = true;
            this.lblDVMa.Location = new System.Drawing.Point(10, 19);
            this.lblDVMa.Name = "lblDVMa";
            this.lblDVMa.Size = new System.Drawing.Size(35, 21);
            this.lblDVMa.TabIndex = 1;
            this.lblDVMa.Text = "Mã:";
            // 
            // dgvDV
            // 
            this.dgvDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDV.BackgroundColor = System.Drawing.Color.White;
            this.dgvDV.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvDV.EnableHeadersVisualStyles = false;
            this.dgvDV.GridColor = System.Drawing.Color.LightGray;
            this.dgvDV.Location = new System.Drawing.Point(10, 60);
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.RowHeadersWidth = 51;
            this.dgvDV.RowTemplate.Height = 28;
            this.dgvDV.Size = new System.Drawing.Size(855, 360);
            this.dgvDV.TabIndex = 0;
            // 
            // tabQuyDinh
            // 
            this.tabQuyDinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabQuyDinh.Controls.Add(this.numQDTien);
            this.tabQuyDinh.Controls.Add(this.lblQDTien);
            this.tabQuyDinh.Controls.Add(this.txtQDMucDo);
            this.tabQuyDinh.Controls.Add(this.lblQDMucDo);
            this.tabQuyDinh.Controls.Add(this.cboQDLoai);
            this.tabQuyDinh.Controls.Add(this.lblQDLoai);
            this.tabQuyDinh.Controls.Add(this.btnThemQD);
            this.tabQuyDinh.Controls.Add(this.txtQDMa);
            this.tabQuyDinh.Controls.Add(this.lblQDMa);
            this.tabQuyDinh.Controls.Add(this.dgvQD);
            this.tabQuyDinh.Location = new System.Drawing.Point(4, 30);
            this.tabQuyDinh.Name = "tabQuyDinh";
            this.tabQuyDinh.Size = new System.Drawing.Size(882, 436);
            this.tabQuyDinh.TabIndex = 4;
            this.tabQuyDinh.Text = "Quy định đền bù";
            // 
            // numQDTien
            // 
            this.numQDTien.Location = new System.Drawing.Point(620, 16);
            this.numQDTien.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numQDTien.Name = "numQDTien";
            this.numQDTien.Size = new System.Drawing.Size(120, 29);
            this.numQDTien.TabIndex = 9;
            // 
            // lblQDTien
            // 
            this.lblQDTien.AutoSize = true;
            this.lblQDTien.Location = new System.Drawing.Point(555, 19);
            this.lblQDTien.Name = "lblQDTien";
            this.lblQDTien.Size = new System.Drawing.Size(61, 21);
            this.lblQDTien.TabIndex = 8;
            this.lblQDTien.Text = "Số tiền:";
            // 
            // txtQDMucDo
            // 
            this.txtQDMucDo.Location = new System.Drawing.Point(410, 16);
            this.txtQDMucDo.Name = "txtQDMucDo";
            this.txtQDMucDo.Size = new System.Drawing.Size(130, 29);
            this.txtQDMucDo.TabIndex = 7;
            // 
            // lblQDMucDo
            // 
            this.lblQDMucDo.AutoSize = true;
            this.lblQDMucDo.Location = new System.Drawing.Point(340, 19);
            this.lblQDMucDo.Name = "lblQDMucDo";
            this.lblQDMucDo.Size = new System.Drawing.Size(67, 21);
            this.lblQDMucDo.TabIndex = 6;
            this.lblQDMucDo.Text = "Mức độ:";
            // 
            // cboQDLoai
            // 
            this.cboQDLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQDLoai.FormattingEnabled = true;
            this.cboQDLoai.Location = new System.Drawing.Point(215, 16);
            this.cboQDLoai.Name = "cboQDLoai";
            this.cboQDLoai.Size = new System.Drawing.Size(110, 29);
            this.cboQDLoai.TabIndex = 5;
            // 
            // lblQDLoai
            // 
            this.lblQDLoai.AutoSize = true;
            this.lblQDLoai.Location = new System.Drawing.Point(145, 19);
            this.lblQDLoai.Name = "lblQDLoai";
            this.lblQDLoai.Size = new System.Drawing.Size(65, 21);
            this.lblQDLoai.TabIndex = 4;
            this.lblQDLoai.Text = "Loại TN:";
            // 
            // btnThemQD
            // 
            this.btnThemQD.Location = new System.Drawing.Point(755, 14);
            this.btnThemQD.Name = "btnThemQD";
            this.btnThemQD.Size = new System.Drawing.Size(100, 32);
            this.btnThemQD.TabIndex = 3;
            this.btnThemQD.Text = "Thêm";
            this.btnThemQD.UseVisualStyleBackColor = true;
            this.btnThemQD.Click += new System.EventHandler(this.btnThemQD_Click);
            // 
            // txtQDMa
            // 
            this.txtQDMa.Location = new System.Drawing.Point(75, 16);
            this.txtQDMa.Name = "txtQDMa";
            this.txtQDMa.Size = new System.Drawing.Size(60, 29);
            this.txtQDMa.TabIndex = 2;
            // 
            // lblQDMa
            // 
            this.lblQDMa.AutoSize = true;
            this.lblQDMa.Location = new System.Drawing.Point(10, 19);
            this.lblQDMa.Name = "lblQDMa";
            this.lblQDMa.Size = new System.Drawing.Size(62, 21);
            this.lblQDMa.TabIndex = 1;
            this.lblQDMa.Text = "Mã QĐ:";
            // 
            // dgvQD
            // 
            this.dgvQD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQD.BackgroundColor = System.Drawing.Color.White;
            this.dgvQD.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvQD.EnableHeadersVisualStyles = false;
            this.dgvQD.GridColor = System.Drawing.Color.LightGray;
            this.dgvQD.Location = new System.Drawing.Point(10, 60);
            this.dgvQD.Name = "dgvQD";
            this.dgvQD.RowHeadersWidth = 51;
            this.dgvQD.RowTemplate.Height = 28;
            this.dgvQD.Size = new System.Drawing.Size(855, 360);
            this.dgvQD.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDong.Location = new System.Drawing.Point(785, 490);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(914, 532);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục khách sạn";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabKhuVuc.ResumeLayout(false);
            this.tabKhuVuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).EndInit();
            this.tabNhanVien.ResumeLayout(false);
            this.tabNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            this.tabLoaiTN.ResumeLayout(false);
            this.tabLoaiTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTN)).EndInit();
            this.tabDichVu.ResumeLayout(false);
            this.tabDichVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDVGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            this.tabQuyDinh.ResumeLayout(false);
            this.tabQuyDinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQDTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQD)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKhuVuc;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.TabPage tabLoaiTN;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.TabPage tabQuyDinh;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvKhu;
        private System.Windows.Forms.Button btnThemKhu;
        private System.Windows.Forms.TextBox txtKhuTen;
        private System.Windows.Forms.Label lblKhuTen;
        private System.Windows.Forms.TextBox txtKhuMa;
        private System.Windows.Forms.Label lblKhuMa;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.TextBox txtNVSDT;
        private System.Windows.Forms.Label lblNVSDT;
        private System.Windows.Forms.TextBox txtNVVaiTro;
        private System.Windows.Forms.Label lblNVVaiTro;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.Label lblNVTen;
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.Label lblNVMa;
        private System.Windows.Forms.DataGridView dgvLoaiTN;
        private System.Windows.Forms.Button btnThemLoaiTN;
        private System.Windows.Forms.TextBox txtLoaiTen;
        private System.Windows.Forms.Label lblLoaiTen;
        private System.Windows.Forms.TextBox txtLoaiMa;
        private System.Windows.Forms.Label lblLoaiMa;
        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.Label lblDVGia;
        private System.Windows.Forms.TextBox txtDVDVT;
        private System.Windows.Forms.Label lblDVDVT;
        private System.Windows.Forms.TextBox txtDVTen;
        private System.Windows.Forms.Label lblDVTen;
        private System.Windows.Forms.TextBox txtDVMa;
        private System.Windows.Forms.Label lblDVMa;
        private System.Windows.Forms.NumericUpDown numDVGia;
        private System.Windows.Forms.DataGridView dgvQD;
        private System.Windows.Forms.Button btnThemQD;
        private System.Windows.Forms.TextBox txtQDMa;
        private System.Windows.Forms.Label lblQDMa;
        private System.Windows.Forms.Label lblQDLoai;
        private System.Windows.Forms.ComboBox cboQDLoai;
        private System.Windows.Forms.TextBox txtQDMucDo;
        private System.Windows.Forms.Label lblQDMucDo;
        private System.Windows.Forms.NumericUpDown numQDTien;
        private System.Windows.Forms.Label lblQDTien;
    }
}