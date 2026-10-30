using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace QuanLyVanPhong.Forms {
    public sealed class FrmGiaHan : ModuleForm {
        
        public FrmGiaHan() : base("Lập phiếu gia hạn theo từng phòng") {

            var ds=Txt("ds","P101;6",1000);ds.Multiline=true;ds.Height=40;ds.ScrollBars=ScrollBars.Vertical;
            var gh=Page("Phiếu gia hạn",new[]{F("Số phiếu gia hạn",Txt("gh",NewId("GH"),20)),F("Hợp đồng",Combo("hd")),F("Ngày lập / kiểm tra công nợ",Date("ngay")),F("Người lập",Txt("nguoi","Bộ phận quản lý",120)),F("Phân bổ: MaPhong;SoThang mỗi dòng",ds)},new[]{A("Lập phiếu gia hạn",()=>S.LapGiaHan(V("gh"),V("hd"),D("ngay"),V("nguoi"),S.DocPhong(V("ds"),true))),A("Số phiếu mới",()=>Set("gh",NewId("GH"))),A("Tải lại",RefreshData)});
            var ct=Page("Chi tiết gia hạn",new[]{F("Số phiếu cần xem",Txt("xgh","GH001",20))},new[]{A("Xem chi tiết",RefreshData)});
            var phong=Page("Thời hạn phòng thuê",new[]{F("Hợp đồng cần xem",Combo("xhd"))},new[]{A("Xem thời hạn",RefreshData)});
            Reload=()=>{Bind("hd",S.Chon("HopDong"));Bind("xhd",S.Chon("HopDong"));gh.DataSource=S.DS("PhieuGiaHan");ct.DataSource=S.ChiTietGiaHan(V("xgh"));phong.DataSource=S.ChiTietThue(V("xhd"));};

        }
    }
}
