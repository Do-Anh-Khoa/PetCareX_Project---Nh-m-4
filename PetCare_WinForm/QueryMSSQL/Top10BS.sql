USE PetCareX
GO
CREATE OR ALTER VIEW dbo.v_TopDoctorRevenue
AS
SELECT TOP 10
	   nv.MaNV AS MaBS, nv.HoTen, nv.ChucVu, nv.MaCN, TongDoanhThu
FROM NHAN_VIEN nv
LEFT JOIN (SELECT BacSiPhuTrach AS MaBS, SUM(GiaKhamBenh) AS DoanhThuKhamBenh 
		   FROM DV_KHAM 
		   GROUP BY BacSiPhuTrach) AS Kb ON MaNV = kb.MaBS

LEFT JOIN (SELECT BacSiPhuTrach AS MaBS, SUM(GiaGoi) AS DoanhThuTiemPhongThang
		   FROM DV_TIEM_PHONG_THEO_THANG
		   GROUP BY BacSiPhuTrach) AS Tpt ON MaNV = Tpt.MaBS

LEFT JOIN (SELECT BacSiPhuTrach AS MaBS, SUM(Gia) AS DoanhThuTiemPhongNgay
		   FROM DV_TIEM_PHONG_DON_LE dvtdl
		   JOIN CHI_TIET_TIEM ctt ON dvtdl.MaTiem = ctt.MaTiem
		   GROUP BY BacSiPhuTrach) AS Tpn ON MaNV = Tpn.MaBS
CROSS APPLY (
    SELECT ISNULL(DoanhThuKhamBenh, 0) + ISNULL(DoanhThuTiemPhongThang, 0) + ISNULL(DoanhThuTiemPhongNgay, 0) AS TongDoanhThu
) t
ORDER BY
  TongDoanhThu DESC;
GO