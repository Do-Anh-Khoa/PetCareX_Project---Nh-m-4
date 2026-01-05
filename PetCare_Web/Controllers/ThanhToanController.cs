using Microsoft.AspNetCore.Mvc;
using PetCare_Web.Data;
using PetCare_Web.Models;

namespace PetCare_Web.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly PetCareContext _context;

        public ThanhToanController(PetCareContext context)
        {
            _context = context;
        }

        // 1. Hiện trang QR code
        public IActionResult Index(string maHd)
        {
            // Kiểm tra đăng nhập
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("MaKH"))) return RedirectToAction("Login", "TaiKhoan");

            var hoaDon = _context.HoaDons.Find(maHd);
            if (hoaDon == null) return NotFound();

            return View(hoaDon);
        }

        // 2. Xử lý khi khách bấm "Đã Chuyển Khoản"
        public IActionResult XacNhanThanhToan(string maHd)
        {
            var hoaDon = _context.HoaDons.Find(maHd);
            if (hoaDon != null)
            {
                hoaDon.TrangThai = "DaThanhToan"; // Cập nhật trạng thái
                hoaDon.HinhThucThanhToan = "ChuyenKhoan"; // Cập nhật hình thức
                _context.SaveChanges();
            }

            TempData["SuccessMessage"] = "🎉 Thanh toán thành công! Cảm ơn bạn đã mua hàng.";
            return RedirectToAction("Index", "LichSu");
        }
    }
}