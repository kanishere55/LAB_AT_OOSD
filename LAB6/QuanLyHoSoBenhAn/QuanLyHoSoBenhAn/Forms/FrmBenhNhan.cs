using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyHoSoBenhAn.Services;

namespace QuanLyHoSoBenhAn.Forms
{
    public sealed class FrmBenhNhan : ModuleForm
    {
        byte[] photo;
        PictureBox picture;
        public FrmBenhNhan() : base("Bệnh nhân • Đăng ký lần đầu và lệ phí năm")
        {
            var photoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 48
            };
            picture = new PictureBox
            {
                Width = 42,
                Dock = DockStyle.Left,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };
            var choose = new Button
            {
                Text = "Chọn ảnh 3×4",
                Dock = DockStyle.Fill
            };
            choose.Click += (s, e) =>
            {
                using (var d = new OpenFileDialog
                {
                    Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp"
                }

                )
                    if (d.ShowDialog() == DialogResult.OK)
                        Run(() =>
                        {
                            var bytes = File.ReadAllBytes(d.FileName);
                            using (var stream = new MemoryStream(bytes))
                            using (var img = Image.FromStream(stream))
                            {
                                if (picture.Image != null)
                                    picture.Image.Dispose();
                                picture.Image = new Bitmap(img);
                            }

                            photo = bytes;
                        }, "Đã chọn ảnh.");
            };
            photoPanel.Controls.Add(choose);
            photoPanel.Controls.Add(picture);
            var a = Page("Đăng ký và cấp hồ sơ", new[] { F("Mã bệnh nhân", Txt("bn", NewId("BN"), 20)), F("Họ và tên", Txt("ten", "", 100)), F("Ngày sinh", Date("sinh", new DateTime(2000, 1, 1))), F("Địa chỉ", Txt("dc", "", 250)), F("Điện thoại", Txt("dt", "", 20)), F("Ảnh 3×4", photoPanel), F("Mã đăng ký", Txt("dk", NewId("DK"), 20)), F("Mã hồ sơ", Txt("hs", NewId("HS"), 20)), F("Mã thu lệ phí", Txt("thu", NewId("LP"), 20)), F("Ngày đăng ký / bắt đầu quyền lợi", Date("ngay")), F("Lệ phí năm (đồng)", Num("tien", 100000)) }, new[] { A("Đăng ký + cấp hồ sơ", () => S.DangKy(new BenhNhanInput { Ma = V("bn"), HoTen = V("ten"), NgaySinh = D("sinh"), DiaChi = V("dc"), DienThoai = V("dt"), Anh = photo, MaDangKy = V("dk"), MaHoSo = V("hs"), MaThu = V("thu"), Ngay = D("ngay"), SoTien = N("tien") })), A("Cập nhật nhân thân", () => S.SuaBenhNhan(V("bn"), V("ten"), D("sinh"), V("dc"), V("dt"), photo)), A("Bệnh nhân mới", () =>
            {
                Set("bn", NewId("BN"));
                Set("dk", NewId("DK"));
                Set("hs", NewId("HS"));
                Set("thu", NewId("LP"));
                Set("ten", "");
                Set("dc", "");
                Set("dt", "");
                photo = null;
                if (picture.Image != null)
                {
                    picture.Image.Dispose();
                    picture.Image = null;
                }
            }) });
            a.CellClick += (s, e) =>
            {
                var r = Row(a);
                if (r == null)
                    return;
                Set("bn", r["Mã BN"]);
                Set("ten", r["Họ tên"]);
                Set("sinh", r["Ngày sinh"]);
                Set("dc", r["Địa chỉ"]);
                Set("dt", r["Điện thoại"]);
                Set("hs", r["Mã hồ sơ"]);
                photo = S.Anh(V("bn"));
                if (photo != null)
                    using (var stream = new MemoryStream(photo))
                    {
                        using (var img = Image.FromStream(stream))
                        {
                            if (picture.Image != null)
                                picture.Image.Dispose();
                            picture.Image = new Bitmap(img);
                        }
                    }
            };
            var b = Page("Thu lệ phí năm tiếp theo", new[] { F("Mã bệnh nhân đã có", Txt("bnphi", "BN001", 20)), F("Mã thu lệ phí mới", Txt("maphi", NewId("LP"), 20)), F("Bắt đầu thời hạn một năm", Date("tu", DateTime.Today.AddYears(1))), F("Số tiền (đồng)", Num("phimoi", 100000)) }, new[] { A("Ghi nhận thu lệ phí", () => S.ThuPhi(V("maphi"), V("bnphi"), D("tu"), N("phimoi"))) });
            var c = Page("Tìm bệnh nhân", new[] { F("Mã hồ sơ, mã BN, họ tên hoặc điện thoại", Txt("tim", "", 100)) }, new[] { A("Tìm kiếm", () =>
            {
            }), A("Tải lại", () => Set("tim", "")) });
            Reload = () =>
            {
                a.DataSource = S.BenhNhan();
                b.DataSource = S.LePhi();
                c.DataSource = S.BenhNhan(V("tim"));
            };
        }
    }
}
