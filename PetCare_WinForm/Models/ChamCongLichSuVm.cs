using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare_Web.Models
{
    public class ChamCongLichSuVm
    {
        public DateTime NgayLamViec { get; set; }

        public string MaNV { get; set; }

        public string HoTen { get; set; }

        public TimeSpan? Checkin { get; set; }

        public TimeSpan? Checkout { get; set; }

        public decimal SoGioLamViec { get; set; }
    }
}
