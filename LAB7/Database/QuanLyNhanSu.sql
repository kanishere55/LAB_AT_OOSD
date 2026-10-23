IF DB_ID(N'QuanLyNhanSu') IS NULL CREATE DATABASE QuanLyNhanSu;
GO
USE QuanLyNhanSu;
GO
SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; SET ANSI_PADDING ON; SET ANSI_WARNINGS ON;
SET ARITHABORT ON; SET CONCAT_NULL_YIELDS_NULL ON; SET NUMERIC_ROUNDABORT OFF;
GO
IF OBJECT_ID(N'dbo.PhongBan',N'U') IS NULL
CREATE TABLE dbo.PhongBan (MaPB varchar(20) PRIMARY KEY, TenPB nvarchar(120) NOT NULL UNIQUE);
GO
IF OBJECT_ID(N'dbo.ChucVu',N'U') IS NULL
CREATE TABLE dbo.ChucVu (MaCV varchar(20) PRIMARY KEY, TenCV nvarchar(100) NOT NULL UNIQUE);
GO
IF OBJECT_ID(N'dbo.CaLam',N'U') IS NULL
CREATE TABLE dbo.CaLam (MaCa varchar(20) PRIMARY KEY, TenCa nvarchar(100) NOT NULL, GioBatDau time NOT NULL, GioKetThuc time NOT NULL, SoGio decimal(5,2) NOT NULL CHECK(SoGio>0 AND SoGio<=24));
GO
IF OBJECT_ID(N'dbo.NhanVien',N'U') IS NULL
CREATE TABLE dbo.NhanVien (MaNV varchar(20) PRIMARY KEY, HoTen nvarchar(120) NOT NULL, NgaySinh date NOT NULL, DienThoai varchar(20) NOT NULL, DiaChi nvarchar(250) NOT NULL, MaPB varchar(20) NOT NULL REFERENCES PhongBan(MaPB), TrangThai nvarchar(30) NOT NULL DEFAULT N'Thử việc' CHECK(TrangThai IN(N'Thử việc',N'Chính thức',N'Không đạt')));
GO
IF OBJECT_ID(N'dbo.QuyetDinhTuyenDung',N'U') IS NULL
CREATE TABLE dbo.QuyetDinhTuyenDung (SoQD varchar(20) PRIMARY KEY, MaNV varchar(20) NOT NULL UNIQUE REFERENCES NhanVien(MaNV), NgayQD date NOT NULL, TuNgay date NOT NULL, DenNgay date NOT NULL, LuongThuViec decimal(18,0) NOT NULL CHECK(LuongThuViec>0), DieuKhoan nvarchar(1000) NOT NULL, KetQua nvarchar(20) NULL CHECK(KetQua IN(N'Đạt',N'Không đạt')), NgayDanhGia date NULL, CHECK(DenNgay>=TuNgay AND TuNgay>=NgayQD), CHECK((KetQua IS NULL AND NgayDanhGia IS NULL) OR (KetQua IS NOT NULL AND NgayDanhGia IS NOT NULL AND NgayDanhGia>=DenNgay)));
GO
IF OBJECT_ID(N'dbo.HopDong',N'U') IS NULL
CREATE TABLE dbo.HopDong (SoHD varchar(20) PRIMARY KEY, MaNV varchar(20) NOT NULL REFERENCES NhanVien(MaNV), Loai nvarchar(20) NOT NULL CHECK(Loai IN(N'Dài hạn',N'Ngắn hạn')), NgayKy date NOT NULL, TuNgay date NOT NULL, DenNgay date NULL, DieuKhoan nvarchar(1000) NOT NULL, CHECK(TuNgay>=NgayKy), CHECK((Loai=N'Dài hạn' AND DenNgay IS NULL) OR (Loai=N'Ngắn hạn' AND DenNgay IS NOT NULL AND DenNgay>=TuNgay)));
GO
IF OBJECT_ID(N'dbo.BaoHiem',N'U') IS NULL
CREATE TABLE dbo.BaoHiem (SoBH varchar(20) PRIMARY KEY, SoHD varchar(20) NOT NULL UNIQUE REFERENCES HopDong(SoHD), SoBHYT varchar(30) NOT NULL UNIQUE, SoBHXH varchar(30) NOT NULL UNIQUE, MucDong decimal(18,0) NOT NULL CHECK(MucDong>0), TyLeYT decimal(6,4) NOT NULL CHECK(TyLeYT BETWEEN 0 AND 1), TyLeXH decimal(6,4) NOT NULL CHECK(TyLeXH BETWEEN 0 AND 1), CHECK(TyLeYT+TyLeXH<=1));
GO
IF OBJECT_ID(N'dbo.QuyetDinhLuong',N'U') IS NULL
CREATE TABLE dbo.QuyetDinhLuong (SoQD varchar(20) PRIMARY KEY, MaNV varchar(20) NOT NULL REFERENCES NhanVien(MaNV), NgayHieuLuc date NOT NULL, LuongCoBan decimal(18,0) NOT NULL CHECK(LuongCoBan>0), PhuCapLuong decimal(18,0) NOT NULL CHECK(PhuCapLuong>=0), PhuCapDocHai decimal(18,0) NOT NULL CHECK(PhuCapDocHai>=0), UNIQUE(MaNV,NgayHieuLuc));
GO
IF OBJECT_ID(N'dbo.QuyetDinhChucVu',N'U') IS NULL
CREATE TABLE dbo.QuyetDinhChucVu (SoQD varchar(20) PRIMARY KEY, MaNV varchar(20) NOT NULL REFERENCES NhanVien(MaNV), MaCV varchar(20) NOT NULL REFERENCES ChucVu(MaCV), NgayHieuLuc date NOT NULL, PhuCap decimal(18,0) NOT NULL CHECK(PhuCap>=0), UNIQUE(MaNV,NgayHieuLuc));
GO
IF OBJECT_ID(N'dbo.KeHoachTuan',N'U') IS NULL
CREATE TABLE dbo.KeHoachTuan (MaKH varchar(20) PRIMARY KEY, MaPB varchar(20) NOT NULL REFERENCES PhongBan(MaPB), DauTuan date NOT NULL, NguoiLap nvarchar(120) NOT NULL, UNIQUE(MaPB,DauTuan));
GO
IF OBJECT_ID(N'dbo.PhanCongCa',N'U') IS NULL
CREATE TABLE dbo.PhanCongCa (MaKH varchar(20) NOT NULL REFERENCES KeHoachTuan(MaKH), MaNV varchar(20) NOT NULL REFERENCES NhanVien(MaNV), Ngay date NOT NULL, MaCa varchar(20) NOT NULL REFERENCES CaLam(MaCa), GioPhuTroiDuKien decimal(5,2) NOT NULL CHECK(GioPhuTroiDuKien BETWEEN 0 AND 24), PRIMARY KEY(MaKH,MaNV,Ngay,MaCa), UNIQUE(MaNV,Ngay,MaCa));
GO
IF OBJECT_ID(N'dbo.ChamCong',N'U') IS NULL
CREATE TABLE dbo.ChamCong (MaNV varchar(20) NOT NULL REFERENCES NhanVien(MaNV), Ngay date NOT NULL, MaCa varchar(20) NOT NULL REFERENCES CaLam(MaCa), SoGio decimal(5,2) NOT NULL CHECK(SoGio BETWEEN 0 AND 24), NguoiCham nvarchar(120) NOT NULL, PRIMARY KEY(MaNV,Ngay,MaCa));
GO
IF OBJECT_ID(N'dbo.PhieuPhuTroi',N'U') IS NULL
CREATE TABLE dbo.PhieuPhuTroi (SoPhieu varchar(20) PRIMARY KEY, Ngay date NOT NULL, SoGio decimal(5,2) NOT NULL CHECK(SoGio>0 AND SoGio<=24), HinhThuc nvarchar(20) NOT NULL CHECK(HinhThuc IN(N'Tăng ca',N'Ngày lễ',N'Ngày nghỉ')), NguoiLap nvarchar(120) NOT NULL);
GO
IF OBJECT_ID(N'dbo.ChiTietPhuTroi',N'U') IS NULL
CREATE TABLE dbo.ChiTietPhuTroi (SoPhieu varchar(20) NOT NULL REFERENCES PhieuPhuTroi(SoPhieu), MaNV varchar(20) NOT NULL REFERENCES NhanVien(MaNV), PRIMARY KEY(SoPhieu,MaNV));
GO
IF OBJECT_ID(N'dbo.QuyetDinhKhenThuong',N'U') IS NULL
CREATE TABLE dbo.QuyetDinhKhenThuong (SoQD varchar(20) PRIMARY KEY, Ngay date NOT NULL, MaNV varchar(20) NULL REFERENCES NhanVien(MaNV), MaPB varchar(20) NULL REFERENCES PhongBan(MaPB), NoiDung nvarchar(1000) NOT NULL, TongTien decimal(18,0) NOT NULL CHECK(TongTien>0), NguoiKy nvarchar(120) NOT NULL, CachXuLy nvarchar(20) NOT NULL CHECK(CachXuLy IN(N'Qua lương',N'Trực tiếp')), CHECK((MaNV IS NOT NULL AND MaPB IS NULL) OR (MaNV IS NULL AND MaPB IS NOT NULL)));
GO
IF OBJECT_ID(N'dbo.ChiTietKhenThuong',N'U') IS NULL
CREATE TABLE dbo.ChiTietKhenThuong (SoQD varchar(20) NOT NULL REFERENCES QuyetDinhKhenThuong(SoQD), MaNV varchar(20) NOT NULL REFERENCES NhanVien(MaNV), SoTien decimal(18,0) NOT NULL CHECK(SoTien>0), PRIMARY KEY(SoQD,MaNV));
GO
IF OBJECT_ID(N'dbo.PhieuChi',N'U') IS NULL
CREATE TABLE dbo.PhieuChi (SoPhieu varchar(20) PRIMARY KEY, SoQD varchar(20) NOT NULL UNIQUE REFERENCES QuyetDinhKhenThuong(SoQD), Ngay date NOT NULL, SoTien decimal(18,0) NOT NULL CHECK(SoTien>0));
GO
IF OBJECT_ID(N'dbo.QuyetDinhKyLuat',N'U') IS NULL
CREATE TABLE dbo.QuyetDinhKyLuat (SoQD varchar(20) PRIMARY KEY, Ngay date NOT NULL, MaNV varchar(20) NULL REFERENCES NhanVien(MaNV), MaPB varchar(20) NULL REFERENCES PhongBan(MaPB), NoiDung nvarchar(1000) NOT NULL, TongTien decimal(18,0) NOT NULL CHECK(TongTien>0), NguoiKy nvarchar(120) NOT NULL, CachXuLy nvarchar(20) NOT NULL CHECK(CachXuLy IN(N'Qua lương',N'Trực tiếp')), CHECK((MaNV IS NOT NULL AND MaPB IS NULL) OR (MaNV IS NULL AND MaPB IS NOT NULL)));
GO
IF OBJECT_ID(N'dbo.ChiTietKyLuat',N'U') IS NULL
CREATE TABLE dbo.ChiTietKyLuat (SoQD varchar(20) NOT NULL REFERENCES QuyetDinhKyLuat(SoQD), MaNV varchar(20) NOT NULL REFERENCES NhanVien(MaNV), SoTien decimal(18,0) NOT NULL CHECK(SoTien>0), PRIMARY KEY(SoQD,MaNV));
GO
IF OBJECT_ID(N'dbo.PhieuThu',N'U') IS NULL
CREATE TABLE dbo.PhieuThu (SoPhieu varchar(20) PRIMARY KEY, SoQD varchar(20) NOT NULL UNIQUE REFERENCES QuyetDinhKyLuat(SoQD), Ngay date NOT NULL, SoTien decimal(18,0) NOT NULL CHECK(SoTien>0));
GO
IF OBJECT_ID(N'dbo.BangLuong',N'U') IS NULL
CREATE TABLE dbo.BangLuong (MaBL varchar(20) PRIMARY KEY, Thang int NOT NULL CHECK(Thang BETWEEN 1 AND 12), Nam int NOT NULL CHECK(Nam BETWEEN 2000 AND 2100), NgayLap date NOT NULL, NgayCongChuan decimal(5,2) NOT NULL CHECK(NgayCongChuan>0), GioNgay decimal(5,2) NOT NULL CHECK(GioNgay>0 AND GioNgay<=24), UNIQUE(Thang,Nam));
GO
IF OBJECT_ID(N'dbo.ChiTietBangLuong',N'U') IS NULL
CREATE TABLE dbo.ChiTietBangLuong (MaBL varchar(20) NOT NULL REFERENCES BangLuong(MaBL), MaNV varchar(20) NOT NULL REFERENCES NhanVien(MaNV), GioCong decimal(8,2) NOT NULL, GioPhuTroi decimal(8,2) NOT NULL, LuongCoBan decimal(18,0) NOT NULL, PhuCap decimal(18,0) NOT NULL, TienCong decimal(18,0) NOT NULL, TienPhuTroi decimal(18,0) NOT NULL, BaoHiem decimal(18,0) NOT NULL, Thuong decimal(18,0) NOT NULL, Phat decimal(18,0) NOT NULL, ThucLinh AS (TienCong+TienPhuTroi+Thuong-BaoHiem-Phat) PERSISTED, PRIMARY KEY(MaBL,MaNV));
GO
IF TYPE_ID(N'dbo.DanhSachTien') IS NULL EXEC(N'CREATE TYPE dbo.DanhSachTien AS TABLE(MaNV varchar(20) PRIMARY KEY, SoTien decimal(18,0) NOT NULL)');
GO
CREATE OR ALTER PROCEDURE dbo.TuyenDung @MaNV varchar(20),@HoTen nvarchar(120),@NgaySinh date,@DienThoai varchar(20),@DiaChi nvarchar(250),@MaPB varchar(20),@SoQD varchar(20),@NgayQD date,@TuNgay date,@DenNgay date,@Luong decimal(18,0),@DieuKhoan nvarchar(1000)
AS BEGIN SET XACT_ABORT ON; SET NOCOUNT ON;
 IF LTRIM(RTRIM(@HoTen))='' OR LTRIM(RTRIM(@DieuKhoan))='' OR LTRIM(RTRIM(@DienThoai))='' OR LTRIM(RTRIM(@DiaChi))='' OR LTRIM(RTRIM(@MaNV))='' OR LTRIM(RTRIM(@SoQD))='' OR @NgaySinh>=@NgayQD THROW 50001,N'Kiểm tra họ tên, ngày sinh và điều khoản.',1;
 BEGIN TRAN;
 INSERT NhanVien(MaNV,HoTen,NgaySinh,DienThoai,DiaChi,MaPB) VALUES(@MaNV,@HoTen,@NgaySinh,@DienThoai,@DiaChi,@MaPB);
 INSERT QuyetDinhTuyenDung(SoQD,MaNV,NgayQD,TuNgay,DenNgay,LuongThuViec,DieuKhoan) VALUES(@SoQD,@MaNV,@NgayQD,@TuNgay,@DenNgay,@Luong,@DieuKhoan);
 COMMIT; END;
