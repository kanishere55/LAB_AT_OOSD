# Kịch bản kiểm thử LAB6

## Cách chạy và dữ liệu

Chạy `Run-Checks.ps1` từ PowerShell có Visual Studio 2022 và SQL Server. Database ghi kiểm thử là `QuanLyHoSoBenhAn_Test`. Mã bệnh nhân/phiếu/toa dùng hậu tố riêng cho mỗi lượt; các giá trị ngày và số tiền dưới đây được khai báo trong `BusinessChecks.cs`. Không xóa dữ liệu ứng dụng để chạy test.

| Nhóm ca | Dữ liệu cụ thể | Mong đợi |
| --- | --- | --- |
| T01–T06 | BN mới, sinh 01/01/1990, đăng ký 01/01/2026, ảnh PNG mẫu, lệ phí 100.000 đ; biến thể thiếu ảnh/phí 0/ngày sinh sau đăng ký/trùng HS hoặc phiếu | Bốn bảng đồng bộ khi hợp lệ; không còn bản ghi mới khi lỗi |
| T07–T09 | Thu tiếp từ 31/12/2026 và 01/01/2027; tra bằng mã hồ sơ/0900000099 | Từ chối chồng thời hạn, nhận năm tiếp theo, tìm được đúng hồ sơ |
| T10–T16 | Điều trị 01/10/2026; định kỳ 02/10/2026, thử lại 15/12/2026 và 02/01/2027 | FK đúng; định kỳ phí 0, không trùng quý; quý mới cần còn quyền lợi |
| T17–T25 | Hẹn 20/10/2026 08:00, hủy và hẹn lại 21/10/2026 08:00; thử sai hồ sơ/hẹn hủy/ngày đổi hết hạn | Kiểm tra quý, quyền lợi, đúng hẹn và trạng thái; tạo phiếu cập nhật hẹn nguyên tử |
| T26–T33 | Phiếu có/không kết luận, bác sĩ BS01/BS02, chỉ định XN01 lúc 01/10/2026 08:00, trả kết quả 09:00 | Chặn kê toa khi sai bác sĩ, thiếu kết luận/kết quả; chặn ngày trả trước chỉ định |
| T34–T38 | Thuốc không có, số lượng 0, toa rỗng; toa hợp lệ T01 số lượng 2, T02 số lượng 3, liều/cách dùng mẫu | Lỗi chi tiết rollback toa; lưu đủ 2 dòng, cấm toa thứ hai, xuất đủ dữ liệu |
| T39–T45 | Các tổ hợp cờ xuất viện/thanh toán; định kỳ có kết luận và không có toa | Chỉ hoàn tất khi đủ điều kiện; đợt hoàn tất được khóa; khám định kỳ có thể không kê thuốc |
| T46–T47 | Hai task cùng gia hạn năm 2027; hai task đặt hẹn quý II/2027 | Mỗi nhóm đúng 1 thành công, 1 từ chối |
| T48–T50 | Cập nhật kết quả NULL sau hoàn thành; hoàn tất khi XN còn chờ; lập phiếu hẹn với bác sĩ không tồn tại | CHECK chặn NULL; chặn hoàn tất; lỗi FK không thay đổi hẹn |
| U01–U12 | Bệnh nhân sinh 01/01/2000, đăng ký 16/10/2026, khám có XN, toa T01 số lượng 2, hoàn tất; hẹn 10/01/2027 08:00 | Nút trên Form gọi đúng Service và ghi dữ liệu SQL; cập nhật nhân thân, lệ phí và danh mục được kiểm tra |

## Kết quả

- 50 kiểm thử Service/CSDL đạt, 0 lỗi: [BusinessResults.csv](BusinessResults.csv).
- 12 kiểm thử luồng Form đạt, 0 lỗi: [UiWorkflowResults.csv](UiWorkflowResults.csv).
- 265 kiểm tra bố cục/nguồn dữ liệu đạt, 0 lỗi: [FormResults.csv](../Evidence/FormResults.csv).

Kiểm thử Form thực thi các nút ghi trong luồng hợp lệ; các ca lỗi nghiệp vụ được kiểm tra ở Service/SQL. Không tự động in ra máy in hoặc thử mọi hộp thoại, mọi DPI. `Capture-Forms.ps1` cần seed ứng dụng để ghi ảnh có dữ liệu. [Truy vết](TruyVetYeuCau.md) liên kết yêu cầu, UML, Form/Service, bảng và test.
