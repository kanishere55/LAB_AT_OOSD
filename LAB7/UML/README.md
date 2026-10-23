# UML LAB7 — Quản lý nhân sự

Mỗi sơ đồ nằm trong **một file `.drawio` riêng**, một trang A4 dọc. Mở draw.io/diagrams.net → File → Open From → Device. Hình, chữ và đường nối đều chỉnh sửa được. Ảnh sơ đồ đã được chèn trong báo cáo Word; có thể xuất lại từ từng file draw.io khi cần.

| STT | Nội dung | Draw.io |
| --- | --- | --- |
| 1 | Lớp nhân sự và hợp đồng | [Draw.io](01_Lop_NhanSu.drawio) |
| 2 | Lớp kế hoạch và chấm công | [Draw.io](02_Lop_ChamCong.drawio) |
| 3 | Lớp lương, khen thưởng và kỷ luật | [Draw.io](03_Lop_LuongThuong.drawio) |
| 4 | Use case tổng quát | [Draw.io](04_UseCase_TongQuat.drawio) |
| 5 | Phân rã tiếp nhận thử việc | [Draw.io](05_PhanRa_ThuViec.drawio) |
| 6 | Phân rã đánh giá thử việc và ký hợp đồng | [Draw.io](06_PhanRa_HopDong.drawio) |
| 7 | Hoạt động tiếp nhận thử việc | [Draw.io](07_Activity_ThuViec.drawio) |
| 8 | Hoạt động đánh giá thử việc và ký hợp đồng | [Draw.io](08_Activity_KyHopDong.drawio) |
| 9 | Tuần tự lập quyết định khen thưởng | [Draw.io](09_Sequence_KhenThuong.drawio) |
| 10 | Trạng thái tiếp nhận nhân viên | [Draw.io](10_TrangThai_NhanVien.drawio) |
| 11 | Lớp thiết kế tổng thể | [Draw.io](11_LopThietKe.drawio) |
| 12 | Tuyển dụng và hợp đồng | [Draw.io](12_ThietKe_Module.drawio) |
| 13 | Danh mục và quyết định | [Draw.io](13_ThietKe_Module.drawio) |
| 14 | Kế hoạch và phụ trội | [Draw.io](14_ThietKe_Module.drawio) |
| 15 | Khen thưởng và bảng lương | [Draw.io](15_ThietKe_Module.drawio) |
| 16 | ERD nhân sự | [Draw.io](16_ERD.drawio) |
| 17 | ERD chấm công | [Draw.io](17_ERD.drawio) |
| 18 | ERD lương thưởng | [Draw.io](18_ERD.drawio) |

Các hình dùng cùng tên lớp, ID và quy tắc nghiệp vụ trong báo cáo. Lớp/bảng NhanVien và PhongBan được lặp ở các nhóm để nối quan hệ; đó vẫn là cùng một thực thể. Biểu đồ lớp phân tích biểu diễn liên kết thay cho việc lặp các khóa ngoại không thuộc ID; bảng thuộc tính trong Word giữ đủ các cột.

Activity tách hai làn Phòng nhân sự và Hệ thống. Sequence khen thưởng thể hiện Kế toán → FrmKhenThuong → NhanSuService → Db → SQL Server; giám đốc ký quyết định ngoài phần mềm. Các hình thiết kế module trình bày các phương thức và nhóm bảng chính liên quan, cùng dùng lớp NhanSuService và Db.

ERD dùng kiểu dữ liệu SQL Server, PK/FK/UQ và ký hiệu chân quạ. Bội số vật lý thể hiện ràng buộc của khóa; các điều kiện như quyết định phải có chi tiết và chứng từ được bảo đảm bằng stored procedure trong một transaction. Liên kết phân công–chấm công được đối chiếu trong GhiChamCong; CSDL có 27 khóa ngoại.