GO
CREATE OR ALTER PROCEDURE dbo.DanhGia @MaNV varchar(20),@Ngay date,@KetQua nvarchar(20)
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
 IF NOT EXISTS(SELECT 1 FROM QuyetDinhTuyenDung WITH(UPDLOCK,HOLDLOCK) WHERE MaNV=@MaNV AND KetQua IS NULL AND DenNgay<=@Ngay) THROW 50002,N'Chưa hết thử việc hoặc đã đánh giá.',1;
 UPDATE QuyetDinhTuyenDung SET KetQua=@KetQua,NgayDanhGia=@Ngay WHERE MaNV=@MaNV;
 IF @KetQua=N'Không đạt' UPDATE NhanVien SET TrangThai=N'Không đạt' WHERE MaNV=@MaNV;
 COMMIT; END;
GO
CREATE OR ALTER PROCEDURE dbo.KyHopDong @SoHD varchar(20),@MaNV varchar(20),@Loai nvarchar(20),@NgayKy date,@TuNgay date,@DenNgay date=NULL,@DieuKhoan nvarchar(1000),@SoBH varchar(20)=NULL,@YT varchar(30)=NULL,@XH varchar(30)=NULL,@MucDong decimal(18,0)=0,@TyLeYT decimal(6,4)=0,@TyLeXH decimal(6,4)=0
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
 IF NOT EXISTS(SELECT 1 FROM QuyetDinhTuyenDung WITH(UPDLOCK,HOLDLOCK) WHERE MaNV=@MaNV AND KetQua=N'Đạt' AND NgayDanhGia<=@NgayKy) THROW 50003,N'Nhân viên chưa được đánh giá đạt trước ngày ký.',1;
 IF EXISTS(SELECT 1 FROM HopDong WITH(UPDLOCK,HOLDLOCK) WHERE MaNV=@MaNV AND TuNgay<=ISNULL(@DenNgay,'99991231') AND ISNULL(DenNgay,'99991231')>=@TuNgay) THROW 50004,N'Thời hạn hợp đồng bị chồng lấn.',1;
 IF LTRIM(RTRIM(@DieuKhoan))='' THROW 50005,N'Nhập điều khoản hợp đồng.',1;
 INSERT HopDong VALUES(@SoHD,@MaNV,@Loai,@NgayKy,@TuNgay,@DenNgay,@DieuKhoan);
 IF @Loai=N'Dài hạn' BEGIN
 IF ISNULL(@SoBH,'')='' OR ISNULL(@YT,'')='' OR ISNULL(@XH,'')='' THROW 50006,N'Hợp đồng dài hạn phải có BHYT và BHXH.',1;
 INSERT BaoHiem VALUES(@SoBH,@SoHD,@YT,@XH,@MucDong,@TyLeYT,@TyLeXH); END;
 UPDATE NhanVien SET TrangThai=N'Chính thức' WHERE MaNV=@MaNV;
 COMMIT; END;
