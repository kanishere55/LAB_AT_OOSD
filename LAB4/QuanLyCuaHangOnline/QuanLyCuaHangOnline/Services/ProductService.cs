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
    public class ProductService
    {
        readonly IProductCatalog catalog;
        public ProductService(IProductCatalog c) { catalog = c; }
        public List<NhomSanPham> Groups() { return catalog.Groups(); }
        public List<SanPham> Search(string g, string k) { return catalog.Search(g, k); }
        public SanPham Get(string code) { return catalog.Get(code); }
    }
}
