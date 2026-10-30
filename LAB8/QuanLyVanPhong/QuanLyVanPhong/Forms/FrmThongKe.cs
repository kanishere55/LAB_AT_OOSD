using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace QuanLyVanPhong.Forms {
    public sealed class FrmThongKe : ModuleForm {
        void Xuat(DataGridView g){using(var d=new SaveFileDialog{Filter="CSV|*.csv",FileName="ThongKe.csv"})if(d.ShowDialog(this)==DialogResult.OK){var b=new StringBuilder();var cols=new System.Collections.Generic.List<DataGridViewColumn>();foreach(DataGridViewColumn c in g.Columns)if(c.Visible)cols.Add(c);b.AppendLine(string.Join(",",cols.ConvertAll(c=>Csv(c.HeaderText))));foreach(DataGridViewRow r in g.Rows)b.AppendLine(string.Join(",",cols.ConvertAll(c=>Csv(Convert.ToString(r.Cells[c.Index].Value)))));File.WriteAllText(d.FileName,b.ToString(),new UTF8Encoding(true));}}
        string Csv(string s){return "\""+s.Replace("\"","\"\"")+"\"";}
        public FrmThongKe() : base("Thống kê phòng, thu tiền và lịch kiểm tra") {

            var phong=Page("Tình trạng phòng",new[]{F("Ngày cần tra cứu",Date("ngay"))},new[]{A("Tra cứu",RefreshData),A("Xuất CSV",()=>Xuat(Tables[0]))});
            var kt=Page("Hạn kiểm tra hàng năm",new[]{F("Ngày đối chiếu",Date("ktngay"))},new[]{A("Kiểm tra hạn",RefreshData),A("Xuất CSV",()=>Xuat(Tables[1]))});
            var thu=Page("Tiền đã thu",new[]{F("Từ ngày",Date("tu",new DateTime(2026,1,1))),F("Đến ngày",Date("den"))},new[]{A("Thống kê",RefreshData),A("Xuất CSV",()=>Xuat(Tables[2]))});
            Reload=()=>{if(D("tu")>D("den"))throw new Exception("Ngày bắt đầu phải trước ngày kết thúc.");phong.DataSource=S.PhongTaiNgay(D("ngay"));kt.DataSource=S.CanKiemTra(D("ktngay"));thu.DataSource=S.DoanhThu(D("tu"),D("den"));};

        }
    }
}
