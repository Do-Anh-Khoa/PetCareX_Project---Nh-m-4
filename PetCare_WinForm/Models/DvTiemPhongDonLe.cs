using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class DvTiemPhongDonLe
{
    public string MaTiem { get; set; } = null!;

    public string? BacSiPhuTrach { get; set; }

    public virtual NhanVien? BacSiPhuTrachNavigation { get; set; }

    public virtual ICollection<ChiTietTiem> ChiTietTiems { get; set; } = new List<ChiTietTiem>();

    public virtual DichVu MaTiemNavigation { get; set; } = null!;
}
