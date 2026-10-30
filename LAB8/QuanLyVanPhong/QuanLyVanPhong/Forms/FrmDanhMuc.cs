using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace QuanLyVanPhong.Forms {
    public sealed class FrmDanhMuc : ModuleForm {
        
        public FrmDanhMuc() : base("Danh mục tầng, phòng và dịch vụ") {

            var tang = Page("Tầng", new[] {F("Mã tầng",Txt("mt","",20)),F("Số tầng",Num("st",1)),F("Tên tầng",Txt("tent","",100))},new[]{A("Thêm tầng",()=>S.Them("Tang",new[]{"MaTang","SoTang","TenTang"},V("mt"),(int)N("st"),V("tent"))),A("Tải lại",RefreshData)});
            var phong = Page("Phòng", new[] {F("Mã phòng",Txt("mp","",20)),F("Tầng",Combo("tang")),F("Diện tích (m²)",Num("dt",80,2)),F("Hướng phòng",Txt("huong","Đông",50)),F("Giá thuê mỗi tháng (đ)",Num("gia",12000000)),F("Tình trạng tu sửa",Check("sua"))},new[]{A("Thêm phòng",()=>S.Them("Phong",new[]{"MaPhong","MaTang","DienTich","Huong","DonGiaThang","DangSua"},V("mp"),V("tang"),N("dt"),V("huong"),N("gia"),B("sua"))),A("Nạp phòng đã chọn",()=>{var r=Row(Tables[1]);if(r==null)return;Set("mp",r["MaPhong"]);Set("sua",r["DangSua"]);}),A("Cập nhật đang sửa",()=>S.TinhTrangPhong(V("mp"),B("sua")))});
            var dv=Page("Dịch vụ",new[]{F("Mã dịch vụ",Txt("mdv","",20)),F("Tên dịch vụ",Txt("tdv","",100)),F("Đơn vị tính",Txt("dvt","kWh",30)),F("Đơn giá (đ)",Num("gdv",3000))},new[]{A("Thêm dịch vụ",()=>S.Them("DichVu",new[]{"MaDV","TenDV","DonViTinh","DonGia"},V("mdv"),V("tdv"),V("dvt"),N("gdv")))});
            Reload=()=>{tang.DataSource=S.DS("Tang");phong.DataSource=S.DS("Phong");dv.DataSource=S.DS("DichVu");Bind("tang",S.Chon("Tang"));};

        }
    }
}
