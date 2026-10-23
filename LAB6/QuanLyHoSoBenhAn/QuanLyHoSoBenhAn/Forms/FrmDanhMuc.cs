using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyHoSoBenhAn.Forms
{
    public sealed class FrmDanhMuc : ModuleForm
    {
        public FrmDanhMuc() : base("Danh mục • Khoa, bác sĩ, thuốc và xét nghiệm")
        {
            var loaders = new List<Action>();
            string[] kinds =
            {
                "Khoa",
                "BacSi",
                "Thuoc",
                "LoaiXetNghiem"
            };
            string[] titles =
            {
                "Khoa",
                "Bác sĩ",
                "Thuốc",
                "Loại xét nghiệm"
            };
            for (int i = 0; i < kinds.Length; i++)
            {
                string k = kinds[i];
                var fields = new List<Tuple<string, Control>>
                {
                    F("Mã", Txt(k + "m", "", 20)),
                    F("Tên", Txt(k + "t", "", 100))
                };
                if (k != "Khoa")
                    fields.Add(F(k == "BacSi" ? "Chuyên môn" : k == "Thuoc" ? "Đơn vị tính" : "Mô tả", Txt(k + "a", "", k == "LoaiXetNghiem" ? 250 : 100)));
                if (k == "Thuoc")
                    fields.Add(F("Hàm lượng", Txt(k + "b", "", 100)));
                var g = Page(titles[i], fields.ToArray(), new[] { A("Thêm mới", () => S.LuuDanhMuc(k, V(k + "m"), V(k + "t"), k == "Khoa" ? "" : V(k + "a"), k == "Thuoc" ? V(k + "b") : "", false)), A("Lưu chỉnh sửa", () => S.LuuDanhMuc(k, V(k + "m"), V(k + "t"), k == "Khoa" ? "" : V(k + "a"), k == "Thuoc" ? V(k + "b") : "", true)), A("Tải lại", () =>
                {
                }) });
                g.CellClick += (s, e) =>
                {
                    var r = Row(g);
                    if (r == null)
                        return;
                    Set(k + "m", r[0]);
                    Set(k + "t", r[1]);
                    if (k != "Khoa")
                        Set(k + "a", r[2]);
                    if (k == "Thuoc")
                        Set(k + "b", r[3]);
                };
                loaders.Add(() => g.DataSource = S.DanhMuc(k));
            }

            Reload = () =>
            {
                foreach (var l in loaders)
                    l();
            };
        }
    }
}
