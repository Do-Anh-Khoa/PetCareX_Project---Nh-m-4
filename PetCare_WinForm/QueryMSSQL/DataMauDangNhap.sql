INSERT INTO NHAN_VIEN
(MaNV, HoTen, NgaySinh, GioiTinh, NgayVaoLam, ChucVu, LuongCoBan, MaCN, UserName)
VALUES
('BS1_test', N'Nguyễn Văn An', '1990-03-15', N'Nam', '2024-01-10', N'BacSi',    30000000, 'CN1', 'BS_an01'),
('QL1_test', N'Trần Thị Mai',  '1985-07-22', N'Nữ',  '2023-09-01', N'QuanLy',   25000000, 'CN1', 'QL_mai01'),
('NV1_test', N'Lê Hoàng Minh', '1998-11-05', N'Nam', '2025-02-18', N'NhanVien', 12000000, 'CN1', 'NV_minh01');

INSERT INTO TAI_KHOAN
(UserName, MatKhau, QuyenHan)
VALUES
('BS_an01',  '123456', 'BacSi'),
('QL_mai01', '123456', 'QuanLy'),
('NV_minh01','123456', 'NhanVien');