namespace QuanLyCuaHangOnline
{
    partial class FrmGioHang
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
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.Location = new System.Drawing.Point(20, 24);
            this.dgvGioHang.Size = new System.Drawing.Size(860, 405);
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AllowUserToDeleteRows = false;
            this.dgvGioHang.RowHeadersVisible = false;
            this.dgvGioHang.MultiSelect = false;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.ColumnHeadersHeight = 32;
            this.Controls.Add(this.dgvGioHang);
            this.lblSL = new System.Windows.Forms.Label();
            this.lblSL.Name = "lblSL";
            this.lblSL.Location = new System.Drawing.Point(20, 458);
            this.lblSL.Size = new System.Drawing.Size(110, 26);
            this.lblSL.Text = "Số lượng mới";
            this.Controls.Add(this.lblSL);
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Location = new System.Drawing.Point(135, 454);
            this.nudSoLuong.Size = new System.Drawing.Size(95, 28);
            this.nudSoLuong.Minimum = 0;
            this.nudSoLuong.Maximum = 999;
            this.nudSoLuong.Value = 1;
            this.Controls.Add(this.nudSoLuong);
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Location = new System.Drawing.Point(255, 450);
            this.btnCapNhat.Size = new System.Drawing.Size(140, 36);
            this.btnCapNhat.Text = "Cập nhật SL";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += this.btnCapNhat_Click;
            this.Controls.Add(this.btnCapNhat);
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Location = new System.Drawing.Point(415, 450);
            this.btnXoa.Size = new System.Drawing.Size(140, 36);
            this.btnXoa.Text = "Xóa khỏi giỏ";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += this.btnXoa_Click;
            this.Controls.Add(this.btnXoa);
            this.lblTienHang = new System.Windows.Forms.Label();
            this.lblTienHang.Name = "lblTienHang";
            this.lblTienHang.Location = new System.Drawing.Point(580, 459);
            this.lblTienHang.Size = new System.Drawing.Size(300, 26);
            this.lblTienHang.Text = "Tiền hàng: 0 đ";
            this.Controls.Add(this.lblTienHang);
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Location = new System.Drawing.Point(650, 508);
            this.btnCheckout.Size = new System.Drawing.Size(230, 36);
            this.btnCheckout.Text = "Đặt hàng / Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += this.btnCheckout_Click;
            this.Controls.Add(this.btnCheckout);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FrmGioHang";
            this.Text = "Giỏ hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblTienHang;
        private System.Windows.Forms.Button btnCheckout;
    }
}
