IF DB_ID(N'QuanLyThuVienDB') IS NULL
CREATE DATABASE QuanLyThuVienDB;
GO
USE QuanLyThuVienDB;
GO
IF OBJECT_ID('dbo.PhieuPhat','U') IS NOT NULL DROP TABLE dbo.PhieuPhat;
IF OBJECT_ID('dbo.ChiTietPhieuMuon','U') IS NOT NULL DROP TABLE dbo.ChiTietPhieuMuon;
IF OBJECT_ID('dbo.PhieuMuon','U') IS NOT NULL DROP TABLE dbo.PhieuMuon;
IF OBJECT_ID('dbo.TheDocGia','U') IS NOT NULL DROP TABLE dbo.TheDocGia;
IF OBJECT_ID('dbo.DocGia','U') IS NOT NULL DROP TABLE dbo.DocGia;
IF OBJECT_ID('dbo.DauSach','U') IS NOT NULL DROP TABLE dbo.DauSach;
IF OBJECT_ID('dbo.NhaXuatBan','U') IS NOT NULL DROP TABLE dbo.NhaXuatBan;
IF OBJECT_ID('dbo.TheLoai','U') IS NOT NULL DROP TABLE dbo.TheLoai;
IF OBJECT_ID('dbo.NhanVien','U') IS NOT NULL DROP TABLE dbo.NhanVien;
GO
CREATE TABLE dbo.NhanVien (
MaNhanVien NVARCHAR(20) NOT NULL PRIMARY KEY,
Ho NVARCHAR(50) NOT NULL,
Ten NVARCHAR(50) NOT NULL,
Phai NVARCHAR(10) NOT NULL,
NgaySinh DATE NOT NULL,
ChucVu NVARCHAR(80) NOT NULL,
SoDienThoai NVARCHAR(20) NULL
);
CREATE TABLE dbo.TheLoai (
MaTheLoai NVARCHAR(20) NOT NULL PRIMARY KEY,
TenTheLoai NVARCHAR(100) NOT NULL UNIQUE
);
CREATE TABLE dbo.NhaXuatBan (
MaNhaXuatBan NVARCHAR(20) NOT NULL PRIMARY KEY,
DiaChi NVARCHAR(250) NULL,
SoDienThoai NVARCHAR(20) NULL
);
CREATE TABLE dbo.DauSach (
MaDauSach NVARCHAR(20) NOT NULL PRIMARY KEY,
TenSach NVARCHAR(200) NOT NULL,
NamXuatBan INT NOT NULL,
SoLuongHienCo INT NOT NULL CONSTRAINT CK_DauSach_SoLuong CHECK (SoLuongHienCo >= 0),
MaTheLoai NVARCHAR(20) NOT NULL,
MaNhaXuatBan NVARCHAR(20) NOT NULL,
CONSTRAINT FK_DauSach_TheLoai FOREIGN KEY (MaTheLoai) REFERENCES dbo.TheLoai(MaTheLoai),
CONSTRAINT FK_DauSach_NXB FOREIGN KEY (MaNhaXuatBan) REFERENCES dbo.NhaXuatBan(MaNhaXuatBan)
);
CREATE TABLE dbo.DocGia (
MaDocGia NVARCHAR(20) NOT NULL PRIMARY KEY,
Ho NVARCHAR(50) NOT NULL,
Ten NVARCHAR(50) NOT NULL,
NgaySinh DATE NOT NULL,
Phai NVARCHAR(10) NOT NULL,
SoDienThoai NVARCHAR(20) NULL,
DiaChi NVARCHAR(250) NOT NULL,
Email NVARCHAR(150) NOT NULL,
Anh3x4 NVARCHAR(260) NULL
);
-- MaThe là khóa kỹ thuật bổ sung để lưu lịch sử cấp/gia hạn thẻ.
CREATE TABLE dbo.TheDocGia (
MaThe NVARCHAR(30) NOT NULL PRIMARY KEY,
MaDocGia NVARCHAR(20) NOT NULL,
NgayCap DATE NOT NULL,
HanSuDung DATE NOT NULL,
DaDongLePhi BIT NOT NULL,
TrangThai BIT NOT NULL CONSTRAINT DF_TheDocGia_TrangThai DEFAULT(1),
CONSTRAINT CK_TheDocGia_Han CHECK (HanSuDung >= NgayCap),
CONSTRAINT FK_TheDocGia_DocGia FOREIGN KEY (MaDocGia) REFERENCES dbo.DocGia(MaDocGia)
);
CREATE UNIQUE INDEX UX_TheDocGia_MotTheHoatDong
ON dbo.TheDocGia(MaDocGia) WHERE TrangThai = 1;
CREATE TABLE dbo.PhieuMuon (
MaPhieuMuon NVARCHAR(30) NOT NULL PRIMARY KEY,
MaDocGia NVARCHAR(20) NOT NULL,
MaNhanVien NVARCHAR(20) NOT NULL,
NgayMuon DATE NOT NULL,
NgayHenTra DATE NOT NULL,
CONSTRAINT CK_PhieuMuon_Ngay CHECK (NgayHenTra >= NgayMuon),
CONSTRAINT FK_PhieuMuon_DocGia FOREIGN KEY (MaDocGia) REFERENCES dbo.DocGia(MaDocGia),
CONSTRAINT FK_PhieuMuon_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES dbo.NhanVien(MaNhanVien)
);
-- Mỗi dòng tương ứng một đầu sách; UNIQUE bảo đảm không có hai sách cùng đầu sách trong một phiếu.
CREATE TABLE dbo.ChiTietPhieuMuon (
MaChiTiet NVARCHAR(35) NOT NULL PRIMARY KEY,
MaPhieuMuon NVARCHAR(30) NOT NULL,
MaDauSach NVARCHAR(20) NOT NULL,
NgayTraThucTe DATE NULL,
TinhTrangTra NVARCHAR(50) NULL,
CONSTRAINT UQ_CTPM_Phieu_DauSach UNIQUE (MaPhieuMuon, MaDauSach),
CONSTRAINT FK_CTPM_PhieuMuon FOREIGN KEY (MaPhieuMuon) REFERENCES dbo.PhieuMuon(MaPhieuMuon),
CONSTRAINT FK_CTPM_DauSach FOREIGN KEY (MaDauSach) REFERENCES dbo.DauSach(MaDauSach)
);
CREATE TABLE dbo.PhieuPhat (
MaPhieuPhat NVARCHAR(35) NOT NULL PRIMARY KEY,
MaChiTiet NVARCHAR(35) NOT NULL,
MaNhanVien NVARCHAR(20) NOT NULL,
NgayPhat DATE NOT NULL,
LyDo NVARCHAR(250) NOT NULL,
PhiPhat DECIMAL(18,0) NOT NULL CONSTRAINT CK_PhieuPhat_Phi CHECK (PhiPhat >= 0),
CONSTRAINT FK_PhieuPhat_CTPM FOREIGN KEY (MaChiTiet) REFERENCES dbo.ChiTietPhieuMuon(MaChiTiet),
CONSTRAINT FK_PhieuPhat_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES dbo.NhanVien(MaNhanVien)
);
GO
CREATE INDEX IX_PhieuMuon_DocGia ON dbo.PhieuMuon(MaDocGia);
CREATE INDEX IX_PhieuMuon_NgayHenTra ON dbo.PhieuMuon(NgayHenTra);
CREATE INDEX IX_CTPM_MaDauSach ON dbo.ChiTietPhieuMuon(MaDauSach);
CREATE INDEX IX_PhieuPhat_NgayPhat ON dbo.PhieuPhat(NgayPhat);
GO
INSERT INTO dbo.NhanVien(MaNhanVien,Ho,Ten,Phai,NgaySinh,ChucVu,SoDienThoai) VALUES
(N'NV001',N'Nguyễn',N'An',N'Nam','1990-02-15',N'Thủ thư',N'0901000001'),
(N'NV002',N'Trần',N'Bình',N'Nữ','1992-08-20',N'Nhân viên quản lý sách',N'0901000002');
INSERT INTO dbo.TheLoai(MaTheLoai,TenTheLoai) VALUES
(N'TL001',N'Tin học'),(N'TL002',N'Tiểu thuyết'),(N'TL003',N'Anh văn'),(N'TL004',N'Truyện ngắn');
INSERT INTO dbo.NhaXuatBan(MaNhaXuatBan,DiaChi,SoDienThoai) VALUES
(N'NXB001',N'Quận 1, TP.HCM',N'0283000001'),
(N'NXB002',N'Quận Cầu Giấy, Hà Nội',N'0243000002');
INSERT INTO dbo.DauSach(MaDauSach,TenSach,NamXuatBan,SoLuongHienCo,MaTheLoai,MaNhaXuatBan) VALUES
(N'S001',N'Lập trình C# căn bản',2025,5,N'TL001',N'NXB001'),
(N'S002',N'Cơ sở dữ liệu',2024,4,N'TL001',N'NXB001'),
(N'S003',N'Mạng máy tính',2023,3,N'TL001',N'NXB002'),
(N'S004',N'Tiếng Anh chuyên ngành',2024,2,N'TL003',N'NXB002');
INSERT INTO dbo.DocGia(MaDocGia,Ho,Ten,NgaySinh,Phai,SoDienThoai,DiaChi,Email,Anh3x4) VALUES
(N'DG001',N'Lê',N'Minh','2003-05-12',N'Nam',N'0911000001',N'TP.HCM',N'minh@example.com',NULL),
(N'DG002',N'Phạm',N'Lan','2002-10-23',N'Nữ',N'0911000002',N'TP.HCM',N'lan@example.com',NULL);
INSERT INTO dbo.TheDocGia(MaThe,MaDocGia,NgayCap,HanSuDung,DaDongLePhi,TrangThai) VALUES
(N'THE_DG001_2026',N'DG001','2026-01-01','2026-12-31',1,1),
(N'THE_DG002_2026',N'DG002','2026-01-01','2026-12-31',1,1);
GO