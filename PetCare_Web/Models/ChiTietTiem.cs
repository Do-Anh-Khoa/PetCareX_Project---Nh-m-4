using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class ChiTietTiem
{
    public string MaVc { get; set; } = null!;

    public string MaTiem { get; set; } = null!;

    public DateOnly? NgayTiem { get; set; }

    public int? LieuLuong { get; set; }

    public double? Gia { get; set; }

    public virtual DvTiemPhongDonLe MaTiemNavigation { get; set; } = null!;

    public virtual Vaccine MaVcNavigation { get; set; } = null!;
}
