# LAB3 — Hệ thống quản lý khách sạn

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.
- Ngày hoàn thiện và kiểm tra: **31/10/2026**.

## Nội dung và kết quả

Bài làm phân tích phòng theo khu vực, tiện nghi và lịch sử lắp đặt/luân chuyển, khách đại diện, đặt/nhận phòng, người lưu trú, dịch vụ, đền bù, hóa đơn, thanh toán và thống kê.

- Báo cáo theo pha **phân tích → thiết kế → CSDL → WinForms → kiểm thử và truy vết**, có đặc tả use case trọng tâm, định danh lớp, association và multiplicity.
- **37 file draw.io riêng**, nền vàng nhạt, viền hồng: 1 use case tổng quát, 4 phân rã chức năng, 4 hình lớp phân tích, 2 trạng thái, 8 Sequence, 4 hình lớp chi tiết, 6 thiết kế module, 3 Activity, 4 ERD và 1 điều hướng Form. Những lớp lặp ở các nhóm vẫn là cùng một lớp.
- Workbook **5 sheet**: UseCase, DacTa, ScreenDesign, TestCase, TruyVet; gồm 14 use case, đặc tả 6 nghiệp vụ trọng tâm và thiết kế 15 màn hình/tab.
- SQL Server có **18 bảng và 22 quan hệ khóa ngoại**, PK, UNIQUE, CHECK; nghiệp vụ nhiều bảng dùng transaction tại Service.
- Ứng dụng **7 Form**, 6 module; source theo **UI → Service → Data**, C# WinForms .NET Framework 4.7.2.
- Build Release thành công; **46/46** ca nghiệp vụ/CSDL đạt. Đã mở và rà 15 màn hình/tab với SQL Server, sửa control tràn vùng chứa và cập nhật ảnh vào Word.
- Báo cáo A4 dọc, không footer; có **15 ảnh Form/tab**, **2 ảnh truy vấn CSDL thực chạy** và giữ các biểu mẫu nghiệp vụ ở phụ lục.

## Các file chính

- [Báo cáo Word](1250080021_NguyenThanhCan_CNPM1_LAB03.docx).
- [Đề bài khách sạn](../CacBaiLab/Bai_3_He_thong_quan_ly_khach_san.pdf).
- [Workbook Use Case và Screen Design](LAB3_UseCase_ScreenDesign.xlsx).
- [37 sơ đồ draw.io](../IMAGES/LAB3).
- [Solution Visual Studio](QuanLyKhachSan/QuanLyKhachSan.sln).
- [Cấu hình kết nối](QuanLyKhachSan/QuanLyKhachSan/App.config).
- [SQL cấu trúc và danh mục mẫu](Database/SQL.sql).

## Môi trường

Windows 11; Visual Studio Community 2022; C# WinForms **.NET Framework 4.7.2**, Any CPU; ADO.NET `System.Data.SqlClient`; SQL Server LocalDB **15.0.4382.1**, instance `(localdb)\MSSQLLocalDB`, Windows Authentication. Database ứng dụng **QuanLyKhachSan**.

Visual Studio cần workload **.NET desktop development** và targeting pack .NET Framework 4.7.2. Project không cần gói NuGet ngoài. Có thể dùng SQL Server instance khác nếu sửa đúng `Data Source`.

Các entity trong UML mô tả mô hình dữ liệu và trách nhiệm nghiệp vụ. Source hiện thực các xử lý qua Service và DataTable; `Models.cs` có hai DTO `PhongDatItem`, `DenBuItem` và lớp kết quả `KetQuaXuLy`. Actor là vai trò nghiệp vụ, chưa triển khai đăng nhập/phân quyền.

## Chuẩn bị và chạy

1. Kiểm tra LocalDB và khởi động instance trong PowerShell:

   ```powershell
   sqllocaldb info
   sqllocaldb start MSSQLLocalDB
   ```

   Nếu chưa có instance, tạo bằng `sqllocaldb create MSSQLLocalDB`.

2. Mở SSMS, kết nối `(localdb)\MSSQLLocalDB` bằng Windows Authentication. Chạy [Database/SQL.sql](Database/SQL.sql) để khởi tạo môi trường mới.

   **Script có `DROP TABLE`, sẽ xóa dữ liệu các bảng của bài khi chạy lại. Chỉ dùng khi khởi tạo hoặc chủ động đặt lại môi trường. Nếu CSDL đã đầy đủ và cần giữ dữ liệu, bỏ qua bước này.**

