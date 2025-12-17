using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class TonKhoVaccine
{
    public string MaCn { get; set; } = null!;

    public string MaVc { get; set; } = null!;

    public string SoLo { get; set; } = null!;

    public int? SoLuong { get; set; }

    public DateOnly? NgaySanXuat { get; set; }

    public DateOnly? NgayHetHan { get; set; }

    public virtual ChiNhanh MaCnNavigation { get; set; } = null!;

    public virtual Vaccine MaVcNavigation { get; set; } = null!;
}
