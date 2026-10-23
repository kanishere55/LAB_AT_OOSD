using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyHoSoBenhAn.Data;

namespace QuanLyHoSoBenhAn.Services
{
    public sealed class BenhNhanInput
    {
        public string Ma, HoTen, DiaChi, DienThoai, MaDangKy, MaHoSo, MaThu;
        public DateTime NgaySinh, Ngay;
        public byte[] Anh;
        public decimal SoTien;
    }

    public sealed class HoSoService
    {
        static SqlParameter P(string k, object v)
        {
            return Db.P(k, v);
        }

        public static void Required(string value, string label)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Cần nhập " + label + ".");
        }

        public void DangKy(BenhNhanInput b)
        {
            Required(b.Ma, "mã bệnh nhân");
            Required(b.MaHoSo, "mã hồ sơ");
            Required(b.MaDangKy, "mã đăng ký");
            Required(b.MaThu, "mã thu");
            Db.Procedure("DangKyBenhNhan", P("MaBenhNhan", b.Ma), P("HoTen", b.HoTen), P("NgaySinh", b.NgaySinh), P("DiaChi", b.DiaChi), P("DienThoai", b.DienThoai), new SqlParameter("@Anh3x4", SqlDbType.VarBinary, -1) { Value = (object)b.Anh ?? DBNull.Value }, P("MaDangKy", b.MaDangKy), P("MaHoSo", b.MaHoSo), P("MaThuLePhi", b.MaThu), P("Ngay", b.Ngay.Date), P("SoTien", b.SoTien));
        }

        public void SuaBenhNhan(string ma, string ten, DateTime sinh, string dc, string dt, byte[] anh)
        {
            Required(ten, "họ tên");
            Required(dc, "địa chỉ");
            if (sinh.Date > DateTime.Today || dt.Length < 9)
                throw new ArgumentException("Ngày sinh hoặc điện thoại không hợp lệ.");
            int n = Db.Execute("UPDATE BenhNhan SET HoTen=@t,NgaySinh=@n,DiaChi=@d,DienThoai=@s,Anh3x4=COALESCE(@a,Anh3x4) WHERE MaBenhNhan=@m", P("t", ten), P("n", sinh.Date), P("d", dc), P("s", dt), new SqlParameter("@a", SqlDbType.VarBinary, -1) { Value = (object)anh ?? DBNull.Value }, P("m", ma));
            if (n == 0)
                throw new ArgumentException("Không tìm thấy bệnh nhân.");
        }

        public DataTable BenhNhan(string q = "")
        {
            return Db.Query("SELECT b.MaBenhNhan [Mã BN],b.HoTen [Họ tên],b.NgaySinh [Ngày sinh],b.DiaChi [Địa chỉ],b.DienThoai [Điện thoại],h.MaHoSo [Mã hồ sơ],h.NgayCap [Ngày cấp] FROM BenhNhan b LEFT JOIN HoSoBenhAn h ON h.MaBenhNhan=b.MaBenhNhan WHERE b.MaBenhNhan=@q OR h.MaHoSo=@q OR b.HoTen LIKE N'%'+@q+N'%' OR b.DienThoai LIKE '%'+@q+'%' ORDER BY b.MaBenhNhan", P("q", q));
        }

        public byte[] Anh(string ma)
        {
            var t = Db.Query("SELECT Anh3x4 FROM BenhNhan WHERE MaBenhNhan=@m", P("m", ma));
            return t.Rows.Count == 0 ? null : (byte[])t.Rows[0][0];
        }

        public void ThuPhi(string ma, string bn, DateTime tu, decimal tien)
        {
            Required(ma, "mã thu");
            Db.Procedure("ThuLePhiNam", P("MaThuLePhi", ma), P("MaBenhNhan", bn), P("TuNgay", tu.Date), P("SoTien", tien));
        }

        public DataTable LePhi()
        {
            return Db.Query("SELECT p.MaThuLePhi [Mã thu],p.MaBenhNhan [Mã BN],b.HoTen [Họ tên],p.NgayThu [Ngày thu],p.SoTien [Số tiền],p.TuNgay [Từ ngày],p.DenNgay [Đến ngày] FROM PhieuThuLePhi p JOIN BenhNhan b ON b.MaBenhNhan=p.MaBenhNhan ORDER BY p.NgayThu DESC");
        }

