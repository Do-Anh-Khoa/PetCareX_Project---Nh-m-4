USE PetCareX_DB;
GO

PRINT '========================================';
PRINT 'BƯỚC 1: XÓA CÁC INDEX DƯ THỪA/TRÙNG LẶP';
PRINT '========================================';
GO

-- XÓA INDEX TRÙNG LẶP/DƯ THỪA
-- HOA_DON
DROP INDEX IF EXISTS IX_HOA_DON_NgayLap ON HOA_DON;
DROP INDEX IF EXISTS IX_HOA_DON_NgayLap_TrangThai ON HOA_DON; -- Giữ IX_HOA_DON_MaCN_NgayLap

-- CHI_TIET_DV_SD (Chỉ giữ 1 bộ)
-- Không cần DROP vì sẽ gặp lỗi duplicate, chỉ tạo nếu chưa có

-- CHI_TIET_MUA_HANG (Tương tự)
-- Không cần DROP

-- DV_KHAM (Xóa duplicate)
-- Giữ IX_DV_KHAM_BacSiPhuTrach, xóa IX_DV_KHAM_MaKham_BacSi vì MaKham là PK
DROP INDEX IF EXISTS IX_DV_KHAM_MaKham_BacSi ON DV_KHAM;

-- DICH_VU (Xóa duplicate)
DROP INDEX IF EXISTS IX_DICH_VU_MaCN ON DICH_VU; -- Giữ IX_DICH_VU_MaDV_MaCN

-- NHAN_VIEN (PK đã có index)
DROP INDEX IF EXISTS IX_NHAN_VIEN_MaNV_HoTen ON NHAN_VIEN;

-- CHI_NHANH (PK đã có index)
DROP INDEX IF EXISTS IX_CHI_NHANH_MaCN_TenChiNhanh ON CHI_NHANH;
-- Giữ IX_CHI_NHANH_TenChiNhanh cho tìm kiếm theo tên

-- SAN_PHAM (PK đã có index)
DROP INDEX IF EXISTS IX_SAN_PHAM_MaSP_TenSP ON SAN_PHAM;

-- KHACH_HANG (LIKE '%text%' không hiệu quả, xóa)
DROP INDEX IF EXISTS IX_KHACH_HANG_HoTen ON KHACH_HANG;

-- DV_MUA_HANG (PK đã có index)
DROP INDEX IF EXISTS IX_DV_MUA_HANG_MaMuaHang ON DV_MUA_HANG;

PRINT 'Đã xóa các index dư thừa!';
GO

PRINT '========================================';
PRINT 'BƯỚC 2: TẠO LẠI INDEX TỐI ƯU';
PRINT '========================================';
GO

-- =====================================================
-- NHÓM 1: HOA_DON (Bảng quan trọng nhất)
-- =====================================================

-- 1. Index CHÍNH cho WHERE + JOIN
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HOA_DON_MaCN_NgayLap_TrangThai' AND object_id = OBJECT_ID('HOA_DON'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_HOA_DON_MaCN_NgayLap_TrangThai
    ON HOA_DON(MaCN, NgayLap, TrangThai)
    INCLUDE (MaHD, TongTien, MaKH, MaNV)
    WITH (FILLFACTOR = 90, PAD_INDEX = ON);
END
GO

-- 2. Index cho tìm theo trạng thái
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HOA_DON_TrangThai_NgayLap' AND object_id = OBJECT_ID('HOA_DON'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_HOA_DON_TrangThai_NgayLap
    ON HOA_DON(TrangThai, NgayLap DESC)
    INCLUDE (MaKH, TongTien, MaCN)
    WITH (FILLFACTOR = 90);
END
GO

-- 3. Index cho tìm theo khách hàng
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HOA_DON_MaKH_TrangThai' AND object_id = OBJECT_ID('HOA_DON'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_HOA_DON_MaKH_TrangThai
    ON HOA_DON(MaKH, TrangThai)
    INCLUDE (NgayLap, TongTien, MaNV, MaCN)
    WITH (FILLFACTOR = 90);
END
GO

