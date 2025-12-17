using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare_WinForm.Models
{
    public class HoaDonChiTietVm
    {
        public string MaHD { get; set; }           
        public DateTime NgayLap { get; set; }        
        public decimal TongTien { get; set; }        
        public string HinhThucThanhToan { get; set; } 
        public string TenKhachHang { get; set; }     
        public string NhanVienTao { get; set; }      
        public string TenChiNhanh { get; set; }     
    }
}
