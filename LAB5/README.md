# LAB5 — Quản lý công ty du lịch Văn Hóa Việt

Ứng dụng C# WinForms .NET Framework 4.7.2 được hiện thực trực tiếp trong solution QuanLyCongTyDuLich của LAB5. Giao diện bám các Hình P.23–P.35 trong đề Bai_6_Quan_ly_cong_ty_du_lich.docx: màn hình chính hai cột nút; nền xám; bảng trắng, dòng chọn xanh; các tab, nhóm nhập liệu và tên nút theo mẫu. Kích thước được điều chỉnh để sử dụng được trên màn hình máy hiện tại. Viền cửa sổ và biểu tượng DateTimePicker phụ thuộc phiên bản Windows.

## Các file chính

- `QuanLyCongTyDuLich/QuanLyCongTyDuLich.sln`: mở bằng Visual Studio.
- `Database/QuanLyCongTyDuLich.sql`: tạo 16 bảng, khóa ngoại, CHECK, unique index và dữ liệu mẫu. Chạy lại không xóa hoặc ghi đè các dòng đang có.
- `QuanLyCongTyDuLich/QuanLyCongTyDuLich/App.config`: cấu hình SQL Server.
- `QuanLyCongTyDuLich/QuanLyCongTyDuLich/Forms`: 9 Form, mỗi Form có file code và Designer để mở/sửa trong Visual Studio.
- `QuanLyCongTyDuLich/QuanLyCongTyDuLich/Services`: 8 Service nghiệp vụ, lớp kết quả và danh sách thành viên.
- `QuanLyCongTyDuLich/QuanLyCongTyDuLich/Data/Db.cs`: ADO.NET và transaction.
- `Tests`: bộ kiểm thử, script chạy, kết quả nghiệp vụ và kết quả Form.
- `Evidence`: 18 ảnh được dựng từ các Form chạy thật với dữ liệu SQL mẫu, gồm tất cả các tab và trường hợp mô tả dài tự xuống dòng.
- `TRACEABILITY.md`: liên kết yêu cầu, hình UML trong đề, Form, Service, bảng SQL và test case.

## Cấu hình đã chạy trên máy

| Thành phần | Cấu hình |
| --- | --- |
| Framework | .NET Framework 4.7.2 |
| UI | Windows Forms |
| CSDL | SQL Server 2022, instance `.\MSSQLSERVER01` |
| Database | `QuanLyCongTyDuLich` |
| Xác thực | Windows Authentication |
| Truy cập | System.Data.SqlClient, truy vấn có tham số |
| Build | MSBuild của Visual Studio Community, Release Any CPU |

CSDL đã được tạo và nạp dữ liệu trên máy ngày 09/10/2026. Chuỗi kết nối hiện tại:

```text
Data Source=.\MSSQLSERVER01;Initial Catalog=QuanLyCongTyDuLich;Integrated Security=True
```

## Mở và chạy

1. Mở `QuanLyCongTyDuLich/QuanLyCongTyDuLich.sln` trong Visual Studio.
2. Chọn project QuanLyCongTyDuLich làm Startup Project nếu cần. Chọn Debug hoặc Release, Build/Rebuild rồi F5.
3. Màn hình chính mở ra. Bấm một trong 8 chức năng để mở Form con.
4. Khi xem thiết kế, mở thư mục Forms, nhấp phải `FrmMain.cs`, `FrmTour.cs`… và chọn View Designer. Form1 là Form trống ban đầu, không phải màn hình khởi động.

Trên máy khác, chạy script SQL bằng SSMS trên instance phù hợp rồi sửa Data Source trong App.config. Không cần NuGet. Visual Studio cần .NET desktop development và targeting pack .NET Framework 4.7.2.

Nếu dùng sqlcmd thay SSMS, phải chỉ định UTF-8 để giữ dấu tiếng Việt:

```powershell
sqlcmd -S '.\MSSQLSERVER01' -E -f 65001 -b -i '.\Database\QuanLyCongTyDuLich.sql'
```

## Chức năng

| Form | Các thao tác |
| --- | --- |
| FrmMain | Mở 8 chức năng, thoát |
| FrmDanhMuc | Thêm phương tiện, điểm bán vé, hướng dẫn viên, điểm tham quan |
| FrmTour | Thêm tour, điểm dừng, phương tiện theo chặng, điểm tham quan của tour |
| FrmChuyenLe | Tạo chuyến, tự tính ngày về, đóng đăng ký chuyến được chọn |
| FrmDangKyLe | Chọn chuyến, điểm bán, số người, tính và ghi nhận thanh toán vé ngay |
| FrmDangKyDoan | Nhập đoàn, chọn tour/ngày đi, cọc, danh sách bảo hiểm, lập hoặc hủy phiếu |
| FrmPhanCongHDV | Phân công một HDV cho chuyến lẻ hoặc nhiều HDV cho đoàn; kiểm tra trùng lịch |
| FrmKetThucKhaoSat | Ghi thanh toán đoàn sau tour, tạo phiếu khảo sát, ghi phản hồi |
| FrmLuongThongKe | Tính lương tháng và tổng hợp 5 chỉ số theo khoảng ngày |

