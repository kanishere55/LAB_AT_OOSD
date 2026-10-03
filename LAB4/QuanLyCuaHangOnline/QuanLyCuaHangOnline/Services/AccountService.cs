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
    public class AccountService
    {
        readonly SqlRepository repo;
        public AccountService(SqlRepository r) { repo = r; }
        public static byte[] Hash(string password, byte[] salt) { using (var h = new Rfc2898DeriveBytes(password, salt, 100000)) { return h.GetBytes(32); } }
        public KhachHang Register(KhachHang c, string password)
        {
            if (string.IsNullOrWhiteSpace(c.HoTen) || string.IsNullOrWhiteSpace(c.GiayTo) || string.IsNullOrWhiteSpace(c.DiaChi)) throw new ArgumentException("Nhập đủ thông tin khách hàng.");
            if (!Regex.IsMatch(c.TenDangNhap ?? "", "^[A-Za-z0-9_]{3,50}$")) throw new ArgumentException("Tên đăng nhập gồm 3–50 chữ, số hoặc gạch dưới.");
            if (!Regex.IsMatch(c.DienThoai ?? "", "^[0-9]{9,15}$")) throw new ArgumentException("Điện thoại phải có 9–15 chữ số.");
            if (c.NgaySinh.Date > DateTime.Today) throw new ArgumentException("Ngày sinh không hợp lệ.");
            if (string.IsNullOrEmpty(password) || password.Length < 8) throw new ArgumentException("Mật khẩu cần ít nhất 8 ký tự.");
            if (string.IsNullOrWhiteSpace(c.Email)) c.Email = null; else { try { var m = new MailAddress(c.Email); if (m.Address != c.Email) throw new ArgumentException("Email không hợp lệ."); } catch (FormatException) { throw new ArgumentException("Email không hợp lệ."); } }
            c.Salt = new byte[16]; using (var rng = RandomNumberGenerator.Create()) { rng.GetBytes(c.Salt); }
            c.MatKhauHash = Hash(password, c.Salt);
            c.MaKH = repo.Register(c); return c;
        }
        public KhachHang Login(string user, string password)
        {
            var c = repo.FindCustomer(user); if (c == null) throw new ArgumentException("Sai tên đăng nhập hoặc mật khẩu.");
            byte[] hash = Hash(password, c.Salt); int diff = 0; for (int i = 0; i < hash.Length; i++) diff |= hash[i] ^ c.MatKhauHash[i];
            if (diff != 0) throw new ArgumentException("Sai tên đăng nhập hoặc mật khẩu."); return c;
        }
    }
}
