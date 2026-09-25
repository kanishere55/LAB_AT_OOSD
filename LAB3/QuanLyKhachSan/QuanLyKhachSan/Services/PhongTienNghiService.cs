using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    public class PhongTienNghiService
    {
        public DataTable LayPhong()
        {
            return Db.Query("SELECT p.*, k.TenKhuVuc FROM Phong p JOIN KhuVuc k ON p.MaKhuVuc=k.MaKhuVuc ORDER BY p.SoPhong");
        }

        public DataTable LayTienNghi()
        {
            return Db.Query("SELECT t.*, l.TenLoaiTN FROM TienNghi t JOIN LoaiTienNghi l ON t.MaLoaiTN=l.MaLoaiTN ORDER BY t.MaTienNghi");
        }

        public DataTable LayLapDat()
        {
            return Db.Query("SELECT p.*, l.TenLoaiTN FROM PhieuLapDat p JOIN TienNghi t ON p.MaTienNghi=t.MaTienNghi JOIN LoaiTienNghi l ON t.MaLoaiTN=l.MaLoaiTN ORDER BY NgayLap DESC");
        }

        public KetQuaXuLy ThemPhong(string so, string khu, int max, decimal gia)
        {
            if (string.IsNullOrWhiteSpace(so) || string.IsNullOrWhiteSpace(khu) || max <= 0 || gia < 0)
                return KetQuaXuLy.Fail("Thông tin phòng không hợp lệ.");
            try
            {
                Db.Execute("INSERT INTO Phong(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES(@s, @k, @m, @g, N'Trống')",
                    new SqlParameter("@s", so),
                    new SqlParameter("@k", khu),
                    new SqlParameter("@m", max),
                    new SqlParameter("@g", gia));
                return KetQuaXuLy.Ok("Đã thêm phòng.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }

        public KetQuaXuLy ThemTienNghi(string ma, string loai, int stt, string tt)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(loai) || stt <= 0)
                return KetQuaXuLy.Fail("Thông tin tiện nghi không hợp lệ.");
            try
            {
                Db.Execute("INSERT INTO TienNghi VALUES(@m, @l, @s, @t)",
                    new SqlParameter("@m", ma),
                    new SqlParameter("@l", loai),
                    new SqlParameter("@s", stt),
                    new SqlParameter("@t", tt));
                return KetQuaXuLy.Ok("Đã thêm tiện nghi.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }

        public KetQuaXuLy LapDat(string soPhieu, string maTN, string soPhong, DateTime ngay, string tinhTrang, string maNV, string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(soPhieu) || string.IsNullOrWhiteSpace(maTN) || string.IsNullOrWhiteSpace(soPhong) || string.IsNullOrWhiteSpace(tinhTrang) || string.IsNullOrWhiteSpace(maNV))
                return KetQuaXuLy.Fail("Phiếu lắp đặt chưa đủ thông tin.");
            try
            {
                Db.Execute("INSERT INTO PhieuLapDat VALUES(@p, @tn, @ph, @n, @tt, @nv, @g)",
                    new SqlParameter("@p", soPhieu),
                    new SqlParameter("@tn", maTN),
                    new SqlParameter("@ph", soPhong),
                    new SqlParameter("@n", ngay.Date),
                    new SqlParameter("@tt", tinhTrang),
                    new SqlParameter("@nv", maNV),
                    new SqlParameter("@g", ghiChu));

                Db.Execute("UPDATE TienNghi SET TinhTrangHienTai=@tt WHERE MaTienNghi=@m",
                    new SqlParameter("@tt", tinhTrang),
                    new SqlParameter("@m", maTN));

                return KetQuaXuLy.Ok("Đã lập phiếu lắp đặt.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    return KetQuaXuLy.Fail("Thiết bị này đã được lắp cho một phòng khác trong ngày đã chọn.");
                return KetQuaXuLy.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }
    }
}