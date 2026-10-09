using System.Data;
using System.Windows.Forms;
using QuanLyCongTyDuLich.Services;

namespace QuanLyCongTyDuLich.Forms
{
    /// <summary>Tiện ích dùng chung cho các Form.</summary>
    internal static class FormHelper
    {
        public static void Nap(ComboBox cbo, DataTable dt, string display, string value)
        {
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = dt;
        }

        public static string Gia(ComboBox cbo)
        {
            return cbo.SelectedValue == null ? "" : cbo.SelectedValue.ToString();
        }

        public static string O(DataGridView dgv, string cot)
        {
            return dgv.CurrentRow == null || dgv.CurrentRow.IsNewRow || !dgv.Columns.Contains(cot)
                ? "" : System.Convert.ToString(dgv.CurrentRow.Cells[cot].Value);
        }

        public static void DinhDangBang(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var grid = (DataGridView)sender;
            var booleanColumns = new System.Collections.Generic.List<DataGridViewColumn>();
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (column.ValueType == typeof(System.DateTime)) column.DefaultCellStyle.Format = "dd/MM/yyyy";
                if (column.ValueType == typeof(decimal)) column.DefaultCellStyle.Format = "0.##";
                if (column is DataGridViewCheckBoxColumn) booleanColumns.Add(column);
            }
            // Hiển thị True/False như bảng trong ảnh mẫu của đề.
            foreach (var column in booleanColumns)
            {
                int index = column.Index;
                var replacement = new DataGridViewTextBoxColumn { Name = column.Name, HeaderText = column.HeaderText,
                    DataPropertyName = column.DataPropertyName, ReadOnly = true, MinimumWidth = 65 };
                grid.Columns.Remove(column);
                grid.Columns.Insert(index, replacement);
            }
            CanCotTheoNoiDung(grid);
        }

        public static void KichThuocBangThayDoi(object sender, System.EventArgs e)
        {
            CanCotTheoNoiDung((DataGridView)sender);
        }

        public static void DuLieuOThayDoi(object sender, DataGridViewCellEventArgs e)
        {
            CanCotTheoNoiDung((DataGridView)sender);
        }

        // Cột mã/số gọn, cột tên và mô tả đủ chỗ. Không ép mọi cột bằng nhau.
        private static void CanCotTheoNoiDung(DataGridView grid)
        {
            if (grid.Columns.Count == 0 || grid.ClientSize.Width <= 0) return;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.DefaultCellStyle.Padding = new Padding(4, 3, 4, 3);

            var columns = new System.Collections.Generic.List<DataGridViewColumn>();
            var desired = new System.Collections.Generic.List<int>();
            int sum = 0, minimumSum = 0;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (!column.Visible) continue;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                int header = TextRenderer.MeasureText(column.HeaderText, grid.ColumnHeadersDefaultCellStyle.Font ?? grid.Font).Width + 32;
                column.MinimumWidth = System.Math.Max(65, header);
                // Đo với nội dung trên một dòng rồi bật wrap lại khi chia độ rộng.
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                int width = System.Math.Max(column.MinimumWidth, System.Math.Min(420, column.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true) + 8));
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columns.Add(column); desired.Add(width); sum += width; minimumSum += column.MinimumWidth;
            }
            if (columns.Count == 0) return;
            int available = grid.ClientSize.Width - grid.RowHeadersWidth - SystemInformation.VerticalScrollBarWidth - 3;
            int room = System.Math.Max(0, available - minimumSum);
            int desiredRoom = System.Math.Max(1, sum - minimumSum);
            for (int i = 0; i < columns.Count; i++)
            {
                int extra = desired[i] - columns[i].MinimumWidth;
                columns[i].Width = columns[i].MinimumWidth + (int)((long)room * extra / desiredRoom);
            }
            // Nếu mọi cột đều ngắn thì tận dụng phần trống còn lại.
            int used = 0;
            foreach (var column in columns) used += column.Width;
            if (used < available) columns[columns.Count - 1].Width += available - used;
            // Tính lại chiều cao sau khi TẤT CẢ cột đã có độ rộng cuối cùng.
            // Khi sửa nhiều ô liên tiếp, chiều cao cũ có thể còn ứng với độ rộng trước đó.
            grid.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        public static void LoiNhapBang(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
            MessageBox.Show("Ngày sinh phải đúng định dạng dd/MM/yyyy; có thể để trống nếu chưa có thông tin.",
                "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>Hiển thị kết quả; trả về true nếu thành công.</summary>
        public static bool Bao(KetQuaXuLy k)
        {
            MessageBox.Show(k.ThongBao, k.ThanhCong ? "Thông báo" : "Không thực hiện được",
                MessageBoxButtons.OK, k.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            return k.ThanhCong;
        }
    }
}