-- =====================================================
-- NHÓM 2: CHI_TIET_DV_SD (Bảng liên kết)
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_CHI_TIET_DV_SD_MaDV_MaHD' AND object_id = OBJECT_ID('CHI_TIET_DV_SD'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_CHI_TIET_DV_SD_MaDV_MaHD
    ON CHI_TIET_DV_SD(MaDV, MaHD)
    WITH (FILLFACTOR = 95);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_CHI_TIET_DV_SD_MaHD' AND object_id = OBJECT_ID('CHI_TIET_DV_SD'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_CHI_TIET_DV_SD_MaHD
    ON CHI_TIET_DV_SD(MaHD)
    INCLUDE (MaDV)
    WITH (FILLFACTOR = 95);
END
GO

-- =====================================================
-- NHÓM 3: CHI_TIET_MUA_HANG
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_CHI_TIET_MUA_HANG_MaSP' AND object_id = OBJECT_ID('CHI_TIET_MUA_HANG'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_CHI_TIET_MUA_HANG_MaSP
    ON CHI_TIET_MUA_HANG(MaSP)
    INCLUDE (MaMuaHang, SoLuong, DonGia)
    WITH (FILLFACTOR = 90);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_CHI_TIET_MUA_HANG_MaMuaHang' AND object_id = OBJECT_ID('CHI_TIET_MUA_HANG'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_CHI_TIET_MUA_HANG_MaMuaHang
    ON CHI_TIET_MUA_HANG(MaMuaHang)
    INCLUDE (MaSP, SoLuong, DonGia)
    WITH (FILLFACTOR = 90);
END
GO

-- =====================================================
-- NHÓM 4: KHACH_HANG
-- =====================================================

-- Chỉ giữ index cho SoDT (exact match hiệu quả)
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_KHACH_HANG_SoDT' AND object_id = OBJECT_ID('KHACH_HANG'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_KHACH_HANG_SoDT
    ON KHACH_HANG(SoDT)
    INCLUDE (HoTen, Email, CapHoiVien, DiemTichLuy, MaKH)
    WITH (FILLFACTOR = 95);
END
GO

-- =====================================================
-- NHÓM 5: THU_CUNG
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_THU_CUNG_MaKH' AND object_id = OBJECT_ID('THU_CUNG'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_THU_CUNG_MaKH
    ON THU_CUNG(MaKH)
    INCLUDE (TenTC, Loai, Giong, TinhTrangSucKhoe)
    WITH (FILLFACTOR = 90);
END
GO

-- =====================================================
-- NHÓM 6: LICH_HEN
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_LICH_HEN_TrangThai_NgayHen' AND object_id = OBJECT_ID('LICH_HEN'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_LICH_HEN_TrangThai_NgayHen
    ON LICH_HEN(TrangThai, NgayHen DESC)
    INCLUDE (MaKH, MaBS, MaCN, GioHen, GhiChu)
    WITH (FILLFACTOR = 90);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_LICH_HEN_MaBS_NgayHen' AND object_id = OBJECT_ID('LICH_HEN'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_LICH_HEN_MaBS_NgayHen
    ON LICH_HEN(MaBS, NgayHen DESC)
    INCLUDE (TrangThai, MaKH)
    WITH (FILLFACTOR = 90);
END
GO

-- =====================================================
-- NHÓM 7: DV_KHAM
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DV_KHAM_BacSiPhuTrach' AND object_id = OBJECT_ID('DV_KHAM'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_DV_KHAM_BacSiPhuTrach
    ON DV_KHAM(BacSiPhuTrach)
    INCLUDE (MaKham, GiaKhamBenh, TrieuChung, ChuanDoan)
    WITH (FILLFACTOR = 90);
END
GO

-- =====================================================
-- NHÓM 8: DICH_VU (Bảng trung tâm)
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DICH_VU_MaDV_MaCN' AND object_id = OBJECT_ID('DICH_VU'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_DICH_VU_MaDV_MaCN
    ON DICH_VU(MaDV, MaCN)
    INCLUDE (MaTC)
    WITH (FILLFACTOR = 95);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DICH_VU_MaTC' AND object_id = OBJECT_ID('DICH_VU'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_DICH_VU_MaTC
    ON DICH_VU(MaTC)
    INCLUDE (MaDV, MaCN)
    WITH (FILLFACTOR = 90);
END
GO

-- =====================================================
-- NHÓM 9: NHAN_VIEN
-- =====================================================

