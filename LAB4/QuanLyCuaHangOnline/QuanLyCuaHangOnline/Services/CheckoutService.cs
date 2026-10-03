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
    public class CheckoutService
    {
        readonly AppSession session; readonly IProductCatalog catalog; readonly SqlRepository repo;
        readonly IPaymentGateway payment; readonly EmailService email;
        public CheckoutService(AppSession s, IProductCatalog c, SqlRepository r, IPaymentGateway p, EmailService e) { session = s; catalog = c; repo = r; payment = p; email = e; }
        public static decimal Shipping(decimal subtotal, string type, decimal basic)
        {
            if (type == "Nhanh" && subtotal >= 1000000m) return 0;
            if (type == "TrongNgay" && subtotal >= 5000000m) return 0; return basic;
        }
        public static void ValidateCard(CardInfo c, DateTime now)
        {
            bool amex = c.LoaiThe == "AmEx";
            if (!new[] { "VISA", "Master", "Discover", "AmEx" }.Contains(c.LoaiThe)) throw new ArgumentException("Loại thẻ không hợp lệ.");
            if (!Regex.IsMatch(c.SoThe ?? "", amex ? "^[0-9]{15}$" : "^[0-9]{16}$")) throw new ArgumentException("Số thẻ sai độ dài.");
            if (!Regex.IsMatch(c.CSV ?? "", amex ? "^[0-9]{4}$" : "^[0-9]{3}$")) throw new ArgumentException("CSV sai độ dài.");
            if (string.IsNullOrWhiteSpace(c.ChuThe)) throw new ArgumentException("Nhập tên chủ thẻ.");
            if (new DateTime(c.HetHan.Year, c.HetHan.Month, 1).AddMonths(1) <= now.Date) throw new ArgumentException("Thẻ đã hết hạn.");
        }
        public CheckoutQuote Quote(NguoiNhan n, string cardType)
        {
            if (session.Customer == null) throw new ArgumentException("Cần đăng nhập trước khi đặt hàng.");
            if (session.Cart.Items.Count == 0) throw new ArgumentException("Giỏ hàng trống.");
            if (string.IsNullOrWhiteSpace(n.HoTen) || string.IsNullOrWhiteSpace(n.DiaChi) || !Regex.IsMatch(n.DienThoai ?? "", "^[0-9]{9,15}$")) throw new ArgumentException("Thông tin người nhận không hợp lệ.");
            var rows = new List<CartItem>(); bool changed = false;
            foreach (var i in session.Cart.Items)
            {
                var p = catalog.Get(i.MaSP);
                if (p == null || !p.ConHang) throw new ArgumentException("Sản phẩm " + i.MaSP + " đã hết hàng.");
                if (i.DonGia != p.GiaHienHanh) { i.DonGia = p.GiaHienHanh; i.TenSP = p.TenSP; changed = true; }
                rows.Add(i.Copy());
            }
            if (changed) throw new ArgumentException("Giá sản phẩm đã đổi. Hãy xem lại giỏ và xác nhận giá mới.");
            decimal fee; if (!decimal.TryParse(ConfigurationManager.AppSettings["Fee_" + cardType], out fee) || fee < 0) throw new ArgumentException("Chưa cấu hình phí thẻ.");
            var q = new CheckoutQuote { Items = rows, TienHang = rows.Sum(i => i.ThanhTien), PhiThe = fee, LoaiThe = cardType };
            q.PhiGiao = Shipping(q.TienHang, n.LoaiGiao, repo.BaseShipping(n.KhuVuc, n.LoaiGiao)); return q;
        }
        public DonHang Place(Guid key, NguoiNhan n, CardInfo card, CheckoutQuote accepted)
        {
            if (session.Cart.Busy) throw new InvalidOperationException("Đang xử lý thanh toán.");
            // Khoa yeu cau da hoan thanh: tra lai don, khong thanh toan lan nua.
            var old = repo.FindOrder(key); if (old != null) { if (session.Customer == null || old.NguoiMua.MaKH != session.Customer.MaKH) throw new ArgumentException("Yêu cầu không hợp lệ."); return old; }
            session.Cart.Busy = true;
            try
            {
                ValidateCard(card, DateTime.Today); var q = Quote(n, card.LoaiThe);
                if (accepted == null || q.TongTien != accepted.TongTien || q.LoaiThe != accepted.LoaiThe || q.Items.Count != accepted.Items.Count || q.Items.Any(x => !accepted.Items.Any(y => x.MaSP == y.MaSP && x.SoLuong == y.SoLuong && x.DonGia == y.DonGia))) throw new ArgumentException("Đơn hàng đã đổi; cần xác nhận lại tổng tiền.");
                var result = payment.Pay(key, card, q.TongTien); if (!result.Approved) throw new ArgumentException(result.Message);
                var d = new DonHang { MaYeuCau = key, NguoiMua = session.Customer, NguoiNhan = n, Quote = q, ThoiDiem = DateTime.Now, LoaiThe = card.LoaiThe, BonSoCuoi = card.SoThe.Substring(card.SoThe.Length - 4), MaGiaoDich = result.MaGiaoDich };
                d.MaDH = repo.SaveOrder(d); session.Cart.Items.Clear(); d.EmailStatus = email.Send(d); return d;
            }
            finally { session.Cart.Busy = false; }
        }
    }
}
