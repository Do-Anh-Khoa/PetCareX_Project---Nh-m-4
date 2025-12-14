using System;
using System.Collections.Generic;

namespace PetCare_Web.Models;

public partial class TaiKhoan
{
    public string UserName { get; set; } = null!;

    public string? MatKhau { get; set; }

    public string? QuyenHan { get; set; }

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
