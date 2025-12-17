using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class ChamCong
{
    public string MaNv { get; set; } = null!;

    public DateOnly NgayLamViec { get; set; }

    public TimeOnly? Checkin { get; set; }

    public TimeOnly? Checkout { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
