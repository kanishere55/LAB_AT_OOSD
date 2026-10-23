# Bằng chứng chạy LAB6

Ảnh ghi ngày 16/10/2026 từ Form WinForms đang hiển thị, truy vấn CSDL `QuanLyHoSoBenhAn`. Các cửa sổ được ghi bằng `Form.DrawToBitmap`; 20 ảnh ứng dụng và 2 ảnh metadata SQL. Hai ảnh cuối dùng cửa sổ kiểm tra truy vấn SQL riêng, không phải SSMS. Dữ liệu đều là mẫu thực hành.

| Ảnh | Nội dung |
| --- | --- |
| [01_Main.png](01_Main.png) | Màn hình chính và tổng hợp dữ liệu SQL Server |
| [02_FrmBenhNhan_1.png](02_FrmBenhNhan_1.png) | Đăng ký bệnh nhân và cấp hồ sơ cùng lệ phí năm |
| [02_FrmBenhNhan_2.png](02_FrmBenhNhan_2.png) | Ghi nhận lệ phí năm tiếp theo và xem thời hạn |
| [02_FrmBenhNhan_3.png](02_FrmBenhNhan_3.png) | Tra cứu bệnh nhân bằng mã hoặc thông tin liên hệ |
| [03_FrmKhamBenh_1.png](03_FrmKhamBenh_1.png) | Tiếp nhận và lập phiếu khám theo hồ sơ |
| [03_FrmKhamBenh_2.png](03_FrmKhamBenh_2.png) | Nạp và ghi nội dung khám, theo dõi điều trị |
| [04_FrmXetNghiem_1.png](04_FrmXetNghiem_1.png) | Lập chỉ định xét nghiệm theo phiếu khám |
| [04_FrmXetNghiem_2.png](04_FrmXetNghiem_2.png) | Ghi kết quả và ngày trả xét nghiệm |
| [05_FrmToaThuoc_1.png](05_FrmToaThuoc_1.png) | Soạn dòng thuốc trước khi lưu toa |
| [05_FrmToaThuoc_2.png](05_FrmToaThuoc_2.png) | Danh sách toa đã lưu và chức năng xuất toa |
| [06_FrmLichHen_1.png](06_FrmLichHen_1.png) | Lịch định kỳ theo hồ sơ và quý khám |
| [07_FrmHoanTat_1.png](07_FrmHoanTat_1.png) | Xác nhận thủ tục và hoàn tất đợt điều trị |
| [08_FrmLichSu_1.png](08_FrmLichSu_1.png) | Lịch sử phân biệt đợt đang điều trị và đã hoàn tất |
| [08_FrmLichSu_2.png](08_FrmLichSu_2.png) | Xét nghiệm của lần khám được chọn |
| [08_FrmLichSu_3.png](08_FrmLichSu_3.png) | Các toa thuốc theo hồ sơ |
| [08_FrmLichSu_4.png](08_FrmLichSu_4.png) | Chi tiết thuốc, số lượng, liều và cách dùng của toa |
| [09_FrmDanhMuc_1.png](09_FrmDanhMuc_1.png) | Danh mục khoa |
| [09_FrmDanhMuc_2.png](09_FrmDanhMuc_2.png) | Danh mục bác sĩ |
| [09_FrmDanhMuc_3.png](09_FrmDanhMuc_3.png) | Danh mục thuốc |
| [09_FrmDanhMuc_4.png](09_FrmDanhMuc_4.png) | Danh mục loại xét nghiệm |
| [10_Database_Tables.png](10_Database_Tables.png) | Đối chiếu 13 bảng, khóa chính và số dòng trong CSDL thực tế |
| [11_Database_ForeignKeys.png](11_Database_ForeignKeys.png) | Đối chiếu các cột khóa ngoại trong CSDL thực tế |

- [Kết quả kiểm tra Form](FormResults.csv).
- [Metadata bảng](10_Database_Tables.csv).
- [Metadata khóa ngoại](11_Database_ForeignKeys.csv).
- Chạy lại: build Release, nạp SQL/seed, chạy [Capture-Forms.ps1](../Tests/Capture-Forms.ps1). Ảnh được chèn trong báo cáo A4; mở PNG để xem toàn bộ độ phân giải.
