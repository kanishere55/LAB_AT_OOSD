# LAB6 — Quản lý hồ sơ bệnh án của bệnh nhân

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.
- Đề thực hành: **Bài 5 — Quản lý hồ sơ bệnh án của bệnh nhân**.
- Ngày thực hiện: **16/10/2026**.

## Mục tiêu và nội dung thực hiện

Bài làm gồm phân tích đăng ký bệnh nhân, lệ phí năm, cấp/tra cứu hồ sơ bệnh án, khám bệnh, xét nghiệm, toa thuốc, hẹn định kỳ và hoàn tất đợt điều trị sau thanh toán viện phí. Phần phân tích và thiết kế trả lời sáu câu trong đề; phần hiện thực bổ sung SQL Server, WinForms và kiểm thử theo yêu cầu trên lớp.

| Sản phẩm | Kết quả |
| --- | --- |
| Lớp và quan hệ | 13 lớp nghiệp vụ, ID, thuộc tính/phương thức; 14 liên kết và bội số |
| UML | 2 hình lớp, 1 use case tổng quát, 2 phân rã chức năng, 2 activity và 1 sequence lập toa |
| Đặc tả trọng tâm | Đăng ký/cấp hồ sơ, hẹn/khám định kỳ, hoàn tất; đặc tả lập toa tại Câu 6 |
| SQL Server | 13 bảng, PK/FK/UNIQUE/CHECK, 11 stored procedure và kiểu bảng `DongToa` |
| WinForms | 9 Form, 8 module nghiệp vụ; UI → HoSoService → Data/Db → SQL Server |
| Kiểm thử | 50 kiểm thử nghiệp vụ/CSDL, 12 luồng ghi dữ liệu từ Form, 265 kiểm tra bố cục |
| Bằng chứng | 20 ảnh màn hình/tab ứng dụng và 2 ảnh truy vấn metadata CSDL thực tế |
| Báo cáo | A4 dọc, 8 hình UML và 22 ảnh ứng dụng/CSDL; có truy vết yêu cầu |

Phân rã use case thể hiện **chức năng**. `include` hướng tới chức năng bắt buộc; `extend` hướng từ chức năng mở rộng về use case cơ sở, có điều kiện. Các đường nối được bố trí theo góc vuông; activity làm rõ thứ tự, điều kiện và các nhánh có/không xét nghiệm, có/không kê thuốc.

## Môi trường và phiên bản

| Thành phần | Cấu hình đã chạy |
| --- | --- |
| Hệ điều hành | Windows 11 |
| IDE | Visual Studio Community 2022 |
| Project | C# Windows Forms, .NET Framework **4.7.2**, Any CPU |
| Kết nối | ADO.NET, `System.Data.SqlClient`, Windows Authentication |
| SQL Server | 2022 Developer **16.0.1000.6** |
| Instance | `.\MSSQLSERVER01` |
| CSDL ứng dụng | `QuanLyHoSoBenhAn` |
| CSDL kiểm thử ghi dữ liệu | `QuanLyHoSoBenhAn_Test` |

Visual Studio cần workload **.NET desktop development** và targeting pack .NET Framework 4.7.2. Project không cần cài NuGet. Form được bố trí bằng C# trong thư mục `Forms`; `ModuleForm` cung cấp bố cục và bảng dùng chung. Mã nguồn hiện dùng `BenhNhanInput` cho đăng ký và `DataTable` cho dữ liệu hiển thị; các lớp phân tích ánh xạ tới các bảng SQL.

## Các file chính

- [Báo cáo Word](1250080021_NguyenThanhCan_CNPM1_LAB6.docx).
- [Đề thực hành gốc](Bai_5_Quan_ly_ho_so_benh_an.docx).
- [Solution WinForms](QuanLyHoSoBenhAn/QuanLyHoSoBenhAn.sln).
- [Cấu hình kết nối](QuanLyHoSoBenhAn/QuanLyHoSoBenhAn/App.config).
- [SQL cấu trúc và thủ tục](Database/QuanLyHoSoBenhAn.sql), [dữ liệu mẫu](Database/DuLieuMau.sql), [truy vấn đối chiếu](Database/KiemTra.sql).
- [8 file draw.io riêng, mỗi file một sơ đồ](UML/README.md), [mô hình StarUML](UML/LAB6_QuanLyHoSoBenhAn.mdj) và [ảnh UML](UML/README.md).
- [Kịch bản kiểm thử](Tests/KichBanKiemThu.md) và [truy vết yêu cầu](Tests/TruyVetYeuCau.md).
- [Bằng chứng chạy ứng dụng và CSDL](Evidence/README.md).