        public DataTable HoSo()
        {
            return Db.Query("SELECT h.MaHoSo Ma,b.HoTen+N' - '+h.MaHoSo Ten FROM HoSoBenhAn h JOIN BenhNhan b ON b.MaBenhNhan=h.MaBenhNhan ORDER BY h.MaHoSo");
        }

        public DataTable DanhMuc(string kind)
        {
            switch (kind)
            {
                case "Khoa":
                    return Db.Query("SELECT MaKhoa Ma,TenKhoa Ten FROM Khoa ORDER BY MaKhoa");
                case "BacSi":
                    return Db.Query("SELECT MaBacSi Ma,HoTen Ten,ChuyenMon FROM BacSi ORDER BY MaBacSi");
                case "Thuoc":
                    return Db.Query("SELECT MaThuoc Ma,TenThuoc Ten,DonViTinh,HamLuong FROM Thuoc ORDER BY MaThuoc");
                case "LoaiXetNghiem":
                    return Db.Query("SELECT MaXetNghiem Ma,TenXetNghiem Ten,MoTa FROM LoaiXetNghiem ORDER BY MaXetNghiem");
                default:
                    throw new ArgumentException("Danh mục không hợp lệ.");
            }
        }

        public void LuuDanhMuc(string kind, string ma, string ten, string a, string b, bool sua)
        {
            Required(ma, "mã");
            Required(ten, "tên");
            string sql;
            switch (kind)
            {
                case "Khoa":
                    sql = sua ? "UPDATE Khoa SET TenKhoa=@t WHERE MaKhoa=@m" : "INSERT Khoa VALUES(@m,@t)";
                    break;
                case "BacSi":
                    sql = sua ? "UPDATE BacSi SET HoTen=@t,ChuyenMon=@a WHERE MaBacSi=@m" : "INSERT BacSi VALUES(@m,@t,@a)";
                    break;
                case "Thuoc":
                    Required(a, "đơn vị tính");
                    sql = sua ? "UPDATE Thuoc SET TenThuoc=@t,DonViTinh=@a,HamLuong=@b WHERE MaThuoc=@m" : "INSERT Thuoc VALUES(@m,@t,@a,@b)";
                    break;
                case "LoaiXetNghiem":
                    sql = sua ? "UPDATE LoaiXetNghiem SET TenXetNghiem=@t,MoTa=@a WHERE MaXetNghiem=@m" : "INSERT LoaiXetNghiem VALUES(@m,@t,@a)";
                    break;
                default:
                    throw new ArgumentException("Danh mục không hợp lệ.");
            }

            if (Db.Execute(sql, P("m", ma), P("t", ten), P("a", a), P("b", b)) == 0)
                throw new ArgumentException("Mã cần sửa không tồn tại.");
        }

        public DataTable PhieuKham(bool mo = false)
        {
            return Db.Query("SELECT p.MaPhieuKham [Mã phiếu],p.MaHoSo [Mã hồ sơ],b.HoTen [Bệnh nhân],p.MaBacSi [Mã BS],p.MaKhoa [Mã khoa],p.NgayGioKham [Ngày khám],p.LoaiKham [Loại khám],p.PhiKham [Phí khám],p.KetLuan [Kết luận],p.DaXuatVien [Xuất viện],p.DaThanhToan [Thanh toán],p.DaHoanTat [Hoàn tất] FROM PhieuKham p JOIN HoSoBenhAn h ON p.MaHoSo=h.MaHoSo JOIN BenhNhan b ON h.MaBenhNhan=b.MaBenhNhan WHERE @mo=0 OR p.DaHoanTat=0 ORDER BY p.NgayGioKham DESC", P("mo", mo));
        }

        public DataTable ChonPhieu()
        {
            return Db.Query("SELECT MaPhieuKham Ma,MaPhieuKham+N' - '+MaHoSo Ten FROM PhieuKham WHERE DaHoanTat=0 ORDER BY NgayGioKham DESC");
        }

        public DataTable ChiTietKham(string ma)
        {
            return Db.Query("SELECT * FROM PhieuKham WHERE MaPhieuKham=@m", P("m", ma));
        }

        public void LapPhieu(string ma, string hs, string bs, string khoa, DateTime ngay, string loai, string hen, decimal phi)
        {
            Required(ma, "mã phiếu khám");
            Db.Procedure("LapPhieuKham", P("MaPhieuKham", ma), P("MaHoSo", hs), P("MaBacSi", bs), P("MaKhoa", khoa), P("NgayGioKham", ngay), P("LoaiKham", loai), P("MaHen", string.IsNullOrWhiteSpace(hen) ? null : hen), P("PhiKham", phi));
        }