3. Kiểm tra chuỗi kết nối `QuanLyKhachSanDB` trong App.config:

   ```text
   Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyKhachSan;Integrated Security=True;
   ```

4. Mở solution, chọn QuanLyKhachSan làm Startup Project, Rebuild **Release**, rồi chạy F5 hoặc Ctrl+F5. Build lại sau khi đổi cấu hình.

5. Kiểm tra danh mục mẫu: A101 sức chứa 2, giá 600.000 đ/ngày; A102 sức chứa 3, giá 800.000 đ; B201 sức chứa 4, giá 1.200.000 đ. DV01 Ăn sáng 120.000 đ/suất; DV02 Tắm hơi 250.000 đ/lượt; DV03 Karaoke 300.000 đ/giờ. Có NV01/NV02/NV03 và TV01/TV02/TL01.

## Kịch bản kiểm tra lại

Script SQL tạo danh mục, chưa tạo khách, phiếu đặt, dịch vụ phát sinh hay hóa đơn. Các mã sau được nhập theo kịch bản; dùng mã mới nếu đã tồn tại.

| Bước | Dữ liệu và kết quả đối chiếu |
| --- | --- |
| Khách | KH01, tên Khách thực hành, CCCD/hộ chiếu LAB3-0001, quốc tịch Việt Nam. CCCD của khách đại diện không được trùng. |
| Lắp đặt | LD01, TV01, A101, ngày 31/10/2026, Tốt, NV02. Thử lắp TV01 sang A102 trong cùng ngày phải bị từ chối. |
| Đặt phòng | DP01, KH01, NV01; A101 2 người; nhận 31/10, trả dự kiến 02/11/2026; Website; cọc 200.000 đ. Thử 3 người hoặc một phiếu chồng lịch phải bị từ chối. |
| Nhận phòng | Thêm 2 người có họ tên, CCCD LT001/LT002 và quốc tịch. Người thứ 3 bị từ chối; nhận phòng chuyển phiếu và phòng sang Đang ở. |
| Dịch vụ | DP01/A101, DV01 ngày 31/10/2026: ghi 1 rồi 2 suất. Kết quả đúng một dòng, số lượng **3**, thành tiền **360.000 đ**. |
| Đền bù | DB01, TV01 hư hỏng nhẹ, 500.000 đ; ghi theo phiếu riêng sau khi kiểm tra phòng. |
| Hóa đơn | HD01/DP01, xác nhận 2 ngày. Tiền phòng 1.200.000 + dịch vụ 360.000 = **1.560.000 đ**. |
| Thanh toán | TT01 tiền mặt 600.000 đ: còn 960.000 đ, chưa trả phòng được. Thử thu 1.000.000 đ phải bị từ chối. TT02 chuyển khoản 960.000 đ: hóa đơn Đã thanh toán. |
| Trả phòng | DP01 Đã trả; A101 Trống khi không còn đặt phòng khác. Không nhận thao tác trả lần hai. |
| Thống kê | Lọc 31/10/2026: đối chiếu HD01 **1.560.000 đ**, đền bù **500.000 đ**, DV01 **3 suất**. |

Trong lần chạy kiểm thử, sau chu trình DP01 còn tạo DP02 No-show và DP03 đang ở để mở đủ các Form. Ảnh sử dụng CSDL kiểm thử riêng `QuanLyKhachSan_Lab3Review_20261031`; không thay đổi CSDL ứng dụng đã có trên máy. Bảng TestCase ghi kết quả từng thời điểm, trước khi bổ sung lượt dùng để chụp Form.

## Quy tắc và transaction

