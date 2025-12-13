USE data8; -- Nhớ đổi tên DB cho đúng
GO

-- 1. BẢNG TÀI KHOẢN
create table TAI_KHOAN
( 
  UserName nvarchar(100) NOT NULL, -- Giữ nguyên, thêm NOT NULL
  MatKhau varchar(100) NOT NULL,   -- Thêm NOT NULL
  QuyenHan nvarchar(100) NOT NULL, -- Thêm NOT NULL
  primary key(UserName)
)
GO

-- 2. BẢNG CHI NHÁNH
create table CHI_NHANH
( 
  MaCN varchar (20) NOT NULL,
  TenChiNhanh nvarchar (100) NOT NULL, -- Thêm NOT NULL
  DiaChi nvarchar(100) NOT NULL,       -- Thêm NOT NULL
  SoDienThoai varchar (100) NOT NULL,  -- Thêm NOT NULL
  GioMoCua time,
  GioDongCua time,
  primary key(MaCN)
)
GO

-- 3. BẢNG NHÂN VIÊN
create table NHAN_VIEN
( 
  MaNV varchar(20) NOT NULL,
  HoTen nvarchar(100) NOT NULL,    -- Thêm NOT NULL
  NgaySinh Date NOT NULL,          -- Thêm NOT NULL
  GioiTinh nvarchar (100) NOT NULL,-- Thêm NOT NULL
  NgayVaoLam date NOT NULL,        -- Thêm NOT NULL
  ChucVu nvarchar (100) NOT NULL,  -- Thêm NOT NULL
  LuongCoBan decimal(18, 0) CHECK (LuongCoBan > 0), -- Giữ nguyên kiểu Decimal và Check cũ
  MaCN varchar(20) NOT NULL,       -- Thêm NOT NULL
  UserName nvarchar(100),
  primary key(MaNV),
  foreign key (MaCN) references CHI_NHANH(MaCN),
  foreign key(UserName) references TAI_KHOAN(UserName)
)
GO

-- 4. BẢNG LỊCH SỬ ĐIỀU ĐỘNG
create table LICH_SU_DIEU_DONG
( 
  MaDieuDong varchar(20) NOT NULL,
  NgayBatDau date NOT NULL,       -- Thêm NOT NULL
  NgayKetThuc date,
  MaCN varchar(20) NOT NULL,      -- Thêm NOT NULL
  primary key(MaDieuDong,NgayBatDau),
  foreign key(MaCN) references CHI_NHANH(MaCN)
)
GO

create table CHI_TIET_DD
( 
  MaNV varchar(20) NOT NULL,
  MaDieuDong varchar(20) NOT NULL,
  NgayBatDau date NOT NULL,
  primary key ( MaNV,MaDieuDong,NgayBatDau),
  foreign key(MaNV) references NHAN_VIEN(MaNV),
  foreign key (MaDieuDong, NgayBatDau) references LICH_SU_DIEU_DONG(MaDieuDong, NgayBatDau)
)
GO

-- 5. BẢNG VACCINE
create table VACCINE
(
  MaVC varchar(20) NOT NULL,
  TenVC nvarchar(100) NOT NULL,   -- Thêm NOT NULL
  LoaiVC nvarchar(100) NOT NULL,  -- Thêm NOT NULL
  GiaVC float CHECK (GiaVC >= 0), -- Giữ nguyên float, thêm Check >= 0
  primary key(MaVC)
)
GO

-- 6. BẢNG KHÁCH HÀNG
create table KHACH_HANG
( 
  MaKH varchar(20) NOT NULL,
  HoTen nvarchar(100) NOT NULL,   -- Thêm NOT NULL
  SoDT nvarchar(100) NOT NULL,    -- Thêm NOT NULL
  Email nvarchar(100),
  CCCD nvarchar(100),
  GioiTinh nvarchar(100),
  NgaySinh date,
  CapHoiVien nvarchar(100) DEFAULT 'CoBan', -- Thêm giá trị mặc định
  DiemTichLuy int DEFAULT 0,                -- Thêm giá trị mặc định 0
  UserName nvarchar(100),
  primary key(MaKH),
  foreign key(UserName) references TAI_KHOAN(UserName)
)
GO

-- 7. BẢNG THÚ CƯNG
create table THU_CUNG
( 
  MaTC varchar(20) NOT NULL,
  TenTC nvarchar (100) NOT NULL,  -- Thêm NOT NULL
  Loai nvarchar (100) NOT NULL,   -- Thêm NOT NULL
  Giong nvarchar(100),
  TinhTrangSucKhoe nvarchar(100),
  MaKH varchar(20) NOT NULL,      -- Thêm NOT NULL
  primary key(MaTC),
  foreign key(MaKH) references KHACH_HANG(MaKH)
)
GO

