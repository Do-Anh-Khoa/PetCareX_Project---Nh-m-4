USE PetCareX_DB
GO

-- Kiểm tra sinh viên tồn tại bằng tên hoặc bằng mã nhân viên
CREATE OR ALTER PROCEDURE sp_KiemTraNhanVienTonTai
    @MaNV varchar(20) = NULL,   
	@HoTen nvarchar(100) = NULL 
AS
BEGIN
    IF (@MaNV IS NULL OR @MaNV = '') AND (@HoTen IS NULL OR @HoTen = '')
    BEGIN
        SELECT 1;
        RETURN;
    END

    SELECT TOP 1 1 
    FROM NHAN_VIEN 
    WHERE 
        ((@MaNV IS NULL OR @MaNV = '') OR MaNV = @MaNV)
        AND
        ((@HoTen IS NULL OR @HoTen = '') OR HoTen LIKE N'%' + @HoTen + N'%')
END
GO

EXEC sp_KiemTraNhanVienTonTai
	@MaNV = null,
	@HoTen = 'Lê'
