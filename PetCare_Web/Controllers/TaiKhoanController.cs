using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Data;
using PetCare_Web.Models;

namespace PetCare_Web.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly PetCareContext _context;

        public TaiKhoanController(PetCareContext context)
        {
            _context = context;
        }

        // --- PHẦN ĐĂNG NHẬP (CŨ) ---
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var account = await _context.TaiKhoans
                .FirstOrDefaultAsync(a => a.UserName == username && a.MatKhau == password);

            if (account != null)
            {
                var khachHang = await _context.KhachHangs
                    .FirstOrDefaultAsync(k => k.UserName == username);

                if (khachHang != null)
                {
                    HttpContext.Session.SetString("MaKH", khachHang.MaKh);
                    HttpContext.Session.SetString("TenKH", khachHang.HoTen);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Tài khoản này không có thông tin khách hàng!";
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
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // --- PHẦN ĐĂNG KÝ (MỚI THÊM) ---
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangKy(string hoten, string sdt, string username, string password, string confirmPassword)
        {
            // 1. Kiểm tra mật khẩu nhập lại
            if (password != confirmPassword)
            {
                ViewBag.Error = "Mật khẩu xác nhận không khớp!";
                return View();
            }

            // 2. Kiểm tra tài khoản đã tồn tại chưa
            if (await _context.TaiKhoans.AnyAsync(t => t.UserName == username))
            {
                ViewBag.Error = "Tên đăng nhập này đã được sử dụng!";
                return View();
            }

            // 3. TẠO TÀI KHOẢN (Bảng TAI_KHOAN)
            var taiKhoan = new TaiKhoan
            {
                UserName = username,
                MatKhau = password,
                QuyenHan = "KhachHang" // Mặc định là khách
            };
            _context.Add(taiKhoan);

            // 4. TẠO THÔNG TIN KHÁCH (Bảng KHACH_HANG)
            // Sinh mã KH ngẫu nhiên dựa trên thời gian để không trùng lặp
            string maKhMoi = "KH" + DateTime.Now.Ticks.ToString().Substring(12);

            var khachHang = new KhachHang
            {
                MaKh = maKhMoi,
                HoTen = hoten,
                SoDt = sdt,
                UserName = username, // Liên kết khóa ngoại
                CapHoiVien = "CoBan", // Giá trị mặc định
                DiemTichLuy = 0,      // Giá trị mặc định
                Email = username      // Tạm lấy username làm email luôn cho tiện
            };
            _context.Add(khachHang);

            // 5. Lưu vào Database
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Đăng ký thành công! Vui lòng đăng nhập.";
            return RedirectToAction("Login");
        }
    }
}