# LAB_AT_OOSD

Bài thực hành học phần **Phương pháp phát triển phần mềm hướng đối tượng**.

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Repository: [kanishere55/LAB_AT_OOSD](https://github.com/kanishere55/LAB_AT_OOSD).

## Danh sách bài thực hành

| Bài | Nội dung | Mã nguồn và hướng dẫn | Báo cáo |
| --- | --- | --- | --- |
| LAB1 | Các lớp hình học, kế thừa và đa hình bằng Java | [README LAB1](LAB1/README.md) | [Báo cáo LAB1](LAB1/1250080021_NguyenThanhCan_CNPM1_LAB01.docx) |
| LAB2 | Hệ thống quản lý thư viện | [README LAB2](LAB2/README.md) | [Báo cáo LAB2](LAB2/1250080021_NguyenThanhCan_CNPM1_LAB02.docx) |
| LAB3 | Hệ thống quản lý khách sạn | [README LAB3](LAB3/README.md) | [Báo cáo LAB3](LAB3/1250080021_NguyenThanhCan_CNPM1_LAB03.docx) |

## Cấu trúc thư mục

```text
LAB_AT_OOSD/
├── README.md
├── .gitignore
├── LAB1/
│   ├── README.md
│   ├── Baitap_oop/                 # Mã nguồn Java
│   └── 1250080021_NguyenThanhCan_CNPM1_LAB01.docx
├── LAB2/
│   ├── README.md
│   ├── QuanLyThuVien.sln
│   ├── QuanLyThuVien/              # Project C# và SQL.sql
│   └── 1250080021_NguyenThanhCan_CNPM1_LAB02.docx
└── LAB3/
    ├── README.md
    ├── Database/SQL.sql            # Script khởi tạo CSDL khách sạn
    ├── QuanLyKhachSan/             # Solution và project C#
    └── 1250080021_NguyenThanhCan_CNPM1_LAB03.docx
```

## Kiểm tra và chạy bài

1. Clone repository hoặc tải ZIP và giải nén toàn bộ thư mục.
2. Mở README của bài cần kiểm tra trong bảng trên.
3. LAB1: biên dịch bằng JDK và chạy lớp `Main`.
4. LAB2, LAB3: chuẩn bị SQL Server, làm theo hướng dẫn khởi tạo CSDL của từng bài, mở solution bằng Visual Studio và chạy project.
5. Tải báo cáo Word tương ứng để xem nội dung báo cáo và hình ảnh trong bài.

Môi trường đã kiểm tra ngày **25/09/2026**: Windows 11, JDK **23.0.1**, Visual Studio Community 2022 **17.14.41**, .NET Framework **4.7.2**, SQL Server LocalDB **15.0.4382.1**. Chi tiết kết quả và giới hạn kiểm tra được ghi tại README từng Lab.

LAB2 sử dụng `(localdb)\ProjectModels` với database `QuanLyThuVienDB`; LAB3 sử dụng `(localdb)\MSSQLLocalDB` với database `QuanLyKhachSan`. Cần chọn đúng instance khi chạy SQL và cấu hình ứng dụng.

**Lưu ý về dữ liệu:** các script SQL có lệnh xóa và tạo lại bảng. Chỉ chạy để khởi tạo môi trường thực hành mới hoặc khi chủ động đặt lại dữ liệu; sao lưu trước nếu CSDL đã có dữ liệu cần giữ.

## Quy ước lưu trữ

- Mỗi Lab có README, mã nguồn và báo cáo riêng trong thư mục của bài đó.
- Các thư mục `bin`, `obj`, `.vs`, file Java đã biên dịch và file khóa Word được bỏ qua bởi `.gitignore`. Visual Studio/JDK sẽ tạo lại đầu ra khi build.
- Cấu hình kết nối hiện dùng Windows Authentication. Không đưa mật khẩu, khóa truy cập hoặc dữ liệu cá nhân thực tế vào repository công khai.
- Khi nộp bài, kiểm tra các thay đổi đã được commit/push và mở repository trên GitHub để xác nhận README, mã nguồn, SQL và báo cáo truy cập được.
