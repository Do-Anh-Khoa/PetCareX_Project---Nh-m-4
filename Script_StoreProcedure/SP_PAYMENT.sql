USE PetCareX_DB
GO

-- Stored Procedure 1: Tìm kiếm hóa đơn chưa thanh toán
CREATE PROCEDURE sp_TimKiemHoaDonChuaThanhToan
    @CustomerSearch NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT TOP 50
        h.MaHD,
        h.NgayLap,
        h.TrangThai,
        h.TongTien,
        h.KhuyenMai,
        h.HinhThucThanhToan,
        h.MaKH,
        h.MaNV,
        h.MaCN
    FROM HOA_DON h
    INNER JOIN KHACH_HANG kh ON h.MaKH = kh.MaKH
    WHERE h.TrangThai = 'ChuaThanhToan'
        AND (kh.SoDT LIKE '%' + @CustomerSearch + '%' 
             OR kh.HoTen LIKE '%' + @CustomerSearch + '%')
    ORDER BY h.NgayLap DESC;
END
GO

-- Stored Procedure 2: Lấy thông tin khách hàng
CREATE PROCEDURE sp_LayThongTinKhachHang
    @MaKH VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        MaKH,
        HoTen,
        SoDT,
        CapHoiVien
    FROM KHACH_HANG
    WHERE MaKH = @MaKH;
END
GO

-- Stored Procedure 3: Lấy thông tin nhân viên
CREATE PROCEDURE sp_LayThongTinNhanVien
    @MaNV VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        MaNV,
        HoTen
    FROM NHAN_VIEN
    WHERE MaNV = @MaNV;
END
GO

-- Stored Procedure 4: Lấy thông tin chi nhánh
CREATE PROCEDURE sp_LayThongTinChiNhanh
    @MaCN VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        MaCN,
        TenChiNhanh
    FROM CHI_NHANH
    WHERE MaCN = @MaCN;
END
GO

-- Stored Procedure 5: Lấy danh sách sản phẩm theo hóa đơn
CREATE PROCEDURE sp_LayDanhSachSanPhamTheoHoaDon
    @MaHD VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        sp.TenSP,
        ctmh.SoLuong,
        ctmh.DonGia,
        (ctmh.SoLuong * ctmh.DonGia) AS ThanhTien
    FROM CHI_TIET_DV_SD ctdv
    INNER JOIN CHI_TIET_MUA_HANG ctmh ON ctdv.MaDV = ctmh.MaMuaHang
    INNER JOIN SAN_PHAM sp ON ctmh.MaSP = sp.MaSP
    WHERE ctdv.MaHD = @MaHD;
END
GO

-- Stored Procedure 6: Cập nhật trạng thái thanh toán
CREATE PROCEDURE sp_CapNhatTrangThaiThanhToan
    @MaHD VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE HOA_DON
        SET TrangThai = 'DaThanhToan'
        WHERE MaHD = @MaHD;
        
        IF @@ROWCOUNT = 0
        BEGIN
            ROLLBACK TRANSACTION;
            SELECT 0 AS Result, N'Không tìm thấy hóa đơn' AS Message;
            RETURN;
        END
        
        COMMIT TRANSACTION;
        SELECT 1 AS Result, N'Thanh toán thành công' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        SELECT 0 AS Result, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO

-- Stored Procedure 7: Lấy chi tiết hóa đơn đầy đủ (tối ưu)
CREATE PROCEDURE sp_LayChiTietHoaDonDayDu
    @MaHD VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Thông tin hóa đơn và liên kết
    SELECT 
        h.MaHD,
        h.NgayLap,
        h.TrangThai,
        h.TongTien,
        h.KhuyenMai,
        h.HinhThucThanhToan,
        kh.HoTen AS TenKH,
        kh.SoDT,
        kh.CapHoiVien,
        nv.HoTen AS TenNV,
        cn.TenChiNhanh AS TenCN
    FROM HOA_DON h
    LEFT JOIN KHACH_HANG kh ON h.MaKH = kh.MaKH
    LEFT JOIN NHAN_VIEN nv ON h.MaNV = nv.MaNV
    LEFT JOIN CHI_NHANH cn ON h.MaCN = cn.MaCN
    WHERE h.MaHD = @MaHD;
    
    -- Danh sách sản phẩm
    SELECT 
        sp.TenSP,
        ctmh.SoLuong,
        ctmh.DonGia,
        (ctmh.SoLuong * ctmh.DonGia) AS ThanhTien
    FROM CHI_TIET_DV_SD ctdv
    INNER JOIN CHI_TIET_MUA_HANG ctmh ON ctdv.MaDV = ctmh.MaMuaHang
    INNER JOIN SAN_PHAM sp ON ctmh.MaSP = sp.MaSP
    WHERE ctdv.MaHD = @MaHD;
END
GO