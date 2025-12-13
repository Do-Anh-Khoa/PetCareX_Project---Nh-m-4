USE data8; 
GO

SET NOCOUNT ON;
SET DATEFORMAT dmy;

-- 1. TẮT RÀNG BUỘC
EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all';
GO

PRINT '>>> BẮT ĐẦU SINH DỮ LIỆU V7 (FIXED: RANDOM TỪNG DÒNG TUYỆT ĐỐI)...';

-----------------------------------------------------------------------------
-- BƯỚC 1: CLEAN UP & PREPARE DATA POOLS
-----------------------------------------------------------------------------
IF OBJECT_ID('tempdb..#Ho') IS NOT NULL DROP TABLE #Ho;
IF OBJECT_ID('tempdb..#TenDem') IS NOT NULL DROP TABLE #TenDem;
IF OBJECT_ID('tempdb..#Ten') IS NOT NULL DROP TABLE #Ten;
IF OBJECT_ID('tempdb..#TrieuChung') IS NOT NULL DROP TABLE #TrieuChung;
IF OBJECT_ID('tempdb..#Review') IS NOT NULL DROP TABLE #Review;
IF OBJECT_ID('tempdb..#ProductData') IS NOT NULL DROP TABLE #ProductData;
IF OBJECT_ID('tempdb..#SucKhoe') IS NOT NULL DROP TABLE #SucKhoe;

-- Xóa dữ liệu cũ
DELETE FROM CHI_TIET_TIEM_THANG; DELETE FROM CHI_TIET_TIEM; DELETE FROM CHI_TIET_MUA_HANG;
DELETE FROM CHI_TIET_DD; DELETE FROM CHI_TIET_DV_SD; DELETE FROM DANH_GIA;
DELETE FROM DV_MUA_HANG; DELETE FROM DV_KHAM; DELETE FROM DV_TIEM_PHONG_DON_LE; DELETE FROM DV_TIEM_PHONG_THEO_THANG;
DELETE FROM DICH_VU; DELETE FROM HOA_DON;
DELETE FROM THU_CUNG; DELETE FROM KHACH_HANG;
DELETE FROM CHAM_CONG; DELETE FROM BANG_LUONG_THANG; DELETE FROM BANG_PHAN_CA;
DELETE FROM LICH_SU_DIEU_DONG; DELETE FROM NHAN_VIEN;
DELETE FROM TON_KHO_SAN_PHAM; DELETE FROM TON_KHO_VACCINE;
DELETE FROM SAN_PHAM; DELETE FROM VACCINE; DELETE FROM CA_LAM_VIEC; DELETE FROM CHI_NHANH; DELETE FROM TAI_KHOAN;

-- Tạo dữ liệu mẫu
CREATE TABLE #Ho (Val NVARCHAR(20)); INSERT INTO #Ho VALUES (N'Nguyễn'),(N'Trần'),(N'Lê'),(N'Phạm'),(N'Huỳnh'),(N'Hoàng'),(N'Phan'),(N'Vũ'),(N'Đặng'),(N'Bùi');
CREATE TABLE #TenDem (Val NVARCHAR(20)); INSERT INTO #TenDem VALUES (N'Văn'),(N'Hữu'),(N'Thị'),(N'Ngọc'),(N'Minh'),(N'Quốc'),(N'Thanh'),(N'Gia'),(N'Bảo'),(N'Mỹ');
CREATE TABLE #Ten (Val NVARCHAR(20)); INSERT INTO #Ten VALUES (N'Hùng'),(N'Dũng'),(N'Lan'),(N'Hương'),(N'Tuấn'),(N'Kiệt'),(N'Vy'),(N'Trang'),(N'Sơn'),(N'Tâm'),(N'Phúc'),(N'Nhi');
CREATE TABLE #TrieuChung (TC NVARCHAR(100), CD NVARCHAR(100), TT NVARCHAR(100));
INSERT INTO #TrieuChung VALUES (N'Bỏ ăn', N'Rối loạn tiêu hóa', N'Men tiêu hóa'),(N'Ho', N'Viêm phổi', N'Kháng sinh'),(N'Ngứa', N'Nấm da', N'Thuốc bôi'),(N'Tiêu chảy', N'Viêm ruột', N'Truyền dịch'),(N'Gãy chân', N'Chấn thương', N'Phẫu thuật');
CREATE TABLE #Review (Diem FLOAT, Comment NVARCHAR(200));
INSERT INTO #Review VALUES (10, N'Tuyệt vời'), (9, N'Rất hài lòng'), (8, N'Tạm ổn'), (5, N'Chờ hơi lâu'), (2, N'Thái độ nhân viên chưa tốt');
CREATE TABLE #ProductData (Name NVARCHAR(100), Type NVARCHAR(50), Price FLOAT);
INSERT INTO #ProductData VALUES (N'Royal Canin', 'ThucAn', 180000), (N'Whiskas', 'ThucAn', 15000), (N'Me-O', 'ThucAn', 110000), (N'Pedigree', 'ThucAn', 45000), (N'Cát Nhật', 'PhuKien', 65000), (N'Dây dắt', 'PhuKien', 120000), (N'NexGard', 'Thuoc', 250000), (N'Canxi', 'Thuoc', 150000);
CREATE TABLE #SucKhoe (Val NVARCHAR(50)); INSERT INTO #SucKhoe VALUES (N'Khỏe'), (N'Yếu'), (N'Bình thường'), (N'Béo phì'), (N'Nấm da');
GO