GO
CREATE OR ALTER PROCEDURE dbo.PhanCong @MaKH varchar(20),@MaNV varchar(20),@Ngay date,@MaCa varchar(20),@Gio decimal(5,2)
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
 IF NOT EXISTS(SELECT 1 FROM KeHoachTuan k JOIN NhanVien n ON k.MaPB=n.MaPB WHERE k.MaKH=@MaKH AND n.MaNV=@MaNV AND n.TrangThai<>N'Không đạt' AND @Ngay BETWEEN k.DauTuan AND DATEADD(day,6,k.DauTuan)) THROW 50007,N'Sai phòng ban, nhân viên hoặc tuần phân công.',1;
 IF EXISTS(SELECT 1 FROM PhanCongCa p WITH(UPDLOCK,HOLDLOCK) JOIN CaLam c ON c.MaCa=p.MaCa CROSS JOIN CaLam m WHERE p.MaNV=@MaNV AND p.Ngay=@Ngay AND m.MaCa=@MaCa AND c.GioBatDau<m.GioKetThuc AND m.GioBatDau<c.GioKetThuc) THROW 50008,N'Ca làm bị trùng giờ.',1;
 INSERT PhanCongCa VALUES(@MaKH,@MaNV,@Ngay,@MaCa,@Gio); COMMIT; END;
