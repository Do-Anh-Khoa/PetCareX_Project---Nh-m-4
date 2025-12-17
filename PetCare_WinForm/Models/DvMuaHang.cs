using System;
using System.Collections.Generic;

namespace PetCare_WinForm.Models;

public partial class DvMuaHang
{
    public string MaMuaHang { get; set; } = null!;

    public string? NhanVienBanHang { get; set; }

    public virtual ICollection<ChiTietMuaHang> ChiTietMuaHangs { get; set; } = new List<ChiTietMuaHang>();

    public virtual DichVu MaMuaHangNavigation { get; set; } = null!;

    public virtual NhanVien? NhanVienBanHangNavigation { get; set; }
}
