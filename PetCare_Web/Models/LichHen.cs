using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class LichHen
{
    public string MaLichHen { get; set; } = null!;

    public DateOnly? NgayHen { get; set; }

    public TimeOnly? GioHen { get; set; }

    public string? TrangThai { get; set; }

    public string? GhiChu { get; set; }

    public string? MaKh { get; set; }

    public string? MaBs { get; set; }

    public string? MaCn { get; set; }

    public virtual NhanVien? MaBsNavigation { get; set; }

    public virtual ChiNhanh? MaCnNavigation { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }
}
