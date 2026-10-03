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
    public class CartService
    {
        readonly IProductCatalog catalog; readonly AppSession session;
        public CartService(IProductCatalog c, AppSession s) { catalog = c; session = s; }
        void CanEdit() { if (session.Cart.Busy) throw new InvalidOperationException("Đang xử lý thanh toán."); }
        public void Add(string code, int qty)
        {
            CanEdit(); if (qty <= 0) throw new ArgumentException("Số lượng phải lớn hơn 0.");
            var p = catalog.Get(code); if (p == null || !p.ConHang) throw new ArgumentException("Sản phẩm đã hết hàng.");
            var item = session.Cart.Items.FirstOrDefault(x => x.MaSP == code);
            if (item == null) session.Cart.Items.Add(new CartItem { MaSP = code, TenSP = p.TenSP, SoLuong = qty, DonGia = p.GiaHienHanh });
            else { item.SoLuong = checked(item.SoLuong + qty); item.DonGia = p.GiaHienHanh; }
        }
        public void Update(string code, int qty)
        {
            CanEdit(); if (qty < 0) throw new ArgumentException("Số lượng không được âm.");
            var item = session.Cart.Items.Single(x => x.MaSP == code);
            if (qty == 0) session.Cart.Items.Remove(item); else item.SoLuong = qty;
        }
        public void Remove(string code) { Update(code, 0); }
    }
}
