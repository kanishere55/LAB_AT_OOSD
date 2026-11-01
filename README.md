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
| LAB6 | Hồ sơ bệnh án của bệnh nhân, đề Bài 5 | [README LAB6](LAB6/README.md) | [Báo cáo LAB6](LAB6/1250080021_NguyenThanhCan_CNPM1_LAB6.docx) |
| LAB7 | Nhân sự công ty sơn Đông Á | [README LAB7](LAB7/README.md) | [Báo cáo LAB7](LAB7/1250080021_NguyenThanhCan_CNPM1_LAB7.docx) |
| LAB8 | Cho thuê văn phòng cao ốc, đề Bài 4 | [README LAB8](LAB8/README.md) | [Báo cáo LAB8](LAB8/1250080021_NguyenThanhCan_CNPM1_LAB8.docx) |

## File sơ đồ draw.io

Mỗi sơ đồ được lưu thành một file `.drawio` riêng trong thư mục UML của bài tương ứng. Có thể mở bằng diagrams.net và chỉnh sửa các hình, thuộc tính, thông điệp và nhãn.

| Bài | Thư mục sơ đồ | Số file |
| --- | --- | ---: |
| LAB2 | [Quản lý thư viện](LAB2/UML) | 14 |
| LAB3 | [Quản lý khách sạn](LAB3/UML) | 37 |
| LAB4 | [e-SHOPPING và bài tập tổng hợp](LAB4/UML) | 12 |
| LAB5 | [Quản lý công ty du lịch](LAB5/UML) | 20 |
| LAB6 | [Quản lý hồ sơ bệnh án](LAB6/UML) | 8 |
| LAB7 | [Quản lý nhân sự](LAB7/UML) | 18 |
| LAB8 | [Cho thuê văn phòng cao ốc](LAB8/UML) | 22 |
| **Tổng** | | **131** |

## Cấu trúc thư mục

```text
LAB_AT_OOSD/
├── README.md
├── .gitignore
├── LAB1/   README, báo cáo và mã nguồn Java
├── LAB2/   README, báo cáo, UML, solution WinForms và SQL
├── LAB3/   README, báo cáo, UML, Database và solution WinForms
├── LAB4/   README, báo cáo, UML, Database, solution, Tests, Evidence
├── LAB5/
│   ├── README.md
│   ├── 1250080021_NguyenThanhCan_CNPM1_LAB5.docx
│   ├── UML/                         20 file draw.io riêng
│   ├── Database/QuanLyCongTyDuLich.sql
│   └── QuanLyCongTyDuLich/           Solution và project C#
├── LAB6/                            Word, UML, SQL, WinForms, Tests và Evidence
├── LAB7/                            Word, UML từng file, SQL kèm dữ liệu mẫu và WinForms
└── LAB8/                            Word A4, 22 file draw.io riêng, SQL kèm dữ liệu mẫu và WinForms
```

## Môi trường và chạy bài

Clone repository hoặc tải ZIP, mở README của bài cần kiểm tra để chọn đúng môi trường và dữ liệu mẫu. LAB1 dùng Java; LAB2 đến LAB8 dùng C# WinForms **.NET Framework 4.7.2** và SQL Server. Visual Studio cần workload .NET desktop development và targeting pack tương ứng.

| Bài | Instance trên máy kiểm tra | Database |
| --- | --- | --- |
| LAB2 | `(localdb)\ProjectModels` | QuanLyThuVienDB |
| LAB3 | `(localdb)\MSSQLLocalDB` | QuanLyKhachSan |
| LAB4 | `.\MSSQLSERVER01` | QuanLyCuaHangOnline |
| LAB5 | `.\MSSQLSERVER01` | QuanLyCongTyDuLich |
| LAB6 | `.\MSSQLSERVER01` | QuanLyHoSoBenhAn |
| LAB7 | `.\MSSQLSERVER01` | QuanLyNhanSu |
| LAB8 | `.\MSSQLSERVER01` | QuanLyVanPhong |

Môi trường các bài trước có JDK **23.0.1**, Visual Studio Community 2022 dòng **17.14**, .NET Framework **4.7.2** và LocalDB **15.0.4382.1**. LAB4 đến LAB8 đã chạy trên SQL Server 2022 **16.0.1000.6**. Chi tiết cấu hình, ngày kiểm tra và giới hạn của từng bài nằm trong README tương ứng.