GO
CREATE OR ALTER PROCEDURE dbo.GhiChamCong @MaNV varchar(20),@Ngay date,@MaCa varchar(20),@Gio decimal(5,2),@Nguoi nvarchar(120)
AS BEGIN SET NOCOUNT ON;
 IF NOT EXISTS(SELECT 1 FROM PhanCongCa p JOIN CaLam c ON p.MaCa=c.MaCa WHERE p.MaNV=@MaNV AND p.Ngay=@Ngay AND p.MaCa=@MaCa AND @Gio<=c.SoGio) THROW 50009,N'Chưa phân công ca hoặc số giờ vượt ca.',1;
 IF EXISTS(SELECT 1 FROM BangLuong WHERE Thang=MONTH(@Ngay) AND Nam=YEAR(@Ngay)) THROW 50010,N'Tháng đã lập bảng lương.',1;
 INSERT ChamCong VALUES(@MaNV,@Ngay,@MaCa,@Gio,@Nguoi); END;
GO
CREATE OR ALTER PROCEDURE dbo.LapPhuTroi @SoPhieu varchar(20),@Ngay date,@Gio decimal(5,2),@HinhThuc nvarchar(20),@Nguoi nvarchar(120),@DS dbo.DanhSachTien READONLY
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
 IF NOT EXISTS(SELECT 1 FROM @DS) THROW 50011,N'Phiếu phụ trội cần nhân viên tham gia.',1;
 IF EXISTS(SELECT 1 FROM @DS d WHERE NOT EXISTS(SELECT 1 FROM PhanCongCa p WHERE p.MaNV=d.MaNV AND p.Ngay=@Ngay AND p.GioPhuTroiDuKien>=@Gio)) THROW 50012,N'Nhân viên chưa có kế hoạch phụ trội phù hợp.',1;
 IF EXISTS(SELECT 1 FROM BangLuong WHERE Thang=MONTH(@Ngay) AND Nam=YEAR(@Ngay)) THROW 50010,N'Tháng đã lập bảng lương.',1;
 IF EXISTS(SELECT 1 FROM @DS d WHERE ISNULL((SELECT SUM(p.SoGio) FROM ChiTietPhuTroi c JOIN PhieuPhuTroi p ON p.SoPhieu=c.SoPhieu WHERE c.MaNV=d.MaNV AND p.Ngay=@Ngay),0)+@Gio>24) THROW 50013,N'Tổng giờ phụ trội ngày vượt 24.',1;
 INSERT PhieuPhuTroi VALUES(@SoPhieu,@Ngay,@Gio,@HinhThuc,@Nguoi);
 INSERT ChiTietPhuTroi SELECT @SoPhieu,MaNV FROM @DS; COMMIT; END;
