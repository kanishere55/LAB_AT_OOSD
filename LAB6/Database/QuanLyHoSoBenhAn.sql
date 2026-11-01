-- LAB6 - Nguyen Thanh Can - 1250080021
-- SQL Server 2022. Chay lai khong xoa du lieu. So tien mau chi dung cho thuc hanh.
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET ARITHABORT ON;
SET NUMERIC_ROUNDABORT OFF;
USE master;
GO
IF DB_ID(N'QuanLyHoSoBenhAn') IS NULL CREATE DATABASE QuanLyHoSoBenhAn;
GO
USE QuanLyHoSoBenhAn;
GO
IF OBJECT_ID(N'dbo.BenhNhan',N'U') IS NULL
 CREATE TABLE BenhNhan(MaBenhNhan varchar(20) PRIMARY KEY, HoTen nvarchar(100) NOT NULL,
 NgaySinh date NOT NULL, DiaChi nvarchar(250) NOT NULL, DienThoai varchar(20) NOT NULL, Anh3x4 varbinary(max) NOT NULL,
 CONSTRAINT CK_BenhNhan_ThongTin CHECK(LEN(LTRIM(RTRIM(HoTen)))>0 AND LEN(DienThoai)>=9 AND DATALENGTH(Anh3x4)>0));
IF OBJECT_ID(N'dbo.PhieuDangKy',N'U') IS NULL
 CREATE TABLE PhieuDangKy(MaDangKy varchar(20) PRIMARY KEY,MaBenhNhan varchar(20) NOT NULL UNIQUE REFERENCES BenhNhan(MaBenhNhan),NgayDangKy datetime2 NOT NULL);
IF OBJECT_ID(N'dbo.HoSoBenhAn',N'U') IS NULL
 CREATE TABLE HoSoBenhAn(MaHoSo varchar(20) PRIMARY KEY,MaBenhNhan varchar(20) NOT NULL UNIQUE REFERENCES BenhNhan(MaBenhNhan),NgayCap date NOT NULL);
IF OBJECT_ID(N'dbo.PhieuThuLePhi',N'U') IS NULL
 CREATE TABLE PhieuThuLePhi(MaThuLePhi varchar(20) PRIMARY KEY,MaBenhNhan varchar(20) NOT NULL REFERENCES BenhNhan(MaBenhNhan),NgayThu datetime2 NOT NULL,
 SoTien decimal(18,2) NOT NULL CHECK(SoTien>0),TuNgay date NOT NULL,DenNgay date NOT NULL,
 CONSTRAINT UQ_LePhi UNIQUE(MaBenhNhan,TuNgay),CONSTRAINT CK_LePhi_Nam CHECK(DenNgay=DATEADD(day,-1,DATEADD(year,1,TuNgay))));
IF OBJECT_ID(N'dbo.Khoa',N'U') IS NULL
 CREATE TABLE Khoa(MaKhoa varchar(20) PRIMARY KEY,TenKhoa nvarchar(100) NOT NULL UNIQUE);
IF OBJECT_ID(N'dbo.BacSi',N'U') IS NULL
 CREATE TABLE BacSi(MaBacSi varchar(20) PRIMARY KEY,HoTen nvarchar(100) NOT NULL,ChuyenMon nvarchar(100) NULL);
IF OBJECT_ID(N'dbo.Thuoc',N'U') IS NULL
 CREATE TABLE Thuoc(MaThuoc varchar(20) PRIMARY KEY,TenThuoc nvarchar(100) NOT NULL,DonViTinh nvarchar(30) NOT NULL,HamLuong nvarchar(100) NULL);
IF OBJECT_ID(N'dbo.LoaiXetNghiem',N'U') IS NULL
 CREATE TABLE LoaiXetNghiem(MaXetNghiem varchar(20) PRIMARY KEY,TenXetNghiem nvarchar(100) NOT NULL UNIQUE,MoTa nvarchar(250) NULL);
IF OBJECT_ID(N'dbo.LichHen',N'U') IS NULL
 CREATE TABLE LichHen(MaHen varchar(20) PRIMARY KEY,MaHoSo varchar(20) NOT NULL REFERENCES HoSoBenhAn(MaHoSo),NgayGioHen datetime2 NOT NULL,
 NoiDung nvarchar(250) NOT NULL,TrangThai nvarchar(30) NOT NULL DEFAULT N'Đã hẹn',
 Nam AS YEAR(NgayGioHen) PERSISTED,Quy AS DATEPART(quarter,NgayGioHen) PERSISTED,
 CONSTRAINT CK_LichHen_TrangThai CHECK(TrangThai IN(N'Đã hẹn',N'Đã xác nhận',N'Đã thực hiện',N'Đã hủy')));
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name=N'UX_LichHen_Quy' AND object_id=OBJECT_ID(N'dbo.LichHen'))
 CREATE UNIQUE INDEX UX_LichHen_Quy ON LichHen(MaHoSo,Nam,Quy) WHERE TrangThai<>N'Đã hủy';