Với bài WinForms, chạy script SQL của bài trên đúng instance, sửa Data Source trong cấu hình nếu cần, mở solution, Rebuild rồi F5. Không trộn script hoặc cấu hình của các database khác nhau. Báo cáo Word chứa mô hình và bằng chứng; mã nguồn, SQL và test giúp chạy lại để đối chiếu.

LAB3 quản lý khách sạn đã có báo cáo theo pha phân tích–thiết kế, workbook Use Case/Screen Design 5 sheet và **37 sơ đồ draw.io riêng**, gồm **3 Activity và 8 Sequence có thanh kích hoạt**. CSDL gồm **18 bảng, 22 quan hệ khóa ngoại**; WinForms có 7 Form, 15 màn hình/tab. Đã build Release, chạy đạt 46/46 ca nghiệp vụ/CSDL và cập nhật ảnh thực chạy vào Word A4. Hướng dẫn, quy ước tiền cọc/đền bù và giới hạn hiện thực nằm trong README LAB3.

LAB5 có **9 Form, 8 Service và 16 bảng SQL Server**. Báo cáo trình bày phân tích và thiết kế UML, trong đó có 2 sơ đồ phân rã use case, 2 activity và 2 tuần tự cho các chức năng lịch chuyến và điểm tham quan. Báo cáo dùng A4 dọc, có 17 ảnh Form/tab và 2 ảnh đối chiếu CSDL. Cách cấu hình, chạy ứng dụng và các kịch bản kiểm tra được trình bày trong README của LAB5.

LAB6 quản lý hồ sơ bệnh án, gồm 13 lớp nghiệp vụ, 8 hình UML, SQL Server 13 bảng và WinForms 9 Form theo UI → Service → Data. Báo cáo A4 dọc có 20 ảnh Form/tab, 2 ảnh đối chiếu CSDL, đặc tả và truy vết. Đã kiểm tra 50 ca nghiệp vụ/CSDL, 12 luồng ghi từ Form và 265 kiểm tra bố cục. README LAB6 hướng dẫn tạo dữ liệu mẫu, chạy solution và kiểm thử trên CSDL riêng.

LAB7 quản lý nhân sự Đông Á, có 22 bảng SQL, 9 Form và 18 sơ đồ draw.io riêng. Báo cáo A4 theo pha phân tích–thiết kế; 41 kiểm thử nghiệp vụ và 322 kiểm tra Form đạt. Ảnh Form nằm trong Word; một script SQL gồm cấu trúc và dữ liệu mẫu. Xem README LAB7 để chạy lại và đối chiếu dữ liệu lương mẫu.

LAB8 quản lý cho thuê văn phòng cao ốc, có **18 bảng, 23 quan hệ khóa ngoại, 9 Form và 22 file draw.io riêng**. Bộ UML gồm 3 UC phân rã chức năng, 3 Activity và 3 Sequence cho ký hợp đồng, thanh toán và gia hạn. Báo cáo A4 dọc theo cách trình bày các lab trước, có 23 ảnh Form/tab và 2 ảnh đối chiếu CSDL. Đã chạy 49 ca nghiệp vụ/CSDL, 11 luồng ghi từ nút Form và 324 kiểm tra Form. README LAB8 hướng dẫn cấu hình, dữ liệu mẫu, công thức và các bước kiểm tra lại.

## Quy định cập nhật và nộp bài

Mỗi thư mục LAB chứa README với thông tin sinh viên, tên bài, môi trường, nội dung thực hiện, kết quả, lỗi/cách khắc phục và hướng dẫn chạy lại. Chỉ đưa báo cáo, source code, SQL, cấu hình an toàn, UML và bằng chứng của bài thực hành lên repository. .gitignore loại trừ dữ liệu IDE, bin/obj, file khóa Word, file database/backup và cấu hình bí mật.

Yêu cầu học phần nêu tên repository **LAB_OOSD**, Public nếu giảng viên không quy định khác. Repository hiện tại đang mang tên **LAB_AT_OOSD**; cần đối chiếu tên với quy định lớp trước khi nộp. Commit và push đủ file trước hạn, mở GitHub kiểm tra nội dung có thể truy cập, rồi nộp URL repository lên bài tương ứng trên Google Classroom. Nếu có yêu cầu video, chèn link ở đầu báo cáo. Sau hạn nộp, không xóa repository hoặc thay nội dung đã nộp khi chưa được giảng viên cho phép.