GO

CREATE OR ALTER PROCEDURE dbo.LapKhenThuong @SoQD varchar(20),@Ngay date,@MaNV varchar(20)=NULL,@MaPB varchar(20)=NULL,@NoiDung nvarchar(1000),@Tong decimal(18,0),@NguoiKy nvarchar(120),@Cach nvarchar(20),@SoPhieu varchar(20),@DS dbo.DanhSachTien READONLY
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
 IF ISNULL(LTRIM(RTRIM(@NguoiKy)),'')='' OR ISNULL(LTRIM(RTRIM(@NoiDung)),'')='' THROW 50014,N'Nhập nội dung và người ký quyết định.',1;
 IF (@MaNV IS NULL AND @MaPB IS NULL) OR (@MaNV IS NOT NULL AND @MaPB IS NOT NULL) THROW 50015,N'Chọn đúng một cá nhân hoặc phòng ban.',1;
 IF NOT EXISTS(SELECT 1 FROM @DS) OR EXISTS(SELECT 1 FROM @DS WHERE SoTien<=0) OR (SELECT SUM(SoTien) FROM @DS)<>@Tong THROW 50016,N'Tổng phân bổ phải bằng tiền quyết định và từng dòng phải dương.',1;
 IF EXISTS(SELECT 1 FROM @DS d LEFT JOIN NhanVien n ON d.MaNV=n.MaNV WHERE n.MaNV IS NULL OR (@MaNV IS NOT NULL AND d.MaNV<>@MaNV) OR (@MaPB IS NOT NULL AND n.MaPB<>@MaPB)) THROW 50017,N'Danh sách phân bổ sai đối tượng.',1;
 IF @Cach=N'Qua lương' AND EXISTS(SELECT 1 FROM BangLuong WITH(UPDLOCK,HOLDLOCK) WHERE Thang=MONTH(@Ngay) AND Nam=YEAR(@Ngay)) THROW 50010,N'Tháng đã lập bảng lương.',1;
 INSERT QuyetDinhKhenThuong VALUES(@SoQD,@Ngay,@MaNV,@MaPB,@NoiDung,@Tong,@NguoiKy,@Cach);
 INSERT ChiTietKhenThuong SELECT @SoQD,MaNV,SoTien FROM @DS;
 INSERT PhieuChi VALUES(@SoPhieu,@SoQD,@Ngay,@Tong); COMMIT; END;
