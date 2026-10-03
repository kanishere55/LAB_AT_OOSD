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
    public class EmailGatewayAdapter : IEmailGateway
    {
        public bool SimulateFailure;
        public void Send(string a, string b) { if (SimulateFailure) throw new InvalidOperationException("Lỗi gửi giả lập"); }
    }
}
