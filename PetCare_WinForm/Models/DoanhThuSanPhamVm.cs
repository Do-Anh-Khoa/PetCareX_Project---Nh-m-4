using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare_Web.Models
{
    public class DoanhThuSanPhamVm
    {
        public string MaSP { get; set; }     
        public string TenSP { get; set; }    
        public string LoaiSP { get; set; }    
        public int SoLuongBan { get; set; }   
        public double DoanhThu { get; set; }
    }

}
