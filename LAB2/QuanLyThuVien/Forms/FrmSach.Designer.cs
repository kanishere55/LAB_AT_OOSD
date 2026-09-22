namespace QuanLyThuVien.Forms
{
    partial class FrmSach
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.Label lblNXB;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.ComboBox cboNXB;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvSach;
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
            this.lblTen = new System.Windows.Forms.Label();
            this.lblNam = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.lblNXB = new System.Windows.Forms.Label();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.cboNXB = new System.Windows.Forms.ComboBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(35, 35);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(88, 21);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã đầu sách";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(35, 80);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(67, 21);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Tên sách";
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(35, 125);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(105, 21);
            this.lblNam.TabIndex = 2;
            this.lblNam.Text = "Năm xuất bản";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(35, 170);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(124, 21);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng hiện có";
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Location = new System.Drawing.Point(570, 35);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(62, 21);
            this.lblTheLoai.TabIndex = 4;
            this.lblTheLoai.Text = "Thể loại";
            // 
            // lblNXB
            // 
            this.lblNXB.AutoSize = true;
            this.lblNXB.Location = new System.Drawing.Point(570, 80);
            this.lblNXB.Name = "lblNXB";
            this.lblNXB.Size = new System.Drawing.Size(100, 21);
            this.lblNXB.TabIndex = 5;
            this.lblNXB.Text = "Nhà xuất bản";
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Location = new System.Drawing.Point(35, 225);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(73, 21);
            this.lblTim.TabIndex = 6;
            this.lblTim.Text = "Tìm kiếm";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(170, 32);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(300, 29);
            this.txtMa.TabIndex = 7;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(170, 77);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(360, 29);
            this.txtTen.TabIndex = 8;
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(170, 122);
            this.numNam.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            this.numNam.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(150, 29);
            this.numNam.TabIndex = 9;
            this.numNam.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(170, 167);
            this.numSoLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(150, 29);
            this.numSoLuong.TabIndex = 10;
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(690, 32);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(270, 29);
            this.cboTheLoai.TabIndex = 11;
            // 
            // cboNXB
            // 
            this.cboNXB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNXB.FormattingEnabled = true;
            this.cboNXB.Location = new System.Drawing.Point(690, 77);
            this.cboNXB.Name = "cboNXB";
            this.cboNXB.Size = new System.Drawing.Size(270, 29);
            this.cboNXB.TabIndex = 12;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(170, 222);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(440, 29);
            this.txtTim.TabIndex = 13;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(625, 217);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(110, 38);
            this.btnTim.TabIndex = 14;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(570, 125);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 40);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(705, 125);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(120, 40);
            this.btnCapNhat.TabIndex = 16;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(840, 125);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 40);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(975, 125);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 40);
            this.btnLamMoi.TabIndex = 18;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Location = new System.Drawing.Point(35, 285);
            this.dgvSach.MultiSelect = false;
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSach.Size = new System.Drawing.Size(1050, 380);
            this.dgvSach.TabIndex = 19;
            this.dgvSach.SelectionChanged += new System.EventHandler(this.dgvSach_SelectionChanged);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(955, 680);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(130, 42);
            this.btnDong.TabIndex = 20;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 740);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvSach);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.cboNXB);
            this.Controls.Add(this.cboTheLoai);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.numNam);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lblTim);
            this.Controls.Add(this.lblNXB);
            this.Controls.Add(this.lblTheLoai);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblMa);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý đầu sách";
            this.Load += new System.EventHandler(this.FrmSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
