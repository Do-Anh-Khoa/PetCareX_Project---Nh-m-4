CREATE TRIGGER trg_TruKho_Vaccine
ON CHI_TIET_TIEM
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Trừ kho
    UPDATE tk
    SET tk.SoLuong = tk.SoLuong - i.LieuLuong
    FROM TON_KHO_VACCINE tk
    JOIN inserted i ON tk.MaVC = i.MaVC

    -- Nếu có dòng nào bị âm kho rollback
    IF EXISTS (
        SELECT 1
        FROM TON_KHO_VACCINE
        WHERE SoLuong < 0
    )
    BEGIN
        RAISERROR (N'Vaccine không đủ trong kho!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END
GO

CREATE PROC sp_LayThongTinGoiTiem
    @MaTC varchar(20)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra có gói tiêm còn hiệu lực không
    IF NOT EXISTS (
        SELECT 1
        FROM DICH_VU dv
        JOIN DV_TIEM_PHONG_THEO_THANG gt ON dv.MaDV = gt.MaGoi
        WHERE dv.MaTC = @MaTC
          AND gt.NgayKT >= CAST(GETDATE() AS date)
    )
    BEGIN
        -- Không có gói tiêm
        SELECT 
            N'Thú cưng không có gói tiêm còn hiệu lực' AS ThongBao;
        RETURN;
    END

    -- Có gói tiêm thì trả chi tiết
    SELECT
        gt.MaGoi,
        gt.TenGoi,
        gt.SoThang,
        gt.NgayDK,
        gt.NgayKT,
        gt.GiaGoi,
        vc.MaVC,
        vc.TenVC,
        vc.LoaiVC,
        ctt.LieuLuong,
        ctt.LanTiem,
        ctt.NgayTiem
    FROM
		DICH_VU dv
		JOIN DV_TIEM_PHONG_THEO_THANG gt ON dv.MaDV = gt.MaGoi
		JOIN CHI_TIET_TIEM_THANG ctt ON gt.MaGoi = ctt.MaGoi
		JOIN VACCINE vc ON ctt.MaVC = vc.MaVC
    WHERE
		dv.MaTC = @MaTC
		AND gt.NgayKT >= CAST(GETDATE() AS date)
    ORDER BY ctt.LanTiem;
END
GO
