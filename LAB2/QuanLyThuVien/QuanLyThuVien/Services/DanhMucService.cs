using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyThuVien.Data;

namespace QuanLyThuVien.Services
{
    public class DanhMucService
    {
        public DataTable LayNhanVien()
        {
            return Db.Query(@"SELECT MaNhanVien, Ho, Ten, Phai, NgaySinh, ChucVu, SoDienThoai
 FROM NhanVien ORDER BY MaNhanVien");
        }

        public KetQuaXuLy LuuNhanVien(NhanVien nv, bool capNhat)
        {
            if (nv == null || string.IsNullOrWhiteSpace(nv.MaNhanVien) ||
                string.IsNullOrWhiteSpace(nv.Ho) || string.IsNullOrWhiteSpace(nv.Ten) ||
                string.IsNullOrWhiteSpace(nv.Phai) || string.IsNullOrWhiteSpace(nv.ChucVu))
                return KetQuaXuLy.Loi("Vui lòng nhập đầy đủ thông tin bắt buộc của nhân viên.");

            try
            {
                string sql = capNhat
                    ? @"UPDATE NhanVien SET Ho=@Ho,Ten=@Ten,Phai=@Phai,NgaySinh=@NgaySinh,ChucVu=@ChucVu,SoDienThoai=@SDT
 WHERE MaNhanVien=@Ma"
                    : @"INSERT INTO NhanVien(MaNhanVien,Ho,Ten,Phai,NgaySinh,ChucVu,SoDienThoai)
 VALUES(@Ma,@Ho,@Ten,@Phai,@NgaySinh,@ChucVu,@SDT)";

                int n = Db.Execute(sql,
                    new SqlParameter("@Ma", nv.MaNhanVien.Trim()),
                    new SqlParameter("@Ho", nv.Ho.Trim()),
                    new SqlParameter("@Ten", nv.Ten.Trim()),
                    new SqlParameter("@Phai", nv.Phai.Trim()),
                    new SqlParameter("@NgaySinh", nv.NgaySinh.Date),
                    new SqlParameter("@ChucVu", nv.ChucVu.Trim()),
                    new SqlParameter("@SDT", (object)(nv.SoDienThoai ?? string.Empty)));

                return n > 0
                    ? KetQuaXuLy.Ok(capNhat ? "Cập nhật nhân viên thành công." : "Thêm nhân viên thành công.")
                    : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    return KetQuaXuLy.Loi("Mã nhân viên đã tồn tại.");

                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        public DataTable LayTheLoai()
        {
            return Db.Query("SELECT MaTheLoai, TenTheLoai FROM TheLoai ORDER BY TenTheLoai");
        }

        public KetQuaXuLy LuuTheLoai(string ma, string ten, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
                return KetQuaXuLy.Loi("Mã và tên thể loại không được để trống.");

            try
            {
                string sql = capNhat
                    ? "UPDATE TheLoai SET TenTheLoai=@Ten WHERE MaTheLoai=@Ma"
                    : "INSERT INTO TheLoai(MaTheLoai,TenTheLoai) VALUES(@Ma,@Ten)";

                int n = Db.Execute(sql,
                    new SqlParameter("@Ma", ma.Trim()),
                    new SqlParameter("@Ten", ten.Trim()));

                return n > 0
                    ? KetQuaXuLy.Ok("Lưu thể loại thành công.")
                    : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    return KetQuaXuLy.Loi("Mã hoặc tên thể loại đã tồn tại.");

                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        public DataTable LayNhaXuatBan()
        {
            return Db.Query("SELECT MaNhaXuatBan, DiaChi, SoDienThoai FROM NhaXuatBan ORDER BY MaNhaXuatBan");
        }

        public KetQuaXuLy LuuNhaXuatBan(string ma, string diaChi, string sdt, bool capNhat)
        {
            if (string.IsNullOrWhiteSpace(ma))
                return KetQuaXuLy.Loi("Mã nhà xuất bản không được để trống.");

            try
            {
                string sql = capNhat
                    ? "UPDATE NhaXuatBan SET DiaChi=@DiaChi,SoDienThoai=@SDT WHERE MaNhaXuatBan=@Ma"
                    : "INSERT INTO NhaXuatBan(MaNhaXuatBan,DiaChi,SoDienThoai) VALUES(@Ma,@DiaChi,@SDT)";

                int n = Db.Execute(sql,
                    new SqlParameter("@Ma", ma.Trim()),
                    new SqlParameter("@DiaChi", (object)(diaChi ?? string.Empty)),
                    new SqlParameter("@SDT", (object)(sdt ?? string.Empty)));

                return n > 0
                    ? KetQuaXuLy.Ok("Lưu nhà xuất bản thành công.")
                    : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    return KetQuaXuLy.Loi("Mã nhà xuất bản đã tồn tại.");

                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        public KetQuaXuLy Xoa(string bang, string cotMa, string ma)
        {
            string[] bangChoPhep = { "NhanVien", "TheLoai", "NhaXuatBan" };
            string[] cotChoPhep = { "MaNhanVien", "MaTheLoai", "MaNhaXuatBan" };

            int index = Array.IndexOf(bangChoPhep, bang);

            if (index < 0 || cotChoPhep[index] != cotMa)
                return KetQuaXuLy.Loi("Tham số xóa không hợp lệ.");

            try
            {
                int n = Db.Execute(
                    "DELETE FROM " + bang + " WHERE " + cotMa + "=@Ma",
                    new SqlParameter("@Ma", ma));

                return n > 0
                    ? KetQuaXuLy.Ok("Xóa dữ liệu thành công.")
                    : KetQuaXuLy.Loi("Không tìm thấy dữ liệu để xóa.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    return KetQuaXuLy.Loi("Không thể xóa vì dữ liệu đang được sử dụng ở nghiệp vụ khác.");

                return KetQuaXuLy.Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}