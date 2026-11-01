# LAB4 — Hệ thống cửa hàng online e-SHOPPING

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.

## Nội dung đã thực hiện

Phân tích hệ thống e-SHOPPING của cửa hàng ABC, xác định các chức năng trong ứng dụng và ba hệ thống bên ngoài: quản lý sản phẩm, thanh toán trực tuyến, email.

Báo cáo trình bày pha phân tích và pha thiết kế, gồm biểu đồ use case, lớp phân tích, trạng thái, tuần tự, lớp thiết kế chi tiết, thiết kế riêng từng chức năng và hoạt động. Thư mục `../IMAGES/LAB4` có 11 file draw.io cho các sơ đồ e-SHOPPING trong báo cáo và 1 file cho sơ đồ lớp của bài tập tổng hợp nhân viên kinh doanh – đơn hàng. Mỗi sơ đồ nằm trong một file riêng.

Ứng dụng C# WinForms tổ chức theo UI → Service/Adapter → Data. Giỏ lưu theo phiên; tài khoản và đơn hàng lưu trên SQL Server. Danh mục sản phẩm mô phỏng nguồn bên ngoài trong schema catalog. Thanh toán và email dùng adapter giả lập; không trừ tiền hoặc gửi email thật.

| Form | Chức năng |
| --- | --- |
| FrmMain | Mở các chức năng sản phẩm, giỏ hàng, tài khoản, tính tiền |
| FrmSanPham | Lọc nhóm, tìm kiếm, chọn số lượng và thêm giỏ |
| FrmChiTietSanPham | Xem thông tin, chuyển nhiều ảnh và thêm giỏ |
| FrmGioHang | Sửa số lượng, xóa dòng, tính tiền hàng và bắt đầu đặt hàng |
| FrmTaiKhoan | Đăng ký, đăng nhập; email không bắt buộc |
| FrmCheckout | Nhập người nhận, chọn khu vực, loại giao và tính phí |
| FrmThanhToan | Chọn thẻ, kiểm tra dữ liệu và xác nhận thanh toán |
| FrmXacNhanDonHang | Hiển thị đơn đã lưu, tổng tiền, giao dịch và trạng thái email |

CSDL có **9 bảng**: 6 bảng tài khoản, phí giao, đơn hàng, chi tiết, thanh toán, email và 3 bảng danh mục mô phỏng. Đơn, chi tiết và thanh toán được ghi cùng transaction; chỉ sau commit mới xóa giỏ. CSDL lưu loại thẻ, bốn số cuối và mã giao dịch, không lưu số thẻ đầy đủ hoặc CSV.

## Môi trường và phiên bản

| Thành phần | Cấu hình đã kiểm tra |
| --- | --- |
| Hệ điều hành | Windows 11 |
| IDE/build | Visual Studio Community 2022, dòng 17.14; MSBuild đi kèm |
| Project | C#, Windows Forms, .NET Framework **4.7.2** |
| Truy cập CSDL | ADO.NET, System.Data.SqlClient |
| SQL Server | SQL Server 2022, **16.0.1000.6** |
| Instance trên máy | `.\MSSQLSERVER01` |
| Database | `QuanLyCuaHangOnline` |
| Xác thực | Windows Authentication |

Visual Studio cần workload .NET desktop development và targeting/developer pack .NET Framework 4.7.2.

## Các file chính

- [Báo cáo Word](1250080021_NguyenThanhCan_CNPM1_LAB04.docx): nội dung phân tích, thiết kế, SQL, giao diện và các quy tắc hiện thực.
- [Bài tập](1250080021_NguyenThanhCan_CNPM1_BT.docx): chuyển sơ đồ lớp nhân viên kinh doanh – đơn hàng sang lược đồ cơ sở dữ liệu.
- [12 sơ đồ draw.io riêng](../IMAGES/LAB4): mở bằng diagrams.net; các lớp, thuộc tính, đường nối và nhãn đều sửa được.
- [Solution](QuanLyCuaHangOnline/QuanLyCuaHangOnline.sln).
- [Script khởi tạo CSDL](Database/SQL.sql).
- [Cấu hình kết nối](QuanLyCuaHangOnline/QuanLyCuaHangOnline/App.config).
- Ảnh giao diện thực chạy nằm trong báo cáo Word.

## Hướng dẫn kiểm tra và chạy lại

1. Mở SQL Server Management Studio, kết nối instance SQL Server trên máy bằng tài khoản có quyền tạo database. Mở và chạy toàn bộ `Database/SQL.sql`. Script tạo CSDL, bảng, ràng buộc và dữ liệu danh mục/phí giao mẫu; có thể chạy lại mà không xóa các đơn đã lưu.
2. Mở solution trong Visual Studio. Trong `App.config`, giữ `Initial Catalog=QuanLyCuaHangOnline` và đổi `Data Source` sang instance của máy nếu cần. Cấu hình hiện tại dùng `.\MSSQLSERVER01` và `Integrated Security=True`.
3. Chọn cấu hình **Release**, chạy Rebuild Solution, rồi Start. Màn hình chính xuất hiện khi kết nối CSDL thành công.
4. Mở sản phẩm, thêm **SP01** số lượng **2**, rồi mở giỏ. Đăng ký tài khoản mới và đăng nhập; email có thể bỏ trống. Chọn nội thành, giao nhanh: tiền hàng 1.000.000 đ, phí giao 0 đ.
5. Nhập thông tin người nhận, tiếp tục thanh toán. Dữ liệu thử giả lập: VISA `4111111111111111`, tên chủ thẻ bất kỳ, hạn tháng/năm còn hiệu lực và CSV `123`. Sau khi chấp nhận, ứng dụng hiển thị mã đơn và giỏ trống.
6. Để thử từ chối thanh toán, dùng CSV `000` với VISA đúng định dạng. Ứng dụng giữ giỏ và không ghi đơn. Có thể sửa CSV thành `123` và xác nhận lại.
7. Kiểm tra các bảng DonHang, ChiTietDonHang, ThanhToan trong SSMS. Đối chiếu TienHang với tổng ThanhTien của chi tiết; đối chiếu TongTien với SoTien thanh toán. Có email thì kiểm tra thêm bảng EmailXacNhan.

## Kết quả

- Rebuild Release thành công với target .NET Framework 4.7.2.
- Chạy đủ **8 Form**: kết nối SQL, nạp dữ liệu, giỏ hàng theo phiên, tính phí giao, che mật khẩu/CSV và đọc lại đơn đã lưu đều hoạt động đúng.
- Đã thử các trường hợp giỏ trống, chưa đăng nhập, sai thông tin thẻ, thanh toán bị từ chối, giá đổi/hết hàng, miễn phí giao đúng ngưỡng, rollback khi lỗi, email gửi thất bại và gửi lại cùng mã yêu cầu.

## Lỗi gặp và cách khắc phục

| Tình huống | Cách xử lý |
| --- | --- |
| Kết nối lỗi do tên instance hoặc chưa tạo CSDL | Chạy SQL.sql trên đúng instance; điều chỉnh Data Source trong App.config |
| Thẻ bị từ chối, sửa CSV rồi xác nhận lại cùng yêu cầu | Adapter chỉ lưu kết quả đã được chấp nhận; kết quả từ chối không chặn lần thử sau |
| Giá thay đổi sau khi thêm giỏ | Đọc lại giá, cập nhật giỏ và yêu cầu xác nhận lại trước thanh toán |
| Dịch vụ email lỗi sau khi lưu đơn | Ghi trạng thái LoiGui; giữ nguyên đơn đã commit |

[Quay về danh sách bài Lab](../README.md).
