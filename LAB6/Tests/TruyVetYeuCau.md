# Truy vết yêu cầu LAB6

H là số hình trong báo cáo Word. T là ca kiểm thử nghiệp vụ/CSDL; U là ca thực thi nút trên Form.

| Yêu cầu | UML | Form / Service | Bảng CSDL | Test |
| --- | --- | --- | --- | --- |
| R01 Đăng ký và cấp hồ sơ | C1–2; H4.1, H5.1 | FrmBenhNhan; DangKy | BenhNhan, PhieuDangKy, PhieuThuLePhi, HoSoBenhAn | T01–T06; U01–U02 |
| R02 Thu/gia hạn lệ phí năm | H2.1; H3.1 | FrmBenhNhan; ThuPhi | PhieuThuLePhi | T07–T08, T46; U03 |
| R03 Tra cứu và theo dõi lịch sử | H2.1–2.2; H3.1 | FrmLichSu; BenhNhan/LichSu | HoSoBenhAn, PhieuKham và dữ liệu điều trị | T09, T44 |
| R04 Tiếp nhận và ghi nhận khám | H4.1–4.2; H5.1–5.2 | FrmKhamBenh; LapPhieu/GhiKham | PhieuKham, BacSi, Khoa | T10–T11, T27; U04–U05 |
| R05 Lịch định kỳ theo quý | H2.1; H3.1; đặc tả 4.2 | FrmLichHen/KhamBenh; DatHen/SuaHen/LapPhieu | LichHen, PhieuKham, PhieuThuLePhi | T12–T25, T45, T47, T50; U10–U11 |
| R06 Chỉ định và kết quả XN | H2.2, H4.2, H5.2 | FrmXetNghiem; ChiDinh/KetQua | ChiDinhXetNghiem, LoaiXetNghiem | T30–T33, T43, T48; U06–U07 |
| R07 Lập và xuất toa thuốc | H2.2, H4.2, H5.2, H6.1 | FrmToaThuoc; LapToa/XuatToa | ToaThuoc, ChiTietToaThuoc, Thuoc, PhieuKham | T26, T28–T29, T34–T38; U08 |
| R08 Hoàn tất sau thanh toán | H3.1; đặc tả 4.3 | FrmHoanTat; ThuTuc/HoanTat | PhieuKham; trạng thái xét nghiệm | T39–T45, T49; U09 |
| R09 Quản lý danh mục | H2.2; H3.1 | FrmDanhMuc; LuuDanhMuc | Khoa, BacSi, Thuoc, LoaiXetNghiem | U12 |
| R10 Kết nối và hiển thị rõ | Các module chức năng | FrmMain, ModuleForm, Data/Db | Toàn bộ CSDL ứng dụng | Build; 265 kiểm tra bố cục |

- [Kịch bản và dữ liệu](KichBanKiemThu.md).
- [Kết quả nghiệp vụ](BusinessResults.csv).
- [Kết quả luồng Form](UiWorkflowResults.csv).
- [Bố cục giao diện](../Evidence/FormResults.csv).
- [Mã kiểm thử](BusinessChecks.cs) và [luồng Form](UiWorkflowChecks.cs).
