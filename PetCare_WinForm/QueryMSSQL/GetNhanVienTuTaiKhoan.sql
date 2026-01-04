USE PetCareX_DB
GO

CREATE OR ALTER PROCEDURE sp_GetNhanVien_ID
    @username NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MaNV,
        HoTen,
        ChucVu
    FROM 
        NHAN_VIEN
    WHERE 
        UserName = @username;
END
GO