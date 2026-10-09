# LAB5 — Quản lý công ty du lịch Văn Hóa Việt

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.
- Đề thực hành: **Bài 6 — Quản lý công ty du lịch**, tổ chức trong thư mục **LAB5**.

## Nội dung đã thực hiện

Phân tích tour và hành trình, khách lẻ theo chuyến, khách đoàn, tiền cọc và bảo hiểm, phân công hướng dẫn viên, thanh toán sau tour, khảo sát và lương tháng. Báo cáo trình bày các mô hình UML theo pha phân tích và pha thiết kế, SQL và ảnh ứng dụng kết nối CSDL.

Các sơ đồ cho chức năng lịch chuyến và điểm tham quan gồm:

- **2 use case phân rã:** quản lý lịch chuyến khách lẻ; quản lý danh mục điểm tham quan.
- **2 activity:** đóng đăng ký chuyến khách lẻ; thêm điểm tham quan vào danh mục.
- **2 tuần tự:** tạo chuyến khách lẻ; thêm điểm tham quan vào danh mục.

Báo cáo Word trình bày trên A4 dọc, gồm sơ đồ UML, thiết kế CSDL và 19 ảnh ứng dụng/CSDL.

Ứng dụng C# WinForms tổ chức theo **UI → Service → Data**, gồm **9 Form, 8 Service và 16 bảng SQL Server**. Form xử lý sự kiện và hiển thị; Service kiểm tra quy tắc; `Data/Db.cs` thực hiện ADO.NET với truy vấn tham số. Mã nguồn dùng DataTable và các lớp kết quả/danh sách thành viên. Entity trong hai sơ đồ tuần tự biểu diễn dữ liệu SQL được truy cập qua Data/Db.

| Form | Chức năng |
| --- | --- |
| FrmMain | Mở 8 chức năng và thoát |
| FrmDanhMuc | 4 tab: phương tiện, điểm bán, HDV, điểm tham quan |
| FrmTour | 4 tab: tour, điểm dừng, phương tiện theo chặng, điểm tham quan |
| FrmChuyenLe | Tạo chuyến, tính ngày về, đóng đăng ký |
| FrmDangKyLe | Đăng ký chuyến mở, tính tiền và thu tiền vé ngay |
| FrmDangKyDoan | Thông tin đoàn, tour, ngày đi, cọc, bảo hiểm, lập/hủy phiếu |
| FrmPhanCongHDV | Phân công chuyến hoặc đoàn, kiểm tra trùng lịch |
| FrmKetThucKhaoSat | Thanh toán đoàn sau tour, khảo sát và phản hồi |
| FrmLuongThongKe | Lương tháng/năm và tổng hợp theo khoảng ngày |

Khách lẻ **1–11 người**, khách đoàn **từ 13 người**; đúng 12 người bị từ chối vì đề không quy định. Đoàn mua bảo hiểm phải có đủ danh sách. Ngày về = ngày đi + số ngày − 1; tổng dự kiến = đơn giá × số người. Không đặt thêm mức cọc hay giá bảo hiểm ngoài đề. Hủy trước ngày đi giữ cọc và gỡ phân công. Mỗi chuyến lẻ có tối đa một phân công; đoàn có thể nhiều HDV. Lương tháng cộng thù lao của các tour kết thúc trong tháng.

Lập/hủy phiếu đoàn dùng transaction. Phân công và thanh toán dùng transaction Serializable để kiểm tra và ghi cùng giao dịch. Khảo sát được lưu trong SQL; nút gửi chưa tích hợp email/SMS. Website quảng cáo, đăng nhập và phân quyền nằm ngoài phần hiện thực. Hành trình mẫu xuất phát/kết thúc TP.HCM; khi thêm điểm dừng, chương trình chưa bắt buộc tour phải có đủ điểm cuối ngay từ lúc tạo.

## Môi trường và phiên bản

