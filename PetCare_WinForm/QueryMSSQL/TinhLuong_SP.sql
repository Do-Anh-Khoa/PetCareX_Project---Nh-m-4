USE PetCareX_DB

GO

-- Tính lương tháng
CREATE OR ALTER PROCEDURE sp_TinhLuong
    @Thang INT,
    @Nam INT,
    @PhanTramHoaHong FLOAT = 0.02 -- Ví dụ: Hoa hồng 2% doanh số
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Xóa dữ liệu lương cũ của tháng đó (để tính lại từ đầu nếu chạy lại)
    DELETE FROM BANG_LUONG_THANG WHERE Thang = @Thang AND Nam = @Nam;

    -- 2. Tính toán và Insert vào bảng lương
    INSERT INTO BANG_LUONG_THANG (MaNV, Thang, Nam, TongGioCong, LuongCoBan, Thuong, TongLuong, NgayTinhLuong)
    SELECT 
        nv.MaNV,
        @Thang,
        @Nam,
        
        -- A. Tính Tổng Giờ Công (Từ bảng CHAM_CONG)
        ISNULL((
            SELECT SUM(DATEDIFF(MINUTE, cc.Checkin, cc.Checkout)) / 60.0
            FROM CHAM_CONG cc 
            WHERE cc.MaNV = nv.MaNV 
              AND MONTH(cc.NgayLamViec) = @Thang 
              AND YEAR(cc.NgayLamViec) = @Nam
        ), 0) AS TongGioCong,

        nv.LuongCoBan, -- Giả sử LuongCoBan ở đây là Lương theo giờ

        -- B. Tính Thưởng (Hoa hồng từ Hóa Đơn)
        ISNULL((
            SELECT SUM(hd.TongTien) * @PhanTramHoaHong
            FROM HOA_DON hd
            WHERE hd.MaNV = nv.MaNV 
              AND MONTH(hd.NgayLap) = @Thang 
              AND YEAR(hd.NgayLap) = @Nam
        ), 0) AS Thuong,

        -- C. Tính Tổng Lương = (Giờ * Lương Cơ Bản) + Thưởng
        0, -- Tạm thời để 0, sẽ update ở bước sau hoặc tính trực tiếp ở đây
        
        GETDATE() -- Ngày tính lương
    FROM NHAN_VIEN nv;

    -- 3. Cập nhật cột TongLuong (Tính toán cột cuối cùng)
    UPDATE BANG_LUONG_THANG
    SET TongLuong = (TongGioCong * LuongCoBan) + Thuong
    WHERE Thang = @Thang AND Nam = @Nam;
END
GO

-- Test
EXEC sp_TinhLuong
    @Thang = 1,
    @Nam = 2025

GO
-- Xem bảng lương để đưa ra quyết định trước khi thực hiện tính
CREATE OR ALTER PROCEDURE sp_XemBangLuong
    @Thang INT,
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        bl.MaNV,
        nv.HoTen,
        nv.ChucVu,
        bl.TongGioCong,
        bl.LuongCoBan,
        bl.Thuong,
        bl.TongLuong
    FROM BANG_LUONG_THANG bl
    JOIN NHAN_VIEN nv ON bl.MaNV = nv.MaNV
    WHERE bl.Thang = @Thang AND bl.Nam = @Nam
    ORDER BY bl.TongLuong DESC;
END
GO

EXEC sp_XemBangLuong
	@Thang = 1,
	@Nam = 2025

