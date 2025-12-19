using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class DanhGium
{
    public string MaDg { get; set; } = null!;

    public double? DiemChatLuong { get; set; }

    public double? DiemThaiDo { get; set; }

    public double? DiemHaiLong { get; set; }

    public string? BinhLuan { get; set; }

    public DateOnly? NgayDg { get; set; }

    public string MaHd { get; set; } = null!;

    public string? MaKh { get; set; }

    public string? MaNv { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }
}
