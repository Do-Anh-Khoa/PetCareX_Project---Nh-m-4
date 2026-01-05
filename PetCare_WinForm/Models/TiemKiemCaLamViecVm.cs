using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare_Web.Models
{
    public class TiemKiemCaLamViecVm
    {
        public DateTime NgayLamViec { get; set; }   
        public string TenCa { get; set; }           
        public TimeSpan GioBD { get; set; }         
        public TimeSpan GioKT { get; set; }         
        public string MaNV { get; set; }            
        public string HoTen { get; set; }           
        public string MaCa { get; set; }            
    }
}