        public void GhiKham(string ma, string tc, decimal? nhiet, string ha, string kl, string db, string pu, string hq)
        {
            Db.Procedure("GhiNhanKham", P("MaPhieuKham", ma), P("TrieuChung", tc), P("ThanNhiet", nhiet), P("HuyetAp", ha), P("KetLuan", kl), P("DienBien", db), P("PhanUngPhu", pu), P("HieuQuaDieuTri", hq));
        }

        public DataTable XetNghiem(string phieu = "")
        {
            return Db.Query("SELECT x.MaChiDinh [Mã chỉ định],x.MaPhieuKham [Mã phiếu],l.TenXetNghiem [Loại xét nghiệm],x.NgayChiDinh [Ngày chỉ định],x.TrangThai [Trạng thái],x.NgayKetQua [Ngày kết quả],x.KetQua [Kết quả] FROM ChiDinhXetNghiem x JOIN LoaiXetNghiem l ON l.MaXetNghiem=x.MaXetNghiem WHERE @p='' OR x.MaPhieuKham=@p ORDER BY x.NgayChiDinh DESC", P("p", phieu));
        }

        public void ChiDinh(string ma, string phieu, string loai, DateTime ngay)
        {
            Required(ma, "mã chỉ định");
            Db.Procedure("LapChiDinh", P("MaChiDinh", ma), P("MaPhieuKham", phieu), P("MaXetNghiem", loai), P("NgayChiDinh", ngay));
        }

        public void KetQua(string ma, DateTime ngay, string kq)
        {
            Required(kq, "kết quả xét nghiệm");
            Db.Procedure("GhiKetQua", P("MaChiDinh", ma), P("NgayKetQua", ngay), P("KetQua", kq));
        }

        public static DataTable DongToa()
        {
            var t = new DataTable();
            t.Columns.Add("SoThuTu", typeof(int));
            t.Columns.Add("MaThuoc", typeof(string));
            t.Columns.Add("SoLuong", typeof(int));
            t.Columns.Add("LieuDung", typeof(string));
            t.Columns.Add("CachDung", typeof(string));
            return t;
        }

        public void LapToa(string ma, string phieu, string bs, string dan, DataTable ds)
        {
            Required(ma, "mã toa");
            Db.Procedure("LapToaThuoc", P("MaToa", ma), P("MaPhieuKham", phieu), P("MaBacSi", bs), P("LoiDan", dan), new SqlParameter("@ChiTiet", SqlDbType.Structured) { TypeName = "dbo.DongToa", Value = ds });
        }

        public DataTable Toa(string hs = "")
        {
            return Db.Query("SELECT t.MaToa [Mã toa],t.MaPhieuKham [Mã phiếu],p.MaHoSo [Mã hồ sơ],t.MaBacSi [Mã BS],t.NgayLap [Ngày lập],t.LoiDan [Lời dặn] FROM ToaThuoc t JOIN PhieuKham p ON p.MaPhieuKham=t.MaPhieuKham WHERE @h='' OR p.MaHoSo=@h ORDER BY t.NgayLap DESC", P("h", hs));
        }

        public DataTable ChiTietToa(string ma)
        {
            return Db.Query("SELECT c.SoThuTu [STT],t.TenThuoc [Tên thuốc],t.DonViTinh [ĐVT],c.SoLuong [Số lượng],c.LieuDung [Liều dùng],c.CachDung [Cách dùng] FROM ChiTietToaThuoc c JOIN Thuoc t ON t.MaThuoc=c.MaThuoc WHERE c.MaToa=@m ORDER BY c.SoThuTu", P("m", ma));
        }

