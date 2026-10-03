-- LAB04 e-SHOPPING - Nguyen Thanh Can 1250080021
IF DB_ID(N'QuanLyCuaHangOnline') IS NULL
    EXEC(N'CREATE DATABASE QuanLyCuaHangOnline');
GO
USE QuanLyCuaHangOnline;
GO
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
GO
IF SCHEMA_ID(N'catalog') IS NULL EXEC(N'CREATE SCHEMA catalog');
GO
IF OBJECT_ID(N'catalog.NhomSanPham',N'U') IS NULL
CREATE TABLE catalog.NhomSanPham (
 MaNhom varchar(20) PRIMARY KEY,
 TenNhom nvarchar(100) NOT NULL);
IF OBJECT_ID(N'catalog.SanPham',N'U') IS NULL
CREATE TABLE catalog.SanPham (
 MaSP varchar(20) PRIMARY KEY,
 MaNhom varchar(20) NOT NULL REFERENCES catalog.NhomSanPham(MaNhom),
 TenSP nvarchar(150) NOT NULL,
 NhaSanXuat nvarchar(100) NOT NULL,
 MoTa nvarchar(1000) NOT NULL,
 ThongSo nvarchar(1000) NOT NULL,
 GiaHienHanh decimal(18,0) NOT NULL CHECK(GiaHienHanh>=0),
 ConHang bit NOT NULL);
IF OBJECT_ID(N'catalog.HinhAnhSanPham',N'U') IS NULL
CREATE TABLE catalog.HinhAnhSanPham (
 MaSP varchar(20) NOT NULL REFERENCES catalog.SanPham(MaSP),
 ThuTu int NOT NULL CHECK(ThuTu>0),
 DuongDan nvarchar(300) NOT NULL,
 PRIMARY KEY(MaSP,ThuTu));
IF OBJECT_ID(N'dbo.KhachHang',N'U') IS NULL
CREATE TABLE dbo.KhachHang (
 MaKH int IDENTITY PRIMARY KEY,
 HoTen nvarchar(100) NOT NULL,
 NgaySinh date NOT NULL,
 GiayTo nvarchar(30) NOT NULL,
 DiaChi nvarchar(250) NOT NULL,
 DienThoai varchar(20) NOT NULL,
 TenDangNhap varchar(50) COLLATE Latin1_General_100_CI_AS NOT NULL UNIQUE,
 MatKhauHash varbinary(32) NOT NULL,
 Salt varbinary(16) NOT NULL,
 Email nvarchar(254) NULL);
IF OBJECT_ID(N'dbo.PhiGiaoHang',N'U') IS NULL
CREATE TABLE dbo.PhiGiaoHang (
 KhuVuc varchar(20) NOT NULL,
 LoaiGiao varchar(20) NOT NULL CHECK(LoaiGiao IN('Thuong','Nhanh','TrongNgay')),
 PhiCoBan decimal(18,0) NOT NULL CHECK(PhiCoBan>=0),
 PRIMARY KEY(KhuVuc,LoaiGiao));
IF OBJECT_ID(N'dbo.DonHang',N'U') IS NULL
CREATE TABLE dbo.DonHang (
 MaDH int IDENTITY PRIMARY KEY,
 MaYeuCau uniqueidentifier NOT NULL UNIQUE,
 MaKH int NOT NULL REFERENCES dbo.KhachHang(MaKH),
 TenNguoiMua nvarchar(100) NOT NULL,
 EmailNguoiMua nvarchar(254) NULL,
 TenNguoiNhan nvarchar(100) NOT NULL,
 DiaChiNhan nvarchar(250) NOT NULL,
 DienThoaiNhan varchar(20) NOT NULL,
 KhuVucGiao varchar(20) NOT NULL,
 LoaiGiao varchar(20) NOT NULL,
 TienHang decimal(18,0) NOT NULL CHECK(TienHang>=0),
 PhiGiao decimal(18,0) NOT NULL CHECK(PhiGiao>=0),
 PhiThe decimal(18,0) NOT NULL CHECK(PhiThe>=0),
 TongTien AS (TienHang+PhiGiao+PhiThe) PERSISTED,
 ThoiDiem datetime2(0) NOT NULL DEFAULT SYSDATETIME(),
 FOREIGN KEY(KhuVucGiao,LoaiGiao) REFERENCES dbo.PhiGiaoHang(KhuVuc,LoaiGiao));