UI chỉ gọi Service, không viết SQL. Lập phiếu đoàn và hủy đoàn dùng transaction. Phân công và thanh toán sau tour dùng transaction Serializable; kiểm tra, ghi tiền và cập nhật trạng thái trong cùng giao dịch. Khảo sát được ghi nhận trong SQL theo đề; nút gửi không gửi email/SMS ngoài ứng dụng.

Giới hạn số người theo đề: khách lẻ 1–11, đoàn từ 13; đúng 12 người bị từ chối. Khách đoàn mua bảo hiểm phải nhập đủ số người. Không tự đặt thêm mức cọc hay giá bảo hiểm. Ngày thanh toán/gửi/nhận phản hồi không ở tương lai; thanh toán và gửi khảo sát phải sau ngày kết thúc tour.

## Thử nhanh với dữ liệu cụ thể

1. **Khách lẻ:** số đăng ký DKL003, chuyến CL002, điểm bán DB01, người Hoàng Văn Phúc, điện thoại 0912000003, 4 người. Thành tiền 10.000.000 đ; bấm Đăng ký và thanh toán vé.
2. **Đoàn:** mã DK03, số phiếu DD003, T003, đi 05/01/2027, 15 người, cọc 30.000.000 đ. Nhập đầy đủ cơ quan/gia đình, địa chỉ, điện thoại, đại diện, nơi đón. Kết thúc dự kiến 09/01/2027, tổng 133.500.000 đ. Nếu tích bảo hiểm, nhập đủ 15 dòng có họ tên; ngày sinh dùng dd/MM/yyyy hoặc để trống.
3. **HDV:** PC004, HDV01, loại LE, CL002, thù lao 1.500.000 đ. Sau khi lưu, CL002 biến mất khỏi danh sách chuyến chưa có HDV.
4. **Thanh toán:** chọn dòng DD001, số TT001, ngày 15/09/2026, 40.000.000 đ. Sau khi lưu, trạng thái Đã hoàn tất thanh toán.
5. **Khảo sát:** loại DOAN, DD001, KS002, ngày gửi 15/09/2026. Chọn KS002, phản hồi 16/09/2026, điểm 4, góp ý Lịch trình hợp lý.
6. **Lương:** tháng 9, năm 2026. Trước khi thêm phân công mới cho tháng 9, dữ liệu mẫu có HDV01 10.500.000 đ, HDV02 11.500.000 đ, HDV03 10.500.000 đ.

Mỗi mã được dùng một lần; nếu đã thực hiện các bước trên thì dùng mã mới. Các ngày thử lấy từ đề và phù hợp ngày kiểm tra 09/10/2026; khi sử dụng sau ngày khởi hành của dữ liệu tương lai, cần dời ngày phù hợp.

## Kiểm thử đã thực hiện

Sau khi build Release, chạy PowerShell tại LAB5:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\Tests\RunTests.ps1
```

Có thể truyền `-Server` nếu instance khác. Script tạo database kiểm thử riêng có hậu tố GUID, chạy dữ liệu mẫu và xóa đúng database đó sau khi kiểm thử. Không thêm, sửa hoặc xóa dữ liệu của database ứng dụng.

Kết quả ngày 09/10/2026:

- Release build thành công.
- 41 kiểm tra nghiệp vụ/CSDL đạt, 0 lỗi; bao phủ TC01–TC24 và kiểm tra bổ sung về dữ liệu lưu, rollback, bảo hiểm, tiền cọc, hạng sao, ngày, gửi khảo sát trùng và HDV không hợp lệ.
- 28 kiểm tra giao diện đạt, 0 lỗi trên 9 Form: mở Form, nạp dữ liệu, chạy nút tính lương/thống kê, kiểm tra vùng control, độ rộng tiêu đề cột, chiều cao nội dung, tổng độ rộng các cột và xuống dòng khi mô tả dài; dựng 18 ảnh để rà bố cục.
- SQL chạy lại thành công, dữ liệu mẫu không bị nhân đôi.

Kiểm thử Form kiểm tra khởi tạo và hiển thị; các nghiệp vụ ghi dữ liệu được kiểm thử qua Service kết hợp truy vấn đối chiếu SQL. Chưa tự động bấm từng nút ghi dữ liệu và xử lý mọi hộp thoại xác nhận trên giao diện.

Phần hiện thực này phục vụ phạm vi SQL, giao diện và kết nối của yêu cầu hiện tại. Các số hình UML trong TRACEABILITY trỏ đến đề Word; không coi đó là bộ UML/báo cáo nộp bài do sinh viên đã tự hoàn thiện.

## Điều chỉnh độ rộng bảng

Các Form có bảng dùng chiều rộng 1340 ở mức thiết kế, giữ bố cục các nhóm nhập liệu theo ảnh của thầy. Độ rộng cột được tính theo tiêu đề và dữ liệu thực tế; mã, số, ngày dùng cột gọn, tên và mô tả được cấp nhiều không gian hơn. Nội dung dài tự xuống dòng và hàng tự tăng chiều cao. Khi thay đổi kích thước bảng, nạp lại dữ liệu hoặc sửa ô, các cột được tính lại. Đăng ký lẻ giữ đúng 9 cột hiển thị của Hình P.30.
