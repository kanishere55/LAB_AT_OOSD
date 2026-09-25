using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyKhachSan.Forms
{
    // The positions here follow the seven reference screens in the lab handout.
    // Keep the existing controls and events so the forms remain usable with the services.
    internal static class ReferenceUi
    {
        internal static void Bounds(Control c, int x, int y, int width, int height)
        {
            c.SetBounds(x, y, width, height);
        }

        internal static void Date(DateTimePicker picker)
        {
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "dd/MM/yyyy";
        }

        internal static void Tabs(TabControl tabs)
        {
            tabs.Font = new Font("Segoe UI", 10F);
            foreach (TabPage page in tabs.TabPages)
            {
                page.BackColor = Color.White;
                if (!page.Text.StartsWith("["))
                    page.Text = "[" + page.Text + "]";
            }
        }

        // Alternating data is deliberately avoided: the handout uses white cells,
        // a pale blue header, thin grid lines and Vietnamese column names.
        internal static void Grid(DataGridView grid, params string[] columns)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowHeadersVisible = false;
            grid.BackgroundColor = Color.White;
            grid.GridColor = Color.FromArgb(215, 220, 226);
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(227, 240, 252);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(35, 43, 53);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F);
            grid.ColumnHeadersHeight = 30;
            grid.RowTemplate.Height = 34;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(49, 143, 235);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i + 1 < columns.Length; i += 2)
            {
                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = columns[i],
                    DataPropertyName = columns[i],
                    HeaderText = columns[i + 1],
                    SortMode = DataGridViewColumnSortMode.Automatic
                });
            }

            // Draw the empty rows seen in the reference without inserting fake
            // records (a fake selected row would trigger database lookups).
            grid.Paint += (sender, e) =>
            {
                if (grid.Rows.Count != 0 || grid.Columns.Count == 0) return;
                using (var pen = new Pen(grid.GridColor))
                {
                    int left = grid.RowHeadersVisible ? grid.RowHeadersWidth : 0;
                    for (int y = grid.ColumnHeadersHeight + grid.RowTemplate.Height; y < grid.ClientSize.Height; y += grid.RowTemplate.Height)
                        e.Graphics.DrawLine(pen, left, y, grid.ClientSize.Width - 1, y);
                    int x = left;
                    foreach (DataGridViewColumn column in grid.Columns)
                    {
                        if (!column.Visible) continue;
                        x += column.Width;
                        e.Graphics.DrawLine(pen, x, grid.ColumnHeadersHeight, x, grid.ClientSize.Height - 1);
                    }
                }
            };
        }

        internal static Image MenuIcon(int kind)
        {
            var bitmap = new Bitmap(48, 48);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var blue = new Pen(Color.FromArgb(43, 100, 150), 3))
                using (var dark = new Pen(Color.FromArgb(68, 75, 83), 3))
                using (var gold = new Pen(Color.FromArgb(165, 110, 12), 2))
                {
                    switch (kind)
                    {
                        case 0: // Clipboard
                            g.FillRectangle(Brushes.White, 11, 8, 27, 35);
                            g.DrawRectangle(blue, 11, 8, 27, 35);
                            g.FillRectangle(Brushes.White, 17, 4, 15, 8);
                            g.DrawRectangle(blue, 17, 4, 15, 8);
                            for (int y = 18; y <= 35; y += 8)
                            {
                                g.FillEllipse(Brushes.SteelBlue, 16, y, 4, 4);
                                g.DrawLine(blue, 24, y + 2, 34, y + 2);
                            }
                            break;
                        case 1: // Bed
                            using (var wood = new SolidBrush(Color.FromArgb(155, 91, 34)))
                            using (var mattress = new SolidBrush(Color.FromArgb(40, 145, 217)))
                            {
                                g.FillRectangle(wood, 7, 7, 5, 34);
                                g.FillRectangle(wood, 39, 21, 5, 20);
                                g.FillRectangle(mattress, 13, 19, 28, 15);
                                g.DrawRectangle(blue, 13, 19, 28, 15);
                                g.FillEllipse(Brushes.White, 14, 15, 11, 7);
                                g.DrawLine(dark, 9, 36, 42, 36);
                            }
                            break;
                        case 2: // Key
                            using (var yellow = new SolidBrush(Color.FromArgb(255, 200, 42)))
                            {
                                g.FillEllipse(yellow, 23, 4, 19, 19);
                                g.DrawEllipse(gold, 23, 4, 19, 19);
                                g.FillEllipse(Brushes.White, 29, 10, 6, 6);
                                g.DrawLine(new Pen(Color.FromArgb(250, 182, 24), 10), 28, 20, 9, 40);
                                g.DrawLine(gold, 28, 20, 9, 40);
                                g.DrawLine(gold, 11, 33, 18, 39);
                            }
                            break;
                        case 3: // Gear
                            using (var steel = new SolidBrush(Color.FromArgb(116, 137, 159)))
                            {
                                for (int a = 0; a < 8; a++)
                                {
                                    g.TranslateTransform(24, 24);
                                    g.RotateTransform(a * 45);
                                    g.FillRectangle(steel, -4, -22, 8, 12);
                                    g.ResetTransform();
                                }
                                g.FillEllipse(steel, 8, 8, 32, 32);
                                g.DrawEllipse(dark, 8, 8, 32, 32);
                                g.FillEllipse(Brushes.White, 18, 18, 12, 12);
                            }
                            break;
                        case 4: // Payment
                            using (var green = new SolidBrush(Color.FromArgb(42, 151, 75)))
                            using (var skin = new SolidBrush(Color.FromArgb(244, 191, 127)))
                            {
                                g.FillRectangle(green, 16, 5, 28, 21);
                                g.DrawRectangle(dark, 16, 5, 28, 21);
                                g.FillEllipse(Brushes.LightGreen, 25, 8, 11, 13);
                                g.FillPolygon(skin, new[] { new Point(4, 26), new Point(20, 27), new Point(29, 23), new Point(39, 28), new Point(22, 41), new Point(5, 38) });
                                g.DrawLine(gold, 5, 39, 28, 39);
                            }
                            break;
                        case 5: // Statistics
                            using (var b1 = new SolidBrush(Color.FromArgb(41, 148, 213)))
                            using (var b2 = new SolidBrush(Color.FromArgb(244, 174, 35)))
                            using (var b3 = new SolidBrush(Color.FromArgb(52, 167, 67)))
                            {
                                g.FillRectangle(b1, 6, 26, 10, 17);
                                g.FillRectangle(b2, 20, 18, 10, 25);
                                g.FillRectangle(b3, 34, 7, 10, 36);
                            }
                            break;
                        case 6: // Exit
                            using (var wood = new SolidBrush(Color.FromArgb(162, 96, 43)))
                            using (var green = new SolidBrush(Color.FromArgb(34, 176, 81)))
                            {
                                g.FillPolygon(wood, new[] { new Point(10, 5), new Point(30, 9), new Point(30, 42), new Point(10, 38) });
                                g.DrawPolygon(dark, new[] { new Point(10, 5), new Point(30, 9), new Point(30, 42), new Point(10, 38) });
                                g.FillPolygon(green, new[] { new Point(26, 19), new Point(37, 19), new Point(37, 14), new Point(46, 25), new Point(37, 36), new Point(37, 31), new Point(26, 31) });
                                g.FillEllipse(Brushes.Gold, 24, 24, 3, 3);
                            }
                            break;
                    }
                }
            }
            return bitmap;
        }
    }

    public partial class FrmMain
    {
        private void ApplyReferenceLayout()
        {
            ClientSize = new Size(940, 468);
            ReferenceUi.Bounds(lblTieuDe, 20, 34, 900, 67);
            ReferenceUi.Bounds(btnDanhMuc, 30, 125, 280, 82);
            ReferenceUi.Bounds(btnPhong, 330, 125, 280, 82);
            ReferenceUi.Bounds(btnDatPhong, 630, 125, 280, 82);
            ReferenceUi.Bounds(btnDichVu, 30, 238, 280, 82);
            ReferenceUi.Bounds(btnTraPhong, 330, 238, 280, 82);
            ReferenceUi.Bounds(btnThongKe, 630, 238, 280, 82);
            ReferenceUi.Bounds(btnThoat, 330, 351, 280, 80);

            SetMenuButton(btnDanhMuc, "Danh mục", 0);
            SetMenuButton(btnPhong, "Phòng - Tiện nghi", 1);
            SetMenuButton(btnDatPhong, "Đặt / Nhận phòng", 2);
            SetMenuButton(btnDichVu, "Sử dụng dịch vụ", 3);
            SetMenuButton(btnTraPhong, "Trả phòng - Thanh toán", 4);
            SetMenuButton(btnThongKe, "Thống kê", 5);
            SetMenuButton(btnThoat, "Thoát", 6);
        }

        private static void SetMenuButton(Button button, string title, int icon)
        {
            button.Text = title;
            button.Image = ReferenceUi.MenuIcon(icon);
            button.UseVisualStyleBackColor = true;
            button.Font = new Font("Segoe UI", 11F);
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.ImageAlign = ContentAlignment.MiddleCenter;
        }
    }

    public partial class FrmDanhMuc
    {
        private void ApplyReferenceLayout()
        {
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(1024, 535);
            ReferenceUi.Bounds(tabControl1, 18, 15, 988, 490);
            ReferenceUi.Tabs(tabControl1);
            btnDong.Visible = false;
            foreach (TabPage page in tabControl1.TabPages)
            {
                foreach (Control c in page.Controls)
                    if (c is DataGridView)
                        ReferenceUi.Bounds(c, 10, 84, 960, 350);
            }
            ReferenceUi.Grid(dgvKhu, "MaKhuVuc", "Mã", "TenKhuVuc", "Tên khu vực");
            ReferenceUi.Grid(dgvNV, "MaNV", "Mã", "HoTen", "Tên", "VaiTro", "Vai trò", "SoDienThoai", "Số điện thoại");
            ReferenceUi.Grid(dgvLoaiTN, "MaLoaiTN", "Mã", "TenLoaiTN", "Tên loại tiện nghi");
            ReferenceUi.Grid(dgvDV, "MaDV", "Mã", "TenDV", "Tên", "DonViTinh", "Đơn vị", "DonGia", "Đơn giá / Mức");
            ReferenceUi.Grid(dgvQD, "MaQuyDinh", "Mã", "TenLoaiTN", "Loại", "MucDoThietHai", "Mức độ", "MucDenBu", "Mức đền bù");

            ReferenceUi.Bounds(txtDVMa, 65, 16, 140, 29);
            ReferenceUi.Bounds(lblDVTen, 230, 19, 40, 22);
            ReferenceUi.Bounds(txtDVTen, 275, 16, 215, 29);
            ReferenceUi.Bounds(lblDVDVT, 505, 19, 120, 22);
            ReferenceUi.Bounds(txtDVDVT, 630, 16, 150, 29);
            ReferenceUi.Bounds(btnThemDV, 850, 14, 115, 32);
            ReferenceUi.Bounds(lblDVGia, 630, 53, 80, 22);
            ReferenceUi.Bounds(numDVGia, 710, 50, 150, 29);
            ReferenceUi.Bounds(btnThemKhu, 850, 14, 115, 32);
            ReferenceUi.Bounds(btnThemNV, 850, 14, 115, 32);
            ReferenceUi.Bounds(btnThemLoaiTN, 850, 14, 115, 32);
            ReferenceUi.Bounds(btnThemQD, 850, 14, 115, 32);
        }
    }

    public partial class FrmPhongTienNghi
    {
        private void ApplyReferenceLayout()
        {
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(940, 505);
            ReferenceUi.Bounds(tabControl1, 20, 15, 900, 465);
            ReferenceUi.Tabs(tabControl1);
            btnDong.Visible = false;
            ReferenceUi.Bounds(dgvPhong, 10, 72, 870, 265);
            ReferenceUi.Bounds(dgvTN, 10, 72, 870, 330);
            ReferenceUi.Bounds(dgvLD, 10, 135, 870, 265);
            ReferenceUi.Grid(dgvPhong, "SoPhong", "Phòng", "TenKhuVuc", "Khu", "SoNguoiToiDa", "Sức chứa", "DonGiaNgay", "Đơn giá", "TrangThai", "Trạng thái");
            ReferenceUi.Grid(dgvTN, "MaTienNghi", "Mã tiện nghi", "TenLoaiTN", "Loại", "SoThuTu", "Số thứ tự", "TinhTrangHienTai", "Tình trạng");
            ReferenceUi.Grid(dgvLD, "SoPhieuLapDat", "Phiếu lắp đặt", "MaTienNghi", "Tiện nghi", "SoPhong", "Phòng", "TinhTrang", "Tình trạng", "NgayLap", "Ngày lắp");
            ReferenceUi.Date(dtNgay);

            // Show the main lắp đặt fields below the room list as pictured.
            // They move back to the detailed tab when that tab is selected.
            MovePlacementControls(false);
            tabControl1.SelectedIndexChanged += (sender, args) =>
                MovePlacementControls(tabControl1.SelectedTab == tabLapDat);
            ReferenceUi.Bounds(btnThemPhong, 780, 14, 100, 32);
        }

        private void MovePlacementControls(bool detailedTab)
        {
            Control target = detailedTab ? (Control)tabLapDat : tabPhong;
            Control[] placement = { lblSoLD, txtSoLD, lblTNLD, cboTN, lblPhongLD, cboPhong, lblTTLD, txtTTLD, btnLapDat };
            foreach (Control c in placement) target.Controls.Add(c);
            lblSoLD.Text = "Phiếu lắp đặt:";
            if (detailedTab)
            {
                ReferenceUi.Bounds(txtGhiChu, 375, 48, 275, 29);
                ReferenceUi.Bounds(lblNgay, 665, 51, 80, 24);
                ReferenceUi.Bounds(dtNgay, 745, 48, 145, 29);
                ReferenceUi.Bounds(lblSoLD, 10, 15, 110, 24);
                ReferenceUi.Bounds(txtSoLD, 120, 12, 125, 29);
                ReferenceUi.Bounds(lblTNLD, 260, 15, 78, 24);
                ReferenceUi.Bounds(cboTN, 340, 12, 115, 29);
                ReferenceUi.Bounds(lblPhongLD, 470, 15, 65, 24);
                ReferenceUi.Bounds(cboPhong, 535, 12, 105, 29);
                ReferenceUi.Bounds(lblTTLD, 655, 15, 85, 24);
                ReferenceUi.Bounds(txtTTLD, 740, 12, 140, 29);
                ReferenceUi.Bounds(btnLapDat, 740, 92, 140, 34);
            }
            else
            {
                ReferenceUi.Bounds(lblSoLD, 10, 370, 110, 24);
                ReferenceUi.Bounds(txtSoLD, 120, 368, 125, 29);
                ReferenceUi.Bounds(lblTNLD, 265, 370, 78, 24);
                ReferenceUi.Bounds(cboTN, 345, 368, 115, 29);
                ReferenceUi.Bounds(lblPhongLD, 480, 370, 65, 24);
                ReferenceUi.Bounds(cboPhong, 545, 368, 105, 29);
                ReferenceUi.Bounds(lblTTLD, 670, 370, 85, 24);
                ReferenceUi.Bounds(txtTTLD, 755, 368, 125, 29);
                ReferenceUi.Bounds(btnLapDat, 740, 405, 140, 34);
            }
        }
    }

    public partial class FrmDatPhong
    {
        private void ApplyReferenceLayout()
        {
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(960, 555);
            ReferenceUi.Bounds(tabControl1, 15, 15, 930, 510);
            ReferenceUi.Tabs(tabControl1);
            btnDong.Visible = false;
            ReferenceUi.Bounds(dgvKhach, 10, 75, 900, 375);
            ReferenceUi.Bounds(dgvPhong, 10, 58, 430, 165);
            ReferenceUi.Bounds(dgvChon, 495, 58, 425, 165);
            ReferenceUi.Bounds(numSoNguoi, 448, 65, 42, 29);
            ReferenceUi.Bounds(btnThemPhong, 448, 108, 40, 32);
            ReferenceUi.Bounds(btnBoPhong, 448, 148, 40, 32);
            ReferenceUi.Bounds(lblPhieuDat, 10, 305, 160, 24);
            ReferenceUi.Bounds(dgvPhieu, 10, 331, 910, 135);
            ReferenceUi.Bounds(btnLapPhieu, 770, 263, 150, 34);
            ReferenceUi.Bounds(dtLap, 88, 238, 125, 29);
            ReferenceUi.Bounds(dtNhan, 305, 238, 125, 29);
            ReferenceUi.Bounds(dtTra, 514, 238, 125, 29);
            ReferenceUi.Bounds(cboNV, 700, 238, 145, 29);
            ReferenceUi.Bounds(lblLap, 10, 241, 75, 23);
            lblLap.Text = "Ngày lập:";
            ReferenceUi.Bounds(lblNhan, 225, 241, 80, 23);
            lblNhan.Text = "Ngày nhận:";
            ReferenceUi.Bounds(lblTra, 442, 241, 72, 23);
            lblTra.Text = "Ngày trả:";
            ReferenceUi.Bounds(lblNV, 652, 241, 45, 23);
            lblNV.Text = "Lễ tân:";
            ReferenceUi.Date(dtLap);
            ReferenceUi.Date(dtNhan);
            ReferenceUi.Date(dtTra);
            ReferenceUi.Grid(dgvKhach, "MaKhach", "Mã khách", "HoTen", "Họ tên", "SoCMND", "CCCD", "QuocTich", "Quốc tịch", "SoDienThoai", "Số điện thoại");
            ReferenceUi.Grid(dgvPhong, "SoPhong", "Phòng", "TenKhuVuc", "Khu", "SoNguoiToiDa", "Sức chứa", "DonGiaNgay", "Đơn giá");
            ReferenceUi.Grid(dgvChon, "SoPhong", "Phòng chọn", "SoNguoi", "Số người", "DonGiaNgay", "Đơn giá/ngày");
            ReferenceUi.Grid(dgvPhieu, "SoPhieuDat", "Số phiếu", "HoTen", "Khách", "NgayNhan", "Ngày nhận", "NgayTraDuKien", "Ngày trả dự kiến", "TienCoc", "Cọc", "KenhDat", "Kênh", "TrangThai", "Trạng thái");
            ReferenceUi.Grid(dgvCT, "SoPhong", "Phòng", "SoNguoi", "Số người", "SoNguoiToiDa", "Sức chứa", "DonGiaNgay", "Đơn giá");
            ReferenceUi.Grid(dgvNguoi, "HoTen", "Họ tên", "SoPhong", "Phòng", "SoCMND", "CCCD", "QuocTich", "Quốc tịch");
        }
    }

    public partial class FrmDichVu
    {
        private void ApplyReferenceLayout()
        {
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(1050, 635);
            btnDong.Visible = false;
            ReferenceUi.Bounds(lblLuot, 35, 34, 125, 25);
            ReferenceUi.Bounds(cboLuot, 165, 29, 180, 32);
            ReferenceUi.Bounds(lblPhong, 375, 34, 75, 25);
            ReferenceUi.Bounds(txtPhong, 455, 29, 130, 32);
            ReferenceUi.Bounds(lblDV, 615, 34, 85, 25);
            ReferenceUi.Bounds(cboDV, 710, 29, 225, 32);
            ReferenceUi.Bounds(lblNgay, 35, 88, 125, 25);
            ReferenceUi.Bounds(dtNgay, 165, 83, 180, 32);
            ReferenceUi.Bounds(lblSL, 375, 88, 80, 25);
            ReferenceUi.Bounds(numSL, 455, 83, 130, 32);
            ReferenceUi.Bounds(btnGhi, 710, 81, 180, 40);
            ReferenceUi.Bounds(dgvLichSu, 35, 170, 980, 420);
            ReferenceUi.Date(dtNgay);
            ReferenceUi.Grid(dgvLichSu, "SoPhieuSDDV", "Số phiếu", "SoPhong", "Phòng", "NgaySuDung", "Ngày", "TenDV", "Dịch vụ", "SoLuong", "Số lượng", "DonGia", "Đơn giá", "ThanhTien", "Thành tiền");
        }
    }

    public partial class FrmTraPhong
    {
        private void ApplyReferenceLayout()
        {
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(1050, 685);
            btnDong.Visible = false;
            ReferenceUi.Bounds(lblDat, 28, 30, 118, 24);
            ReferenceUi.Bounds(cboDat, 150, 25, 160, 29);
            ReferenceUi.Bounds(dgvPhong, 28, 75, 280, 170);
            ReferenceUi.Bounds(dgvTN, 328, 75, 334, 170);
            ReferenceUi.Bounds(dgvDBChon, 682, 75, 340, 170);
            ReferenceUi.Bounds(lblSoDB, 28, 270, 130, 24);
            ReferenceUi.Bounds(txtSoDB, 160, 266, 140, 29);
            ReferenceUi.Bounds(lblMucDo, 326, 270, 80, 24);
            ReferenceUi.Bounds(txtMucDo, 410, 266, 160, 29);
            ReferenceUi.Bounds(lblDenBu, 595, 270, 70, 24);
            ReferenceUi.Bounds(numDenBu, 668, 266, 145, 29);
            ReferenceUi.Bounds(btnThemDB, 790, 262, 95, 35);
            btnThemDB.Text = "Thêm";
            btnThemDB.Visible = true;
            ReferenceUi.Bounds(btnLapDB, 895, 262, 135, 35);
            ReferenceUi.Bounds(lblSoHD, 28, 331, 110, 24);
            ReferenceUi.Bounds(txtSoHD, 140, 327, 145, 29);
            ReferenceUi.Bounds(lblSoNgay, 315, 331, 140, 24);
            ReferenceUi.Bounds(numSoNgay, 456, 327, 100, 29);
            ReferenceUi.Bounds(btnLapHD, 590, 325, 140, 35);
            ReferenceUi.Bounds(dgvHD, 28, 390, 994, 190);
            ReferenceUi.Bounds(lblHT, 28, 610, 90, 24);
            ReferenceUi.Bounds(cboHT, 120, 606, 150, 29);
            ReferenceUi.Bounds(lblTienTT, 300, 610, 75, 24);
            ReferenceUi.Bounds(numTienTT, 380, 606, 145, 29);
            ReferenceUi.Bounds(btnThanhToan, 545, 604, 145, 35);
            ReferenceUi.Bounds(btnTraPhong, 710, 604, 185, 35);
            ReferenceUi.Grid(dgvPhong, "SoPhong", "Phòng", "DonGiaNgay", "Đơn giá/ngày");
            ReferenceUi.Grid(dgvTN, "MaTienNghi", "Tiện nghi", "TenLoaiTN", "Loại", "TinhTrangHienTai", "Tình trạng");
            ReferenceUi.Grid(dgvDBChon, "TenLoaiTN", "Tiện nghi đền bù", "MucDoThietHai", "Mức độ", "SoTien", "Số tiền");
            ReferenceUi.Grid(dgvHD, "SoHoaDon", "Hóa đơn", "SoPhieuDat", "Phiếu đặt", "TienPhong", "Tiền phòng", "TienDichVu", "Tiền dịch vụ", "TongTien", "Tổng tiền", "TrangThai", "Trạng thái");
        }
    }

    public partial class FrmThongKe
    {
        private void ApplyReferenceLayout()
        {
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(1095, 690);
            btnDong.Visible = false;
            ReferenceUi.Bounds(lblTu, 38, 31, 90, 26);
            ReferenceUi.Bounds(dtTu, 130, 26, 165, 32);
            ReferenceUi.Bounds(lblDen, 325, 31, 105, 26);
            ReferenceUi.Bounds(dtDen, 430, 26, 165, 32);
            ReferenceUi.Bounds(btnTK, 625, 24, 140, 36);
            ReferenceUi.Bounds(lblPhieuDat, 42, 105, 300, 30);
            ReferenceUi.Bounds(lblDangO, 550, 105, 300, 30);
            ReferenceUi.Bounds(lblHoaDon, 42, 155, 300, 30);
            ReferenceUi.Bounds(lblDoanhThu, 550, 155, 450, 30);
            ReferenceUi.Bounds(lblDenBu, 42, 205, 430, 30);
            ReferenceUi.Bounds(lblDichVu, 35, 275, 200, 26);
            ReferenceUi.Bounds(dgvDV, 35, 305, 1025, 300);
            ReferenceUi.Date(dtTu);
            ReferenceUi.Date(dtDen);
            dtTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtDen.Value = dtTu.Value.AddMonths(1).AddDays(-1);
            lblPhieuDat.Text = "Phiếu đặt: 0";
            lblDangO.Text = "Đang ở: 0";
            lblHoaDon.Text = "Hóa đơn: 0";
            lblDoanhThu.Text = "Doanh thu HĐ: 0 đ";
            lblDenBu.Text = "Tổng đền bù: 0 đ";
            ReferenceUi.Grid(dgvDV, "MaDV", "Mã DV", "TenDV", "Tên dịch vụ", "TongSoLuong", "Tổng số lượng", "TongTien", "Tổng tiền");
        }
    }
}
