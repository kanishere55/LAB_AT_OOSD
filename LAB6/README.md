# LAB6 — Quản lý hồ sơ bệnh án của bệnh nhân

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.
- Đề thực hành: **Bài 5 — Quản lý hồ sơ bệnh án của bệnh nhân**.
- Ngày thực hiện: **16/10/2026**.

## Mục tiêu và nội dung thực hiện

Bài làm gồm phân tích đăng ký bệnh nhân, lệ phí năm, cấp/tra cứu hồ sơ bệnh án, khám bệnh, xét nghiệm, toa thuốc, hẹn định kỳ và hoàn tất đợt điều trị sau thanh toán viện phí. Phần phân tích và thiết kế trả lời sáu câu trong đề; phần hiện thực bổ sung SQL Server và WinForms theo yêu cầu trên lớp.

| Sản phẩm | Kết quả |
| --- | --- |
| Lớp và quan hệ | 13 lớp nghiệp vụ, ID, thuộc tính/phương thức; 14 liên kết và bội số |
| UML | 2 hình lớp, 1 use case tổng quát, 2 phân rã chức năng, 2 activity và 1 sequence lập toa |
| Đặc tả trọng tâm | Đăng ký/cấp hồ sơ, hẹn/khám định kỳ, hoàn tất; đặc tả lập toa tại Câu 6 |
| SQL Server | 13 bảng, PK/FK/UNIQUE/CHECK, 11 stored procedure và kiểu bảng `DongToa` |
| WinForms | 9 Form, 8 module nghiệp vụ; UI → HoSoService → Data/Db → SQL Server |
| Ảnh kết quả | 20 ảnh màn hình/tab ứng dụng và 2 ảnh truy vấn CSDL |
| Báo cáo | 8 sơ đồ UML và 22 ảnh ứng dụng/CSDL |

Phân rã use case thể hiện **chức năng**. `include` hướng tới chức năng bắt buộc; `extend` hướng từ chức năng mở rộng về use case cơ sở, có điều kiện. Activity làm rõ thứ tự, điều kiện và các nhánh có/không xét nghiệm, có/không kê thuốc.

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

Visual Studio cần workload **.NET desktop development** và targeting pack .NET Framework 4.7.2. Project không cần cài NuGet. Form được bố trí bằng C# trong thư mục `Forms`; `ModuleForm` cung cấp bố cục và bảng dùng chung. Mã nguồn hiện dùng `BenhNhanInput` cho đăng ký và `DataTable` cho dữ liệu hiển thị; các lớp phân tích ánh xạ tới các bảng SQL.

## Các file chính

- [Báo cáo Word](1250080021_NguyenThanhCan_CNPM1_LAB6.docx).
- [Đề thực hành gốc](../CacBaiLab/Bai_5_Quan_ly_ho_so_benh_an.docx).
- [Solution WinForms](QuanLyHoSoBenhAn/QuanLyHoSoBenhAn.sln).
- [Cấu hình kết nối](QuanLyHoSoBenhAn/QuanLyHoSoBenhAn/App.config).
- [SQL cấu trúc, thủ tục và danh mục mẫu](Database/QuanLyHoSoBenhAn.sql).
- [8 file draw.io riêng, mỗi file một sơ đồ](../IMAGES/LAB6): 2 hình lớp, use case tổng quát, 2 phân rã chức năng, 2 activity và sequence lập toa thuốc.
- Ảnh chạy ứng dụng và ảnh CSDL nằm trong báo cáo Word.

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
- Lệ phí có hiệu lực một năm; không thu chồng thời hạn. Số tiền mẫu 100.000 đ và phí khám điều trị 150.000 đ chỉ là dữ liệu thực hành, có thể nhập mức khác.
- Quyền khám định kỳ tính một lần trong mỗi **quý dương lịch**, tại ngày còn hiệu lực lệ phí năm; phí khám bằng 0. UNIQUE có lọc ngăn trùng lịch chưa hủy và trùng lần khám định kỳ theo hồ sơ/năm/quý.
- Có lịch hẹn còn hiệu lực trong quý thì tiếp nhận phải chọn đúng mã hẹn, hồ sơ và ngày; tạo phiếu và chuyển trạng thái hẹn trong cùng transaction.
- Xét nghiệm và toa phải gắn với phiếu khám. Chỉ kê toa sau kết luận và có đủ kết quả xét nghiệm; bác sĩ kê phải là bác sĩ phụ trách phiếu. Một phiếu tối đa một toa; toa đã lưu có ít nhất một dòng hợp lệ.
- Hoàn tất chỉ khi có kết luận, đủ kết quả xét nghiệm, đã xuất viện và đã thanh toán viện phí. Đợt hoàn tất được khóa nội dung khám/xét nghiệm và đánh dấu ghi nhận lịch sử.
- Lệ phí năm được tách khỏi viện phí. Module hoàn tất ghi **xác nhận viện phí đã được thanh toán**; chưa hiện thực sổ kế toán/hóa đơn viện phí, cổng bệnh nhân hoặc gửi SMS.

