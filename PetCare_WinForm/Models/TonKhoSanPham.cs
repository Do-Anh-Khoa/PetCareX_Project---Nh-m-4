using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class TonKhoSanPham
{
    public string MaCn { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public int? SoLuong { get; set; }

    public DateOnly? NgaySanXuat { get; set; }

    public DateOnly? NgayHetHan { get; set; }

    public virtual ChiNhanh MaCnNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
