USE PetCareX_DB
GO

-- 1. Load Chi Nhánh
--DROP PROCEDURE sp_LoadChiNhanh
--GO
CREATE PROCEDURE sp_LoadChiNhanh
AS
BEGIN
    SELECT MaCN, TenChiNhanh, DiaChi, SoDienThoai, GioMoCua, GioDongCua
    FROM CHI_NHANH 
    ORDER BY MaCN
END
GO

-- 2. Load Sản Phẩm theo Chi Nhánh với Tồn Kho
--DROP PROCEDURE sp_LoadProductsByChiNhanh
--GO
CREATE PROCEDURE sp_LoadProductsByChiNhanh
    @MaCN VARCHAR(20)
AS
BEGIN
    SELECT 
        sp.MaSP,
        sp.TenSP,
        ISNULL(sp.GiaBan, 0) AS GiaBan,
        sp.LoaiSP,
        ISNULL(SUM(tk.SoLuong), 0) AS TonKho,
        @MaCN AS MaCN
    FROM SAN_PHAM sp
    LEFT JOIN TON_KHO_SAN_PHAM tk ON sp.MaSP = tk.MaSP AND tk.MaCN = @MaCN
    GROUP BY sp.MaSP, sp.TenSP, sp.GiaBan, sp.LoaiSP
    HAVING ISNULL(SUM(tk.SoLuong), 0) > 0
    ORDER BY sp.TenSP
END
GO

-- 3. Tìm Nhân Viên theo Mã hoặc Tên và Chi Nhánh
--DROP PROCEDURE sp_SearchEmployee
--GO
CREATE PROCEDURE sp_SearchEmployee
    @SearchText NVARCHAR(100),
    @MaCN VARCHAR(20)
AS
BEGIN
    SELECT 
        nv.MaNV,
        nv.HoTen,
        nv.MaCN,
        cn.TenChiNhanh
    FROM NHAN_VIEN nv
    LEFT JOIN CHI_NHANH cn ON nv.MaCN = cn.MaCN
    WHERE (nv.MaNV = @SearchText OR nv.HoTen LIKE '%' + @SearchText + '%')
    AND nv.MaCN = @MaCN
END
GO

-- 4. Tìm Khách Hàng theo SĐT hoặc Tên
--DROP PROCEDURE sp_SearchCustomer
--GO
CREATE PROCEDURE sp_SearchCustomer
    @SearchText NVARCHAR(100)
AS
BEGIN
    SELECT 
        MaKH,
        HoTen,
        SoDT,
        Email,
        GioiTinh,
        CapHoiVien,
        ISNULL(DiemTichLuy, 0) AS DiemTichLuy
    FROM KHACH_HANG
    WHERE SoDT = @SearchText OR HoTen LIKE '%' + @SearchText + '%'
END
GO

-- 5. Tạo Khách Hàng Mới
--DROP PROCEDURE sp_CreateCustomer
CREATE PROCEDURE sp_CreateCustomer
    @MaKH VARCHAR(20),
    @HoTen NVARCHAR(100),
    @SoDT NVARCHAR(100),
    @Email NVARCHAR(100),
    @GioiTinh NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        INSERT INTO KHACH_HANG (MaKH, HoTen, SoDT, Email, GioiTinh, CapHoiVien, DiemTichLuy)
        VALUES (@MaKH, @HoTen, @SoDT, @Email, @GioiTinh, 'CoBan', 0)
        
        SELECT 
            MaKH,
            HoTen,
            SoDT,
            Email,
            GioiTinh,
            CapHoiVien,
            DiemTichLuy
        FROM KHACH_HANG
        WHERE MaKH = @MaKH
    END TRY
    BEGIN CATCH
        THROW
    END CATCH
END
GO

-- 6. Kiểm tra Tồn Kho Sản Phẩm
--DROP PROCEDURE sp_CheckProductStock
CREATE PROCEDURE sp_CheckProductStock
    @MaSP VARCHAR(20),
    @MaCN VARCHAR(20)
AS
BEGIN
    SELECT 
        ISNULL(SUM(SoLuong), 0) AS TonKho
    FROM TON_KHO_SAN_PHAM
    WHERE MaSP = @MaSP AND MaCN = @MaCN
END
GO

