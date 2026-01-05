USE PetCareX_DB
GO

CREATE OR ALTER PROCEDURE sp_TimKiemCaLamViec
    @MaNV varchar(20) = NULL,
    @HoTen nvarchar(100) = NULL,
    @Flag int -- 1 for ID, 0 for Name
AS
BEGIN
    SELECT 
        NV.MaNV, 
        NV.HoTen, 
        C.TenCa, 
        C.GioBD, 
        C.GioKT, 
        PC.NgayLamViec
    FROM BANG_PHAN_CA PC
    JOIN NHAN_VIEN NV ON PC.MaNV = NV.MaNV
    JOIN CA_LAM_VIEC C ON PC.MaCa = C.MaCa
    WHERE 
        ((@MaNV IS NULL OR @MaNV = '') AND (@HoTen IS NULL OR @HoTen = ''))       
        OR
        (@Flag = 1 AND NV.MaNV = @MaNV)
        OR 
        (@Flag = 0 AND NV.HoTen LIKE N'%' + @HoTen + N'%');
END
GO

EXEC sp_TimKiemCaLamViec
    @MaNV = 'NV1',
    @HoTen = 'L',
    @Flag = 1

GO

CREATE OR ALTER PROCEDURE sp_TimKiemCaLamViec_TheoMaNV
    @MaNV VARCHAR(20)   -- Chắc chắn không NULL
AS
BEGIN
    SELECT 
        NV.MaNV,
        NV.HoTen,
        C.TenCa,
        C.GioBD,
        C.GioKT,
        PC.NgayLamViec
    FROM BANG_PHAN_CA PC
    JOIN NHAN_VIEN NV ON PC.MaNV = NV.MaNV
    JOIN CA_LAM_VIEC C ON PC.MaCa = C.MaCa
    WHERE NV.MaNV = @MaNV;
END
GO