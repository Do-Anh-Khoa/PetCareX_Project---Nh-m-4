using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class ThuCung
{
    public string MaTc { get; set; } = null!;

    public string TenTc { get; set; } = null!;

    public string Loai { get; set; } = null!;

    public string? Giong { get; set; }

    public string? TinhTrangSucKhoe { get; set; }

    public string MaKh { get; set; } = null!;

    public virtual ICollection<DichVu> DichVus { get; set; } = new List<DichVu>();

    public virtual KhachHang MaKhNavigation { get; set; } = null!;
}
