using System;
using System.Windows.Forms;

namespace QuanLyHoSoBenhAn.Forms
{
    public sealed class FrmLichHen : ModuleForm
    {
        public FrmLichHen() : base("Lịch khám định kỳ • Quyền lợi theo quý")
        {
            var g = Page("Đặt, đổi và hủy hẹn", new[] { F("Mã hẹn", Txt("ma", NewId("LH"), 20)), F("Hồ sơ bệnh án", Combo("hs")), F("Ngày giờ hẹn", Date("ngay", DateTime.Today.AddDays(2).AddHours(8), true)), F("Nội dung", Txt("nd", "Khám sức khỏe định kỳ theo quý", 250)), F("Trạng thái khi cập nhật", Combo("tt", new[] { "Đã hẹn", "Đã xác nhận", "Đã hủy" })) }, new[] { A("Đặt hẹn mới", () => S.DatHen(V("ma"), V("hs"), D("ngay"), V("nd"))), A("Cập nhật hẹn", () => S.SuaHen(V("ma"), D("ngay"), V("nd"), V("tt"))), A("Mã hẹn mới", () => Set("ma", NewId("LH"))), A("Tải lại", () =>
            {
            }) });
            g.CellClick += (s, e) =>
            {
                var r = Row(g);
                if (r == null)
                    return;
                Set("ma", r["Mã hẹn"]);
                Set("hs", r["Mã hồ sơ"]);
                Set("ngay", r["Ngày giờ hẹn"]);
                Set("nd", r["Nội dung"]);
                Set("tt", r["Trạng thái"]);
            };
            Reload = () =>
            {
                Bind("hs", S.HoSo());
                g.DataSource = S.LichHen();
            };
        }
    }
}
