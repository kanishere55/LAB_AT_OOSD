namespace QuanLyThuVien.Forms
{
    partial class FrmMuonTra
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabMuon;
        private System.Windows.Forms.TabPage tabTra;
        private System.Windows.Forms.Label lblDocGia;
        private System.Windows.Forms.Label lblNhanVienMuon;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.Label lblHenTra;
        private System.Windows.Forms.Label lblSachCon;
        private System.Windows.Forms.Label lblSachChon;
        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboNhanVienMuon;
        private System.Windows.Forms.DateTimePicker dtNgayMuon;
        private System.Windows.Forms.DateTimePicker dtHenTra;
        private System.Windows.Forms.DataGridView dgvSachCon;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Button btnBoSach;
        private System.Windows.Forms.DataGridView dgvSachChon;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Label lblDocGiaTra;
        private System.Windows.Forms.Label lblNhanVienTra;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.Label lblPhiPhat;
        private System.Windows.Forms.ComboBox cboDocGiaTra;
        private System.Windows.Forms.Button btnTaiSachMuon;
        private System.Windows.Forms.ComboBox cboNhanVienTra;
        private System.Windows.Forms.DataGridView dgvDangMuon;
        private System.Windows.Forms.DateTimePicker dtNgayTra;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.NumericUpDown numPhiPhat;
        private System.Windows.Forms.Button btnTraSach;
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
            this.tabMuon = new System.Windows.Forms.TabPage();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.dgvSachChon = new System.Windows.Forms.DataGridView();
            this.btnBoSach = new System.Windows.Forms.Button();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.dgvSachCon = new System.Windows.Forms.DataGridView();
            this.dtHenTra = new System.Windows.Forms.DateTimePicker();
            this.dtNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.cboNhanVienMuon = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.lblSachChon = new System.Windows.Forms.Label();
            this.lblSachCon = new System.Windows.Forms.Label();
            this.lblHenTra = new System.Windows.Forms.Label();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.lblNhanVienMuon = new System.Windows.Forms.Label();
            this.lblDocGia = new System.Windows.Forms.Label();
            this.tabTra = new System.Windows.Forms.TabPage();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.numPhiPhat = new System.Windows.Forms.NumericUpDown();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.dtNgayTra = new System.Windows.Forms.DateTimePicker();
            this.dgvDangMuon = new System.Windows.Forms.DataGridView();
            this.cboNhanVienTra = new System.Windows.Forms.ComboBox();
            this.btnTaiSachMuon = new System.Windows.Forms.Button();
            this.cboDocGiaTra = new System.Windows.Forms.ComboBox();
            this.lblPhiPhat = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.lblNhanVienTra = new System.Windows.Forms.Label();
            this.lblDocGiaTra = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.tabMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCon)).BeginInit();
            this.tabTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhiPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabMuon);
            this.tabs.Controls.Add(this.tabTra);
            this.tabs.Location = new System.Drawing.Point(20, 20);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1170, 720);
            this.tabs.TabIndex = 0;
            // 
            // tabMuon
            // 
            this.tabMuon.Controls.Add(this.btnLapPhieu);
            this.tabMuon.Controls.Add(this.dgvSachChon);
            this.tabMuon.Controls.Add(this.btnBoSach);
            this.tabMuon.Controls.Add(this.btnThemSach);
            this.tabMuon.Controls.Add(this.dgvSachCon);
            this.tabMuon.Controls.Add(this.dtHenTra);
            this.tabMuon.Controls.Add(this.dtNgayMuon);
            this.tabMuon.Controls.Add(this.cboNhanVienMuon);
            this.tabMuon.Controls.Add(this.lblTrangThai);
            this.tabMuon.Controls.Add(this.btnKiemTra);
            this.tabMuon.Controls.Add(this.cboDocGia);
            this.tabMuon.Controls.Add(this.lblSachChon);
            this.tabMuon.Controls.Add(this.lblSachCon);
            this.tabMuon.Controls.Add(this.lblHenTra);
            this.tabMuon.Controls.Add(this.lblNgayMuon);
            this.tabMuon.Controls.Add(this.lblNhanVienMuon);
            this.tabMuon.Controls.Add(this.lblDocGia);
            this.tabMuon.Location = new System.Drawing.Point(4, 30);
            this.tabMuon.Name = "tabMuon";
            this.tabMuon.Padding = new System.Windows.Forms.Padding(3);
            this.tabMuon.Size = new System.Drawing.Size(1162, 686);
            this.tabMuon.TabIndex = 0;
            this.tabMuon.Text = "Mượn sách";
            this.tabMuon.UseVisualStyleBackColor = true;
            // 
            // labels muon
            // 
            this.lblDocGia.AutoSize = true; this.lblDocGia.Location = new System.Drawing.Point(25, 30); this.lblDocGia.Name = "lblDocGia"; this.lblDocGia.Text = "Độc giả";
            this.lblNhanVienMuon.AutoSize = true; this.lblNhanVienMuon.Location = new System.Drawing.Point(25, 80); this.lblNhanVienMuon.Name = "lblNhanVienMuon"; this.lblNhanVienMuon.Text = "Nhân viên";
            this.lblNgayMuon.AutoSize = true; this.lblNgayMuon.Location = new System.Drawing.Point(430, 30); this.lblNgayMuon.Name = "lblNgayMuon"; this.lblNgayMuon.Text = "Ngày mượn";
            this.lblHenTra.AutoSize = true; this.lblHenTra.Location = new System.Drawing.Point(430, 80); this.lblHenTra.Name = "lblHenTra"; this.lblHenTra.Text = "Ngày hẹn trả";
            this.lblSachCon.AutoSize = true; this.lblSachCon.Location = new System.Drawing.Point(25, 145); this.lblSachCon.Name = "lblSachCon"; this.lblSachCon.Text = "Sách còn trong kho";
            this.lblSachChon.AutoSize = true; this.lblSachChon.Location = new System.Drawing.Point(650, 145); this.lblSachChon.Name = "lblSachChon"; this.lblSachChon.Text = "Danh sách chọn, tối đa 3 đầu sách";
            // 
            // cboDocGia
            // 
            this.cboDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Location = new System.Drawing.Point(120, 27);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(260, 29);
            this.cboDocGia.TabIndex = 6;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(800, 25);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(170, 38);
            this.btnKiemTra.TabIndex = 7;
            this.btnKiemTra.Text = "Kiểm tra điều kiện";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(800, 75);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(330, 60);
            this.lblTrangThai.TabIndex = 8;
            // 
            // cboNhanVienMuon
            // 
            this.cboNhanVienMuon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVienMuon.FormattingEnabled = true;
            this.cboNhanVienMuon.Location = new System.Drawing.Point(120, 77);
            this.cboNhanVienMuon.Name = "cboNhanVienMuon";
            this.cboNhanVienMuon.Size = new System.Drawing.Size(260, 29);
            this.cboNhanVienMuon.TabIndex = 9;
            // 
            // dtNgayMuon
            // 
            this.dtNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayMuon.Location = new System.Drawing.Point(545, 27);
            this.dtNgayMuon.Name = "dtNgayMuon";
            this.dtNgayMuon.Size = new System.Drawing.Size(180, 29);
            this.dtNgayMuon.TabIndex = 10;
            // 
            // dtHenTra
            // 
            this.dtHenTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHenTra.Location = new System.Drawing.Point(545, 77);
            this.dtHenTra.Name = "dtHenTra";
            this.dtHenTra.Size = new System.Drawing.Size(180, 29);
            this.dtHenTra.TabIndex = 11;
            // 
            // dgvSachCon
            // 
            this.dgvSachCon.AllowUserToAddRows = false;
            this.dgvSachCon.AllowUserToDeleteRows = false;
            this.dgvSachCon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSachCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachCon.Location = new System.Drawing.Point(25, 180);
            this.dgvSachCon.MultiSelect = false;
            this.dgvSachCon.Name = "dgvSachCon";
            this.dgvSachCon.ReadOnly = true;
            this.dgvSachCon.RowHeadersWidth = 51;
            this.dgvSachCon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachCon.Size = new System.Drawing.Size(485, 390);
            this.dgvSachCon.TabIndex = 12;
            // 
            // btnThemSach
            // 
            this.btnThemSach.Location = new System.Drawing.Point(525, 280);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(110, 42);
            this.btnThemSach.TabIndex = 13;
            this.btnThemSach.Text = "Thêm >>";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // btnBoSach
            // 
            this.btnBoSach.Location = new System.Drawing.Point(525, 340);
            this.btnBoSach.Name = "btnBoSach";
            this.btnBoSach.Size = new System.Drawing.Size(110, 42);
            this.btnBoSach.TabIndex = 14;
            this.btnBoSach.Text = "<< Bỏ";
            this.btnBoSach.UseVisualStyleBackColor = true;
            this.btnBoSach.Click += new System.EventHandler(this.btnBoSach_Click);
            // 
            // dgvSachChon
            // 
            this.dgvSachChon.AllowUserToAddRows = false;
            this.dgvSachChon.AllowUserToDeleteRows = false;
            this.dgvSachChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSachChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachChon.Location = new System.Drawing.Point(650, 180);
            this.dgvSachChon.MultiSelect = false;
            this.dgvSachChon.Name = "dgvSachChon";
            this.dgvSachChon.ReadOnly = true;
            this.dgvSachChon.RowHeadersWidth = 51;
            this.dgvSachChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachChon.Size = new System.Drawing.Size(485, 390);
            this.dgvSachChon.TabIndex = 15;
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(925, 590);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(210, 45);
            this.btnLapPhieu.TabIndex = 16;
            this.btnLapPhieu.Text = "Lập phiếu mượn";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // tabTra
            // 
            this.tabTra.Controls.Add(this.btnDong);
            this.tabTra.Controls.Add(this.btnTraSach);
            this.tabTra.Controls.Add(this.numPhiPhat);
            this.tabTra.Controls.Add(this.cboTinhTrang);
            this.tabTra.Controls.Add(this.dtNgayTra);
            this.tabTra.Controls.Add(this.dgvDangMuon);
            this.tabTra.Controls.Add(this.cboNhanVienTra);
            this.tabTra.Controls.Add(this.btnTaiSachMuon);
            this.tabTra.Controls.Add(this.cboDocGiaTra);
            this.tabTra.Controls.Add(this.lblPhiPhat);
            this.tabTra.Controls.Add(this.lblTinhTrang);
            this.tabTra.Controls.Add(this.lblNgayTra);
            this.tabTra.Controls.Add(this.lblNhanVienTra);
            this.tabTra.Controls.Add(this.lblDocGiaTra);
            this.tabTra.Location = new System.Drawing.Point(4, 30);
            this.tabTra.Name = "tabTra";
            this.tabTra.Padding = new System.Windows.Forms.Padding(3);
            this.tabTra.Size = new System.Drawing.Size(1162, 686);
            this.tabTra.TabIndex = 1;
            this.tabTra.Text = "Trả sách";
            this.tabTra.UseVisualStyleBackColor = true;
            // 
            // labels tra
            // 
            this.lblDocGiaTra.AutoSize = true; this.lblDocGiaTra.Location = new System.Drawing.Point(25, 30); this.lblDocGiaTra.Name = "lblDocGiaTra"; this.lblDocGiaTra.Text = "Độc giả trả sách";
            this.lblNhanVienTra.AutoSize = true; this.lblNhanVienTra.Location = new System.Drawing.Point(25, 80); this.lblNhanVienTra.Name = "lblNhanVienTra"; this.lblNhanVienTra.Text = "Nhân viên nhận trả";
            this.lblNgayTra.AutoSize = true; this.lblNgayTra.Location = new System.Drawing.Point(25, 525); this.lblNgayTra.Name = "lblNgayTra"; this.lblNgayTra.Text = "Ngày trả";
            this.lblTinhTrang.AutoSize = true; this.lblTinhTrang.Location = new System.Drawing.Point(380, 525); this.lblTinhTrang.Name = "lblTinhTrang"; this.lblTinhTrang.Text = "Tình trạng";
            this.lblPhiPhat.AutoSize = true; this.lblPhiPhat.Location = new System.Drawing.Point(700, 525); this.lblPhiPhat.Name = "lblPhiPhat"; this.lblPhiPhat.Text = "Phí phạt";
            // 
            // cboDocGiaTra
            // 
            this.cboDocGiaTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGiaTra.FormattingEnabled = true;
            this.cboDocGiaTra.Location = new System.Drawing.Point(180, 27);
            this.cboDocGiaTra.Name = "cboDocGiaTra";
            this.cboDocGiaTra.Size = new System.Drawing.Size(270, 29);
            this.cboDocGiaTra.TabIndex = 5;
            this.cboDocGiaTra.SelectedIndexChanged += new System.EventHandler(this.cboDocGiaTra_SelectedIndexChanged);
            // 
            // btnTaiSachMuon
            // 
            this.btnTaiSachMuon.Location = new System.Drawing.Point(475, 24);
            this.btnTaiSachMuon.Name = "btnTaiSachMuon";
            this.btnTaiSachMuon.Size = new System.Drawing.Size(190, 38);
            this.btnTaiSachMuon.TabIndex = 6;
            this.btnTaiSachMuon.Text = "Tải sách đang mượn";
            this.btnTaiSachMuon.UseVisualStyleBackColor = true;
            this.btnTaiSachMuon.Click += new System.EventHandler(this.btnTaiSachMuon_Click);
            // 
            // cboNhanVienTra
            // 
            this.cboNhanVienTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVienTra.FormattingEnabled = true;
            this.cboNhanVienTra.Location = new System.Drawing.Point(180, 77);
            this.cboNhanVienTra.Name = "cboNhanVienTra";
            this.cboNhanVienTra.Size = new System.Drawing.Size(270, 29);
            this.cboNhanVienTra.TabIndex = 7;
            // 
            // dgvDangMuon
            // 
            this.dgvDangMuon.AllowUserToAddRows = false;
            this.dgvDangMuon.AllowUserToDeleteRows = false;
            this.dgvDangMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDangMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangMuon.Location = new System.Drawing.Point(25, 135);
            this.dgvDangMuon.MultiSelect = false;
            this.dgvDangMuon.Name = "dgvDangMuon";
            this.dgvDangMuon.ReadOnly = true;
            this.dgvDangMuon.RowHeadersWidth = 51;
            this.dgvDangMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangMuon.Size = new System.Drawing.Size(1110, 350);
            this.dgvDangMuon.TabIndex = 8;
            // 
            // dtNgayTra
            // 
            this.dtNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayTra.Location = new System.Drawing.Point(110, 522);
            this.dtNgayTra.Name = "dtNgayTra";
            this.dtNgayTra.Size = new System.Drawing.Size(180, 29);
            this.dtNgayTra.TabIndex = 9;
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Location = new System.Drawing.Point(480, 522);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(190, 29);
            this.cboTinhTrang.TabIndex = 10;
            // 
            // numPhiPhat
            // 
            this.numPhiPhat.Location = new System.Drawing.Point(780, 522);
            this.numPhiPhat.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numPhiPhat.Name = "numPhiPhat";
            this.numPhiPhat.Size = new System.Drawing.Size(190, 29);
            this.numPhiPhat.TabIndex = 11;
            // 
            // btnTraSach
            // 
            this.btnTraSach.Location = new System.Drawing.Point(820, 580);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(190, 44);
            this.btnTraSach.TabIndex = 12;
            this.btnTraSach.Text = "Xác nhận trả sách";
            this.btnTraSach.UseVisualStyleBackColor = true;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(1025, 580);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 44);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 765);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mượn - Trả sách";
            this.Load += new System.EventHandler(this.FrmMuonTra_Load);
            this.tabs.ResumeLayout(false);
            this.tabMuon.ResumeLayout(false);
            this.tabMuon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCon)).EndInit();
            this.tabTra.ResumeLayout(false);
            this.tabTra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhiPhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangMuon)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
