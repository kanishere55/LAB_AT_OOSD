/*    BÀI 6 - QUẢN LÝ CÔNG TY DU LỊCH VĂN HÓA VIỆT
   Script tạo CSDL QuanLyCongTyDuLich (SQL Server / LocalDB)
   - Mọi tour xuất phát và kết thúc tại TP.HCM; điểm dừng đánh số theo thứ tự hành trình.
   - Khách đoàn: > 12 người, đặt cọc, thanh toán sau tour; khách lẻ: < 12 người, mua vé theo chuyến.
   - Đề không quy định trường hợp đúng 12 người: CHECK chặn ở cả hai bảng (xem quyết định QD01).
   ===================================================================== */
IF DB_ID(N'QuanLyCongTyDuLich') IS NULL CREATE DATABASE QuanLyCongTyDuLich;
GO
USE QuanLyCongTyDuLich;
GO
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
GO

IF OBJECT_ID(N'dbo.Tour', N'U') IS NULL
CREATE TABLE Tour(
 MaTour varchar(20) NOT NULL PRIMARY KEY,
 TenTour nvarchar(180) NOT NULL,
 SoNgay int NOT NULL CHECK(SoNgay>0),
 SoDem int NOT NULL CHECK(SoDem>=0),
 DonGiaKhach decimal(18,2) NOT NULL CHECK(DonGiaKhach>=0),
 MoTa nvarchar(1000) NULL,
 DangMoBan bit NOT NULL DEFAULT 1,
 CONSTRAINT CK_Tour_SoDem CHECK(SoDem<=SoNgay)
);
IF OBJECT_ID(N'dbo.PhuongTien', N'U') IS NULL
CREATE TABLE PhuongTien(
 MaPT varchar(20) NOT NULL PRIMARY KEY,
 TenPT nvarchar(120) NOT NULL UNIQUE,
 GhiChu nvarchar(300) NULL
);
IF OBJECT_ID(N'dbo.DiemThamQuan', N'U') IS NULL
CREATE TABLE DiemThamQuan(
 MaDiemTQ varchar(20) NOT NULL PRIMARY KEY,
 TenDiemTQ nvarchar(180) NOT NULL,
 DiaDiem nvarchar(250) NOT NULL,
 NoiDung nvarchar(1000) NULL,
 YNghia nvarchar(1000) NULL
);
IF OBJECT_ID(N'dbo.DiemBanVe', N'U') IS NULL
CREATE TABLE DiemBanVe(
 MaDiemBan varchar(20) NOT NULL PRIMARY KEY,
 TenDiemBan nvarchar(150) NOT NULL,
 DiaChi nvarchar(250) NOT NULL,
 DienThoai varchar(20) NULL
);
IF OBJECT_ID(N'dbo.HuongDanVien', N'U') IS NULL
CREATE TABLE HuongDanVien(
 MaHDV varchar(20) NOT NULL PRIMARY KEY,
 HoTen nvarchar(120) NOT NULL,
 DienThoai varchar(20) NULL,
 LuongCoBan decimal(18,2) NOT NULL CHECK(LuongCoBan>=0),
 DangLamViec bit NOT NULL DEFAULT 1
);
IF OBJECT_ID(N'dbo.TourDiemDung', N'U') IS NULL
CREATE TABLE TourDiemDung(
 MaTour varchar(20) NOT NULL,
 ThuTu int NOT NULL CHECK(ThuTu>0),
 TenDiemDung nvarchar(180) NOT NULL,
 DoiPhuongTien bit NOT NULL DEFAULT 0,
 CoNoiAn bit NOT NULL DEFAULT 0,
 CoKhachSan bit NOT NULL DEFAULT 0,
 HangSaoKhachSan int NULL CHECK(HangSaoKhachSan BETWEEN 2 AND 5),
 GhiChu nvarchar(500) NULL,
 PRIMARY KEY(MaTour,ThuTu),
 CONSTRAINT FK_TDD_Tour FOREIGN KEY(MaTour) REFERENCES Tour(MaTour),
 CONSTRAINT CK_TDD_KhachSan CHECK((CoKhachSan=0 AND HangSaoKhachSan IS NULL) OR (CoKhachSan=1 AND HangSaoKhachSan IS NOT NULL AND HangSaoKhachSan BETWEEN 2 AND 5))
);
IF OBJECT_ID(N'dbo.TourPhuongTien', N'U') IS NULL
CREATE TABLE TourPhuongTien(
 MaTour varchar(20) NOT NULL,
 ThuTuChang int NOT NULL CHECK(ThuTuChang>0),
 MaPT varchar(20) NOT NULL,
 GhiChu nvarchar(300) NULL,
 PRIMARY KEY(MaTour,ThuTuChang,MaPT),
 CONSTRAINT FK_TPT_Tour FOREIGN KEY(MaTour) REFERENCES Tour(MaTour),
 CONSTRAINT FK_TPT_PT FOREIGN KEY(MaPT) REFERENCES PhuongTien(MaPT)
);
IF OBJECT_ID(N'dbo.TourDiemThamQuan', N'U') IS NULL
CREATE TABLE TourDiemThamQuan(
 MaTour varchar(20) NOT NULL,
 MaDiemTQ varchar(20) NOT NULL,
 ThuTu int NOT NULL CHECK(ThuTu>0),
 PRIMARY KEY(MaTour,MaDiemTQ),
 CONSTRAINT UQ_TDTQ UNIQUE(MaTour,ThuTu),
 CONSTRAINT FK_TDTQ_Tour FOREIGN KEY(MaTour) REFERENCES Tour(MaTour),
 CONSTRAINT FK_TDTQ_Diem FOREIGN KEY(MaDiemTQ) REFERENCES DiemThamQuan(MaDiemTQ)
);
IF OBJECT_ID(N'dbo.ChuyenLe', N'U') IS NULL
CREATE TABLE ChuyenLe(
 MaChuyen varchar(20) NOT NULL PRIMARY KEY,
 MaTour varchar(20) NOT NULL,
 NgayDi date NOT NULL,
 NgayVe date NOT NULL,
 DiaDiemDon nvarchar(250) NOT NULL,
 TrangThai nvarchar(40) NOT NULL DEFAULT N'Mở đăng ký',
 CONSTRAINT CK_Chuyen_TrangThai CHECK(TrangThai IN (N'Mở đăng ký',N'Đóng đăng ký')),
 CONSTRAINT FK_Chuyen_Tour FOREIGN KEY(MaTour) REFERENCES Tour(MaTour),
 CONSTRAINT CK_Chuyen_Ngay CHECK(NgayVe>=NgayDi)
);
IF OBJECT_ID(N'dbo.DoanKhach', N'U') IS NULL
CREATE TABLE DoanKhach(
 MaDoan varchar(20) NOT NULL PRIMARY KEY,
 TenCoQuanDaiDien nvarchar(180) NOT NULL,
 DiaChi nvarchar(250) NOT NULL,
 DienThoai varchar(20) NOT NULL,
 NguoiDaiDien nvarchar(120) NOT NULL
);
IF OBJECT_ID(N'dbo.DangKyDoan', N'U') IS NULL
CREATE TABLE DangKyDoan(
 SoDKDoan varchar(20) NOT NULL PRIMARY KEY,
 MaDoan varchar(20) NOT NULL,
 MaTour varchar(20) NOT NULL,
 NgayDangKy datetime2 NOT NULL,
 NgayDi date NOT NULL,
 NgayKetThucDuKien date NOT NULL,
 SoNguoi int NOT NULL CHECK(SoNguoi>12),
 DiaDiemDon nvarchar(250) NOT NULL,
 MuaBaoHiem bit NOT NULL DEFAULT 0,
 TienCoc decimal(18,2) NOT NULL CHECK(TienCoc>0),
 DaThanhToanCoc bit NOT NULL CHECK(DaThanhToanCoc=1),
 TongTienDuKien decimal(18,2) NOT NULL CHECK(TongTienDuKien>=0),
 TrangThai nvarchar(40) NOT NULL DEFAULT N'Đã đăng ký',
 CONSTRAINT CK_DKDoan_TrangThai CHECK(TrangThai IN (N'Đã đăng ký',N'Hủy - mất cọc',N'Đã hoàn tất thanh toán')),
 CONSTRAINT CK_DKDoan_Coc CHECK(TienCoc<=TongTienDuKien),
 CONSTRAINT FK_DKDoan_Doan FOREIGN KEY(MaDoan) REFERENCES DoanKhach(MaDoan),
 CONSTRAINT FK_DKDoan_Tour FOREIGN KEY(MaTour) REFERENCES Tour(MaTour),
 CONSTRAINT CK_DKDoan_Ngay CHECK(NgayKetThucDuKien>=NgayDi)
);
IF OBJECT_ID(N'dbo.ThanhVienDoan', N'U') IS NULL
CREATE TABLE ThanhVienDoan(
 SoDKDoan varchar(20) NOT NULL,
 STT int NOT NULL CHECK(STT>0),
 HoTen nvarchar(120) NOT NULL,
 NgaySinh date NULL,
 SoGiayTo nvarchar(40) NULL,
 PRIMARY KEY(SoDKDoan,STT),
 CONSTRAINT FK_TVDoan_DK FOREIGN KEY(SoDKDoan) REFERENCES DangKyDoan(SoDKDoan)
);
IF OBJECT_ID(N'dbo.DangKyLe', N'U') IS NULL
CREATE TABLE DangKyLe(
 SoDKLe varchar(20) NOT NULL PRIMARY KEY,
 MaChuyen varchar(20) NOT NULL,
 MaDiemBan varchar(20) NOT NULL,
 NgayDangKy datetime2 NOT NULL,
 TenNguoiDangKy nvarchar(120) NOT NULL,
 DienThoai varchar(20) NOT NULL,
 SoNguoi int NOT NULL CHECK(SoNguoi BETWEEN 1 AND 11),
 ThanhTien decimal(18,2) NOT NULL CHECK(ThanhTien>=0),
 DaThanhToan bit NOT NULL DEFAULT 1 CHECK(DaThanhToan=1),
 TrangThai nvarchar(40) NOT NULL DEFAULT N'Đã đăng ký',
 CONSTRAINT FK_DKLe_Chuyen FOREIGN KEY(MaChuyen) REFERENCES ChuyenLe(MaChuyen),
 CONSTRAINT FK_DKLe_DiemBan FOREIGN KEY(MaDiemBan) REFERENCES DiemBanVe(MaDiemBan)
);
IF OBJECT_ID(N'dbo.PhanCongHDV', N'U') IS NULL
CREATE TABLE PhanCongHDV(
 MaPC varchar(20) NOT NULL PRIMARY KEY,
 MaHDV varchar(20) NOT NULL,
 LoaiDoiTuong varchar(10) NOT NULL CHECK(LoaiDoiTuong IN('LE','DOAN')),
 MaChuyen varchar(20) NULL,
 SoDKDoan varchar(20) NULL,
 NgayBatDau date NOT NULL,
 NgayKetThuc date NOT NULL,
 ThuLaoTour decimal(18,2) NOT NULL CHECK(ThuLaoTour>=0),
 CONSTRAINT FK_PC_HDV FOREIGN KEY(MaHDV) REFERENCES HuongDanVien(MaHDV),
 CONSTRAINT FK_PC_Chuyen FOREIGN KEY(MaChuyen) REFERENCES ChuyenLe(MaChuyen),
 CONSTRAINT FK_PC_Doan FOREIGN KEY(SoDKDoan) REFERENCES DangKyDoan(SoDKDoan),
 CONSTRAINT CK_PC_Target CHECK((LoaiDoiTuong='LE' AND MaChuyen IS NOT NULL AND SoDKDoan IS NULL) OR (LoaiDoiTuong='DOAN' AND SoDKDoan IS NOT NULL AND MaChuyen IS NULL)),
 CONSTRAINT CK_PC_Ngay CHECK(NgayKetThuc>=NgayBatDau)
);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'UX_PC_ChuyenLe' AND object_id=OBJECT_ID(N'dbo.PhanCongHDV'))
CREATE UNIQUE INDEX UX_PC_ChuyenLe ON PhanCongHDV(MaChuyen) WHERE MaChuyen IS NOT NULL;
IF OBJECT_ID(N'dbo.ThanhToanDoan', N'U') IS NULL
CREATE TABLE ThanhToanDoan(
 SoTT varchar(20) NOT NULL PRIMARY KEY,
 SoDKDoan varchar(20) NOT NULL,
 NgayThanhToan datetime2 NOT NULL,
 SoTien decimal(18,2) NOT NULL CHECK(SoTien>0),
 GhiChu nvarchar(300) NULL,
 CONSTRAINT FK_TTDoan_DK FOREIGN KEY(SoDKDoan) REFERENCES DangKyDoan(SoDKDoan)
);
IF OBJECT_ID(N'dbo.KhaoSat', N'U') IS NULL
CREATE TABLE KhaoSat(
 MaKhaoSat varchar(20) NOT NULL PRIMARY KEY,
 LoaiKhach varchar(10) NOT NULL CHECK(LoaiKhach IN('LE','DOAN')),
 SoDKLe varchar(20) NULL,
 SoDKDoan varchar(20) NULL,
 NgayGui date NOT NULL,
 NgayPhanHoi date NULL,
 DiemDanhGia int NULL CHECK(DiemDanhGia BETWEEN 1 AND 5),
 GopY nvarchar(1500) NULL,
 CONSTRAINT FK_KS_Le FOREIGN KEY(SoDKLe) REFERENCES DangKyLe(SoDKLe),
 CONSTRAINT FK_KS_Doan FOREIGN KEY(SoDKDoan) REFERENCES DangKyDoan(SoDKDoan),
 CONSTRAINT CK_KS_PhanHoi CHECK(NgayPhanHoi IS NULL OR NgayPhanHoi>=NgayGui),
 CONSTRAINT CK_KS_Target CHECK((LoaiKhach='LE' AND SoDKLe IS NOT NULL AND SoDKDoan IS NULL) OR (LoaiKhach='DOAN' AND SoDKDoan IS NOT NULL AND SoDKLe IS NULL))
);
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'UX_KS_Le' AND object_id=OBJECT_ID(N'dbo.KhaoSat'))
CREATE UNIQUE INDEX UX_KS_Le ON KhaoSat(SoDKLe) WHERE SoDKLe IS NOT NULL;
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'UX_KS_Doan' AND object_id=OBJECT_ID(N'dbo.KhaoSat'))
CREATE UNIQUE INDEX UX_KS_Doan ON KhaoSat(SoDKDoan) WHERE SoDKDoan IS NOT NULL;
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name=N'IX_PC_HDV_Ngay' AND object_id=OBJECT_ID(N'dbo.PhanCongHDV'))
CREATE INDEX IX_PC_HDV_Ngay ON PhanCongHDV(MaHDV,NgayBatDau,NgayKetThuc);
GO