IF OBJECT_ID(N'dbo.PhieuKham',N'U') IS NULL
 CREATE TABLE PhieuKham(MaPhieuKham varchar(20) PRIMARY KEY,MaHoSo varchar(20) NOT NULL REFERENCES HoSoBenhAn(MaHoSo),MaBacSi varchar(20) NOT NULL REFERENCES BacSi(MaBacSi),
 MaKhoa varchar(20) NOT NULL REFERENCES Khoa(MaKhoa),MaHen varchar(20) NULL REFERENCES LichHen(MaHen),NgayGioKham datetime2 NOT NULL,LoaiKham nvarchar(20) NOT NULL,
 TrieuChung nvarchar(500) NULL,ThanNhiet decimal(4,1) NULL,HuyetAp nvarchar(30) NULL,KetLuan nvarchar(500) NULL,DienBien nvarchar(500) NULL,
 PhanUngPhu nvarchar(500) NULL,HieuQuaDieuTri nvarchar(500) NULL,DaXuatVien bit NOT NULL DEFAULT 0,DaThanhToan bit NOT NULL DEFAULT 0,
 DaHoanTat bit NOT NULL DEFAULT 0,NgayHoanTat datetime2 NULL,PhiKham decimal(18,2) NOT NULL DEFAULT 0,
 Nam AS YEAR(NgayGioKham) PERSISTED,Quy AS DATEPART(quarter,NgayGioKham) PERSISTED,
 CONSTRAINT UQ_PhieuKham_BacSi UNIQUE(MaPhieuKham,MaBacSi),
 CONSTRAINT CK_Kham_Loai CHECK(LoaiKham IN(N'Điều trị',N'Định kỳ')),
 CONSTRAINT CK_Kham_Phi CHECK(PhiKham>=0 AND (LoaiKham<>N'Định kỳ' OR PhiKham=0)),
 CONSTRAINT CK_Kham_HoanTat CHECK((DaHoanTat=0 AND NgayHoanTat IS NULL) OR (DaHoanTat=1 AND DaXuatVien=1 AND DaThanhToan=1 AND NgayHoanTat IS NOT NULL)));
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name=N'UX_Kham_MaHen' AND object_id=OBJECT_ID(N'dbo.PhieuKham'))
 CREATE UNIQUE INDEX UX_Kham_MaHen ON PhieuKham(MaHen) WHERE MaHen IS NOT NULL;
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name=N'UX_Kham_DinhKy' AND object_id=OBJECT_ID(N'dbo.PhieuKham'))
 CREATE UNIQUE INDEX UX_Kham_DinhKy ON PhieuKham(MaHoSo,Nam,Quy) WHERE LoaiKham=N'Định kỳ';
IF OBJECT_ID(N'dbo.ChiDinhXetNghiem',N'U') IS NULL
 CREATE TABLE ChiDinhXetNghiem(MaChiDinh varchar(20) PRIMARY KEY,MaPhieuKham varchar(20) NOT NULL REFERENCES PhieuKham(MaPhieuKham),
 MaXetNghiem varchar(20) NOT NULL REFERENCES LoaiXetNghiem(MaXetNghiem),NgayChiDinh datetime2 NOT NULL,TrangThai nvarchar(30) NOT NULL DEFAULT N'Chờ kết quả',NgayKetQua datetime2 NULL,KetQua nvarchar(1000) NULL,
 CONSTRAINT CK_XN_KetQua CHECK((TrangThai=N'Chờ kết quả' AND NgayKetQua IS NULL AND KetQua IS NULL) OR (TrangThai=N'Đã có kết quả' AND NgayKetQua IS NOT NULL AND KetQua IS NOT NULL AND NgayKetQua>=NgayChiDinh AND LEN(LTRIM(RTRIM(KetQua)))>0)));
