namespace QuanLyKhachSan.Forms
{
    partial class FrmPhongTienNghi
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
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.lblGia = new System.Windows.Forms.Label();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.lblMax = new System.Windows.Forms.Label();
            this.cboKhu = new System.Windows.Forms.ComboBox();
            this.lblKhu = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.tabTienNghi = new System.Windows.Forms.TabPage();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.numSTT = new System.Windows.Forms.NumericUpDown();
            this.lblSTT = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.txtMaTN = new System.Windows.Forms.TextBox();
            this.lblMaTN = new System.Windows.Forms.Label();
            this.btnThemTN = new System.Windows.Forms.Button();
            this.dgvTN = new System.Windows.Forms.DataGridView();
            this.tabLapDat = new System.Windows.Forms.TabPage();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.txtTTLD = new System.Windows.Forms.TextBox();
            this.lblTTLD = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.lblNgay = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblPhongLD = new System.Windows.Forms.Label();
            this.cboTN = new System.Windows.Forms.ComboBox();
            this.lblTNLD = new System.Windows.Forms.Label();
            this.txtSoLD = new System.Windows.Forms.TextBox();
            this.lblSoLD = new System.Windows.Forms.Label();
            this.btnLapDat = new System.Windows.Forms.Button();
            this.dgvLD = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.tabTienNghi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).BeginInit();
            this.tabLapDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPhong);
            this.tabControl1.Controls.Add(this.tabTienNghi);
            this.tabControl1.Controls.Add(this.tabLapDat);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(915, 480);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPhong
            // 
            this.tabPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabPhong.Controls.Add(this.numGia);
            this.tabPhong.Controls.Add(this.lblGia);
            this.tabPhong.Controls.Add(this.numMax);
            this.tabPhong.Controls.Add(this.lblMax);
            this.tabPhong.Controls.Add(this.cboKhu);
            this.tabPhong.Controls.Add(this.lblKhu);
            this.tabPhong.Controls.Add(this.txtPhong);
            this.tabPhong.Controls.Add(this.lblPhong);
            this.tabPhong.Controls.Add(this.btnThemPhong);
            this.tabPhong.Controls.Add(this.dgvPhong);
            this.tabPhong.Location = new System.Drawing.Point(4, 30);
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.Size = new System.Drawing.Size(907, 446);
            this.tabPhong.TabIndex = 0;
            this.tabPhong.Text = "Phòng";
            // 
            // numGia
            // 
            this.numGia.Location = new System.Drawing.Point(670, 16);
            this.numGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(100, 29);
            this.numGia.TabIndex = 9;
            this.numGia.Value = new decimal(new int[] { 600000, 0, 0, 0 });
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(565, 19);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(106, 21);
            this.lblGia.TabIndex = 8;
            this.lblGia.Text = "Đơn giá/ngày:";
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(485, 16);
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(65, 29);
            this.numMax.TabIndex = 7;
            this.numMax.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(365, 19);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(117, 21);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "Số người tối đa:";
            // 
            // cboKhu
            // 
            this.cboKhu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhu.FormattingEnabled = true;
            this.cboKhu.Location = new System.Drawing.Point(235, 16);
            this.cboKhu.Name = "cboKhu";
            this.cboKhu.Size = new System.Drawing.Size(115, 29);
            this.cboKhu.TabIndex = 5;
            // 
            // lblKhu
            // 
            this.lblKhu.AutoSize = true;
            this.lblKhu.Location = new System.Drawing.Point(165, 19);
            this.lblKhu.Name = "lblKhu";
            this.lblKhu.Size = new System.Drawing.Size(69, 21);
            this.lblKhu.TabIndex = 4;
            this.lblKhu.Text = "Khu vực:";
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(85, 16);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(70, 29);
            this.txtPhong.TabIndex = 3;
            this.txtPhong.Text = "A101";
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(5, 19);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(80, 21);
            this.lblPhong.TabIndex = 2;
            this.lblPhong.Text = "Số phòng:";
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(790, 14);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(105, 32);
            this.btnThemPhong.TabIndex = 1;
            this.btnThemPhong.Text = "Thêm";
            this.btnThemPhong.UseVisualStyleBackColor = true;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // dgvPhong
            // 
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvPhong.EnableHeadersVisualStyles = false;
            this.dgvPhong.GridColor = System.Drawing.Color.LightGray;
            this.dgvPhong.Location = new System.Drawing.Point(10, 60);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.RowHeadersWidth = 51;
            this.dgvPhong.RowTemplate.Height = 28;
            this.dgvPhong.Size = new System.Drawing.Size(885, 370);
            this.dgvPhong.TabIndex = 0;
            // 
            // tabTienNghi
            // 
            this.tabTienNghi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabTienNghi.Controls.Add(this.txtTinhTrang);
            this.tabTienNghi.Controls.Add(this.lblTinhTrang);
            this.tabTienNghi.Controls.Add(this.numSTT);
            this.tabTienNghi.Controls.Add(this.lblSTT);
            this.tabTienNghi.Controls.Add(this.cboLoai);
            this.tabTienNghi.Controls.Add(this.lblLoai);
            this.tabTienNghi.Controls.Add(this.txtMaTN);
            this.tabTienNghi.Controls.Add(this.lblMaTN);
            this.tabTienNghi.Controls.Add(this.btnThemTN);
            this.tabTienNghi.Controls.Add(this.dgvTN);
            this.tabTienNghi.Location = new System.Drawing.Point(4, 30);
            this.tabTienNghi.Name = "tabTienNghi";
            this.tabTienNghi.Size = new System.Drawing.Size(907, 446);
            this.tabTienNghi.TabIndex = 1;
            this.tabTienNghi.Text = "Tiện nghi";
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(595, 16);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(140, 29);
            this.txtTinhTrang.TabIndex = 9;
            this.txtTinhTrang.Text = "Tốt";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new System.Drawing.Point(510, 19);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(84, 21);
            this.lblTinhTrang.TabIndex = 8;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // numSTT
            // 
            this.numSTT.Location = new System.Drawing.Point(420, 16);
            this.numSTT.Name = "numSTT";
            this.numSTT.Size = new System.Drawing.Size(70, 29);
            this.numSTT.TabIndex = 7;
            this.numSTT.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSTT
            // 
            this.lblSTT.AutoSize = true;
            this.lblSTT.Location = new System.Drawing.Point(375, 19);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(40, 21);
            this.lblSTT.TabIndex = 6;
            this.lblSTT.Text = "STT:";
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(225, 16);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(130, 29);
            this.cboLoai.TabIndex = 5;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(155, 19);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(65, 21);
            this.lblLoai.TabIndex = 4;
            this.lblLoai.Text = "Loại TN:";
            // 
            // txtMaTN
            // 
            this.txtMaTN.Location = new System.Drawing.Point(75, 16);
            this.txtMaTN.Name = "txtMaTN";
            this.txtMaTN.Size = new System.Drawing.Size(70, 29);
            this.txtMaTN.TabIndex = 3;
            // 
            // lblMaTN
            // 
            this.lblMaTN.AutoSize = true;
            this.lblMaTN.Location = new System.Drawing.Point(10, 19);
            this.lblMaTN.Name = "lblMaTN";
            this.lblMaTN.Size = new System.Drawing.Size(61, 21);
            this.lblMaTN.TabIndex = 2;
            this.lblMaTN.Text = "Mã TN:";
            // 
            // btnThemTN
            // 
            this.btnThemTN.Location = new System.Drawing.Point(760, 14);
            this.btnThemTN.Name = "btnThemTN";
            this.btnThemTN.Size = new System.Drawing.Size(110, 32);
            this.btnThemTN.TabIndex = 1;
            this.btnThemTN.Text = "Thêm";
            this.btnThemTN.UseVisualStyleBackColor = true;
            this.btnThemTN.Click += new System.EventHandler(this.btnThemTN_Click);
            // 
            // dgvTN
            // 
            this.dgvTN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTN.BackgroundColor = System.Drawing.Color.White;
            this.dgvTN.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvTN.EnableHeadersVisualStyles = false;
            this.dgvTN.GridColor = System.Drawing.Color.LightGray;
            this.dgvTN.Location = new System.Drawing.Point(10, 60);
            this.dgvTN.Name = "dgvTN";
            this.dgvTN.RowHeadersWidth = 51;
            this.dgvTN.RowTemplate.Height = 28;
            this.dgvTN.Size = new System.Drawing.Size(885, 370);
            this.dgvTN.TabIndex = 0;
            // 
            // tabLapDat
            // 
            this.tabLapDat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabLapDat.Controls.Add(this.txtGhiChu);
            this.tabLapDat.Controls.Add(this.lblGhiChu);
            this.tabLapDat.Controls.Add(this.cboNV);
            this.tabLapDat.Controls.Add(this.lblNV);
            this.tabLapDat.Controls.Add(this.txtTTLD);
            this.tabLapDat.Controls.Add(this.lblTTLD);
            this.tabLapDat.Controls.Add(this.dtNgay);
            this.tabLapDat.Controls.Add(this.lblNgay);
            this.tabLapDat.Controls.Add(this.cboPhong);
            this.tabLapDat.Controls.Add(this.lblPhongLD);
            this.tabLapDat.Controls.Add(this.cboTN);
            this.tabLapDat.Controls.Add(this.lblTNLD);
            this.tabLapDat.Controls.Add(this.txtSoLD);
            this.tabLapDat.Controls.Add(this.lblSoLD);
            this.tabLapDat.Controls.Add(this.btnLapDat);
            this.tabLapDat.Controls.Add(this.dgvLD);
            this.tabLapDat.Location = new System.Drawing.Point(4, 30);
            this.tabLapDat.Name = "tabLapDat";
            this.tabLapDat.Size = new System.Drawing.Size(907, 446);
            this.tabLapDat.TabIndex = 2;
            this.tabLapDat.Text = "Lắp đặt / luân chuyển";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(375, 48);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(350, 29);
            this.txtGhiChu.TabIndex = 15;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(305, 51);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(66, 21);
            this.lblGhiChu.TabIndex = 14;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // cboNV
            // 
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(100, 48);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(180, 29);
            this.cboNV.TabIndex = 13;
            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Location = new System.Drawing.Point(10, 51);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(61, 21);
            this.lblNV.TabIndex = 12;
            this.lblNV.Text = "Mã NV:";
            // 
            // txtTTLD
            // 
            this.txtTTLD.Location = new System.Drawing.Point(625, 12);
            this.txtTTLD.Name = "txtTTLD";
            this.txtTTLD.Size = new System.Drawing.Size(100, 29);
            this.txtTTLD.TabIndex = 11;
            this.txtTTLD.Text = "Tốt";
            // 
            // lblTTLD
            // 
            this.lblTTLD.AutoSize = true;
            this.lblTTLD.Location = new System.Drawing.Point(540, 15);
            this.lblTTLD.Name = "lblTTLD";
            this.lblTTLD.Size = new System.Drawing.Size(84, 21);
            this.lblTTLD.TabIndex = 10;
            this.lblTTLD.Text = "Tình trạng:";
            // 
            // dtNgay
            // 
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgay.Location = new System.Drawing.Point(745, 48);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(145, 29);
            this.dtNgay.TabIndex = 9;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(745, 15);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(76, 21);
            this.lblNgay.TabIndex = 8;
            this.lblNgay.Text = "Ngày lắp:";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(440, 12);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(90, 29);
            this.cboPhong.TabIndex = 7;
            // 
            // lblPhongLD
            // 
            this.lblPhongLD.AutoSize = true;
            this.lblPhongLD.Location = new System.Drawing.Point(375, 15);
            this.lblPhongLD.Name = "lblPhongLD";
            this.lblPhongLD.Size = new System.Drawing.Size(59, 21);
            this.lblPhongLD.TabIndex = 6;
            this.lblPhongLD.Text = "Phòng:";
            // 
            // cboTN
            // 
            this.cboTN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTN.FormattingEnabled = true;
            this.cboTN.Location = new System.Drawing.Point(265, 12);
            this.cboTN.Name = "cboTN";
            this.cboTN.Size = new System.Drawing.Size(95, 29);
            this.cboTN.TabIndex = 5;
            // 
            // lblTNLD
            // 
            this.lblTNLD.AutoSize = true;
            this.lblTNLD.Location = new System.Drawing.Point(185, 15);
            this.lblTNLD.Name = "lblTNLD";
            this.lblTNLD.Size = new System.Drawing.Size(77, 21);
            this.lblTNLD.TabIndex = 4;
            this.lblTNLD.Text = "Tiện nghi:";
            // 
            // txtSoLD
            // 
            this.txtSoLD.Location = new System.Drawing.Point(100, 12);
            this.txtSoLD.Name = "txtSoLD";
            this.txtSoLD.Size = new System.Drawing.Size(75, 29);
            this.txtSoLD.TabIndex = 3;
            this.txtSoLD.Text = "LD001";
            // 
            // lblSoLD
            // 
            this.lblSoLD.AutoSize = true;
            this.lblSoLD.Location = new System.Drawing.Point(10, 15);
            this.lblSoLD.Name = "lblSoLD";
            this.lblSoLD.Size = new System.Drawing.Size(89, 21);
            this.lblSoLD.TabIndex = 2;
            this.lblSoLD.Text = "Phiếu LĐ:";
            // 
            // btnLapDat
            // 
            this.btnLapDat.Location = new System.Drawing.Point(745, 85);
            this.btnLapDat.Name = "btnLapDat";
            this.btnLapDat.Size = new System.Drawing.Size(145, 34);
            this.btnLapDat.TabIndex = 1;
            this.btnLapDat.Text = "Lập phiếu";
            this.btnLapDat.UseVisualStyleBackColor = true;
            this.btnLapDat.Click += new System.EventHandler(this.btnLapDat_Click);
            // 
            // dgvLD
            // 
            this.dgvLD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLD.BackgroundColor = System.Drawing.Color.White;
            this.dgvLD.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvLD.EnableHeadersVisualStyles = false;
            this.dgvLD.GridColor = System.Drawing.Color.LightGray;
            this.dgvLD.Location = new System.Drawing.Point(10, 125);
            this.dgvLD.Name = "dgvLD";
            this.dgvLD.RowHeadersWidth = 51;
            this.dgvLD.RowTemplate.Height = 28;
            this.dgvLD.Size = new System.Drawing.Size(885, 305);
            this.dgvLD.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDong.Location = new System.Drawing.Point(815, 498);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmPhongTienNghi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(939, 540);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPhongTienNghi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phòng - Tiện nghi - Phiếu lắp đặt";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPhong.ResumeLayout(false);
            this.tabPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.tabTienNghi.ResumeLayout(false);
            this.tabTienNghi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).EndInit();
            this.tabLapDat.ResumeLayout(false);
            this.tabLapDat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLD)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.TabPage tabTienNghi;
        private System.Windows.Forms.TabPage tabLapDat;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboKhu;
        private System.Windows.Forms.Label lblKhu;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.DataGridView dgvTN;
        private System.Windows.Forms.Button btnThemTN;
        private System.Windows.Forms.TextBox txtMaTN;
        private System.Windows.Forms.Label lblMaTN;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.NumericUpDown numSTT;
        private System.Windows.Forms.Label lblSTT;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.DataGridView dgvLD;
        private System.Windows.Forms.Button btnLapDat;
        private System.Windows.Forms.TextBox txtSoLD;
        private System.Windows.Forms.Label lblSoLD;
        private System.Windows.Forms.ComboBox cboTN;
        private System.Windows.Forms.Label lblTNLD;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblPhongLD;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.TextBox txtTTLD;
        private System.Windows.Forms.Label lblTTLD;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
    }
}