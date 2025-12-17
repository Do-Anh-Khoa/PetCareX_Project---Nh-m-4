using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class DvTiemPhongTheoThang
{
    public string MaGoi { get; set; } = null!;

    public string? TenGoi { get; set; }

    public int? SoThang { get; set; }

    public DateOnly? NgayDk { get; set; }

    public DateOnly? NgayKt { get; set; }

    public double? GiaGoi { get; set; }

    public string? BacSiPhuTrach { get; set; }

    public virtual NhanVien? BacSiPhuTrachNavigation { get; set; }

    public virtual ICollection<ChiTietTiemThang> ChiTietTiemThangs { get; set; } = new List<ChiTietTiemThang>();

    public virtual DichVu MaGoiNavigation { get; set; } = null!;
}