IF OBJECT_ID(N'dbo.ToaThuoc',N'U') IS NULL
 CREATE TABLE ToaThuoc(MaToa varchar(20) PRIMARY KEY,MaPhieuKham varchar(20) NOT NULL UNIQUE,MaBacSi varchar(20) NOT NULL REFERENCES BacSi(MaBacSi),NgayLap datetime2 NOT NULL,LoiDan nvarchar(500) NULL,
 CONSTRAINT FK_Toa_PhieuKham_BacSi FOREIGN KEY(MaPhieuKham,MaBacSi) REFERENCES PhieuKham(MaPhieuKham,MaBacSi));
IF OBJECT_ID(N'dbo.ChiTietToaThuoc',N'U') IS NULL
 CREATE TABLE ChiTietToaThuoc(MaToa varchar(20) NOT NULL REFERENCES ToaThuoc(MaToa),SoThuTu int NOT NULL CHECK(SoThuTu>0),MaThuoc varchar(20) NOT NULL REFERENCES Thuoc(MaThuoc),
 SoLuong int NOT NULL CHECK(SoLuong>0),LieuDung nvarchar(150) NOT NULL CHECK(LEN(LTRIM(RTRIM(LieuDung)))>0),CachDung nvarchar(150) NOT NULL CHECK(LEN(LTRIM(RTRIM(CachDung)))>0),PRIMARY KEY(MaToa,SoThuTu));
GO
IF TYPE_ID('dbo.DongToa') IS NULL EXEC('CREATE TYPE dbo.DongToa AS TABLE(SoThuTu int,MaThuoc varchar(20),SoLuong int,LieuDung nvarchar(150),CachDung nvarchar(150))');
GO
CREATE OR ALTER PROCEDURE dbo.DangKyBenhNhan
 @MaBenhNhan varchar(20),@HoTen nvarchar(100),@NgaySinh date,@DiaChi nvarchar(250),@DienThoai varchar(20),@Anh3x4 varbinary(max),
 @MaDangKy varchar(20),@MaHoSo varchar(20),@MaThuLePhi varchar(20),@Ngay date,@SoTien decimal(18,2)
AS
BEGIN
 SET NOCOUNT ON; SET XACT_ABORT ON;
 IF NULLIF(LTRIM(RTRIM(@HoTen)),N'') IS NULL OR NULLIF(LTRIM(RTRIM(@DiaChi)),N'') IS NULL OR @NgaySinh>@Ngay OR LEN(@DienThoai)<9 OR DATALENGTH(@Anh3x4) IS NULL OR DATALENGTH(@Anh3x4)=0 OR @SoTien<=0
 THROW 51000,N'Cần đủ thông tin, ảnh 3x4, ngày sinh hợp lệ và lệ phí lớn hơn 0.',1;
 BEGIN TRY
  BEGIN TRAN;
  INSERT BenhNhan VALUES(@MaBenhNhan,@HoTen,@NgaySinh,@DiaChi,@DienThoai,@Anh3x4);
  INSERT PhieuDangKy VALUES(@MaDangKy,@MaBenhNhan,@Ngay);
  INSERT PhieuThuLePhi VALUES(@MaThuLePhi,@MaBenhNhan,@Ngay,@SoTien,@Ngay,DATEADD(day,-1,DATEADD(year,1,@Ngay)));
  INSERT HoSoBenhAn VALUES(@MaHoSo,@MaBenhNhan,@Ngay);
  COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.ThuLePhiNam @MaThuLePhi varchar(20),@MaBenhNhan varchar(20),@TuNgay date,@SoTien decimal(18,2)
AS
BEGIN
 SET NOCOUNT ON;SET XACT_ABORT ON;SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
 BEGIN TRY BEGIN TRAN;
 IF @SoTien<=0 THROW 51001,N'Lệ phí phải lớn hơn 0.',1;
 IF EXISTS(SELECT 1 FROM PhieuThuLePhi WITH(UPDLOCK,HOLDLOCK) WHERE MaBenhNhan=@MaBenhNhan AND TuNgay<=DATEADD(day,-1,DATEADD(year,1,@TuNgay)) AND DenNgay>=@TuNgay)
 THROW 51002,N'Thời hạn lệ phí bị trùng với lần thu trước.',1;
 INSERT PhieuThuLePhi VALUES(@MaThuLePhi,@MaBenhNhan,SYSDATETIME(),@SoTien,@TuNgay,DATEADD(day,-1,DATEADD(year,1,@TuNgay)));
 COMMIT;END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK;THROW;END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.DatLichDinhKy @MaHen varchar(20),@MaHoSo varchar(20),@NgayGioHen datetime2,@NoiDung nvarchar(250)
