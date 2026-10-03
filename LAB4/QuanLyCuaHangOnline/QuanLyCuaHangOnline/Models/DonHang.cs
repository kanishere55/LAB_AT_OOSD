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
    public class DonHang
    {
        public int MaDH; public Guid MaYeuCau; public KhachHang NguoiMua;
        public NguoiNhan NguoiNhan; public CheckoutQuote Quote; public DateTime ThoiDiem;
        public string LoaiThe, BonSoCuoi, MaGiaoDich, EmailStatus;
    }
}
