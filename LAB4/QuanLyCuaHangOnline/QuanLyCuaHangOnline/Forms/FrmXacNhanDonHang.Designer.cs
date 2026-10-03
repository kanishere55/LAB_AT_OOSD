namespace QuanLyCuaHangOnline
{
    partial class FrmXacNhanDonHang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.lblMaDon = new System.Windows.Forms.Label();
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Location = new System.Drawing.Point(25, 23);
            this.lblMaDon.Size = new System.Drawing.Size(840, 35);
            this.lblMaDon.Text = "";
            this.Controls.Add(this.lblMaDon);
            this.lblNguoiMua = new System.Windows.Forms.Label();
            this.lblNguoiMua.Name = "lblNguoiMua";
            this.lblNguoiMua.Location = new System.Drawing.Point(25, 75);
            this.lblNguoiMua.Size = new System.Drawing.Size(840, 26);
            this.lblNguoiMua.Text = "";
            this.Controls.Add(this.lblNguoiMua);
            this.lblNguoiNhan = new System.Windows.Forms.Label();
            this.lblNguoiNhan.Name = "lblNguoiNhan";
            this.lblNguoiNhan.Location = new System.Drawing.Point(25, 115);
            this.lblNguoiNhan.Size = new System.Drawing.Size(840, 48);
            this.lblNguoiNhan.Text = "";
            this.Controls.Add(this.lblNguoiNhan);
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Location = new System.Drawing.Point(25, 170);
            this.lblTongTien.Size = new System.Drawing.Size(840, 26);
            this.lblTongTien.Text = "";
            this.Controls.Add(this.lblTongTien);
            this.lblThanhToan = new System.Windows.Forms.Label();
            this.lblThanhToan.Name = "lblThanhToan";
            this.lblThanhToan.Location = new System.Drawing.Point(25, 210);
            this.lblThanhToan.Size = new System.Drawing.Size(840, 26);
            this.lblThanhToan.Text = "";
            this.Controls.Add(this.lblThanhToan);
            this.lblCT = new System.Windows.Forms.Label();
            this.lblCT.Name = "lblCT";
            this.lblCT.Location = new System.Drawing.Point(25, 255);
            this.lblCT.Size = new System.Drawing.Size(840, 26);
            this.lblCT.Text = "Chi tiết đơn hàng";
            this.Controls.Add(this.lblCT);
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.Location = new System.Drawing.Point(25, 290);
            this.dgvChiTiet.Size = new System.Drawing.Size(850, 215);
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersHeight = 32;
            this.Controls.Add(this.dgvChiTiet);
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Location = new System.Drawing.Point(25, 525);
            this.lblEmail.Size = new System.Drawing.Size(840, 26);
            this.lblEmail.Text = "";
            this.Controls.Add(this.lblEmail);
            this.btnDong = new System.Windows.Forms.Button();
            this.btnDong.Name = "btnDong";
            this.btnDong.Location = new System.Drawing.Point(700, 562);
            this.btnDong.Size = new System.Drawing.Size(175, 36);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += this.btnDong_Click;
            this.Controls.Add(this.btnDong);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 610);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FrmXacNhanDonHang";
            this.Text = "Xác nhận đơn hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblMaDon;
        private System.Windows.Forms.Label lblNguoiMua;
        private System.Windows.Forms.Label lblNguoiNhan;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblThanhToan;
        private System.Windows.Forms.Label lblCT;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnDong;
    }
}