AS
BEGIN
 SET NOCOUNT ON;SET XACT_ABORT ON;SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
 BEGIN TRY BEGIN TRAN;
 IF NOT EXISTS(SELECT 1 FROM HoSoBenhAn h JOIN PhieuThuLePhi p WITH(UPDLOCK,HOLDLOCK) ON h.MaBenhNhan=p.MaBenhNhan WHERE h.MaHoSo=@MaHoSo AND CAST(@NgayGioHen AS date) BETWEEN p.TuNgay AND p.DenNgay)
 THROW 51003,N'Hồ sơ không tồn tại hoặc lệ phí không còn hiệu lực vào ngày hẹn.',1;
 IF EXISTS(SELECT 1 FROM PhieuKham WITH(UPDLOCK,HOLDLOCK) WHERE MaHoSo=@MaHoSo AND LoaiKham=N'Định kỳ' AND Nam=YEAR(@NgayGioHen) AND Quy=DATEPART(quarter,@NgayGioHen))
 THROW 51004,N'Đã sử dụng quyền khám định kỳ trong quý này.',1;
 INSERT LichHen(MaHen,MaHoSo,NgayGioHen,NoiDung) VALUES(@MaHen,@MaHoSo,@NgayGioHen,@NoiDung);
 COMMIT;END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK;THROW;END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.CapNhatLichHen @MaHen varchar(20),@NgayGioHen datetime2,@NoiDung nvarchar(250),@TrangThai nvarchar(30)
AS
BEGIN
 SET NOCOUNT ON;SET XACT_ABORT ON;SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
 BEGIN TRY BEGIN TRAN;
 DECLARE @hs varchar(20);
 SELECT @hs=MaHoSo FROM LichHen WITH(UPDLOCK,HOLDLOCK) WHERE MaHen=@MaHen AND TrangThai IN(N'Đã hẹn',N'Đã xác nhận');
 IF @hs IS NULL OR @TrangThai NOT IN(N'Đã hẹn',N'Đã xác nhận',N'Đã hủy') THROW 51005,N'Lịch hẹn không còn được phép thay đổi.',1;
 IF @TrangThai<>N'Đã hủy' AND (NOT EXISTS(SELECT 1 FROM HoSoBenhAn h JOIN PhieuThuLePhi p ON h.MaBenhNhan=p.MaBenhNhan WHERE h.MaHoSo=@hs AND CAST(@NgayGioHen AS date) BETWEEN p.TuNgay AND p.DenNgay)
 OR EXISTS(SELECT 1 FROM PhieuKham WHERE MaHoSo=@hs AND LoaiKham=N'Định kỳ' AND Nam=YEAR(@NgayGioHen) AND Quy=DATEPART(quarter,@NgayGioHen))) THROW 51006,N'Ngày đổi hẹn không có quyền khám định kỳ hợp lệ.',1;
 UPDATE LichHen SET NgayGioHen=@NgayGioHen,NoiDung=@NoiDung,TrangThai=@TrangThai WHERE MaHen=@MaHen;
 COMMIT;END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK;THROW;END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.LapPhieuKham @MaPhieuKham varchar(20),@MaHoSo varchar(20),@MaBacSi varchar(20),@MaKhoa varchar(20),@NgayGioKham datetime2,@LoaiKham nvarchar(20),@MaHen varchar(20)=NULL,@PhiKham decimal(18,2)=0
