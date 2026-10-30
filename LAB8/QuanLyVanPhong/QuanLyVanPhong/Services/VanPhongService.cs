using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using QuanLyVanPhong.Data;

namespace QuanLyVanPhong.Services
{
    public sealed class VanPhongService
    {
        static readonly string[] Tables = { "Tang", "Phong", "KhachHang", "HopDong", "ChiTietHopDong", "KyTienThue", "DichVu", "SuDungDichVu", "HoaDonDichVu", "ChiTietHoaDonDV", "PhieuGiaHan", "ChiTietGiaHan", "NhanVien", "TheGiuXe", "DotKiemTra", "ChiTietKiemTra", "PhieuPhat", "ThanhToan" };
        public DataTable DS(string table)
        {
            if (!Tables.Contains(table)) throw new ArgumentException("Bảng không hợp lệ.");
            return Db.Query("SELECT * FROM dbo.[" + table + "]");
        }

        public DataTable Chon(string table)
        {
            var q = new Dictionary<string, string> {
                {"Tang", "SELECT MaTang Ma,TenTang Ten FROM Tang ORDER BY SoTang"},
                {"Phong", "SELECT MaPhong Ma,MaPhong+N' - '+Huong Ten FROM Phong ORDER BY MaPhong"},
                {"KhachHang", "SELECT MaKH Ma,TenCongTy+N' - '+MaKH Ten FROM KhachHang ORDER BY MaKH"},
                {"HopDong", "SELECT SoHD Ma,SoHD+N' - '+MaKH Ten FROM HopDong ORDER BY SoHD"},
                {"DichVu", "SELECT MaDV Ma,TenDV Ten FROM DichVu ORDER BY MaDV"},
                {"NhanVien", "SELECT MaNV Ma,HoTen+N' - '+MaNV Ten FROM NhanVien ORDER BY MaNV"},
                {"DotKiemTra", "SELECT SoDot Ma,SoDot Ten FROM DotKiemTra ORDER BY NgayKiemTra DESC"}
            };
            if (!q.ContainsKey(table)) throw new ArgumentException("Danh mục không hợp lệ.");
            return Db.Query(q[table]);
        }

        public void Them(string table, string[] cols, params object[] vals)
        {
            var allowed = new Dictionary<string, string[]> {
                {"Tang",new[]{"MaTang","SoTang","TenTang"}},
                {"Phong",new[]{"MaPhong","MaTang","DienTich","Huong","DonGiaThang","DangSua"}},
                {"KhachHang",new[]{"MaKH","TenCongTy","MaSoThue","NguoiDaiDien","DienThoai","DiaChi"}},
                {"DichVu",new[]{"MaDV","TenDV","DonViTinh","DonGia"}},
                {"DotKiemTra",new[]{"SoDot","NgayKiemTra","NguoiKiemTra","NoiDung"}},
                {"ChiTietKiemTra",new[]{"SoDot","MaPhong","TinhTrang","CanTuSua","ViPhamKetCau","DeXuat"}}
            };
            if (!allowed.ContainsKey(table) || !cols.SequenceEqual(allowed[table]) || vals.Length != cols.Length)
                throw new ArgumentException("Bảng hoặc cột không hợp lệ.");
            if (vals.Any(v => v is string && string.IsNullOrWhiteSpace((string)v)))
                throw new ArgumentException("Nhập đủ thông tin bắt buộc.");
            var args = vals.Select((v, i) => Db.P("p" + i, v)).ToArray();
            Db.Execute("INSERT dbo.[" + table + "](" + string.Join(",", cols) + ") VALUES(" + string.Join(",", args.Select(a => a.ParameterName)) + ")", args);
        }

        public void TinhTrangPhong(string maPhong, bool dangSua)
        {
            if (Db.Execute("UPDATE Phong SET DangSua=@s WHERE MaPhong=@p", Db.P("s", dangSua), Db.P("p", maPhong)) == 0)
                throw new ArgumentException("Chọn phòng cần cập nhật tình trạng.");
        }

