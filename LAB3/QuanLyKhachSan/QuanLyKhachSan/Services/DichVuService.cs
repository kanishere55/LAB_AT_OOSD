using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    public class DichVuService
    {
        public DataTable LayPhieuDangO()
        {
            return Db.Query(@"SELECT d.SoPhieuDat, k.HoTen, c.SoPhong 
                              FROM PhieuDatPhong d 
                              JOIN KhachHang k ON d.MaKhach=k.MaKhach 
                              JOIN ChiTietDatPhong c ON d.SoPhieuDat=c.SoPhieuDat 
                              WHERE d.TrangThai=N'Đang ở' 
                              ORDER BY d.SoPhieuDat, c.SoPhong");
        }

        public DataTable LayDichVu()
        {
            return Db.Query("SELECT * FROM DichVu ORDER BY MaDV");
        }

        public DataTable LayLichSu(string so)
        {
            return Db.Query(@"SELECT p.SoPhieuSDDV, p.SoPhong, p.NgaySuDung, d.TenDV, c.SoLuong, c.DonGia, c.ThanhTien 
                              FROM PhieuSuDungDV p 
                              JOIN ChiTietPhieuSuDungDV c ON p.SoPhieuSDDV=c.SoPhieuSDDV 
                              JOIN DichVu d ON c.MaDV=d.MaDV 
                              WHERE p.SoPhieuDat=@s 
                              ORDER BY p.NgaySuDung, p.SoPhong, d.TenDV",
                              new SqlParameter("@s", so));
        }

        public KetQuaXuLy GhiNhan(string soPhieuDat, string soPhong, DateTime ngay, string maNV, string maDV, int soLuong)
        {
            if (string.IsNullOrWhiteSpace(soPhieuDat) || string.IsNullOrWhiteSpace(soPhong) || string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(maDV) || soLuong <= 0)
                return KetQuaXuLy.Fail("Thông tin sử dụng dịch vụ không hợp lệ.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var st = new SqlCommand("SELECT TrangThai FROM PhieuDatPhong WHERE SoPhieuDat=@s", cn, tx);
                    st.Parameters.AddWithValue("@s", soPhieuDat);
                    if (Convert.ToString(st.ExecuteScalar()) != "Đang ở")
                        return KetQuaXuLy.Fail("Chỉ ghi nhận dịch vụ cho phiếu đang lưu trú.");

                    var g = new SqlCommand("SELECT DonGia FROM DichVu WHERE MaDV=@d", cn, tx);
                    g.Parameters.AddWithValue("@d", maDV);
                    object og = g.ExecuteScalar();
                    if (og == null) return KetQuaXuLy.Fail("Không tìm thấy dịch vụ.");
                    decimal gia = Convert.ToDecimal(og);

                    var f = new SqlCommand("SELECT SoPhieuSDDV FROM PhieuSuDungDV WHERE SoPhieuDat=@s AND SoPhong=@p AND NgaySuDung=@n", cn, tx);
                    f.Parameters.AddWithValue("@s", soPhieuDat);
                    f.Parameters.AddWithValue("@p", soPhong);
                    f.Parameters.AddWithValue("@n", ngay.Date);
                    string so = Convert.ToString(f.ExecuteScalar());

                    if (string.IsNullOrWhiteSpace(so))
                    {
                        so = "SD" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        var h = new SqlCommand("INSERT INTO PhieuSuDungDV VALUES(@so, @s, @p, @n, @nv)", cn, tx);
                        h.Parameters.AddWithValue("@so", so);
                        h.Parameters.AddWithValue("@s", soPhieuDat);
                        h.Parameters.AddWithValue("@p", soPhong);
                        h.Parameters.AddWithValue("@n", ngay.Date);
                        h.Parameters.AddWithValue("@nv", maNV);
                        h.ExecuteNonQuery();
                    }

                    var chk = new SqlCommand("SELECT COUNT(*) FROM ChiTietPhieuSuDungDV WHERE SoPhieuSDDV=@so AND MaDV=@d", cn, tx);
                    chk.Parameters.AddWithValue("@so", so);
                    chk.Parameters.AddWithValue("@d", maDV);

                    if (Convert.ToInt32(chk.ExecuteScalar()) > 0)
                    {
                        var u = new SqlCommand("UPDATE ChiTietPhieuSuDungDV SET SoLuong=SoLuong+@sl, DonGia=@g WHERE SoPhieuSDDV=@so AND MaDV=@d", cn, tx);
                        u.Parameters.AddWithValue("@sl", soLuong);
                        u.Parameters.AddWithValue("@g", gia);
                        u.Parameters.AddWithValue("@so", so);
                        u.Parameters.AddWithValue("@d", maDV);
                        u.ExecuteNonQuery();
                    }
                    else
                    {
                        var i = new SqlCommand("INSERT INTO ChiTietPhieuSuDungDV VALUES(@so, @d, @sl, @g)", cn, tx);
                        i.Parameters.AddWithValue("@so", so);
                        i.Parameters.AddWithValue("@d", maDV);
                        i.Parameters.AddWithValue("@sl", soLuong);
                        i.Parameters.AddWithValue("@g", gia);
                        i.ExecuteNonQuery();
                    }

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã ghi nhận dịch vụ. Nếu cùng dịch vụ được dùng nhiều lần trong ngày, số lượng được cộng dồn trong cùng phiếu.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail(ex.Message);
                }
            }
        }
    }
}