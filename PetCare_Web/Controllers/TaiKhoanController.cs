using Microsoft.AspNetCore.Mvc;
using PetCare_Web.Data;
using PetCare_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace PetCare_Web.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly PetCareContext _context;

        public TaiKhoanController(PetCareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // 1. Kiểm tra trong bảng TAI_KHOAN
            var account = await _context.TaiKhoans
                .FirstOrDefaultAsync(a => a.UserName == username && a.MatKhau == password);

            if (account != null)
            {
                // 2. Nếu đúng tài khoản, tìm thông tin trong bảng KHACH_HANG
                var khachHang = await _context.KhachHangs
                    .FirstOrDefaultAsync(k => k.UserName == username);

                if (khachHang != null)
                {
                    // 3. Lưu MaKH và TenKH vào Session để dùng cho toàn bộ Web
                    HttpContext.Session.SetString("MaKH", khachHang.MaKh);
                    HttpContext.Session.SetString("TenKH", khachHang.HoTen);

                    return RedirectToAction("Index", "Home"); // Vào trang chủ
                }
                else
                {
                    ViewBag.Error = "Tài khoản này không phải là Khách Hàng!";
                }
            }
            else
            {
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu!";
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Xóa Session đăng xuất
            return RedirectToAction("Login");
        }
    }
}