-----------------------------------------------------------------------------
-- BƯỚC 2: MASTER DATA (CHI NHÁNH, SẢN PHẨM, VACCINE)
-----------------------------------------------------------------------------
PRINT '--> Sinh Master Data...';

-- 2.1 Chi nhánh (10 CN)
DECLARE @i INT = 1;
WHILE @i <= 10 
BEGIN
    INSERT INTO CHI_NHANH VALUES ('CN'+CAST(@i AS VARCHAR), N'PetCareX '+CAST(@i AS VARCHAR), N'Địa chỉ '+CAST(@i AS VARCHAR), '09090000'+CAST(@i AS VARCHAR), '08:00', '21:00');
    SET @i = @i + 1;
END

-- 2.2 Vaccine (5 Loại)
INSERT INTO VACCINE VALUES 
('VC01', N'Dại', 'Cho/Meo', 150000), ('VC02', N'5 Bệnh', 'Cho', 350000), 
('VC03', N'7 Bệnh', 'Cho', 450000), ('VC04', N'Giảm Bạch Cầu', 'Meo', 300000), 
('VC05', N'FIP', 'Meo', 500000);

-- 2.3 Sản phẩm (50 Loại)
SET @i = 1;
WHILE @i <= 50
BEGIN
    DECLARE @PName NVARCHAR(100), @PType NVARCHAR(50), @PPrice FLOAT;
    SELECT TOP 1 @PName=Name, @PType=Type, @PPrice=Price FROM #ProductData ORDER BY NEWID();
    INSERT INTO SAN_PHAM VALUES ('SP'+CAST(@i AS VARCHAR), @PName + ' ' + CAST(@i AS VARCHAR), @PType, @PPrice);
    SET @i = @i + 1;
END

-- 2.4 Nhân viên & Tài khoản (50 NV - FIX: GIỚI TÍNH RANDOM TỪNG DÒNG)
SET @i = 1;
WHILE @i <= 50
BEGIN
    DECLARE @MaCN VARCHAR(20) = 'CN' + CAST(((@i - 1) / 5) + 1 AS VARCHAR);
    DECLARE @ChucVu NVARCHAR(50) = CASE WHEN (@i%5)=1 THEN 'QuanLy' WHEN (@i%5)<=3 THEN 'BacSi' ELSE 'BanHang' END;
    DECLARE @Luong DECIMAL(18,0) = CASE WHEN @ChucVu='QuanLy' THEN 20000000 WHEN @ChucVu='BacSi' THEN 15000000 ELSE 7000000 END;
    DECLARE @UserNV NVARCHAR(100) = 'staff'+CAST(@i AS VARCHAR);

    INSERT INTO TAI_KHOAN (UserName, MatKhau, QuyenHan) VALUES (@UserNV, '123', @ChucVu);
    
    DECLARE @NameNV NVARCHAR(100) = (SELECT TOP 1 Val FROM #Ho ORDER BY NEWID())+' '+(SELECT TOP 1 Val FROM #Ten ORDER BY NEWID());
    
    -- *** FIX: Random Giới tính & Ngày sinh trong INSERT ***
    INSERT INTO NHAN_VIEN (MaNV, HoTen, NgaySinh, GioiTinh, NgayVaoLam, ChucVu, LuongCoBan, MaCN, UserName)
    VALUES (
        'NV'+CAST(@i AS VARCHAR), 
        @NameNV, 
        DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 10000) - 7000, GETDATE()), -- Tuổi random
        CASE WHEN (ABS(CHECKSUM(NEWID()))%2)=0 THEN N'Nam' ELSE N'Nữ' END, -- Random Nam/Nữ
        DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 1000), GETDATE()), -- Ngày vào làm
        @ChucVu, @Luong, @MaCN, @UserNV
    );
    SET @i = @i + 1;