| Thành phần | Cấu hình đã kiểm tra |
| --- | --- |
| Hệ điều hành | Windows 11 |
| IDE | Visual Studio Community 2022, dòng 17.14 |
| Project | C#, Windows Forms, .NET Framework **4.7.2**, Any CPU |
| Truy cập CSDL | ADO.NET, System.Data.SqlClient |
| SQL Server | 2022 Developer, **16.0.1000.6** |
| Instance | `.\MSSQLSERVER01` |
| Database | `QuanLyCongTyDuLich` |
| Xác thực | Windows Authentication |

Visual Studio cần workload **.NET desktop development** và targeting/developer pack **.NET Framework 4.7.2**. Project không cần cài NuGet để chạy.

## Các file chính

- [Báo cáo Word](1250080021_NguyenThanhCan_CNPM1_LAB5.docx): phân tích nghiệp vụ, mô hình UML, thiết kế CSDL, SQL và ảnh kết quả chạy ứng dụng.
- [Solution](QuanLyCongTyDuLich/QuanLyCongTyDuLich.sln).
- [Script tạo CSDL và dữ liệu mẫu](Database/QuanLyCongTyDuLich.sql).
- [Cấu hình kết nối](QuanLyCongTyDuLich/QuanLyCongTyDuLich/App.config).

## Hướng dẫn kiểm tra và chạy lại

1. Mở SSMS, kết nối SQL Server có quyền tạo database. Chạy toàn bộ `Database/QuanLyCongTyDuLich.sql`. Script tạo 16 bảng, PK/FK/CHECK/UNIQUE và dữ liệu mẫu; chạy lại không xóa bảng hoặc ghi đè dữ liệu đã có.
2. Mở solution bằng Visual Studio. Trong `App.config`, giữ `Initial Catalog=QuanLyCongTyDuLich`, đổi `Data Source` theo instance máy chạy. Cấu hình hiện tại:

   ```text
   Data Source=.\MSSQLSERVER01;Initial Catalog=QuanLyCongTyDuLich;Integrated Security=True
   ```

3. Chọn project `QuanLyCongTyDuLich` làm Startup Project. Chọn **Release** hoặc **Debug**, Rebuild Solution rồi F5. `Program.cs` chạy `FrmMain`; `Form1` là Form trống ban đầu.
4. Mở từng chức năng. Tour T001 có 3 ngày, 2 đêm, giá 2.500.000 đ. Chuyến CL002/CL003 đang mở; CL001 đã đóng.
5. Muốn chỉnh giao diện, mở `Forms`, nhấp phải file `Frm*.cs` rồi chọn **View Designer**. Mỗi Form có code sự kiện và file Designer.

Có thể chạy SQL bằng `sqlcmd` từ thư mục LAB5. Tham số `-f 65001` giữ đúng tiếng Việt:

```powershell
sqlcmd -S '.\MSSQLSERVER01' -E -f 65001 -b -i '.\Database\QuanLyCongTyDuLich.sql'
```

## Kịch bản kiểm tra nhanh

Dùng các mã chưa tồn tại. Các ngày dưới đây phù hợp lần kiểm tra **09/10/2026**; nếu chạy sau ngày khởi hành, đổi ngày thử sang tương lai.

1. **Khách lẻ:** DKL003, CL002, DB01, Hoàng Văn Phúc, điện thoại mẫu 0912000003, 4 người. Thành tiền **10.000.000 đ**; đăng ký và thanh toán vé.
2. **Đoàn:** DK03/DD003, T003, đi 05/01/2027, 15 người, cọc 30.000.000 đ. Nhập đầy đủ cơ quan, địa chỉ, điện thoại, đại diện và nơi đón. Kết thúc dự kiến 09/01/2027, tổng **133.500.000 đ**. Tích bảo hiểm thì nhập đủ 15 dòng họ tên; ngày sinh dùng dd/MM/yyyy hoặc để trống.
3. **Phân công:** PC004, HDV01, loại LE, CL002, thù lao 1.500.000 đ. Sau lưu, CL002 không còn trong danh sách chuyến chưa có HDV. Thử gán thêm HDV khác để kiểm tra từ chối.
4. **Thanh toán:** chọn DD001, TT001, ngày 15/09/2026, **40.000.000 đ**. Trạng thái chuyển thành Đã hoàn tất thanh toán; thử trả 50.000.000 đ trước đó để kiểm tra từ chối.
5. **Khảo sát:** DOAN/DD001, KS002, gửi 15/09/2026; phản hồi 16/09/2026, điểm 4, góp ý Lịch trình hợp lý.
6. **Lương:** tháng 9 năm 2026, trước khi thêm phân công mới kết thúc trong tháng 9: HDV01 **10.500.000 đ**, HDV02 **11.500.000 đ**, HDV03 **10.500.000 đ**.

