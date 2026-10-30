# LAB8 — Quản lý cho thuê văn phòng cao ốc

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.
- Ngày thực hiện: **30/10/2026**.
- Đề: **Bài 4 — Quản lý cho thuê văn phòng ở cao ốc**.

## Nội dung và kết quả

Phân tích phòng theo tầng, hợp đồng nhiều phòng, thu trước 6 tháng, thu tiền thuê từ tháng 7, dịch vụ cuối tháng, gia hạn có kiểm tra công nợ, nhân viên có ảnh, thẻ xe và kiểm tra tình trạng phòng hàng năm.

- Báo cáo trả lời đủ 6 câu, trình bày pha phân tích → pha thiết kế → SQL Server → WinForms → kiểm thử và truy vết.
- **18 lớp/bảng**, **23 quan hệ khóa ngoại**, PK/FK/UNIQUE/CHECK; **9 stored procedure** gồm 8 nghiệp vụ và thủ tục hỗ trợ tạo kỳ thuê; 1 TVP và 1 view công nợ.
- **22 sơ đồ**, mỗi sơ đồ một file `.drawio` riêng: 3 lớp phân tích, 1 UC tổng quát, 3 UC phân rã chức năng, 1 trạng thái, 3 Sequence, 1 lớp thiết kế tổng thể, 4 thiết kế module, 3 Activity và 3 ERD.
- **9 Form**, 8 module, 23 màn hình/tab. Form chính 2 cột, 8 nút chức năng và nút Thoát.
- Build Release thành công; **49/49** kiểm tra nghiệp vụ/CSDL, **11/11** luồng ghi từ nút Form và **324/324** kiểm tra Form đạt.
- Word A4 dọc, không footer; có 23 ảnh Form/tab và 2 ảnh đối chiếu CSDL thực chạy. Ảnh lấy bằng DrawToBitmap từ Form đang chạy với SQL Server; ảnh CSDL là cửa sổ hiển thị kết quả truy vấn metadata.

## Các file chính

- [Báo cáo Word](1250080021_NguyenThanhCan_CNPM1_LAB8.docx).
- [Đề bài](Bai_4_Cho_thue_van_phong_cao_oc.docx).
- [Solution](QuanLyVanPhong/QuanLyVanPhong.sln).
- [Cấu hình kết nối](QuanLyVanPhong/QuanLyVanPhong/App.config).
- [SQL cấu trúc, thủ tục và dữ liệu mẫu](Database/QuanLyVanPhong.sql).
- [Thư mục 22 sơ đồ draw.io riêng](UML).

## Môi trường

Windows 11; Visual Studio Community 2022; C# WinForms **.NET Framework 4.7.2**, Any CPU; ADO.NET `System.Data.SqlClient`; SQL Server 2022 Developer **16.0.1000.6**, instance `.\MSSQLSERVER01`, Windows Authentication. CSDL ứng dụng **QuanLyVanPhong**, CSDL kiểm thử **QuanLyVanPhong_Test**.

Project không cần NuGet. Visual Studio cần workload **.NET desktop development** và targeting pack .NET Framework 4.7.2.

Form gọi `VanPhongService`; Service kiểm tra danh sách và chuyển tham số/TVP tới `Data/Db`. SQL Server xử lý transaction và các điều kiện liên quan nhiều bảng. Lớp thực thể trong UML mô tả dữ liệu nghiệp vụ; C# hiện thực bằng DataTable và Service. Chưa có đăng nhập/phân quyền cho từng vai trò.

## Cài đặt và chạy

1. Trong SSMS, kết nối SQL Server bằng tài khoản có quyền tạo database. Chạy toàn bộ `Database/QuanLyVanPhong.sql`. File có cấu trúc và dữ liệu mẫu ở cuối; không xóa bảng hay ghi đè seed đã tồn tại.
2. Mở solution trong Visual Studio. Kiểm tra chuỗi kết nối trong App.config:

   ```text
   Data Source=.\MSSQLSERVER01;Initial Catalog=QuanLyVanPhong;Integrated Security=True;TrustServerCertificate=True
   ```

3. Nếu máy dùng instance khác, sửa `Data Source` cho đúng nơi đã chạy SQL, rồi Rebuild cấu hình Release.
4. Đặt QuanLyVanPhong làm Startup Project, nhấn F5 hoặc Ctrl+F5.
5. Mở các module từ màn hình chính. Mã và ngày trong các ô nhập có thể thay đổi trước khi lưu; khi ghi mới phải dùng mã chưa tồn tại.

