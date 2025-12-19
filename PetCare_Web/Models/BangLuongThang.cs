using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class BangLuongThang
{
    public string MaNv { get; set; } = null!;

    public int Thang { get; set; }

    public int Nam { get; set; }

    public int? TongGioCong { get; set; }

    public decimal? LuongCoBan { get; set; }

    public decimal? Thuong { get; set; }

    public decimal? TongLuong { get; set; }

    public DateOnly? NgayTinhLuong { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
