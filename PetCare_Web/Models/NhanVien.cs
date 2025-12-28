using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public DateOnly NgaySinh { get; set; }

    public string GioiTinh { get; set; } = null!;

    public DateOnly NgayVaoLam { get; set; }

    public string ChucVu { get; set; } = null!;

    public decimal? LuongCoBan { get; set; }

    public string MaCn { get; set; } = null!;

    public string? UserName { get; set; }

    public virtual ICollection<BangLuongThang> BangLuongThangs { get; set; } = new List<BangLuongThang>();

    public virtual ICollection<BangPhanCa> BangPhanCas { get; set; } = new List<BangPhanCa>();

    public virtual ICollection<ChamCong> ChamCongs { get; set; } = new List<ChamCong>();

    public virtual ICollection<ChiTietDd> ChiTietDds { get; set; } = new List<ChiTietDd>();

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ICollection<DvKham> DvKhams { get; set; } = new List<DvKham>();

    public virtual ICollection<DvMuaHang> DvMuaHangs { get; set; } = new List<DvMuaHang>();

    public virtual ICollection<DvTiemPhongDonLe> DvTiemPhongDonLes { get; set; } = new List<DvTiemPhongDonLe>();

    public virtual ICollection<DvTiemPhongTheoThang> DvTiemPhongTheoThangs { get; set; } = new List<DvTiemPhongTheoThang>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();

    public virtual ChiNhanh MaCnNavigation { get; set; } = null!;

    public virtual TaiKhoan? UserNameNavigation { get; set; }
}
