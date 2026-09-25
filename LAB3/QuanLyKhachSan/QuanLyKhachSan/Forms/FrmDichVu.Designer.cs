namespace QuanLyKhachSan.Forms
{
    partial class FrmDichVu
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

            this.lblLuot = new System.Windows.Forms.Label();
            this.cboLuot = new System.Windows.Forms.ComboBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblDV = new System.Windows.Forms.Label();
            this.cboDV = new System.Windows.Forms.ComboBox();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.lblSL = new System.Windows.Forms.Label();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.lblNV = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLuot
            // 
            this.lblLuot.AutoSize = true;
            this.lblLuot.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLuot.Location = new System.Drawing.Point(25, 25);
            this.lblLuot.Name = "lblLuot";
            this.lblLuot.Size = new System.Drawing.Size(107, 21);
            this.lblLuot.TabIndex = 0;
            this.lblLuot.Text = "Phiếu lưu trú:";
            // 
            // cboLuot
            // 
            this.cboLuot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLuot.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLuot.FormattingEnabled = true;
            this.cboLuot.Location = new System.Drawing.Point(140, 22);
            this.cboLuot.Name = "cboLuot";
            this.cboLuot.Size = new System.Drawing.Size(175, 29);
            this.cboLuot.TabIndex = 1;
            this.cboLuot.SelectedIndexChanged += new System.EventHandler(this.cboLuot_SelectedIndexChanged);
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhong.Location = new System.Drawing.Point(340, 25);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(59, 21);
            this.lblPhong.TabIndex = 2;
            this.lblPhong.Text = "Phòng:";
            // 
            // txtPhong
            // 
            this.txtPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhong.Location = new System.Drawing.Point(415, 22);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.ReadOnly = true;
            this.txtPhong.Size = new System.Drawing.Size(125, 29);
            this.txtPhong.TabIndex = 3;
            this.txtPhong.Text = "A101";
            // 
            // lblDV
            // 
            this.lblDV.AutoSize = true;
            this.lblDV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDV.Location = new System.Drawing.Point(565, 25);
            this.lblDV.Name = "lblDV";
            this.lblDV.Size = new System.Drawing.Size(66, 21);
            this.lblDV.TabIndex = 4;
            this.lblDV.Text = "Dịch vụ:";
            // 
            // cboDV
            // 
            this.cboDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDV.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboDV.FormattingEnabled = true;
            this.cboDV.Location = new System.Drawing.Point(645, 22);
            this.cboDV.Name = "cboDV";
            this.cboDV.Size = new System.Drawing.Size(220, 29);
            this.cboDV.TabIndex = 5;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNgay.Location = new System.Drawing.Point(25, 68);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(111, 21);
            this.lblNgay.TabIndex = 6;
            this.lblNgay.Text = "Ngày sử dụng:";
            // 
            // dtNgay
            // 
            this.dtNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgay.Location = new System.Drawing.Point(140, 65);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(175, 29);
            this.dtNgay.TabIndex = 7;
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSL.Location = new System.Drawing.Point(340, 68);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(76, 21);
            this.lblSL.TabIndex = 8;
            this.lblSL.Text = "Số lượng:";
            // 
            // numSL
            // 
            this.numSL.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numSL.Location = new System.Drawing.Point(415, 65);
            this.numSL.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(125, 29);
            this.numSL.TabIndex = 9;
            this.numSL.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblNV
            // 
            this.lblNV.Location = new System.Drawing.Point(0, 0);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(0, 0);
            this.lblNV.TabIndex = 15;
            // 
            // cboNV
            // 
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(0, 0);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(0, 24);
            this.cboNV.TabIndex = 16;
            this.cboNV.Visible = false;
            // 
            // btnGhi
            // 
            this.btnGhi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnGhi.Location = new System.Drawing.Point(645, 62);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(175, 34);
            this.btnGhi.TabIndex = 12;
            this.btnGhi.Text = "Ghi nhận";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDong.Location = new System.Drawing.Point(795, 495);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvLichSu.EnableHeadersVisualStyles = false;
            this.dgvLichSu.GridColor = System.Drawing.Color.LightGray;
            this.dgvLichSu.Location = new System.Drawing.Point(25, 115);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.RowHeadersWidth = 51;
            this.dgvLichSu.RowTemplate.Height = 28;
            this.dgvLichSu.Size = new System.Drawing.Size(880, 365);
            this.dgvLichSu.TabIndex = 14;
            // 
            // FrmDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 540);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.cboNV);
            this.Controls.Add(this.lblNV);
            this.Controls.Add(this.numSL);
            this.Controls.Add(this.lblSL);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.cboDV);
            this.Controls.Add(this.lblDV);
            this.Controls.Add(this.txtPhong);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.cboLuot);
            this.Controls.Add(this.lblLuot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sử dụng dịch vụ";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblLuot;
        private System.Windows.Forms.ComboBox cboLuot;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblDV;
        private System.Windows.Forms.ComboBox cboDV;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvLichSu;
    }
}
