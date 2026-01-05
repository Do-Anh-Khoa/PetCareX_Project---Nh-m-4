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

--Thêm phân ca
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

-- Tìm kiếm ca làm việc
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

-- Tìm kiếm ca làm việc theo mã nhân viên
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

-- =============================================
-- 1. Thống kê tổng doanh thu (Danh sách hóa đơn chi tiết)
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuPhongKham
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20) = NULL,
    @TuKhoa NVARCHAR(100) = NULL, -- Tìm theo tên KH hoặc Mã HĐ
    @SortOption INT = 0 -- 0: Mới nhất, 1: Cũ nhất, 2: Giá cao
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        hd.MaHD,
        hd.NgayLap,
        hd.TongTien,
        hd.HinhThucThanhToan,
        kh.HoTen AS TenKhachHang,
        nv.HoTen AS NhanVienTao,
        cn.TenChiNhanh
    FROM HOA_DON hd
    JOIN KHACH_HANG kh ON hd.MaKH = kh.MaKH
    JOIN NHAN_VIEN nv ON hd.MaNV = nv.MaNV
    JOIN CHI_NHANH cn ON hd.MaCN = cn.MaCN
    WHERE
        (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
        AND (@MaCN IS NULL OR hd.MaCN = @MaCN)
        AND (@TuKhoa IS NULL OR kh.HoTen LIKE N'%' + @TuKhoa + '%' OR hd.MaHD LIKE N'%' + @TuKhoa + '%')
    ORDER BY 
        CASE WHEN @SortOption = 0 THEN hd.NgayLap END DESC,
        CASE WHEN @SortOption = 1 THEN hd.NgayLap END ASC,
        CASE WHEN @SortOption = 2 THEN hd.TongTien END DESC;
END
GO

-- =============================================
-- 2. Thống kê doanh thu theo Bác Sĩ
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuTheoBacSi
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- CTE lấy doanh thu từ Khám bệnh
    WITH DoanhThuKham AS (
        SELECT dk.BacSiPhuTrach AS MaNV, SUM(ISNULL(dk.GiaKhamBenh, 0)) AS TienKham
        FROM DV_KHAM dk
        JOIN DICH_VU dv ON dk.MaKham = dv.MaDV
        JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
        JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
        WHERE 
            (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
            AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
            AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
        GROUP BY dk.BacSiPhuTrach
    ),

    -- CTE lấy doanh thu từ Tiêm phòng đơn lẻ (Tính tổng giá vaccine tiêm)
    DoanhThuTiemLe AS (
        SELECT tp.BacSiPhuTrach AS MaNV, SUM(ISNULL(ctt.Gia, 0)) AS TienTiem
        FROM DV_TIEM_PHONG_DON_LE tp
        JOIN CHI_TIET_TIEM ctt ON tp.MaTiem = ctt.MaTiem
        JOIN DICH_VU dv ON tp.MaTiem = dv.MaDV
        JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
        JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
        WHERE 
            (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
            AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
            AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
        GROUP BY tp.BacSiPhuTrach
    )
    
    -- Tổng hợp kết quả
    SELECT 
        nv.MaNV,
        nv.HoTen AS TenBacSi,
        ISNULL(k.TienKham, 0) + ISNULL(t.TienTiem, 0) AS TongDoanhThu
    FROM NHAN_VIEN nv
    LEFT JOIN DoanhThuKham k ON nv.MaNV = k.MaNV
    LEFT JOIN DoanhThuTiemLe t ON nv.MaNV = t.MaNV
    WHERE nv.ChucVu LIKE 'BacSi'
          AND (ISNULL(k.TienKham, 0) + ISNULL(t.TienTiem, 0)) > 0 -- Chỉ hiện BS có doanh thu
    ORDER BY TongDoanhThu DESC;
END
GO

-- =============================================
-- 3. Thống kê số lượt khám bệnh
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_SoLuotKham
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
	
	IF @MaCN IS NULL
	BEGIN
		;THROW 50001, N'Mã chi nhánh không được rỗng', 1;
	END
    SELECT 
        CAST(hd.NgayLap AS DATE) AS Ngay,
        COUNT(dk.MaKham) AS SoLuotKham
    FROM DV_KHAM dk
    JOIN DICH_VU dv ON dk.MaKham = dv.MaDV
    JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    WHERE 
        (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
        AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
    GROUP BY CAST(hd.NgayLap AS DATE)
    ORDER BY Ngay ASC;
END
GO

-- =============================================
-- 4. Thống kê doanh thu theo Sản Phẩm
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuSanPham
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL,
    @MaCN VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 20 -- Lấy top 20 sản phẩm
        sp.MaSP,
        sp.TenSP,
        sp.LoaiSP,
        SUM(ctmh.SoLuong) AS SoLuongBan,
        SUM(ctmh.SoLuong * ctmh.DonGia) AS DoanhThu
    FROM CHI_TIET_MUA_HANG ctmh
    JOIN SAN_PHAM sp ON ctmh.MaSP = sp.MaSP
    JOIN DV_MUA_HANG dvmh ON ctmh.MaMuaHang = dvmh.MaMuaHang
    JOIN DICH_VU dv ON dvmh.MaMuaHang = dv.MaDV
    JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    WHERE 
        (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
        AND (@MaCN IS NULL OR dv.MaCN = @MaCN)
    GROUP BY sp.MaSP, sp.TenSP, sp.LoaiSP
    ORDER BY DoanhThu DESC;
END
GO

-- =============================================
-- 5. Thống kê doanh thu tất cả chi nhánh
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_DoanhThuTatCaChiNhanh
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        cn.MaCN,
        cn.TenChiNhanh,
        COUNT(hd.MaHD) AS SoLuongHoaDon,
        SUM(ISNULL(hd.TongTien, 0)) AS TongDoanhThu
    FROM CHI_NHANH cn
    LEFT JOIN HOA_DON hd ON cn.MaCN = hd.MaCN 
        AND (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
    GROUP BY cn.MaCN, cn.TenChiNhanh
    ORDER BY TongDoanhThu DESC;
END
GO

-- =============================================
-- 6. Thống kê lượt khám theo chi nhánh
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThongKe_LuotKhamTheoChiNhanh
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        cn.MaCN,
        cn.TenChiNhanh,
        COUNT(dk.MaKham) AS SoLuotKham
    FROM CHI_NHANH cn
    LEFT JOIN DICH_VU dv ON cn.MaCN = dv.MaCN
    LEFT JOIN DV_KHAM dk ON dv.MaDV = dk.MaKham
    LEFT JOIN CHI_TIET_DV_SD ctsd ON dv.MaDV = ctsd.MaDV
    LEFT JOIN HOA_DON hd ON ctsd.MaHD = hd.MaHD
    WHERE 
        (@TuNgay IS NULL OR CAST(hd.NgayLap AS DATE) >= @TuNgay)
        AND (@DenNgay IS NULL OR CAST(hd.NgayLap AS DATE) <= @DenNgay)
    GROUP BY cn.MaCN, cn.TenChiNhanh
    ORDER BY SoLuotKham DESC;
END
GO

-- Xóa phân ca
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