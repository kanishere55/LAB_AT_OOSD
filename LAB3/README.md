# LAB3 — Hệ thống quản lý khách sạn

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.

## Mục tiêu và nội dung đã thực hiện

Xây dựng ứng dụng quản lý khách sạn bằng C# Windows Forms và SQL Server, tổ chức thành phần giao diện, xử lý nghiệp vụ và truy cập dữ liệu.

| Màn hình | Nội dung trong mã nguồn |
| --- | --- |
| `FrmMain` | Điều hướng đến các nhóm chức năng |
| `FrmDanhMuc` | Khu vực, nhân viên, loại tiện nghi, dịch vụ và quy định đền bù |
| `FrmPhongTienNghi` | Phòng, tiện nghi, phiếu lắp đặt/luân chuyển |
| `FrmDatPhong` | Khách hàng, đặt phòng, nhận phòng, người lưu trú và đánh dấu no-show |
| `FrmDichVu` | Ghi nhận sử dụng dịch vụ và xem lịch sử theo phiếu lưu trú |
| `FrmTraPhong` | Đền bù, lập hóa đơn, ghi nhận thanh toán và hoàn tất trả phòng |
| `FrmThongKe` | Tổng hợp phiếu đặt, khách đang ở, hóa đơn, đền bù và dịch vụ theo dữ liệu CSDL |

CSDL gồm **18 bảng**, có khóa chính, khóa ngoại và các ràng buộc dữ liệu. Script khởi tạo có dữ liệu mẫu cho danh mục, phòng, tiện nghi, dịch vụ và quy định đền bù.

## Môi trường và phiên bản

| Thành phần | Cấu hình |
| --- | --- |
| Hệ điều hành kiểm tra | Windows 11 |
| IDE/build đã kiểm tra | Visual Studio Community 2022 **17.14.41**, MSBuild đi kèm |
| Project | C#, Windows Forms, **.NET Framework 4.7.2** |
| Truy cập CSDL | ADO.NET, `System.Data.SqlClient` |
| CSDL đã kết nối | SQL Server LocalDB **15.0.4382.1** |
| Instance mặc định | `(localdb)\MSSQLLocalDB` |
| Database | `QuanLyKhachSan` |
| Xác thực | Windows Authentication |

Visual Studio cần workload **.NET desktop development** và bộ targeting/developer pack .NET Framework 4.7.2. Có thể dùng SQL Server instance khác bằng cách điều chỉnh cấu hình kết nối.

## Cấu trúc và các file chính

```text
LAB3/
├── README.md
├── Database/
│   └── SQL.sql
├── QuanLyKhachSan/
│   ├── QuanLyKhachSan.sln
│   └── QuanLyKhachSan/
│       ├── QuanLyKhachSan.csproj
│       ├── App.config
│       ├── Program.cs
│       ├── Models.cs
│       ├── Data/
│       ├── Forms/
│       ├── Services/
│       └── Properties/
└── 1250080021_NguyenThanhCan_CNPM1_LAB03.docx
```

- [Solution](QuanLyKhachSan/QuanLyKhachSan.sln): mở ứng dụng trong Visual Studio.
- [Script SQL](Database/SQL.sql): bản khởi tạo CSDL dùng cho bài.
- [App.config](QuanLyKhachSan/QuanLyKhachSan/App.config): chuỗi kết nối `QuanLyKhachSanDB`.
- `Forms`: giao diện; `Services`: xử lý nghiệp vụ; `Data/Db.cs`: kết nối và thực thi truy vấn.

## Hướng dẫn chuẩn bị và chạy lại

### 1. Chuẩn bị LocalDB

Mở PowerShell:

```powershell
sqllocaldb info
```

Nếu chưa có instance `MSSQLLocalDB`, tạo bằng `sqllocaldb create MSSQLLocalDB`. Sau đó khởi động:

```powershell
sqllocaldb start MSSQLLocalDB
```

### 2. Khởi tạo cơ sở dữ liệu trên máy mới

1. Mở SQL Server Management Studio.
2. Kết nối server **`(localdb)\MSSQLLocalDB`**, chọn **Windows Authentication**.
3. Mở [Database/SQL.sql](Database/SQL.sql) và Execute để tạo database, bảng và dữ liệu mẫu.

**Script có `DROP TABLE`: chạy lại sẽ xóa dữ liệu trong các bảng của bài. Chỉ thực hiện khi khởi tạo môi trường mới hoặc chủ động đặt lại dữ liệu, có sao lưu khi cần. Nếu CSDL đã đầy đủ thì bỏ qua bước khởi tạo.**

Kiểm tra sau khi khởi tạo:

```sql
USE QuanLyKhachSan;
SELECT name FROM sys.tables ORDER BY name;
SELECT SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai
FROM dbo.Phong;
```

Script có các phòng mẫu `A101`, `A102`, `B201`, dịch vụ `DV01`, `DV02`, `DV03` và nhân viên `NV01`, `NV02`, `NV03`. Script chưa tạo sẵn khách hàng, phiếu đặt hoặc hóa đơn; cần nhập khách hàng và lập phiếu nếu muốn kiểm tra luồng lưu trú từ đầu.