## Các module

| Form | Chức năng |
| --- | --- |
| FrmMain | Mở module và tổng hợp số liệu từ SQL |
| FrmBenhNhan | Đăng ký/ảnh/lệ phí/cấp hồ sơ; cập nhật nhân thân; gia hạn và tìm kiếm |
| FrmKhamBenh | Lập phiếu điều trị hoặc định kỳ; ghi triệu chứng, chỉ số, kết luận và theo dõi |
| FrmXetNghiem | Chỉ định theo phiếu, ghi ngày và kết quả |
| FrmToaThuoc | Soạn thuốc, lưu toa + chi tiết, xem, xuất TXT và xem trước khi in A4 |
| FrmLichHen | Đặt, đổi, xác nhận và hủy lịch định kỳ |
| FrmHoanTat | Xác nhận xuất viện/thanh toán và hoàn tất |
| FrmLichSu | Các lần khám, xét nghiệm, toa và dòng thuốc theo hồ sơ |
| FrmDanhMuc | Thêm/sửa khoa, bác sĩ, thuốc và loại xét nghiệm |

## Quy tắc nghiệp vụ

- Đăng ký chỉ cấp hồ sơ khi đủ thông tin, ảnh 3×4 và lệ phí dương. Bốn bảng bệnh nhân/đăng ký/lệ phí/hồ sơ cùng commit hoặc rollback.
- Lệ phí có hiệu lực một năm; không thu chồng thời hạn. Số tiền mẫu 100.000 đ và phí khám điều trị 150.000 đ phục vụ kiểm thử, có thể nhập mức khác.
- Quyền khám định kỳ tính một lần trong mỗi **quý dương lịch**, tại ngày còn hiệu lực lệ phí năm; phí khám bằng 0. UNIQUE có lọc ngăn trùng lịch chưa hủy và trùng lần khám định kỳ theo hồ sơ/năm/quý.
- Có lịch hẹn còn hiệu lực trong quý thì tiếp nhận phải chọn đúng mã hẹn, hồ sơ và ngày; tạo phiếu và chuyển trạng thái hẹn trong cùng transaction.
- Xét nghiệm và toa phải gắn với phiếu khám. Chỉ kê toa sau kết luận và có đủ kết quả xét nghiệm; bác sĩ kê phải là bác sĩ phụ trách phiếu. Một phiếu tối đa một toa; toa đã lưu có ít nhất một dòng hợp lệ.
- Hoàn tất chỉ khi có kết luận, đủ kết quả xét nghiệm, đã xuất viện và đã thanh toán viện phí. Đợt hoàn tất được khóa nội dung khám/xét nghiệm và đánh dấu ghi nhận lịch sử.
- Lệ phí năm được tách khỏi viện phí. Module hoàn tất ghi **xác nhận viện phí đã được thanh toán**; chưa hiện thực sổ kế toán/hóa đơn viện phí, cổng bệnh nhân hoặc gửi SMS.

## Cài đặt và chạy lại

1. Kết nối SQL Server bằng Windows Authentication với quyền tạo database. Chạy `Database/QuanLyHoSoBenhAn.sql`, sau đó `Database/DuLieuMau.sql`. Script chạy lại không xóa bảng hay ghi đè dữ liệu mẫu đã tồn tại.
2. Mở solution bằng Visual Studio. Trong `App.config`, đổi `Data Source` nếu instance khác; giữ `Initial Catalog=QuanLyHoSoBenhAn`:

   ```text
   Data Source=.\MSSQLSERVER01;Initial Catalog=QuanLyHoSoBenhAn;Integrated Security=True;TrustServerCertificate=True
   ```

3. Chọn project `QuanLyHoSoBenhAn` làm Startup Project, Rebuild rồi F5. Thanh trạng thái phải báo kết nối thành công.
4. Dùng các mẫu dưới đây để kiểm tra đọc dữ liệu. Khi thử ghi, dùng mã mới và chọn ngày phù hợp quyền lợi; thao tác Form ghi trực tiếp vào CSDL ứng dụng.

```powershell
sqlcmd -S '.\MSSQLSERVER01' -E -f 65001 -b -i '.\Database\QuanLyHoSoBenhAn.sql'
sqlcmd -S '.\MSSQLSERVER01' -E -f 65001 -b -i '.\Database\DuLieuMau.sql'
```

