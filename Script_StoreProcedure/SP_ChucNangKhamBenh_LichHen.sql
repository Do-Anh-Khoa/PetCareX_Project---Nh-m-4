﻿USE PetCareX_DB
GO

-- 1. Lấy danh sách lịch hẹn (Chỉ lấy các cột hiển thị lên Grid)
CREATE OR ALTER PROCEDURE sp_GetLichHenChoDuyet
AS
BEGIN
    SELECT 
        l.MaLichHen,
        ISNULL(k.HoTen, N'Khách vãng lai') AS TenKhachHang, -- Xử lý null ngay tại SQL
        ISNULL(k.SoDt, '') AS SoDT,
        l.NgayHen,
        l.GioHen,
        ISNULL(nv.HoTen, '') AS TenBacSi,
        ISNULL(cn.TenChiNhanh, '') AS TenChiNhanh,
        l.TrangThai,
        l.GhiChu
    FROM LICH_HEN l
    JOIN KHACH_HANG k ON l.MaKH = k.MaKH
    JOIN NHAN_VIEN nv ON l.MaBS = nv.MaNV
    JOIN CHI_NHANH cn ON l.MaCN = cn.MaCN
    WHERE l.TrangThai = 'DaXacNhan' OR l.TrangThai IS NULL OR l.TrangThai = ''
END
GO

-- 2. Lấy danh sách Bác sĩ (Chỉ lấy Mã và Tên để đổ vào ComboBox)
CREATE OR ALTER PROCEDURE sp_GetDanhSachBacSi
AS
BEGIN
    SELECT MaNV, HoTen 
    FROM NHAN_VIEN 
    WHERE ChucVu = 'BacSi'
END
GO

-- 3. Lấy danh sách Chi nhánh (Chỉ lấy Mã và Tên)
CREATE OR ALTER PROCEDURE sp_GetDanhSachChiNhanh
AS
BEGIN
    SELECT MaCN, TenChiNhanh FROM CHI_NHANH
END
GO

-- 4. Tìm khách hàng theo SĐT (Chỉ lấy Mã và Tên để hiển thị và gán biến)
CREATE OR ALTER PROCEDURE sp_GetKhachHangInfoBySdt
    @SoDt VARCHAR(20)
AS
BEGIN
	IF @SoDt IS NULL
	BEGIN
		PRINT N'Số điện thoại không được để trống';
		RETURN;
	END

    SELECT MaKH, HoTen 
    FROM KHACH_HANG 
    WHERE SoDt = @SoDt
END
GO

-- 5. Lấy danh sách thú cưng của khách (Chỉ lấy Mã và Tên để đổ vào ComboBox)
CREATE OR ALTER PROCEDURE sp_GetThuCungInfoByMaKh
    @MaKh VARCHAR(20)
AS
BEGIN
	IF @MaKh IS NULL
	BEGIN
		PRINT N'Mã khách hàng bị thiếu';
		RETURN;
	END	

    SELECT MaTC, TenTC 
    FROM THU_CUNG 
    WHERE MaKH = @MaKh
END
GO

-- 6. SP Lấy danh sách lịch hẹn khám bệnh (cho form Lịch Hẹn)
CREATE OR ALTER PROCEDURE sp_GetDanhSachLichHenKham
    @TrangThai NVARCHAR(50) = NULL,
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL
AS
BEGIN
    -- Lấy tất cả nếu tham số NULL
    SELECT 
        l.MaLichHen,
        l.NgayHen,
        l.GioHen,
        l.TrangThai,
        l.GhiChu,
        ISNULL(k.HoTen, N'Khách vãng lai') AS TenKhachHang,
        ISNULL(k.SoDT, '') AS SoDT,
        ISNULL(bs.HoTen, '') AS TenBacSi,
        ISNULL(l.MaBS, '') AS MaBacSi, -- Cần mã BS để truyền sang form Khám
        ISNULL(cn.TenChiNhanh, '') AS TenChiNhanh
    FROM LICH_HEN l
    LEFT JOIN KHACH_HANG k ON l.MaKH = k.MaKH
    LEFT JOIN NHAN_VIEN bs ON l.MaBS = bs.MaNV
    LEFT JOIN CHI_NHANH cn ON l.MaCN = cn.MaCN
    WHERE 
        (@TrangThai IS NULL OR l.TrangThai = @TrangThai OR @TrangThai = '')
        AND (@TuNgay IS NULL OR l.NgayHen >= @TuNgay)
        AND (@DenNgay IS NULL OR l.NgayHen <= @DenNgay)
    ORDER BY l.NgayHen DESC, l.GioHen DESC
