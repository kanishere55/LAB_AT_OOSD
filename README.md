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
| LAB1 | Các lớp hình học bằng Java và Use Case thư viện trực tuyến | [README LAB1](LAB1/README.md) | [Báo cáo LAB1](LAB1/1250080021_NguyenThanhCan_CNPM1_LAB01.docx) |
| LAB2 | Hệ thống quản lý thư viện | [README LAB2](LAB2/README.md) | [Báo cáo LAB2](LAB2/1250080021_NguyenThanhCan_CNPM1_LAB02.docx) |
| LAB3 | Hệ thống quản lý khách sạn | [README LAB3](LAB3/README.md) | [Báo cáo LAB3](LAB3/1250080021_NguyenThanhCan_CNPM1_LAB03.docx) |
| LAB4 | Cửa hàng online e-SHOPPING | [README LAB4](LAB4/README.md) | [Báo cáo LAB4](LAB4/1250080021_NguyenThanhCan_CNPM1_LAB04.docx) |
| LAB5 | Công ty du lịch Văn Hóa Việt, đề Bài 6 | [README LAB5](LAB5/README.md) | [Báo cáo LAB5](LAB5/1250080021_NguyenThanhCan_CNPM1_LAB5.docx) |
| LAB6 | Hồ sơ bệnh án của bệnh nhân, đề Bài 5 | [README LAB6](LAB6/README.md) | [Báo cáo LAB6](LAB6/1250080021_NguyenThanhCan_CNPM1_LAB6.docx) |
| LAB7 | Nhân sự công ty sơn Đông Á | [README LAB7](LAB7/README.md) | [Báo cáo LAB7](LAB7/1250080021_NguyenThanhCan_CNPM1_LAB7.docx) |
| LAB8 | Cho thuê văn phòng cao ốc, đề Bài 4 | [README LAB8](LAB8/README.md) | [Báo cáo LAB8](LAB8/1250080021_NguyenThanhCan_CNPM1_LAB8.docx) |

## File sơ đồ draw.io

Toàn bộ file nguồn sơ đồ phân tích và thiết kế được lưu tại **[IMAGES](IMAGES)**, chia theo LAB1 đến LAB8. Mỗi sơ đồ là một file `.drawio` riêng, có thể mở và chỉnh sửa bằng diagrams.net. [Danh mục hình và file nguồn](IMAGES/README.md) liên kết từng hình trong báo cáo với file tương ứng.

| Bài | Thư mục sơ đồ | Số file |
| --- | --- | ---: |
| LAB1 | [Hình học Java và Use Case thư viện trực tuyến](IMAGES/LAB1) | 1 |
| LAB2 | [Quản lý thư viện](IMAGES/LAB2) | 14 |
| LAB3 | [Quản lý khách sạn](IMAGES/LAB3) | 37 |
| LAB4 | [e-SHOPPING và bài tập tổng hợp](IMAGES/LAB4) | 12 |
| LAB5 | [Quản lý công ty du lịch](IMAGES/LAB5) | 20 |
| LAB6 | [Quản lý hồ sơ bệnh án](IMAGES/LAB6) | 8 |
| LAB7 | [Quản lý nhân sự](IMAGES/LAB7) | 18 |
| LAB8 | [Cho thuê văn phòng cao ốc](IMAGES/LAB8) | 22 |
| **Tổng** | | **132** |

## Cấu trúc thư mục