| Mẫu | Dữ liệu |
| --- | --- |
| BN001 / HS001 | Lệ phí 01/01–31/12/2026; PK001 đã hoàn tất, CD001 đã trả kết quả, TOA001 có 2 dòng |
| PK002 / HS001 | Khám điều trị 16/10/2026, có kết luận, chưa hoàn tất và chưa có toa |
| BN002 / HS002 | LH001 đã thực hiện thành PK003 ngày 15/10/2026; định kỳ quý IV, phí 0, không có toa |
| LH002 / HS001 | Hẹn 10/12/2026 lúc 08:30; khi tiếp nhận chọn đúng hồ sơ, mã hẹn và ngày |

Ảnh, tên, thuốc, chỉ số và kết quả trong seed đều là dữ liệu thực hành.

## Chạy kiểm thử

Từ thư mục LAB6, dùng PowerShell:

```powershell
.\Tests\Run-Checks.ps1
.\Tests\Capture-Forms.ps1
```

`Run-Checks.ps1` tạo hoặc cập nhật CSDL `QuanLyHoSoBenhAn_Test`, build Release và chạy 50 kiểm thử Service/SQL cùng 12 luồng nút Form. Mỗi lần chạy dùng mã riêng. Nếu SQL instance khác, dùng `-Instance 'TEN_INSTANCE'`; cấu hình ứng dụng và script chụp Form đọc `App.config`. Script build hiện dùng đường dẫn Visual Studio 2022 Community; điều chỉnh biến `$buildTool`/`$compiler` nếu cài edition hoặc vị trí khác.

`Capture-Forms.ps1` chạy sau khi đã build Release và nạp seed. Script mở đủ Form/tab, kiểm tra bố cục ở kích thước mặc định/nhỏ nhất, rồi ghi ảnh vào `Evidence`. Ảnh lấy bằng **DrawToBitmap từ Form đang chạy**, đọc dữ liệu SQL thật. Hai ảnh CSDL là kết quả truy vấn metadata trong cửa sổ kiểm tra riêng; không phải cửa sổ SSMS.

Kết quả ngày 16/10/2026:

- **50/50** kiểm thử nghiệp vụ/CSDL đạt: đăng ký, rollback, quyền lợi, quý, FK, toa, trạng thái hoàn tất và hai ca đồng thời.
- **12/12** luồng ghi từ nút Form đạt.
- **265/265** kiểm tra giao diện đạt trên 20 màn hình/tab ở hai kích thước; không thay đổi DPI Windows.
- Build Release thành công; SQL cấu trúc và seed chạy lại thành công.

Kết quả chi tiết: [BusinessResults.csv](Tests/BusinessResults.csv), [UiWorkflowResults.csv](Tests/UiWorkflowResults.csv), [FormResults.csv](Evidence/FormResults.csv). Chưa kiểm thử mọi tổ hợp dữ liệu, mọi mức DPI hoặc in ra máy in vật lý.

## Lỗi gặp và cách khắc phục

| Tình huống | Cách xử lý |
| --- | --- |
| Index trên cột tính toán/có lọc yêu cầu tùy chọn SET | Khai báo QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_WARNINGS, ARITHABORT và các tùy chọn cần thiết trước DDL |
| CHECK với NULL có thể cho trạng thái xét nghiệm thiếu kết quả | Kiểm tra tường minh `IS NOT NULL` cùng nội dung và ngày trả; T48 xác nhận bị chặn |
| Cột/tiêu đề dài | Fill theo trọng số, wrap và tăng chiều cao hàng; rà tất cả tab ở hai kích thước |
| Trùng mã/quý hoặc lỗi nhiều bảng | Service trả thông báo; PK/FK/UNIQUE/CHECK và transaction ngăn lưu dở dang |
| Không kết nối CSDL | Kiểm tra dịch vụ, instance, script và Data Source |
| EXE đang chạy khi build | Đóng chương trình, Rebuild rồi chạy lại |

## Nộp bài

Thư mục LAB6 gồm Word, UML, source C#, SQL, Tests, Evidence và README. Không đưa `bin/obj/.vs`, file khóa Word, thông tin xác thực, MDF/LDF hoặc backup lên GitHub. Repository của học phần được yêu cầu tên LAB_OOSD, Public nếu lớp không quy định khác; remote hiện tại của bộ bài là LAB_AT_OOSD. Sau commit/push, mở GitHub kiểm tra file truy cập được rồi nộp URL trên Classroom theo yêu cầu lớp. Nếu có video, chèn link ở đầu báo cáo.

[Quay về danh sách bài Lab](../README.md).
