using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public sealed class FrmTuyenDung : ModuleForm
    {
        public FrmTuyenDung() : base("Tuyển dụng - thử việc")
        {
            Page("Tuyển dụng", new[] { F("Mã nhân viên", Txt("nv", NewId("NV"), 20)), F("Họ và tên", Txt("ten", "", 120)), F("Ngày sinh", Date("sinh", new DateTime(2000, 1, 1))), F("Điện thoại", Txt("dt", "", 20)), F("Địa chỉ", Txt("dc", "", 250)), F("Phòng ban tuyển dụng", Combo("pb")), F("Số quyết định", Txt("qd", NewId("TD"), 20)), F("Ngày quyết định", Date("ngay")), F("Bắt đầu thử việc", Date("tu")), F("Kết thúc thử việc", Date("den", DateTime.Today.AddMonths(2))), F("Lương thử việc", Num("luong", 6000000)), F("Điều khoản hai bên", Txt("dk", "", 1000)) }, new[] { A("Lưu tuyển dụng", () =>
            {
                S.TuyenDung(new[] { "MaNV", "HoTen", "NgaySinh", "DienThoai", "DiaChi", "MaPB", "SoQD", "NgayQD", "TuNgay", "DenNgay", "Luong", "DieuKhoan" }, V("nv"), V("ten"), D("sinh"), V("dt"), V("dc"), V("pb"), V("qd"), D("ngay"), D("tu"), D("den"), N("luong"), V("dk"));
            }), A("Tải lại", () =>
            {
                ;
            }) });
            Page("Đánh giá thử việc", new[] { F("Nhân viên", Combo("dgnv")), F("Ngày đánh giá", Date("dgngay")), F("Kết quả", Combo("kq", new[] { "Đạt", "Không đạt" })) }, new[] { A("Ghi kết quả", () =>
            {
                S.DanhGia(new[] { "MaNV", "Ngay", "KetQua" }, V("dgnv"), D("dgngay"), V("kq"));
            }) });
            Reload = () =>
            {
                Bind("pb", S.PhongBan());
                Bind("dgnv", S.NhanVien());
                Tables[0].DataSource = S.DS("NhanVien");
                Tables[1].DataSource = S.DS("QuyetDinhTuyenDung");
            };
        }
    }
}
