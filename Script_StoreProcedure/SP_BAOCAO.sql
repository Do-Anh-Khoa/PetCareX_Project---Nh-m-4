USE [PetCareX_DB]
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetDoanhThu_TheoBacSi]
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Xử lý ngày null
    DECLARE @Start DATE = ISNULL(@TuNgay, '2000-01-01');
    DECLARE @End DATE = ISNULL(@DenNgay, GETDATE());

    SELECT 
        nv.MaNV,
        nv.HoTen AS TenBacSi,
        cn.TenChiNhanh,
        COUNT(DISTINCT dk.MaKham) AS SoLuotKham,
        ISNULL(SUM(hd.TongTien), 0) AS TongDoanhThu
    FROM NHAN_VIEN nv
    JOIN DV_KHAM dk ON nv.MaNV = dk.BacSiPhuTrach
    JOIN DICH_VU dv ON dk.MaKham = dv.MaDV
    JOIN CHI_NHANH cn ON dv.MaCN = cn.MaCN
    JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    WHERE 
        CAST(hd.NgayLap AS DATE) BETWEEN @Start AND @End
        AND (@MaCN IS NULL OR cn.MaCN = @MaCN)
    GROUP BY nv.MaNV, nv.HoTen, cn.TenChiNhanh
    ORDER BY TongDoanhThu DESC;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetDoanhThu_SanPham]
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Start DATE = ISNULL(@TuNgay, '2000-01-01');
    DECLARE @End DATE = ISNULL(@DenNgay, GETDATE());

    SELECT 
        sp.MaSP,
        sp.TenSP,
        sp.LoaiSP,
        SUM(ctmh.SoLuong) AS SoLuongBan,
        -- Giả sử giá bán nằm trong bảng SAN_PHAM hoặc tính từ HOA_DON. 
        -- Ở đây tạm tính tổng tiền hóa đơn của giao dịch mua hàng này
        SUM(hd.TongTien) AS DoanhThuUocTinh
    FROM SAN_PHAM sp
    JOIN CHI_TIET_MUA_HANG ctmh ON sp.MaSP = ctmh.MaSP
    JOIN DV_MUA_HANG dmh ON ctmh.MaMuaHang = dmh.MaMuaHang
    JOIN DICH_VU dv ON dmh.MaMuaHang = dv.MaDV -- Mua hàng cũng là 1 dịch vụ
    JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    WHERE 
        CAST(hd.NgayLap AS DATE) BETWEEN @Start AND @End
        AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
    GROUP BY sp.MaSP, sp.TenSP, sp.LoaiSP
    ORDER BY SoLuongBan DESC;
END
GO

-- Thống kê tổng số lượt khám từ ngày đến ngày
CREATE OR ALTER PROCEDURE [dbo].[sp_GetSoLuotKham]
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TuNgay_Thuc DATE;
    DECLARE @DenNgay_Thuc DATE;

    -- Lấy từ hóa đơn đầu tới hóa đơn cuối nếu người dùng để null ngày
    SELECT
        @TuNgay_Thuc = ISNULL(@TuNgay, MIN(CAST(hd.NgayLap AS DATE))),
        @DenNgay_Thuc = ISNULL(@DenNgay, MAX(CAST(hd.NgayLap AS DATE)))
    FROM HOA_DON hd;
    SELECT
        CAST(dv.MaCN AS VARCHAR(20)) AS MaChiNhanh,
        @TuNgay_Thuc AS TuNgay,
        @DenNgay_Thuc AS DenNgay,
        COUNT(dk.MaKham) AS TongSoLuotKham
    FROM DV_KHAM dk
    JOIN DICH_VU dv ON dk.MaKham = dv.MaDV
    JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    WHERE 
        CAST(hd.NgayLap AS DATE) BETWEEN @TuNgay_Thuc AND @DenNgay_Thuc
        AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
    GROUP BY CAST(dv.MaCN AS VARCHAR(20));
END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetDoanhThu_NangCao]
    @MaCN VARCHAR(20) = NULL, -- NULL = Lấy tất cả chi nhánh
    @TuNgay DATE = NULL,      -- NULL = Từ ngày đầu tiên
    @DenNgay DATE = NULL      -- NULL = Đến hiện tại
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Chuẩn bị biến để hiển thị ra cột (Xử lý trường hợp NULL)
    DECLARE @HienThiTuNgay DATE;
    DECLARE @HienThiDenNgay DATE;

    -- Nếu @TuNgay là NULL, lấy ngày của hóa đơn đầu tiên trong hệ thống
    IF @TuNgay IS NULL
        SELECT @HienThiTuNgay = MIN(CAST(NgayLap AS DATE)) FROM HOA_DON;
    ELSE
        SET @HienThiTuNgay = @TuNgay;

    -- Nếu @DenNgay là NULL, lấy ngày hiện tại
    IF @DenNgay IS NULL
        SET @HienThiDenNgay = CAST(GETDATE() AS DATE);
    ELSE
        SET @HienThiDenNgay = @DenNgay;

    -- 2. Thực hiện truy vấn
    SELECT 
        cn.MaCN,
        cn.TenChiNhanh,
        
        -- Cột mới: Hiển thị khoảng thời gian báo cáo cho người đọc biết
        @HienThiTuNgay AS NgayBatDau,
        @HienThiDenNgay AS NgayKetThuc,

        -- Số liệu thống kê
        COUNT(hd.MaHD) AS SoLuongHoaDon, 
        ISNULL(SUM(hd.TongTien), 0) AS TongDoanhThu
    FROM CHI_NHANH cn
    LEFT JOIN HOA_DON hd ON cn.MaCN = hd.MaCN
    WHERE 
        -- Lọc Chi Nhánh
        (@MaCN IS NULL OR cn.MaCN = @MaCN)
        
        -- Lọc Ngày (Sử dụng tham số gốc để lọc đúng logic)
        AND (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
    GROUP BY cn.MaCN, cn.TenChiNhanh
    ORDER BY TongDoanhThu DESC;
END