## Dữ liệu mẫu và trình tự kiểm tra

| Module | Dữ liệu và kết quả đối chiếu |
| --- | --- |
| Danh mục | T01/T02; P101 80 m², 12 triệu/tháng; P102 60 m², 8 triệu; P201 100 m², 15 triệu; P202 120 m², 18 triệu, còn trống tại 30/10/2026. |
| Hợp đồng | HD001/KH001 thuê P101 và P102 trong 12 tháng từ 01/04/2026, hạn gốc 31/03/2027. Thu trước 6 tháng: **120.000.000 đ**. |
| Tiền thuê | Hai kỳ từ 01/10/2026 của HD001 còn nợ 12 triệu và 8 triệu, tổng **20 triệu**. Chọn dòng → Nạp khoản đã chọn → nhập mã thu mới → Ghi thanh toán. |
| Dịch vụ | DV092026/P101: 100 kWh × 3.000 + Internet 250.000 = **550.000 đ**, 2 dòng, chưa thanh toán. SD003/P102: nước 5 m³ × 15.000, ngày 20/10/2026, chưa lập hóa đơn. |
| Gia hạn | HD002/KH002 thuê P201 6 tháng từ 01/05/2026, trả trước **90 triệu**. GH001 ngày 30/10/2026 gia hạn 3 tháng đến **31/01/2027**, tạo 3 kỳ 15 triệu. |
| Nhân viên/thẻ xe | NV001 thuộc KH001, phòng P101; có ảnh biểu trưng thực hành lưu trong CSDL và thẻ TX001. Khi nhập hồ sơ mới, chọn ảnh PNG/JPG/BMP tối đa 5 MB. |
| Kiểm tra/phạt | KT2026 ngày 15/10/2026; P101 vi phạm kết cấu, PP001 **2 triệu**; P201 bình thường. Theo dõi hạn kiểm tra lại sau 1 năm tại Thống kê. |

Tên, mã số thuế, liên hệ, biển số và ảnh biểu trưng trong seed là dữ liệu thực hành.

Kịch bản kiểm tra gia hạn HD001/P101:

1. Thử lập gia hạn khi kỳ tháng 10 chưa trả: bị từ chối do còn nợ tiền thuê.
2. Thu 5 triệu cho kỳ P101: còn 7 triệu. Thu 8 triệu bị từ chối; thu đúng 7 triệu thì kỳ hết nợ.
3. Thử gia hạn tiếp: bị từ chối khi DV092026 chưa trả đủ. Thu đủ 550.000 đ cho loại Dịch vụ.
4. Với ngày lập 30/10/2026, thử gia hạn P101 6 tháng: được chấp nhận nếu không có nợ hay lịch chồng phát sinh thêm. Thử 7 tháng phải bị từ chối.
5. Một phiếu có thể nhập nhiều dòng `MaPhong;SoThang`; nếu một phòng không hợp lệ thì toàn phiếu rollback. P102 còn nợ và có dịch vụ chưa lên hóa đơn nên không đủ điều kiện gia hạn.

## Quy tắc và công thức

