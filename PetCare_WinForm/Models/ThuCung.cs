using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class ThuCung
{
    public string MaTc { get; set; } = null!;

    public string? TenTc { get; set; }

    public string? Loai { get; set; }

    public string? Giong { get; set; }

    public string? TinhTrangSucKhoe { get; set; }

    public string? MaKh { get; set; }

    public virtual ICollection<DichVu> DichVus { get; set; } = new List<DichVu>();

    public virtual KhachHang? MaKhNavigation { get; set; }
}