IF OBJECT_ID(N'dbo.ChiTietDonHang',N'U') IS NULL
CREATE TABLE dbo.ChiTietDonHang (
 MaDH int NOT NULL REFERENCES dbo.DonHang(MaDH),
 MaSP varchar(20) NOT NULL,
 TenSP nvarchar(150) NOT NULL,
 SoLuong int NOT NULL CHECK(SoLuong>0),
 DonGia decimal(18,0) NOT NULL CHECK(DonGia>=0),
 ThanhTien AS (SoLuong*DonGia) PERSISTED,
 PRIMARY KEY(MaDH,MaSP));
-- MaSP la ma tham chieu sang he thong ngoai; khong FK cross-system.
IF OBJECT_ID(N'dbo.ThanhToan',N'U') IS NULL
CREATE TABLE dbo.ThanhToan (
 MaDH int PRIMARY KEY REFERENCES dbo.DonHang(MaDH),
 LoaiThe varchar(20) NOT NULL CHECK(LoaiThe IN('VISA','Master','Discover','AmEx')),
 BonSoCuoi char(4) NOT NULL CHECK(BonSoCuoi NOT LIKE '%[^0-9]%'),
 MaGiaoDich varchar(50) NOT NULL UNIQUE,
 SoTien decimal(18,0) NOT NULL CHECK(SoTien>=0),
 ThoiDiem datetime2(0) NOT NULL DEFAULT SYSDATETIME());
IF OBJECT_ID(N'dbo.EmailXacNhan',N'U') IS NULL
CREATE TABLE dbo.EmailXacNhan (
 MaDH int PRIMARY KEY REFERENCES dbo.DonHang(MaDH),
 DiaChiEmail nvarchar(254) NOT NULL,
 NoiDung nvarchar(max) NOT NULL,
 TrangThai varchar(20) NOT NULL CHECK(TrangThai IN('DaGui','LoiGui')),
 ThoiDiem datetime2(0) NOT NULL DEFAULT SYSDATETIME());
GO
IF NOT EXISTS(SELECT 1 FROM catalog.NhomSanPham)
INSERT catalog.NhomSanPham VALUES
 ('DIENTU',N'Thiết bị điện tử'),('GIADUNG',N'Điện gia dụng'),('DOCHOI',N'Đồ chơi');
IF NOT EXISTS(SELECT 1 FROM catalog.SanPham)
INSERT catalog.SanPham VALUES
 ('SP01','DIENTU',N'Tai nghe Bluetooth',N'ABC Audio',N'Tai nghe không dây.',N'Bluetooth 5.3; pin 30 giờ',500000,1),
 ('SP02','DIENTU',N'Máy ảnh kỹ thuật số',N'ABC Camera',N'Máy ảnh dùng cho du lịch.',N'24 MP; màn hình 3 inch',5000000,1),
 ('SP03','GIADUNG',N'Ấm đun nước',N'ABC Home',N'Ấm điện tự ngắt.',N'1.8 lít; 1500 W',350000,1),
 ('SP04','DOCHOI',N'Bộ xếp hình',N'ABC Toys',N'Bộ xếp hình cho trẻ từ 6 tuổi.',N'200 chi tiết',200000,0);
IF NOT EXISTS(SELECT 1 FROM catalog.HinhAnhSanPham)
INSERT catalog.HinhAnhSanPham VALUES
 ('SP01',1,N'Assets/SP01_1.png'),('SP01',2,N'Assets/SP01_2.png'),
 ('SP02',1,N'Assets/SP02_1.png'),('SP03',1,N'Assets/SP03_1.png'),('SP04',1,N'Assets/SP04_1.png');
-- Du lieu mau: phi giao theo khu vuc va loai giao.
IF NOT EXISTS(SELECT 1 FROM dbo.PhiGiaoHang)
INSERT dbo.PhiGiaoHang VALUES
 ('NoiThanh','Thuong',20000),('NoiThanh','Nhanh',40000),('NoiThanh','TrongNgay',80000),
 ('NgoaiThanh','Thuong',35000),('NgoaiThanh','Nhanh',60000),('NgoaiThanh','TrongNgay',100000),
 ('TinhKhac','Thuong',50000),('TinhKhac','Nhanh',90000);
GO
