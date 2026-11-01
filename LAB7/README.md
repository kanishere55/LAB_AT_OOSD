# LAB7 — Quản lý nhân sự công ty sơn Đông Á

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.
- Ngày thực hiện: **23/10/2026**.

## Nội dung và kết quả

Bài làm phân tích tuyển dụng/thử việc, hợp đồng và bảo hiểm, lương/chức vụ, kế hoạch tuần, ca/chấm công, phụ trội, khen thưởng/kỷ luật, bảng lương và thống kê. Báo cáo trình bày theo pha phân tích → pha thiết kế → CSDL → WinForms.

- Trả lời 6 câu của đề; 22 lớp/bảng nghiệp vụ, ID, association và multiplicity.
- 18 sơ đồ: 3 hình lớp, 1 use case tổng quát, 2 phân rã chức năng, 1 trạng thái, 1 sequence khen thưởng, 1 lớp thiết kế tổng thể, 4 thiết kế module, 2 activity và 3 ERD. Mỗi sơ đồ là **một file draw.io riêng**.
- WinForms có **9 Form**, 8 module; màn hình chính 2 cột và nút Thoát.
- SQL Server có **22 bảng**, PK/FK/UNIQUE/CHECK, 9 stored procedure, TVP và transaction nhiều bảng.
- **41/41** kiểm thử nghiệp vụ/CSDL và **322/322** kiểm tra Form đạt; build Release thành công.
- Báo cáo A4 dọc, không footer; 20 ảnh Form/tab của ứng dụng chạy với dữ liệu SQL Server.

## Các file chính

- [Báo cáo Word](1250080021_NguyenThanhCan_CNPM1_LAB7.docx).
- [Đề bài](../CacBaiLab/Bai_7_Quan_ly_nhan_su.docx).
- [Solution](QuanLyNhanSu/QuanLyNhanSu.sln), [cấu hình](QuanLyNhanSu/QuanLyNhanSu/App.config).
- [SQL cấu trúc, thủ tục và dữ liệu mẫu](Database/QuanLyNhanSu.sql).
- [18 sơ đồ draw.io riêng](../IMAGES/LAB7).

## Môi trường

Windows 11, Visual Studio Community 2022, C# WinForms **.NET Framework 4.7.2**, Any CPU; ADO.NET `System.Data.SqlClient`. SQL Server 2022 Developer **16.0.1000.6**, instance `.\MSSQLSERVER01`, Windows Authentication. CSDL ứng dụng `QuanLyNhanSu`; kiểm thử `QuanLyNhanSu_Test`. Project không cần NuGet; cần workload .NET desktop development và targeting pack 4.7.2.

UI gọi `NhanSuService`, Service chuyển xử lý tới `Data/Db` và stored procedure bằng tham số. Form bố trí bằng C# qua `ModuleForm`. Mô hình lớp thực thể ánh xạ sang SQL; source dùng DataTable để hiển thị dữ liệu. Các vai trò UML là vai trò nghiệp vụ, chưa triển khai đăng nhập/phân quyền.

Bốn tác nhân trực tiếp trong mô hình là phòng nhân sự, trưởng phòng, ban chấm công và kế toán. Giám đốc ký quyết định ngoài phần mềm; kế toán nhập quyết định thưởng/phạt đã ký. Người lao động cung cấp hồ sơ và nhận quyết định qua nhân sự. Tra cứu bảo hiểm, người tham gia phụ trội và thông báo lỗi đều đi qua Service.

## Cài đặt và chạy

1. Mở `Database/QuanLyNhanSu.sql` trong SSMS và chạy toàn bộ file trên SQL Server có quyền tạo database. File chứa cấu trúc bảng, thủ tục và dữ liệu mẫu ở cuối; không xóa bảng hay ghi đè dữ liệu mẫu đã tồn tại.
2. Mở solution bằng Visual Studio; kiểm tra `Data Source` trong App.config:

   ```text
   Data Source=.\MSSQLSERVER01;Initial Catalog=QuanLyNhanSu;Integrated Security=True;TrustServerCertificate=True
   ```

3. Rebuild, chọn project QuanLyNhanSu làm Startup Project và F5.
4. Bảng lương mẫu **BL092026**, nhân viên **NV001**, thực lĩnh **10.016.923 đ**. Khi ghi mới, dùng mã chưa có và ngày phù hợp nghiệp vụ.

| Module | Kiểm tra |
| --- | --- |
| Danh mục | Phòng PB01/PB02, chức vụ CV01 và ca CA01 08:00–17:00, 8 giờ quy đổi. |
| Tuyển dụng | NV002 thử việc đến 30/11/2026; đánh giá sớm phải từ chối. |
| Hợp đồng | NV003 đã đạt 01/10/2026, chưa có hợp đồng; có thể dùng kiểm tra ký ngắn hạn với ngày phù hợp. |
| Lương/chức vụ | NV001 có QL001/QC001 từ 01/08/2026; không nhận cùng NV/ngày hiệu lực lần nữa. |
| Kế hoạch/công | KH001, PB01, tuần 19/10/2026; phân công NV001 hoặc NV002 trong tuần, rồi chấm công đúng ca. |
| Phụ trội | Phải có kế hoạch số giờ dự kiến; mỗi dòng là mã NV. Danh sách hỗ trợ nhiều dòng. |
| Thưởng/phạt | Chọn Cá nhân/Phòng ban, nhập `MaNV;SoTien` mỗi dòng. Cá nhân NV001 300000; tập thể PB01 có thể phân bổ NV001;300000 và NV002;200000, tổng 500000. |
| Bảng lương | Xem BL092026; tính tháng khác sau khi có dữ liệu công/lương phù hợp; xuất CSV từ tab Chi tiết. |