-- 7. Tạo Hóa Đơn (Transaction)
--DROP PROCEDURE sp_CreateInvoice
CREATE PROCEDURE dbo.sp_CreateInvoice
(
    @MaHD VARCHAR(20),
    @NgayLap DATE,
    @TongTien DECIMAL(18,0),
    @KhuyenMai NVARCHAR(100),
    @HinhThucThanhToan NVARCHAR(100),
    @MaNV VARCHAR(20),
    @MaKH VARCHAR(20),
    @MaCN VARCHAR(20),
    @MaMuaHang VARCHAR(20),
    @InvoiceDetails NVARCHAR(MAX)   -- JSON
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        
        IF @@TRANCOUNT = 0 
            BEGIN TRAN
        ELSE 
            SAVE TRAN sp_SavePoint   -- nếu lỡ gọi lồng nhau

        ----------------------------------------------------
        -- 1. Tạo hóa đơn
        ----------------------------------------------------
        INSERT INTO dbo.HOA_DON (MaHD, NgayLap, TongTien, KhuyenMai, HinhThucThanhToan, TrangThai, MaNV, MaKH, MaCN)
        VALUES (@MaHD, @NgayLap, @TongTien, @KhuyenMai, @HinhThucThanhToan, N'ChuaThanhToan', @MaNV, @MaKH, @MaCN);

        ----------------------------------------------------
        -- 2. Tạo dịch vụ
        ----------------------------------------------------
        INSERT INTO dbo.DICH_VU (MaDV, MaTC, MaCN)
        VALUES (@MaMuaHang, NULL, @MaCN);

        ----------------------------------------------------
        -- 3. Tạo dịch vụ mua hàng
        ----------------------------------------------------
        INSERT INTO dbo.DV_MUA_HANG (MaMuaHang, NhanVienBanHang)
        VALUES (@MaMuaHang, @MaNV);

        ----------------------------------------------------
        -- 4. Liên kết hóa đơn – dịch vụ
        ----------------------------------------------------
        INSERT INTO dbo.CHI_TIET_DV_SD (MaHD, MaDV)
        VALUES (@MaHD, @MaMuaHang);

        ----------------------------------------------------
        -- 5. Thêm chi tiết mua hàng từ JSON
        ----------------------------------------------------
        INSERT INTO dbo.CHI_TIET_MUA_HANG (MaMuaHang, MaSP, SoLuong, DonGia)
        SELECT 
            @MaMuaHang,
            JSON_VALUE(value, '$.MaSP'),
            CAST(JSON_VALUE(value, '$.SoLuong') AS INT),
            CAST(JSON_VALUE(value, '$.DonGia') AS DECIMAL(18,0))
        FROM OPENJSON(@InvoiceDetails);

        ----------------------------------------------------
        -- 6. Trừ tồn kho
        ----------------------------------------------------
        UPDATE tk
        SET tk.SoLuong = tk.SoLuong - d.SoLuong
        FROM dbo.TON_KHO_SAN_PHAM tk
        INNER JOIN (
            SELECT 
                JSON_VALUE(value, '$.MaSP') AS MaSP,
                CAST(JSON_VALUE(value, '$.SoLuong') AS INT) AS SoLuong
            FROM OPENJSON(@InvoiceDetails)
        ) d ON tk.MaSP = d.MaSP
        WHERE tk.MaCN = @MaCN;

        ----------------------------------------------------
        -- 7. Không cho âm kho
        ----------------------------------------------------
        IF EXISTS (
            SELECT 1 
            FROM dbo.TON_KHO_SAN_PHAM 
            WHERE MaCN = @MaCN AND SoLuong < 0
        )
        BEGIN
            THROW 50001, N'Không đủ tồn kho cho một số sản phẩm', 1;
        END

        ----------------------------------------------------
        -- 8. Commit an toàn
        ----------------------------------------------------
        IF @@TRANCOUNT > 0
            COMMIT;

        SELECT 'SUCCESS' AS Status, @MaHD AS MaHD;
    END TRY

    BEGIN CATCH
        
        IF @@TRANCOUNT > 0
            ROLLBACK;

        THROW;
    END CATCH
END
GO


-- 8. Thanh Toán Hóa Đơn
--DROP PROCEDURE sp_PayInvoice
CREATE PROCEDURE sp_PayInvoice
    @MaHD VARCHAR(20),
    @MaKH VARCHAR(20) = NULL
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Kiểm tra hóa đơn tồn tại
        DECLARE @TongTien DECIMAL(18,0)
        DECLARE @TrangThai NVARCHAR(100)
        
        SELECT @TongTien = TongTien, @TrangThai = TrangThai
        FROM HOA_DON
        WHERE MaHD = @MaHD

        IF @TongTien IS NULL
        BEGIN
            THROW 50002, N'Không tìm thấy hóa đơn', 1
        END

        IF @TrangThai = N'DaThanhToan'
        BEGIN
            THROW 50003, N'Hóa đơn đã được thanh toán', 1
        END

        -- Cập nhật trạng thái hóa đơn
        UPDATE HOA_DON
        SET TrangThai = N'DaThanhToan'
        WHERE MaHD = @MaHD

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW
    END CATCH
END
GO

-- 9. Lấy thông tin Chi Nhánh theo Mã
--DROP PROCEDURE sp_GetChiNhanhByMa
CREATE PROCEDURE sp_GetChiNhanhByMa
    @MaCN VARCHAR(20)
AS
BEGIN
    SELECT MaCN, TenChiNhanh, DiaChi, SoDienThoai
    FROM CHI_NHANH
    WHERE MaCN = @MaCN
END
GO

-- 10. Lấy thông tin Khách Hàng theo Mã
--DROP PROCEDURE sp_GetCustomerByMa
CREATE PROCEDURE sp_GetCustomerByMa
    @MaKH VARCHAR(20)
AS
BEGIN
    SELECT 
        MaKH,
        HoTen,
        SoDT,
        Email,
        GioiTinh,
        CapHoiVien,
        ISNULL(DiemTichLuy, 0) AS DiemTichLuy
    FROM KHACH_HANG
    WHERE MaKH = @MaKH
END
GO