END

-- 2.5 Ca & Tồn kho
INSERT INTO CA_LAM_VIEC VALUES ('CA1', N'Sáng', '08:00', '12:00'), ('CA2', N'Chiều', '13:00', '17:00'), ('CA3', N'Tối', '17:00', '21:00');

INSERT INTO TON_KHO_SAN_PHAM (MaCN, MaSP, SoLuong, NgaySanXuat, NgayHetHan)
SELECT CN.MaCN, SP.MaSP, 50 + ABS(CHECKSUM(NEWID())%100), 
       DATEADD(DAY, -ABS(CHECKSUM(NEWID())%365), GETDATE()), 
       DATEADD(DAY, ABS(CHECKSUM(NEWID())%365) + 100, GETDATE())
FROM CHI_NHANH CN CROSS JOIN SAN_PHAM SP;

INSERT INTO TON_KHO_VACCINE (MaCN, MaVC, SoLo, SoLuong, NgaySanXuat, NgayHetHan)
SELECT CN.MaCN, VC.MaVC, 'LO'+CAST(ABS(CHECKSUM(NEWID())%100) AS VARCHAR), 500, 
       DATEADD(DAY, -ABS(CHECKSUM(NEWID())%200), GETDATE()), 
       DATEADD(DAY, ABS(CHECKSUM(NEWID())%200)+100, GETDATE())
FROM CHI_NHANH CN CROSS JOIN VACCINE VC;
GO 

