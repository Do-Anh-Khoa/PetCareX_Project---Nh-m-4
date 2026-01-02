using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Models;

namespace PetCare_Web.Data;

public partial class PetCareContext : DbContext
{
    public PetCareContext()
    {
    }

    public PetCareContext(DbContextOptions<PetCareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangLuongThang> BangLuongThangs { get; set; }

    public virtual DbSet<BangPhanCa> BangPhanCas { get; set; }

    public virtual DbSet<CaLamViec> CaLamViecs { get; set; }

    public virtual DbSet<ChamCong> ChamCongs { get; set; }

    public virtual DbSet<ChiNhanh> ChiNhanhs { get; set; }

    public virtual DbSet<ChiTietDd> ChiTietDds { get; set; }

    public virtual DbSet<ChiTietDvSd> ChiTietDvSds { get; set; }

    public virtual DbSet<ChiTietMuaHang> ChiTietMuaHangs { get; set; }

    public virtual DbSet<ChiTietTiem> ChiTietTiems { get; set; }

    public virtual DbSet<ChiTietTiemThang> ChiTietTiemThangs { get; set; }

    public virtual DbSet<DanhGium> DanhGia { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<DvKham> DvKhams { get; set; }

    public virtual DbSet<DvMuaHang> DvMuaHangs { get; set; }

    public virtual DbSet<DvTiemPhongDonLe> DvTiemPhongDonLes { get; set; }

    public virtual DbSet<DvTiemPhongTheoThang> DvTiemPhongTheoThangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LichHen> LichHens { get; set; }

    public virtual DbSet<LichSuDieuDong> LichSuDieuDongs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThuCung> ThuCungs { get; set; }

    public virtual DbSet<TonKhoSanPham> TonKhoSanPhams { get; set; }

    public virtual DbSet<TonKhoVaccine> TonKhoVaccines { get; set; }

    public virtual DbSet<Vaccine> Vaccines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-ORDALAOG\\SQLEXPRESS;Initial Catalog=PetCareX_DB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangLuongThang>(entity =>
        {
            entity.HasKey(e => new { e.MaNv, e.Thang, e.Nam }).HasName("PK__BANG_LUO__563F494F5895B211");

            entity.ToTable("BANG_LUONG_THANG");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NgayTinhLuong).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Thuong)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TongGioCong).HasDefaultValue(0);
            entity.Property(e => e.TongLuong).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.BangLuongThangs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__BANG_LUONG__MaNV__22751F6C");
        });

        modelBuilder.Entity<BangPhanCa>(entity =>
        {
            entity.HasKey(e => new { e.MaCa, e.MaNv, e.NgayLamViec }).HasName("PK__BANG_PHA__2965A1F9EF20C9C3");

            entity.ToTable("BANG_PHAN_CA");

            entity.Property(e => e.MaCa)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");

            entity.HasOne(d => d.MaCaNavigation).WithMany(p => p.BangPhanCas)
                .HasForeignKey(d => d.MaCa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BANG_PHAN___MaCa__1CBC4616");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.BangPhanCas)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BANG_PHAN___MaNV__1BC821DD");
        });

        modelBuilder.Entity<CaLamViec>(entity =>
        {
            entity.HasKey(e => e.MaCa).HasName("PK__CA_LAM_V__27258E7B48C600E7");

            entity.ToTable("CA_LAM_VIEC");

            entity.Property(e => e.MaCa)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GioBd).HasColumnName("GioBD");
            entity.Property(e => e.GioKt).HasColumnName("GioKT");
            entity.Property(e => e.TenCa).HasMaxLength(100);
        });

        modelBuilder.Entity<ChamCong>(entity =>
        {
            entity.HasKey(e => new { e.MaNv, e.NgayLamViec }).HasName("PK__CHAM_CON__E402F82157058E57");

            entity.ToTable("CHAM_CONG");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.ChamCongs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__CHAM_CONG__MaNV__25518C17");
        });

        modelBuilder.Entity<ChiNhanh>(entity =>
        {
            entity.HasKey(e => e.MaCn).HasName("PK__CHI_NHAN__27258E0E5D479839");

            entity.ToTable("CHI_NHANH");

            entity.Property(e => e.MaCn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCN");
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TenChiNhanh).HasMaxLength(100);
        });

        modelBuilder.Entity<ChiTietDd>(entity =>
        {
            entity.HasKey(e => new { e.MaNv, e.MaDieuDong, e.NgayBatDau }).HasName("PK__CHI_TIET__7F22DB102308F20A");

            entity.ToTable("CHI_TIET_DD");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.MaDieuDong)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GhiChu).HasMaxLength(100);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.ChiTietDds)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_D__MaNV__4316F928");

            entity.HasOne(d => d.LichSuDieuDong).WithMany(p => p.ChiTietDds)
                .HasForeignKey(d => new { d.MaDieuDong, d.NgayBatDau })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_DD__440B1D61");
        });

        modelBuilder.Entity<ChiTietDvSd>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaDv }).HasName("PK__CHI_TIET__4557FE855358D29E");

            entity.ToTable("CHI_TIET_DV_SD");

            entity.Property(e => e.MaHd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaDv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaDV");
            entity.Property(e => e.GhiChu).HasMaxLength(100);

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.ChiTietDvSds)
                .HasForeignKey(d => d.MaDv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_D__MaDV__656C112C");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietDvSds)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_D__MaHD__6477ECF3");
        });

        modelBuilder.Entity<ChiTietMuaHang>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.MaMuaHang }).HasName("PK__CHI_TIET__379539C237E85030");

            entity.ToTable("CHI_TIET_MUA_HANG");

            entity.Property(e => e.MaSp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.MaMuaHang)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MaMuaHangNavigation).WithMany(p => p.ChiTietMuaHangs)
                .HasForeignKey(d => d.MaMuaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET___MaMua__0B91BA14");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietMuaHangs)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_M__MaSP__0A9D95DB");
        });

        modelBuilder.Entity<ChiTietTiem>(entity =>
        {
            entity.HasKey(e => new { e.MaVc, e.MaTiem }).HasName("PK__CHI_TIET__F3E930B48D6A910A");

            entity.ToTable("CHI_TIET_TIEM");

            entity.Property(e => e.MaVc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaVC");
            entity.Property(e => e.MaTiem)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MaTiemNavigation).WithMany(p => p.ChiTietTiems)
                .HasForeignKey(d => d.MaTiem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET___MaTie__72C60C4A");

            entity.HasOne(d => d.MaVcNavigation).WithMany(p => p.ChiTietTiems)
                .HasForeignKey(d => d.MaVc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_T__MaVC__73BA3083");
        });

        modelBuilder.Entity<ChiTietTiemThang>(entity =>
        {
            entity.HasKey(e => new { e.MaVc, e.MaGoi, e.LanTiem }).HasName("PK__CHI_TIET__870B6AFF58BA0087");

            entity.ToTable("CHI_TIET_TIEM_THANG");

            entity.Property(e => e.MaVc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaVC");
            entity.Property(e => e.MaGoi)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MaGoiNavigation).WithMany(p => p.ChiTietTiemThangs)
                .HasForeignKey(d => d.MaGoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET___MaGoi__7F2BE32F");

            entity.HasOne(d => d.MaVcNavigation).WithMany(p => p.ChiTietTiemThangs)
                .HasForeignKey(d => d.MaVc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_T__MaVC__7E37BEF6");
        });

        modelBuilder.Entity<DanhGium>(entity =>
        {
            entity.HasKey(e => e.MaDg).HasName("PK__DANH_GIA__272586600BB6B5DA");

            entity.ToTable("DANH_GIA");

            entity.Property(e => e.MaDg)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaDG");
            entity.Property(e => e.BinhLuan).HasMaxLength(500);
            entity.Property(e => e.MaHd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayDg)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("NgayDG");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DANH_GIA__MaHD__5CD6CB2B");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__DANH_GIA__MaKH__5BE2A6F2");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__DANH_GIA__MaNV__5DCAEF64");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDv).HasName("PK__DICH_VU__27258657F87657B6");

            entity.ToTable("DICH_VU");

            entity.Property(e => e.MaDv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaDV");
            entity.Property(e => e.MaCn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCN");
            entity.Property(e => e.MaTc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaTC");

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.MaCn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DICH_VU__MaCN__619B8048");

            entity.HasOne(d => d.MaTcNavigation).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.MaTc)
                .HasConstraintName("FK__DICH_VU__MaTC__60A75C0F");
        });

        modelBuilder.Entity<DvKham>(entity =>
        {
            entity.HasKey(e => e.MaKham).HasName("PK__DV_KHAM__653E9A7AC2196A6D");

            entity.ToTable("DV_KHAM");

            entity.Property(e => e.MaKham)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BacSiPhuTrach)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ChuanDoan).HasMaxLength(100);
            entity.Property(e => e.ToaThuoc).HasMaxLength(100);
            entity.Property(e => e.TrieuChung).HasMaxLength(100);

            entity.HasOne(d => d.BacSiPhuTrachNavigation).WithMany(p => p.DvKhams)
                .HasForeignKey(d => d.BacSiPhuTrach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_KHAM__BacSiPh__693CA210");

            entity.HasOne(d => d.MaKhamNavigation).WithOne(p => p.DvKham)
                .HasForeignKey<DvKham>(d => d.MaKham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_KHAM__MaKham__6A30C649");
        });

        modelBuilder.Entity<DvMuaHang>(entity =>
        {
            entity.HasKey(e => e.MaMuaHang).HasName("PK__DV_MUA_H__0B031DE0DF3781DC");

            entity.ToTable("DV_MUA_HANG");

            entity.Property(e => e.MaMuaHang)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NhanVienBanHang)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MaMuaHangNavigation).WithOne(p => p.DvMuaHang)
                .HasForeignKey<DvMuaHang>(d => d.MaMuaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_MUA_HA__MaMua__05D8E0BE");

            entity.HasOne(d => d.NhanVienBanHangNavigation).WithMany(p => p.DvMuaHangs)
                .HasForeignKey(d => d.NhanVienBanHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_MUA_HA__NhanV__04E4BC85");
        });

        modelBuilder.Entity<DvTiemPhongDonLe>(entity =>
        {
            entity.HasKey(e => e.MaTiem).HasName("PK__DV_TIEM___4CC209DCBBA6217E");

            entity.ToTable("DV_TIEM_PHONG_DON_LE");

            entity.Property(e => e.MaTiem)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BacSiPhuTrach)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.BacSiPhuTrachNavigation).WithMany(p => p.DvTiemPhongDonLes)
                .HasForeignKey(d => d.BacSiPhuTrach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_TIEM_P__BacSi__6E01572D");

            entity.HasOne(d => d.MaTiemNavigation).WithOne(p => p.DvTiemPhongDonLe)
                .HasForeignKey<DvTiemPhongDonLe>(d => d.MaTiem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_TIEM_P__MaTie__6D0D32F4");
        });

        modelBuilder.Entity<DvTiemPhongTheoThang>(entity =>
        {
            entity.HasKey(e => e.MaGoi).HasName("PK__DV_TIEM___3CD30F6905A424AC");

            entity.ToTable("DV_TIEM_PHONG_THEO_THANG");

            entity.Property(e => e.MaGoi)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BacSiPhuTrach)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NgayDk).HasColumnName("NgayDK");
            entity.Property(e => e.NgayKt).HasColumnName("NgayKT");
            entity.Property(e => e.TenGoi).HasMaxLength(100);

            entity.HasOne(d => d.BacSiPhuTrachNavigation).WithMany(p => p.DvTiemPhongTheoThangs)
                .HasForeignKey(d => d.BacSiPhuTrach)
                .HasConstraintName("FK__DV_TIEM_P__BacSi__797309D9");

            entity.HasOne(d => d.MaGoiNavigation).WithOne(p => p.DvTiemPhongTheoThang)
                .HasForeignKey<DvTiemPhongTheoThang>(d => d.MaGoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_TIEM_P__MaGoi__787EE5A0");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HOA_DON__2725A6E0061CBD2E");

            entity.ToTable("HOA_DON");

            entity.Property(e => e.MaHd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.HinhThucThanhToan).HasMaxLength(100);
            entity.Property(e => e.KhuyenMai).HasMaxLength(100);
            entity.Property(e => e.MaCn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCN");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayLap).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TrangThai).HasMaxLength(100);

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaCn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HOA_DON__MaCN__5629CD9C");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HOA_DON__MaKH__5535A963");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HOA_DON__MaNV__5441852A");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KHACH_HA__2725CF1E1C92EFAA");

            entity.ToTable("KHACH_HANG");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.CapHoiVien)
                .HasMaxLength(100)
                .HasDefaultValue("CoBan");
            entity.Property(e => e.Cccd)
                .HasMaxLength(100)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiemTichLuy).HasDefaultValue(0);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDt)
                .HasMaxLength(100)
                .HasColumnName("SoDT");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK__KHACH_HAN__UserN__4BAC3F29");
        });

        modelBuilder.Entity<LichHen>(entity =>
        {
            entity.HasKey(e => e.MaLichHen).HasName("PK__LICH_HEN__150F264F7D807565");

            entity.ToTable("LICH_HEN");

            entity.Property(e => e.MaLichHen)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaBs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaBS");
            entity.Property(e => e.MaCn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCN");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaBsNavigation).WithMany(p => p.LichHens)
                .HasForeignKey(d => d.MaBs)
                .HasConstraintName("FK__LICH_HEN__MaBS__29221CFB");

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.LichHens)
                .HasForeignKey(d => d.MaCn)
                .HasConstraintName("FK__LICH_HEN__MaCN__2A164134");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.LichHens)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__LICH_HEN__MaKH__282DF8C2");
        });

        modelBuilder.Entity<LichSuDieuDong>(entity =>
        {
            entity.HasKey(e => new { e.MaDieuDong, e.NgayBatDau }).HasName("PK__LICH_SU___8070C1A4096C6650");

            entity.ToTable("LICH_SU_DIEU_DONG");

            entity.Property(e => e.MaDieuDong)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaCn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCN");

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.LichSuDieuDongs)
                .HasForeignKey(d => d.MaCn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LICH_SU_DI__MaCN__403A8C7D");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NHAN_VIE__2725D70A7C80624E");

            entity.ToTable("NHAN_VIEN");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MaCn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCN");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaCn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NHAN_VIEN__MaCN__3C69FB99");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK__NHAN_VIEN__UserN__3D5E1FD2");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SAN_PHAM__2725081C821B278D");

            entity.ToTable("SAN_PHAM");

            entity.Property(e => e.MaSp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.LoaiSp)
                .HasMaxLength(100)
                .HasColumnName("LoaiSP");
            entity.Property(e => e.TenSp)
                .HasMaxLength(100)
                .HasColumnName("TenSP");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__TAI_KHOA__C9F284578A51C119");

            entity.ToTable("TAI_KHOAN");

            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QuyenHan).HasMaxLength(100);
        });

        modelBuilder.Entity<ThuCung>(entity =>
        {
            entity.HasKey(e => e.MaTc).HasName("PK__THU_CUNG__27250068331D9FB9");

            entity.ToTable("THU_CUNG");

            entity.Property(e => e.MaTc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaTC");
            entity.Property(e => e.Giong).HasMaxLength(100);
            entity.Property(e => e.Loai).HasMaxLength(100);
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.TenTc)
                .HasMaxLength(100)
                .HasColumnName("TenTC");
            entity.Property(e => e.TinhTrangSucKhoe).HasMaxLength(100);

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.ThuCungs)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__THU_CUNG__MaKH__4E88ABD4");
        });

        modelBuilder.Entity<TonKhoSanPham>(entity =>
        {
            entity.HasKey(e => new { e.MaCn, e.MaSp }).HasName("PK__TON_KHO___F557DE8F86D1BECB");

            entity.ToTable("TON_KHO_SAN_PHAM");

            entity.Property(e => e.MaCn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCN");
            entity.Property(e => e.MaSp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.SoLuong).HasDefaultValue(0);

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.TonKhoSanPhams)
                .HasForeignKey(d => d.MaCn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TON_KHO_SA__MaCN__10566F31");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TonKhoSanPhams)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TON_KHO_SA__MaSP__114A936A");
        });

        modelBuilder.Entity<TonKhoVaccine>(entity =>
        {
            entity.HasKey(e => new { e.MaCn, e.MaVc, e.SoLo }).HasName("PK__TON_KHO___49EBE3C785C7AE0A");

            entity.ToTable("TON_KHO_VACCINE");

            entity.Property(e => e.MaCn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCN");
            entity.Property(e => e.MaVc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaVC");
            entity.Property(e => e.SoLo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoLuong).HasDefaultValue(0);

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.TonKhoVaccines)
                .HasForeignKey(d => d.MaCn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TON_KHO_VA__MaCN__160F4887");

            entity.HasOne(d => d.MaVcNavigation).WithMany(p => p.TonKhoVaccines)
                .HasForeignKey(d => d.MaVc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TON_KHO_VA__MaVC__17036CC0");
        });

        modelBuilder.Entity<Vaccine>(entity =>
        {
            entity.HasKey(e => e.MaVc).HasName("PK__VACCINE__272510291D0746B1");

            entity.ToTable("VACCINE");

            entity.Property(e => e.MaVc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaVC");
            entity.Property(e => e.GiaVc).HasColumnName("GiaVC");
            entity.Property(e => e.LoaiVc)
                .HasMaxLength(100)
                .HasColumnName("LoaiVC");
            entity.Property(e => e.TenVc)
                .HasMaxLength(100)
                .HasColumnName("TenVC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
