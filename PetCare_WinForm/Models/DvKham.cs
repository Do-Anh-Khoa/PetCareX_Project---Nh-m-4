using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class DvKham
{
    public string MaKham { get; set; } = null!;

    public string? TrieuChung { get; set; }

    public string? ChuanDoan { get; set; }

    public string? ToaThuoc { get; set; }

    public string? BacSiPhuTrach { get; set; }

    public DateOnly? NgayTaiKham { get; set; }

    public double? GiaKhamBenh { get; set; }

    public virtual NhanVien? BacSiPhuTrachNavigation { get; set; }

    public virtual DichVu MaKhamNavigation { get; set; } = null!;
}