        public DataTable DocPhong(string value, bool giaHan)
        {
            var t = new DataTable(); t.Columns.Add("MaPhong", typeof(string)); t.Columns.Add("SoThang", typeof(int));
            var ids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var line in value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var a = line.Trim().Split(';'); int n = 0;
                if (a.Length != (giaHan ? 2 : 1) || string.IsNullOrWhiteSpace(a[0]) || a[0].Trim().Length > 20 || !ids.Add(a[0].Trim()) || (giaHan && (!int.TryParse(a[1], out n) || n <= 0)))
                    throw new ArgumentException(giaHan ? "Mỗi dòng nhập MaPhong;SoThang, không trùng phòng." : "Mỗi dòng nhập một mã phòng, không trùng phòng.");
                t.Rows.Add(a[0].Trim(), n);
            }
            if (t.Rows.Count == 0) throw new ArgumentException("Danh sách phòng không được rỗng.");
            return t;
        }

        public void Proc(string name, string[] keys, params object[] values)
        {
            string[] allowed = { "KyHopDong", "GhiDichVu", "LapHoaDonDichVu", "ThuTien", "LapGiaHan", "GhiNhanVien", "CapTheXe", "LapPhieuPhat" };
            if (!allowed.Contains(name) || keys.Length != values.Length) throw new ArgumentException("Thao tác không hợp lệ.");
            if (values.Any(v => v is string && string.IsNullOrWhiteSpace((string)v))) throw new ArgumentException("Nhập đủ các trường bắt buộc.");
            var args = values.Select((v, i) => Db.P(keys[i], v)).ToArray();
            for (int i = 0; i < values.Length; i++)
                if (values[i] is DataTable) { args[i].SqlDbType = SqlDbType.Structured; args[i].TypeName = "dbo.DanhSachPhong"; }
            Db.Procedure(name, args);
        }