## Cài đặt và chạy lại

1. Kết nối SQL Server bằng Windows Authentication với quyền tạo database. Chạy toàn bộ `Database/QuanLyHoSoBenhAn.sql`. Script tạo cấu trúc, thủ tục và bốn danh mục mẫu Khoa, BacSi, Thuoc, LoaiXetNghiem; có thể chạy lại mà không xóa bảng hay ghi đè các mã danh mục đã tồn tại.
2. Mở solution bằng Visual Studio. Trong `App.config`, đổi `Data Source` nếu instance khác; giữ `Initial Catalog=QuanLyHoSoBenhAn`:

   ```text
   Data Source=.\MSSQLSERVER01;Initial Catalog=QuanLyHoSoBenhAn;Integrated Security=True;TrustServerCertificate=True
   ```

3. Chọn project `QuanLyHoSoBenhAn` làm Startup Project, Rebuild rồi F5. Thanh trạng thái phải báo kết nối thành công.
4. Kiểm tra bốn danh mục mẫu trước, sau đó tạo bệnh nhân và hồ sơ qua Form theo các kịch bản bên dưới. Khi thử ghi, dùng mã mới và chọn ngày phù hợp quyền lợi; thao tác Form ghi trực tiếp vào CSDL ứng dụng.

```powershell
sqlcmd -S '.\MSSQLSERVER01' -E -f 65001 -b -i '.\Database\QuanLyHoSoBenhAn.sql'
```

Danh mục mẫu gồm K01/K02, BS01/BS02, T01/T02 và XN01/XN02. Dữ liệu bệnh nhân, lịch hẹn, phiếu khám, xét nghiệm và toa thuốc được tạo qua các Form. Các mã BN001, HS001, PK001 và TOA001 trong ảnh báo cáo là dữ liệu của lần thực hành đã chụp.

## Kiểm tra lại nghiệp vụ

| Kịch bản | Thao tác | Kết quả cần đối chiếu |
| --- | --- | --- |
| Đăng ký lần đầu | Nhập mã bệnh nhân mới, thông tin, ảnh 3×4 và lệ phí dương; cấp hồ sơ | Tạo đồng thời BenhNhan, PhieuDangKy, PhieuThuLePhi, HoSoBenhAn; lỗi thì rollback |
| Khám định kỳ theo quý | Đặt lịch và tiếp nhận trong quý còn hiệu lực lệ phí năm; thử đăng ký thêm lần nữa cùng quý | Lần định kỳ hợp lệ có phí 0; không cho trùng quyền lợi theo hồ sơ/năm/quý |
| Phiếu khám và xét nghiệm | Lập phiếu, chọn bác sĩ/khoa; chỉ định loại xét nghiệm và ghi kết quả | ChiDinhXetNghiem gắn đúng MaPhieuKham; không ghi kết quả cho phiếu đã hoàn tất |
| Lập toa thuốc | Chọn phiếu có kết luận, đủ kết quả xét nghiệm, đúng bác sĩ; thêm ít nhất một dòng thuốc rồi lưu | ToaThuoc và ChiTietToaThuoc cùng được lưu; mỗi phiếu tối đa một toa |
| Hoàn tất điều trị | Thử hoàn tất khi chưa xác nhận thanh toán; sau đó xác nhận xuất viện và viện phí đã trả | Chặn khi chưa đủ điều kiện; hoàn tất khi hợp lệ và khóa nội dung điều trị |
| Tra cứu lịch sử | Chọn hồ sơ vừa thực hành | Hiển thị đúng các phiếu khám, kết quả xét nghiệm, toa và dòng thuốc liên quan |

Build Release thành công; các kịch bản trên chạy đúng khi đối chiếu trên ứng dụng và SQL Server.

## Lỗi gặp và cách khắc phục

| Tình huống | Cách xử lý |
| --- | --- |
| Index trên cột tính toán/có lọc yêu cầu tùy chọn SET | Khai báo QUOTED_IDENTIFIER, ANSI_NULLS, ANSI_WARNINGS, ARITHABORT và các tùy chọn cần thiết trước DDL |
| CHECK với NULL có thể cho trạng thái xét nghiệm thiếu kết quả | Kiểm tra tường minh `IS NOT NULL` cùng nội dung và ngày trả |
| Cột/tiêu đề dài | Fill theo trọng số, wrap và tăng chiều cao hàng |
| Trùng mã/quý hoặc lỗi nhiều bảng | Service trả thông báo; PK/FK/UNIQUE/CHECK và transaction ngăn lưu dở dang |
| Không kết nối CSDL | Kiểm tra dịch vụ, instance, script và Data Source |
| EXE đang chạy khi build | Đóng chương trình, Rebuild rồi chạy lại |

[Quay về danh sách bài Lab](../README.md).
