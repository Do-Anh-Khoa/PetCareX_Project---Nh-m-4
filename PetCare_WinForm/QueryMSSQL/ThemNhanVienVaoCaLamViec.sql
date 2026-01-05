USE PetCareX_DB
GO

CREATE OR ALTER PROCEDURE sp_ThemPhanCa
    @TenCa nvarchar(50),          -- Tên ca
    @InputNhanVien nvarchar(100), -- MaNV hoặc HoTen
    @NgayLamViec date            
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MaCa varchar(20);
    DECLARE @MaNV varchar(20);

	-- 1. TenCa -> MaCa
    SELECT TOP 1 @MaCa = MaCa 
    FROM CA_LAM_VIEC 
    WHERE TenCa = @TenCa;

    -- Validation: Không tìm thấy mã ca
    IF @MaCa IS NULL
    BEGIN
        ;THROW 51000, N'Lỗi: Không tìm thấy Tên Ca làm việc này trong hệ thống.', 1;
        RETURN;
    END

    -- 2. Input -> MaNV
    SELECT TOP 1 @MaNV = MaNV 
    FROM NHAN_VIEN 
    WHERE MaNV = @InputNhanVien OR HoTen = @InputNhanVien;

    -- Không tìm thấy nhân viên
    IF @MaNV IS NULL
    BEGIN
        ;THROW 51000, N'Lỗi: Không tìm thấy Nhân viên (Vui lòng kiểm tra lại Mã hoặc Họ Tên).', 1;
        RETURN;
    END

    -- 3. Kiểm tra NV đã được phân công vào thời gian đó chứa
    IF EXISTS (SELECT 1 FROM BANG_PHAN_CA 
               WHERE MaNV = @MaNV AND MaCa = @MaCa AND NgayLamViec = @NgayLamViec)
    BEGIN
        DECLARE @ErrorMsg nvarchar(200);
        SET @ErrorMsg = N'Lỗi: Nhân viên ' + @InputNhanVien + N' đã có lịch làm việc này rồi.';
        ;THROW 51000, @ErrorMsg, 1;
        RETURN;
    END

    -- 4. Thêm dữ liệu
    INSERT INTO BANG_PHAN_CA (MaCa, MaNV, NgayLamViec)
    VALUES (@MaCa, @MaNV, @NgayLamViec);
END
GO