-- 8. BẢNG HÓA ĐƠN
create table HOA_DON
( 
  MaHD varchar(20) NOT NULL,
  NgayLap date NOT NULL DEFAULT GETDATE(), -- Thêm NOT NULL và mặc định ngày hiện tại
  TongTien decimal(18, 0) DEFAULT 0 CHECK (TongTien >= 0), -- Giữ decimal, thêm Default và Check
  KhuyenMai nvarchar(100),
  HinhThucThanhToan nvarchar(100) NOT NULL, -- Thêm NOT NULL
  MaNV varchar(20) NOT NULL,      -- Thêm NOT NULL
  MaKH varchar(20) NOT NULL,      -- Thêm NOT NULL
  MaCN varchar(20) NOT NULL,      -- Thêm NOT NULL
  primary key(MaHD),
  foreign key(MaNV) references NHAN_VIEN(MaNV),
  foreign key(MaKH) references KHACH_HANG(MaKH),
  foreign key(MaCN) references CHI_NHANH(MaCN)
)
GO

create table DANH_GIA
( 
  MaDG varchar(20) NOT NULL,
  DiemChatLuong float CHECK (DiemChatLuong BETWEEN 0 AND 10),
  DiemThaiDo float CHECK (DiemThaiDo BETWEEN 0 AND 10),
  DiemHaiLong float,
  BinhLuan nvarchar(500),
  NgayDG date DEFAULT GETDATE(), -- Thêm mặc định ngày hiện tại
  MaHD varchar(20) NOT NULL,     -- Thêm NOT NULL
  MaKH varchar(20),
  MaNV varchar(20),
  primary key(MaDG),
  foreign key (MaKH) references KHACH_HANG(MaKH),
  foreign key (MaHD) references HOA_DON(MaHD),
  foreign key (MaNV) references NHAN_VIEN(MaNV)
)
GO

-- 9. DỊCH VỤ
create table DICH_VU
( 
  MaDV varchar(20) NOT NULL,
  MaTC varchar(20) NULL,
  MaCN varchar(20) NOT NULL,      -- Thêm NOT NULL
  primary key(MaDV),
  foreign key(MaTC) references THU_CUNG(MaTC),
  foreign key(MaCN) references CHI_NHANH(MaCN)
)
GO

create table CHI_TIET_DV_SD
( 
  MaHD varchar(20) NOT NULL,
  MaDV varchar(20) NOT NULL,
  primary key( MaHD,MaDV),
  foreign key(MaHD) references HOA_DON(MaHD),
  foreign key (MaDV) references DICH_VU(MaDV)
)
GO

create table DV_KHAM
( 
  MaKham varchar (20) NOT NULL,
  TrieuChung nvarchar(100),
  ChuanDoan nvarchar(100),
  ToaThuoc  nvarchar(100),
  BacSiPhuTrach varchar(20) NOT NULL, -- Thêm NOT NULL
  NgayTaiKham Date,
  GiaKhamBenh float CHECK (GiaKhamBenh >= 0), -- Giữ float, thêm Check >= 0
  primary key(MaKham),
  foreign key (BacSiPhuTrach) references NHAN_VIEN(MaNV),
  foreign key(MaKham) references DICH_VU(MaDV)
)
GO

create table DV_TIEM_PHONG_DON_LE
(
  MaTiem varchar (20) NOT NULL,
  BacSiPhuTrach varchar(20) NOT NULL, -- Thêm NOT NULL
  primary key(MaTiem),
  foreign key (MaTiem) references DICH_VU(MaDV),
  foreign key (BacSiPhuTrach) references NHAN_VIEN(MaNV)
)
GO

create table CHI_TIET_TIEM
(
  MaVC varchar(20) NOT NULL,
  MaTiem varchar (20) NOT NULL,
  NgayTiem date NOT NULL,         -- Thêm NOT NULL
  LieuLuong int CHECK (LieuLuong > 0),
  Gia float CHECK (Gia >= 0),     -- Giữ float, thêm Check >= 0
  primary key( MaVC,MaTiem),
  foreign key(MaTiem) references DV_TIEM_PHONG_DON_LE(MaTiem),
  foreign key(MaVC) references VACCINE(MaVC)
)
GO

-- 10. GÓI TIÊM
create table DV_TIEM_PHONG_THEO_THANG
( 
  MaGoi varchar(20) NOT NULL,
  TenGoi nvarchar(100) NOT NULL,  -- Thêm NOT NULL
  SoThang int CHECK (SoThang > 0),
  NgayDK date NOT NULL,           -- Thêm NOT NULL
  NgayKT date NOT NULL,           -- Thêm NOT NULL
  GiaGoi float CHECK (GiaGoi >= 0), -- Giữ float, thêm Check
  BacSiPhuTrach varchar(20),
  primary key (MaGoi),
  foreign key(MaGoi) references DICH_VU(MaDV),
  foreign key(BacSiPhuTrach) references NHAN_VIEN(MaNV)
)
GO

