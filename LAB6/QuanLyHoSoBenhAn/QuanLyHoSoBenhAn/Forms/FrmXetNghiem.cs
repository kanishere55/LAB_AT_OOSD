using System;
using System.Windows.Forms;

namespace QuanLyHoSoBenhAn.Forms
{
    public sealed class FrmXetNghiem : ModuleForm
    {
        public FrmXetNghiem() : base("Xét nghiệm • Chỉ định và kết quả")
        {
            var a = Page("Chỉ định xét nghiệm", new[] { F("Mã chỉ định", Txt("ma", NewId("CD"), 20)), F("Phiếu khám đang mở", Combo("phieu")), F("Loại xét nghiệm", Combo("loai")), F("Ngày giờ chỉ định", Date("ngay", null, true)) }, new[] { A("Lập chỉ định", () => S.ChiDinh(V("ma"), V("phieu"), V("loai"), D("ngay"))), A("Mã chỉ định mới", () => Set("ma", NewId("CD"))), A("Tải lại", () =>
            {
            }) });
            var b = Page("Ghi kết quả", new[] { F("Mã chỉ định (chọn từ bảng)", Txt("cd", "", 20)), F("Ngày giờ trả kết quả", Date("tra", null, true)), F("Nội dung kết quả", Txt("kq", "", 1000)) }, new[] { A("Lưu kết quả", () => S.KetQua(V("cd"), D("tra"), V("kq"))), A("Tải lại", () =>
            {
            }) });
            EventHandler<DataGridViewCellEventArgs> select = (s, e) =>
            {
                var r = Row((DataGridView)s);
                if (r == null)
                    return;
                Set("cd", r["Mã chỉ định"]);
                Set("kq", r["Kết quả"]);
                if (r["Ngày kết quả"] != DBNull.Value)
                    Set("tra", r["Ngày kết quả"]);
                Tabs.SelectedIndex = 1;
            };
            a.CellClick += new DataGridViewCellEventHandler(select);
            b.CellClick += new DataGridViewCellEventHandler(select);
            Reload = () =>
            {
                Bind("phieu", S.ChonPhieu());
                Bind("loai", S.DanhMuc("LoaiXetNghiem"));
                a.DataSource = S.XetNghiem();
                b.DataSource = S.XetNghiem();
            };
        }
    }
}
