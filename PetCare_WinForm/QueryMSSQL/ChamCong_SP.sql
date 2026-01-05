USE PetCareX_DB;
GO

-- =============================================
-- 1. CHECK-IN
-- Logic: 
-- - Lấy ngày giờ hiện tại của Server.
-- - Nếu đã Check-in hôm nay rồi thì báo lỗi (để không bị ghi đè giờ cũ)
-- =============================================
CREATE OR ALTER PROCEDURE sp_ChamCong_CheckIn
    @MaNV VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @NgayHienTai DATE = CAST(GETDATE() AS DATE);
    DECLARE @GioHienTai TIME = CAST(GETDATE() AS TIME);

    -- Kiểm tra nhân viên tồn tại
    IF NOT EXISTS (SELECT 1 FROM NHAN_VIEN WHERE MaNV = @MaNV)
    BEGIN
        ;THROW 52001, N'Lỗi: Mã nhân viên không tồn tại.', 1;
        RETURN;
    END

    -- Kiểm tra xem hôm nay đã Check-in chưa
    IF EXISTS (SELECT 1 FROM CHAM_CONG WHERE MaNV = @MaNV AND NgayLamViec = @NgayHienTai)
    BEGIN
        ;THROW 52002, N'Bạn đã Check-in ngày hôm nay rồi.', 1;
        RETURN;
    END

    -- Thực hiện Check-in
    INSERT INTO CHAM_CONG (MaNV, NgayLamViec, Checkin, Checkout)
    VALUES (@MaNV, @NgayHienTai, @GioHienTai, NULL);
    
    SELECT N'Check-in thành công lúc ' + CAST(@GioHienTai AS NVARCHAR(20)) AS ThongBao;
END
GO

-- =============================================
-- 2. CHECK-OUT
-- Logic: 
-- - Phải có dữ liệu Check-in hôm nay thì mới được Check-out
-- - Update giờ Check-out vào dòng dữ liệu của ngày hôm nay
-- =============================================
CREATE OR ALTER PROCEDURE sp_ChamCong_CheckOut
    @MaNV VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NgayHienTai DATE = CAST(GETDATE() AS DATE);
    DECLARE @GioHienTai TIME = CAST(GETDATE() AS TIME);

    -- 1. Kiểm tra xem đã Check-in hôm nay chưa
    IF NOT EXISTS (SELECT 1 FROM CHAM_CONG WHERE MaNV = @MaNV AND NgayLamViec = @NgayHienTai)
    BEGIN
        ;THROW 52003, N'Bạn chưa Check-in, không thể Check-out.', 1;
        RETURN;
    END
	
	-- 2. Kiểm tra Check-out đã tồn tại chưa
	IF EXISTS (SELECT 1 FROM CHAM_CONG WHERE MaNV = @MaNV AND NgayLamViec = @NgayHienTai AND (Checkout IS NOT NULL))
    BEGIN
        ;THROW 52002, N'Bạn đã Check-OUT ngày hôm nay rồi.', 1;
        RETURN;
    END

    -- 3. Thực hiện Check-out (Update dòng cũ)
    UPDATE CHAM_CONG
    SET Checkout = @GioHienTai
    WHERE MaNV = @MaNV AND NgayLamViec = @NgayHienTai;

    SELECT N'Check-out thành công lúc ' + CAST(@GioHienTai AS NVARCHAR(20)) AS ThongBao;
END
GO

-- Kiểm tra trạng thái chấm công
CREATE OR ALTER PROCEDURE sp_ChamCong_LayTrangThai
    @MaNV VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NgayHienTai DATE = CAST(GETDATE() AS DATE);

    SELECT 
        MaNV,
        NgayLamViec,
        Checkin,
        Checkout,
        CASE 
            WHEN Checkin IS NULL THEN N'Chưa vào làm'
            WHEN Checkout IS NULL THEN N'Đang làm việc'
            ELSE N'Đã ra về'
        END AS TrangThai
    FROM CHAM_CONG
    WHERE MaNV = @MaNV AND NgayLamViec = @NgayHienTai;
END
GO

-------
------ Xóa các record chấm công trong ngày để test CHECK-IN và CHECK-OUT
-- DELETE FROM CHAM_CONG
-- WHERE CAST(NgayLamViec AS DATE) = CAST(GETDATE() AS DATE)
-----
-------

GO
-- Xem lịch sử chấm công trong 30 ngày gần nhất
CREATE OR ALTER PROCEDURE sp_ChamCong_XemLichSu
    @MaNV VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 31
        cc.NgayLamViec,
        nv.MaNV,
        nv.HoTen,

        CAST(cc.Checkin AS time(0))  AS Checkin,
        CAST(cc.Checkout AS time(0)) AS Checkout,

        CAST(
            CASE 
                WHEN cc.Checkin IS NOT NULL AND cc.Checkout IS NOT NULL 
                THEN DATEDIFF(MINUTE, cc.Checkin, cc.Checkout) / 60.0
                ELSE 0
            END
        AS DECIMAL(5,2)) AS SoGioLamViec

    FROM CHAM_CONG cc
    JOIN NHAN_VIEN nv ON cc.MaNV = nv.MaNV
    WHERE cc.MaNV = @MaNV
    ORDER BY cc.NgayLamViec DESC, nv.HoTen ASC;
END
GO

EXEC sp_ChamCong_XemLichSu
	 @MaNV = 'NV31'