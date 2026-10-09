# Truy vết hiện thực LAB5

Các số hình P.x bên dưới là tham chiếu trong đề Bai_6_Quan_ly_cong_ty_du_lich.docx. Mã nguồn hiện thực UI → Service → Data; test case gọi Service và đối chiếu dữ liệu SQL. Bộ kiểm thử tạo database riêng, không sửa dữ liệu ứng dụng.

| Yêu cầu | Hình UML trong đề | Form | Service | Bảng CSDL | Kiểm thử |
| --- | --- | --- | --- | --- | --- |
| Danh mục | P.1, P.4 | FrmDanhMuc | DanhMucService | PhuongTien, DiemBanVe, HuongDanVien, DiemThamQuan | TC01 |
| Tour, điểm dừng, phương tiện, điểm tham quan; BR01–02 | P.3, P.14 | FrmTour | TourService | Tour, TourDiemDung, TourPhuongTien, TourDiemThamQuan | TC02–03, EX-HOTEL |
| Khách lẻ, tính ngày về, thu tiền ngay; BR03, QD01–02 | P.2, P.8, P.15 | FrmChuyenLe, FrmDangKyLe | ChuyenLeService, DangKyLeService | ChuyenLe, DangKyLe | TC04–07, TC04-DATE, TC05-MONEY |
| Đoàn, cọc, bảo hiểm, hủy mất cọc; BR04–05 | P.2, P.5, P.7, P.16, P.20 | FrmDangKyDoan | DangKyDoanService | DoanKhach, DangKyDoan, ThanhVienDoan | TC08–12, TC08-DATA, TC12-DATA, EX-ROLLBACK, EX-DEPOSIT |
| Một HDV/chuyến lẻ; đoàn nhiều HDV; không trùng lịch; BR06 | P.9, P.17 | FrmPhanCongHDV | PhanCongService | PhanCongHDV, HuongDanVien | TC13–16, EX-INACTIVE |
| Thanh toán sau tour, không quá số còn phải trả; BR04 | P.10, P.18 | FrmKetThucKhaoSat | KetThucService | DangKyDoan, ThanhToanDoan | TC17–19, TC18-DATA, EX-PAID-AGAIN |
| Khảo sát sau tour, tối đa một phiếu, điểm 1–5; BR08 | P.6, P.11, P.18 | FrmKetThucKhaoSat | KetThucService | KhaoSat, DangKyLe, DangKyDoan | TC20–22, EX-SURVEY-DUP, EX-RATING, EX-RESPONSE-DATE, EX-FUTURE |
| Lương căn bản + thù lao tour kết thúc trong tháng; BR07 | P.12, P.19 | FrmLuongThongKe | ThongKeService | HuongDanVien, PhanCongHDV | TC23 |
| Tổng hợp theo khoảng ngày | P.19 | FrmLuongThongKe | ThongKeService | DangKyLe, DangKyDoan, ThanhToanDoan, KhaoSat | TC24 |
| Giao diện theo mẫu P.23–P.35 | P.22 điều hướng | 9 Form và các tab | Các Service đọc dữ liệu | 16 bảng | FormResults.txt; Evidence gồm 18 ảnh |

Kết quả kiểm thử chi tiết được lưu trong Tests/TestResults.txt và Tests/FormResults.txt. Không có SQL trong các Form; Data/Db.cs quản lý kết nối, truy vấn tham số và transaction dùng chung.