GO

CREATE OR ALTER PROCEDURE dbo.LapKyLuat @SoQD varchar(20),@Ngay date,@MaNV varchar(20)=NULL,@MaPB varchar(20)=NULL,@NoiDung nvarchar(1000),@Tong decimal(18,0),@NguoiKy nvarchar(120),@Cach nvarchar(20),@SoPhieu varchar(20),@DS dbo.DanhSachTien READONLY
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON; BEGIN TRAN;
 IF ISNULL(LTRIM(RTRIM(@NguoiKy)),'')='' OR ISNULL(LTRIM(RTRIM(@NoiDung)),'')='' THROW 50014,N'Nhập nội dung và người ký quyết định.',1;
 IF (@MaNV IS NULL AND @MaPB IS NULL) OR (@MaNV IS NOT NULL AND @MaPB IS NOT NULL) THROW 50015,N'Chọn đúng một cá nhân hoặc phòng ban.',1;
 IF NOT EXISTS(SELECT 1 FROM @DS) OR EXISTS(SELECT 1 FROM @DS WHERE SoTien<=0) OR (SELECT SUM(SoTien) FROM @DS)<>@Tong THROW 50016,N'Tổng phân bổ phải bằng tiền quyết định và từng dòng phải dương.',1;
 IF EXISTS(SELECT 1 FROM @DS d LEFT JOIN NhanVien n ON d.MaNV=n.MaNV WHERE n.MaNV IS NULL OR (@MaNV IS NOT NULL AND d.MaNV<>@MaNV) OR (@MaPB IS NOT NULL AND n.MaPB<>@MaPB)) THROW 50017,N'Danh sách phân bổ sai đối tượng.',1;
 IF @Cach=N'Qua lương' AND EXISTS(SELECT 1 FROM BangLuong WITH(UPDLOCK,HOLDLOCK) WHERE Thang=MONTH(@Ngay) AND Nam=YEAR(@Ngay)) THROW 50010,N'Tháng đã lập bảng lương.',1;
 INSERT QuyetDinhKyLuat VALUES(@SoQD,@Ngay,@MaNV,@MaPB,@NoiDung,@Tong,@NguoiKy,@Cach);
 INSERT ChiTietKyLuat SELECT @SoQD,MaNV,SoTien FROM @DS;
 INSERT PhieuThu VALUES(@SoPhieu,@SoQD,@Ngay,@Tong); COMMIT; END;
