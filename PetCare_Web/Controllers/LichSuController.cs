using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Data;
using PetCare_Web.Models;

namespace PetCare_Web.Controllers
{
    public class LichSuController : Controller
    {
        private readonly PetCareContext _context;

        public LichSuController(PetCareContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 1. CHỐT CỨNG MÃ KHÁCH HÀNG (Bạn check kỹ xem có đúng KH1045 không nha)
            string currentUserId = HttpContext.Session.GetString("MaKH");
            if (string.IsNullOrEmpty(currentUserId)) return RedirectToAction("Login", "TaiKhoan");

            // 2. LẤY LỊCH HẸN (Tạm thời bỏ Include để test xem nó có ra dòng nào không)
            var lichKham = await _context.LichHens
                .Include(l => l.MaBsNavigation)  // <== Thêm dòng này để lấy Tên Bác Sĩ
        .        Include(l => l.MaCnNavigation)  // <
                .Where(l => l.MaKh == currentUserId)
                .OrderByDescending(l => l.NgayHen)
                .ToListAsync();

            // 3. LẤY HÓA ĐƠN
            var donHang = await _context.HoaDons
                .Where(h => h.MaKh == currentUserId)
                .OrderByDescending(h => h.NgayLap)
                .ToListAsync();

            // Debug: Nếu danh sách rỗng, thử lấy TẤT CẢ (để xem có phải sai mã KH không)
            if (lichKham.Count == 0 && donHang.Count == 0)
            {
                // Uncomment dòng dưới nếu muốn test "liều": Lấy hết sạch data của cả hệ thống hiện ra
                // lichKham = await _context.LichHens.ToListAsync(); 
                // TempData["Error"] = "Không tìm thấy dữ liệu của " + currentUserId + ". Đang hiện tất cả để test.";
            }

            ViewBag.LichKham = lichKham;
            ViewBag.DonHang = donHang;

            return View();
        }
    }
}