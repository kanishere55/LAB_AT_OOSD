using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    public class TraPhongService
    {
        public DataTable LayPhieuDangO()
        {
            return Db.Query(@"SELECT d.SoPhieuDat, k.HoTen, d.NgayNhanThucTe, d.NgayTraDuKien 
                              FROM PhieuDatPhong d 
                              JOIN KhachHang k ON d.MaKhach=k.MaKhach 
                              WHERE d.TrangThai=N'Đang ở' 
                              ORDER BY d.SoPhieuDat");
        }

        public DataTable LayPhongTheoPhieu(string so)
        {
            return Db.Query(@"SELECT c.SoPhong, p.DonGiaNgay 
                              FROM ChiTietDatPhong c 
                              JOIN Phong p ON c.SoPhong=p.SoPhong 
                              WHERE c.SoPhieuDat=@s",
                              new SqlParameter("@s", so));
        }

        public DataTable LayTienNghiPhong(string phong)
        {
            return Db.Query(@"SELECT TOP 100 p.MaTienNghi, l.TenLoaiTN, t.TinhTrangHienTai 
                              FROM PhieuLapDat p 
                              JOIN TienNghi t ON p.MaTienNghi=t.MaTienNghi 
                              JOIN LoaiTienNghi l ON t.MaLoaiTN=l.MaLoaiTN 
                              WHERE p.SoPhong=@p 
                              ORDER BY p.NgayLap DESC",
                              new SqlParameter("@p", phong));
        }

        public DataTable LayQuyDinh()
        {
            return Db.Query(@"SELECT q.*, l.TenLoaiTN 
                              FROM QuyDinhDenBu q 
                              JOIN LoaiTienNghi l ON q.MaLoaiTN=l.MaLoaiTN 
                              ORDER BY l.TenLoaiTN, q.MucDoThietHai");
        }

        public DataTable LayHoaDon()
        {
            return Db.Query(@"SELECT h.*, k.HoTen 
                              FROM HoaDon h 
                              JOIN PhieuDatPhong d ON h.SoPhieuDat=d.SoPhieuDat 
                              JOIN KhachHang k ON d.MaKhach=k.MaKhach 
                              ORDER BY h.NgayLap DESC");
        }

        public KetQuaXuLy LapPhieuDenBu(string soDB, string soDat, string phong, DateTime ngay, string maNV, List<DenBuItem> ds)
        {
            if (string.IsNullOrWhiteSpace(soDB) || string.IsNullOrWhiteSpace(soDat) || string.IsNullOrWhiteSpace(phong) || string.IsNullOrWhiteSpace(maNV) || ds == null || ds.Count == 0)
                return KetQuaXuLy.Fail("Phiếu đền bù chưa đủ thông tin.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    decimal tong = 0;
                    foreach (var x in ds)
                    {
                        if (x.SoTien < 0) return KetQuaXuLy.Fail("Mức đền bù không hợp lệ.");
                        tong += x.SoTien;
                    }

                    var h = new SqlCommand("INSERT INTO PhieuDenBu VALUES(@so, @d, @p, @n, @nv, @t)", cn, tx);
                    h.Parameters.AddWithValue("@so", soDB);
                    h.Parameters.AddWithValue("@d", soDat);
                    h.Parameters.AddWithValue("@p", phong);
                    h.Parameters.AddWithValue("@n", ngay);
                    h.Parameters.AddWithValue("@nv", maNV);
                    h.Parameters.AddWithValue("@t", tong);
                    h.ExecuteNonQuery();

                    foreach (var x in ds)
                    {
                        var c = new SqlCommand("INSERT INTO ChiTietPhieuDenBu VALUES(@so, @tn, @m, @t)", cn, tx);
                        c.Parameters.AddWithValue("@so", soDB);
                        c.Parameters.AddWithValue("@tn", x.MaTienNghi);
                        c.Parameters.AddWithValue("@m", x.MucDoThietHai);
                        c.Parameters.AddWithValue("@t", x.SoTien);
                        c.ExecuteNonQuery();
                    }

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập phiếu đền bù.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail(ex.Message);
                }
            }
        }

        public KetQuaXuLy LapHoaDon(string soHD, string soDat, DateTime ngay, string maNV, int soNgay)
        {
            if (string.IsNullOrWhiteSpace(soHD) || string.IsNullOrWhiteSpace(soDat) || string.IsNullOrWhiteSpace(maNV) || soNgay <= 0)
                return KetQuaXuLy.Fail("Thông tin hóa đơn chưa hợp lệ.");
            try
            {
                decimal phong = Convert.ToDecimal(Db.Scalar(@"SELECT ISNULL(SUM(p.DonGiaNgay),0) 
                                                              FROM ChiTietDatPhong c 
                                                              JOIN Phong p ON c.SoPhong=p.SoPhong 
                                                              WHERE c.SoPhieuDat=@s",
                                                              new SqlParameter("@s", soDat))) * soNgay;

                decimal dv = Convert.ToDecimal(Db.Scalar(@"SELECT ISNULL(SUM(c.ThanhTien),0) 
                                                          FROM PhieuSuDungDV h 
                                                          JOIN ChiTietPhieuSuDungDV c ON h.SoPhieuSDDV=c.SoPhieuSDDV 
                                                          WHERE h.SoPhieuDat=@s",
                                                          new SqlParameter("@s", soDat)));

                Db.Execute(@"INSERT INTO HoaDon(SoHoaDon, SoPhieuDat, NgayLap, MaNV, SoNgayTinhTien, TienPhong, TienDichVu, TrangThai) 
                             VALUES(@h, @s, @n, @nv, @ng, @p, @d, N'Chưa thanh toán')",
                             new SqlParameter("@h", soHD),
                             new SqlParameter("@s", soDat),
                             new SqlParameter("@n", ngay),
                             new SqlParameter("@nv", maNV),
                             new SqlParameter("@ng", soNgay),
                             new SqlParameter("@p", phong),
                             new SqlParameter("@d", dv));

                return KetQuaXuLy.Ok("Đã lập hóa đơn tiền phòng và dịch vụ. Số ngày tính tiền là dữ liệu nhân viên xác nhận vì đề gốc không quy định cách làm tròn ngày lưu trú.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }

        public KetQuaXuLy ThanhToan(string maTT, string soHD, DateTime ngay, string hinhThuc, decimal tien)
        {
            if (string.IsNullOrWhiteSpace(maTT) || string.IsNullOrWhiteSpace(soHD) || string.IsNullOrWhiteSpace(hinhThuc) || tien <= 0)
                return KetQuaXuLy.Fail("Thông tin thanh toán không hợp lệ.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var q = new SqlCommand("SELECT TongTien FROM HoaDon WHERE SoHoaDon=@h", cn, tx);
                    q.Parameters.AddWithValue("@h", soHD);
                    object o = q.ExecuteScalar();
                    if (o == null) return KetQuaXuLy.Fail("Không tìm thấy hóa đơn.");
                    decimal tong = Convert.ToDecimal(o);

                    var paid = new SqlCommand("SELECT ISNULL(SUM(SoTien),0) FROM ThanhToan WHERE SoHoaDon=@h", cn, tx);
                    paid.Parameters.AddWithValue("@h", soHD);
                    decimal da = Convert.ToDecimal(paid.ExecuteScalar());

                    if (da + tien > tong)
                        return KetQuaXuLy.Fail("Số tiền thanh toán vượt số còn phải trả.");

                    var i = new SqlCommand("INSERT INTO ThanhToan VALUES(@m, @h, @n, @ht, @t)", cn, tx);
                    i.Parameters.AddWithValue("@m", maTT);
                    i.Parameters.AddWithValue("@h", soHD);
                    i.Parameters.AddWithValue("@n", ngay);
                    i.Parameters.AddWithValue("@ht", hinhThuc);
                    i.Parameters.AddWithValue("@t", tien);
                    i.ExecuteNonQuery();

                    if (da + tien == tong)
                    {
                        var u = new SqlCommand("UPDATE HoaDon SET TrangThai=N'Đã thanh toán' WHERE SoHoaDon=@h", cn, tx);
                        u.Parameters.AddWithValue("@h", soHD);
                        u.ExecuteNonQuery();
                    }

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã ghi nhận thanh toán bằng " + hinhThuc + ".");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail(ex.Message);
                }
            }
        }

        public KetQuaXuLy TraPhong(string soDat, DateTime ngayTra)
        {
            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var q = new SqlCommand("SELECT h.SoHoaDon, h.TrangThai FROM HoaDon h WHERE h.SoPhieuDat=@s", cn, tx);
                    q.Parameters.AddWithValue("@s", soDat);
                    string soHD = null, tt = null;
                    using (var rd = q.ExecuteReader())
                    {
                        if (!rd.Read())
                            return KetQuaXuLy.Fail("Chưa lập hóa đơn cho phiếu đặt phòng.");
                        soHD = Convert.ToString(rd[0]);
                        tt = Convert.ToString(rd[1]);
                    }

                    if (tt != "Đã thanh toán")
                        return KetQuaXuLy.Fail("Hóa đơn chưa thanh toán đủ.");

                    var u1 = new SqlCommand("UPDATE PhieuDatPhong SET TrangThai=N'Đã trả', NgayTraThucTe=@n WHERE SoPhieuDat=@s", cn, tx);
                    u1.Parameters.AddWithValue("@n", ngayTra);
                    u1.Parameters.AddWithValue("@s", soDat);
                    u1.ExecuteNonQuery();

                    var u2 = new SqlCommand("UPDATE Phong SET TrangThai=N'Trống' WHERE SoPhong IN(SELECT SoPhong FROM ChiTietDatPhong WHERE SoPhieuDat=@s)", cn, tx);
                    u2.Parameters.AddWithValue("@s", soDat);
                    u2.ExecuteNonQuery();

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã hoàn tất trả phòng.");
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