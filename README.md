# LAB_AT_OOSD

Bài thực hành học phần **Phương pháp phát triển phần mềm hướng đối tượng**. Mỗi bài được lưu trong một thư mục LAB riêng, gồm hướng dẫn, báo cáo và các file hiện thực của bài đó.

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Repository hiện tại: [kanishere55/LAB_AT_OOSD](https://github.com/kanishere55/LAB_AT_OOSD).

## Danh sách bài thực hành

| Bài | Nội dung | Hướng dẫn và mã nguồn | Báo cáo |
| --- | --- | --- | --- |
| LAB1 | Các lớp hình học, kế thừa và đa hình bằng Java | [README LAB1](LAB1/README.md) | [Báo cáo LAB1](LAB1/1250080021_NguyenThanhCan_CNPM1_LAB01.docx) |
| LAB2 | Hệ thống quản lý thư viện | [README LAB2](LAB2/README.md) | [Báo cáo LAB2](LAB2/1250080021_NguyenThanhCan_CNPM1_LAB02.docx) |
| LAB3 | Hệ thống quản lý khách sạn | [README LAB3](LAB3/README.md) | [Báo cáo LAB3](LAB3/1250080021_NguyenThanhCan_CNPM1_LAB03.docx) |
| LAB4 | Cửa hàng online e-SHOPPING | [README LAB4](LAB4/README.md) | [Báo cáo LAB4](LAB4/1250080021_NguyenThanhCan_CNPM1_LAB04.docx) |
| LAB5 | Công ty du lịch Văn Hóa Việt, đề Bài 6 | [README LAB5](LAB5/README.md) | [Báo cáo LAB5](LAB5/1250080021_NguyenThanhCan_CNPM1_LAB5.docx) |

## Cấu trúc thư mục

```text
LAB_AT_OOSD/
├── README.md
├── .gitignore
├── LAB1/   README, báo cáo và mã nguồn Java
├── LAB2/   README, báo cáo, solution WinForms và SQL
├── LAB3/   README, báo cáo, Database và solution WinForms
├── LAB4/   README, báo cáo, UML, Database, solution, Tests, Evidence
└── LAB5/
    ├── README.md
    ├── 1250080021_NguyenThanhCan_CNPM1_LAB5.docx
    ├── Database/QuanLyCongTyDuLich.sql
    └── QuanLyCongTyDuLich/           Solution và project C#
```

## Môi trường và chạy bài

Clone repository hoặc tải ZIP, mở README của bài cần kiểm tra để chọn đúng môi trường và dữ liệu mẫu. LAB1 dùng Java; LAB2 đến LAB5 dùng C# WinForms **.NET Framework 4.7.2** và SQL Server. Visual Studio cần workload .NET desktop development và targeting pack tương ứng.

| Bài | Instance trên máy kiểm tra | Database |
| --- | --- | --- |
| LAB2 | `(localdb)\ProjectModels` | QuanLyThuVienDB |
| LAB3 | `(localdb)\MSSQLLocalDB` | QuanLyKhachSan |
| LAB4 | `.\MSSQLSERVER01` | QuanLyCuaHangOnline |
| LAB5 | `.\MSSQLSERVER01` | QuanLyCongTyDuLich |

Môi trường các bài trước có JDK **23.0.1**, Visual Studio Community 2022 dòng **17.14**, .NET Framework **4.7.2** và LocalDB **15.0.4382.1**. LAB4 và LAB5 đã chạy trên SQL Server 2022 **16.0.1000.6**. Chi tiết cấu hình, ngày kiểm tra và giới hạn của từng bài nằm trong README tương ứng.

Với bài WinForms, chạy script SQL của bài trên đúng instance, sửa Data Source trong cấu hình nếu cần, mở solution, Rebuild rồi F5. Không trộn script hoặc cấu hình của các database khác nhau. Báo cáo Word chứa mô hình và bằng chứng; mã nguồn, SQL và test giúp chạy lại để đối chiếu.

LAB5 có **9 Form, 8 Service và 16 bảng SQL Server**. Báo cáo trình bày phân tích và thiết kế UML, trong đó có 2 sơ đồ phân rã use case, 2 activity và 2 tuần tự cho các chức năng lịch chuyến và điểm tham quan. Báo cáo dùng A4 dọc, có 17 ảnh Form/tab và 2 ảnh đối chiếu CSDL. Cách cấu hình, chạy ứng dụng và các kịch bản kiểm tra được trình bày trong README của LAB5.

## Quy định cập nhật và nộp bài

Mỗi thư mục LAB chứa README với thông tin sinh viên, tên bài, môi trường, nội dung thực hiện, kết quả, lỗi/cách khắc phục và hướng dẫn chạy lại. Chỉ đưa báo cáo, source code, SQL, cấu hình an toàn, UML và bằng chứng của bài thực hành lên repository. .gitignore loại trừ dữ liệu IDE, bin/obj, file khóa Word, file database/backup và cấu hình bí mật.

Yêu cầu học phần nêu tên repository **LAB_OOSD**, Public nếu giảng viên không quy định khác. Repository hiện tại đang mang tên **LAB_AT_OOSD**; cần đối chiếu tên với quy định lớp trước khi nộp. Commit và push đủ file trước hạn, mở GitHub kiểm tra nội dung có thể truy cập, rồi nộp URL repository lên bài tương ứng trên Google Classroom. Nếu có yêu cầu video, chèn link ở đầu báo cáo. Sau hạn nộp, không xóa repository hoặc thay nội dung đã nộp khi chưa được giảng viên cho phép.
