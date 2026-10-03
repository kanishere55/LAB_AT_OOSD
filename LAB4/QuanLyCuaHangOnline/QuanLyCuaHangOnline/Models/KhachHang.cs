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
    public class KhachHang
    {
        public int MaKH; public string HoTen, GiayTo, DiaChi, DienThoai, TenDangNhap, Email;
        public DateTime NgaySinh; public byte[] MatKhauHash, Salt;
    }
}
