using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;

    public DateOnly NgayLap { get; set; }

    public decimal? TongTien { get; set; }

    public string? KhuyenMai { get; set; }

    public string HinhThucThanhToan { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public string MaKh { get; set; } = null!;

    public string MaCn { get; set; } = null!;

    public virtual ICollection<ChiTietDvSd> ChiTietDvSds { get; set; } = new List<ChiTietDvSd>();

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ChiNhanh MaCnNavigation { get; set; } = null!;

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