- Hợp đồng tối thiểu 6 tháng; ngày kết thúc gồm ngày cuối, bằng ngày bắt đầu cộng số tháng trừ 1 ngày. Ứng dụng thực hành nhận số tháng nguyên từ 6 đến 120.
- Giá mỗi phòng được chốt vào chi tiết hợp đồng. Tiền trả trước = tổng giá tháng các phòng × 6. Ký chỉ lưu khi đã xác nhận nhận đủ tiền.
- Kỳ thuê từ tháng 7 là từng tháng theo ngày bắt đầu thuê; hạn thu là ngày đầu tháng dương lịch chứa ngày bắt đầu kỳ. Ví dụ bắt đầu thuê 15/04 thì kỳ thứ 7 bắt đầu 15/10 và hạn thu 01/10.
- Tiền dịch vụ = tổng `ROUND(SoLuong × DonGia, 0)`. Giá ghi theo lần sử dụng; tiền thuê và dịch vụ có khoản thu riêng.
- Mỗi lần thu phải dương và không vượt số còn nợ. CSDL khóa bản ghi nguồn khi kiểm tra và ghi chứng từ.
- Mỗi lần, mỗi phòng gia hạn không quá `floor(SoThangThue / 2)` tháng của hợp đồng gốc. Thời gian mới nối tiếp hạn cũ; giá giữ theo hợp đồng. Đề không giới hạn tổng số lần gia hạn.
- Chỉ gia hạn khi hết nợ thuê đến hạn tại ngày lập, dịch vụ đã dùng đều đã lập hóa đơn và trả đủ. Kỳ thuê tương lai chưa đến hạn không tính là nợ. Số tiền thanh toán sau ngày lập không chứng minh hết nợ ở ngày trước đó.
- Không ghi thêm dịch vụ vào tháng đã lập hóa đơn hoặc ghi lùi về trước thời điểm đã xác nhận gia hạn.
- Phạt do tự sửa kết cấu chỉ được lập từ kết quả kiểm tra vi phạm; số tiền nhập theo quy định cao ốc. Phạt theo dõi riêng và không tự thêm vào điều kiện gia hạn của câu 6.
- Khách và công ty thuê cung cấp hồ sơ qua quản lý; bốn tác nhân trực tiếp là bộ phận quản lý, kế toán, bảo vệ, bộ phận kỹ thuật.

## Kiểm thử và giới hạn

Ngày 30/10/2026 đã kiểm tra trên CSDL riêng: 49 ca nghiệp vụ/CSDL, 11 luồng ghi từ nút Form và 324 kiểm tra Form đều đạt. Các ca gồm rollback hợp đồng nhiều phòng, thu trước, kỳ tháng thứ 7, thu từng phần, gia hạn có nợ, hóa đơn chưa lập/chưa trả, giới hạn gia hạn, lịch chồng, ảnh nhân viên, biển số duy nhất và kiểm tra sau 1 năm. Hai ca đồng thời kiểm tra thuê trùng phòng và thu vượt khoản nợ.

Kiểm tra giao diện mở đủ 9 Form và 23 màn hình/tab, nạp SQL và rà vùng nhập/cột ở kích thước mặc định, nhỏ nhất. Luồng lưu ảnh kiểm tra bằng dữ liệu ảnh đã chọn; chưa tự động thao tác hộp thoại chọn file, xuất CSV, mọi mức DPI hoặc máy in vật lý. Source không có thao tác xóa lịch sử hợp đồng/chứng từ hay điều chỉnh hóa đơn đã chốt.

## Lỗi gặp và cách khắc phục

| Tình huống | Cách xử lý |
| --- | --- |
| Không kết nối SQL | Kiểm tra dịch vụ SQL, Data Source và đúng database QuanLyVanPhong. |
| Phòng trùng lịch hoặc đang sửa | Tra cứu tình trạng tại ngày thuê; chọn phòng/thời hạn phù hợp hoặc cập nhật trạng thái sửa. |
| Gia hạn bị từ chối | Đối chiếu từng phòng, giới hạn tháng, nợ thuê đến hạn, dịch vụ chưa lên hóa đơn/chưa trả đủ và lịch thuê sau hạn cũ. |
| Thu vượt khoản nợ | Tải lại công nợ, chọn dòng và nạp số còn lại; không dùng số tiền cũ sau khi vừa ghi thu. |
| Trùng mã, biển số, hóa đơn tháng | Dùng mã mới, kiểm tra dữ liệu; PK/UNIQUE ngăn ghi trùng. |
| Ảnh nhân viên không hợp lệ | Chọn đúng định dạng ảnh tối đa 5 MB; phòng phải do công ty thuê tại ngày báo cáo. |
| Dữ liệu dài trên bảng | Wrap tiêu đề/nội dung và tăng chiều cao hàng; kiểm tra mọi tab ở hai kích thước. |

## Nộp bài

LAB8 gồm Word, từng sơ đồ draw.io, source WinForms, một script SQL và README. Không đưa bin/obj/.vs, file khóa Word, MDF/LDF, backup hay thông tin xác thực lên GitHub. Commit/push trước hạn, mở repository kiểm tra file truy cập được rồi nộp URL trên Classroom; nếu được yêu cầu video thì đặt link đầu báo cáo.

[Quay về danh sách bài Lab](../README.md).
