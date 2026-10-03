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
    public class ProductCatalogAdapter : IProductCatalog
    {
        readonly SqlRepository repo; public ProductCatalogAdapter(SqlRepository r) { repo = r; }
        public List<NhomSanPham> Groups() { var a = new List<NhomSanPham>(); using (var c = repo.Open()) using (var cmd = c.CreateCommand()) { cmd.CommandText = "SELECT * FROM catalog.NhomSanPham ORDER BY TenNhom"; using (var r = cmd.ExecuteReader()) while (r.Read()) a.Add(new NhomSanPham { MaNhom = (string)r[0], TenNhom = (string)r[1] }); } return a; }
        public List<SanPham> Search(string group, string keyword)
        {
            var a = new List<SanPham>(); using (var c = repo.Open()) using (var cmd = c.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM catalog.SanPham WHERE (@g='' OR MaNhom=@g) AND (TenSP LIKE @k OR NhaSanXuat LIKE @k OR MaSP LIKE @k) ORDER BY MaSP"; SqlRepository.P(cmd, "@g", SqlDbType.VarChar, group ?? "", 20); SqlRepository.P(cmd, "@k", SqlDbType.NVarChar, "%" + (keyword ?? "").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") + "%", 160);
                using (var r = cmd.ExecuteReader()) while (r.Read()) a.Add(new SanPham { MaSP = (string)r["MaSP"], MaNhom = (string)r["MaNhom"], TenSP = (string)r["TenSP"], NhaSanXuat = (string)r["NhaSanXuat"], MoTa = (string)r["MoTa"], ThongSo = (string)r["ThongSo"], GiaHienHanh = (decimal)r["GiaHienHanh"], ConHang = (bool)r["ConHang"] });
            }
            return a;
        }
        public SanPham Get(string code)
        {
            var p = Search(null, code).FirstOrDefault(x => x.MaSP == code); if (p == null) return null;
            using (var c = repo.Open()) using (var cmd = c.CreateCommand()) { cmd.CommandText = "SELECT DuongDan FROM catalog.HinhAnhSanPham WHERE MaSP=@p ORDER BY ThuTu"; SqlRepository.P(cmd, "@p", SqlDbType.VarChar, code, 20); using (var r = cmd.ExecuteReader()) while (r.Read()) p.HinhAnh.Add((string)r[0]); }
            return p;
        }
    }
}