create table CHI_TIET_TIEM_THANG
(
  MaVC varchar(20) NOT NULL,
  MaGoi varchar(20) NOT NULL,
  LieuLuong int CHECK (LieuLuong > 0),
  NgayTiem date,
  LanTiem int CHECK (LanTiem > 0),
  primary key(MaVC, MaGoi,LanTiem),
  foreign key (MaVC) references VACCINE(MaVC),
  foreign key (MaGoi) references DV_TIEM_PHONG_THEO_THANG(MaGoi)
)
GO

-- 11. BÁN HÀNG
create table SAN_PHAM
(
  MaSP varchar(20) NOT NULL,
  TenSP nvarchar(100) NOT NULL,   -- Thêm NOT NULL
  LoaiSP nvarchar(100) NOT NULL,  -- Thêm NOT NULL
  GiaBan float CHECK (GiaBan >= 0), -- Giữ float, thêm Check
  primary key (MaSP)
)
GO

create table DV_MUA_HANG
( 
  MaMuaHang varchar (20) NOT NULL,
  NhanVienBanHang varchar(20) NOT NULL, -- Thêm NOT NULL
  primary key(MaMuaHang),
  foreign key(NhanVienBanHang) references NHAN_VIEN(MaNV),
  foreign key(MaMuaHang) references DICH_VU(MaDV)
)
GO

create table CHI_TIET_MUA_HANG
( 
  SoLuong int CHECK (SoLuong > 0), -- Giữ nguyên Check
  DonGia float CHECK (DonGia >= 0), -- Giữ float, thêm Check
  MaMuaHang varchar(20) NOT NULL,
  MaSP varchar(20) NOT NULL,
  primary key(MaSP, MaMuaHang),
  foreign key(MaSP) references SAN_PHAM(MaSP),
  foreign key(MaMuaHang) references DV_MUA_HANG(MaMuaHang)
)
GO

-- 12. KHO HÀNG
CREATE TABLE TON_KHO_SAN_PHAM
(
  MaCN varchar(20) NOT NULL,
  MaSP varchar(20) NOT NULL,
  SoLuong int DEFAULT 0 CHECK (SoLuong >= 0), -- Thêm Default 0 và Check >= 0
  NgaySanXuat date,
  NgayHetHan date,
  PRIMARY KEY (MaCN, MaSP),
  FOREIGN KEY (MaCN) REFERENCES CHI_NHANH(MaCN),
  FOREIGN KEY (MaSP) REFERENCES SAN_PHAM(MaSP)
)
GO

CREATE TABLE TON_KHO_VACCINE
(
  MaCN varchar(20) NOT NULL,
  MaVC varchar(20) NOT NULL,
  SoLo varchar(50) NOT NULL,      -- Thêm NOT NULL
  SoLuong int DEFAULT 0 CHECK (SoLuong >= 0), -- Thêm Default 0 và Check >= 0
  NgaySanXuat date,
  NgayHetHan date,
  PRIMARY KEY (MaCN, MaVC, SoLo), 
  FOREIGN KEY (MaCN) REFERENCES CHI_NHANH(MaCN),
  FOREIGN KEY (MaVC) REFERENCES VACCINE(MaVC)
)
GO

-- 13. CHẤM CÔNG & LƯƠNG
create table CA_LAM_VIEC
(
  MaCa varchar(20) NOT NULL,
  TenCa nvarchar(100) NOT NULL,   -- Thêm NOT NULL
  GioBD time,
  GioKT time,
  primary key (MaCa)
)
GO

create table BANG_PHAN_CA
(
  MaCa varchar(20) NOT NULL,
  MaNV varchar(20) NOT NULL,
  NgayLamViec date NOT NULL,      -- Thêm NOT NULL
  primary key (MaCa, MaNV,NgayLamViec),
  foreign key(MaNV) references NHAN_VIEN(MaNV),
  foreign key (MaCa) references CA_LAM_VIEC(MaCa)
)
GO

create table BANG_LUONG_THANG
( 
  MaNV varchar(20) NOT NULL,
  Thang int NOT NULL,
  Nam int NOT NULL,
  TongGioCong int DEFAULT 0,
  LuongCoBan decimal(18,0), -- Giữ nguyên kiểu Decimal của bạn
  Thuong decimal(18,0) DEFAULT 0,
  TongLuong decimal(18,0),
  NgayTinhLuong date DEFAULT GETDATE(),
  primary key(MaNV,Thang, Nam),
  foreign key(MaNV) references NHAN_VIEN(MaNV) on delete cascade
)
GO

create table CHAM_CONG
( 
  MaNV varchar(20) NOT NULL,
  NgayLamViec date NOT NULL,
  Checkin time,
  Checkout time,
  primary key( MaNV,NgayLamViec),
  foreign key(MaNV) references NHAN_VIEN(MaNV) on delete cascade
)
GO