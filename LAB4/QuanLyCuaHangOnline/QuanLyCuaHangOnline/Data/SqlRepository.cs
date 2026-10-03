using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangOnline
{
    public class SqlRepository
    {
        public readonly string ConnectionString = Db.ConnectionString;
        public SqlConnection Open() { return Db.OpenConnection(); }
        public static void P(SqlCommand c, string name, SqlDbType type, object value, int size = 0) { var p = size > 0 ? c.Parameters.Add(name, type, size) : c.Parameters.Add(name, type); p.Value = value ?? DBNull.Value; }
        public int Register(KhachHang k)
        {
            using (var c = Open()) using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "INSERT dbo.KhachHang(HoTen,NgaySinh,GiayTo,DiaChi,DienThoai,TenDangNhap,MatKhauHash,Salt,Email) OUTPUT INSERTED.MaKH VALUES(@n,@d,@g,@a,@p,@u,@h,@s,@e)";
                P(cmd, "@n", SqlDbType.NVarChar, k.HoTen, 100); P(cmd, "@d", SqlDbType.Date, k.NgaySinh); P(cmd, "@g", SqlDbType.NVarChar, k.GiayTo, 30); P(cmd, "@a", SqlDbType.NVarChar, k.DiaChi, 250); P(cmd, "@p", SqlDbType.VarChar, k.DienThoai, 20); P(cmd, "@u", SqlDbType.VarChar, k.TenDangNhap, 50); P(cmd, "@h", SqlDbType.VarBinary, k.MatKhauHash, 32); P(cmd, "@s", SqlDbType.VarBinary, k.Salt, 16); P(cmd, "@e", SqlDbType.NVarChar, k.Email, 254);
                try { return (int)cmd.ExecuteScalar(); } catch (SqlException ex) { if (ex.Number == 2627 || ex.Number == 2601) throw new ArgumentException("Tên đăng nhập đã tồn tại."); throw; }
            }
        }
        public KhachHang FindCustomer(string username)
        {
            using (var c = Open()) using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM dbo.KhachHang WHERE TenDangNhap=@u"; P(cmd, "@u", SqlDbType.VarChar, username, 50);
                using (var r = cmd.ExecuteReader()) { if (!r.Read()) return null; return new KhachHang { MaKH = (int)r["MaKH"], HoTen = (string)r["HoTen"], NgaySinh = (DateTime)r["NgaySinh"], GiayTo = (string)r["GiayTo"], DiaChi = (string)r["DiaChi"], DienThoai = (string)r["DienThoai"], TenDangNhap = (string)r["TenDangNhap"], MatKhauHash = (byte[])r["MatKhauHash"], Salt = (byte[])r["Salt"], Email = r["Email"] == DBNull.Value ? null : (string)r["Email"] }; }
            }
        }
        public decimal BaseShipping(string region, string type)
        {
            using (var c = Open()) using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT PhiCoBan FROM dbo.PhiGiaoHang WHERE KhuVuc=@r AND LoaiGiao=@t"; P(cmd, "@r", SqlDbType.VarChar, region, 20); P(cmd, "@t", SqlDbType.VarChar, type, 20); var v = cmd.ExecuteScalar(); if (v == null) throw new ArgumentException("Khu vực chưa hỗ trợ loại giao đã chọn."); return (decimal)v;
            }
        }
        public int SaveOrder(DonHang d)
        {
            using (var c = Open()) using (var tx = c.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    using (var cmd = c.CreateCommand())
                    {
                        cmd.Transaction = tx;
                        cmd.CommandText = "SELECT MaDH FROM dbo.DonHang WITH(UPDLOCK,HOLDLOCK) WHERE MaYeuCau=@k"; P(cmd, "@k", SqlDbType.UniqueIdentifier, d.MaYeuCau); var old = cmd.ExecuteScalar(); if (old != null) { tx.Commit(); return (int)old; }
                        cmd.Parameters.Clear(); cmd.CommandText = "INSERT dbo.DonHang(MaYeuCau,MaKH,TenNguoiMua,EmailNguoiMua,TenNguoiNhan,DiaChiNhan,DienThoaiNhan,KhuVucGiao,LoaiGiao,TienHang,PhiGiao,PhiThe,ThoiDiem) OUTPUT INSERTED.MaDH VALUES(@k,@c,@b,@e,@n,@a,@p,@r,@t,@s,@f,@fee,@time)";
                        P(cmd, "@k", SqlDbType.UniqueIdentifier, d.MaYeuCau); P(cmd, "@c", SqlDbType.Int, d.NguoiMua.MaKH); P(cmd, "@b", SqlDbType.NVarChar, d.NguoiMua.HoTen, 100); P(cmd, "@e", SqlDbType.NVarChar, d.NguoiMua.Email, 254); P(cmd, "@n", SqlDbType.NVarChar, d.NguoiNhan.HoTen, 100); P(cmd, "@a", SqlDbType.NVarChar, d.NguoiNhan.DiaChi, 250); P(cmd, "@p", SqlDbType.VarChar, d.NguoiNhan.DienThoai, 20); P(cmd, "@r", SqlDbType.VarChar, d.NguoiNhan.KhuVuc, 20); P(cmd, "@t", SqlDbType.VarChar, d.NguoiNhan.LoaiGiao, 20); P(cmd, "@s", SqlDbType.Decimal, d.Quote.TienHang); P(cmd, "@f", SqlDbType.Decimal, d.Quote.PhiGiao); P(cmd, "@fee", SqlDbType.Decimal, d.Quote.PhiThe); P(cmd, "@time", SqlDbType.DateTime2, d.ThoiDiem);
                        int id = (int)cmd.ExecuteScalar();
                        foreach (var i in d.Quote.Items) { cmd.Parameters.Clear(); cmd.CommandText = "INSERT dbo.ChiTietDonHang(MaDH,MaSP,TenSP,SoLuong,DonGia) VALUES(@d,@p,@n,@q,@v)"; P(cmd, "@d", SqlDbType.Int, id); P(cmd, "@p", SqlDbType.VarChar, i.MaSP, 20); P(cmd, "@n", SqlDbType.NVarChar, i.TenSP, 150); P(cmd, "@q", SqlDbType.Int, i.SoLuong); P(cmd, "@v", SqlDbType.Decimal, i.DonGia); cmd.ExecuteNonQuery(); }
                        cmd.Parameters.Clear(); cmd.CommandText = "INSERT dbo.ThanhToan(MaDH,LoaiThe,BonSoCuoi,MaGiaoDich,SoTien) VALUES(@d,@t,@last,@g,@s)"; P(cmd, "@d", SqlDbType.Int, id); P(cmd, "@t", SqlDbType.VarChar, d.LoaiThe, 20); P(cmd, "@last", SqlDbType.Char, d.BonSoCuoi, 4); P(cmd, "@g", SqlDbType.VarChar, d.MaGiaoDich, 50); P(cmd, "@s", SqlDbType.Decimal, d.Quote.TongTien); cmd.ExecuteNonQuery(); tx.Commit(); return id;
                    }
                }
                catch { tx.Rollback(); throw; }
            }
        }
        public void SaveEmail(int id, string email, string body, string status)
        {
            using (var c = Open()) using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "IF NOT EXISTS(SELECT 1 FROM dbo.EmailXacNhan WHERE MaDH=@d) INSERT dbo.EmailXacNhan(MaDH,DiaChiEmail,NoiDung,TrangThai) VALUES(@d,@e,@b,@s)"; P(cmd, "@d", SqlDbType.Int, id); P(cmd, "@e", SqlDbType.NVarChar, email, 254); P(cmd, "@b", SqlDbType.NVarChar, body, -1); P(cmd, "@s", SqlDbType.VarChar, status, 20); cmd.ExecuteNonQuery();
            }
        }
        public DonHang FindOrder(Guid key)
        {
            DonHang d = null; using (var c = Open()) using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT d.*,t.LoaiThe,t.BonSoCuoi,t.MaGiaoDich,e.TrangThai FROM dbo.DonHang d JOIN dbo.ThanhToan t ON t.MaDH=d.MaDH LEFT JOIN dbo.EmailXacNhan e ON e.MaDH=d.MaDH WHERE MaYeuCau=@k"; P(cmd, "@k", SqlDbType.UniqueIdentifier, key);
                using (var r = cmd.ExecuteReader()) { if (r.Read()) d = new DonHang { MaDH = (int)r["MaDH"], MaYeuCau = key, ThoiDiem = (DateTime)r["ThoiDiem"], NguoiMua = new KhachHang { MaKH = (int)r["MaKH"], HoTen = (string)r["TenNguoiMua"], Email = r["EmailNguoiMua"] == DBNull.Value ? null : (string)r["EmailNguoiMua"] }, NguoiNhan = new NguoiNhan { HoTen = (string)r["TenNguoiNhan"], DiaChi = (string)r["DiaChiNhan"], DienThoai = (string)r["DienThoaiNhan"], KhuVuc = (string)r["KhuVucGiao"], LoaiGiao = (string)r["LoaiGiao"] }, Quote = new CheckoutQuote { TienHang = (decimal)r["TienHang"], PhiGiao = (decimal)r["PhiGiao"], PhiThe = (decimal)r["PhiThe"], Items = new List<CartItem>() }, LoaiThe = (string)r["LoaiThe"], BonSoCuoi = (string)r["BonSoCuoi"], MaGiaoDich = (string)r["MaGiaoDich"], EmailStatus = r["TrangThai"] == DBNull.Value ? "Không có email" : (string)r["TrangThai"] }; }
                if (d != null) { cmd.Parameters.Clear(); cmd.CommandText = "SELECT * FROM dbo.ChiTietDonHang WHERE MaDH=@d"; P(cmd, "@d", SqlDbType.Int, d.MaDH); using (var r = cmd.ExecuteReader()) { while (r.Read()) d.Quote.Items.Add(new CartItem { MaSP = (string)r["MaSP"], TenSP = (string)r["TenSP"], SoLuong = (int)r["SoLuong"], DonGia = (decimal)r["DonGia"] }); } }
            }
            return d;
        }
    }
}
