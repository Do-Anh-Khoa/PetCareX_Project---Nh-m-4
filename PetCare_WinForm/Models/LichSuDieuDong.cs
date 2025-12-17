using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class LichSuDieuDong
{
    public string MaDieuDong { get; set; } = null!;

    public DateOnly NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public string? MaCn { get; set; }

    public virtual ChiNhanh? MaCnNavigation { get; set; }

    public virtual ICollection<NhanVien> MaNvs { get; set; } = new List<NhanVien>();
}
