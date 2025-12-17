using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class ChiTietMuaHang
{
    public int? SoLuong { get; set; }

    public double? DonGia { get; set; }

    public string MaMuaHang { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public virtual DvMuaHang MaMuaHangNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
