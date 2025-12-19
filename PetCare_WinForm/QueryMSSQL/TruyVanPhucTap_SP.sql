USE PetCareX_DB;
GO

-- =============================================
-- 1. Thống kê tổng doanh thu (Danh sách hóa đơn chi tiết)
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuPhongKham
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20) = NULL,
    @TuKhoa NVARCHAR(100) = NULL, -- Tìm theo tên KH hoặc Mã HĐ
    @SortOption INT = 0 -- 0: Mới nhất, 1: Cũ nhất, 2: Giá cao
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        hd.MaHD,
        hd.NgayLap,
        hd.TongTien,
        hd.HinhThucThanhToan,
        kh.HoTen AS TenKhachHang,
        nv.HoTen AS NhanVienTao,
        cn.TenChiNhanh
    FROM HOA_DON hd
    JOIN KHACH_HANG kh ON hd.MaKH = kh.MaKH
    JOIN NHAN_VIEN nv ON hd.MaNV = nv.MaNV
    JOIN CHI_NHANH cn ON hd.MaCN = cn.MaCN
    WHERE 
        (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
        AND (@MaCN IS NULL OR hd.MaCN = @MaCN)
        AND (@TuKhoa IS NULL OR kh.HoTen LIKE N'%' + @TuKhoa + '%' OR hd.MaHD LIKE N'%' + @TuKhoa + '%')
    ORDER BY 
        CASE WHEN @SortOption = 0 THEN hd.NgayLap END DESC,
        CASE WHEN @SortOption = 1 THEN hd.NgayLap END ASC,
        CASE WHEN @SortOption = 2 THEN hd.TongTien END DESC;
END
GO

EXEC sp_ThongKe_DoanhThuPhongKham
    @TuNgay = null,
    @DenNgay = null,
    @MaCN = 'CN1',
    @TuKhoa = N'',
    @SortOption = 0;

GO
-- =============================================
-- 2. Thống kê doanh thu theo Bác Sĩ
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuTheoBacSi
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- CTE lấy doanh thu từ Khám bệnh
    WITH DoanhThuKham AS (
        SELECT dk.BacSiPhuTrach AS MaNV, SUM(ISNULL(dk.GiaKhamBenh, 0)) AS TienKham
        FROM DV_KHAM dk
        JOIN DICH_VU dv ON dk.MaKham = dv.MaDV
        JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
        JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
        WHERE 
            (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
            AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
            AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
        GROUP BY dk.BacSiPhuTrach
    ),

    -- CTE lấy doanh thu từ Tiêm phòng đơn lẻ (Tính tổng giá vaccine tiêm)
    DoanhThuTiemLe AS (
        SELECT tp.BacSiPhuTrach AS MaNV, SUM(ISNULL(ctt.Gia, 0)) AS TienTiem
        FROM DV_TIEM_PHONG_DON_LE tp
        JOIN CHI_TIET_TIEM ctt ON tp.MaTiem = ctt.MaTiem
        JOIN DICH_VU dv ON tp.MaTiem = dv.MaDV
        JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
        JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
        WHERE 
            (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
            AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
            AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
        GROUP BY tp.BacSiPhuTrach
    )
    
    -- Tổng hợp kết quả
    SELECT 
        nv.MaNV,
        nv.HoTen AS TenBacSi,
        ISNULL(k.TienKham, 0) + ISNULL(t.TienTiem, 0) AS TongDoanhThu
    FROM NHAN_VIEN nv
    LEFT JOIN DoanhThuKham k ON nv.MaNV = k.MaNV
    LEFT JOIN DoanhThuTiemLe t ON nv.MaNV = t.MaNV
    WHERE nv.ChucVu LIKE 'BacSi'
          AND (ISNULL(k.TienKham, 0) + ISNULL(t.TienTiem, 0)) > 0 -- Chỉ hiện BS có doanh thu
    ORDER BY TongDoanhThu DESC;
END
GO

EXEC sp_ThongKe_DoanhThuTheoBacSi
    @TuNgay = NULL,
    @DenNgay = NULL,
	@MaCN = 'CN1'

GO
-- =============================================
-- 3. Thống kê số lượt khám bệnh
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_SoLuotKham
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
	
	IF @MaCN IS NULL
	BEGIN
		;THROW 50001, N'Mã chi nhánh không được rỗng', 1;
	END
    SELECT 
        CAST(hd.NgayLap AS DATE) AS Ngay,
        COUNT(dk.MaKham) AS SoLuotKham
    FROM DV_KHAM dk
    JOIN DICH_VU dv ON dk.MaKham = dv.MaDV
    JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    WHERE 
        (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
        AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
    GROUP BY CAST(hd.NgayLap AS DATE)
    ORDER BY Ngay ASC;
END
GO

EXEC sp_ThongKe_SoLuotKham
    @TuNgay = NULL,
    @DenNgay = NULL,
	@MaCN = 'CN1'

GO
-- =============================================
-- 4. Thống kê doanh thu theo Sản Phẩm
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuSanPham
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 20 -- Lấy top 20 sản phẩm
        sp.MaSP,
        sp.TenSP,
        sp.LoaiSP,
        SUM(ctmh.SoLuong) AS SoLuongBan,
        SUM(ctmh.SoLuong * ctmh.DonGia) AS DoanhThu
    FROM CHI_TIET_MUA_HANG ctmh
    JOIN SAN_PHAM sp ON ctmh.MaSP = sp.MaSP
    JOIN DV_MUA_HANG dvmh ON ctmh.MaMuaHang = dvmh.MaMuaHang
    JOIN DICH_VU dv ON dvmh.MaMuaHang = dv.MaDV
    JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    WHERE 
        (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
        AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
    GROUP BY sp.MaSP, sp.TenSP, sp.LoaiSP
    ORDER BY DoanhThu DESC;
END
GO

EXEC sp_ThongKe_DoanhThuSanPham
    @TuNgay = NULL,
    @DenNgay = NULL,
	@MaCN = 'CN1'
GO
-- =============================================
-- 5. Thống kê doanh thu tất cả chi nhánh
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuTatCaChiNhanh
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        cn.MaCN,
        cn.TenChiNhanh,
        COUNT(hd.MaHD) AS SoLuongHoaDon,
        SUM(ISNULL(hd.TongTien, 0)) AS TongDoanhThu
    FROM CHI_NHANH cn
    LEFT JOIN HOA_DON hd ON cn.MaCN = hd.MaCN 
        AND (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
    GROUP BY cn.MaCN, cn.TenChiNhanh
    ORDER BY TongDoanhThu DESC;
END
GO

EXEC sp_ThongKe_DoanhThuTatCaChiNhanh
    @TuNgay = NULL,
    @DenNgay = NULL

GO
-- =============================================
-- 6. Thống kê lượt khám theo chi nhánh
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_LuotKhamTheoChiNhanh
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        cn.MaCN,
        cn.TenChiNhanh,
        COUNT(dk.MaKham) AS SoLuotKham
    FROM CHI_NHANH cn
    LEFT JOIN DICH_VU dv ON cn.MaCN = dv.MaCN
    LEFT JOIN DV_KHAM dk ON dv.MaDV = dk.MaKham
    LEFT JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    LEFT JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    WHERE 
        (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
    GROUP BY cn.MaCN, cn.TenChiNhanh
    ORDER BY SoLuotKham DESC;
END
GO

EXEC sp_ThongKe_LuotKhamTheoChiNhanh
    @TuNgay = '2000-12-01',
    @DenNgay = '2025-12-31'
