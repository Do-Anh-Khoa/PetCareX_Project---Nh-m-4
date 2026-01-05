USE PetCareX_DB
GO

CREATE OR ALTER PROCEDURE sp_XoaPhanCa
    @TenCa nvarchar(50),          
	@InputNhanVien nvarchar(100), -- MaNV hoặc HoTen
    @NgayLamViec date             
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @MaCa varchar(20);
    DECLARE @MaNV varchar(20);

    -- 1. (TenCa -> MaCa)
    SELECT TOP 1 @MaCa = MaCa 
    FROM CA_LAM_VIEC 
    WHERE TenCa = @TenCa;

    IF @MaCa IS NULL
    BEGIN
        ;THROW 51000, N'Lỗi: Không tìm thấy Tên Ca làm việc này.', 1;
        RETURN;
    END

    -- 2. (Input -> MaNV)
    SELECT TOP 1 @MaNV = MaNV 
    FROM NHAN_VIEN 
    WHERE MaNV = @InputNhanVien OR HoTen = @InputNhanVien;

    IF @MaNV IS NULL
    BEGIN
        ;THROW 51000, N'Lỗi: Không tìm thấy Nhân viên (Kiểm tra lại Mã hoặc Tên).', 1;
        RETURN;
    END

    -- 3. Kiểm tra mã nhân viên có trong bảng phân ca không
    IF NOT EXISTS (SELECT 1 FROM BANG_PHAN_CA 
                   WHERE MaNV = @MaNV AND MaCa = @MaCa AND NgayLamViec = @NgayLamViec)
    BEGIN
        ;THROW 51000, N'Lỗi: Không tìm thấy lịch làm việc này để xóa.', 1;
        RETURN;
    END

    -- 4. Xóa dữ liệu
    DELETE FROM BANG_PHAN_CA 
    WHERE MaNV = @MaNV AND MaCa = @MaCa AND NgayLamViec = @NgayLamViec;

    SELECT N'Xóa phân ca thành công!' AS ThongBao;
END
GO