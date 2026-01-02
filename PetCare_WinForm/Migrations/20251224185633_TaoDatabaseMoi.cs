using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCare_WinForm.Migrations
{
    /// <inheritdoc />
    public partial class TaoDatabaseMoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CA_LAM_VIEC",
                columns: table => new
                {
                    MaCa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenCa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GioBD = table.Column<TimeOnly>(type: "time", nullable: true),
                    GioKT = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CA_LAM_V__27258E7B48C600E7", x => x.MaCa);
                });

            migrationBuilder.CreateTable(
                name: "CHI_NHANH",
                columns: table => new
                {
                    MaCN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenChiNhanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    GioMoCua = table.Column<TimeOnly>(type: "time", nullable: true),
                    GioDongCua = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHI_NHAN__27258E0E5D479839", x => x.MaCN);
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAM",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GiaBan = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SAN_PHAM__2725081C821B278D", x => x.MaSP);
                });

            migrationBuilder.CreateTable(
                name: "TAI_KHOAN",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    QuyenHan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TAI_KHOA__C9F284578A51C119", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "VACCINE",
                columns: table => new
                {
                    MaVC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenVC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiVC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GiaVC = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VACCINE__272510291D0746B1", x => x.MaVC);
                });

            migrationBuilder.CreateTable(
                name: "LICH_SU_DIEU_DONG",
                columns: table => new
                {
                    MaDieuDong = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NgayBatDau = table.Column<DateOnly>(type: "date", nullable: false),
                    NgayKetThuc = table.Column<DateOnly>(type: "date", nullable: true),
                    MaCN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LICH_SU___8070C1A4096C6650", x => new { x.MaDieuDong, x.NgayBatDau });
                    table.ForeignKey(
                        name: "FK__LICH_SU_DI__MaCN__403A8C7D",
                        column: x => x.MaCN,
                        principalTable: "CHI_NHANH",
                        principalColumn: "MaCN");
                });

            migrationBuilder.CreateTable(
                name: "TON_KHO_SAN_PHAM",
                columns: table => new
                {
                    MaCN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaSP = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    NgaySanXuat = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayHetHan = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TON_KHO___F557DE8F86D1BECB", x => new { x.MaCN, x.MaSP });
                    table.ForeignKey(
                        name: "FK__TON_KHO_SA__MaCN__10566F31",
                        column: x => x.MaCN,
                        principalTable: "CHI_NHANH",
                        principalColumn: "MaCN");
                    table.ForeignKey(
                        name: "FK__TON_KHO_SA__MaSP__114A936A",
                        column: x => x.MaSP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateTable(
                name: "KHACH_HANG",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    CapHoiVien = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValue: "CoBan"),
                    DiemTichLuy = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHACH_HA__2725CF1E1C92EFAA", x => x.MaKH);
                    table.ForeignKey(
                        name: "FK__KHACH_HAN__UserN__4BAC3F29",
                        column: x => x.UserName,
                        principalTable: "TAI_KHOAN",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "NHAN_VIEN",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayVaoLam = table.Column<DateOnly>(type: "date", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MaCN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHAN_VIE__2725D70A7C80624E", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK__NHAN_VIEN__MaCN__3C69FB99",
                        column: x => x.MaCN,
                        principalTable: "CHI_NHANH",
                        principalColumn: "MaCN");
                    table.ForeignKey(
                        name: "FK__NHAN_VIEN__UserN__3D5E1FD2",
                        column: x => x.UserName,
                        principalTable: "TAI_KHOAN",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "TON_KHO_VACCINE",
                columns: table => new
                {
                    MaCN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaVC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SoLo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    NgaySanXuat = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayHetHan = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TON_KHO___49EBE3C785C7AE0A", x => new { x.MaCN, x.MaVC, x.SoLo });
                    table.ForeignKey(
                        name: "FK__TON_KHO_VA__MaCN__160F4887",
                        column: x => x.MaCN,
                        principalTable: "CHI_NHANH",
                        principalColumn: "MaCN");
                    table.ForeignKey(
                        name: "FK__TON_KHO_VA__MaVC__17036CC0",
                        column: x => x.MaVC,
                        principalTable: "VACCINE",
                        principalColumn: "MaVC");
                });

            migrationBuilder.CreateTable(
                name: "THU_CUNG",
                columns: table => new
                {
                    MaTC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenTC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Giong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TinhTrangSucKhoe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaKH = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__THU_CUNG__27250068331D9FB9", x => x.MaTC);
                    table.ForeignKey(
                        name: "FK__THU_CUNG__MaKH__4E88ABD4",
                        column: x => x.MaKH,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKH");
                });

            migrationBuilder.CreateTable(
                name: "BANG_LUONG_THANG",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    TongGioCong = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Thuong = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValue: 0m),
                    TongLuong = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    NgayTinhLuong = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BANG_LUO__563F494F5895B211", x => new { x.MaNV, x.Thang, x.Nam });
                    table.ForeignKey(
                        name: "FK__BANG_LUONG__MaNV__22751F6C",
                        column: x => x.MaNV,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BANG_PHAN_CA",
                columns: table => new
                {
                    MaCa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaNV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NgayLamViec = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BANG_PHA__2965A1F9EF20C9C3", x => new { x.MaCa, x.MaNV, x.NgayLamViec });
                    table.ForeignKey(
                        name: "FK__BANG_PHAN___MaCa__1CBC4616",
                        column: x => x.MaCa,
                        principalTable: "CA_LAM_VIEC",
                        principalColumn: "MaCa");
                    table.ForeignKey(
                        name: "FK__BANG_PHAN___MaNV__1BC821DD",
                        column: x => x.MaNV,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "CHAM_CONG",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NgayLamViec = table.Column<DateOnly>(type: "date", nullable: false),
                    Checkin = table.Column<TimeOnly>(type: "time", nullable: true),
                    Checkout = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHAM_CON__E402F82157058E57", x => new { x.MaNV, x.NgayLamViec });
                    table.ForeignKey(
                        name: "FK__CHAM_CONG__MaNV__25518C17",
                        column: x => x.MaNV,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_DD",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaDieuDong = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NgayBatDau = table.Column<DateOnly>(type: "date", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHI_TIET__7F22DB102308F20A", x => new { x.MaNV, x.MaDieuDong, x.NgayBatDau });
                    table.ForeignKey(
                        name: "FK__CHI_TIET_DD__440B1D61",
                        columns: x => new { x.MaDieuDong, x.NgayBatDau },
                        principalTable: "LICH_SU_DIEU_DONG",
                        principalColumns: new[] { "MaDieuDong", "NgayBatDau" });
                    table.ForeignKey(
                        name: "FK__CHI_TIET_D__MaNV__4316F928",
                        column: x => x.MaNV,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "HOA_DON",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NgayLap = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    TongTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValue: 0m),
                    KhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HinhThucThanhToan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaKH = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaCN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HOA_DON__2725A6E0061CBD2E", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK__HOA_DON__MaCN__5629CD9C",
                        column: x => x.MaCN,
                        principalTable: "CHI_NHANH",
                        principalColumn: "MaCN");
                    table.ForeignKey(
                        name: "FK__HOA_DON__MaKH__5535A963",
                        column: x => x.MaKH,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK__HOA_DON__MaNV__5441852A",
                        column: x => x.MaNV,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "LICH_HEN",
                columns: table => new
                {
                    MaLichHen = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NgayHen = table.Column<DateOnly>(type: "date", nullable: true),
                    GioHen = table.Column<TimeOnly>(type: "time", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MaKH = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MaBS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MaCN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LICH_HEN__150F264F7D807565", x => x.MaLichHen);
                    table.ForeignKey(
                        name: "FK__LICH_HEN__MaBS__29221CFB",
                        column: x => x.MaBS,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                    table.ForeignKey(
                        name: "FK__LICH_HEN__MaCN__2A164134",
                        column: x => x.MaCN,
                        principalTable: "CHI_NHANH",
                        principalColumn: "MaCN");
                    table.ForeignKey(
                        name: "FK__LICH_HEN__MaKH__282DF8C2",
                        column: x => x.MaKH,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKH");
                });

            migrationBuilder.CreateTable(
                name: "DICH_VU",
                columns: table => new
                {
                    MaDV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaTC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MaCN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DICH_VU__27258657F87657B6", x => x.MaDV);
                    table.ForeignKey(
                        name: "FK__DICH_VU__MaCN__619B8048",
                        column: x => x.MaCN,
                        principalTable: "CHI_NHANH",
                        principalColumn: "MaCN");
                    table.ForeignKey(
                        name: "FK__DICH_VU__MaTC__60A75C0F",
                        column: x => x.MaTC,
                        principalTable: "THU_CUNG",
                        principalColumn: "MaTC");
                });

            migrationBuilder.CreateTable(
                name: "DANH_GIA",
                columns: table => new
                {
                    MaDG = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DiemChatLuong = table.Column<double>(type: "float", nullable: true),
                    DiemThaiDo = table.Column<double>(type: "float", nullable: true),
                    DiemHaiLong = table.Column<double>(type: "float", nullable: true),
                    BinhLuan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayDG = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    MaHD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaKH = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MaNV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DANH_GIA__272586600BB6B5DA", x => x.MaDG);
                    table.ForeignKey(
                        name: "FK__DANH_GIA__MaHD__5CD6CB2B",
                        column: x => x.MaHD,
                        principalTable: "HOA_DON",
                        principalColumn: "MaHD");
                    table.ForeignKey(
                        name: "FK__DANH_GIA__MaKH__5BE2A6F2",
                        column: x => x.MaKH,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK__DANH_GIA__MaNV__5DCAEF64",
                        column: x => x.MaNV,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_DV_SD",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaDV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHI_TIET__4557FE855358D29E", x => new { x.MaHD, x.MaDV });
                    table.ForeignKey(
                        name: "FK__CHI_TIET_D__MaDV__656C112C",
                        column: x => x.MaDV,
                        principalTable: "DICH_VU",
                        principalColumn: "MaDV");
                    table.ForeignKey(
                        name: "FK__CHI_TIET_D__MaHD__6477ECF3",
                        column: x => x.MaHD,
                        principalTable: "HOA_DON",
                        principalColumn: "MaHD");
                });

            migrationBuilder.CreateTable(
                name: "DV_KHAM",
                columns: table => new
                {
                    MaKham = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TrieuChung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChuanDoan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToaThuoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BacSiPhuTrach = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NgayTaiKham = table.Column<DateOnly>(type: "date", nullable: true),
                    GiaKhamBenh = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DV_KHAM__653E9A7AC2196A6D", x => x.MaKham);
                    table.ForeignKey(
                        name: "FK__DV_KHAM__BacSiPh__693CA210",
                        column: x => x.BacSiPhuTrach,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                    table.ForeignKey(
                        name: "FK__DV_KHAM__MaKham__6A30C649",
                        column: x => x.MaKham,
                        principalTable: "DICH_VU",
                        principalColumn: "MaDV");
                });

            migrationBuilder.CreateTable(
                name: "DV_MUA_HANG",
                columns: table => new
                {
                    MaMuaHang = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NhanVienBanHang = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DV_MUA_H__0B031DE0DF3781DC", x => x.MaMuaHang);
                    table.ForeignKey(
                        name: "FK__DV_MUA_HA__MaMua__05D8E0BE",
                        column: x => x.MaMuaHang,
                        principalTable: "DICH_VU",
                        principalColumn: "MaDV");
                    table.ForeignKey(
                        name: "FK__DV_MUA_HA__NhanV__04E4BC85",
                        column: x => x.NhanVienBanHang,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "DV_TIEM_PHONG_DON_LE",
                columns: table => new
                {
                    MaTiem = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    BacSiPhuTrach = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DV_TIEM___4CC209DCBBA6217E", x => x.MaTiem);
                    table.ForeignKey(
                        name: "FK__DV_TIEM_P__BacSi__6E01572D",
                        column: x => x.BacSiPhuTrach,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                    table.ForeignKey(
                        name: "FK__DV_TIEM_P__MaTie__6D0D32F4",
                        column: x => x.MaTiem,
                        principalTable: "DICH_VU",
                        principalColumn: "MaDV");
                });

            migrationBuilder.CreateTable(
                name: "DV_TIEM_PHONG_THEO_THANG",
                columns: table => new
                {
                    MaGoi = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoThang = table.Column<int>(type: "int", nullable: true),
                    NgayDK = table.Column<DateOnly>(type: "date", nullable: false),
                    NgayKT = table.Column<DateOnly>(type: "date", nullable: false),
                    GiaGoi = table.Column<double>(type: "float", nullable: true),
                    BacSiPhuTrach = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DV_TIEM___3CD30F6905A424AC", x => x.MaGoi);
                    table.ForeignKey(
                        name: "FK__DV_TIEM_P__BacSi__797309D9",
                        column: x => x.BacSiPhuTrach,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                    table.ForeignKey(
                        name: "FK__DV_TIEM_P__MaGoi__787EE5A0",
                        column: x => x.MaGoi,
                        principalTable: "DICH_VU",
                        principalColumn: "MaDV");
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_MUA_HANG",
                columns: table => new
                {
                    MaMuaHang = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaSP = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHI_TIET__379539C237E85030", x => new { x.MaSP, x.MaMuaHang });
                    table.ForeignKey(
                        name: "FK__CHI_TIET_M__MaSP__0A9D95DB",
                        column: x => x.MaSP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MaSP");
                    table.ForeignKey(
                        name: "FK__CHI_TIET___MaMua__0B91BA14",
                        column: x => x.MaMuaHang,
                        principalTable: "DV_MUA_HANG",
                        principalColumn: "MaMuaHang");
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_TIEM",
                columns: table => new
                {
                    MaVC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaTiem = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NgayTiem = table.Column<DateOnly>(type: "date", nullable: false),
                    LieuLuong = table.Column<int>(type: "int", nullable: true),
                    Gia = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHI_TIET__F3E930B48D6A910A", x => new { x.MaVC, x.MaTiem });
                    table.ForeignKey(
                        name: "FK__CHI_TIET_T__MaVC__73BA3083",
                        column: x => x.MaVC,
                        principalTable: "VACCINE",
                        principalColumn: "MaVC");
                    table.ForeignKey(
                        name: "FK__CHI_TIET___MaTie__72C60C4A",
                        column: x => x.MaTiem,
                        principalTable: "DV_TIEM_PHONG_DON_LE",
                        principalColumn: "MaTiem");
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_TIEM_THANG",
                columns: table => new
                {
                    MaVC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaGoi = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LanTiem = table.Column<int>(type: "int", nullable: false),
                    LieuLuong = table.Column<int>(type: "int", nullable: true),
                    NgayTiem = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHI_TIET__870B6AFF58BA0087", x => new { x.MaVC, x.MaGoi, x.LanTiem });
                    table.ForeignKey(
                        name: "FK__CHI_TIET_T__MaVC__7E37BEF6",
                        column: x => x.MaVC,
                        principalTable: "VACCINE",
                        principalColumn: "MaVC");
                    table.ForeignKey(
                        name: "FK__CHI_TIET___MaGoi__7F2BE32F",
                        column: x => x.MaGoi,
                        principalTable: "DV_TIEM_PHONG_THEO_THANG",
                        principalColumn: "MaGoi");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BANG_PHAN_CA_MaNV",
                table: "BANG_PHAN_CA",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_DD_MaDieuDong_NgayBatDau",
                table: "CHI_TIET_DD",
                columns: new[] { "MaDieuDong", "NgayBatDau" });

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_DV_SD_MaDV",
                table: "CHI_TIET_DV_SD",
                column: "MaDV");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_MUA_HANG_MaMuaHang",
                table: "CHI_TIET_MUA_HANG",
                column: "MaMuaHang");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_TIEM_MaTiem",
                table: "CHI_TIET_TIEM",
                column: "MaTiem");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_TIEM_THANG_MaGoi",
                table: "CHI_TIET_TIEM_THANG",
                column: "MaGoi");

            migrationBuilder.CreateIndex(
                name: "IX_DANH_GIA_MaHD",
                table: "DANH_GIA",
                column: "MaHD");

            migrationBuilder.CreateIndex(
                name: "IX_DANH_GIA_MaKH",
                table: "DANH_GIA",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_DANH_GIA_MaNV",
                table: "DANH_GIA",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_DICH_VU_MaCN",
                table: "DICH_VU",
                column: "MaCN");

            migrationBuilder.CreateIndex(
                name: "IX_DICH_VU_MaTC",
                table: "DICH_VU",
                column: "MaTC");

            migrationBuilder.CreateIndex(
                name: "IX_DV_KHAM_BacSiPhuTrach",
                table: "DV_KHAM",
                column: "BacSiPhuTrach");

            migrationBuilder.CreateIndex(
                name: "IX_DV_MUA_HANG_NhanVienBanHang",
                table: "DV_MUA_HANG",
                column: "NhanVienBanHang");

            migrationBuilder.CreateIndex(
                name: "IX_DV_TIEM_PHONG_DON_LE_BacSiPhuTrach",
                table: "DV_TIEM_PHONG_DON_LE",
                column: "BacSiPhuTrach");

            migrationBuilder.CreateIndex(
                name: "IX_DV_TIEM_PHONG_THEO_THANG_BacSiPhuTrach",
                table: "DV_TIEM_PHONG_THEO_THANG",
                column: "BacSiPhuTrach");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_MaCN",
                table: "HOA_DON",
                column: "MaCN");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_MaKH",
                table: "HOA_DON",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_MaNV",
                table: "HOA_DON",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_KHACH_HANG_UserName",
                table: "KHACH_HANG",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_LICH_HEN_MaBS",
                table: "LICH_HEN",
                column: "MaBS");

            migrationBuilder.CreateIndex(
                name: "IX_LICH_HEN_MaCN",
                table: "LICH_HEN",
                column: "MaCN");

            migrationBuilder.CreateIndex(
                name: "IX_LICH_HEN_MaKH",
                table: "LICH_HEN",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_LICH_SU_DIEU_DONG_MaCN",
                table: "LICH_SU_DIEU_DONG",
                column: "MaCN");

            migrationBuilder.CreateIndex(
                name: "IX_NHAN_VIEN_MaCN",
                table: "NHAN_VIEN",
                column: "MaCN");

            migrationBuilder.CreateIndex(
                name: "IX_NHAN_VIEN_UserName",
                table: "NHAN_VIEN",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_THU_CUNG_MaKH",
                table: "THU_CUNG",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_TON_KHO_SAN_PHAM_MaSP",
                table: "TON_KHO_SAN_PHAM",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_TON_KHO_VACCINE_MaVC",
                table: "TON_KHO_VACCINE",
                column: "MaVC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANG_LUONG_THANG");

            migrationBuilder.DropTable(
                name: "BANG_PHAN_CA");

            migrationBuilder.DropTable(
                name: "CHAM_CONG");

            migrationBuilder.DropTable(
                name: "CHI_TIET_DD");

            migrationBuilder.DropTable(
                name: "CHI_TIET_DV_SD");

            migrationBuilder.DropTable(
                name: "CHI_TIET_MUA_HANG");

            migrationBuilder.DropTable(
                name: "CHI_TIET_TIEM");

            migrationBuilder.DropTable(
                name: "CHI_TIET_TIEM_THANG");

            migrationBuilder.DropTable(
                name: "DANH_GIA");

            migrationBuilder.DropTable(
                name: "DV_KHAM");

            migrationBuilder.DropTable(
                name: "LICH_HEN");

            migrationBuilder.DropTable(
                name: "TON_KHO_SAN_PHAM");

            migrationBuilder.DropTable(
                name: "TON_KHO_VACCINE");

            migrationBuilder.DropTable(
                name: "CA_LAM_VIEC");

            migrationBuilder.DropTable(
                name: "LICH_SU_DIEU_DONG");

            migrationBuilder.DropTable(
                name: "DV_MUA_HANG");

            migrationBuilder.DropTable(
                name: "DV_TIEM_PHONG_DON_LE");

            migrationBuilder.DropTable(
                name: "DV_TIEM_PHONG_THEO_THANG");

            migrationBuilder.DropTable(
                name: "HOA_DON");

            migrationBuilder.DropTable(
                name: "SAN_PHAM");

            migrationBuilder.DropTable(
                name: "VACCINE");

            migrationBuilder.DropTable(
                name: "DICH_VU");

            migrationBuilder.DropTable(
                name: "NHAN_VIEN");

            migrationBuilder.DropTable(
                name: "THU_CUNG");

            migrationBuilder.DropTable(
                name: "CHI_NHANH");

            migrationBuilder.DropTable(
                name: "KHACH_HANG");

            migrationBuilder.DropTable(
                name: "TAI_KHOAN");
        }
    }
}
