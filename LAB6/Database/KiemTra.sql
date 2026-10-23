USE QuanLyHoSoBenhAn;
GO
SELECT t.name AS Bang,COUNT(c.column_id) AS SoCot,
 (SELECT SUM(p.rows) FROM sys.partitions p WHERE p.object_id=t.object_id AND p.index_id IN(0,1)) AS SoDong
FROM sys.tables t JOIN sys.columns c ON c.object_id=t.object_id
GROUP BY t.object_id,t.name ORDER BY t.name;
SELECT fk.name AS KhoaNgoai,OBJECT_NAME(fk.parent_object_id) AS BangCon,
 COL_NAME(fc.parent_object_id,fc.parent_column_id) AS CotCon,
 OBJECT_NAME(fk.referenced_object_id) AS BangCha,COL_NAME(fc.referenced_object_id,fc.referenced_column_id) AS CotCha
FROM sys.foreign_keys fk JOIN sys.foreign_key_columns fc ON fc.constraint_object_id=fk.object_id
ORDER BY BangCon,fk.name,fc.constraint_column_id;
SELECT t.name AS Bang,i.name AS RangBuoc,i.is_primary_key AS PK,i.is_unique_constraint AS UQ,i.filter_definition AS DieuKien
FROM sys.indexes i JOIN sys.tables t ON t.object_id=i.object_id WHERE i.is_unique=1 ORDER BY t.name,i.name;
SELECT h.MaHoSo,b.HoTen,p.MaPhieuKham,p.LoaiKham,p.PhiKham,p.DaHoanTat,p.DaXuatVien,p.DaThanhToan
FROM HoSoBenhAn h JOIN BenhNhan b ON b.MaBenhNhan=h.MaBenhNhan JOIN PhieuKham p ON p.MaHoSo=h.MaHoSo;
SELECT t.MaToa,t.MaPhieuKham,t.MaBacSi,COUNT(c.SoThuTu) AS SoDongThuoc FROM ToaThuoc t LEFT JOIN ChiTietToaThuoc c ON c.MaToa=t.MaToa GROUP BY t.MaToa,t.MaPhieuKham,t.MaBacSi;