        public string XuatToa(string ma)
        {
            var t = Db.Query("SELECT t.MaToa,b.HoTen,b.NgaySinh,p.MaHoSo,p.NgayGioKham,p.KetLuan,bs.HoTen BacSi,t.LoiDan FROM ToaThuoc t JOIN PhieuKham p ON p.MaPhieuKham=t.MaPhieuKham JOIN HoSoBenhAn h ON h.MaHoSo=p.MaHoSo JOIN BenhNhan b ON b.MaBenhNhan=h.MaBenhNhan JOIN BacSi bs ON bs.MaBacSi=t.MaBacSi WHERE MaToa=@m", P("m", ma));
            if (t.Rows.Count == 0)
                throw new ArgumentException("Không tìm thấy toa đã lưu.");
            var r = t.Rows[0];
            var s = new System.Text.StringBuilder();
            s.AppendLine("TOA THUỐC - " + ma);
            s.AppendLine("Bệnh nhân: " + r["HoTen"] + " | Hồ sơ: " + r["MaHoSo"]);
            s.AppendLine("Ngày khám: " + Convert.ToDateTime(r["NgayGioKham"]).ToString("dd/MM/yyyy HH:mm"));
            s.AppendLine("Kết luận: " + r["KetLuan"]);
            s.AppendLine();
            foreach (DataRow c in ChiTietToa(ma).Rows)
                s.AppendLine(c["STT"] + ". " + c["Tên thuốc"] + " - " + c["Số lượng"] + " " + c["ĐVT"] + Environment.NewLine + "   Liều dùng: " + c["Liều dùng"] + "; Cách dùng: " + c["Cách dùng"]);
            s.AppendLine();
            s.AppendLine("Lời dặn: " + r["LoiDan"]);
            s.AppendLine("Bác sĩ: " + r["BacSi"]);
            return s.ToString();
        }

        public DataTable LichHen()
        {
            return Db.Query("SELECT l.MaHen [Mã hẹn],l.MaHoSo [Mã hồ sơ],b.HoTen [Bệnh nhân],l.NgayGioHen [Ngày giờ hẹn],l.NoiDung [Nội dung],l.TrangThai [Trạng thái],l.Quy [Quý],l.Nam [Năm] FROM LichHen l JOIN HoSoBenhAn h ON h.MaHoSo=l.MaHoSo JOIN BenhNhan b ON b.MaBenhNhan=h.MaBenhNhan ORDER BY l.NgayGioHen DESC");
        }

        public void DatHen(string ma, string hs, DateTime ngay, string nd)
        {
            Required(ma, "mã hẹn");
            Required(nd, "nội dung hẹn");
            Db.Procedure("DatLichDinhKy", P("MaHen", ma), P("MaHoSo", hs), P("NgayGioHen", ngay), P("NoiDung", nd));
        }

        public void SuaHen(string ma, DateTime ngay, string nd, string tt)
        {
            Required(nd, "nội dung hẹn");
            Db.Procedure("CapNhatLichHen", P("MaHen", ma), P("NgayGioHen", ngay), P("NoiDung", nd), P("TrangThai", tt));
        }

        public void ThuTuc(string ma, bool xv, bool tt)
        {
            Db.Procedure("XacNhanThuTuc", P("MaPhieuKham", ma), P("DaXuatVien", xv), P("DaThanhToan", tt));
        }

        public void HoanTat(string ma)
        {
            Db.Procedure("HoanTatDieuTri", P("MaPhieuKham", ma));
        }

        public DataTable LichSu(string hs)
        {
            return Db.Query("SELECT p.MaPhieuKham [Mã phiếu],p.NgayGioKham [Ngày khám],p.LoaiKham [Loại khám],b.HoTen [Bác sĩ],k.TenKhoa [Khoa],p.KetLuan [Kết luận],CASE WHEN p.DaHoanTat=1 THEN N'Đã ghi nhận lịch sử' ELSE N'Đang điều trị' END [Trạng thái] FROM PhieuKham p JOIN BacSi b ON b.MaBacSi=p.MaBacSi JOIN Khoa k ON k.MaKhoa=p.MaKhoa WHERE p.MaHoSo=@h ORDER BY p.NgayGioKham DESC", P("h", hs));
        }

        public DataTable TongHop()
        {
            return Db.Query("SELECT N'Bệnh nhân' [Nội dung],COUNT(*) [Số lượng] FROM BenhNhan UNION ALL SELECT N'Hồ sơ bệnh án',COUNT(*) FROM HoSoBenhAn UNION ALL SELECT N'Phiếu khám đang mở',COUNT(*) FROM PhieuKham WHERE DaHoanTat=0 UNION ALL SELECT N'Đợt đã hoàn tất',COUNT(*) FROM PhieuKham WHERE DaHoanTat=1 UNION ALL SELECT N'Toa thuốc',COUNT(*) FROM ToaThuoc UNION ALL SELECT N'Lịch hẹn còn chờ',COUNT(*) FROM LichHen WHERE TrangThai IN(N'Đã hẹn',N'Đã xác nhận')");
        }
    }
}
