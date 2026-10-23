using System;
using System.Windows.Forms;

namespace QuanLyHoSoBenhAn.Forms
{
    public sealed class FrmHoanTat : ModuleForm
    {
        public FrmHoanTat() : base("Hoàn tất đợt điều trị • Ghi nhận hồ sơ sau thanh toán")
        {
            var g = Page("Xác nhận thủ tục và hoàn tất", new[] { F("Phiếu khám đang mở", Combo("phieu")), F("Đã làm thủ tục xuất viện", Check("xv")), F("Đã thanh toán viện phí", Check("tt")) }, new[] { A("Lưu xác nhận thủ tục", () => S.ThuTuc(V("phieu"), B("xv"), B("tt"))), A("Hoàn tất và ghi lịch sử", () => S.HoanTat(V("phieu"))), A("Tải lại", () =>
            {
            }) });
            g.CellClick += (s, e) =>
            {
                var r = Row(g);
                if (r == null)
                    return;
                Set("phieu", r["Mã phiếu"]);
                Set("xv", r["Xuất viện"]);
                Set("tt", r["Thanh toán"]);
            };
            Reload = () =>
            {
                Bind("phieu", S.ChonPhieu());
                g.DataSource = S.PhieuKham();
            };
        }
    }
}
