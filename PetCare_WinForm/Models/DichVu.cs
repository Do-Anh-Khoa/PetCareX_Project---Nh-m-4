using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class DichVu
{
    public string MaDv { get; set; } = null!;

    public string? MaTc { get; set; }

    public string? MaCn { get; set; }

    public virtual DvKham? DvKham { get; set; }

    public virtual DvMuaHang? DvMuaHang { get; set; }

    public virtual DvTiemPhongDonLe? DvTiemPhongDonLe { get; set; }

    public virtual DvTiemPhongTheoThang? DvTiemPhongTheoThang { get; set; }

    public virtual ChiNhanh? MaCnNavigation { get; set; }

    public virtual ThuCung? MaTcNavigation { get; set; }

    public virtual ICollection<HoaDon> MaHds { get; set; } = new List<HoaDon>();
}
