using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public sealed class FrmPhuTroi : ModuleForm
    {
        public FrmPhuTroi() : base("Phiếu phụ trội")
        {
            Page("Ghi phiếu phụ trội", new[] { F("Số phiếu", Txt("phieu", NewId("PT"), 20)), F("Ngày phụ trội", Date("ngay")), F("Số giờ mỗi nhân viên", Num("gio", 2, 2)), F("Hình thức (hệ số đều 1,5)", Combo("loai", new[] { "Tăng ca", "Ngày lễ", "Ngày nghỉ" })), F("Người ban chấm công lập", Txt("nguoi", "", 120)), F("Danh sách mã NV, mỗi dòng một mã", Txt("ds", "NV001", 1000)) }, new[] { A("Lưu phiếu và chi tiết", () =>
            {
                S.LapPhuTroi(new[] { "SoPhieu", "Ngay", "Gio", "HinhThuc", "Nguoi", "DS" }, V("phieu"), D("ngay"), N("gio"), V("loai"), V("nguoi"), S.DocDanhSach(V("ds"), false));
            }) });
            Page("Nhân viên tham gia", new[] { F("Số phiếu tra cứu", Txt("xphieu", "PT001", 20)) }, new[] { A("Xem chi tiết", () =>
            {
                ;
            }) });
            Reload = () =>
            {
                Tables[0].DataSource = S.DS("PhieuPhuTroi");
                Tables[1].DataSource = S.NguoiThamGia(V("xphieu"));
            };
        }
    }
}
