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
    public class SanPham
    {
        public string MaSP { get; set; }
        public string MaNhom { get; set; }
        public string TenSP { get; set; }
        public string NhaSanXuat { get; set; }
        public string MoTa { get; set; }
        public string ThongSo { get; set; }
        public decimal GiaHienHanh { get; set; }
        public bool ConHang { get; set; }
        public List<string> HinhAnh = new List<string>();
    }
}