### 3. Kiểm tra chuỗi kết nối

[App.config](QuanLyKhachSan/QuanLyKhachSan/App.config) đang sử dụng:

```text
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyKhachSan;Integrated Security=True;
```

Nếu SQL Server trên máy khác có tên instance khác, sửa `Data Source` cho đúng nơi đã chạy script. Giữ đúng tên database `QuanLyKhachSan` hoặc điều chỉnh đồng bộ nếu chủ động đổi tên CSDL. Build lại sau khi sửa cấu hình.

### 4. Build và chạy ứng dụng

1. Mở [QuanLyKhachSan.sln](QuanLyKhachSan/QuanLyKhachSan.sln).
2. Đặt `QuanLyKhachSan` làm Startup Project nếu cần.
3. Chọn cấu hình **Debug**, chạy **Build Solution**.
4. Nhấn **F5** hoặc **Ctrl+F5** để mở form chính.
5. Mở các chức năng từ form chính và kiểm tra dữ liệu đã khởi tạo.

Có thể build trong Developer PowerShell của Visual Studio, đứng tại `LAB3`:

```powershell
msbuild .\QuanLyKhachSan\QuanLyKhachSan.sln /t:Rebuild /p:Configuration=Debug
```

### 5. Trình tự kiểm tra nghiệp vụ

Trên database thực hành:

1. Kiểm tra danh mục, phòng và tiện nghi. Lập phiếu lắp đặt nếu cần theo dõi tiện nghi trong phòng.
2. Thêm khách hàng, chọn phòng và lập phiếu đặt với ngày nhận/trả dự kiến hợp lệ.
3. Ghi nhận người lưu trú và nhận phòng theo thông báo kiểm tra của chương trình.
4. Chọn phiếu đang ở để ghi nhận dịch vụ.
5. Kiểm tra tiện nghi khi trả phòng; lập phiếu đền bù nếu có phát sinh.
6. Lập hóa đơn, ghi nhận thanh toán và hoàn tất trả phòng.
7. Chọn khoảng ngày ở màn hình thống kê để xem dữ liệu tương ứng.

Các bước trên thay đổi dữ liệu thực hành. Dùng mã phiếu mới để tránh trùng khóa với dữ liệu đã có.

## Kết quả kiểm tra

Ngày **25/09/2026**:

- Rebuild solution bằng MSBuild của Visual Studio 2022 thành công sau khi sắp xếp file SQL.
- Kết nối `(localdb)\MSSQLLocalDB` bằng Windows Authentication thành công.
- Database `QuanLyKhachSan` có **18 bảng**.
- File SQL dùng để khởi tạo được đặt tại `Database/SQL.sql`.

Lần kiểm tra này xác nhận khả năng biên dịch và truy vấn CSDL hiện có. Chưa chạy lại toàn bộ thao tác thêm/sửa và chu trình đặt phòng → nhận phòng → dịch vụ → thanh toán trong lần kiểm tra này. Kết quả nghiệp vụ cần đối chiếu với dữ liệu thực tế khi thực hiện trình tự ở trên.

## Lỗi gặp phải và cách khắc phục

### Lỗi kết nối SQL Server khi mở form

Đã gặp `System.Data.SqlClient.SqlException` tại `cn.Open()`, thông báo không tìm thấy hoặc không truy cập được SQL Server (`A network-related or instance-specific error...`).

Các bước kiểm tra:

1. Kiểm tra tên instance trong `App.config` và danh sách `sqllocaldb info`.
2. Kiểm tra/khởi động instance bằng `sqllocaldb info MSSQLLocalDB` và `sqllocaldb start MSSQLLocalDB`.
3. Kết nối bằng SSMS với cùng server, xác thực Windows và database `QuanLyKhachSan`.
4. Dừng phiên debug hiện tại, build lại và chạy chương trình để sử dụng cấu hình mới nhất.
5. Nếu lỗi còn xuất hiện, lấy đầy đủ **Copy Details** của exception, đặc biệt mã lỗi, để xác định nguyên nhân.

### Các tình huống khi chạy trên máy khác

| Hiện tượng | Cách xử lý |
| --- | --- |
| Thiếu .NET Framework 4.7.2 targeting pack | Cài thành phần tương ứng trong Visual Studio Installer rồi build lại |
| Không tìm thấy database/bảng | Kiểm tra script đã chạy trên đúng instance và đúng database |
| Không có phiếu để chọn tại màn hình dịch vụ/trả phòng | Kiểm tra đã tạo phiếu đặt và hoàn tất nhận phòng; danh sách lấy theo phiếu đang ở |
| Trùng mã khi lập phiếu | Chọn mã mới và kiểm tra dữ liệu hiện có, không chạy lại SQL chỉ để xóa lỗi trùng mã |

## Báo cáo
[Tải báo cáo Word LAB3](1250080021_NguyenThanhCan_CNPM1_LAB03.docx).

[Quay về danh sách bài Lab](../README.md).