AS
BEGIN
 SET NOCOUNT ON;SET XACT_ABORT ON;SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
 BEGIN TRY BEGIN TRAN;
 IF @LoaiKham=N'Định kỳ' AND NOT EXISTS(SELECT 1 FROM HoSoBenhAn h JOIN PhieuThuLePhi p WITH(UPDLOCK,HOLDLOCK) ON h.MaBenhNhan=p.MaBenhNhan WHERE h.MaHoSo=@MaHoSo AND CAST(@NgayGioKham AS date) BETWEEN p.TuNgay AND p.DenNgay)
 THROW 51007,N'Lệ phí năm không còn hiệu lực để khám định kỳ.',1;
 IF @MaHen IS NOT NULL AND NOT EXISTS(SELECT 1 FROM LichHen WITH(UPDLOCK,HOLDLOCK) WHERE MaHen=@MaHen AND MaHoSo=@MaHoSo AND TrangThai IN(N'Đã hẹn',N'Đã xác nhận') AND CAST(NgayGioHen AS date)=CAST(@NgayGioKham AS date))
 THROW 51008,N'Lịch hẹn phải đúng hồ sơ, đúng ngày và chưa được thực hiện/hủy.',1;
 IF @MaHen IS NOT NULL AND @LoaiKham<>N'Định kỳ' THROW 51009,N'Lịch hẹn này dùng cho khám định kỳ.',1;
 IF @LoaiKham=N'Định kỳ' AND @MaHen IS NULL AND EXISTS(SELECT 1 FROM LichHen WITH(UPDLOCK,HOLDLOCK) WHERE MaHoSo=@MaHoSo AND Nam=YEAR(@NgayGioKham) AND Quy=DATEPART(quarter,@NgayGioKham) AND TrangThai IN(N'Đã hẹn',N'Đã xác nhận'))
 THROW 51019,N'Quý này đã có lịch hẹn: nhập đúng mã hẹn hoặc hủy lịch trước khi lập phiếu.',1;
 INSERT PhieuKham(MaPhieuKham,MaHoSo,MaBacSi,MaKhoa,MaHen,NgayGioKham,LoaiKham,PhiKham) VALUES(@MaPhieuKham,@MaHoSo,@MaBacSi,@MaKhoa,@MaHen,@NgayGioKham,@LoaiKham,@PhiKham);
 IF @MaHen IS NOT NULL UPDATE LichHen SET TrangThai=N'Đã thực hiện' WHERE MaHen=@MaHen;
 COMMIT;END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK;THROW;END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.GhiNhanKham @MaPhieuKham varchar(20),@TrieuChung nvarchar(500),@ThanNhiet decimal(4,1)=NULL,@HuyetAp nvarchar(30),@KetLuan nvarchar(500),@DienBien nvarchar(500),@PhanUngPhu nvarchar(500),@HieuQuaDieuTri nvarchar(500)
AS
BEGIN
 SET NOCOUNT ON;
 UPDATE PhieuKham SET TrieuChung=@TrieuChung,ThanNhiet=@ThanNhiet,HuyetAp=@HuyetAp,KetLuan=@KetLuan,DienBien=@DienBien,PhanUngPhu=@PhanUngPhu,HieuQuaDieuTri=@HieuQuaDieuTri WHERE MaPhieuKham=@MaPhieuKham AND DaHoanTat=0;
 IF @@ROWCOUNT=0 THROW 51010,N'Phiếu khám không tồn tại hoặc đã hoàn tất.',1;
END;
GO
CREATE OR ALTER PROCEDURE dbo.LapChiDinh @MaChiDinh varchar(20),@MaPhieuKham varchar(20),@MaXetNghiem varchar(20),@NgayChiDinh datetime2
AS
BEGIN
 SET NOCOUNT ON;SET XACT_ABORT ON;
 BEGIN TRY BEGIN TRAN;
 IF NOT EXISTS(SELECT 1 FROM PhieuKham WITH(UPDLOCK,HOLDLOCK) WHERE MaPhieuKham=@MaPhieuKham AND DaHoanTat=0) THROW 51011,N'Phiếu khám không còn mở.',1;
 INSERT ChiDinhXetNghiem(MaChiDinh,MaPhieuKham,MaXetNghiem,NgayChiDinh) VALUES(@MaChiDinh,@MaPhieuKham,@MaXetNghiem,@NgayChiDinh);
 COMMIT;END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK;THROW;END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.GhiKetQua @MaChiDinh varchar(20),@NgayKetQua datetime2,@KetQua nvarchar(1000)
AS
BEGIN
 SET NOCOUNT ON;SET XACT_ABORT ON;
 BEGIN TRY BEGIN TRAN;
 IF NOT EXISTS(SELECT 1 FROM PhieuKham p WITH(UPDLOCK,HOLDLOCK) JOIN ChiDinhXetNghiem x ON x.MaPhieuKham=p.MaPhieuKham WHERE x.MaChiDinh=@MaChiDinh AND p.DaHoanTat=0) THROW 51012,N'Không tìm thấy chỉ định thuộc phiếu khám đang mở.',1;
 UPDATE ChiDinhXetNghiem SET NgayKetQua=@NgayKetQua,KetQua=@KetQua,TrangThai=N'Đã có kết quả' WHERE MaChiDinh=@MaChiDinh;
 COMMIT;END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK;THROW;END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.LapToaThuoc @MaToa varchar(20),@MaPhieuKham varchar(20),@MaBacSi varchar(20),@LoiDan nvarchar(500),@ChiTiet dbo.DongToa READONLY