GO

CREATE OR ALTER PROCEDURE dbo.LapBangLuong @MaBL varchar(20),@Thang int,@Nam int,@NgayLap date,@Cong decimal(5,2),@GioNgay decimal(5,2)
AS BEGIN SET NOCOUNT ON; SET XACT_ABORT ON; SET TRANSACTION ISOLATION LEVEL SERIALIZABLE; BEGIN TRAN;
 DECLARE @Dau date=DATEFROMPARTS(@Nam,@Thang,1),@Cuoi date=EOMONTH(DATEFROMPARTS(@Nam,@Thang,1));
 IF @Cong<=0 OR @GioNgay<=0 THROW 50018,N'Công chuẩn và giờ/ngày phải dương.',1;
 IF EXISTS(SELECT 1 FROM BangLuong WITH(UPDLOCK,HOLDLOCK) WHERE Thang=@Thang AND Nam=@Nam) THROW 50019,N'Đã lập bảng lương tháng này.',1;
 IF EXISTS(SELECT 1 FROM ChamCong c JOIN NhanVien n ON n.MaNV=c.MaNV WHERE c.Ngay BETWEEN @Dau AND @Cuoi AND EXISTS(SELECT 1 FROM HopDong h WHERE h.MaNV=n.MaNV AND h.TuNgay<=@Cuoi AND (h.DenNgay IS NULL OR h.DenNgay>=@Dau)) AND NOT EXISTS(SELECT 1 FROM QuyetDinhLuong q WHERE q.MaNV=n.MaNV AND q.NgayHieuLuc<=@Cuoi)) THROW 50020,N'Nhân viên chính thức có công nhưng chưa có quyết định lương.',1;
 INSERT BangLuong VALUES(@MaBL,@Thang,@Nam,@NgayLap,@Cong,@GioNgay);
 INSERT ChiTietBangLuong(MaBL,MaNV,GioCong,GioPhuTroi,LuongCoBan,PhuCap,TienCong,TienPhuTroi,BaoHiem,Thuong,Phat)
 SELECT @MaBL,n.MaNV,c.Gio,ISNULL(o.Gio,0),ISNULL(l.LuongCoBan,t.LuongThuViec),ISNULL(l.PhuCapLuong,0)+ISNULL(l.PhuCapDocHai,0)+ISNULL(v.PhuCap,0),
 ROUND((ISNULL(l.LuongCoBan,t.LuongThuViec)+ISNULL(l.PhuCapLuong,0)+ISNULL(l.PhuCapDocHai,0)+ISNULL(v.PhuCap,0))*c.Gio/(@Cong*@GioNgay),0),
 ROUND((ISNULL(l.LuongCoBan,t.LuongThuViec)+ISNULL(l.PhuCapLuong,0)+ISNULL(l.PhuCapDocHai,0)+ISNULL(v.PhuCap,0))*ISNULL(o.Gio,0)*1.5/(@Cong*@GioNgay),0),
 ROUND(ISNULL(b.MucDong*(b.TyLeYT+b.TyLeXH),0),0),ISNULL(kt.Tien,0),ISNULL(kl.Tien,0)
 FROM NhanVien n JOIN (SELECT MaNV,SUM(SoGio) Gio FROM ChamCong WHERE Ngay BETWEEN @Dau AND @Cuoi GROUP BY MaNV)c ON n.MaNV=c.MaNV
 JOIN QuyetDinhTuyenDung t ON n.MaNV=t.MaNV
 OUTER APPLY(SELECT TOP 1 * FROM QuyetDinhLuong WHERE MaNV=n.MaNV AND NgayHieuLuc<=@Cuoi ORDER BY NgayHieuLuc DESC)l
 OUTER APPLY(SELECT TOP 1 * FROM QuyetDinhChucVu WHERE MaNV=n.MaNV AND NgayHieuLuc<=@Cuoi ORDER BY NgayHieuLuc DESC)v
 OUTER APPLY(SELECT TOP 1 bh.* FROM BaoHiem bh JOIN HopDong h ON bh.SoHD=h.SoHD WHERE h.MaNV=n.MaNV AND h.TuNgay<=@Cuoi AND (h.DenNgay IS NULL OR h.DenNgay>=@Dau) ORDER BY h.TuNgay DESC)b
 OUTER APPLY(SELECT SUM(p.SoGio) Gio FROM ChiTietPhuTroi d JOIN PhieuPhuTroi p ON p.SoPhieu=d.SoPhieu WHERE d.MaNV=n.MaNV AND p.Ngay BETWEEN @Dau AND @Cuoi)o
 OUTER APPLY(SELECT SUM(d.SoTien) Tien FROM ChiTietKhenThuong d JOIN QuyetDinhKhenThuong q ON d.SoQD=q.SoQD WHERE d.MaNV=n.MaNV AND q.Ngay BETWEEN @Dau AND @Cuoi AND q.CachXuLy=N'Qua lương')kt
 OUTER APPLY(SELECT SUM(d.SoTien) Tien FROM ChiTietKyLuat d JOIN QuyetDinhKyLuat q ON d.SoQD=q.SoQD WHERE d.MaNV=n.MaNV AND q.Ngay BETWEEN @Dau AND @Cuoi AND q.CachXuLy=N'Qua lương')kl;
 IF @@ROWCOUNT=0 THROW 50021,N'Không có chấm công để lập bảng lương.',1;
 COMMIT; END;
GO
