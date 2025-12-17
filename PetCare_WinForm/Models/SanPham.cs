using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string? TenSp { get; set; }

    public string? LoaiSp { get; set; }

    public double? GiaBan { get; set; }

    public virtual ICollection<ChiTietMuaHang> ChiTietMuaHangs { get; set; } = new List<ChiTietMuaHang>();

    public virtual ICollection<TonKhoSanPham> TonKhoSanPhams { get; set; } = new List<TonKhoSanPham>();
}
