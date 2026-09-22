using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyThuVien.Data;
namespace QuanLyThuVien.Services
{
    public class ThongKeService
    {
        public ThongKeTongHop LayTongHop(DateTime tuNgay, DateTime denNgay)
        {
            DateTime from = tuNgay.Date;
            DateTime to = denNgay.Date;
            if (to < from) { DateTime t = from; from = to; to = t; }
            ThongKeTongHop kq = new ThongKeTongHop();
            kq.LuotSachMuon = Convert.ToInt32(Db.Scalar(@"SELECT COUNT(*) FROM ChiTietPhieuMuon ct
 JOIN PhieuMuon pm ON pm.MaPhieuMuon=ct.MaPhieuMuon
WHERE pm.NgayMuon BETWEEN @Tu AND @Den",
            new SqlParameter("@Tu", from), new SqlParameter("@Den", to)));
            kq.SachQuaHan = Convert.ToInt32(Db.Scalar(@"SELECT COUNT(*) FROM ChiTietPhieuMuon ct
 JOIN PhieuMuon pm ON pm.MaPhieuMuon=ct.MaPhieuMuon
WHERE (ct.NgayTraThucTe IS NULL AND pm.NgayHenTra < CAST(GETDATE() AS date))
 OR (ct.NgayTraThucTe IS NOT NULL AND ct.NgayTraThucTe > pm.NgayHenTra
 AND ct.NgayTraThucTe BETWEEN @Tu AND @Den)",
            new SqlParameter("@Tu", from), new SqlParameter("@Den", to)));
            kq.SachMat = Convert.ToInt32(Db.Scalar(@"SELECT COUNT(*) FROM ChiTietPhieuMuon
 WHERE NgayTraThucTe BETWEEN @Tu AND @Den AND TinhTrangTra LIKE N'%Mất%'",
            new SqlParameter("@Tu", from), new SqlParameter("@Den", to)));
            kq.SachHuHong = Convert.ToInt32(Db.Scalar(@"SELECT COUNT(*) FROM ChiTietPhieuMuon
 WHERE NgayTraThucTe BETWEEN @Tu AND @Den
 AND (TinhTrangTra LIKE N'%Rách%' OR TinhTrangTra LIKE N'%Hư%')",
            new SqlParameter("@Tu", from), new SqlParameter("@Den", to)));
            object tong = Db.Scalar("SELECT ISNULL(SUM(PhiPhat),0) FROM PhieuPhat WHERE NgayPhat BETWEEN @Tu AND @Den",
            new SqlParameter("@Tu", from), new SqlParameter("@Den", to));
            kq.TongPhiPhat = Convert.ToDecimal(tong);
            return kq;
        }
        public DataTable LayChiTietPhat(DateTime tuNgay, DateTime denNgay)
        {
            return Db.Query(@"SELECT pp.MaPhieuPhat, pp.NgayPhat, pm.MaDocGia, ct.MaDauSach,
 s.TenSach, pp.LyDo, pp.PhiPhat, pp.MaNhanVien
 FROM PhieuPhat pp
JOIN ChiTietPhieuMuon ct ON ct.MaChiTiet=pp.MaChiTiet
JOIN PhieuMuon pm ON pm.MaPhieuMuon=ct.MaPhieuMuon
JOIN DauSach s ON s.MaDauSach=ct.MaDauSach
WHERE pp.NgayPhat BETWEEN @Tu AND @Den
ORDER BY pp.NgayPhat DESC, pp.MaPhieuPhat",
            new SqlParameter("@Tu", tuNgay.Date), new SqlParameter("@Den", denNgay.Date));
        }
    }
}
