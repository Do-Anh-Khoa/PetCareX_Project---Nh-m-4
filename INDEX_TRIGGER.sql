use PetCareX
go
--DROP INDEX IDX__KHACH_HANG__SO_DT ON KHACH_HANG;    

-- tao index
CREATE NONCLUSTERED INDEX IDX__KHACH_HANG__SO_DT
ON KHACH_HANG(SoDT)
INCLUDE (MaKH,
    HoTen,
    Email,
    CCCD,
    GioiTinh,
    NgaySinh,
    CapHoiVien,
    DiemTichLuy,
    UserName);

GO
--SET STATISTICS TIME ON;
--SET STATISTICS IO ON;

--SELECT 
--    MaKH,
--    HoTen,
--    SoDT,
--    Email,
--    CCCD,
--    GioiTinh,
--    NgaySinh,
--    CapHoiVien,
--    DiemTichLuy,
--    UserName
--FROM KHACH_HANG
--WHERE SoDT = '0910001175';

--SET STATISTICS TIME OFF;
--SET STATISTICS IO OFF;


-- ===================TRIGGER=============================

--DROP TRIGGER TRG_TICH_DIEM_SAU_THANH_TOAN
CREATE TRIGGER TRG_TICH_DIEM_SAU_THANH_TOAN
ON HOA_DON
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE KH
    SET
        DiemTichLuy = KH.DiemTichLuy + FLOOR(HD.TongTien / 50000),
        CapHoiVien = CASE
            WHEN KH.DiemTichLuy + FLOOR(HD.TongTien / 50000) >= 240 THEN N'VIP'
            WHEN KH.DiemTichLuy + FLOOR(HD.TongTien / 50000) >= 100 THEN N'ThanThiet'
            ELSE N'CoBan'
        END
    FROM KHACH_HANG KH
    JOIN (
        SELECT
            I.MaKH,
            SUM(ISNULL(I.TongTien, 0)) AS TongTien
        FROM inserted I
        JOIN deleted D ON I.MaHD = D.MaHD
        WHERE D.TrangThai = N'ChuaThanhToan'
          AND I.TrangThai = N'DaThanhToan'
          AND I.MaKH IS NOT NULL
        GROUP BY I.MaKH
    ) HD ON KH.MaKH = HD.MaKH;
END;

GO

--SELECT MaHD FROM HOA_DON H
--JOIN KHACH_HANG KH ON KH.MaKH = H.MaKH
--WHERE KH.SoDT = '0123456789' AND H.TrangThai='DaThanhToan'