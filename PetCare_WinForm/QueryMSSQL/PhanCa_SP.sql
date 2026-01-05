USE PetCareX_DB;
GO

CREATE OR ALTER PROC sp_TimKiemCaLamViec
    @MaNV VARCHAR(20) = NULL,   
    @TuNgay DATE = NULL,        
    @DenNgay DATE = NULL        
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        bpc.NgayLamViec,
        c.TenCa,
        c.GioBD,
        c.GioKT,
        nv.MaNV, 
        nv.HoTen,
        bpc.MaCa
    FROM BANG_PHAN_CA bpc
    JOIN NHAN_VIEN nv ON bpc.MaNV = nv.MaNV
    JOIN CA_LAM_VIEC c ON bpc.MaCa = c.MaCa
    WHERE 
        (@MaNV IS NULL OR bpc.MaNV = @MaNV)
        AND (@TuNgay IS NULL OR bpc.NgayLamViec >= @TuNgay)
        AND (@DenNgay IS NULL OR bpc.NgayLamViec <= @DenNgay)
    ORDER BY bpc.NgayLamViec DESC, c.GioBD ASC;
END
GO

-- Them ca lam viec
CREATE OR ALTER PROC sp_ThemCaLamViec
    @MaCa VARCHAR(20),
    @MaNV VARCHAR(20),
    @NgayLamViec DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Kiem tra NV co ton tai
    IF NOT EXISTS (SELECT 1 FROM NHAN_VIEN WHERE MaNV = @MaNV)
    BEGIN
        ;THROW 52001, N'Nhân viên không tồn tại.', 1;
        RETURN;
    END

    -- 2. Kiem tra ca lam viec co ton tai
    IF NOT EXISTS (SELECT 1 FROM CA_LAM_VIEC WHERE MaCa = @MaCa)
    BEGIN
        ;THROW 52002, N'Ca làm việc không tồn tại.', 1;
        RETURN;
    END

    -- 3. Kiem tra nhan vien da duoc phan cong vao ca do trong ngay hom do chua
    IF EXISTS (SELECT 1 FROM BANG_PHAN_CA WHERE MaCa = @MaCa AND MaNV = @MaNV AND NgayLamViec = @NgayLamViec)
    BEGIN
        ;THROW 52003, N'Nhân viên đã được phân công ca này trong ngày đã chọn.', 1;
        RETURN;
    END

    -- 4. Them vao ca moi
    INSERT INTO BANG_PHAN_CA (MaCa, MaNV, NgayLamViec)
    VALUES (@MaCa, @MaNV, @NgayLamViec);
END
GO

-- Xoa ca lam viec
CREATE OR ALTER PROC sp_XoaCaLamViecc
    @MaCa VARCHAR(20),
    @MaNV VARCHAR(20),
    @NgayLamViec DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM BANG_PHAN_CA
        WHERE MaCa = @MaCa
          AND MaNV = @MaNV
          AND NgayLamViec = @NgayLamViec
    )
    BEGIN
        ;THROW 52004, N'Không tồn tại ca làm việc để xóa.', 2;
        RETURN;
    END

    DELETE FROM BANG_PHAN_CA
    WHERE MaCa = @MaCa
      AND MaNV = @MaNV
      AND NgayLamViec = @NgayLamViec;
END
GO
