using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class CaLamViec
{
    public string MaCa { get; set; } = null!;

    public string? TenCa { get; set; }

    public TimeOnly? GioBd { get; set; }

    public TimeOnly? GioKt { get; set; }

    public virtual ICollection<BangPhanCa> BangPhanCas { get; set; } = new List<BangPhanCa>();
}