## Quy tắc và công thức

- Hồ sơ và QĐ tuyển dụng cùng transaction. Đánh giá sau hết thử việc; chỉ đạt mới ký, hợp đồng không chồng thời hạn.
- Dài hạn bắt buộc BHYT + BHXH trong cùng transaction; ngắn hạn có ngày hết hạn.
- Phụ trội ba hình thức đều hệ số **1,5** như đề.
- Thưởng/phạt chọn đúng một cá nhân hoặc phòng; phân bổ dương, đúng đối tượng và tổng tiền. Quyết định + phân bổ + phiếu chi/thu cùng commit hoặc rollback. Thông tin người ký ghi từ quyết định đã ký, chưa tích hợp chữ ký số.
- `Qua lương` mới cộng/trừ lương. `Trực tiếp` có chứng từ riêng và không tính lần hai. Tháng đã lập lương không nhận thêm công, phụ trội hoặc thưởng/phạt Qua lương.
- Mức tháng = cơ bản + PC lương + PC độc hại + PC chức vụ; dùng QĐ mới nhất hiệu lực đến cuối tháng. Khi chưa có QĐ lương, dùng mức thử việc. Chưa chia giai đoạn khi mức lương thay đổi trong tháng.
- Đơn giá giờ = mức tháng / (công chuẩn × giờ/ngày); tiền công = đơn giá giờ × giờ thực tế; phụ trội = đơn giá giờ × giờ PT × 1,5. Làm tròn số tiền đến đồng.
- Bảo hiểm = mức đóng × (tỷ lệ YT + tỷ lệ XH). Công chuẩn và tỷ lệ là tham số mẫu nhập, không phải tỷ lệ cố định do đề quy định.
- Thực lĩnh = công + PT + thưởng − BH − phạt. Bảng tháng gồm nhân viên có chấm công, kể cả dòng công 0 giờ; số liệu chi tiết được lưu tại lúc lập.

Mẫu NV001: mức tháng 10 triệu, 208 giờ công, 8 giờ PT, công chuẩn 26 × 8 giờ → công 10 triệu, PT 576923; BH 8000000 × (0,015 + 0,08) = 760000; thưởng 300000, phạt 100000 → **10016923 đ**.

## Kết quả kiểm tra

Ngày 23/10/2026: build Release thành công; **41/41** ca kiểm tra nghiệp vụ/CSDL và **322/322** kiểm tra Form đạt. Các ca ghi dữ liệu dùng CSDL kiểm thử riêng. Kiểm tra Form mở đủ 9 Form và 20 màn hình/tab, đọc dữ liệu SQL và kiểm tra vùng nhập/cột ở kích thước mặc định, nhỏ nhất.

Để kiểm tra lại trực tiếp, chạy script SQL, mở solution và thực hiện các tình huống trong bảng Module ở trên. Đối chiếu BL092026 của NV001: công 208 giờ, phụ trội 8 giờ, tiền công 10.000.000 đ, tiền phụ trội 576.923 đ, bảo hiểm 760.000 đ, thưởng 300.000 đ, phạt 100.000 đ, thực lĩnh **10.016.923 đ**.

Ảnh giao diện trong Word được lấy bằng DrawToBitmap từ Form đang chạy với SQL Server. Kiểm tra Form chưa tự động bấm mọi nút ghi dữ liệu, thử mọi hộp thoại hoặc mọi DPI Windows.

## Lỗi gặp và cách khắc phục

| Tình huống | Khắc phục |
| --- | --- |
| Thiếu BH khi ký dài hạn | Nhập đủ mã hồ sơ, số YT/XH, mức đóng và tỷ lệ; transaction rollback khi lỗi. |
| Trùng mã/quyết định/tháng | Dùng mã mới, kiểm tra lịch sử; PK/UNIQUE ngăn ghi trùng. |
| Phân bổ sai tổng hoặc sai phòng | Kiểm tra từng dòng MaNV;SoTien; không tự chia đều tập thể. |
| Cột dài | Wrap hàng/tiêu đề, chia cột, kiểm tra đủ Form và tab. |
| Không kết nối SQL | Kiểm tra dịch vụ SQL, Data Source và script đúng LAB7. |

## Nộp bài

LAB7 gồm Word, source WinForms, một script SQL và README; các file nguồn sơ đồ nằm tại [IMAGES/LAB7](../IMAGES/LAB7). Bỏ bin/obj/.vs, file khóa Word, MDF/LDF, backup và thông tin xác thực khỏi Git. Việc nộp Word tổng hợp, đặt link repository và duy trì quyền Public thực hiện theo [hướng dẫn chung](../README.md#quy-định-cập-nhật-và-nộp-bài-tổng-hợp). Kiểm tra nội dung trên máy trước khi tự commit/push.

[Quay về danh sách bài Lab](../README.md).

## File nguồn sơ đồ cho báo cáo tổng hợp

[Danh mục hình và file nguồn](../IMAGES/README.md) liệt kê 18 file của LAB7. Mỗi sơ đồ là một file `.drawio` riêng tại [IMAGES/LAB7](../IMAGES/LAB7).
