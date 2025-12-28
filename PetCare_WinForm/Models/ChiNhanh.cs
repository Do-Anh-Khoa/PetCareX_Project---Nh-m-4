using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class ChiNhanh
{
    public string MaCn { get; set; } = null!;

    public string TenChiNhanh { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public TimeOnly? GioMoCua { get; set; }

    public TimeOnly? GioDongCua { get; set; }

    public virtual ICollection<DichVu> DichVus { get; set; } = new List<DichVu>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();

    public virtual ICollection<LichSuDieuDong> LichSuDieuDongs { get; set; } = new List<LichSuDieuDong>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual ICollection<TonKhoSanPham> TonKhoSanPhams { get; set; } = new List<TonKhoSanPham>();

    public virtual ICollection<TonKhoVaccine> TonKhoVaccines { get; set; } = new List<TonKhoVaccine>();
}
