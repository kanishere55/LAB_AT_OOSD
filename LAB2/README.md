# LAB2 — Hệ thống quản lý thư viện

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.

## Nội dung đã thực hiện

Ứng dụng C# Windows Forms quản lý thư viện, sử dụng ADO.NET để truy cập SQL Server. Mã nguồn gồm các nhóm chức năng:

- Quản lý nhân viên, thể loại và nhà xuất bản.
- Quản lý đầu sách và số lượng hiện có.
- Quản lý độc giả, cấp và gia hạn thẻ thư viện.
- Lập phiếu mượn, kiểm tra điều kiện thẻ, sách quá hạn và giới hạn số sách.
- Trả sách, ghi nhận tình trạng và phí phạt.
- Thống kê mượn, quá hạn, mất/hư hỏng sách và phí phạt.

## Môi trường và phiên bản

| Thành phần | Cấu hình |
| --- | --- |
| Hệ điều hành kiểm tra | Windows 11 |
| IDE/build đã kiểm tra | Visual Studio Community 2022 **17.14.41**, MSBuild đi kèm |
| Project | C#, Windows Forms, **.NET Framework 4.7.2** |
| CSDL đã kết nối | SQL Server LocalDB **15.0.4382.1** |
| Instance mặc định | `(localdb)\ProjectModels` |
| Database | `QuanLyThuVienDB` |
| Xác thực | Windows Authentication |

Visual Studio cần workload **.NET desktop development** và bộ targeting/developer pack .NET Framework 4.7.2. Có thể dùng SQL Server instance khác nếu sửa `Data Source` trong cấu hình cho khớp.

## Các file chính

- [QuanLyThuVien.sln](QuanLyThuVien.sln): solution mở bằng Visual Studio.
- [QuanLyThuVien.csproj](QuanLyThuVien/QuanLyThuVien.csproj): project ứng dụng.
- [SQL.sql](QuanLyThuVien/SQL.sql): khởi tạo 9 bảng, các ràng buộc và dữ liệu mẫu.
- [App.config](QuanLyThuVien/App.config): chuỗi kết nối `QuanLyThuVienDb`.
- `QuanLyThuVien/Forms`: giao diện; `Services`: nghiệp vụ; `Data/Db.cs`: truy cập CSDL; `Models.cs`: các lớp dữ liệu.

## Hướng dẫn chuẩn bị và chạy lại

### 1. Chuẩn bị SQL Server

Mở PowerShell và kiểm tra danh sách LocalDB:

```powershell
sqllocaldb info
```

Nếu chưa có `ProjectModels`, tạo instance bằng `sqllocaldb create ProjectModels`. Sau đó khởi động:

```powershell
sqllocaldb start ProjectModels
```

Trong SQL Server Management Studio, kết nối server `(localdb)\ProjectModels` bằng **Windows Authentication**, mở [SQL.sql](QuanLyThuVien/SQL.sql) và Execute để khởi tạo database trên môi trường thực hành mới.

**Script có `DROP TABLE`: chạy lại sẽ xóa dữ liệu trong các bảng của bài. Nếu database đang có dữ liệu cần giữ, hãy sao lưu và kiểm tra trước khi chạy.** Nếu đã có database đầy đủ thì bỏ qua bước khởi tạo.

Sau khi khởi tạo, có thể kiểm tra bằng truy vấn:

```sql
USE QuanLyThuVienDB;
SELECT name FROM sys.tables ORDER BY name;
SELECT COUNT(*) AS SoDauSach FROM dbo.DauSach;
```

Script cung cấp nhân viên, thể loại, nhà xuất bản, đầu sách, độc giả và thẻ mẫu. Thẻ mẫu có hạn đến **31/12/2026**; khi kiểm tra sau thời điểm này cần gia hạn thẻ trước khi mượn.

### 2. Kiểm tra cấu hình kết nối

Trong [App.config](QuanLyThuVien/App.config), chuỗi kết nối hiện tại là:

```text
Data Source=(localdb)\ProjectModels;Initial Catalog=QuanLyThuVienDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True
```

Nếu dùng instance khác, sửa `Data Source` tương ứng; database phải được tạo trên chính instance đó. Build lại sau khi sửa `App.config`.

### 3. Mở và chạy ứng dụng

1. Mở [QuanLyThuVien.sln](QuanLyThuVien.sln).
2. Đặt `QuanLyThuVien` làm Startup Project nếu Visual Studio yêu cầu.
3. Chọn cấu hình **Debug**, chạy **Build Solution**.
4. Nhấn **F5** hoặc **Ctrl+F5**.
5. Mở các màn hình từ form chính để kiểm tra danh mục, sách, độc giả, mượn/trả và thống kê.

Có thể build bằng Developer PowerShell của Visual Studio, đứng tại `LAB2`:

```powershell
msbuild .\QuanLyThuVien.sln /t:Rebuild /p:Configuration=Debug
```

### 4. Trình tự kiểm tra nghiệp vụ

Trên database thực hành, kiểm tra danh mục và đầu sách trước, tiếp theo chọn độc giả có thẻ còn hạn/đã đóng lệ phí, lập phiếu mượn, trả sách và xem thống kê. Các bước lập phiếu, trả sách, gia hạn thẻ sẽ thay đổi dữ liệu.

## Kết quả kiểm tra

Ngày **25/09/2026**:

- Rebuild solution bằng MSBuild của Visual Studio 2022 thành công.
- Kết nối `(localdb)\ProjectModels` bằng Windows Authentication thành công.
- Database `QuanLyThuVienDB` có **9 bảng**.

## Lỗi gặp phải và cách khắc phục

Không phát sinh lỗi trong lần rebuild và truy vấn CSDL nêu trên. Các tình huống có thể gặp khi thiết lập máy khác:

| Hiện tượng | Cách kiểm tra và xử lý |
| --- | --- |
| Thiếu targeting pack .NET Framework 4.7.2 | Bổ sung thành phần .NET Framework 4.7.2 trong Visual Studio Installer rồi build lại |
| Không kết nối được SQL Server | Kiểm tra instance bằng `sqllocaldb info`, khởi động `ProjectModels`, đối chiếu `Data Source` |
| Không mở được `QuanLyThuVienDB` hoặc không tìm thấy bảng | Kiểm tra đã khởi tạo SQL trên đúng instance và tên database trong `App.config` |
| Không đủ điều kiện mượn | Kiểm tra hạn thẻ, lệ phí, sách quá hạn và số sách đang mượn; xử lý dữ liệu theo thông báo nghiệp vụ |

## Báo cáo

[Tải báo cáo Word LAB2](1250080021_NguyenThanhCan_CNPM1_LAB02.docx).

[Quay về danh sách bài Lab](../README.md).
