using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public sealed class NhanSuService
    {
        public DataTable NhanVien()
        {
            return Db.Query("SELECT MaNV Ma,HoTen+N' - '+MaNV Ten FROM NhanVien ORDER BY MaNV");
        }

        public DataTable PhongBan()
        {
            return Db.Query("SELECT MaPB Ma,TenPB Ten FROM PhongBan ORDER BY MaPB");
        }

        public DataTable ChucVu()
        {
            return Db.Query("SELECT MaCV Ma,TenCV Ten FROM ChucVu ORDER BY MaCV");
        }

        public DataTable Ca()
        {
            return Db.Query("SELECT MaCa Ma,TenCa Ten FROM CaLam ORDER BY MaCa");
        }

        public DataTable DS(string table)
        {
            if (!Allowed.Contains(table))
                throw new ArgumentException("Bảng không hợp lệ.");
            return Db.Query("SELECT * FROM dbo.[" + table + "]");
        }

        static readonly string[] Allowed =
        {
            "PhongBan",
            "ChucVu",
            "CaLam",
            "NhanVien",
            "QuyetDinhTuyenDung",
            "HopDong",
            "BaoHiem",
            "QuyetDinhLuong",
            "QuyetDinhChucVu",
            "KeHoachTuan",
            "PhanCongCa",
            "ChamCong",
            "PhieuPhuTroi",
            "ChiTietPhuTroi",
            "QuyetDinhKhenThuong",
            "ChiTietKhenThuong",
            "PhieuChi",
            "QuyetDinhKyLuat",
            "ChiTietKyLuat",
            "PhieuThu",
            "BangLuong",
            "ChiTietBangLuong"
        };
        public void Them(string table, string[] cols, object[] vals)
        {
            var permitted = new System.Collections.Generic.Dictionary<string, string[]>
            {
                {
                    "PhongBan",
                    new[]
                    {
                        "MaPB",
                        "TenPB"
                    }
                },
                {
                    "ChucVu",
                    new[]
                    {
                        "MaCV",
                        "TenCV"
                    }
                },
                {
                    "CaLam",
                    new[]
                    {
                        "MaCa",
                        "TenCa",
                        "GioBatDau",
                        "GioKetThuc",
                        "SoGio"
                    }
                },
                {
                    "QuyetDinhLuong",
                    new[]
                    {
                        "SoQD",
                        "MaNV",
                        "NgayHieuLuc",
                        "LuongCoBan",
                        "PhuCapLuong",
                        "PhuCapDocHai"
                    }
                },
                {
                    "QuyetDinhChucVu",
                    new[]
                    {
                        "SoQD",
                        "MaNV",
                        "MaCV",
                        "NgayHieuLuc",
                        "PhuCap"
                    }
                },
                {
                    "KeHoachTuan",
                    new[]
                    {
                        "MaKH",
                        "MaPB",
                        "DauTuan",
                        "NguoiLap"
                    }
                }
            };
            if (!permitted.ContainsKey(table) || !cols.SequenceEqual(permitted[table]) || vals.Length != cols.Length)
                throw new ArgumentException("Không được ghi bảng/cột này.");
            foreach (var v in vals)
                if (v is string && string.IsNullOrWhiteSpace((string)v))
                    throw new ArgumentException("Nhập đủ các trường bắt buộc.");
            if (table == "CaLam" && (TimeSpan)vals[2] >= (TimeSpan)vals[3])
                throw new ArgumentException("Ca trong ngày phải kết thúc sau giờ bắt đầu.");
            if (table == "KeHoachTuan" && ((DateTime)vals[2]).DayOfWeek != DayOfWeek.Monday)
                throw new ArgumentException("Ngày đầu tuần phải là thứ Hai.");
            if (table.StartsWith("QuyetDinh"))
            {
                var effective = (DateTime)vals[2 + (table == "QuyetDinhChucVu" ? 1 : 0)];
                if (Db.Query("SELECT 1 FROM HopDong WHERE MaNV=@nv AND TuNgay<=@d AND (DenNgay IS NULL OR DenNgay>=@d)", Db.P("nv", vals[1]), Db.P("d", effective)).Rows.Count == 0)
                    throw new ArgumentException("Chỉ lập quyết định cho nhân viên có hợp đồng hiệu lực.");
            }

            Db.Execute("INSERT dbo.[" + table + "] (" + string.Join(",", cols) + ") VALUES (" + string.Join(",", cols.Select(c => "@" + c)) + ")", cols.Select((c, i) => Db.P(c, vals[i])).ToArray());
        }

        public void Proc(string name, string[] keys, params object[] values)
        {
            if (!new[]
            {
                "TuyenDung",
                "DanhGia",
                "KyHopDong",
                "PhanCong",
                "GhiChamCong",
                "LapPhuTroi",
                "LapKhenThuong",
                "LapKyLuat",
                "LapBangLuong"
            }.Contains(name))
                throw new ArgumentException("Nghiệp vụ không hợp lệ.");
            var args = keys.Select((k, i) => Db.P(k, values[i])).ToArray();
            foreach (var p in args)
                if (p.Value is DataTable)
                {
                    p.SqlDbType = SqlDbType.Structured;
                    p.TypeName = "dbo.DanhSachTien";
                }

            Db.Procedure(name, args);
        }

        public void TuyenDung(string[] keys, params object[] values)
        {
            Proc("TuyenDung", keys, values);
        }

        public void DanhGia(string[] keys, params object[] values)
        {
            Proc("DanhGia", keys, values);
        }

        public void KyHopDong(string[] keys, params object[] values)
        {
            Proc("KyHopDong", keys, values);
        }

        public void PhanCong(string[] keys, params object[] values)
        {
            Proc("PhanCong", keys, values);
        }

        public void GhiChamCong(string[] keys, params object[] values)
        {
            Proc("GhiChamCong", keys, values);
        }

        public void LapPhuTroi(string[] keys, params object[] values)
        {
            Proc("LapPhuTroi", keys, values);
        }

        public void LapKyLuat(string[] keys, params object[] values)
        {
            Proc("LapKyLuat", keys, values);
        }

        public void LapBangLuong(string[] keys, params object[] values)
        {
            Proc("LapBangLuong", keys, values);
        }

        public DataTable DocDanhSach(string text, bool money)
        {
            var t = new DataTable();
            t.Columns.Add("MaNV", typeof(string));
            t.Columns.Add("SoTien", typeof(decimal));
            t.PrimaryKey = new[]
            {
                t.Columns[0]
            };
            foreach (var line in text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var a = line.Split(';');
                decimal v = 0;
                if (money && (a.Length != 2 || !decimal.TryParse(a[1], out v)))
                    throw new ArgumentException("Mỗi dòng: MaNV;SoTien (không dấu phân cách nghìn).");
                t.Rows.Add(a[0].Trim(), v);
            }

            return t;
        }

        public void LapKhenThuong(string q, DateTime d, string nv, string pb, string nd, decimal tong, string ky, string cach, string pc, DataTable ds)
        {
            Proc("LapKhenThuong", new[] { "SoQD", "Ngay", "MaNV", "MaPB", "NoiDung", "Tong", "NguoiKy", "Cach", "SoPhieu", "DS" }, q, d, nv, pb, nd, tong, ky, cach, pc, ds);
        }

        public DataTable Luong(string ma)
        {
            return Db.Query("SELECT MaNV [Mã NV],GioCong [Giờ công],GioPhuTroi [Giờ phụ trội],TienCong [Tiền công],TienPhuTroi [Tiền phụ trội],BaoHiem [Bảo hiểm],Thuong [Thưởng],Phat [Phạt],ThucLinh [Thực lĩnh] FROM ChiTietBangLuong WHERE MaBL=@ma", Db.P("ma", ma));
        }

        public DataTable ThongKe()
        {
            return Db.Query("SELECT b.MaBL [Mã bảng],b.Thang [Tháng],b.Nam [Năm],COUNT(c.MaNV) [Số NV],SUM(c.ThucLinh) [Tổng thực lĩnh] FROM BangLuong b LEFT JOIN ChiTietBangLuong c ON b.MaBL=c.MaBL GROUP BY b.MaBL,b.Thang,b.Nam ORDER BY b.Nam,b.Thang");
        }
    }
}
