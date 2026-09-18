namespace QuanLyThuVien.Forms
{
    partial class FrmThongKe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label lblMuon;
        private System.Windows.Forms.Label lblQuaHan;
        private System.Windows.Forms.Label lblMat;
        private System.Windows.Forms.Label lblHuHong;
        private System.Windows.Forms.Label lblPhiPhat;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.DataGridView dgvPhat;
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
            this.lblTu = new System.Windows.Forms.Label();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.lblMuon = new System.Windows.Forms.Label();
            this.lblQuaHan = new System.Windows.Forms.Label();
            this.lblMat = new System.Windows.Forms.Label();
            this.lblHuHong = new System.Windows.Forms.Label();
            this.lblPhiPhat = new System.Windows.Forms.Label();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.dgvPhat = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhat)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(35, 35);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(61, 21);
            this.lblTu.TabIndex = 0;
            this.lblTu.Text = "Từ ngày";
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(360, 35);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(72, 21);
            this.lblDen.TabIndex = 1;
            this.lblDen.Text = "Đến ngày";
            // 
            // dtTu
            // 
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTu.Location = new System.Drawing.Point(115, 32);
            this.dtTu.Name = "dtTu";
            this.dtTu.Size = new System.Drawing.Size(180, 29);
            this.dtTu.TabIndex = 2;
            // 
            // dtDen
            // 
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDen.Location = new System.Drawing.Point(445, 32);
            this.dtDen.Name = "dtDen";
            this.dtDen.Size = new System.Drawing.Size(180, 29);
            this.dtDen.TabIndex = 3;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(670, 25);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(140, 42);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // lblMuon
            // 
            this.lblMuon.AutoSize = true;
            this.lblMuon.Location = new System.Drawing.Point(35, 100);
            this.lblMuon.Name = "lblMuon";
            this.lblMuon.Size = new System.Drawing.Size(139, 21);
            this.lblMuon.TabIndex = 5;
            this.lblMuon.Text = "Lượt sách mượn: 0";
            // 
            // lblQuaHan
            // 
            this.lblQuaHan.AutoSize = true;
            this.lblQuaHan.Location = new System.Drawing.Point(300, 100);
            this.lblQuaHan.Name = "lblQuaHan";
            this.lblQuaHan.Size = new System.Drawing.Size(115, 21);
            this.lblQuaHan.TabIndex = 6;
            this.lblQuaHan.Text = "Sách quá hạn: 0";
            // 
            // lblMat
            // 
            this.lblMat.AutoSize = true;
            this.lblMat.Location = new System.Drawing.Point(35, 145);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(82, 21);
            this.lblMat.TabIndex = 7;
            this.lblMat.Text = "Sách mất: 0";
            // 
            // lblHuHong
            // 
            this.lblHuHong.AutoSize = true;
            this.lblHuHong.Location = new System.Drawing.Point(300, 145);
            this.lblHuHong.Name = "lblHuHong";
            this.lblHuHong.Size = new System.Drawing.Size(114, 21);
            this.lblHuHong.TabIndex = 8;
            this.lblHuHong.Text = "Sách hư hỏng: 0";
            // 
            // lblPhiPhat
            // 
            this.lblPhiPhat.AutoSize = true;
            this.lblPhiPhat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPhiPhat.Location = new System.Drawing.Point(35, 190);
            this.lblPhiPhat.Name = "lblPhiPhat";
            this.lblPhiPhat.Size = new System.Drawing.Size(166, 25);
            this.lblPhiPhat.TabIndex = 9;
            this.lblPhiPhat.Text = "Tổng phí phạt: 0 đ";
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Location = new System.Drawing.Point(35, 245);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(137, 21);
            this.lblChiTiet.TabIndex = 10;
            this.lblChiTiet.Text = "Chi tiết phiếu phạt";
            // 
            // dgvPhat
            // 
            this.dgvPhat.AllowUserToAddRows = false;
            this.dgvPhat.AllowUserToDeleteRows = false;
            this.dgvPhat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhat.Location = new System.Drawing.Point(35, 280);
            this.dgvPhat.MultiSelect = false;
            this.dgvPhat.Name = "dgvPhat";
            this.dgvPhat.ReadOnly = true;
            this.dgvPhat.RowHeadersWidth = 51;
            this.dgvPhat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhat.Size = new System.Drawing.Size(1000, 340);
            this.dgvPhat.TabIndex = 11;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(905, 635);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(130, 42);
            this.btnDong.TabIndex = 12;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 700);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvPhat);
            this.Controls.Add(this.lblChiTiet);
            this.Controls.Add(this.lblPhiPhat);
            this.Controls.Add(this.lblHuHong);
            this.Controls.Add(this.lblMat);
            this.Controls.Add(this.lblQuaHan);
            this.Controls.Add(this.lblMuon);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtDen);
            this.Controls.Add(this.dtTu);
            this.Controls.Add(this.lblDen);
            this.Controls.Add(this.lblTu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
