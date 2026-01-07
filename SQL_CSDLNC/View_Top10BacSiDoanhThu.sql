USE [data10]
GO

/****** Object:  View [dbo].[Top10BacSiDoanhThu]    Script Date: 2026-01-07 7:59:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[Top10BacSiDoanhThu] AS
SELECT TOP 10 
    nv.MaNV AS MaBs,
    nv.HoTen,
    CAST(ISNULL(SUM(hd.TongTien), 0) AS DECIMAL(18,0)) AS TongDoanhThu
FROM NHAN_VIEN nv
LEFT JOIN HOA_DON hd ON nv.MaNV = hd.MaNV
WHERE nv.ChucVu LIKE N'%Bác s?%' 
GROUP BY nv.MaNV, nv.HoTen
ORDER BY TongDoanhThu DESC;
GO