        public void KyHopDong(string hd, string kh, DateTime ky, DateTime tu, int thang, string dieuKhoan, bool daNhan, string hinhThuc, string nguoiThu, DataTable ds)
        {
            Proc("KyHopDong", new[] { "SoHD", "MaKH", "NgayKy", "TuNgay", "SoThang", "DieuKhoan", "DaNhanTruoc", "HinhThuc", "NguoiThu", "DS" }, hd, kh, ky.Date, tu.Date, thang, dieuKhoan, daNhan, hinhThuc, nguoiThu, ds);
        }
        public void LapGiaHan(string gh, string hd, DateTime ngay, string nguoi, DataTable ds)
        {
            Proc("LapGiaHan", new[] { "SoGH", "SoHD", "NgayLap", "NguoiLap", "DS" }, gh, hd, ngay.Date, nguoi, ds);
        }
        public void ThuTien(string tt, string loai, string khoan, DateTime ngay, decimal tien, string hinhThuc, string nguoi)
        {
            Proc("ThuTien", new[] { "MaTT", "Loai", "MaKhoan", "NgayThu", "SoTien", "HinhThuc", "NguoiThu" }, tt, loai, khoan, ngay.Date, tien, hinhThuc, nguoi);
        }
        public DataTable ChiTietThue(string soHD)
        {
            return Db.Query("SELECT c.SoHD,c.MaPhong,p.MaTang,p.DienTich,c.DonGiaThang,h.TuNgay,c.NgayHetHan FROM ChiTietHopDong c JOIN HopDong h ON c.SoHD=h.SoHD JOIN Phong p ON c.MaPhong=p.MaPhong WHERE c.SoHD=@hd", Db.P("hd", soHD));
        }
        public DataTable ChiTietHoaDon(string ma)
        {
            return Db.Query("SELECT c.MaHDDV,s.MaSD,s.MaDV,d.TenDV,s.NgaySuDung,s.SoLuong,s.DonGia,ROUND(s.SoLuong*s.DonGia,0) ThanhTien FROM ChiTietHoaDonDV c JOIN SuDungDichVu s ON c.MaSD=s.MaSD JOIN DichVu d ON d.MaDV=s.MaDV WHERE c.MaHDDV=@ma", Db.P("ma", ma));
        }
        public DataTable ChiTietGiaHan(string ma)
        {
            return Db.Query("SELECT * FROM ChiTietGiaHan WHERE SoGH=@ma", Db.P("ma", ma));
        }
        public DataTable CongNo(DateTime ngay, bool tatCa)
        {
            return Db.Query("SELECT Loai,MaKhoan,SoHD,MaPhong,MaKH,HanThu,SoTien,DaThu,ConLai FROM v_CongNo WHERE ConLai>0 AND (@all=1 OR HanThu<=@ngay) ORDER BY HanThu,SoHD,MaPhong", Db.P("all", tatCa), Db.P("ngay", ngay.Date));
        }
        public DataTable LichSuThu()
        {
            return Db.Query("SELECT MaTT,COALESCE(MaKy,MaHDDV,SoPhat) MaKhoan,CASE WHEN MaKy IS NOT NULL THEN N'Tiền thuê' WHEN MaHDDV IS NOT NULL THEN N'Dịch vụ' ELSE N'Phạt' END Loai,NgayThu,SoTien,HinhThuc,NguoiThu FROM ThanhToan ORDER BY NgayThu DESC,MaTT");
        }
        public DataTable NhanVien()
        {
            return Db.Query("SELECT n.MaNV,n.HoTen,n.MaKH,k.TenCongTy,n.MaPhong,p.MaTang,n.ChucVu,n.NgayBaoCao FROM NhanVien n JOIN KhachHang k ON n.MaKH=k.MaKH JOIN Phong p ON n.MaPhong=p.MaPhong");
        }
        public byte[] Anh(string maNV)
        {
            var t = Db.Query("SELECT HinhAnh FROM NhanVien WHERE MaNV=@ma", Db.P("ma", maNV));
            return t.Rows.Count == 0 ? null : (byte[])t.Rows[0][0];
        }
        public DataTable TheXe()
        {
            return Db.Query("SELECT t.MaThe,t.MaNV,n.HoTen,n.MaPhong,t.BienSo,t.LoaiXe,t.NhanHieu,t.MauXe,t.NgayCap FROM TheGiuXe t JOIN NhanVien n ON t.MaNV=n.MaNV");
        }
        public DataTable PhongTaiNgay(DateTime ngay)
        {
            return Db.Query(@"SELECT p.MaPhong,p.MaTang,p.DienTich,p.Huong,p.DonGiaThang,CASE WHEN p.DangSua=1 THEN N'Đang sửa' WHEN EXISTS(SELECT 1 FROM ChiTietHopDong c JOIN HopDong h ON h.SoHD=c.SoHD WHERE c.MaPhong=p.MaPhong AND @n BETWEEN h.TuNgay AND c.NgayHetHan) THEN N'Đang thuê' ELSE N'Trống' END TrangThai FROM Phong p ORDER BY p.MaPhong", Db.P("n", ngay.Date));
        }
        public DataTable CanKiemTra(DateTime ngay)
        {
            return Db.Query(@"SELECT p.MaPhong,p.MaTang,k.NgayKiemTra KiemTraGanNhat,DATEADD(year,1,k.NgayKiemTra) HanKiemTra,CASE WHEN k.NgayKiemTra IS NULL THEN N'Chưa kiểm tra' WHEN DATEADD(year,1,k.NgayKiemTra)<=@n THEN N'Đến hạn' ELSE N'Chưa đến hạn' END TrangThai FROM Phong p OUTER APPLY(SELECT MAX(d.NgayKiemTra) NgayKiemTra FROM ChiTietKiemTra c JOIN DotKiemTra d ON c.SoDot=d.SoDot WHERE c.MaPhong=p.MaPhong)k ORDER BY p.MaPhong", Db.P("n", ngay.Date));
        }
        public DataTable DoanhThu(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT CASE WHEN MaKy IS NOT NULL THEN N'Tiền thuê' WHEN MaHDDV IS NOT NULL THEN N'Dịch vụ' ELSE N'Phạt' END Loai,COUNT(*) SoLanThu,SUM(SoTien) TongTien FROM ThanhToan WHERE NgayThu BETWEEN @tu AND @den GROUP BY CASE WHEN MaKy IS NOT NULL THEN N'Tiền thuê' WHEN MaHDDV IS NOT NULL THEN N'Dịch vụ' ELSE N'Phạt' END", Db.P("tu", tu.Date), Db.P("den", den.Date));
        }
        public string ThongBaoLoi(Exception error) { return Db.Friendly(error); }
    }
}
