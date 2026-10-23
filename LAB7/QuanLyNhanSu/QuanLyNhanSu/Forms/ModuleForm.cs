using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public class ModuleForm : Form
    {
        protected readonly NhanSuService S = new NhanSuService();
        public readonly Dictionary<string, Control> Fields = new Dictionary<string, Control>();
        public readonly List<DataGridView> Tables = new List<DataGridView>();
        protected readonly TabControl Tabs = new TabControl
        {
            Dock = DockStyle.Fill
        };
        protected readonly Label Status = new Label
        {
            Dock = DockStyle.Bottom,
            Height = 32,
            Padding = new Padding(10, 5, 0, 0),
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
                MessageBox.Show(this, S.ThongBaoLoi(e), "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            g.DataBindingComplete += (a, b) => SizeColumns(g);
            return g;
        }

        public static void SizeColumns(DataGridView g)
        {
            foreach (DataGridViewColumn c in g.Columns)
            {
                var headers = new Dictionary<string, string>
                {
                    {
                        "MaPB",
                        "Mã phòng"
                    },
                    {
                        "TenPB",
                        "Tên phòng ban"
                    },
                    {
                        "MaCV",
                        "Mã chức vụ"
                    },
                    {
                        "TenCV",
                        "Tên chức vụ"
                    },
                    {
                        "MaCa",
                        "Mã ca"
                    },
                    {
                        "TenCa",
                        "Tên ca"
                    },
                    {
                        "GioBatDau",
                        "Giờ bắt đầu"
                    },
                    {
                        "GioKetThuc",
                        "Giờ kết thúc"
                    },
                    {
                        "SoGio",
                        "Số giờ"
                    },
                    {
                        "MaNV",
                        "Mã NV"
                    },
                    {
                        "HoTen",
                        "Họ tên"
                    },
                    {
                        "NgaySinh",
                        "Ngày sinh"
                    },
                    {
                        "DienThoai",
                        "Điện thoại"
                    },
                    {
                        "DiaChi",
                        "Địa chỉ"
                    },
                    {
                        "TrangThai",
                        "Trạng thái"
                    },
                    {
                        "SoQD",
                        "Số QĐ"
                    },
                    {
                        "NgayQD",
                        "Ngày QĐ"
                    },
                    {
                        "TuNgay",
                        "Từ ngày"
                    },
                    {
                        "DenNgay",
                        "Đến ngày"
                    },
                    {
                        "LuongThuViec",
                        "Lương thử việc"
                    },
                    {
                        "DieuKhoan",
                        "Điều khoản"
                    },
                    {
                        "KetQua",
                        "Kết quả"
                    },
                    {
                        "NgayDanhGia",
                        "Ngày đánh giá"
                    },
                    {
                        "SoHD",
                        "Số HĐ"
                    },
                    {
                        "Loai",
                        "Loại"
                    },
                    {
                        "NgayKy",
                        "Ngày ký"
                    },
                    {
                        "SoBH",
                        "Số hồ sơ BH"
                    },
                    {
                        "SoBHYT",
                        "Số BHYT"
                    },
                    {
                        "SoBHXH",
                        "Số BHXH"
                    },
                    {
                        "MucDong",
                        "Mức đóng"
                    },
                    {
                        "TyLeYT",
                        "Tỷ lệ YT"
                    },
                    {
                        "TyLeXH",
                        "Tỷ lệ XH"
                    },
                    {
                        "NgayHieuLuc",
                        "Hiệu lực"
                    },
                    {
                        "LuongCoBan",
                        "Lương cơ bản"
                    },
                    {
                        "PhuCapLuong",
                        "PC lương"
                    },
                    {
                        "PhuCapDocHai",
                        "PC độc hại"
                    },
                    {
                        "PhuCap",
                        "Phụ cấp"
                    },
                    {
                        "MaKH",
                        "Mã KH"
                    },
                    {
                        "DauTuan",
                        "Đầu tuần"
                    },
                    {
                        "NguoiLap",
                        "Người lập"
                    },
                    {
                        "Ngay",
                        "Ngày"
                    },
                    {
                        "GioPhuTroiDuKien",
                        "Giờ PT dự kiến"
                    },
                    {
                        "NguoiCham",
                        "Người chấm"
                    },
                    {
                        "SoPhieu",
                        "Số phiếu"
                    },
                    {
                        "HinhThuc",
                        "Hình thức"
                    },
                    {
                        "NoiDung",
                        "Nội dung"
                    },
                    {
                        "TongTien",
                        "Tổng tiền"
                    },
                    {
                        "NguoiKy",
                        "Người ký"
                    },
                    {
                        "CachXuLy",
                        "Cách xử lý"
                    },
                    {
                        "SoTien",
                        "Số tiền"
                    },
                    {
                        "MaBL",
                        "Mã bảng"
                    },
                    {
                        "Thang",
                        "Tháng"
                    },
                    {
                        "Nam",
                        "Năm"
                    },
                    {
                        "NgayLap",
                        "Ngày lập"
                    },
                    {
                        "NgayCongChuan",
                        "Công chuẩn"
                    },
                    {
                        "GioNgay",
                        "Giờ/ngày"
                    }
                };
                if (headers.ContainsKey(c.DataPropertyName))
                    c.HeaderText = headers[c.DataPropertyName];
                string n = c.HeaderText;
                c.MinimumWidth = 45;
                c.FillWeight = n.Contains("Kết") || n.Contains("Nội dung") || n.Contains("Địa chỉ") || n.Contains("Điều khoản") ? 175 : (n.Contains("Họ tên") || n.Contains("Nhân viên") || n.Contains("Tên") ? 135 : 85);
                if (c.ValueType == typeof(DateTime))
                    c.DefaultCellStyle.Format = "dd/MM/yyyy";
                if (c.ValueType == typeof(decimal))
                    c.DefaultCellStyle.Format = c.DataPropertyName.StartsWith("TyLe") ? "P2"
                        : (c.DataPropertyName.Contains("Gio") || c.DataPropertyName == "NgayCongChuan"
                            || c.HeaderText.StartsWith("Giờ", StringComparison.OrdinalIgnoreCase)) ? "N2" : "N0";
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
