# LAB1 — Lập trình hướng đối tượng với các lớp hình học

## Thông tin sinh viên

- Họ tên: **Nguyễn Thành Can**.
- MSSV: **1250080021**.
- Lớp: **12_ĐH_CNPM1**.
- Học phần: Phương pháp phát triển phần mềm hướng đối tượng.

## Mục tiêu và nội dung đã thực hiện

Xây dựng các lớp hình học bằng Java, sử dụng lớp trừu tượng, kế thừa, ghi đè phương thức và đa hình. Mã nguồn trong `Baitap_oop` thực hiện tính diện tích, chu vi và in thông tin hình ra console.

| File | Nội dung |
| --- | --- |
| [CHinhVe.java](Baitap_oop/CHinhVe.java) | Lớp trừu tượng, khai báo `dienTich()`, `chuVi()`, `ve()` |
| [CDiem.java](Baitap_oop/CDiem.java) | Biểu diễn tọa độ điểm |
| [CTamGiac.java](Baitap_oop/CTamGiac.java) | Tam giác với ba đỉnh |
| [CTuGiac.java](Baitap_oop/CTuGiac.java) | Tứ giác với bốn đỉnh |
| [CEllipse.java](Baitap_oop/CEllipse.java) | Ellipse với tâm và hai bán trục |
| [Main.java](Baitap_oop/Main.java) | Tạo mảng `CHinhVe[]` và gọi các phương thức của từng hình |

Phương thức `ve()` hiện in tên hình ra console. Chu vi ellipse sử dụng công thức xấp xỉ trong mã nguồn.

## Môi trường và phiên bản

- Hệ điều hành kiểm tra: Windows 11.
- JDK: **23.0.1**; `javac 23.0.1`.
- Chương trình Java console, không có thư viện ngoài hoặc cơ sở dữ liệu.

## Hướng dẫn chạy lại

Mở PowerShell tại thư mục `LAB1`, sau đó chạy:

```powershell
java -version
javac -version
javac -encoding UTF-8 -d .\bin .\Baitap_oop\*.java
java -cp .\bin Main
```

JDK phải được cài đặt và các lệnh `java`, `javac` phải có trong `PATH`. Thư mục `bin` chứa kết quả biên dịch và được Git bỏ qua.

## Kết quả

Đã biên dịch và chạy `Main` thành công ngày **25/09/2026** bằng JDK 23.0.1. Kết quả console:

```text
Ve tam giac
Dien tich: 6.0
Chu vi: 12.0

Ve tu giac
Dien tich: 12.0
Chu vi: 14.0

Ve ellipse
Dien tich: 25.132742
Chu vi: 19.869177
```



## Lỗi gặp phải và cách khắc phục

Lần biên dịch và chạy nêu trên không phát sinh lỗi. Nếu chạy trên máy khác gặp các tình huống sau:

| Hiện tượng | Cách kiểm tra và xử lý |
| --- | --- |
| Không nhận lệnh `javac` | Cài JDK, bổ sung thư mục `bin` của JDK vào `PATH`, mở lại terminal |
| `Could not find or load main class Main` | Đứng tại `LAB1`, biên dịch đủ sáu file và dùng đúng `java -cp .\bin Main` |
| Lỗi mã hóa khi biên dịch | Lưu mã nguồn UTF-8 và giữ tham số `-encoding UTF-8` |

## Báo cáo

[Tải báo cáo Word LAB1](1250080021_NguyenThanhCan_CNPM1_LAB01.docx).

[Quay về danh sách bài Lab](../README.md).
