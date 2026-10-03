namespace QuanLyCuaHangOnline
{
    partial class FrmThanhToan
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
            this.lblLoaiThe = new System.Windows.Forms.Label();
            this.lblLoaiThe.Name = "lblLoaiThe";
            this.lblLoaiThe.Location = new System.Drawing.Point(30, 40);
            this.lblLoaiThe.Size = new System.Drawing.Size(155, 26);
            this.lblLoaiThe.Text = "Loại thẻ";
            this.Controls.Add(this.lblLoaiThe);
            this.cboLoaiThe = new System.Windows.Forms.ComboBox();
            this.cboLoaiThe.Name = "cboLoaiThe";
            this.cboLoaiThe.Location = new System.Drawing.Point(210, 35);
            this.cboLoaiThe.Size = new System.Drawing.Size(250, 28);
            this.cboLoaiThe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThe.Items.AddRange(new object[] { "VISA", "Master", "Discover", "American Express" });
            this.cboLoaiThe.SelectedIndex = 0;
            this.Controls.Add(this.cboLoaiThe);
            this.lblSoThe = new System.Windows.Forms.Label();
            this.lblSoThe.Name = "lblSoThe";
            this.lblSoThe.Location = new System.Drawing.Point(30, 107);
            this.lblSoThe.Size = new System.Drawing.Size(155, 26);
            this.lblSoThe.Text = "Số thẻ";
            this.Controls.Add(this.lblSoThe);
            this.txtSoThe = new System.Windows.Forms.TextBox();
            this.txtSoThe.Name = "txtSoThe";
            this.txtSoThe.Location = new System.Drawing.Point(210, 102);
            this.txtSoThe.Size = new System.Drawing.Size(460, 27);
            this.Controls.Add(this.txtSoThe);
            this.lblHetHan = new System.Windows.Forms.Label();
            this.lblHetHan.Name = "lblHetHan";
            this.lblHetHan.Location = new System.Drawing.Point(30, 174);
            this.lblHetHan.Size = new System.Drawing.Size(155, 26);
            this.lblHetHan.Text = "Ngày hết hạn";
            this.Controls.Add(this.lblHetHan);
            this.dtpHetHan = new System.Windows.Forms.DateTimePicker();
            this.dtpHetHan.Name = "dtpHetHan";
            this.dtpHetHan.Location = new System.Drawing.Point(210, 169);
            this.dtpHetHan.Size = new System.Drawing.Size(190, 28);
            this.dtpHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHetHan.CustomFormat = "MM/yyyy";
            this.dtpHetHan.ShowUpDown = true;
            this.dtpHetHan.Value = System.DateTime.Today.AddYears(2);
            this.Controls.Add(this.dtpHetHan);
            this.lblChuThe = new System.Windows.Forms.Label();
            this.lblChuThe.Name = "lblChuThe";
            this.lblChuThe.Location = new System.Drawing.Point(30, 241);
            this.lblChuThe.Size = new System.Drawing.Size(155, 26);
            this.lblChuThe.Text = "Tên chủ thẻ";
            this.Controls.Add(this.lblChuThe);
            this.txtChuThe = new System.Windows.Forms.TextBox();
            this.txtChuThe.Name = "txtChuThe";
            this.txtChuThe.Location = new System.Drawing.Point(210, 236);
            this.txtChuThe.Size = new System.Drawing.Size(460, 27);
            this.Controls.Add(this.txtChuThe);
            this.lblCSV = new System.Windows.Forms.Label();
            this.lblCSV.Name = "lblCSV";
            this.lblCSV.Location = new System.Drawing.Point(30, 308);
            this.lblCSV.Size = new System.Drawing.Size(155, 26);
            this.lblCSV.Text = "Mã CSV";
            this.Controls.Add(this.lblCSV);
            this.txtCSV = new System.Windows.Forms.TextBox();
            this.txtCSV.Name = "txtCSV";
            this.txtCSV.Location = new System.Drawing.Point(210, 303);
            this.txtCSV.Size = new System.Drawing.Size(140, 27);
            this.txtCSV.UseSystemPasswordChar = true;
            this.Controls.Add(this.txtCSV);
            this.lblPhiThe = new System.Windows.Forms.Label();
            this.lblPhiThe.Name = "lblPhiThe";
            this.lblPhiThe.Location = new System.Drawing.Point(30, 375);
            this.lblPhiThe.Size = new System.Drawing.Size(640, 26);
            this.lblPhiThe.Text = "";
            this.Controls.Add(this.lblPhiThe);
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Location = new System.Drawing.Point(30, 416);
            this.lblTongTien.Size = new System.Drawing.Size(640, 26);
            this.lblTongTien.Text = "";
            this.Controls.Add(this.lblTongTien);
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Location = new System.Drawing.Point(430, 484);
            this.btnXacNhan.Size = new System.Drawing.Size(240, 36);
            this.btnXacNhan.Text = "Xác nhận thanh toán";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += this.btnXacNhan_Click;
            this.Controls.Add(this.btnXacNhan);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 555);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FrmThanhToan";
            this.Text = "Thanh toán thẻ tín dụng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblLoaiThe;
        private System.Windows.Forms.ComboBox cboLoaiThe;
        private System.Windows.Forms.Label lblSoThe;
        private System.Windows.Forms.TextBox txtSoThe;
        private System.Windows.Forms.Label lblHetHan;
        private System.Windows.Forms.DateTimePicker dtpHetHan;
        private System.Windows.Forms.Label lblChuThe;
        private System.Windows.Forms.TextBox txtChuThe;
        private System.Windows.Forms.Label lblCSV;
        private System.Windows.Forms.TextBox txtCSV;
        private System.Windows.Forms.Label lblPhiThe;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnXacNhan;
    }
}
