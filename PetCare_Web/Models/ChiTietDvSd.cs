using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class ChiTietDvSd
{
    public string MaHd { get; set; } = null!;

    public string MaDv { get; set; } = null!;

    public virtual DichVu MaDvNavigation { get; set; } = null!;

    public virtual HoaDon MaHdNavigation { get; set; } = null!;
}
