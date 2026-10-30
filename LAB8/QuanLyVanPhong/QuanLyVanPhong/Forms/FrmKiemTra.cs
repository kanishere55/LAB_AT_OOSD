using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace QuanLyVanPhong.Forms {
    public sealed class FrmKiemTra : ModuleForm {
        
        public FrmKiemTra() : base("Kiểm tra định kỳ, tu sửa và xử phạt") {

            var dot=Page("Đợt kiểm tra",new[]{F("Số đợt",Txt("dot",NewId("KT"),20)),F("Ngày kiểm tra",Date("ngay")),F("Người kiểm tra",Txt("nguoi","Bộ phận kỹ thuật",120)),F("Nội dung",Txt("nd","Kiểm tra định kỳ tình trạng văn phòng",500))},new[]{A("Lập đợt kiểm tra",()=>S.Them("DotKiemTra",new[]{"SoDot","NgayKiemTra","NguoiKiemTra","NoiDung"},V("dot"),D("ngay"),V("nguoi"),V("nd")))});
            var ct=Page("Kết quả từng phòng",new[]{F("Đợt kiểm tra",Combo("xdot")),F("Phòng kiểm tra",Combo("phong")),F("Tình trạng thực tế",Txt("tt","Bình thường",500)),F("Nhu cầu tu sửa",Check("sua")),F("Vi phạm tự sửa kết cấu",Check("vp")),F("Đề xuất xử lý",Txt("dx","Tiếp tục theo dõi",500))},new[]{A("Lưu kết quả",()=>S.Them("ChiTietKiemTra",new[]{"SoDot","MaPhong","TinhTrang","CanTuSua","ViPhamKetCau","DeXuat"},V("xdot"),V("phong"),V("tt"),B("sua"),B("vp"),V("dx")))});
            var phat=Page("Phiếu xử phạt",new[]{F("Số phiếu phạt",Txt("phat",NewId("PP"),20)),F("Đợt đã xác nhận vi phạm",Combo("pdot")),F("Hợp đồng chịu trách nhiệm",Combo("hd")),F("Phòng vi phạm",Combo("pphong")),F("Ngày lập phiếu",Date("lap")),F("Số tiền theo quy định (đ)",Num("tien",2000000)),F("Nội dung vi phạm",Txt("pnd","Tự ý thay đổi kết cấu văn phòng",500))},new[]{A("Lập phiếu phạt",()=>S.Proc("LapPhieuPhat",new[]{"SoPhat","SoDot","SoHD","MaPhong","NgayLap","NoiDung","SoTien"},V("phat"),V("pdot"),V("hd"),V("pphong"),D("lap"),V("pnd"),N("tien")))});
            Reload=()=>{Bind("xdot",S.Chon("DotKiemTra"));Bind("pdot",S.Chon("DotKiemTra"));Bind("phong",S.Chon("Phong"));Bind("pphong",S.Chon("Phong"));Bind("hd",S.Chon("HopDong"));dot.DataSource=S.DS("DotKiemTra");ct.DataSource=S.DS("ChiTietKiemTra");phat.DataSource=S.DS("PhieuPhat");};

        }
    }
}
