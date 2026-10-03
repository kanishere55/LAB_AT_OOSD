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
    public class PaymentGatewayAdapter : IPaymentGateway
    {
        // Gia lap dich vu ngoai. CSV 000/0000: tu choi; cac gia tri hop le khac: chap nhan.
        readonly Dictionary<Guid, PaymentResult> results = new Dictionary<Guid, PaymentResult>();
        public PaymentResult Pay(Guid key, CardInfo c, decimal total)
        {
            if (results.ContainsKey(key)) return results[key];
            var r = new PaymentResult
            {
                Approved = !c.CSV.All(x => x == '0'),
                MaGiaoDich = "LAB-" + key.ToString("N"),
                Message = "Dịch vụ giả lập từ chối giao dịch."
            };
            if (r.Approved) results[key] = r; return r;
        }
    }
}
