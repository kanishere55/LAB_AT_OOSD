using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QuanLyVanPhong.Services;

namespace QuanLyVanPhong.Forms
{
    public class ModuleForm : Form
    {
        protected readonly VanPhongService S = new VanPhongService();
        public readonly Dictionary<string, Control> Fields = new Dictionary<string, Control>();
        public readonly List<DataGridView> Tables = new List<DataGridView>();
        protected readonly TabControl Tabs = new TabControl
        {
            Dock = DockStyle.Fill
        };
        protected readonly Label Status = new Label
        {
            Dock = DockStyle.Bottom,
            Height = 52,
            Padding = new Padding(10, 5, 10, 0),
            BackColor = Color.FromArgb(234, 242, 249)
        };
        public Action Reload;
        protected ModuleForm(string title)
        {
            Text = title;
            Name = GetType().Name;
            Font = new Font("Segoe UI", 10);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1240, 830);
            MinimumSize = new Size(1120, 800);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            Controls.Add(Tabs);
            Controls.Add(Status);
            var h = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(225, 225, 225),
                Dock = DockStyle.Top,
                Height = 58,
                Padding = new Padding(16, 14, 0, 0)
            };
            Controls.Add(h);
            Shown += (a, b) => RefreshData();
        }

        public void RefreshData()
        {
            try
            {
                if (Reload != null)
                    Reload();
                Status.Text = "Đã tải dữ liệu SQL Server • " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Status.ForeColor = Color.DarkGreen;
            }
            catch (Exception e)
            {
                Status.Text = S.ThongBaoLoi(e);
                Status.ForeColor = Color.Firebrick;
            }
        }

        protected void Run(Action work, string success = "Đã lưu dữ liệu.")
        {
            try
            {
                work();
                RefreshData();
                Status.Text = success;
                Status.ForeColor = Color.DarkGreen;
            }
            catch (Exception e)
            {
                Status.Text = S.ThongBaoLoi(e);
                Status.ForeColor = Color.Firebrick;
                
            }
        }

        public static string NewId(string p)
        {
            return p + DateTime.Now.ToString("yyMMddHHmmssffff");
        }

        protected TextBox Txt(string key, string val = "", int max = 500)
        {
            var c = new TextBox
            {
                Text = val,
                MaxLength = max,
                Dock = DockStyle.Top
            };
            Fields.Add(key, c);
            return c;
        }

        protected ComboBox Combo(string key, string[] values = null)
        {
            var c = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Top
            };
            Fields.Add(key, c);
            if (values != null)
            {
                c.Items.AddRange(values);
                c.SelectedIndex = 0;
            }

            return c;
        }

        protected DateTimePicker Date(string key, DateTime? val = null, bool time = false)
        {
            var c = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = time ? "dd/MM/yyyy HH:mm" : "dd/MM/yyyy",
                Value = val ?? DateTime.Now,
                Dock = DockStyle.Top
            };
            Fields.Add(key, c);
            return c;
        }

        protected NumericUpDown Num(string key, decimal val = 0, int decimals = 0)
        {
            var c = new NumericUpDown
            {
                Minimum = 0,
                Maximum = 1000000000,
                DecimalPlaces = decimals,
                ThousandsSeparator = true,
                Value = val,
                Dock = DockStyle.Top
            };
            Fields.Add(key, c);
            return c;
        }

        protected CheckBox Check(string key)
        {
            var c = new CheckBox
            {
                Text = "Đã xác nhận",
                Dock = DockStyle.Top
            };
            Fields.Add(key, c);
            return c;
        }

        protected string V(string key)
        {
            var c = Fields[key] as ComboBox;
            if (c != null && c.DataSource != null)
                return Convert.ToString(c.SelectedValue);
            return Fields[key].Text.Trim();
        }

        protected DateTime D(string key)
        {
            return ((DateTimePicker)Fields[key]).Value;
        }

        protected decimal N(string key)
        {
            return ((NumericUpDown)Fields[key]).Value;
        }

        protected bool B(string key)
        {
            return ((CheckBox)Fields[key]).Checked;
        }

        protected void Set(string key, object v)
        {
            if (Fields[key] is DateTimePicker)
            {
                if (v != DBNull.Value)
                    ((DateTimePicker)Fields[key]).Value = Convert.ToDateTime(v);
                return;
            }

            if (Fields[key] is NumericUpDown)
            {
                ((NumericUpDown)Fields[key]).Value = v == DBNull.Value ? 0 : Convert.ToDecimal(v);
                return;
            }

            if (Fields[key] is CheckBox)
            {
                ((CheckBox)Fields[key]).Checked = v != DBNull.Value && Convert.ToBoolean(v);
                return;
            }

            if (Fields[key] is ComboBox && ((ComboBox)Fields[key]).DataSource != null)
                ((ComboBox)Fields[key]).SelectedValue = v;
            else
                Fields[key].Text = Convert.ToString(v);
        }

        protected void Bind(string key, DataTable t)
        {
            var c = (ComboBox)Fields[key];
            var old = Convert.ToString(c.SelectedValue);
            c.DataSource = t;
            c.DisplayMember = "Ten";
            c.ValueMember = "Ma";
            if (old != "")
                c.SelectedValue = old;
            if (c.SelectedIndex < 0 && t.Rows.Count > 0)
                c.SelectedIndex = 0;
        }

        protected Tuple<string, Control> F(string label, Control c)
        {
            return Tuple.Create(label, c);
        }

        protected Tuple<string, Action> A(string label, Action action)
        {
            return Tuple.Create(label, action);
        }

        public static DataGridView Grid()
        {
            var g = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(222, 233, 244);
            g.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            g.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            g.DefaultCellStyle.Padding = new Padding(3);
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 249, 252);
            g.CellFormatting += (a, e) =>
            {
                if (e.ColumnIndex < 0 || !(e.Value is string)) return;
                var column = g.Columns[e.ColumnIndex];
                int width = Math.Max(16, column.Width - e.CellStyle.Padding.Horizontal - 14);
                e.Value = WrapLongWords((string)e.Value, e.CellStyle.Font ?? g.Font, width);
                e.FormattingApplied = true;
            };
            g.DataBindingComplete += (a, b) => SizeColumns(g);
            return g;
        }

        static string WrapLongWords(string text, Font font, int width)
        {
            var flags = TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine;
            return Regex.Replace(text, @"[^\s]+", match =>
            {
                string word = match.Value;
                if (TextRenderer.MeasureText(word, font, Size.Empty, flags).Width <= width) return word;
                var result = new StringBuilder();
                var line = new StringBuilder();
                foreach (char letter in word)
                {
                    if (line.Length > 0 && TextRenderer.MeasureText(line.ToString() + letter, font, Size.Empty, flags).Width > width)
                    {
                        result.Append(line).Append(Environment.NewLine);
                        line.Clear();
                    }
                    line.Append(letter);
                }
                return result.Append(line).ToString();
            });
        }

        public static void SizeColumns(DataGridView g)
        {
            foreach (DataGridViewColumn c in g.Columns)
            {
                var headers = new Dictionary<string, string>
                {
                    {"MaTang", "Mã tầng"},
                    {"SoTang", "Số tầng"},
                    {"TenTang", "Tên tầng"},
                    {"MaPhong", "Mã phòng"},
                    {"DienTich", "Diện tích (m²)"},
                    {"Huong", "Hướng"},
                    {"DonGiaThang", "Giá/tháng"},
                    {"DangSua", "Đang sửa"},
                    {"MaKH", "Mã khách"},
                    {"TenCongTy", "Tên công ty"},
                    {"MaSoThue", "Mã số thuế"},
                    {"NguoiDaiDien", "Đại diện"},
                    {"DienThoai", "Điện thoại"},
                    {"DiaChi", "Địa chỉ"},
                    {"SoHD", "Số HĐ"},
                    {"NgayKy", "Ngày ký"},
                    {"TuNgay", "Từ ngày"},
                    {"DenNgay", "Đến ngày"},
                    {"SoThangThue", "Tháng thuê gốc"},
                    {"SoThang", "Số tháng"},
                    {"DieuKhoan", "Điều khoản"},
                    {"NgayHetHan", "Hết hạn hiện tại"},
                    {"MaKy", "Mã kỳ thuê"},
                    {"HanThu", "Hạn thu"},
                    {"SoTien", "Số tiền"},
                    {"MaDV", "Mã dịch vụ"},
                    {"TenDV", "Tên dịch vụ"},
                    {"DonViTinh", "Đơn vị"},
                    {"DonGia", "Đơn giá"},
                    {"MaSD", "Mã sử dụng"},
                    {"NgaySuDung", "Ngày sử dụng"},
                    {"SoLuong", "Số lượng"},
                    {"MaHDDV", "Mã HĐ dịch vụ"},
                    {"Thang", "Tháng"},
                    {"Nam", "Năm"},
                    {"NgayLap", "Ngày lập"},
                    {"TongTien", "Tổng tiền"},
                    {"SoLanThu", "Số lần thu"},
                    {"SoGH", "Số gia hạn"},
                    {"NguoiLap", "Người lập"},
                    {"MaNV", "Mã NV"},
                    {"HoTen", "Họ tên"},
                    {"ChucVu", "Chức vụ"},
                    {"NgayBaoCao", "Ngày báo cáo"},
                    {"MaThe", "Mã thẻ"},
                    {"BienSo", "Biển số"},
                    {"LoaiXe", "Loại xe"},
                    {"NhanHieu", "Nhãn hiệu"},
                    {"MauXe", "Màu xe"},
                    {"NgayCap", "Ngày cấp"},
                    {"SoDot", "Số đợt"},
                    {"NgayKiemTra", "Ngày kiểm tra"},
                    {"NguoiKiemTra", "Người kiểm tra"},
                    {"NoiDung", "Nội dung"},
                    {"TinhTrang", "Tình trạng"},
                    {"CanTuSua", "Cần tu sửa"},
                    {"ViPhamKetCau", "Vi phạm kết cấu"},
                    {"DeXuat", "Đề xuất"},
                    {"SoPhat", "Số phạt"},
                    {"MaTT", "Mã thanh toán"},
                    {"NgayThu", "Ngày thu"},
                    {"HinhThuc", "Hình thức"},
                    {"NguoiThu", "Người thu"},
                    {"Loai", "Loại khoản"},
                    {"MaKhoan", "Mã khoản"},
                    {"DaThu", "Đã thu"},
                    {"ConLai", "Còn lại"},
                    {"ThanhTien", "Thành tiền"},
                    {"KiemTraGanNhat", "Kiểm tra gần nhất"},
                    {"HanKiemTra", "Hạn kiểm tra lại"},
                    {"TrangThai", "Trạng thái"}
                };
                if (headers.ContainsKey(c.DataPropertyName))
                    c.HeaderText = headers[c.DataPropertyName];
                string n = c.HeaderText;
                c.MinimumWidth = 48;
                if (c.DataPropertyName == "HinhAnh") { c.Visible = false; continue; }
                c.FillWeight = n.Contains("Kết") || n.Contains("Nội dung") || n.Contains("Địa chỉ") || n.Contains("Điều khoản") ? 175 : (n.Contains("Họ tên") || n.Contains("Nhân viên") || n.Contains("Tên") ? 135 : 85);
                if (c.ValueType == typeof(DateTime))
                    c.DefaultCellStyle.Format = "dd/MM/yyyy";
                if (c.ValueType == typeof(decimal))
                    c.DefaultCellStyle.Format = (c.DataPropertyName == "DienTich" || c.DataPropertyName == "SoLuong") ? "N2" : "N0";
            }
        }

        protected DataGridView Page(string title, Tuple<string, Control>[] fields, Tuple<string, Action>[] actions)
        {
            var page = new TabPage(title)
            {
                Padding = new Padding(10),
                BackColor = Color.White
            };
            Tabs.TabPages.Add(page);
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3
            };
            int rows = (fields.Length + 2) / 3;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, rows * 74));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            var inputs = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = rows
            };
            for (int i = 0; i < 3; i++)
                inputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333f));
            for (int i = 0; i < rows; i++)
                inputs.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            for (int i = 0; i < fields.Length; i++)
            {
                var box = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(0, 0, 14, 0)
                };
                var label = new Label
                {
                    Text = fields[i].Item1,
                    Dock = DockStyle.Top,
                    Height = 25,
                    AutoEllipsis = false
                };
                fields[i].Item2.Margin = new Padding(0);
                box.Controls.Add(fields[i].Item2);
                box.Controls.Add(label);
                inputs.Controls.Add(box, i % 3, i / 3);
            }

            var buttons = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                AutoScroll = true
            };
            foreach (var a in actions)
            {
                var copy = a;
                var button = new Button
                {
                    Text = a.Item1,
                    AutoSize = true,
                    Height = 34,
                    MinimumSize = new Size(110, 34),
                    BackColor = Color.FromArgb(231, 239, 248),
                    FlatStyle = FlatStyle.Flat
                };
                button.Click += (o, e) => Run(copy.Item2);
                buttons.Controls.Add(button);
            }

            var grid = Grid();
            Tables.Add(grid);
            root.Controls.Add(inputs, 0, 0);
            root.Controls.Add(buttons, 0, 1);
            root.Controls.Add(grid, 0, 2);
            page.Controls.Add(root);
            return grid;
        }

        protected DataRow Row(DataGridView g)
        {
            return g.CurrentRow == null ? null : ((DataRowView)g.CurrentRow.DataBoundItem).Row;
        }
    }
}