-- Index cho tìm theo chức vụ (quan trọng cho báo cáo)
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_NHAN_VIEN_ChucVu_MaCN' AND object_id = OBJECT_ID('NHAN_VIEN'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_NHAN_VIEN_ChucVu_MaCN
    ON NHAN_VIEN(ChucVu, MaCN)
    INCLUDE (HoTen, LuongCoBan)
    WITH (FILLFACTOR = 95);
END
GO

-- Index cho tìm theo chi nhánh
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_NHAN_VIEN_MaCN' AND object_id = OBJECT_ID('NHAN_VIEN'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_NHAN_VIEN_MaCN
    ON NHAN_VIEN(MaCN)
    INCLUDE (HoTen, ChucVu)
    WITH (FILLFACTOR = 95);
END
GO

-- =====================================================
-- NHÓM 10: BANG_PHAN_CA
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_BANG_PHAN_CA_MaNV_NgayLamViec' AND object_id = OBJECT_ID('BANG_PHAN_CA'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_BANG_PHAN_CA_MaNV_NgayLamViec
    ON BANG_PHAN_CA(MaNV, NgayLamViec DESC)
    INCLUDE (MaCa)
    WITH (FILLFACTOR = 85);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_BANG_PHAN_CA_NgayLamViec' AND object_id = OBJECT_ID('BANG_PHAN_CA'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_BANG_PHAN_CA_NgayLamViec
    ON BANG_PHAN_CA(NgayLamViec DESC)
    INCLUDE (MaNV, MaCa)
    WITH (FILLFACTOR = 85);
END
GO

-- =====================================================
-- NHÓM 11: CHAM_CONG
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_CHAM_CONG_MaNV_NgayLamViec' AND object_id = OBJECT_ID('CHAM_CONG'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_CHAM_CONG_MaNV_NgayLamViec
    ON CHAM_CONG(MaNV, NgayLamViec DESC)
    INCLUDE (Checkin, Checkout)
    WITH (FILLFACTOR = 85);
END
GO

-- =====================================================
-- NHÓM 12: BANG_LUONG_THANG
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_BANG_LUONG_THANG_Thang_Nam' AND object_id = OBJECT_ID('BANG_LUONG_THANG'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_BANG_LUONG_THANG_Thang_Nam
    ON BANG_LUONG_THANG(Nam DESC, Thang DESC)
    INCLUDE (MaNV, TongLuong, TongGioCong)
    WITH (FILLFACTOR = 90);
END
GO

-- =====================================================
-- NHÓM 13: SAN_PHAM
-- =====================================================

-- Chỉ giữ index cho LoaiSP (GROUP BY)
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SAN_PHAM_LoaiSP' AND object_id = OBJECT_ID('SAN_PHAM'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_SAN_PHAM_LoaiSP
    ON SAN_PHAM(LoaiSP)
    INCLUDE (MaSP, TenSP, GiaBan)
    WITH (FILLFACTOR = 95);
END
GO

-- =====================================================
-- NHÓM 14: TON_KHO_SAN_PHAM
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_TON_KHO_SAN_PHAM_MaCN_MaSP' AND object_id = OBJECT_ID('TON_KHO_SAN_PHAM'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_TON_KHO_SAN_PHAM_MaCN_MaSP
    ON TON_KHO_SAN_PHAM(MaCN, MaSP)
    INCLUDE (SoLuong, NgayHetHan)
    WITH (FILLFACTOR = 90);
END
GO

-- =====================================================
-- NHÓM 15: DV_MUA_HANG
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DV_MUA_HANG_NhanVienBanHang' AND object_id = OBJECT_ID('DV_MUA_HANG'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_DV_MUA_HANG_NhanVienBanHang
    ON DV_MUA_HANG(NhanVienBanHang)
    INCLUDE (MaMuaHang)
    WITH (FILLFACTOR = 95);
END
GO

