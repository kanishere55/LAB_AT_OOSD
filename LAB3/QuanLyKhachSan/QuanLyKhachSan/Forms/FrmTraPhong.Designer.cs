namespace QuanLyKhachSan.Forms
{
    partial class FrmTraPhong
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

            this.lblDat = new System.Windows.Forms.Label();
            this.cboDat = new System.Windows.Forms.ComboBox();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.dgvTN = new System.Windows.Forms.DataGridView();
            this.dgvDBChon = new System.Windows.Forms.DataGridView();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.txtSoDB = new System.Windows.Forms.TextBox();
            this.lblSoDB = new System.Windows.Forms.Label();
            this.txtMucDo = new System.Windows.Forms.TextBox();
            this.lblMucDo = new System.Windows.Forms.Label();
            this.numDenBu = new System.Windows.Forms.NumericUpDown();
            this.lblDenBu = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.btnThemDB = new System.Windows.Forms.Button();
            this.btnLapDB = new System.Windows.Forms.Button();
            this.txtSoHD = new System.Windows.Forms.TextBox();
            this.lblSoHD = new System.Windows.Forms.Label();
            this.numSoNgay = new System.Windows.Forms.NumericUpDown();
            this.lblSoNgay = new System.Windows.Forms.Label();
            this.cboNV2 = new System.Windows.Forms.ComboBox();
            this.lblNV2 = new System.Windows.Forms.Label();
            this.btnLapHD = new System.Windows.Forms.Button();
            this.dgvHD = new System.Windows.Forms.DataGridView();
            this.txtHDChon = new System.Windows.Forms.TextBox();
            this.lblHDChon = new System.Windows.Forms.Label();
            this.txtMaTT = new System.Windows.Forms.TextBox();
            this.lblMaTT = new System.Windows.Forms.Label();
            this.cboHT = new System.Windows.Forms.ComboBox();
            this.lblHT = new System.Windows.Forms.Label();
            this.numTienTT = new System.Windows.Forms.NumericUpDown();
            this.lblTienTT = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnTraPhong = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDenBu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienTT)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDat
            // 
            this.lblDat.AutoSize = true;
            this.lblDat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDat.Location = new System.Drawing.Point(20, 16);
            this.lblDat.Name = "lblDat";
            this.lblDat.Size = new System.Drawing.Size(107, 21);
            this.lblDat.TabIndex = 0;
            this.lblDat.Text = "Phiếu đang ở:";
            // 
            // cboDat
            // 
            this.cboDat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboDat.FormattingEnabled = true;
            this.cboDat.Location = new System.Drawing.Point(135, 13);
            this.cboDat.Name = "cboDat";
            this.cboDat.Size = new System.Drawing.Size(150, 29);
            this.cboDat.TabIndex = 1;
            // 
            // dgvPhong
            // 
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvPhong.EnableHeadersVisualStyles = false;
            this.dgvPhong.GridColor = System.Drawing.Color.LightGray;
            this.dgvPhong.Location = new System.Drawing.Point(20, 50);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.RowTemplate.Height = 26;
            this.dgvPhong.Size = new System.Drawing.Size(270, 140);
            this.dgvPhong.TabIndex = 2;
            this.dgvPhong.SelectionChanged += new System.EventHandler(this.dgvPhong_SelectionChanged);
            // 
            // dgvTN
            // 
            this.dgvTN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTN.BackgroundColor = System.Drawing.Color.White;
            this.dgvTN.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvTN.EnableHeadersVisualStyles = false;
            this.dgvTN.GridColor = System.Drawing.Color.LightGray;
            this.dgvTN.Location = new System.Drawing.Point(310, 50);
            this.dgvTN.Name = "dgvTN";
            this.dgvTN.RowHeadersVisible = false;
            this.dgvTN.RowTemplate.Height = 26;
            this.dgvTN.Size = new System.Drawing.Size(320, 140);
            this.dgvTN.TabIndex = 3;
            // 
            // dgvDBChon
            // 
            this.dgvDBChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDBChon.BackgroundColor = System.Drawing.Color.White;
            this.dgvDBChon.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvDBChon.EnableHeadersVisualStyles = false;
            this.dgvDBChon.GridColor = System.Drawing.Color.LightGray;
            this.dgvDBChon.Location = new System.Drawing.Point(650, 50);
            this.dgvDBChon.Name = "dgvDBChon";
            this.dgvDBChon.RowHeadersVisible = false;
            this.dgvDBChon.RowTemplate.Height = 26;
            this.dgvDBChon.Size = new System.Drawing.Size(330, 140);
            this.dgvDBChon.TabIndex = 4;
            // 
            // lblSoDB
            // 
            this.lblSoDB.AutoSize = true;
            this.lblSoDB.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoDB.Location = new System.Drawing.Point(20, 203);
            this.lblSoDB.Name = "lblSoDB";
            this.lblSoDB.Size = new System.Drawing.Size(126, 21);
            this.lblSoDB.TabIndex = 8;
            this.lblSoDB.Text = "Số phiếu đền bù:";
            // 
            // txtSoDB
            // 
            this.txtSoDB.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoDB.Location = new System.Drawing.Point(145, 200);
            this.txtSoDB.Name = "txtSoDB";
            this.txtSoDB.Size = new System.Drawing.Size(130, 29);
            this.txtSoDB.TabIndex = 7;
            this.txtSoDB.Text = "DB001";
            // 
            // lblMucDo
            // 
            this.lblMucDo.AutoSize = true;
            this.lblMucDo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMucDo.Location = new System.Drawing.Point(300, 203);
            this.lblMucDo.Name = "lblMucDo";
            this.lblMucDo.Size = new System.Drawing.Size(67, 21);
            this.lblMucDo.TabIndex = 10;
            this.lblMucDo.Text = "Mức độ:";
            // 
            // txtMucDo
            // 
            this.txtMucDo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMucDo.Location = new System.Drawing.Point(380, 200);
            this.txtMucDo.Name = "txtMucDo";
            this.txtMucDo.Size = new System.Drawing.Size(150, 29);
            this.txtMucDo.TabIndex = 9;
            this.txtMucDo.Text = "Hư hỏng nhẹ";
            // 
            // lblDenBu
            // 
            this.lblDenBu.AutoSize = true;
            this.lblDenBu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDenBu.Location = new System.Drawing.Point(555, 203);
            this.lblDenBu.Name = "lblDenBu";
            this.lblDenBu.Size = new System.Drawing.Size(61, 21);
            this.lblDenBu.TabIndex = 12;
            this.lblDenBu.Text = "Số tiền:";
            // 
            // numDenBu
            // 
            this.numDenBu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numDenBu.Location = new System.Drawing.Point(625, 200);
            this.numDenBu.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numDenBu.Name = "numDenBu";
            this.numDenBu.Size = new System.Drawing.Size(130, 29);
            this.numDenBu.TabIndex = 11;
            this.numDenBu.Value = new decimal(new int[] { 500000, 0, 0, 0 });
            // 
            // btnLapDB
            // 
            this.btnLapDB.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLapDB.Location = new System.Drawing.Point(795, 197);
            this.btnLapDB.Name = "btnLapDB";
            this.btnLapDB.Size = new System.Drawing.Size(165, 33);
            this.btnLapDB.TabIndex = 16;
            this.btnLapDB.Text = "Lập phiếu đền bù";
            this.btnLapDB.UseVisualStyleBackColor = true;
            this.btnLapDB.Click += new System.EventHandler(this.btnLapDB_Click);
            // 
            // lblSoHD
            // 
            this.lblSoHD.AutoSize = true;
            this.lblSoHD.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoHD.Location = new System.Drawing.Point(20, 245);
            this.lblSoHD.Name = "lblSoHD";
            this.lblSoHD.Size = new System.Drawing.Size(94, 21);
            this.lblSoHD.TabIndex = 18;
            this.lblSoHD.Text = "Số hóa đơn:";
            // 
            // txtSoHD
            // 
            this.txtSoHD.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoHD.Location = new System.Drawing.Point(135, 242);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.Size = new System.Drawing.Size(135, 29);
            this.txtSoHD.TabIndex = 17;
            this.txtSoHD.Text = "HD001";
            // 
            // lblSoNgay
            // 
            this.lblSoNgay.AutoSize = true;
            this.lblSoNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoNgay.Location = new System.Drawing.Point(285, 245);
            this.lblSoNgay.Name = "lblSoNgay";
            this.lblSoNgay.Size = new System.Drawing.Size(130, 21);
            this.lblSoNgay.TabIndex = 20;
            this.lblSoNgay.Text = "Số ngày tính tiền:";
            // 
            // numSoNgay
            // 
            this.numSoNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numSoNgay.Location = new System.Drawing.Point(420, 242);
            this.numSoNgay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNgay.Name = "numSoNgay";
            this.numSoNgay.Size = new System.Drawing.Size(95, 29);
            this.numSoNgay.TabIndex = 19;
            this.numSoNgay.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // btnLapHD
            // 
            this.btnLapHD.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLapHD.Location = new System.Drawing.Point(545, 239);
            this.btnLapHD.Name = "btnLapHD";
            this.btnLapHD.Size = new System.Drawing.Size(135, 33);
            this.btnLapHD.TabIndex = 23;
            this.btnLapHD.Text = "Lập hóa đơn";
            this.btnLapHD.UseVisualStyleBackColor = true;
            this.btnLapHD.Click += new System.EventHandler(this.btnLapHD_Click);
            // 
            // dgvHD
            // 
            this.dgvHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHD.BackgroundColor = System.Drawing.Color.White;
            this.dgvHD.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvHD.EnableHeadersVisualStyles = false;
            this.dgvHD.GridColor = System.Drawing.Color.LightGray;
            this.dgvHD.Location = new System.Drawing.Point(20, 280);
            this.dgvHD.Name = "dgvHD";
            this.dgvHD.RowHeadersVisible = false;
            this.dgvHD.RowTemplate.Height = 26;
            this.dgvHD.Size = new System.Drawing.Size(960, 145);
            this.dgvHD.TabIndex = 24;
            this.dgvHD.SelectionChanged += new System.EventHandler(this.dgvHD_SelectionChanged);
            // 
            // lblHT
            // 
            this.lblHT.AutoSize = true;
            this.lblHT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHT.Location = new System.Drawing.Point(20, 442);
            this.lblHT.Name = "lblHT";
            this.lblHT.Size = new System.Drawing.Size(81, 21);
            this.lblHT.TabIndex = 30;
            this.lblHT.Text = "Hình thức:";
            // 
            // cboHT
            // 
            this.cboHT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboHT.FormattingEnabled = true;
            this.cboHT.Location = new System.Drawing.Point(110, 439);
            this.cboHT.Name = "cboHT";
            this.cboHT.Size = new System.Drawing.Size(140, 29);
            this.cboHT.TabIndex = 29;
            // 
            // lblTienTT
            // 
            this.lblTienTT.AutoSize = true;
            this.lblTienTT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienTT.Location = new System.Drawing.Point(275, 442);
            this.lblTienTT.Name = "lblTienTT";
            this.lblTienTT.Size = new System.Drawing.Size(61, 21);
            this.lblTienTT.TabIndex = 32;
            this.lblTienTT.Text = "Số tiền:";
            // 
            // numTienTT
            // 
            this.numTienTT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numTienTT.Location = new System.Drawing.Point(345, 439);
            this.numTienTT.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numTienTT.Name = "numTienTT";
            this.numTienTT.Size = new System.Drawing.Size(125, 29);
            this.numTienTT.TabIndex = 31;
            this.numTienTT.Value = new decimal(new int[] { 1200000, 0, 0, 0 });
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnThanhToan.Location = new System.Drawing.Point(495, 436);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(135, 33);
            this.btnThanhToan.TabIndex = 33;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnTraPhong
            // 
            this.btnTraPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTraPhong.Location = new System.Drawing.Point(650, 436);
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.Size = new System.Drawing.Size(175, 33);
            this.btnTraPhong.TabIndex = 34;
            this.btnTraPhong.Text = "Hoàn tất trả phòng";
            this.btnTraPhong.UseVisualStyleBackColor = true;
            this.btnTraPhong.Click += new System.EventHandler(this.btnTraPhong_Click);
            // 
            // btnThemDB
            // 
            this.btnThemDB.Location = new System.Drawing.Point(0, 0);
            this.btnThemDB.Name = "btnThemDB";
            this.btnThemDB.Size = new System.Drawing.Size(0, 0);
            this.btnThemDB.TabIndex = 36;
            this.btnThemDB.Visible = false;
            this.btnThemDB.Click += new System.EventHandler(this.btnThemDB_Click);
            // 
            // cboNV
            // 
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(0, 0);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(0, 24);
            this.cboNV.TabIndex = 37;
            this.cboNV.Visible = false;
            // 
            // lblNV
            // 
            this.lblNV.Location = new System.Drawing.Point(0, 0);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(0, 0);
            this.lblNV.TabIndex = 38;
            // 
            // cboNV2
            // 
            this.cboNV2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV2.FormattingEnabled = true;
            this.cboNV2.Location = new System.Drawing.Point(0, 0);
            this.cboNV2.Name = "cboNV2";
            this.cboNV2.Size = new System.Drawing.Size(0, 24);
            this.cboNV2.TabIndex = 39;
            this.cboNV2.Visible = false;
            // 
            // lblNV2
            // 
            this.lblNV2.Location = new System.Drawing.Point(0, 0);
            this.lblNV2.Name = "lblNV2";
            this.lblNV2.Size = new System.Drawing.Size(0, 0);
            this.lblNV2.TabIndex = 40;
            // 
            // txtHDChon
            // 
            this.txtHDChon.Location = new System.Drawing.Point(0, 0);
            this.txtHDChon.Name = "txtHDChon";
            this.txtHDChon.Size = new System.Drawing.Size(0, 22);
            this.txtHDChon.TabIndex = 41;
            this.txtHDChon.Visible = false;
            // 
            // lblHDChon
            // 
            this.lblHDChon.Location = new System.Drawing.Point(0, 0);
            this.lblHDChon.Name = "lblHDChon";
            this.lblHDChon.Size = new System.Drawing.Size(0, 0);
            this.lblHDChon.TabIndex = 42;
            // 
            // txtMaTT
            // 
            this.txtMaTT.Location = new System.Drawing.Point(0, 0);
            this.txtMaTT.Name = "txtMaTT";
            this.txtMaTT.Size = new System.Drawing.Size(0, 22);
            this.txtMaTT.TabIndex = 43;
            this.txtMaTT.Visible = false;
            // 
            // lblMaTT
            // 
            this.lblMaTT.Location = new System.Drawing.Point(0, 0);
            this.lblMaTT.Name = "lblMaTT";
            this.lblMaTT.Size = new System.Drawing.Size(0, 0);
            this.lblMaTT.TabIndex = 44;
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(0, 0);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(0, 22);
            this.txtPhong.TabIndex = 45;
            this.txtPhong.Visible = false;
            // 
            // lblPhong
            // 
            this.lblPhong.Location = new System.Drawing.Point(0, 0);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(0, 0);
            this.lblPhong.TabIndex = 46;
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDong.Location = new System.Drawing.Point(870, 436);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 33);
            this.btnDong.TabIndex = 35;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmTraPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1004, 485);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTraPhong);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.numTienTT);
            this.Controls.Add(this.lblTienTT);
            this.Controls.Add(this.cboHT);
            this.Controls.Add(this.lblHT);
            this.Controls.Add(this.dgvHD);
            this.Controls.Add(this.btnLapHD);
            this.Controls.Add(this.numSoNgay);
            this.Controls.Add(this.lblSoNgay);
            this.Controls.Add(this.txtSoHD);
            this.Controls.Add(this.lblSoHD);
            this.Controls.Add(this.btnLapDB);
            this.Controls.Add(this.numDenBu);
            this.Controls.Add(this.lblDenBu);
            this.Controls.Add(this.txtMucDo);
            this.Controls.Add(this.lblMucDo);
            this.Controls.Add(this.txtSoDB);
            this.Controls.Add(this.lblSoDB);
            this.Controls.Add(this.dgvDBChon);
            this.Controls.Add(this.dgvTN);
            this.Controls.Add(this.dgvPhong);
            this.Controls.Add(this.cboDat);
            this.Controls.Add(this.lblDat);
            this.Controls.Add(this.btnThemDB);
            this.Controls.Add(this.cboNV);
            this.Controls.Add(this.lblNV);
            this.Controls.Add(this.cboNV2);
            this.Controls.Add(this.lblNV2);
            this.Controls.Add(this.txtHDChon);
            this.Controls.Add(this.lblHDChon);
            this.Controls.Add(this.txtMaTT);
            this.Controls.Add(this.lblMaTT);
            this.Controls.Add(this.txtPhong);
            this.Controls.Add(this.lblPhong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTraPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trả phòng - Đền bù - Hóa đơn - Thanh toán";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDenBu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienTT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDat;
        private System.Windows.Forms.ComboBox cboDat;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.DataGridView dgvTN;
        private System.Windows.Forms.DataGridView dgvDBChon;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.TextBox txtSoDB;
        private System.Windows.Forms.Label lblSoDB;
        private System.Windows.Forms.TextBox txtMucDo;
        private System.Windows.Forms.Label lblMucDo;
        private System.Windows.Forms.NumericUpDown numDenBu;
        private System.Windows.Forms.Label lblDenBu;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.Button btnThemDB;
        private System.Windows.Forms.Button btnLapDB;
        private System.Windows.Forms.TextBox txtSoHD;
        private System.Windows.Forms.Label lblSoHD;
        private System.Windows.Forms.NumericUpDown numSoNgay;
        private System.Windows.Forms.Label lblSoNgay;
        private System.Windows.Forms.ComboBox cboNV2;
        private System.Windows.Forms.Label lblNV2;
        private System.Windows.Forms.Button btnLapHD;
        private System.Windows.Forms.DataGridView dgvHD;
        private System.Windows.Forms.TextBox txtHDChon;
        private System.Windows.Forms.Label lblHDChon;
        private System.Windows.Forms.TextBox txtMaTT;
        private System.Windows.Forms.Label lblMaTT;
        private System.Windows.Forms.ComboBox cboHT;
        private System.Windows.Forms.Label lblHT;
        private System.Windows.Forms.NumericUpDown numTienTT;
        private System.Windows.Forms.Label lblTienTT;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnTraPhong;
        private System.Windows.Forms.Button btnDong;
    }
}