- Khoảng đặt tính cả hai đầu mút; trùng khi `nhận mới <= trả cũ` và `trả mới >= nhận cũ`. Chỉ các phiếu Đã đặt/Đang ở được xét giữ phòng. Trạng thái phòng là chỉ báo, việc kiểm tra trống dựa vào lịch.
- Đặt phòng, người lưu trú, nhận phòng, No-show, lắp đặt, dịch vụ, đền bù, hóa đơn, thu tiền và trả phòng dùng transaction; các bước ghi nhiều bảng cùng commit hoặc rollback. Khóa phòng/hóa đơn được giữ trong lúc kiểm tra và cập nhật.
- `UNIQUE(MaLoaiTN, SoThuTu)` phân biệt thiết bị theo loại; `UNIQUE(MaTienNghi, NgayLap)` ngăn lắp hai phòng cùng ngày. Vị trí hiện tại lấy phiếu lắp mới nhất.
- Một đầu phiếu dịch vụ cho mỗi lượt–phòng–ngày; PK chi tiết gồm phiếu và mã DV. Ghi lại cùng ngày cộng số lượng và giữ đơn giá dòng.
- Tiền phòng = tổng giá ngày các phòng × số ngày nhân viên xác nhận. Tiền dịch vụ = tổng chi tiết sử dụng. Tổng hóa đơn = phòng + dịch vụ.
- Tiền cọc được lưu để theo dõi, **chưa tự đối trừ hoặc hoàn cọc**. Đền bù theo phiếu riêng, **không cộng vào tổng hóa đơn** và chưa có chức năng thu tiền đền bù riêng.
- Mỗi phiếu có tối đa một hóa đơn. Khi đã có hóa đơn thì không ghi thêm dịch vụ của lượt đó. Hóa đơn 0 đ được xác nhận đã thanh toán ngay.
- Thu tiền hỗ trợ tiền mặt, chuyển khoản, thẻ và ví điện tử. Mỗi lần thu dương, không vượt số còn lại; đủ tiền mới hoàn tất trả phòng.
- No-show chỉ áp dụng phiếu Đã đặt. Trạng thái Hủy được dự phòng trong CHECK nhưng chưa có thao tác hủy trên Form.

## Kết quả kiểm tra và giới hạn

Ngày 31/10/2026: build Release thành công, **46/46** ca nghiệp vụ/CSDL đạt. Các ca gồm dữ liệu trùng, vượt sức chứa, ngày đảo, phòng bảo trì, trùng lịch, thiết bị/ngày, số người, cộng dồn dịch vụ, rollback đền bù, chốt hóa đơn, thu một phần/vượt/đủ, No-show, trả hai lần và thống kê.

Đã mở **7 Form, 15 màn hình/tab**, nạp dữ liệu SQL và rà control trong vùng chứa ở kích thước mặc định. Các Form cố định kích thước; bảng hỗ trợ wrap tiêu đề/nội dung và hiển thị ngày `dd/MM/yyyy`. Chưa kiểm tra mọi DPI, thao tác đồng thời ở tải lớn, cổng thanh toán thật hoặc máy in. Ảnh Form được ghi bằng DrawToBitmap từ Form đang chạy; ảnh CSDL hiển thị kết quả truy vấn thực tế.

## Lỗi gặp và cách khắc phục

| Tình huống | Cách xử lý |
| --- | --- |
| Lỗi mở kết nối SQL | Kiểm tra instance LocalDB, trạng thái dịch vụ, tên database và App.config; build lại trước khi chạy. |
| Trùng mã hoặc CCCD | Tra cứu dữ liệu, dùng mã mới; không chạy lại script SQL để xử lý trùng mã. |
| No-show làm đổi nhầm phòng đang ở | Chỉ đổi phiếu Đã đặt; cập nhật phiếu và phòng trong một transaction, tính lại trạng thái từ các phiếu còn hiệu lực. |
| Lắp đặt cập nhật dở dang | Ghi phiếu và tình trạng trong cùng transaction; UNIQUE thiết bị/ngày chặn dữ liệu trùng. |
| Dịch vụ làm lệch hóa đơn đã chốt | Từ chối ghi thêm sau khi lập hóa đơn; giữ giá dòng khi cộng số lượng. |
| Nút nhận phòng bị khuất, control chồng | Đặt lại kích thước bảng và vị trí nút trên tab, kiểm tra mọi màn hình; thu gọn ô số tiền đền bù để không bị nút Thêm đè lên. |
| Không hoàn tất trả phòng | Kiểm tra phiếu Đang ở và tổng thanh toán đủ hóa đơn. |

## Nộp bài

LAB3 gồm Word, workbook, từng file draw.io, solution, một script SQL và README. Ảnh giao diện/CSDL nằm trong Word. Không đưa bin/obj/.vs, file khóa Word, MDF/LDF, backup hay thông tin xác thực lên GitHub. Commit/push và kiểm tra repository truy cập được trước hạn theo hướng dẫn của lớp.

[Quay về danh sách bài Lab](../README.md).

## File nguồn sơ đồ cho báo cáo tổng hợp

[Danh mục hình và file nguồn](../IMAGES/README.md) liệt kê 37 file của LAB3. Mỗi sơ đồ là một file `.drawio` riêng tại [IMAGES/LAB3](../IMAGES/LAB3).
