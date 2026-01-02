using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetCare_Web.Models;
using PetCare_Web.Data;

namespace PetCare_Web.Controllers
{
    public class DatLichController : Controller
    {
        private readonly PetCareContext _context;

        public DatLichController(PetCareContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Load danh sách Bác sĩ và Chi nhánh
            ViewData["MaBs"] = new SelectList(_context.NhanViens.Where(n => n.ChucVu == "BacSi"), "MaNv", "HoTen");
            ViewData["MaCn"] = new SelectList(_context.ChiNhanhs, "MaCn", "TenChiNhanh");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TaoLich([Bind("NgayHen,GioHen,MaBs,MaCn,GhiChu")] LichHen lichHen)
        {
            // CHỐT CỨNG KH1045 ĐỂ KHỚP VỚI TRANG LỊCH SỬ
            string currentUserId = HttpContext.Session.GetString("MaKH");
            if (string.IsNullOrEmpty(currentUserId)) return RedirectToAction("Login", "TaiKhoan");

            // Loại bỏ các lỗi validate không cần thiết
            ModelState.Remove("MaLichHen");
            ModelState.Remove("MaKh");
            ModelState.Remove("TrangThai");
            ModelState.Remove("MaKhNavigation");
            ModelState.Remove("MaBsNavigation");
            ModelState.Remove("MaCnNavigation");

            if (ModelState.IsValid)
            {
                lichHen.MaLichHen = "LH" + DateTime.Now.Ticks.ToString().Substring(10);
                lichHen.MaKh = currentUserId;
                lichHen.TrangThai = "ChoXacNhan"; // Trạng thái này sẽ hiện là "Chờ duyệt"

                _context.Add(lichHen);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "🎉 Đặt lịch khám thành công! Vui lòng chờ xác nhận.";
                return RedirectToAction("Index", "LichSu");
            }

            // Nếu lỗi, load lại danh sách để không bị trắng trang
            ViewData["MaBs"] = new SelectList(_context.NhanViens.Where(n => n.ChucVu == "BacSi"), "MaNv", "HoTen");
            ViewData["MaCn"] = new SelectList(_context.ChiNhanhs, "MaCn", "TenChiNhanh");
            return View("Index", lichHen);
        }
    }
}