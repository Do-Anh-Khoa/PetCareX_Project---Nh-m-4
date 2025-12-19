using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class ChiTietTiemThang
{
    public string MaVc { get; set; } = null!;

    public string MaGoi { get; set; } = null!;

    public int? LieuLuong { get; set; }

    public DateOnly? NgayTiem { get; set; }

    public int LanTiem { get; set; }

    public virtual DvTiemPhongTheoThang MaGoiNavigation { get; set; } = null!;

    public virtual Vaccine MaVcNavigation { get; set; } = null!;
}
