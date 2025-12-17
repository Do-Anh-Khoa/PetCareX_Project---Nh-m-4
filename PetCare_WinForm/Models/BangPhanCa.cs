using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class BangPhanCa
{
    public string MaCa { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public DateOnly NgayLamViec { get; set; }

    public virtual CaLamViec MaCaNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
