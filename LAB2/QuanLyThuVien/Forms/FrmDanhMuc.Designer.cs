namespace QuanLyThuVien.Forms
{
    partial class FrmDanhMuc
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabNV;
        private System.Windows.Forms.TabPage tabTL;
        private System.Windows.Forms.TabPage tabNXB;
        private System.Windows.Forms.Label lblNVMa;
        private System.Windows.Forms.Label lblNVHo;
        private System.Windows.Forms.Label lblNVTen;
        private System.Windows.Forms.Label lblNVPhai;
        private System.Windows.Forms.Label lblNVNgaySinh;
        private System.Windows.Forms.Label lblNVChucVu;
        private System.Windows.Forms.Label lblNVSDT;
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.TextBox txtNVHo;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.ComboBox cboNVPhai;
        private System.Windows.Forms.DateTimePicker dtNVNgaySinh;
        private System.Windows.Forms.TextBox txtNVChucVu;
        private System.Windows.Forms.TextBox txtNVSDT;
        private System.Windows.Forms.Button btnNVThem;
        private System.Windows.Forms.Button btnNVCapNhat;
        private System.Windows.Forms.Button btnNVXoa;
        private System.Windows.Forms.Button btnNVMoi;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.Label lblTLMa;
        private System.Windows.Forms.Label lblTLTen;
        private System.Windows.Forms.TextBox txtTLMa;
        private System.Windows.Forms.TextBox txtTLTen;
        private System.Windows.Forms.Button btnTLThem;
        private System.Windows.Forms.Button btnTLCapNhat;
        private System.Windows.Forms.Button btnTLXoa;
        private System.Windows.Forms.Button btnTLMoi;
        private System.Windows.Forms.DataGridView dgvTL;
        private System.Windows.Forms.Label lblNXBMa;
        private System.Windows.Forms.Label lblNXBDiaChi;
        private System.Windows.Forms.Label lblNXBSDT;
        private System.Windows.Forms.TextBox txtNXBMa;
        private System.Windows.Forms.TextBox txtNXBDiaChi;
        private System.Windows.Forms.TextBox txtNXBSDT;
        private System.Windows.Forms.Button btnNXBThem;
        private System.Windows.Forms.Button btnNXBCapNhat;
        private System.Windows.Forms.Button btnNXBXoa;
        private System.Windows.Forms.Button btnNXBMoi;
        private System.Windows.Forms.DataGridView dgvNXB;
        private System.Windows.Forms.Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabNV = new System.Windows.Forms.TabPage();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.btnNVMoi = new System.Windows.Forms.Button();
            this.btnNVXoa = new System.Windows.Forms.Button();
            this.btnNVCapNhat = new System.Windows.Forms.Button();
            this.btnNVThem = new System.Windows.Forms.Button();
            this.txtNVSDT = new System.Windows.Forms.TextBox();
            this.txtNVChucVu = new System.Windows.Forms.TextBox();
            this.dtNVNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboNVPhai = new System.Windows.Forms.ComboBox();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.txtNVHo = new System.Windows.Forms.TextBox();
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.lblNVSDT = new System.Windows.Forms.Label();
            this.lblNVChucVu = new System.Windows.Forms.Label();
            this.lblNVNgaySinh = new System.Windows.Forms.Label();
            this.lblNVPhai = new System.Windows.Forms.Label();
            this.lblNVTen = new System.Windows.Forms.Label();
            this.lblNVHo = new System.Windows.Forms.Label();
            this.lblNVMa = new System.Windows.Forms.Label();
            this.tabTL = new System.Windows.Forms.TabPage();
            this.dgvTL = new System.Windows.Forms.DataGridView();
            this.btnTLMoi = new System.Windows.Forms.Button();
            this.btnTLXoa = new System.Windows.Forms.Button();
            this.btnTLCapNhat = new System.Windows.Forms.Button();
            this.btnTLThem = new System.Windows.Forms.Button();
            this.txtTLTen = new System.Windows.Forms.TextBox();
            this.txtTLMa = new System.Windows.Forms.TextBox();
            this.lblTLTen = new System.Windows.Forms.Label();
            this.lblTLMa = new System.Windows.Forms.Label();
            this.tabNXB = new System.Windows.Forms.TabPage();
            this.dgvNXB = new System.Windows.Forms.DataGridView();
            this.btnNXBMoi = new System.Windows.Forms.Button();
            this.btnNXBXoa = new System.Windows.Forms.Button();
            this.btnNXBCapNhat = new System.Windows.Forms.Button();
            this.btnNXBThem = new System.Windows.Forms.Button();
            this.txtNXBSDT = new System.Windows.Forms.TextBox();
            this.txtNXBDiaChi = new System.Windows.Forms.TextBox();
            this.txtNXBMa = new System.Windows.Forms.TextBox();
            this.lblNXBSDT = new System.Windows.Forms.Label();
            this.lblNXBDiaChi = new System.Windows.Forms.Label();
            this.lblNXBMa = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.tabTL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTL)).BeginInit();
            this.tabNXB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabNV);
            this.tabs.Controls.Add(this.tabTL);
            this.tabs.Controls.Add(this.tabNXB);
            this.tabs.Location = new System.Drawing.Point(20, 20);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1020, 625);
            this.tabs.TabIndex = 0;
            // 
            // tabNV
            // 
            this.tabNV.Controls.Add(this.dgvNV);
            this.tabNV.Controls.Add(this.btnNVMoi);
            this.tabNV.Controls.Add(this.btnNVXoa);
            this.tabNV.Controls.Add(this.btnNVCapNhat);
            this.tabNV.Controls.Add(this.btnNVThem);
            this.tabNV.Controls.Add(this.txtNVSDT);
            this.tabNV.Controls.Add(this.txtNVChucVu);
            this.tabNV.Controls.Add(this.dtNVNgaySinh);
            this.tabNV.Controls.Add(this.cboNVPhai);
            this.tabNV.Controls.Add(this.txtNVTen);
            this.tabNV.Controls.Add(this.txtNVHo);
            this.tabNV.Controls.Add(this.txtNVMa);
            this.tabNV.Controls.Add(this.lblNVSDT);
            this.tabNV.Controls.Add(this.lblNVChucVu);
            this.tabNV.Controls.Add(this.lblNVNgaySinh);
            this.tabNV.Controls.Add(this.lblNVPhai);
            this.tabNV.Controls.Add(this.lblNVTen);
            this.tabNV.Controls.Add(this.lblNVHo);
            this.tabNV.Controls.Add(this.lblNVMa);
            this.tabNV.Location = new System.Drawing.Point(4, 30);
            this.tabNV.Name = "tabNV";
            this.tabNV.Padding = new System.Windows.Forms.Padding(3);
            this.tabNV.Size = new System.Drawing.Size(1012, 591);
            this.tabNV.TabIndex = 0;
            this.tabNV.Text = "Nhân viên";
            this.tabNV.UseVisualStyleBackColor = true;
            // 
            // dgvNV
            // 
            this.dgvNV.AllowUserToAddRows = false;
            this.dgvNV.AllowUserToDeleteRows = false;
            this.dgvNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.Location = new System.Drawing.Point(25, 190);
            this.dgvNV.MultiSelect = false;
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.ReadOnly = true;
            this.dgvNV.RowHeadersWidth = 51;
            this.dgvNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNV.Size = new System.Drawing.Size(960, 370);
            this.dgvNV.TabIndex = 18;
            this.dgvNV.SelectionChanged += new System.EventHandler(this.dgvNV_SelectionChanged);
            // 
            // btnNVMoi
            // 
            this.btnNVMoi.Location = new System.Drawing.Point(855, 130);
            this.btnNVMoi.Name = "btnNVMoi";
            this.btnNVMoi.Size = new System.Drawing.Size(120, 38);
            this.btnNVMoi.TabIndex = 17;
            this.btnNVMoi.Text = "Làm mới";
            this.btnNVMoi.UseVisualStyleBackColor = true;
            this.btnNVMoi.Click += new System.EventHandler(this.btnNVMoi_Click);
            // 
            // btnNVXoa
            // 
            this.btnNVXoa.Location = new System.Drawing.Point(715, 130);
            this.btnNVXoa.Name = "btnNVXoa";
            this.btnNVXoa.Size = new System.Drawing.Size(120, 38);
            this.btnNVXoa.TabIndex = 16;
            this.btnNVXoa.Text = "Xóa";
            this.btnNVXoa.UseVisualStyleBackColor = true;
            this.btnNVXoa.Click += new System.EventHandler(this.btnNVXoa_Click);
            // 
            // btnNVCapNhat
            // 
            this.btnNVCapNhat.Location = new System.Drawing.Point(855, 80);
            this.btnNVCapNhat.Name = "btnNVCapNhat";
            this.btnNVCapNhat.Size = new System.Drawing.Size(120, 38);
            this.btnNVCapNhat.TabIndex = 15;
            this.btnNVCapNhat.Text = "Cập nhật";
            this.btnNVCapNhat.UseVisualStyleBackColor = true;
            this.btnNVCapNhat.Click += new System.EventHandler(this.btnNVCapNhat_Click);
            // 
            // btnNVThem
            // 
            this.btnNVThem.Location = new System.Drawing.Point(715, 80);
            this.btnNVThem.Name = "btnNVThem";
            this.btnNVThem.Size = new System.Drawing.Size(120, 38);
            this.btnNVThem.TabIndex = 14;
            this.btnNVThem.Text = "Thêm";
            this.btnNVThem.UseVisualStyleBackColor = true;
            this.btnNVThem.Click += new System.EventHandler(this.btnNVThem_Click);
            // 
            // txtNVSDT
            // 
            this.txtNVSDT.Location = new System.Drawing.Point(800, 30);
            this.txtNVSDT.Name = "txtNVSDT";
            this.txtNVSDT.Size = new System.Drawing.Size(175, 29);
            this.txtNVSDT.TabIndex = 13;
            // 
            // txtNVChucVu
            // 
            this.txtNVChucVu.Location = new System.Drawing.Point(495, 125);
            this.txtNVChucVu.Name = "txtNVChucVu";
            this.txtNVChucVu.Size = new System.Drawing.Size(195, 29);
            this.txtNVChucVu.TabIndex = 12;
            // 
            // dtNVNgaySinh
            // 
            this.dtNVNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNVNgaySinh.Location = new System.Drawing.Point(495, 80);
            this.dtNVNgaySinh.Name = "dtNVNgaySinh";
            this.dtNVNgaySinh.Size = new System.Drawing.Size(170, 29);
            this.dtNVNgaySinh.TabIndex = 11;
            // 
            // cboNVPhai
            // 
            this.cboNVPhai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNVPhai.FormattingEnabled = true;
            this.cboNVPhai.Location = new System.Drawing.Point(495, 35);
            this.cboNVPhai.Name = "cboNVPhai";
            this.cboNVPhai.Size = new System.Drawing.Size(170, 29);
            this.cboNVPhai.TabIndex = 10;
            // 
            // txtNVTen
            // 
            this.txtNVTen.Location = new System.Drawing.Point(145, 125);
            this.txtNVTen.Name = "txtNVTen";
            this.txtNVTen.Size = new System.Drawing.Size(210, 29);
            this.txtNVTen.TabIndex = 9;
            // 
            // txtNVHo
            // 
            this.txtNVHo.Location = new System.Drawing.Point(145, 80);
            this.txtNVHo.Name = "txtNVHo";
            this.txtNVHo.Size = new System.Drawing.Size(210, 29);
            this.txtNVHo.TabIndex = 8;
            // 
            // txtNVMa
            // 
            this.txtNVMa.Location = new System.Drawing.Point(145, 35);
            this.txtNVMa.Name = "txtNVMa";
            this.txtNVMa.Size = new System.Drawing.Size(210, 29);
            this.txtNVMa.TabIndex = 7;
            // 
            // labels NV
            // 
            this.lblNVMa.AutoSize = true; this.lblNVMa.Location = new System.Drawing.Point(25, 38); this.lblNVMa.Name = "lblNVMa"; this.lblNVMa.Text = "Mã nhân viên";
            this.lblNVHo.AutoSize = true; this.lblNVHo.Location = new System.Drawing.Point(25, 83); this.lblNVHo.Name = "lblNVHo"; this.lblNVHo.Text = "Họ";
            this.lblNVTen.AutoSize = true; this.lblNVTen.Location = new System.Drawing.Point(25, 128); this.lblNVTen.Name = "lblNVTen"; this.lblNVTen.Text = "Tên";
            this.lblNVPhai.AutoSize = true; this.lblNVPhai.Location = new System.Drawing.Point(400, 38); this.lblNVPhai.Name = "lblNVPhai"; this.lblNVPhai.Text = "Phái";
            this.lblNVNgaySinh.AutoSize = true; this.lblNVNgaySinh.Location = new System.Drawing.Point(400, 83); this.lblNVNgaySinh.Name = "lblNVNgaySinh"; this.lblNVNgaySinh.Text = "Ngày sinh";
            this.lblNVChucVu.AutoSize = true; this.lblNVChucVu.Location = new System.Drawing.Point(400, 128); this.lblNVChucVu.Name = "lblNVChucVu"; this.lblNVChucVu.Text = "Chức vụ";
            this.lblNVSDT.AutoSize = true; this.lblNVSDT.Location = new System.Drawing.Point(705, 38); this.lblNVSDT.Name = "lblNVSDT"; this.lblNVSDT.Text = "Điện thoại";
            // 
            // tabTL
            // 
            this.tabTL.Controls.Add(this.dgvTL);
            this.tabTL.Controls.Add(this.btnTLMoi);
            this.tabTL.Controls.Add(this.btnTLXoa);
            this.tabTL.Controls.Add(this.btnTLCapNhat);
            this.tabTL.Controls.Add(this.btnTLThem);
            this.tabTL.Controls.Add(this.txtTLTen);
            this.tabTL.Controls.Add(this.txtTLMa);
            this.tabTL.Controls.Add(this.lblTLTen);
            this.tabTL.Controls.Add(this.lblTLMa);
            this.tabTL.Location = new System.Drawing.Point(4, 30);
            this.tabTL.Name = "tabTL";
            this.tabTL.Padding = new System.Windows.Forms.Padding(3);
            this.tabTL.Size = new System.Drawing.Size(1012, 591);
            this.tabTL.TabIndex = 1;
            this.tabTL.Text = "Thể loại";
            this.tabTL.UseVisualStyleBackColor = true;
            // 
            // dgvTL
            // 
            this.dgvTL.AllowUserToAddRows = false;
            this.dgvTL.AllowUserToDeleteRows = false;
            this.dgvTL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTL.Location = new System.Drawing.Point(35, 165);
            this.dgvTL.MultiSelect = false;
            this.dgvTL.Name = "dgvTL";
            this.dgvTL.ReadOnly = true;
            this.dgvTL.RowHeadersWidth = 51;
            this.dgvTL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTL.Size = new System.Drawing.Size(940, 395);
            this.dgvTL.TabIndex = 8;
            this.dgvTL.SelectionChanged += new System.EventHandler(this.dgvTL_SelectionChanged);
            // 
            // buttons TL
            // 
            this.btnTLThem.Location = new System.Drawing.Point(560, 35); this.btnTLThem.Name = "btnTLThem"; this.btnTLThem.Size = new System.Drawing.Size(110, 38); this.btnTLThem.Text = "Thêm"; this.btnTLThem.UseVisualStyleBackColor = true; this.btnTLThem.Click += new System.EventHandler(this.btnTLThem_Click);
            this.btnTLCapNhat.Location = new System.Drawing.Point(690, 35); this.btnTLCapNhat.Name = "btnTLCapNhat"; this.btnTLCapNhat.Size = new System.Drawing.Size(110, 38); this.btnTLCapNhat.Text = "Cập nhật"; this.btnTLCapNhat.UseVisualStyleBackColor = true; this.btnTLCapNhat.Click += new System.EventHandler(this.btnTLCapNhat_Click);
            this.btnTLXoa.Location = new System.Drawing.Point(560, 85); this.btnTLXoa.Name = "btnTLXoa"; this.btnTLXoa.Size = new System.Drawing.Size(110, 38); this.btnTLXoa.Text = "Xóa"; this.btnTLXoa.UseVisualStyleBackColor = true; this.btnTLXoa.Click += new System.EventHandler(this.btnTLXoa_Click);
            this.btnTLMoi.Location = new System.Drawing.Point(690, 85); this.btnTLMoi.Name = "btnTLMoi"; this.btnTLMoi.Size = new System.Drawing.Size(110, 38); this.btnTLMoi.Text = "Làm mới"; this.btnTLMoi.UseVisualStyleBackColor = true; this.btnTLMoi.Click += new System.EventHandler(this.btnTLMoi_Click);
            this.txtTLMa.Location = new System.Drawing.Point(160, 35); this.txtTLMa.Name = "txtTLMa"; this.txtTLMa.Size = new System.Drawing.Size(240, 29);
            this.txtTLTen.Location = new System.Drawing.Point(160, 85); this.txtTLTen.Name = "txtTLTen"; this.txtTLTen.Size = new System.Drawing.Size(340, 29);
            this.lblTLMa.AutoSize = true; this.lblTLMa.Location = new System.Drawing.Point(35, 38); this.lblTLMa.Name = "lblTLMa"; this.lblTLMa.Text = "Mã thể loại";
            this.lblTLTen.AutoSize = true; this.lblTLTen.Location = new System.Drawing.Point(35, 88); this.lblTLTen.Name = "lblTLTen"; this.lblTLTen.Text = "Tên thể loại";
            // 
            // tabNXB
            // 
            this.tabNXB.Controls.Add(this.dgvNXB);
            this.tabNXB.Controls.Add(this.btnNXBMoi);
            this.tabNXB.Controls.Add(this.btnNXBXoa);
            this.tabNXB.Controls.Add(this.btnNXBCapNhat);
            this.tabNXB.Controls.Add(this.btnNXBThem);
            this.tabNXB.Controls.Add(this.txtNXBSDT);
            this.tabNXB.Controls.Add(this.txtNXBDiaChi);
            this.tabNXB.Controls.Add(this.txtNXBMa);
            this.tabNXB.Controls.Add(this.lblNXBSDT);
            this.tabNXB.Controls.Add(this.lblNXBDiaChi);
            this.tabNXB.Controls.Add(this.lblNXBMa);
            this.tabNXB.Location = new System.Drawing.Point(4, 30);
            this.tabNXB.Name = "tabNXB";
            this.tabNXB.Padding = new System.Windows.Forms.Padding(3);
            this.tabNXB.Size = new System.Drawing.Size(1012, 591);
            this.tabNXB.TabIndex = 2;
            this.tabNXB.Text = "Nhà xuất bản";
            this.tabNXB.UseVisualStyleBackColor = true;
            // 
            // dgvNXB
            // 
            this.dgvNXB.AllowUserToAddRows = false;
            this.dgvNXB.AllowUserToDeleteRows = false;
            this.dgvNXB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNXB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNXB.Location = new System.Drawing.Point(35, 205);
            this.dgvNXB.MultiSelect = false;
            this.dgvNXB.Name = "dgvNXB";
            this.dgvNXB.ReadOnly = true;
            this.dgvNXB.RowHeadersWidth = 51;
            this.dgvNXB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNXB.Size = new System.Drawing.Size(940, 355);
            this.dgvNXB.TabIndex = 10;
            this.dgvNXB.SelectionChanged += new System.EventHandler(this.dgvNXB_SelectionChanged);
            // 
            // controls NXB
            // 
            this.lblNXBMa.AutoSize = true; this.lblNXBMa.Location = new System.Drawing.Point(35, 38); this.lblNXBMa.Name = "lblNXBMa"; this.lblNXBMa.Text = "Mã nhà xuất bản";
            this.lblNXBDiaChi.AutoSize = true; this.lblNXBDiaChi.Location = new System.Drawing.Point(35, 88); this.lblNXBDiaChi.Name = "lblNXBDiaChi"; this.lblNXBDiaChi.Text = "Địa chỉ";
            this.lblNXBSDT.AutoSize = true; this.lblNXBSDT.Location = new System.Drawing.Point(35, 138); this.lblNXBSDT.Name = "lblNXBSDT"; this.lblNXBSDT.Text = "Điện thoại";
            this.txtNXBMa.Location = new System.Drawing.Point(180, 35); this.txtNXBMa.Name = "txtNXBMa"; this.txtNXBMa.Size = new System.Drawing.Size(240, 29);
            this.txtNXBDiaChi.Location = new System.Drawing.Point(180, 85); this.txtNXBDiaChi.Name = "txtNXBDiaChi"; this.txtNXBDiaChi.Size = new System.Drawing.Size(360, 29);
            this.txtNXBSDT.Location = new System.Drawing.Point(180, 135); this.txtNXBSDT.Name = "txtNXBSDT"; this.txtNXBSDT.Size = new System.Drawing.Size(240, 29);
            this.btnNXBThem.Location = new System.Drawing.Point(610, 35); this.btnNXBThem.Name = "btnNXBThem"; this.btnNXBThem.Size = new System.Drawing.Size(110, 38); this.btnNXBThem.Text = "Thêm"; this.btnNXBThem.UseVisualStyleBackColor = true; this.btnNXBThem.Click += new System.EventHandler(this.btnNXBThem_Click);
            this.btnNXBCapNhat.Location = new System.Drawing.Point(740, 35); this.btnNXBCapNhat.Name = "btnNXBCapNhat"; this.btnNXBCapNhat.Size = new System.Drawing.Size(110, 38); this.btnNXBCapNhat.Text = "Cập nhật"; this.btnNXBCapNhat.UseVisualStyleBackColor = true; this.btnNXBCapNhat.Click += new System.EventHandler(this.btnNXBCapNhat_Click);
            this.btnNXBXoa.Location = new System.Drawing.Point(610, 85); this.btnNXBXoa.Name = "btnNXBXoa"; this.btnNXBXoa.Size = new System.Drawing.Size(110, 38); this.btnNXBXoa.Text = "Xóa"; this.btnNXBXoa.UseVisualStyleBackColor = true; this.btnNXBXoa.Click += new System.EventHandler(this.btnNXBXoa_Click);
            this.btnNXBMoi.Location = new System.Drawing.Point(740, 85); this.btnNXBMoi.Name = "btnNXBMoi"; this.btnNXBMoi.Size = new System.Drawing.Size(110, 38); this.btnNXBMoi.Text = "Làm mới"; this.btnNXBMoi.UseVisualStyleBackColor = true; this.btnNXBMoi.Click += new System.EventHandler(this.btnNXBMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(900, 660);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(140, 42);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 720);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục và nhân viên";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabs.ResumeLayout(false);
            this.tabNV.ResumeLayout(false);
            this.tabNV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            this.tabTL.ResumeLayout(false);
            this.tabTL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTL)).EndInit();
            this.tabNXB.ResumeLayout(false);
            this.tabNXB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
