using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetCare_WinForm.Models;

namespace PetCare_WinForm.Data;

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

    public virtual DbSet<Top10BacSiDoanhThu> Top10BacSiDoanhThu { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-VC4DCMU4\\MSSQLSERVER_2;Database=PetCareX;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangLuongThang>(entity =>
        {
            entity.HasKey(e => new { e.MaNv, e.Thang, e.Nam }).HasName("PK__BANG_LUO__563F494FD94F894E");

            entity.ToTable("BANG_LUONG_THANG");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Thuong).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TongLuong).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.BangLuongThangs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__BANG_LUONG__MaNV__0D7A0286");
        });

        modelBuilder.Entity<BangPhanCa>(entity =>
        {
            entity.HasKey(e => new { e.MaCa, e.MaNv, e.NgayLamViec }).HasName("PK__BANG_PHA__2965A1F930DA2F47");

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
                .HasConstraintName("FK__BANG_PHAN___MaCa__0A9D95DB");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.BangPhanCas)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BANG_PHAN___MaNV__09A971A2");
        });

        modelBuilder.Entity<CaLamViec>(entity =>
        {
            entity.HasKey(e => e.MaCa).HasName("PK__CA_LAM_V__27258E7BEAD35D11");

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
            entity.HasKey(e => new { e.MaNv, e.NgayLamViec }).HasName("PK__CHAM_CON__E402F821E35540EA");

            entity.ToTable("CHAM_CONG");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.ChamCongs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__CHAM_CONG__MaNV__10566F31");
        });

        modelBuilder.Entity<ChiNhanh>(entity =>
        {
            entity.HasKey(e => e.MaCn).HasName("PK__CHI_NHAN__27258E0E2A6ED94B");

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

        modelBuilder.Entity<ChiTietMuaHang>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.MaMuaHang }).HasName("PK__CHI_TIET__379539C27A8B7756");

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
                .HasConstraintName("FK__CHI_TIET___MaMua__7D439ABD");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietMuaHangs)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_M__MaSP__7C4F7684");
        });

        modelBuilder.Entity<ChiTietTiem>(entity =>
        {
            entity.HasKey(e => new { e.MaVc, e.MaTiem }).HasName("PK__CHI_TIET__F3E930B4A8ADFA81");

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
                .HasConstraintName("FK__CHI_TIET___MaTie__6A30C649");

            entity.HasOne(d => d.MaVcNavigation).WithMany(p => p.ChiTietTiems)
                .HasForeignKey(d => d.MaVc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_T__MaVC__6B24EA82");
        });

        modelBuilder.Entity<ChiTietTiemThang>(entity =>
        {
            entity.HasKey(e => new { e.MaVc, e.MaGoi, e.LanTiem }).HasName("PK__CHI_TIET__870B6AFF43E374A8");

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
                .HasConstraintName("FK__CHI_TIET___MaGoi__73BA3083");

            entity.HasOne(d => d.MaVcNavigation).WithMany(p => p.ChiTietTiemThangs)
                .HasForeignKey(d => d.MaVc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_T__MaVC__72C60C4A");
        });

        modelBuilder.Entity<DanhGium>(entity =>
        {
            entity.HasKey(e => e.MaDg).HasName("PK__DANH_GIA__27258660002DE056");

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
            entity.Property(e => e.NgayDg).HasColumnName("NgayDG");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK__DANH_GIA__MaHD__5629CD9C");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__DANH_GIA__MaKH__5535A963");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__DANH_GIA__MaNV__571DF1D5");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDv).HasName("PK__DICH_VU__272586578E64C4BD");

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
                .HasConstraintName("FK__DICH_VU__MaCN__5AEE82B9");

            entity.HasOne(d => d.MaTcNavigation).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.MaTc)
                .HasConstraintName("FK__DICH_VU__MaTC__59FA5E80");
        });

        modelBuilder.Entity<DvKham>(entity =>
        {
            entity.HasKey(e => e.MaKham).HasName("PK__DV_KHAM__653E9A7A44BBBC44");

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
                .HasConstraintName("FK__DV_KHAM__BacSiPh__619B8048");

            entity.HasOne(d => d.MaKhamNavigation).WithOne(p => p.DvKham)
                .HasForeignKey<DvKham>(d => d.MaKham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_KHAM__MaKham__628FA481");
        });

        modelBuilder.Entity<DvMuaHang>(entity =>
        {
            entity.HasKey(e => e.MaMuaHang).HasName("PK__DV_MUA_H__0B031DE05E4E7F8D");

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
                .HasConstraintName("FK__DV_MUA_HA__MaMua__797309D9");

            entity.HasOne(d => d.NhanVienBanHangNavigation).WithMany(p => p.DvMuaHangs)
                .HasForeignKey(d => d.NhanVienBanHang)
                .HasConstraintName("FK__DV_MUA_HA__NhanV__787EE5A0");
        });

        modelBuilder.Entity<DvTiemPhongDonLe>(entity =>
        {
            entity.HasKey(e => e.MaTiem).HasName("PK__DV_TIEM___4CC209DC8998917F");

            entity.ToTable("DV_TIEM_PHONG_DON_LE");

            entity.Property(e => e.MaTiem)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BacSiPhuTrach)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.BacSiPhuTrachNavigation).WithMany(p => p.DvTiemPhongDonLes)
                .HasForeignKey(d => d.BacSiPhuTrach)
                .HasConstraintName("FK__DV_TIEM_P__BacSi__66603565");

            entity.HasOne(d => d.MaTiemNavigation).WithOne(p => p.DvTiemPhongDonLe)
                .HasForeignKey<DvTiemPhongDonLe>(d => d.MaTiem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_TIEM_P__MaTie__656C112C");
        });

        modelBuilder.Entity<DvTiemPhongTheoThang>(entity =>
        {
            entity.HasKey(e => e.MaGoi).HasName("PK__DV_TIEM___3CD30F6949FBFE91");

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
                .HasConstraintName("FK__DV_TIEM_P__BacSi__6EF57B66");

            entity.HasOne(d => d.MaGoiNavigation).WithOne(p => p.DvTiemPhongTheoThang)
                .HasForeignKey<DvTiemPhongTheoThang>(d => d.MaGoi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DV_TIEM_P__MaGoi__6E01572D");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HOA_DON__2725A6E011D4FBE0");

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
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaCn)
                .HasConstraintName("FK__HOA_DON__MaCN__5070F446");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__HOA_DON__MaKH__4F7CD00D");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__HOA_DON__MaNV__4E88ABD4");

            entity.HasMany(d => d.MaDvs).WithMany(p => p.MaHds)
                .UsingEntity<Dictionary<string, object>>(
                    "ChiTietDvSd",
                    r => r.HasOne<DichVu>().WithMany()
                        .HasForeignKey("MaDv")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CHI_TIET_D__MaDV__5EBF139D"),
                    l => l.HasOne<HoaDon>().WithMany()
                        .HasForeignKey("MaHd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CHI_TIET_D__MaHD__5DCAEF64"),
                    j =>
                    {
                        j.HasKey("MaHd", "MaDv").HasName("PK__CHI_TIET__4557FE8599EF3504");
                        j.ToTable("CHI_TIET_DV_SD");
                        j.IndexerProperty<string>("MaHd")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("MaHD");
                        j.IndexerProperty<string>("MaDv")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("MaDV");
                    });
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KHACH_HA__2725CF1E3341BDF2");

            entity.ToTable("KHACH_HANG");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.CapHoiVien).HasMaxLength(100);
            entity.Property(e => e.Cccd)
                .HasMaxLength(100)
                .HasColumnName("CCCD");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDt)
                .HasMaxLength(100)
                .HasColumnName("SoDT");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK__KHACH_HAN__UserN__48CFD27E");
        });

        modelBuilder.Entity<LichHen>(entity =>
        {
            entity.HasKey(e => e.MaLichHen).HasName("PK__LICH_HEN__150F264FF03107A2");

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
                .HasConstraintName("FK__LICH_HEN__MaBS__160F4887");

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.LichHens)
                .HasForeignKey(d => d.MaCn)
                .HasConstraintName("FK__LICH_HEN__MaCN__17036CC0");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.LichHens)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__LICH_HEN__MaKH__151B244E");
        });

        modelBuilder.Entity<LichSuDieuDong>(entity =>
        {
            entity.HasKey(e => new { e.MaDieuDong, e.NgayBatDau }).HasName("PK__LICH_SU___8070C1A4CB9E6398");

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
                .HasConstraintName("FK__LICH_SU_DI__MaCN__403A8C7D");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NHAN_VIE__2725D70A63F7020D");

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
                .HasConstraintName("FK__NHAN_VIEN__MaCN__3C69FB99");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK__NHAN_VIEN__UserN__3D5E1FD2");

            entity.HasMany(d => d.LichSuDieuDongs).WithMany(p => p.MaNvs)
                .UsingEntity<Dictionary<string, object>>(
                    "ChiTietDd",
                    r => r.HasOne<LichSuDieuDong>().WithMany()
                        .HasForeignKey("MaDieuDong", "NgayBatDau")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CHI_TIET_DD__440B1D61"),
                    l => l.HasOne<NhanVien>().WithMany()
                        .HasForeignKey("MaNv")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CHI_TIET_D__MaNV__4316F928"),
                    j =>
                    {
                        j.HasKey("MaNv", "MaDieuDong", "NgayBatDau").HasName("PK__CHI_TIET__7F22DB10BA5230BF");
                        j.ToTable("CHI_TIET_DD");
                        j.IndexerProperty<string>("MaNv")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("MaNV");
                        j.IndexerProperty<string>("MaDieuDong")
                            .HasMaxLength(20)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SAN_PHAM__2725081CAE3D047D");

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
            entity.HasKey(e => e.UserName).HasName("PK__TAI_KHOA__C9F284574F46C6E0");

            entity.ToTable("TAI_KHOAN");

            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QuyenHan).HasMaxLength(100);
        });

        modelBuilder.Entity<ThuCung>(entity =>
        {
            entity.HasKey(e => e.MaTc).HasName("PK__THU_CUNG__27250068A1D128CE");

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
                .HasConstraintName("FK__THU_CUNG__MaKH__4BAC3F29");
        });

        modelBuilder.Entity<TonKhoSanPham>(entity =>
        {
            entity.HasKey(e => new { e.MaCn, e.MaSp }).HasName("PK__TON_KHO___F557DE8F02725EAB");

            entity.ToTable("TON_KHO_SAN_PHAM");

            entity.Property(e => e.MaCn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCN");
            entity.Property(e => e.MaSp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaSP");

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.TonKhoSanPhams)
                .HasForeignKey(d => d.MaCn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TON_KHO_SA__MaCN__00200768");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TonKhoSanPhams)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TON_KHO_SA__MaSP__01142BA1");
        });

        modelBuilder.Entity<TonKhoVaccine>(entity =>
        {
            entity.HasKey(e => new { e.MaCn, e.MaVc, e.SoLo }).HasName("PK__TON_KHO___49EBE3C73231E13B");

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

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.TonKhoVaccines)
                .HasForeignKey(d => d.MaCn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TON_KHO_VA__MaCN__03F0984C");

            entity.HasOne(d => d.MaVcNavigation).WithMany(p => p.TonKhoVaccines)
                .HasForeignKey(d => d.MaVc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TON_KHO_VA__MaVC__04E4BC85");
        });

        modelBuilder.Entity<Vaccine>(entity =>
        {
            entity.HasKey(e => e.MaVc).HasName("PK__VACCINE__27251029125DC3ED");

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

        modelBuilder.Entity<Top10BacSiDoanhThu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Top10BacSiDoanhThu");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
