using System;
using System.Collections.Generic;
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
    }
}
