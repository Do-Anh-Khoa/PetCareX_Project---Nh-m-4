using Microsoft.AspNetCore.Mvc;
using PetCare_Web.Data;
using PetCare_Web.Models;

namespace PetCare_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly PetCareContext _context;

        public AccountController(PetCareContext context)
        {
            _context = context;
        }

        // --- ĐĂNG KÝ ---
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string hoten, string sdt)
        {
            try
            {
                // 1. Kiểm tra trùng
                var existingAccount = _context.TaiKhoans.FirstOrDefault(a => a.UserName == username);
                if (existingAccount != null)
                {
                    ViewBag.Error = "Tài khoản đã tồn tại!";
                    return View();
                }

                // 2. Tạo Tài khoản
                var tk = new TaiKhoan
                {
                    UserName = username,
                    MatKhau = password,
                    QuyenHan = "KhachHang"
                };
                _context.TaiKhoans.Add(tk);
                _context.SaveChanges();

                // 3. Tạo Khách hàng
                var kh = new KhachHang
                {
                    MaKh = "KH" + DateTime.Now.ToString("ddHHmm"),
                    HoTen = hoten,
                    SoDt = sdt,
                    UserName = username,
                    DiemTichLuy = 0,
                    CapHoiVien = "Mới"
                };
                _context.KhachHangs.Add(kh);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi: " + ex.Message;
                return View();
            }
        }

        // --- ĐĂNG NHẬP ---
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.TaiKhoans.FirstOrDefault(u => u.UserName == username && u.MatKhau == password);
            if (user != null)
            {
                var khach = _context.KhachHangs.FirstOrDefault(k => k.UserName == username);
                if (khach != null)
                {
                    // Lưu Session
                    HttpContext.Session.SetString("UserNames", username);
                    HttpContext.Session.SetString("TenKH", khach.HoTen);
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Error = "Sai tài khoản hoặc mật khẩu!";
            return View();
        }
    }
}