END
GO

-- 7. Lấy danh sách lịch sử khám thông qua mã thú cưng
CREATE OR ALTER PROCEDURE sp_GetLichSuKham
    @MaTC VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

	IF @MaTC IS NULL
	BEGIN
		;THROW 50001, 'MaTC không được để trống', 1;
	END

    SELECT 
        hd.NgayLap AS NgayKham,         -- Ngày khách đến khám
        dk.TrieuChung,
        dk.ChuanDoan,
        dk.ToaThuoc,
        dk.NgayTaiKham,                 -- Ngày hẹn tái khám
        nv.HoTen AS BacSiPhuTrach,      -- Tên bác sĩ
        dv.MaDV AS MaHoSo               -- Mã dịch vụ để tiện tra cứu sâu hơn nếu cần
    FROM DV_KHAM dk
    JOIN DICH_VU dv ON dk.MaKham = dv.MaDV
    JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    JOIN NHAN_VIEN nv ON dk.BacSiPhuTrach = nv.MaNV
    WHERE dv.MaTC = @MaTC
    ORDER BY hd.NgayLap DESC;
END
GO

-- 8. SP Lấy danh sách Vaccine
CREATE OR ALTER PROCEDURE sp_GetDanhSachVaccine
AS
BEGIN
    SELECT MaVC, TenVC, LoaiVC, GiaVC 
    FROM VACCINE
    ORDER BY TenVC
END
GO

-- 9. SP Lấy thông tin chi tiết Lịch Hẹn để hiển thị lên Form
CREATE OR ALTER PROCEDURE sp_GetThongTinKhamBenh
    @MaLichHen VARCHAR(20)
AS
BEGIN
    SELECT 
        l.MaLichHen,
        l.MaKH,
        k.HoTen AS TenKhachHang,
        l.MaBS,
        bs.HoTen AS TenBacSi,
        l.NgayHen,
        l.MaCN,
        -- Lấy mã thú cưng đầu tiên của khách (nếu chưa có trong lịch hẹn)
        (SELECT TOP 1 MaTC FROM THU_CUNG WHERE MaKH = l.MaKH) AS MaThuCung
    FROM LICH_HEN l
    LEFT JOIN KHACH_HANG k ON l.MaKH = k.MaKH
    LEFT JOIN NHAN_VIEN bs ON l.MaBS = bs.MaNV
    WHERE l.MaLichHen = @MaLichHen
END
GO

-- 10. SP Lưu Bệnh Án (Thực hiện Transaction để đảm bảo tính toàn vẹn)
CREATE OR ALTER PROCEDURE sp_LuuBenhAnKham
    @MaDichVu VARCHAR(20),
    @MaThuCung VARCHAR(20),
    @MaChiNhanh VARCHAR(20),
    @TrieuChung NVARCHAR(100),
    @ChuanDoan NVARCHAR(100),
    @ToaThuoc NVARCHAR(100),
    @MaBacSi VARCHAR(20),
    @GiaKham FLOAT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Insert DICH_VU
        INSERT INTO DICH_VU(MaDV, MaTC, MaCN)
        VALUES(@MaDichVu, @MaThuCung, @MaChiNhanh);

        -- Insert DV_KHAM
        INSERT INTO DV_KHAM(MaKham, TrieuChung, ChuanDoan, ToaThuoc, BacSiPhuTrach, GiaKhamBenh)
        VALUES(@MaDichVu, @TrieuChung, @ChuanDoan, @ToaThuoc, @MaBacSi, @GiaKham);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 11. SP Hoàn tất khám (Cập nhật lịch hẹn)
CREATE OR ALTER PROCEDURE sp_HoanTatKhamBenh
    @MaLichHen VARCHAR(20),
    @GhiChu NVARCHAR(200)
AS
BEGIN
    UPDATE LICH_HEN 
    SET TrangThai = 'DaHoanThanh',
        GhiChu = ISNULL(GhiChu, '') + ' | ' + @GhiChu
    WHERE MaLichHen = @MaLichHen
END
GO