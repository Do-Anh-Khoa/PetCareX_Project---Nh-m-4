using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class ChiTietDd
{
    public string MaNv { get; set; } = null!;

    public string MaDieuDong { get; set; } = null!;

    public DateOnly NgayBatDau { get; set; }

    public string? GhiChu { get; set; }

    public virtual LichSuDieuDong LichSuDieuDong { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
