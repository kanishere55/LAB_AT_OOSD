namespace QuanLyCuaHangOnline
{
    partial class FrmMain
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Location = new System.Drawing.Point(30, 48);
            this.lblTitle.Size = new System.Drawing.Size(590, 55);
            this.lblTitle.Text = "e-SHOPPING";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(this.lblTitle);
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Location = new System.Drawing.Point(75, 155);
            this.btnSanPham.Size = new System.Drawing.Size(220, 65);
            this.btnSanPham.Text = "Sản phẩm";
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += this.btnSanPham_Click;
            this.Controls.Add(this.btnSanPham);
            this.btnGioHang = new System.Windows.Forms.Button();
            this.btnGioHang.Name = "btnGioHang";
            this.btnGioHang.Location = new System.Drawing.Point(355, 155);
            this.btnGioHang.Size = new System.Drawing.Size(220, 65);
            this.btnGioHang.Text = "Giỏ hàng";
            this.btnGioHang.UseVisualStyleBackColor = true;
            this.btnGioHang.Click += this.btnGioHang_Click;
            this.Controls.Add(this.btnGioHang);
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Location = new System.Drawing.Point(75, 260);
            this.btnTaiKhoan.Size = new System.Drawing.Size(220, 65);
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += this.btnTaiKhoan_Click;
            this.Controls.Add(this.btnTaiKhoan);
            this.btnDatHang = new System.Windows.Forms.Button();
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.Location = new System.Drawing.Point(355, 260);
            this.btnDatHang.Size = new System.Drawing.Size(220, 65);
            this.btnDatHang.Text = "Đặt hàng";
            this.btnDatHang.UseVisualStyleBackColor = true;
            this.btnDatHang.Click += this.btnDatHang_Click;
            this.Controls.Add(this.btnDatHang);
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Location = new System.Drawing.Point(215, 385);
            this.btnThoat.Size = new System.Drawing.Size(220, 50);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += this.btnThoat_Click;
            this.Controls.Add(this.btnThoat);
            this.lblSession = new System.Windows.Forms.Label();
            this.lblSession.Name = "lblSession";
            this.lblSession.Location = new System.Drawing.Point(25, 468);
            this.lblSession.Size = new System.Drawing.Size(600, 26);
            this.lblSession.Text = "Chưa đăng nhập";
            this.Controls.Add(this.lblSession);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FrmMain";
            this.Text = "e-SHOPPING - Cửa hàng online";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnGioHang;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnDatHang;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblSession;
    }
}