AS
BEGIN
 SET NOCOUNT ON;SET XACT_ABORT ON;
 BEGIN TRY BEGIN TRAN;
 IF NOT EXISTS(SELECT 1 FROM PhieuKham WITH(UPDLOCK,HOLDLOCK) WHERE MaPhieuKham=@MaPhieuKham AND MaBacSi=@MaBacSi AND DaHoanTat=0 AND LEN(LTRIM(RTRIM(KetLuan)))>0) THROW 51013,N'Phiếu khám chưa có kết luận, sai bác sĩ hoặc đã hoàn tất.',1;
 IF EXISTS(SELECT 1 FROM ChiDinhXetNghiem WHERE MaPhieuKham=@MaPhieuKham AND TrangThai<>N'Đã có kết quả') THROW 51014,N'Chờ đủ kết quả xét nghiệm trước khi lập toa.',1;
 IF NOT EXISTS(SELECT 1 FROM @ChiTiet) THROW 51015,N'Toa phải có ít nhất một dòng thuốc.',1;
 INSERT ToaThuoc VALUES(@MaToa,@MaPhieuKham,@MaBacSi,SYSDATETIME(),@LoiDan);
 INSERT ChiTietToaThuoc SELECT @MaToa,SoThuTu,MaThuoc,SoLuong,LieuDung,CachDung FROM @ChiTiet;
 COMMIT;END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK;THROW;END CATCH;
END;
GO
CREATE OR ALTER PROCEDURE dbo.XacNhanThuTuc @MaPhieuKham varchar(20),@DaXuatVien bit,@DaThanhToan bit
AS
BEGIN
 SET NOCOUNT ON;
 UPDATE PhieuKham SET DaXuatVien=@DaXuatVien,DaThanhToan=@DaThanhToan WHERE MaPhieuKham=@MaPhieuKham AND DaHoanTat=0;
 IF @@ROWCOUNT=0 THROW 51016,N'Phiếu không tồn tại hoặc đã hoàn tất.',1;
END;
GO
CREATE OR ALTER PROCEDURE dbo.HoanTatDieuTri @MaPhieuKham varchar(20)
AS
BEGIN
 SET NOCOUNT ON;SET XACT_ABORT ON;
 BEGIN TRY BEGIN TRAN;
 IF NOT EXISTS(SELECT 1 FROM PhieuKham WITH(UPDLOCK,HOLDLOCK) WHERE MaPhieuKham=@MaPhieuKham AND DaHoanTat=0 AND DaXuatVien=1 AND DaThanhToan=1 AND LEN(LTRIM(RTRIM(KetLuan)))>0) THROW 51017,N'Cần có kết luận, xuất viện và xác nhận đã thanh toán viện phí.',1;
 IF EXISTS(SELECT 1 FROM ChiDinhXetNghiem WHERE MaPhieuKham=@MaPhieuKham AND TrangThai<>N'Đã có kết quả') THROW 51018,N'Còn chỉ định chưa có kết quả.',1;
 UPDATE PhieuKham SET DaHoanTat=1,NgayHoanTat=SYSDATETIME() WHERE MaPhieuKham=@MaPhieuKham;
 COMMIT;END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK;THROW;END CATCH;
END;
GO
IF NOT EXISTS(SELECT 1 FROM Khoa WHERE MaKhoa='K01') INSERT Khoa VALUES('K01',N'Nội tổng quát'),('K02',N'Khám sức khỏe');
IF NOT EXISTS(SELECT 1 FROM BacSi WHERE MaBacSi='BS01') INSERT BacSi VALUES('BS01',N'Bác sĩ mẫu 01',N'Nội khoa'),('BS02',N'Bác sĩ mẫu 02',N'Khám tổng quát');
IF NOT EXISTS(SELECT 1 FROM Thuoc WHERE MaThuoc='T01') INSERT Thuoc VALUES('T01',N'Thuốc mẫu A',N'Viên',N'Mẫu thực hành'),('T02',N'Thuốc mẫu B',N'Gói',N'Mẫu thực hành');
IF NOT EXISTS(SELECT 1 FROM LoaiXetNghiem WHERE MaXetNghiem='XN01') INSERT LoaiXetNghiem VALUES('XN01',N'Xét nghiệm mẫu 01',N'Dữ liệu thực hành'),('XN02',N'Xét nghiệm mẫu 02',N'Dữ liệu thực hành');
GO
