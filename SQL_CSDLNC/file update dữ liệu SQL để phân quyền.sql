USE data10; -- ??m b?o b?n ?ang ch?n ?úng Database
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

PRINT '>>> B?T ??U QUÁ TRÌNH C?P NH?T ??NG B? USERNAME...';

BEGIN TRANSACTION; -- B?t ??u giao d?ch t?ng

BEGIN TRY
    -- =======================================================
    -- PH?N 1: C?P NH?T NHÂN VIÊN (NHAN_VIEN & TAI_KHOAN)
    -- =======================================================
    PRINT '--- ?ang x? lý: Nhân Viên ---';

    -- 1.1. T?m t?t khóa ngo?i Nhân Viên
    ALTER TABLE NHAN_VIEN NOCHECK CONSTRAINT ALL;

    -- 1.2. T?o b?ng t?m tính toán User m?i cho Nhân Viên
    IF OBJECT_ID('tempdb..#MapNhanVien') IS NOT NULL DROP TABLE #MapNhanVien;

    SELECT 
        MaNV, 
        UserName AS OldUser,
        CASE 
            WHEN ChucVu = 'BanHang' THEN MaNV                    -- Bán hàng: Gi? nguyên (VD: NV19)
            WHEN ChucVu = 'BacSi' THEN REPLACE(MaNV, 'NV', 'BS') -- Bác s?: NV.. -> BS..
            WHEN ChucVu = 'QuanLy' THEN REPLACE(MaNV, 'NV', 'QL')-- Qu?n lý: NV.. -> QL..
            ELSE UserName 
        END AS NewUser
    INTO #MapNhanVien
    FROM NHAN_VIEN;

    -- 1.3. Update TAI_KHOAN (D?a trên User c? c?a NV)
    UPDATE T
    SET T.UserName = M.NewUser
    FROM TAI_KHOAN T
    INNER JOIN #MapNhanVien M ON T.UserName = M.OldUser
    WHERE M.NewUser <> M.OldUser;

    -- 1.4. Update NHAN_VIEN
    UPDATE N
    SET N.UserName = M.NewUser
    FROM NHAN_VIEN N
    INNER JOIN #MapNhanVien M ON N.MaNV = M.MaNV
    WHERE M.NewUser <> M.OldUser;

    -- 1.5. B?t l?i khóa ngo?i Nhân Viên
    ALTER TABLE NHAN_VIEN CHECK CONSTRAINT ALL;
    DROP TABLE #MapNhanVien;

    -- =======================================================
    -- PH?N 2: C?P NH?T KHÁCH HÀNG (KHACH_HANG & TAI_KHOAN)
    -- =======================================================
    PRINT '--- ?ang x? lý: Khách Hàng ---';

    -- 2.1. T?m t?t khóa ngo?i Khách Hàng
    ALTER TABLE KHACH_HANG NOCHECK CONSTRAINT ALL;

    -- 2.2. T?o b?ng t?m tính toán User m?i cho Khách Hàng
    IF OBJECT_ID('tempdb..#MapKhachHang') IS NOT NULL DROP TABLE #MapKhachHang;

    SELECT 
        MaKH, 
        UserName AS OldUser,
        CASE 
            WHEN MaKH LIKE 'KH%' THEN MaKH        -- ?ã có KH thì gi? nguyên
            ELSE 'KH' + CAST(MaKH AS VARCHAR(20)) -- Ch?a có thì thêm KH
        END AS NewUser
    INTO #MapKhachHang
    FROM KHACH_HANG
    WHERE UserName IS NOT NULL; 

    -- 2.3. Update TAI_KHOAN (D?a trên User c? c?a KH)
    UPDATE T
    SET T.UserName = M.NewUser
    FROM TAI_KHOAN T
    INNER JOIN #MapKhachHang M ON T.UserName = M.OldUser
    WHERE M.NewUser <> M.OldUser;

    -- 2.4. Update KHACH_HANG
    UPDATE K
    SET K.UserName = M.NewUser
    FROM KHACH_HANG K
    INNER JOIN #MapKhachHang M ON K.MaKH = M.MaKH
    WHERE M.NewUser <> M.OldUser;

    -- 2.5. B?t l?i khóa ngo?i Khách Hàng
    ALTER TABLE KHACH_HANG CHECK CONSTRAINT ALL;
    DROP TABLE #MapKhachHang;

    -- =======================================================
    -- K?T THÚC
    -- =======================================================
    COMMIT TRANSACTION;
    PRINT '>>> [THÀNH CÔNG] ?ã c?p nh?t xong toàn b? h? th?ng!';

END TRY
BEGIN CATCH
    -- N?u có l?i b?t k? ?âu, hoàn tác T?T C?
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    
    -- ??m b?o khóa ngo?i luôn ???c b?t l?i dù có l?i
    ALTER TABLE NHAN_VIEN CHECK CONSTRAINT ALL;
    ALTER TABLE KHACH_HANG CHECK CONSTRAINT ALL;

    PRINT '>>> [L?I X?Y RA] ' + ERROR_MESSAGE();
END CATCH;
GO

-- Ki?m tra k?t qu?
PRINT '--- K?t qu? Nhân Viên ---';
SELECT MaNV, HoTen, ChucVu, UserName FROM NHAN_VIEN ORDER BY ChucVu;

PRINT '--- K?t qu? Khách Hàng (M?u) ---';
SELECT TOP 10 MaKH, HoTen, UserName FROM KHACH_HANG;

PRINT '--- Ki?m tra Tài Kho?n ---';
SELECT * FROM TAI_KHOAN;