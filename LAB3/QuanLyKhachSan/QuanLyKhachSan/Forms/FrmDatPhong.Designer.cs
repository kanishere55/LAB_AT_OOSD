namespace QuanLyKhachSan.Forms
{
    partial class FrmDatPhong
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
            this.tabKhachHang = new System.Windows.Forms.TabPage();
            this.btnThemKhach = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtQT = new System.Windows.Forms.TextBox();
            this.lblQT = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.dgvKhach = new System.Windows.Forms.DataGridView();
            this.tabDatPhong = new System.Windows.Forms.TabPage();
            this.btnBoPhong = new System.Windows.Forms.Button();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.numSoNguoi = new System.Windows.Forms.NumericUpDown();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.dgvChon = new System.Windows.Forms.DataGridView();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.numCoc = new System.Windows.Forms.NumericUpDown();
            this.lblCoc = new System.Windows.Forms.Label();
            this.dtTra = new System.Windows.Forms.DateTimePicker();
            this.lblTra = new System.Windows.Forms.Label();
            this.dtNhan = new System.Windows.Forms.DateTimePicker();
            this.lblNhan = new System.Windows.Forms.Label();
            this.dtLap = new System.Windows.Forms.DateTimePicker();
            this.lblLap = new System.Windows.Forms.Label();
            this.cboKenh = new System.Windows.Forms.ComboBox();
            this.lblKenh = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.cboKhach = new System.Windows.Forms.ComboBox();
            this.lblKhach = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.lblPhieuDat = new System.Windows.Forms.Label();
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.tabNhanPhong = new System.Windows.Forms.TabPage();
            this.btnNoShow = new System.Windows.Forms.Button();
            this.btnNhanPhong = new System.Windows.Forms.Button();
            this.btnThemNguoi = new System.Windows.Forms.Button();
            this.txtNguoiQT = new System.Windows.Forms.TextBox();
            this.lblNguoiQT = new System.Windows.Forms.Label();
            this.txtNguoiCMND = new System.Windows.Forms.TextBox();
            this.lblNguoiCMND = new System.Windows.Forms.Label();
            this.txtNguoiTen = new System.Windows.Forms.TextBox();
            this.lblNguoiTen = new System.Windows.Forms.Label();
            this.txtNguoiPhong = new System.Windows.Forms.TextBox();
            this.lblNguoiPhong = new System.Windows.Forms.Label();
            this.dgvNguoi = new System.Windows.Forms.DataGridView();
            this.dgvCT = new System.Windows.Forms.DataGridView();
            this.txtPhieuChon = new System.Windows.Forms.TextBox();
            this.lblPhieuChon = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).BeginInit();
            this.tabDatPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            this.tabNhanPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKhachHang);
            this.tabControl1.Controls.Add(this.tabDatPhong);
            this.tabControl1.Controls.Add(this.tabNhanPhong);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(950, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // tabKhachHang
            // 
            this.tabKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabKhachHang.Controls.Add(this.btnThemKhach);
            this.tabKhachHang.Controls.Add(this.txtSDT);
            this.tabKhachHang.Controls.Add(this.lblSDT);
            this.tabKhachHang.Controls.Add(this.txtQT);
            this.tabKhachHang.Controls.Add(this.lblQT);
            this.tabKhachHang.Controls.Add(this.txtCMND);
            this.tabKhachHang.Controls.Add(this.lblCMND);
            this.tabKhachHang.Controls.Add(this.txtTenKH);
            this.tabKhachHang.Controls.Add(this.lblTenKH);
            this.tabKhachHang.Controls.Add(this.txtMaKH);
            this.tabKhachHang.Controls.Add(this.lblMaKH);
            this.tabKhachHang.Controls.Add(this.dgvKhach);
            this.tabKhachHang.Location = new System.Drawing.Point(4, 30);
            this.tabKhachHang.Name = "tabKhachHang";
            this.tabKhachHang.Size = new System.Drawing.Size(942, 526);
            this.tabKhachHang.TabIndex = 0;
            this.tabKhachHang.Text = "Khách hàng";
            // 
            // btnThemKhach
            // 
            this.btnThemKhach.Location = new System.Drawing.Point(800, 15);
            this.btnThemKhach.Name = "btnThemKhach";
            this.btnThemKhach.Size = new System.Drawing.Size(125, 34);
            this.btnThemKhach.TabIndex = 11;
            this.btnThemKhach.Text = "Lưu khách";
            this.btnThemKhach.UseVisualStyleBackColor = true;
            this.btnThemKhach.Click += new System.EventHandler(this.btnThemKhach_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(670, 18);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(115, 29);
            this.txtSDT.TabIndex = 10;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(625, 21);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(41, 21);
            this.lblSDT.TabIndex = 9;
            this.lblSDT.Text = "SĐT:";
            // 
            // txtQT
            // 
            this.txtQT.Location = new System.Drawing.Point(515, 18);
            this.txtQT.Name = "txtQT";
            this.txtQT.Size = new System.Drawing.Size(100, 29);
            this.txtQT.TabIndex = 8;
            this.txtQT.Text = "Việt Nam";
            // 
            // lblQT
            // 
            this.lblQT.AutoSize = true;
            this.lblQT.Location = new System.Drawing.Point(435, 21);
            this.lblQT.Name = "lblQT";
            this.lblQT.Size = new System.Drawing.Size(79, 21);
            this.lblQT.TabIndex = 7;
            this.lblQT.Text = "Quốc tịch:";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(325, 18);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(100, 29);
            this.txtCMND.TabIndex = 6;
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Location = new System.Drawing.Point(265, 21);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(56, 21);
            this.lblCMND.TabIndex = 5;
            this.lblCMND.Text = "CCCD:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(145, 18);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(110, 29);
            this.txtTenKH.TabIndex = 4;
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(85, 21);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(59, 21);
            this.lblTenKH.TabIndex = 3;
            this.lblTenKH.Text = "Họ tên:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(35, 18);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(45, 29);
            this.txtMaKH.TabIndex = 2;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(5, 21);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(35, 21);
            this.lblMaKH.TabIndex = 1;
            this.lblMaKH.Text = "Mã:";
            // 
            // dgvKhach
            // 
            this.dgvKhach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhach.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhach.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvKhach.EnableHeadersVisualStyles = false;
            this.dgvKhach.GridColor = System.Drawing.Color.LightGray;
            this.dgvKhach.Location = new System.Drawing.Point(10, 65);
            this.dgvKhach.Name = "dgvKhach";
            this.dgvKhach.RowHeadersWidth = 51;
            this.dgvKhach.RowTemplate.Height = 28;
            this.dgvKhach.Size = new System.Drawing.Size(915, 445);
            this.dgvKhach.TabIndex = 0;
            // 
            // tabDatPhong
            // 
            this.tabDatPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabDatPhong.Controls.Add(this.lblPhieuDat);
            this.tabDatPhong.Controls.Add(this.dgvPhieu);
            this.tabDatPhong.Controls.Add(this.btnBoPhong);
            this.tabDatPhong.Controls.Add(this.btnThemPhong);
            this.tabDatPhong.Controls.Add(this.numSoNguoi);
            this.tabDatPhong.Controls.Add(this.lblSoNguoi);
            this.tabDatPhong.Controls.Add(this.dgvChon);
            this.tabDatPhong.Controls.Add(this.dgvPhong);
            this.tabDatPhong.Controls.Add(this.btnLapPhieu);
            this.tabDatPhong.Controls.Add(this.numCoc);
            this.tabDatPhong.Controls.Add(this.lblCoc);
            this.tabDatPhong.Controls.Add(this.dtTra);
            this.tabDatPhong.Controls.Add(this.lblTra);
            this.tabDatPhong.Controls.Add(this.dtNhan);
            this.tabDatPhong.Controls.Add(this.lblNhan);
            this.tabDatPhong.Controls.Add(this.dtLap);
            this.tabDatPhong.Controls.Add(this.lblLap);
            this.tabDatPhong.Controls.Add(this.cboKenh);
            this.tabDatPhong.Controls.Add(this.lblKenh);
            this.tabDatPhong.Controls.Add(this.cboNV);
            this.tabDatPhong.Controls.Add(this.lblNV);
            this.tabDatPhong.Controls.Add(this.cboKhach);
            this.tabDatPhong.Controls.Add(this.lblKhach);
            this.tabDatPhong.Controls.Add(this.txtSoPhieu);
            this.tabDatPhong.Controls.Add(this.lblSoPhieu);
            this.tabDatPhong.Location = new System.Drawing.Point(4, 30);
            this.tabDatPhong.Name = "tabDatPhong";
            this.tabDatPhong.Size = new System.Drawing.Size(942, 526);
            this.tabDatPhong.TabIndex = 1;
            this.tabDatPhong.Text = "Đặt phòng";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(100, 12);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(120, 29);
            this.txtSoPhieu.TabIndex = 1;
            this.txtSoPhieu.Text = "DP001";
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Location = new System.Drawing.Point(5, 15);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(100, 21);
            this.lblSoPhieu.TabIndex = 0;
            this.lblSoPhieu.Text = "Số phiếu đặt:";
            // 
            // cboKhach
            // 
            this.cboKhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhach.FormattingEnabled = true;
            this.cboKhach.Location = new System.Drawing.Point(290, 12);
            this.cboKhach.Name = "cboKhach";
            this.cboKhach.Size = new System.Drawing.Size(180, 29);
            this.cboKhach.TabIndex = 3;
            // 
            // lblKhach
            // 
            this.lblKhach.AutoSize = true;
            this.lblKhach.Location = new System.Drawing.Point(235, 15);
            this.lblKhach.Name = "lblKhach";
            this.lblKhach.Size = new System.Drawing.Size(55, 21);
            this.lblKhach.TabIndex = 2;
            this.lblKhach.Text = "Khách:";
            // 
            // cboKenh
            // 
            this.cboKenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKenh.FormattingEnabled = true;
            this.cboKenh.Location = new System.Drawing.Point(565, 12);
            this.cboKenh.Name = "cboKenh";
            this.cboKenh.Size = new System.Drawing.Size(130, 29);
            this.cboKenh.TabIndex = 7;
            // 
            // lblKenh
            // 
            this.lblKenh.AutoSize = true;
            this.lblKenh.Location = new System.Drawing.Point(490, 15);
            this.lblKenh.Name = "lblKenh";
            this.lblKenh.Size = new System.Drawing.Size(71, 21);
            this.lblKenh.TabIndex = 6;
            this.lblKenh.Text = "Kênh đặt:";
            // 
            // numCoc
            // 
            this.numCoc.Location = new System.Drawing.Point(780, 12);
            this.numCoc.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numCoc.Name = "numCoc";
            this.numCoc.Size = new System.Drawing.Size(145, 29);
            this.numCoc.TabIndex = 15;
            this.numCoc.Value = new decimal(new int[] { 500000, 0, 0, 0 });
            // 
            // lblCoc
            // 
            this.lblCoc.AutoSize = true;
            this.lblCoc.Location = new System.Drawing.Point(710, 15);
            this.lblCoc.Name = "lblCoc";
            this.lblCoc.Size = new System.Drawing.Size(71, 21);
            this.lblCoc.TabIndex = 14;
            this.lblCoc.Text = "Tiền cọc:";
            // 
            // dgvPhong
            // 
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvPhong.EnableHeadersVisualStyles = false;
            this.dgvPhong.GridColor = System.Drawing.Color.LightGray;
            this.dgvPhong.Location = new System.Drawing.Point(10, 50);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.RowHeadersWidth = 35;
            this.dgvPhong.RowTemplate.Height = 26;
            this.dgvPhong.Size = new System.Drawing.Size(430, 175);
            this.dgvPhong.TabIndex = 17;
            // 
            // dgvChon
            // 
            this.dgvChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChon.BackgroundColor = System.Drawing.Color.White;
            this.dgvChon.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvChon.EnableHeadersVisualStyles = false;
            this.dgvChon.GridColor = System.Drawing.Color.LightGray;
            this.dgvChon.Location = new System.Drawing.Point(495, 50);
            this.dgvChon.Name = "dgvChon";
            this.dgvChon.RowHeadersWidth = 35;
            this.dgvChon.RowTemplate.Height = 26;
            this.dgvChon.Size = new System.Drawing.Size(430, 175);
            this.dgvChon.TabIndex = 18;
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(448, 90);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(40, 32);
            this.btnThemPhong.TabIndex = 21;
            this.btnThemPhong.Text = ">";
            this.btnThemPhong.UseVisualStyleBackColor = true;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // btnBoPhong
            // 
            this.btnBoPhong.Location = new System.Drawing.Point(448, 130);
            this.btnBoPhong.Name = "btnBoPhong";
            this.btnBoPhong.Size = new System.Drawing.Size(40, 32);
            this.btnBoPhong.TabIndex = 22;
            this.btnBoPhong.Text = "<";
            this.btnBoPhong.UseVisualStyleBackColor = true;
            this.btnBoPhong.Click += new System.EventHandler(this.btnBoPhong_Click);
            // 
            // numSoNguoi
            // 
            this.numSoNguoi.Location = new System.Drawing.Point(448, 55);
            this.numSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNguoi.Name = "numSoNguoi";
            this.numSoNguoi.Size = new System.Drawing.Size(42, 29);
            this.numSoNguoi.TabIndex = 20;
            this.numSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoNguoi
            // 
            this.lblSoNguoi.Location = new System.Drawing.Point(0, 0);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Size = new System.Drawing.Size(0, 0);
            this.lblSoNguoi.TabIndex = 24;
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLapPhieu.Location = new System.Drawing.Point(775, 230);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(150, 34);
            this.btnLapPhieu.TabIndex = 16;
            this.btnLapPhieu.Text = "Lập phiếu đặt";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // lblPhieuDat
            // 
            this.lblPhieuDat.AutoSize = true;
            this.lblPhieuDat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhieuDat.Location = new System.Drawing.Point(10, 245);
            this.lblPhieuDat.Name = "lblPhieuDat";
            this.lblPhieuDat.Size = new System.Drawing.Size(125, 21);
            this.lblPhieuDat.TabIndex = 23;
            this.lblPhieuDat.Text = "Phiếu đặt phòng:";
            // 
            // dgvPhieu
            // 
            this.dgvPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieu.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvPhieu.EnableHeadersVisualStyles = false;
            this.dgvPhieu.GridColor = System.Drawing.Color.LightGray;
            this.dgvPhieu.Location = new System.Drawing.Point(10, 270);
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.RowHeadersWidth = 35;
            this.dgvPhieu.RowTemplate.Height = 26;
            this.dgvPhieu.Size = new System.Drawing.Size(915, 245);
            this.dgvPhieu.TabIndex = 19;
            this.dgvPhieu.SelectionChanged += new System.EventHandler(this.dgvPhieu_SelectionChanged);
            // 
            // dtLap
            // 
            this.dtLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtLap.Location = new System.Drawing.Point(145, 233);
            this.dtLap.Name = "dtLap";
            this.dtLap.Size = new System.Drawing.Size(100, 29);
            this.dtLap.TabIndex = 9;
            // 
            // lblLap
            // 
            this.lblLap.Location = new System.Drawing.Point(0, 0);
            this.lblLap.Name = "lblLap";
            this.lblLap.Size = new System.Drawing.Size(0, 0);
            this.lblLap.TabIndex = 25;
            // 
            // dtNhan
            // 
            this.dtNhan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNhan.Location = new System.Drawing.Point(260, 233);
            this.dtNhan.Name = "dtNhan";
            this.dtNhan.Size = new System.Drawing.Size(100, 29);
            this.dtNhan.TabIndex = 11;
            // 
            // lblNhan
            // 
            this.lblNhan.Location = new System.Drawing.Point(0, 0);
            this.lblNhan.Name = "lblNhan";
            this.lblNhan.Size = new System.Drawing.Size(0, 0);
            this.lblNhan.TabIndex = 26;
            // 
            // dtTra
            // 
            this.dtTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTra.Location = new System.Drawing.Point(375, 233);
            this.dtTra.Name = "dtTra";
            this.dtTra.Size = new System.Drawing.Size(100, 29);
            this.dtTra.TabIndex = 13;
            // 
            // lblTra
            // 
            this.lblTra.Location = new System.Drawing.Point(0, 0);
            this.lblTra.Name = "lblTra";
            this.lblTra.Size = new System.Drawing.Size(0, 0);
            this.lblTra.TabIndex = 27;
            // 
            // cboNV
            // 
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(495, 233);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(130, 29);
            this.cboNV.TabIndex = 5;
            // 
            // lblNV
            // 
            this.lblNV.Location = new System.Drawing.Point(0, 0);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(0, 0);
            this.lblNV.TabIndex = 28;
            // 
            // tabNhanPhong
            // 
            this.tabNhanPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabNhanPhong.Controls.Add(this.btnNoShow);
            this.tabNhanPhong.Controls.Add(this.btnNhanPhong);
            this.tabNhanPhong.Controls.Add(this.btnThemNguoi);
            this.tabNhanPhong.Controls.Add(this.txtNguoiQT);
            this.tabNhanPhong.Controls.Add(this.lblNguoiQT);
            this.tabNhanPhong.Controls.Add(this.txtNguoiCMND);
            this.tabNhanPhong.Controls.Add(this.lblNguoiCMND);
            this.tabNhanPhong.Controls.Add(this.txtNguoiTen);
            this.tabNhanPhong.Controls.Add(this.lblNguoiTen);
            this.tabNhanPhong.Controls.Add(this.txtNguoiPhong);
            this.tabNhanPhong.Controls.Add(this.lblNguoiPhong);
            this.tabNhanPhong.Controls.Add(this.dgvNguoi);
            this.tabNhanPhong.Controls.Add(this.dgvCT);
            this.tabNhanPhong.Controls.Add(this.txtPhieuChon);
            this.tabNhanPhong.Controls.Add(this.lblPhieuChon);
            this.tabNhanPhong.Location = new System.Drawing.Point(4, 30);
            this.tabNhanPhong.Name = "tabNhanPhong";
            this.tabNhanPhong.Size = new System.Drawing.Size(942, 526);
            this.tabNhanPhong.TabIndex = 2;
            this.tabNhanPhong.Text = "Nhận phòng / Người lưu trú";
            // 
            // btnNoShow
            // 
            this.btnNoShow.Location = new System.Drawing.Point(760, 480);
            this.btnNoShow.Name = "btnNoShow";
            this.btnNoShow.Size = new System.Drawing.Size(165, 36);
            this.btnNoShow.TabIndex = 15;
            this.btnNoShow.Text = "Đánh dấu No-show";
            this.btnNoShow.UseVisualStyleBackColor = true;
            this.btnNoShow.Click += new System.EventHandler(this.btnNoShow_Click);
            // 
            // btnNhanPhong
            // 
            this.btnNhanPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNhanPhong.Location = new System.Drawing.Point(600, 480);
            this.btnNhanPhong.Name = "btnNhanPhong";
            this.btnNhanPhong.Size = new System.Drawing.Size(145, 36);
            this.btnNhanPhong.TabIndex = 14;
            this.btnNhanPhong.Text = "Nhận phòng";
            this.btnNhanPhong.UseVisualStyleBackColor = true;
            this.btnNhanPhong.Click += new System.EventHandler(this.btnNhanPhong_Click);
            // 
            // btnThemNguoi
            // 
            this.btnThemNguoi.Location = new System.Drawing.Point(815, 235);
            this.btnThemNguoi.Name = "btnThemNguoi";
            this.btnThemNguoi.Size = new System.Drawing.Size(110, 32);
            this.btnThemNguoi.TabIndex = 13;
            this.btnThemNguoi.Text = "Thêm người";
            this.btnThemNguoi.UseVisualStyleBackColor = true;
            this.btnThemNguoi.Click += new System.EventHandler(this.btnThemNguoi_Click);
            // 
            // txtNguoiQT
            // 
            this.txtNguoiQT.Location = new System.Drawing.Point(685, 237);
            this.txtNguoiQT.Name = "txtNguoiQT";
            this.txtNguoiQT.Size = new System.Drawing.Size(115, 29);
            this.txtNguoiQT.TabIndex = 12;
            this.txtNguoiQT.Text = "Việt Nam";
            // 
            // lblNguoiQT
            // 
            this.lblNguoiQT.AutoSize = true;
            this.lblNguoiQT.Location = new System.Drawing.Point(605, 240);
            this.lblNguoiQT.Name = "lblNguoiQT";
            this.lblNguoiQT.Size = new System.Drawing.Size(79, 21);
            this.lblNguoiQT.TabIndex = 11;
            this.lblNguoiQT.Text = "Quốc tịch:";
            // 
            // txtNguoiCMND
            // 
            this.txtNguoiCMND.Location = new System.Drawing.Point(475, 237);
            this.txtNguoiCMND.Name = "txtNguoiCMND";
            this.txtNguoiCMND.Size = new System.Drawing.Size(115, 29);
            this.txtNguoiCMND.TabIndex = 10;
            // 
            // lblNguoiCMND
            // 
            this.lblNguoiCMND.AutoSize = true;
            this.lblNguoiCMND.Location = new System.Drawing.Point(415, 240);
            this.lblNguoiCMND.Name = "lblNguoiCMND";
            this.lblNguoiCMND.Size = new System.Drawing.Size(56, 21);
            this.lblNguoiCMND.TabIndex = 9;
            this.lblNguoiCMND.Text = "CCCD:";
            // 
            // txtNguoiTen
            // 
            this.txtNguoiTen.Location = new System.Drawing.Point(245, 237);
            this.txtNguoiTen.Name = "txtNguoiTen";
            this.txtNguoiTen.Size = new System.Drawing.Size(155, 29);
            this.txtNguoiTen.TabIndex = 8;
            // 
            // lblNguoiTen
            // 
            this.lblNguoiTen.AutoSize = true;
            this.lblNguoiTen.Location = new System.Drawing.Point(185, 240);
            this.lblNguoiTen.Name = "lblNguoiTen";
            this.lblNguoiTen.Size = new System.Drawing.Size(59, 21);
            this.lblNguoiTen.TabIndex = 7;
            this.lblNguoiTen.Text = "Họ tên:";
            // 
            // txtNguoiPhong
            // 
            this.txtNguoiPhong.Location = new System.Drawing.Point(85, 237);
            this.txtNguoiPhong.Name = "txtNguoiPhong";
            this.txtNguoiPhong.Size = new System.Drawing.Size(85, 29);
            this.txtNguoiPhong.TabIndex = 6;
            // 
            // lblNguoiPhong
            // 
            this.lblNguoiPhong.AutoSize = true;
            this.lblNguoiPhong.Location = new System.Drawing.Point(20, 240);
            this.lblNguoiPhong.Name = "lblNguoiPhong";
            this.lblNguoiPhong.Size = new System.Drawing.Size(59, 21);
            this.lblNguoiPhong.TabIndex = 5;
            this.lblNguoiPhong.Text = "Phòng:";
            // 
            // dgvNguoi
            // 
            this.dgvNguoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguoi.BackgroundColor = System.Drawing.Color.White;
            this.dgvNguoi.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvNguoi.EnableHeadersVisualStyles = false;
            this.dgvNguoi.GridColor = System.Drawing.Color.LightGray;
            this.dgvNguoi.Location = new System.Drawing.Point(15, 280);
            this.dgvNguoi.Name = "dgvNguoi";
            this.dgvNguoi.RowHeadersWidth = 51;
            this.dgvNguoi.RowTemplate.Height = 28;
            this.dgvNguoi.Size = new System.Drawing.Size(910, 185);
            this.dgvNguoi.TabIndex = 4;
            // 
            // dgvCT
            // 
            this.dgvCT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCT.BackgroundColor = System.Drawing.Color.White;
            this.dgvCT.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvCT.EnableHeadersVisualStyles = false;
            this.dgvCT.GridColor = System.Drawing.Color.LightGray;
            this.dgvCT.Location = new System.Drawing.Point(15, 55);
            this.dgvCT.Name = "dgvCT";
            this.dgvCT.RowHeadersWidth = 51;
            this.dgvCT.RowTemplate.Height = 28;
            this.dgvCT.Size = new System.Drawing.Size(910, 165);
            this.dgvCT.TabIndex = 3;
            // 
            // txtPhieuChon
            // 
            this.txtPhieuChon.Location = new System.Drawing.Point(125, 14);
            this.txtPhieuChon.Name = "txtPhieuChon";
            this.txtPhieuChon.ReadOnly = true;
            this.txtPhieuChon.Size = new System.Drawing.Size(150, 29);
            this.txtPhieuChon.TabIndex = 2;
            // 
            // lblPhieuChon
            // 
            this.lblPhieuChon.AutoSize = true;
            this.lblPhieuChon.Location = new System.Drawing.Point(20, 17);
            this.lblPhieuChon.Name = "lblPhieuChon";
            this.lblPhieuChon.Size = new System.Drawing.Size(91, 21);
            this.lblPhieuChon.TabIndex = 1;
            this.lblPhieuChon.Text = "Phiếu chọn:";
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDong.Location = new System.Drawing.Point(845, 580);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(115, 34);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(974, 624);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDatPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Khách hàng - Đặt phòng - Nhận phòng";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabKhachHang.ResumeLayout(false);
            this.tabKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).EndInit();
            this.tabDatPhong.ResumeLayout(false);
            this.tabDatPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            this.tabNhanPhong.ResumeLayout(false);
            this.tabNhanPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKhachHang;
        private System.Windows.Forms.TabPage tabDatPhong;
        private System.Windows.Forms.TabPage tabNhanPhong;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvKhach;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.TextBox txtQT;
        private System.Windows.Forms.Label lblQT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Button btnThemKhach;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.ComboBox cboKhach;
        private System.Windows.Forms.Label lblKhach;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.ComboBox cboKenh;
        private System.Windows.Forms.Label lblKenh;
        private System.Windows.Forms.DateTimePicker dtLap;
        private System.Windows.Forms.Label lblLap;
        private System.Windows.Forms.DateTimePicker dtNhan;
        private System.Windows.Forms.Label lblNhan;
        private System.Windows.Forms.DateTimePicker dtTra;
        private System.Windows.Forms.Label lblTra;
        private System.Windows.Forms.NumericUpDown numCoc;
        private System.Windows.Forms.Label lblCoc;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.DataGridView dgvChon;
        private System.Windows.Forms.NumericUpDown numSoNguoi;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.Button btnBoPhong;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.Label lblPhieuDat;
        private System.Windows.Forms.TextBox txtPhieuChon;
        private System.Windows.Forms.Label lblPhieuChon;
        private System.Windows.Forms.DataGridView dgvCT;
        private System.Windows.Forms.DataGridView dgvNguoi;
        private System.Windows.Forms.TextBox txtNguoiPhong;
        private System.Windows.Forms.Label lblNguoiPhong;
        private System.Windows.Forms.TextBox txtNguoiTen;
        private System.Windows.Forms.Label lblNguoiTen;
        private System.Windows.Forms.TextBox txtNguoiCMND;
        private System.Windows.Forms.Label lblNguoiCMND;
        private System.Windows.Forms.TextBox txtNguoiQT;
        private System.Windows.Forms.Label lblNguoiQT;
        private System.Windows.Forms.Button btnThemNguoi;
        private System.Windows.Forms.Button btnNhanPhong;
        private System.Windows.Forms.Button btnNoShow;
    }
}