using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class Vaccine
{
    public string MaVc { get; set; } = null!;

    public string TenVc { get; set; } = null!;

    public string LoaiVc { get; set; } = null!;

    public double? GiaVc { get; set; }

    public virtual ICollection<ChiTietTiemThang> ChiTietTiemThangs { get; set; } = new List<ChiTietTiemThang>();

    public virtual ICollection<ChiTietTiem> ChiTietTiems { get; set; } = new List<ChiTietTiem>();

    public virtual ICollection<TonKhoVaccine> TonKhoVaccines { get; set; } = new List<TonKhoVaccine>();
}
