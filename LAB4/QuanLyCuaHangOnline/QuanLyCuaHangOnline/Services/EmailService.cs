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
    public class EmailService
    {
        readonly SqlRepository repo; readonly IEmailGateway gateway;
        public EmailService(SqlRepository r, IEmailGateway g) { repo = r; gateway = g; }
        public static string Body(DonHang d)
        {
            var b = new StringBuilder();
            b.AppendLine("Đơn hàng #" + d.MaDH + " - " + d.ThoiDiem.ToString("dd/MM/yyyy HH:mm:ss"));
            b.AppendLine("Người mua: " + d.NguoiMua.HoTen);
            b.AppendLine("Người nhận: " + d.NguoiNhan.HoTen + " | " + d.NguoiNhan.DiaChi + " | " + d.NguoiNhan.DienThoai);
            b.AppendLine("Khu vực: " + d.NguoiNhan.KhuVuc + "; giao: " + d.NguoiNhan.LoaiGiao);
            foreach (var i in d.Quote.Items) b.AppendLine(i.MaSP + " " + i.TenSP + " | SL " + i.SoLuong + " | đơn giá " + i.DonGia + " | thành tiền " + i.ThanhTien);
            b.AppendLine("Tiền hàng: " + d.Quote.TienHang + "; phí giao: " + d.Quote.PhiGiao + "; phụ phí thanh toán: " + d.Quote.PhiThe);
            b.AppendLine("Tổng thanh toán: " + d.Quote.TongTien + " đồng"); return b.ToString();
        }
        public string Send(DonHang d)
        {
            if (string.IsNullOrEmpty(d.NguoiMua.Email)) return "Không có email";
            string status = "DaGui", body = Body(d); try { gateway.Send(d.NguoiMua.Email, body); } catch { status = "LoiGui"; }
            try { repo.SaveEmail(d.MaDH, d.NguoiMua.Email, body, status); } catch { return "Không ghi được nhật ký email"; }
            return status;
        }
    }
}
