using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangOnline
{
    internal static class FormHelper
    {
        public static void Run(Form form, Action action)
        {
            try { action(); }
            catch (Exception ex)
            {
                MessageBox.Show(form, ex.Message, "e-SHOPPING", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void FormatGrid(DataGridView grid)
        {
            var headers = new Dictionary<string, string> {
                { "MaSP", "Mã SP" }, { "TenSP", "Tên sản phẩm" }, { "NhaSanXuat", "Nhà sản xuất" },
                { "DonGia", "Đơn giá (đ)" }, { "TrangThai", "Tình trạng" },
                { "SoLuong", "Số lượng" }, { "ThanhTien", "Thành tiền (đ)" }
            };
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (headers.ContainsKey(column.Name)) column.HeaderText = headers[column.Name];
                if (column.Name == "DonGia" || column.Name == "ThanhTien")
                    column.DefaultCellStyle.Format = "N0";
                if (column.Name == "TenSP") column.FillWeight = 200;
                if (column.Name == "MaSP" || column.Name == "SoLuong") column.FillWeight = 65;
            }
        }
        public static void Capture(Form form, string path)
        {
            form.ShowInTaskbar = false;
            form.Opacity = 0;
            form.Show();
            Application.DoEvents();
            using (var image = new Bitmap(form.Width, form.Height))
            {
                form.DrawToBitmap(image, new Rectangle(0, 0, form.Width, form.Height));
                image.Save(path);
            }
            form.Hide();
        }
    }
}