```text
LAB_AT_OOSD/
├── README.md
├── .gitignore
├── IMAGES/
│   ├── README.md                  Danh mục hình và file nguồn
│   └── LAB1/ ... LAB8/             Mỗi sơ đồ một file .drawio
├── CacBaiLab/                     Tài liệu đề bài
├── LAB1/                          README, báo cáo và mã nguồn Java
├── LAB2/                          README, báo cáo, WinForms và SQL
├── LAB3/                          README, báo cáo, WinForms và SQL
├── LAB4/                          README, báo cáo chính, bài tập bổ sung, source và SQL
├── LAB5/                          README, báo cáo, WinForms và SQL
├── LAB6/                          README, báo cáo, WinForms và SQL
├── LAB7/                          README, báo cáo, WinForms và SQL
└── LAB8/                          README, báo cáo, WinForms và SQL
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

Với bài WinForms, chạy script SQL của bài trên đúng instance, sửa Data Source trong cấu hình nếu cần, mở solution, Rebuild rồi F5. Không trộn script hoặc cấu hình của các database khác nhau. Báo cáo Word chứa mô hình và bằng chứng; mã nguồn và SQL giúp chạy lại để đối chiếu.

LAB3 quản lý khách sạn đã có báo cáo theo pha phân tích–thiết kế và **37 sơ đồ draw.io riêng**, gồm **3 Activity và 8 Sequence có thanh kích hoạt**. CSDL gồm **18 bảng, 22 quan hệ khóa ngoại**; WinForms có 7 Form, 15 màn hình/tab. Đã build Release, chạy đạt 46/46 ca nghiệp vụ/CSDL và cập nhật ảnh thực chạy vào Word A4. Hướng dẫn, quy ước tiền cọc/đền bù và giới hạn hiện thực nằm trong README LAB3.

LAB5 có **9 Form, 8 Service và 16 bảng SQL Server**. Báo cáo trình bày phân tích và thiết kế UML, trong đó có 2 sơ đồ phân rã use case, 2 activity và 2 tuần tự cho các chức năng lịch chuyến và điểm tham quan. Báo cáo dùng A4 dọc, có 17 ảnh Form/tab và 2 ảnh đối chiếu CSDL. Cách cấu hình, chạy ứng dụng và các kịch bản kiểm tra được trình bày trong README của LAB5.

LAB6 quản lý hồ sơ bệnh án, gồm 13 lớp nghiệp vụ, 8 hình UML, SQL Server 13 bảng và WinForms 9 Form theo UI → Service → Data. Báo cáo A4 dọc có 20 ảnh Form/tab, 2 ảnh đối chiếu CSDL, đặc tả và truy vết. Đã kiểm tra 50 ca nghiệp vụ/CSDL, 12 luồng ghi từ Form và 265 kiểm tra bố cục. README LAB6 hướng dẫn tạo dữ liệu mẫu, chạy solution và kiểm thử trên CSDL riêng.

LAB7 quản lý nhân sự Đông Á, có 22 bảng SQL, 9 Form và 18 sơ đồ draw.io riêng. Báo cáo A4 theo pha phân tích–thiết kế; 41 kiểm thử nghiệp vụ và 322 kiểm tra Form đạt. Ảnh Form nằm trong Word; một script SQL gồm cấu trúc và dữ liệu mẫu. Xem README LAB7 để chạy lại và đối chiếu dữ liệu lương mẫu.

LAB8 quản lý cho thuê văn phòng cao ốc, có **18 bảng, 23 quan hệ khóa ngoại, 9 Form và 22 file draw.io riêng**. Bộ UML gồm 3 UC phân rã chức năng, 3 Activity và 3 Sequence cho ký hợp đồng, thanh toán và gia hạn. Báo cáo A4 dọc theo cách trình bày các lab trước, có 23 ảnh Form/tab thực chạy. Đã chạy 49 ca nghiệp vụ/CSDL, 11 luồng ghi từ nút Form và 324 kiểm tra Form. README LAB8 hướng dẫn cấu hình, dữ liệu mẫu, công thức và các bước kiểm tra lại.

## Quy định cập nhật và nộp bài tổng hợp

Phạm vi bài thực hành của lớp gồm LAB1 đến LAB8. Theo thông báo nộp bài ngày 01/11/2026:

- File Word tổng hợp phải chứa các LAB theo đúng thứ tự, có mục lục và số trang tương ứng.
- Đặt liên kết [repository OOSD](https://github.com/kanishere55/LAB_AT_OOSD) ở đầu file Word tổng hợp.
- Lưu đầy đủ file nguồn sơ đồ phân tích và thiết kế trong thư mục gốc [IMAGES](IMAGES), giữ định dạng `.drawio` để mở và chỉnh sửa.
- Repository phải duy trì **Public** trong thời gian giảng viên kiểm tra và chấm bài.
- Commit, push đầy đủ file; kiểm tra đường dẫn repository, thư mục IMAGES và khả năng tải/mở file nguồn trước khi nộp.
- Nộp **file Word tổng hợp** qua đường dẫn giảng viên cung cấp trong khoảng **08:00–23:59 ngày 01/11/2026**.
- Sau thời hạn, không xóa repository hoặc thay nội dung đã nộp khi chưa được giảng viên cho phép.

Mỗi thư mục LAB có README ghi thông tin sinh viên, nội dung, môi trường, kết quả, lỗi và hướng dẫn chạy lại. Chỉ lưu báo cáo, mã nguồn, SQL, cấu hình an toàn, file nguồn sơ đồ và bằng chứng thực hành. `.gitignore` loại trừ dữ liệu IDE, bin/obj, file khóa Word, file database/backup và cấu hình bí mật.
