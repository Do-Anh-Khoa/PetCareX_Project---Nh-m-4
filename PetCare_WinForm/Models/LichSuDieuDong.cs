using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class LichSuDieuDong
{
    public string MaDieuDong { get; set; } = null!;

    public DateOnly NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public string MaCn { get; set; } = null!;

    public virtual ICollection<ChiTietDd> ChiTietDds { get; set; } = new List<ChiTietDd>();

    public virtual ChiNhanh MaCnNavigation { get; set; } = null!;
}
