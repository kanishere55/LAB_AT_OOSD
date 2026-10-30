using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace QuanLyVanPhong.Forms {
    public sealed class FrmNhanVien : ModuleForm {
        byte[] PhotoBytes;
        PictureBox Photo;
        void SetPhoto(byte[] data){if(data==null)return;using(var stream=new MemoryStream(data))using(var img=Image.FromStream(stream)){var old=Photo.Image;Photo.Image=new Bitmap(img);if(old!=null)old.Dispose();}}
        protected override void Dispose(bool disposing){if(disposing&&Photo!=null&&Photo.Image!=null)Photo.Image.Dispose();base.Dispose(disposing);}
        public FrmNhanVien() : base("Nhân viên công ty thuê và thẻ giữ xe") {

            var photo=new Panel{Dock=DockStyle.Top,Height=40};
            Photo=new PictureBox{SizeMode=PictureBoxSizeMode.Zoom,Dock=DockStyle.Left,Width=58,BackColor=Color.WhiteSmoke};
            var choose=new Button{Text="Chọn ảnh…",Dock=DockStyle.Right,Width=115};
            choose.Click+=(a,b)=>{using(var d=new OpenFileDialog{Filter="Ảnh nhân viên|*.png;*.jpg;*.jpeg;*.bmp"})if(d.ShowDialog(this)==DialogResult.OK)Run(()=>{var bytes=File.ReadAllBytes(d.FileName);if(bytes.Length>5*1024*1024)throw new Exception("Ảnh tối đa 5 MB.");SetPhoto(bytes);PhotoBytes=bytes;},"Đã chọn ảnh nhân viên.");};
            photo.Controls.Add(Photo);photo.Controls.Add(choose);
            var nv=Page("Báo cáo nhân viên",new[]{F("Mã nhân viên",Txt("nv",NewId("NV"),20)),F("Họ tên",Txt("ten","",120)),F("Công ty",Combo("kh")),F("Phòng làm việc",Combo("phong")),F("Chức vụ",Txt("cv","Nhân viên",100)),F("Ngày báo cáo",Date("ngay")),F("Hình ảnh (tối đa 5 MB)",photo)},new[]{A("Lưu nhân viên",()=>S.Proc("GhiNhanVien",new[]{"MaNV","HoTen","MaKH","MaPhong","ChucVu","NgayBaoCao","HinhAnh"},V("nv"),V("ten"),V("kh"),V("phong"),V("cv"),D("ngay"),PhotoBytes)),A("Xem ảnh người đã chọn",()=>{var r=Row(Tables[0]);if(r!=null)SetPhoto(S.Anh(Convert.ToString(r["MaNV"])));})});
            var xe=Page("Cấp thẻ giữ xe",new[]{F("Mã thẻ",Txt("the",NewId("TX"),20)),F("Nhân viên",Combo("xnv")),F("Biển số",Txt("bs","",20)),F("Loại xe",Combo("loai",new[]{"Xe máy","Ô tô","Xe đạp"})),F("Nhãn hiệu",Txt("nh","",80)),F("Màu xe",Txt("mau","",50)),F("Ngày cấp",Date("cap"))},new[]{A("Cấp thẻ",()=>S.Proc("CapTheXe",new[]{"MaThe","MaNV","BienSo","LoaiXe","NhanHieu","MauXe","NgayCap"},V("the"),V("xnv"),V("bs"),V("loai"),V("nh"),V("mau"),D("cap")))});
            nv.CellClick+=(a,b)=>{if(b.RowIndex>=0)Run(()=>{var r=Row(nv);if(r!=null)SetPhoto(S.Anh(Convert.ToString(r["MaNV"])));},"Đã hiển thị ảnh.");};
            Reload=()=>{Bind("kh",S.Chon("KhachHang"));Bind("phong",S.Chon("Phong"));Bind("xnv",S.Chon("NhanVien"));nv.DataSource=S.NhanVien();xe.DataSource=S.TheXe();if(Photo.Image==null&&nv.Rows.Count>0)SetPhoto(S.Anh(Convert.ToString(nv.Rows[0].Cells["MaNV"].Value)));};

        }
    }
}