-- =====================================================
-- NHÓM 16: TIÊM PHÒNG
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DV_TIEM_PHONG_DON_LE_BacSiPhuTrach' AND object_id = OBJECT_ID('DV_TIEM_PHONG_DON_LE'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_DV_TIEM_PHONG_DON_LE_BacSiPhuTrach
    ON DV_TIEM_PHONG_DON_LE(BacSiPhuTrach)
    INCLUDE (MaTiem)
    WITH (FILLFACTOR = 95);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DV_TIEM_PHONG_THEO_THANG_NgayDK_NgayKT' AND object_id = OBJECT_ID('DV_TIEM_PHONG_THEO_THANG'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_DV_TIEM_PHONG_THEO_THANG_NgayDK_NgayKT
    ON DV_TIEM_PHONG_THEO_THANG(NgayDK, NgayKT)
    INCLUDE (MaGoi, TenGoi, BacSiPhuTrach, GiaGoi)
    WITH (FILLFACTOR = 90);
END
GO

-- =====================================================
-- NHÓM 17: CHI_NHANH
-- =====================================================

-- Chỉ cần index cho tìm theo tên
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_CHI_NHANH_TenChiNhanh' AND object_id = OBJECT_ID('CHI_NHANH'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_CHI_NHANH_TenChiNhanh
    ON CHI_NHANH(TenChiNhanh)
    INCLUDE (DiaChi, SoDienThoai)
    WITH (FILLFACTOR = 100); -- Ít thay đổi
END
GO

-- =====================================================
-- NHÓM 18: DANH_GIA
-- =====================================================

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DANH_GIA_MaHD' AND object_id = OBJECT_ID('DANH_GIA'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_DANH_GIA_MaHD
    ON DANH_GIA(MaHD)
    INCLUDE (DiemChatLuong, DiemThaiDo, DiemHaiLong, NgayDG)
    WITH (FILLFACTOR = 90);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DANH_GIA_MaKH_NgayDG' AND object_id = OBJECT_ID('DANH_GIA'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_DANH_GIA_MaKH_NgayDG
    ON DANH_GIA(MaKH, NgayDG DESC)
    INCLUDE (DiemHaiLong, MaNV)
    WITH (FILLFACTOR = 90);
END
GO

PRINT '========================================';
PRINT 'BƯỚC 3: CẬP NHẬT STATISTICS';
PRINT '========================================';
GO

-- Cập nhật statistics cho các bảng quan trọng
UPDATE STATISTICS HOA_DON WITH FULLSCAN;
UPDATE STATISTICS CHI_TIET_DV_SD WITH FULLSCAN;
UPDATE STATISTICS DV_KHAM WITH FULLSCAN;
UPDATE STATISTICS DICH_VU WITH FULLSCAN;
UPDATE STATISTICS CHI_TIET_MUA_HANG WITH FULLSCAN;
GO

PRINT '========================================';
PRINT 'BƯỚC 4: BẬT TỰ ĐỘNG CẬP NHẬT STATISTICS';
PRINT '========================================';
GO

ALTER DATABASE PetCareX_DB SET AUTO_CREATE_STATISTICS ON;
ALTER DATABASE PetCareX_DB SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE PetCareX_DB SET AUTO_UPDATE_STATISTICS_ASYNC ON;
GO

PRINT '========================================';
PRINT 'HOÀN TẤT TỐI ƯU INDEX!';
PRINT '========================================';
GO

-- Kiểm tra kết quả
SELECT 
    OBJECT_NAME(i.object_id) AS TableName,
    COUNT(*) AS TotalIndexes,
    SUM(CASE WHEN i.type_desc = 'CLUSTERED' THEN 1 ELSE 0 END) AS ClusteredIndexes,
    SUM(CASE WHEN i.type_desc = 'NONCLUSTERED' THEN 1 ELSE 0 END) AS NonClusteredIndexes
FROM sys.indexes i
WHERE OBJECT_NAME(i.object_id) IN (
    'HOA_DON', 'CHI_TIET_DV_SD', 'CHI_TIET_MUA_HANG', 'KHACH_HANG',
    'THU_CUNG', 'LICH_HEN', 'DV_KHAM', 'DICH_VU', 'NHAN_VIEN',
    'BANG_PHAN_CA', 'CHAM_CONG', 'BANG_LUONG_THANG', 'SAN_PHAM',
    'TON_KHO_SAN_PHAM', 'DV_MUA_HANG', 'CHI_NHANH', 'DANH_GIA'
)
GROUP BY OBJECT_NAME(i.object_id)
ORDER BY TableName;
GO