using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare_Web.Models
{
    public class XemLuongVm
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }

        public int TongGioCong { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal Thuong { get; set; }       
        public decimal TongLuong { get; set; }
    }
}
