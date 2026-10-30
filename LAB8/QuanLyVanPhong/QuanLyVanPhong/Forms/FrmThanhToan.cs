using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace QuanLyVanPhong.Forms {
    public sealed class FrmThanhToan : ModuleForm {
        
        public FrmThanhToan() : base("Thu tiền thuê, dịch vụ và tiền phạt") {

            var no=Page("Công nợ và thu tiền",new[]{F("Mã thanh toán",Txt("tt",NewId("TT"),90)),F("Loại khoản thu",Combo("loai",new[]{"Tiền thuê","Dịch vụ","Phạt"})),F("Mã kỳ thuê / hóa đơn / phiếu phạt",Txt("khoan","HD001_P101_20261001",70)),F("Ngày thu / đối chiếu hạn",Date("ngay")),F("Số tiền thu (đ)",Num("tien",12000000)),F("Hình thức",Combo("ht",new[]{"Chuyển khoản","Tiền mặt"})),F("Người thu",Txt("nguoi","Kế toán",120)),F("Phạm vi danh sách",Check("all"))},new[]{A("Nạp khoản đã chọn",()=>{var r=Row(Tables[0]);if(r==null)return;Set("loai",r["Loai"]);Set("khoan",r["MaKhoan"]);Set("tien",r["ConLai"]);}),A("Ghi thanh toán",()=>S.ThuTien(V("tt"),V("loai"),V("khoan"),D("ngay"),N("tien"),V("ht"),V("nguoi"))),A("Tải lại",RefreshData),A("Mã thu mới",()=>Set("tt",NewId("TT")))});
            ((CheckBox)Fields["all"]).Text="Gồm cả kỳ chưa đến hạn";
            var ls=Page("Lịch sử thanh toán",new Tuple<string,Control>[0],new[]{A("Tải lại",RefreshData)});
            Reload=()=>{no.DataSource=S.CongNo(D("ngay"),B("all"));ls.DataSource=S.LichSuThu();};

        }
    }
}
