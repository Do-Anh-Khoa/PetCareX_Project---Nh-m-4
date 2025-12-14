using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;

    public DateOnly? NgayLap { get; set; }

    public decimal? TongTien { get; set; }

    public string? KhuyenMai { get; set; }

    public string? HinhThucThanhToan { get; set; }

    public string? MaNv { get; set; }

    public string? MaKh { get; set; }

    public string? MaCn { get; set; }

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ChiNhanh? MaCnNavigation { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual ICollection<DichVu> MaDvs { get; set; } = new List<DichVu>();
}
