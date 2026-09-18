namespace QuanLyThuVien.Forms
{
    partial class FrmDocGia
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblHo;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblPhai;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAnh;
        private System.Windows.Forms.Label lblNgayCap;
        private System.Windows.Forms.Label lblHan;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.ComboBox cboPhai;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAnh;
        private System.Windows.Forms.DateTimePicker dtNgayCap;
        private System.Windows.Forms.DateTimePicker dtHan;
        private System.Windows.Forms.CheckBox chkLePhi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnCapThe;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvDocGia;
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
            this.lblMa = new System.Windows.Forms.Label();
            this.lblHo = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblPhai = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAnh = new System.Windows.Forms.Label();
            this.lblNgayCap = new System.Windows.Forms.Label();
            this.lblHan = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboPhai = new System.Windows.Forms.ComboBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.dtNgayCap = new System.Windows.Forms.DateTimePicker();
            this.dtHan = new System.Windows.Forms.DateTimePicker();
            this.chkLePhi = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnCapThe = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(30, 30);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(86, 21);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã độc giả";
            // 
            // lblHo
            // 
            this.lblHo.AutoSize = true;
            this.lblHo.Location = new System.Drawing.Point(30, 70);
            this.lblHo.Name = "lblHo";
            this.lblHo.Size = new System.Drawing.Size(28, 21);
            this.lblHo.TabIndex = 1;
            this.lblHo.Text = "Họ";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(30, 110);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(34, 21);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 150);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(78, 21);
            this.lblNgaySinh.TabIndex = 3;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblPhai
            // 
            this.lblPhai.AutoSize = true;
            this.lblPhai.Location = new System.Drawing.Point(30, 190);
            this.lblPhai.Name = "lblPhai";
            this.lblPhai.Size = new System.Drawing.Size(38, 21);
            this.lblPhai.TabIndex = 4;
            this.lblPhai.Text = "Phái";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(395, 30);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(99, 21);
            this.lblSDT.TabIndex = 5;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(395, 70);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(55, 21);
            this.lblDiaChi.TabIndex = 6;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(395, 110);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 21);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            // 
            // lblAnh
            // 
            this.lblAnh.AutoSize = true;
            this.lblAnh.Location = new System.Drawing.Point(395, 150);
            this.lblAnh.Name = "lblAnh";
            this.lblAnh.Size = new System.Drawing.Size(62, 21);
            this.lblAnh.TabIndex = 8;
            this.lblAnh.Text = "Ảnh 3x4";
            // 
            // lblNgayCap
            // 
            this.lblNgayCap.AutoSize = true;
            this.lblNgayCap.Location = new System.Drawing.Point(785, 30);
            this.lblNgayCap.Name = "lblNgayCap";
            this.lblNgayCap.Size = new System.Drawing.Size(74, 21);
            this.lblNgayCap.TabIndex = 9;
            this.lblNgayCap.Text = "Ngày cấp";
            // 
            // lblHan
            // 
            this.lblHan.AutoSize = true;
            this.lblHan.Location = new System.Drawing.Point(785, 70);
            this.lblHan.Name = "lblHan";
            this.lblHan.Size = new System.Drawing.Size(94, 21);
            this.lblHan.TabIndex = 10;
            this.lblHan.Text = "Hạn sử dụng";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(135, 27);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(220, 29);
            this.txtMa.TabIndex = 11;
            // 
            // txtHo
            // 
            this.txtHo.Location = new System.Drawing.Point(135, 67);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(220, 29);
            this.txtHo.TabIndex = 12;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(135, 107);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(220, 29);
            this.txtTen.TabIndex = 13;
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgaySinh.Location = new System.Drawing.Point(135, 147);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(170, 29);
            this.dtNgaySinh.TabIndex = 14;
            // 
            // cboPhai
            // 
            this.cboPhai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhai.FormattingEnabled = true;
            this.cboPhai.Location = new System.Drawing.Point(135, 187);
            this.cboPhai.Name = "cboPhai";
            this.cboPhai.Size = new System.Drawing.Size(170, 29);
            this.cboPhai.TabIndex = 15;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(510, 27);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(235, 29);
            this.txtSDT.TabIndex = 16;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(510, 67);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(235, 29);
            this.txtDiaChi.TabIndex = 17;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(510, 107);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(235, 29);
            this.txtEmail.TabIndex = 18;
            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(510, 147);
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.Size = new System.Drawing.Size(235, 29);
            this.txtAnh.TabIndex = 19;
            // 
            // dtNgayCap
            // 
            this.dtNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayCap.Location = new System.Drawing.Point(900, 27);
            this.dtNgayCap.Name = "dtNgayCap";
            this.dtNgayCap.Size = new System.Drawing.Size(180, 29);
            this.dtNgayCap.TabIndex = 20;
            // 
            // dtHan
            // 
            this.dtHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHan.Location = new System.Drawing.Point(900, 67);
            this.dtHan.Name = "dtHan";
            this.dtHan.Size = new System.Drawing.Size(180, 29);
            this.dtHan.TabIndex = 21;
            // 
            // chkLePhi
            // 
            this.chkLePhi.AutoSize = true;
            this.chkLePhi.Location = new System.Drawing.Point(900, 110);
            this.chkLePhi.Name = "chkLePhi";
            this.chkLePhi.Size = new System.Drawing.Size(177, 25);
            this.chkLePhi.TabIndex = 22;
            this.chkLePhi.Text = "Đã đóng lệ phí năm";
            this.chkLePhi.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(785, 160);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 40);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "Thêm độc giả";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(940, 160);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(135, 40);
            this.btnCapNhat.TabIndex = 24;
            this.btnCapNhat.Text = "Cập nhật độc giả";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnCapThe
            // 
            this.btnCapThe.Location = new System.Drawing.Point(785, 210);
            this.btnCapThe.Name = "btnCapThe";
            this.btnCapThe.Size = new System.Drawing.Size(135, 40);
            this.btnCapThe.TabIndex = 25;
            this.btnCapThe.Text = "Cấp thẻ";
            this.btnCapThe.UseVisualStyleBackColor = true;
            this.btnCapThe.Click += new System.EventHandler(this.btnCapThe_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(940, 210);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(135, 40);
            this.btnGiaHan.TabIndex = 26;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(30, 260);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 40);
            this.btnLamMoi.TabIndex = 27;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.AllowUserToAddRows = false;
            this.dgvDocGia.AllowUserToDeleteRows = false;
            this.dgvDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Location = new System.Drawing.Point(30, 320);
            this.dgvDocGia.MultiSelect = false;
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.ReadOnly = true;
            this.dgvDocGia.RowHeadersWidth = 51;
            this.dgvDocGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocGia.Size = new System.Drawing.Size(1130, 390);
            this.dgvDocGia.TabIndex = 28;
            this.dgvDocGia.SelectionChanged += new System.EventHandler(this.dgvDocGia_SelectionChanged);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(1030, 730);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(130, 42);
            this.btnDong.TabIndex = 29;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 790);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvDocGia);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.btnCapThe);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.chkLePhi);
            this.Controls.Add(this.dtHan);
            this.Controls.Add(this.dtNgayCap);
            this.Controls.Add(this.txtAnh);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.cboPhai);
            this.Controls.Add(this.dtNgaySinh);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtHo);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lblHan);
            this.Controls.Add(this.lblNgayCap);
            this.Controls.Add(this.lblAnh);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblPhai);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblHo);
            this.Controls.Add(this.lblMa);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmDocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Độc giả và thẻ";
            this.Load += new System.EventHandler(this.FrmDocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
