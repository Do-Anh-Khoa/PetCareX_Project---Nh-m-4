using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class DichVu
{
    public string MaDv { get; set; } = null!;

    public string? MaTc { get; set; }

    public string MaCn { get; set; } = null!;

    public virtual ICollection<ChiTietDvSd> ChiTietDvSds { get; set; } = new List<ChiTietDvSd>();

    public virtual DvKham? DvKham { get; set; }

    public virtual DvMuaHang? DvMuaHang { get; set; }

    public virtual DvTiemPhongDonLe? DvTiemPhongDonLe { get; set; }

    public virtual DvTiemPhongTheoThang? DvTiemPhongTheoThang { get; set; }

    public virtual ChiNhanh MaCnNavigation { get; set; } = null!;

    public virtual ThuCung? MaTcNavigation { get; set; }
}
