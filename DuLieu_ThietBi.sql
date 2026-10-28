

CREATE DATABASE DuLieu_ThietBi;
GO

USE DuLieu_ThietBi;
GO

IF OBJECT_ID('dbo.ThietBi', 'U') IS NOT NULL
    DROP TABLE dbo.ThietBi;
GO

CREATE TABLE ThietBi (
    MaThietBi NVARCHAR(10) NOT NULL PRIMARY KEY,
    TenThietBi NTEXT NOT NULL,
    DonGia NVARCHAR(12) NOT NULL
);
GO


INSERT INTO ThietBi (MaThietBi, TenThietBi, DonGia) VALUES
('TB01', N'Máy tính xách tay Dell', '15000000'),
('TB02', N'Máy in HP LaserJet', '5500000'),
('TB03', N'Màn hình Samsung', '3800000'),
('TB04', N'Bàn phím cơ logitech', '1200000'),
('TB05', N'Chuột không dây', '450000');
GO