/* ---------------- DỮ LIỆU MẪU ---------------- */
INSERT INTO Tour(MaTour,TenTour,SoNgay,SoDem,DonGiaKhach,MoTa,DangMoBan)
SELECT MaTour,TenTour,SoNgay,SoDem,DonGiaKhach,MoTa,DangMoBan FROM (VALUES ('T001',N'Miền Tây 3 ngày 2 đêm',3,2,2500000,N'TP.HCM - Mỹ Tho - Cần Thơ - TP.HCM',1),
('T002',N'Đà Lạt 4 ngày 3 đêm',4,3,3200000,N'TP.HCM - Đà Lạt - TP.HCM',1),
('T003',N'Hà Nội - Hạ Long 5 ngày 4 đêm',5,4,8900000,N'TP.HCM - Hà Nội - Hạ Long - TP.HCM',1)) AS v(MaTour,TenTour,SoNgay,SoDem,DonGiaKhach,MoTa,DangMoBan)
WHERE NOT EXISTS (SELECT 1 FROM Tour t WHERE t.MaTour=v.MaTour);
INSERT INTO PhuongTien(MaPT,TenPT,GhiChu)
SELECT MaPT,TenPT,GhiChu FROM (VALUES ('PT01',N'Xe du lịch',NULL),('PT02',N'Máy bay',NULL),('PT03',N'Tàu hỏa',NULL),('PT04',N'Tàu thủy',NULL)) AS v(MaPT,TenPT,GhiChu)
WHERE NOT EXISTS (SELECT 1 FROM PhuongTien t WHERE t.MaPT=v.MaPT);
INSERT INTO DiemBanVe(MaDiemBan,TenDiemBan,DiaChi,DienThoai)
SELECT MaDiemBan,TenDiemBan,DiaChi,DienThoai FROM (VALUES ('DB01',N'Điểm bán Quận 1',N'12 Lê Lợi, Quận 1, TP.HCM','0281000001'),('DB02',N'Điểm bán Thủ Đức',N'5 Võ Văn Ngân, TP. Thủ Đức','0281000002')) AS v(MaDiemBan,TenDiemBan,DiaChi,DienThoai)
WHERE NOT EXISTS (SELECT 1 FROM DiemBanVe t WHERE t.MaDiemBan=v.MaDiemBan);
INSERT INTO HuongDanVien(MaHDV,HoTen,DienThoai,LuongCoBan,DangLamViec)
SELECT MaHDV,HoTen,DienThoai,LuongCoBan,DangLamViec FROM (VALUES ('HDV01',N'Nguyễn Minh Anh','0903000001',9000000,1),('HDV02',N'Trần Quốc Bình','0903000002',9500000,1),('HDV03',N'Lê Thu Cúc','0903000003',8500000,1)) AS v(MaHDV,HoTen,DienThoai,LuongCoBan,DangLamViec)
WHERE NOT EXISTS (SELECT 1 FROM HuongDanVien t WHERE t.MaHDV=v.MaHDV);
INSERT INTO DiemThamQuan(MaDiemTQ,TenDiemTQ,DiaDiem,NoiDung,YNghia)
SELECT MaDiemTQ,TenDiemTQ,DiaDiem,NoiDung,YNghia FROM (VALUES ('DTQ01',N'Chợ nổi Cái Răng',N'Cần Thơ',N'Tham quan chợ trên sông',N'Nét văn hóa sông nước miền Tây'),
('DTQ02',N'Chùa Vĩnh Tràng',N'Mỹ Tho, Tiền Giang',N'Tham quan kiến trúc chùa',N'Di tích kiến trúc nghệ thuật cấp quốc gia'),
('DTQ03',N'Hồ Xuân Hương',N'Đà Lạt',N'Dạo quanh hồ trung tâm',N'Biểu tượng thành phố Đà Lạt'),
('DTQ04',N'Vịnh Hạ Long',N'Quảng Ninh',N'Du thuyền tham quan vịnh',N'Di sản thiên nhiên thế giới'),
('DTQ05',N'Văn Miếu - Quốc Tử Giám',N'Hà Nội',N'Tham quan di tích',N'Trường đại học đầu tiên của Việt Nam')) AS v(MaDiemTQ,TenDiemTQ,DiaDiem,NoiDung,YNghia)
WHERE NOT EXISTS (SELECT 1 FROM DiemThamQuan t WHERE t.MaDiemTQ=v.MaDiemTQ);
/* Điểm dừng: nơi đến quan trọng, cũng là nơi đi tiếp theo; điểm cuối là TP.HCM */
INSERT INTO TourDiemDung(MaTour,ThuTu,TenDiemDung,DoiPhuongTien,CoNoiAn,CoKhachSan,HangSaoKhachSan,GhiChu)
SELECT MaTour,ThuTu,TenDiemDung,DoiPhuongTien,CoNoiAn,CoKhachSan,HangSaoKhachSan,GhiChu FROM (VALUES ('T001',1,N'Mỹ Tho',0,1,0,NULL,NULL),('T001',2,N'Cần Thơ',0,1,1,3,NULL),('T001',3,N'TP.HCM',0,0,0,NULL,N'Kết thúc tour'),
('T003',1,N'Hà Nội',1,1,1,4,N'Đổi sang xe du lịch'),('T003',2,N'Hạ Long',1,1,1,5,N'Đi tàu thủy trên vịnh'),('T003',3,N'TP.HCM',0,0,0,NULL,N'Kết thúc tour')) AS v(MaTour,ThuTu,TenDiemDung,DoiPhuongTien,CoNoiAn,CoKhachSan,HangSaoKhachSan,GhiChu)
WHERE NOT EXISTS (SELECT 1 FROM TourDiemDung t WHERE t.MaTour=v.MaTour AND t.ThuTu=v.ThuTu);
/* Phương tiện theo chặng: chặng k là đoạn đi tới điểm dừng thứ k */
INSERT INTO TourPhuongTien(MaTour,ThuTuChang,MaPT,GhiChu)
SELECT MaTour,ThuTuChang,MaPT,GhiChu FROM (VALUES ('T001',1,'PT01',NULL),('T001',2,'PT01',NULL),('T001',3,'PT01',NULL),
('T003',1,'PT02',N'TP.HCM - Hà Nội'),('T003',2,'PT01',N'Hà Nội - Hạ Long'),('T003',2,'PT04',N'Tham quan vịnh'),('T003',3,'PT02',N'Hà Nội - TP.HCM')) AS v(MaTour,ThuTuChang,MaPT,GhiChu)
WHERE NOT EXISTS (SELECT 1 FROM TourPhuongTien t WHERE t.MaTour=v.MaTour AND t.ThuTuChang=v.ThuTuChang AND t.MaPT=v.MaPT);
INSERT INTO TourDiemThamQuan(MaTour,MaDiemTQ,ThuTu)
SELECT MaTour,MaDiemTQ,ThuTu FROM (VALUES ('T001','DTQ02',1),('T001','DTQ01',2),('T002','DTQ03',1),('T003','DTQ05',1),('T003','DTQ04',2)) AS v(MaTour,MaDiemTQ,ThuTu)
WHERE NOT EXISTS (SELECT 1 FROM TourDiemThamQuan t WHERE t.MaTour=v.MaTour AND t.MaDiemTQ=v.MaDiemTQ);
/* Chuyến khách lẻ: NgayVe = NgayDi + SoNgay - 1 */
INSERT INTO ChuyenLe(MaChuyen,MaTour,NgayDi,NgayVe,DiaDiemDon,TrangThai)
SELECT MaChuyen,MaTour,NgayDi,NgayVe,DiaDiemDon,TrangThai FROM (VALUES ('CL001','T001','20260905','20260907',N'Nhà Văn hóa Thanh Niên, Quận 1',N'Đóng đăng ký'),
('CL002','T001','20261115','20261117',N'Nhà Văn hóa Thanh Niên, Quận 1',N'Mở đăng ký'),
('CL003','T002','20261120','20261123',N'Công viên 23/9, Quận 1',N'Mở đăng ký')) AS v(MaChuyen,MaTour,NgayDi,NgayVe,DiaDiemDon,TrangThai)
WHERE NOT EXISTS (SELECT 1 FROM ChuyenLe t WHERE t.MaChuyen=v.MaChuyen);
INSERT INTO DangKyLe(SoDKLe,MaChuyen,MaDiemBan,NgayDangKy,TenNguoiDangKy,DienThoai,SoNguoi,ThanhTien,DaThanhToan,TrangThai)
SELECT SoDKLe,MaChuyen,MaDiemBan,NgayDangKy,TenNguoiDangKy,DienThoai,SoNguoi,ThanhTien,DaThanhToan,TrangThai FROM (VALUES ('DKL001','CL001','DB01','20260820 09:00',N'Phạm Văn Long','0912000001',2,5000000,1,N'Đã đăng ký'),
('DKL002','CL002','DB02','20261001 10:00',N'Võ Thị Mai','0912000002',3,7500000,1,N'Đã đăng ký')) AS v(SoDKLe,MaChuyen,MaDiemBan,NgayDangKy,TenNguoiDangKy,DienThoai,SoNguoi,ThanhTien,DaThanhToan,TrangThai)
WHERE NOT EXISTS (SELECT 1 FROM DangKyLe t WHERE t.SoDKLe=v.SoDKLe);
INSERT INTO DoanKhach(MaDoan,TenCoQuanDaiDien,DiaChi,DienThoai,NguoiDaiDien)
SELECT MaDoan,TenCoQuanDaiDien,DiaChi,DienThoai,NguoiDaiDien FROM (VALUES ('DK01',N'Công ty CP Phần mềm Sao Việt',N'25 Nguyễn Thị Minh Khai, Quận 3, TP.HCM','0283900001',N'Lê Văn Hải'),
('DK02',N'Gia đình ông Trần Văn Nam',N'8 Phan Xích Long, Phú Nhuận, TP.HCM','0909111222',N'Trần Văn Nam')) AS v(MaDoan,TenCoQuanDaiDien,DiaChi,DienThoai,NguoiDaiDien)
WHERE NOT EXISTS (SELECT 1 FROM DoanKhach t WHERE t.MaDoan=v.MaDoan);
/* DD001: đoàn đã đi xong (dùng cho thanh toán sau tour, khảo sát); DD002: đoàn sắp đi */
INSERT INTO DangKyDoan(SoDKDoan,MaDoan,MaTour,NgayDangKy,NgayDi,NgayKetThucDuKien,SoNguoi,DiaDiemDon,MuaBaoHiem,TienCoc,DaThanhToanCoc,TongTienDuKien,TrangThai)
SELECT SoDKDoan,MaDoan,MaTour,NgayDangKy,NgayDi,NgayKetThucDuKien,SoNguoi,DiaDiemDon,MuaBaoHiem,TienCoc,DaThanhToanCoc,TongTienDuKien,TrangThai FROM (VALUES ('DD001','DK01','T001','20260801 08:30','20260910','20260912',20,N'25 Nguyễn Thị Minh Khai, Quận 3',0,10000000,1,50000000,N'Đã đăng ký'),
('DD002','DK02','T002','20260925 14:00','20261210','20261213',15,N'8 Phan Xích Long, Phú Nhuận',0,12000000,1,48000000,N'Đã đăng ký')) AS v(SoDKDoan,MaDoan,MaTour,NgayDangKy,NgayDi,NgayKetThucDuKien,SoNguoi,DiaDiemDon,MuaBaoHiem,TienCoc,DaThanhToanCoc,TongTienDuKien,TrangThai)
WHERE NOT EXISTS (SELECT 1 FROM DangKyDoan t WHERE t.SoDKDoan=v.SoDKDoan);
INSERT INTO PhanCongHDV(MaPC,MaHDV,LoaiDoiTuong,MaChuyen,SoDKDoan,NgayBatDau,NgayKetThuc,ThuLaoTour)
SELECT MaPC,MaHDV,LoaiDoiTuong,MaChuyen,SoDKDoan,NgayBatDau,NgayKetThuc,ThuLaoTour FROM (VALUES ('PC001','HDV01','LE','CL001',NULL,'20260905','20260907',1500000),
('PC002','HDV02','DOAN',NULL,'DD001','20260910','20260912',2000000),
('PC003','HDV03','DOAN',NULL,'DD001','20260910','20260912',2000000)) AS v(MaPC,MaHDV,LoaiDoiTuong,MaChuyen,SoDKDoan,NgayBatDau,NgayKetThuc,ThuLaoTour)
WHERE NOT EXISTS (SELECT 1 FROM PhanCongHDV t WHERE t.MaPC=v.MaPC);
INSERT INTO KhaoSat(MaKhaoSat,LoaiKhach,SoDKLe,SoDKDoan,NgayGui,NgayPhanHoi,DiemDanhGia,GopY)
SELECT MaKhaoSat,LoaiKhach,SoDKLe,SoDKDoan,NgayGui,NgayPhanHoi,DiemDanhGia,GopY FROM (VALUES ('KS001','LE','DKL001',NULL,'20260908','20260910',5,N'Hướng dẫn viên nhiệt tình')) AS v(MaKhaoSat,LoaiKhach,SoDKLe,SoDKDoan,NgayGui,NgayPhanHoi,DiemDanhGia,GopY)
WHERE NOT EXISTS (SELECT 1 FROM KhaoSat t WHERE t.MaKhaoSat=v.MaKhaoSat);
GO
PRINT N'Đã tạo CSDL QuanLyCongTyDuLich.';

