namespace QuanLyCuaHangOnline
{
    partial class FrmSanPham
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
            this.lblNhom = new System.Windows.Forms.Label();
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Location = new System.Drawing.Point(20, 22);
            this.lblNhom.Size = new System.Drawing.Size(140, 26);
            this.lblNhom.Text = "Nhóm sản phẩm";
            this.Controls.Add(this.lblNhom);
            this.cboNhom = new System.Windows.Forms.ComboBox();
            this.cboNhom.Name = "cboNhom";
            this.cboNhom.Location = new System.Drawing.Point(165, 18);
            this.cboNhom.Size = new System.Drawing.Size(220, 28);
            this.cboNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Controls.Add(this.cboNhom);
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Location = new System.Drawing.Point(412, 22);
            this.lblTuKhoa.Size = new System.Drawing.Size(85, 26);
            this.lblTuKhoa.Text = "Từ khóa";
            this.Controls.Add(this.lblTuKhoa);
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Location = new System.Drawing.Point(500, 18);
            this.txtTuKhoa.Size = new System.Drawing.Size(235, 27);
            this.Controls.Add(this.txtTuKhoa);
            this.btnTim = new System.Windows.Forms.Button();
            this.btnTim.Name = "btnTim";
            this.btnTim.Location = new System.Drawing.Point(755, 16);
            this.btnTim.Size = new System.Drawing.Size(125, 36);
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += this.btnTim_Click;
            this.Controls.Add(this.btnTim);
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.Location = new System.Drawing.Point(20, 70);
            this.dgvSanPham.Size = new System.Drawing.Size(860, 405);
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.MultiSelect = false;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersHeight = 32;
            this.Controls.Add(this.dgvSanPham);
            this.lblSL = new System.Windows.Forms.Label();
            this.lblSL.Name = "lblSL";
            this.lblSL.Location = new System.Drawing.Point(20, 504);
            this.lblSL.Size = new System.Drawing.Size(85, 26);
            this.lblSL.Text = "Số lượng";
            this.Controls.Add(this.lblSL);
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Location = new System.Drawing.Point(110, 500);
            this.nudSoLuong.Size = new System.Drawing.Size(95, 28);
            this.nudSoLuong.Minimum = 1;
            this.nudSoLuong.Maximum = 999;
            this.nudSoLuong.Value = 1;
            this.Controls.Add(this.nudSoLuong);
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Location = new System.Drawing.Point(530, 497);
            this.btnChiTiet.Size = new System.Drawing.Size(160, 36);
            this.btnChiTiet.Text = "Xem chi tiết";
            this.btnChiTiet.UseVisualStyleBackColor = true;
            this.btnChiTiet.Click += this.btnChiTiet_Click;
            this.Controls.Add(this.btnChiTiet);
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThem.Name = "btnThem";
            this.btnThem.Location = new System.Drawing.Point(720, 497);
            this.btnThem.Size = new System.Drawing.Size(160, 36);
            this.btnThem.Text = "Thêm vào giỏ";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += this.btnThem_Click;
            this.Controls.Add(this.btnThem);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FrmSanPham";
            this.Text = "Danh sách sản phẩm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblNhom;
        private System.Windows.Forms.ComboBox cboNhom;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Button btnThem;
    }
}