-----------------------------------------------------------------------------
-- BƯỚC 3: KHÁCH HÀNG & THÚ CƯNG (FIX: EMAIL, NGÀY SINH, GENDER KHÁC NHAU)
-----------------------------------------------------------------------------
PRINT '--> Sinh 5.000 Khách hàng (Fix Email, Điểm, Gender)...';
DECLARE @i INT = 1;
BEGIN TRANSACTION
WHILE @i <= 5000
BEGIN
    DECLARE @UserKH NVARCHAR(100) = 'khach'+CAST(@i AS VARCHAR);
    INSERT INTO TAI_KHOAN (UserName, MatKhau, QuyenHan) VALUES (@UserKH, 'pass', 'KhachHang');
    
    DECLARE @NameKH NVARCHAR(100) = (SELECT TOP 1 Val FROM #Ho ORDER BY NEWID())+' '+(SELECT TOP 1 Val FROM #Ten ORDER BY NEWID());
    DECLARE @Cap NVARCHAR(20) = CASE WHEN (ABS(CHECKSUM(NEWID()))%100)<10 THEN 'VIP' ELSE 'CoBan' END;
    
    -- *** FIX: Email động, Ngày sinh động, Điểm động, Giới tính động ***
    INSERT INTO KHACH_HANG (MaKH, HoTen, SoDT, Email, CCCD, GioiTinh, NgaySinh, CapHoiVien, DiemTichLuy, UserName)
    VALUES (
        'KH'+CAST(@i AS VARCHAR), 
        @NameKH, 
        '09'+CAST(10000000+@i AS VARCHAR), 
        -- Email random theo tên và số
        'user'+CAST(@i AS VARCHAR)+'_'+SUBSTRING(CONVERT(varchar(255), NEWID()),1,4)+'@gmail.com', 
        '001'+CAST(100000000+@i AS VARCHAR),
        CASE WHEN (ABS(CHECKSUM(NEWID()))%2)=0 THEN N'Nam' ELSE N'Nữ' END, -- Gender
        DATEADD(DAY, -(ABS(CHECKSUM(NEWID()))%15000) - 6570, GETDATE()), -- Ngày sinh (18-60 tuổi)
        @Cap, 
        CASE WHEN @Cap='VIP' THEN 5000 + ABS(CHECKSUM(NEWID())%1000) ELSE ABS(CHECKSUM(NEWID())%500) END, -- Điểm
        @UserKH
    );
    
    -- Thú cưng
    DECLARE @NumPet INT = (ABS(CHECKSUM(NEWID())) % 2) + 1;
    DECLARE @j INT = 1;
    WHILE @j <= @NumPet
    BEGIN
        DECLARE @LoaiPet NVARCHAR(50) = CASE WHEN (ABS(CHECKSUM(NEWID()))%2)=0 THEN 'Cho' ELSE 'Meo' END;
        DECLARE @SK NVARCHAR(50) = (SELECT TOP 1 Val FROM #SucKhoe ORDER BY NEWID());
        INSERT INTO THU_CUNG VALUES (
            'TC'+CAST(@i AS VARCHAR)+'_'+CAST(@j AS VARCHAR), 
            N'Pet', 
            @LoaiPet, 
            CASE WHEN (ABS(CHECKSUM(NEWID()))%2)=0 THEN N'Đực' ELSE N'Cái' END, 
            @SK, 'KH'+CAST(@i AS VARCHAR)
        );
        SET @j = @j + 1;
    END
    SET @i = @i + 1;
    IF (@i % 1000) = 0 BEGIN COMMIT TRANSACTION; BEGIN TRANSACTION; END
END
COMMIT TRANSACTION;
GO

-----------------------------------------------------------------------------
-- BƯỚC 4: GIAO DỊCH (FIX: MUA NHIỀU SP KHÁC NHAU, TIÊM NHIỀU LOẠI)
-----------------------------------------------------------------------------
PRINT '--> Sinh 60.000 Giao dịch (Fix: Mua nhiều món, random vaccine)...';

DECLARE @TotalHD INT = 60000;
DECLARE @CountHD INT = 1;
DECLARE @DateRun DATE = '2023-01-01';

BEGIN TRANSACTION
WHILE @CountHD <= @TotalHD
BEGIN
    IF (@CountHD % 80) = 0 SET @DateRun = DATEADD(DAY, 1, @DateRun);
    IF @DateRun > GETDATE() SET @DateRun = DATEADD(DAY, -10, GETDATE());

    -- Random Actor (Chọn lại cho từng dòng)
    DECLARE @MaKH VARCHAR(20) = 'KH' + CAST((ABS(CHECKSUM(NEWID())) % 5000) + 1 AS VARCHAR);
    DECLARE @MaCN VARCHAR(20) = 'CN' + CAST((ABS(CHECKSUM(NEWID())) % 10) + 1 AS VARCHAR);
    DECLARE @MaNV VARCHAR(20) = (SELECT TOP 1 MaNV FROM NHAN_VIEN WHERE MaCN = @MaCN ORDER BY NEWID());
    IF @MaNV IS NULL SET @MaNV = 'NV' + CAST((ABS(CHECKSUM(NEWID())) % 50) + 1 AS VARCHAR);

    DECLARE @MaHD VARCHAR(20) = 'HD' + CAST(@CountHD AS VARCHAR);
    DECLARE @MaDV VARCHAR(20) = 'DV' + CAST(@CountHD AS VARCHAR);
    
    INSERT INTO HOA_DON (MaHD, NgayLap, TongTien, HinhThucThanhToan, MaNV, MaKH, MaCN)
    VALUES (@MaHD, @DateRun, 0, 'TienMat', @MaNV, @MaKH, @MaCN);

    DECLARE @MaTC VARCHAR(20) = (SELECT TOP 1 MaTC FROM THU_CUNG WHERE MaKH = @MaKH);
    IF @MaTC IS NULL SET @MaTC = (SELECT TOP 1 MaTC FROM THU_CUNG ORDER BY NEWID());

    INSERT INTO DICH_VU (MaDV, MaTC, MaCN) VALUES (@MaDV, @MaTC, @MaCN);
    INSERT INTO CHI_TIET_DV_SD (MaHD, MaDV) VALUES (@MaHD, @MaDV);

    DECLARE @Type INT = ABS(CHECKSUM(NEWID())) % 3; 
    DECLARE @TotalMoney DECIMAL(18,0) = 0;

    -- ====================================================================
    -- FIX 1: MUA HÀNG (Mua 1 đến 5 sản phẩm ngẫu nhiên khác nhau)
    -- ====================================================================
    IF @Type = 0 
    BEGIN
        INSERT INTO DV_MUA_HANG (MaMuaHang, NhanVienBanHang) VALUES (@MaDV, @MaNV);
        
        DECLARE @NumItem INT = (ABS(CHECKSUM(NEWID())) % 5) + 1; -- 1 đến 5 món
        DECLARE @k INT = 1;
        DECLARE @UsedSP TABLE (ID VARCHAR(20)); DELETE FROM @UsedSP; -- Reset list đã mua

        WHILE @k <= @NumItem
        BEGIN
            -- Chọn 1 SP ngẫu nhiên chưa có trong đơn này
            DECLARE @RndSP VARCHAR(20);
            SELECT TOP 1 @RndSP = MaSP FROM SAN_PHAM 
            WHERE MaSP NOT IN (SELECT ID FROM @UsedSP)
            ORDER BY NEWID();

            IF @RndSP IS NOT NULL
            BEGIN
                DECLARE @Price DECIMAL(18,0) = (SELECT GiaBan FROM SAN_PHAM WHERE MaSP = @RndSP);
                DECLARE @Qty INT = (ABS(CHECKSUM(NEWID())) % 5) + 1; 
                
                INSERT INTO CHI_TIET_MUA_HANG (MaSP, MaMuaHang, SoLuong, DonGia)
                VALUES (@RndSP, @MaDV, @Qty, @Price);
                
                INSERT INTO @UsedSP VALUES (@RndSP);
                SET @TotalMoney = @TotalMoney + (@Qty * @Price);
            END
            SET @k = @k + 1;
        END
    END
    -- ====================================================================
    -- FIX 2: KHÁM BỆNH
    -- ====================================================================
    ELSE IF @Type = 1 
    BEGIN
        DECLARE @TC NVARCHAR(100), @CD NVARCHAR(100), @TT NVARCHAR(100);
        SELECT TOP 1 @TC=TC, @CD=CD, @TT=TT FROM #TrieuChung ORDER BY NEWID();
        DECLARE @BS VARCHAR(20) = (SELECT TOP 1 MaNV FROM NHAN_VIEN WHERE ChucVu='BacSi' AND MaCN=@MaCN ORDER BY NEWID());
        IF @BS IS NULL SET @BS = @MaNV;
        INSERT INTO DV_KHAM (MaKham, TrieuChung, ChuanDoan, ToaThuoc, BacSiPhuTrach, NgayTaiKham, GiaKhamBenh) 
        VALUES (@MaDV, @TC, @CD, @TT, @BS, DATEADD(DAY, 7, @DateRun), 200000);
        SET @TotalMoney = 200000;
    END
    -- ====================================================================
    -- FIX 3: TIÊM PHÒNG (Random Mã VC01 -> VC05)
    -- ====================================================================
    ELSE 
    BEGIN
        DECLARE @BSTiem VARCHAR(20) = (SELECT TOP 1 MaNV FROM NHAN_VIEN WHERE ChucVu='BacSi' AND MaCN=@MaCN ORDER BY NEWID());
        IF @BSTiem IS NULL SET @BSTiem = @MaNV;
        
        -- *** FIX: Random Mã Vaccine VC01 - VC05 ***
        DECLARE @RndVC VARCHAR(20) = 'VC0' + CAST((ABS(CHECKSUM(NEWID())) % 5) + 1 AS VARCHAR);
        DECLARE @PriceVC DECIMAL(18,0) = (SELECT GiaVC FROM VACCINE WHERE MaVC = @RndVC);

        IF (ABS(CHECKSUM(NEWID())) % 2) = 0 
        BEGIN
            INSERT INTO DV_TIEM_PHONG_DON_LE (MaTiem, BacSiPhuTrach) VALUES (@MaDV, @BSTiem);
            INSERT INTO CHI_TIET_TIEM (MaVC, MaTiem, NgayTiem, LieuLuong, Gia) 
            VALUES (@RndVC, @MaDV, @DateRun, 1, @PriceVC);
            SET @TotalMoney = @PriceVC;
        END
        ELSE 
        BEGIN
            INSERT INTO DV_TIEM_PHONG_THEO_THANG (MaGoi, TenGoi, SoThang, NgayDK, NgayKT, GiaGoi, BacSiPhuTrach) 
            VALUES (@MaDV, N'Gói '+@RndVC, 6, @DateRun, DATEADD(M, 6, @DateRun), @PriceVC*5, @BSTiem);
            INSERT INTO CHI_TIET_TIEM_THANG (MaVC, MaGoi, LieuLuong, NgayTiem, LanTiem) 
            VALUES (@RndVC, @MaDV, 1, @DateRun, 1);
            SET @TotalMoney = @PriceVC*5;
        END
    END

    UPDATE HOA_DON SET TongTien = @TotalMoney WHERE MaHD = @MaHD;

    IF (ABS(CHECKSUM(NEWID())) % 10) < 3
    BEGIN
        DECLARE @DiemDG FLOAT, @Cmt NVARCHAR(200);
        SELECT TOP 1 @DiemDG=Diem, @Cmt=Comment FROM #Review ORDER BY NEWID();
        INSERT INTO DANH_GIA (MaDG, DiemChatLuong, DiemThaiDo, DiemHaiLong, BinhLuan, NgayDG, MaHD, MaKH, MaNV)
        VALUES ('DG'+CAST(@CountHD AS VARCHAR), @DiemDG, @DiemDG, @DiemDG, @Cmt, DATEADD(DAY, 1, @DateRun), @MaHD, @MaKH, @MaNV);
    END

    SET @CountHD = @CountHD + 1;
    IF (@CountHD % 2000) = 0 BEGIN COMMIT TRANSACTION; BEGIN TRANSACTION; PRINT '... Đã tạo ' + CAST(@CountHD AS VARCHAR); END
END
COMMIT TRANSACTION;
GO

-----------------------------------------------------------------------------
-- BƯỚC 5: HR (FIX: CHẤM CÔNG & GIỜ LÀM KHÁC NHAU)
-----------------------------------------------------------------------------
PRINT '--> Sinh dữ liệu HR (Phân ca & Chấm công FULL nhân viên)...';

-- 1. Phân ca (Random CA1, CA2, CA3 cho toàn bộ NV)
DELETE FROM BANG_PHAN_CA;
INSERT INTO BANG_PHAN_CA (MaCa, MaNV, NgayLamViec)
SELECT 
    'CA' + CAST((ABS(CHECKSUM(NEWID())) % 3) + 1 AS VARCHAR),
    MaNV, 
    '2024-01-01' 
FROM NHAN_VIEN;

-- 2. Chấm công & Lương
DECLARE @DateRun DATE = '2023-01-01';
DECLARE @EndRun DATE = GETDATE();

WHILE @DateRun <= @EndRun
BEGIN
    IF DATEPART(dw, @DateRun) <> 1 
    BEGIN
        -- FIX: Insert cho TẤT CẢ nhân viên với giờ Checkin/out random khác nhau
        INSERT INTO CHAM_CONG (MaNV, NgayLamViec, Checkin, Checkout)
        SELECT 
            MaNV, 
            @DateRun, 
            DATEADD(MINUTE, ABS(CHECKSUM(NEWID()))%90, '07:30'), -- Random từ 7:30 - 9:00
            DATEADD(MINUTE, ABS(CHECKSUM(NEWID()))%90, '16:30')  -- Random từ 16:30 - 18:00
        FROM NHAN_VIEN;
    END

    IF @DateRun = EOMONTH(@DateRun)
    BEGIN
        -- FIX: Giờ công tháng random để biết ai năng suất hơn
        INSERT INTO BANG_LUONG_THANG (MaNV, Thang, Nam, TongGioCong, LuongCoBan, Thuong, TongLuong, NgayTinhLuong)
        SELECT MaNV, MONTH(@DateRun), YEAR(@DateRun), 
               160 + (ABS(CHECKSUM(NEWID()))%60), -- Giờ công từ 160h đến 220h
               LuongCoBan, 
               CASE WHEN (ABS(CHECKSUM(NEWID()))%10)=0 THEN 1000000 ELSE 0 END,
               0, DATEADD(DAY, 5, @DateRun)
        FROM NHAN_VIEN;
        
        UPDATE BANG_LUONG_THANG SET TongLuong = LuongCoBan + Thuong 
        WHERE Thang=MONTH(@DateRun) AND Nam=YEAR(@DateRun);
    END
    SET @DateRun = DATEADD(DAY, 1, @DateRun);
END

INSERT INTO LICH_SU_DIEU_DONG (MaDieuDong, NgayBatDau, NgayKetThuc, MaCN) VALUES ('DD01', '2023-06-01', '2023-12-31', 'CN2');
INSERT INTO CHI_TIET_DD (MaNV, MaDieuDong, NgayBatDau) VALUES ('NV1', 'DD01', '2023-06-01');
GO

-----------------------------------------------------------------------------
-- BƯỚC 6: DỌN DẸP
-----------------------------------------------------------------------------
DROP TABLE #Ho; DROP TABLE #TenDem; DROP TABLE #Ten; DROP TABLE #TrieuChung; DROP TABLE #Review; DROP TABLE #ProductData; DROP TABLE #SucKhoe;
PRINT '--> Bật lại ràng buộc...';
EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all';
GO
PRINT '>>> HOÀN TẤT! (Dữ liệu đã đa dạng hóa hoàn toàn)';