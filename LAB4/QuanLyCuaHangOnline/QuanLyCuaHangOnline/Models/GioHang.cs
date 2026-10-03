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
    public class GioHang
    {
        public List<CartItem> Items = new List<CartItem>();
        public bool Busy { get; set; }
        public decimal TienHang { get { return Items.Sum(x => x.ThanhTien); } }
    }
}
