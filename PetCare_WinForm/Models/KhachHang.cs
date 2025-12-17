using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? SoDt { get; set; }

    public string? Email { get; set; }

    public string? Cccd { get; set; }

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? CapHoiVien { get; set; }

    public int? DiemTichLuy { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();

    public virtual ICollection<ThuCung> ThuCungs { get; set; } = new List<ThuCung>();

    public virtual TaiKhoan? UserNameNavigation { get; set; }
}