Các thao tác này ghi vào database ứng dụng. Dùng database riêng được tạo từ script SQL nếu cần thử mà không ảnh hưởng dữ liệu đang sử dụng.

## Kết quả kiểm tra

Kết quả ngày **09/10/2026**:

- Build Release thành công.
- **41 kiểm tra nghiệp vụ/CSDL đạt, 0 lỗi**, gồm đăng ký, rollback, bảo hiểm, cọc, ngày, hạng sao, HDV, khảo sát trùng và thanh toán.
- **28 kiểm tra Form đạt, 0 lỗi**: mở 9 Form, đọc SQL, tính lương/thống kê, kiểm tra vùng control và độ rõ của bảng.
- **68 tình huống bố cục đạt, 0 vấn đề**: 17 màn hình/tab × dữ liệu mẫu/dài × kích thước gốc/mô phỏng 125%. Kiểm tra cột, hàng, nhãn, nút, combobox, số tiền và chồng lấn. 125% là mô phỏng control/font trong harness, không thay DPI Windows.
- Đã chạy và chụp trực tiếp đủ 9 Form cùng mọi tab; báo cáo có **17 ảnh cửa sổ ứng dụng và 2 ảnh CSDL**.
- Script SQL chạy lại thành công, không nhân đôi mã mẫu.

Kiểm tra nghiệp vụ gọi Service rồi truy vấn SQL đối chiếu. Kiểm tra Form gồm khởi tạo/hiển thị và các nút đọc dữ liệu; chưa tự động bấm mọi nút ghi dữ liệu và xử lý mọi hộp thoại. Với các kịch bản đăng ký đoàn, chọn ngày đi trong tương lai khi chạy lại.

## Lỗi gặp và cách khắc phục

| Tình huống | Cách xử lý |
| --- | --- |
| Cột dữ liệu hoặc tiêu đề bị che | Chia độ rộng theo tiêu đề/nội dung; wrap ô dài; tính lại chiều cao hàng sau khi chia cột; rà mọi Form và tab |
| Nhãn chạm ô nhập | Điều chỉnh khoảng cách nhãn và control trong 8 Form nghiệp vụ |
| SQL lỗi dấu tiếng Việt | NVARCHAR, literal N và sqlcmd UTF-8 `-f 65001` |
| Không kết nối SQL | Kiểm tra instance, dịch vụ, database và Data Source trong App.config |
| EXE đang chạy làm build không chép được | Shift+F5, đóng bản đang chạy, Rebuild rồi F5 |
| Mã trùng hoặc dữ liệu không hợp lệ | Service trả thông báo; PK/FK/CHECK/UNIQUE ngăn ghi sai; transaction rollback khi cần |

## Tổ chức và nộp bài

Thư mục LAB5 gồm báo cáo Word, README, script SQL và project C# WinForms. Dữ liệu trong script SQL là dữ liệu mẫu. Không đưa bin/obj/.vs, mật khẩu, file database MDF/LDF, bản backup hoặc file khóa Word lên GitHub.

Theo yêu cầu học phần, repository nộp có tên **LAB_OOSD** và để Public nếu lớp không có quy định khác. Remote hiện tại là **LAB_AT_OOSD**; cần đối chiếu tên với quy định lớp trước khi nộp. Commit và push báo cáo, source code, SQL và README; mở GitHub kiểm tra thư mục LAB5 truy cập được rồi dán URL repository vào Google Classroom. Nếu giảng viên yêu cầu video, đặt link ở đầu báo cáo. Sau hạn nộp, giữ nội dung đã nộp khi chưa được phép sửa.
