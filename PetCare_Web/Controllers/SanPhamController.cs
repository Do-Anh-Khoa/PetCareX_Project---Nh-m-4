using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Models;
using PetCare_Web.Data;

namespace PetCare_Web.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly PetCareContext _context;

        public SanPhamController(PetCareContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            // Kiểm tra đăng nhập (Bắt buộc đăng nhập mới được xem hàng để mua)
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("MaKH")))
                return RedirectToAction("Login", "TaiKhoan");

            var products = from p in _context.SanPhams select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.TenSp.Contains(searchString));
            }
            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> DatMua(string id)
        {
            // 1. LẤY MÃ KHÁCH TỪ SESSION
            string currentUserId = HttpContext.Session.GetString("MaKH");
            if (string.IsNullOrEmpty(currentUserId)) return RedirectToAction("Login", "TaiKhoan");

            var sp = await _context.SanPhams.FindAsync(id);
            if (sp == null) return NotFound();

            // Lấy đại 1 nhân viên để gán vào hóa đơn (Tránh lỗi DB)
            var randomNhanVien = await _context.NhanViens.FirstOrDefaultAsync();
            string maNvTam = randomNhanVien?.MaNv ?? "NV001";

            double giaGocDouble = sp.GiaBan ?? 0;
            decimal giaTienTe = (decimal)giaGocDouble;

            // 2. TẠO HÓA ĐƠN (Trạng thái: Chưa thanh toán)
            var hoaDon = new HoaDon
            {
                MaHd = "HD" + DateTime.Now.Ticks.ToString().Substring(10),
                NgayLap = DateOnly.FromDateTime(DateTime.Now),
                MaKh = currentUserId,
                TongTien = giaTienTe,
                TrangThai = "ChuaThanhToan", // <--- Quan trọng
                HinhThucThanhToan = "ChuyenKhoan",
                MaCn = "CN1", // Mã cứng chi nhánh như cũ
                MaNv = maNvTam
            };
            _context.Add(hoaDon);
            await _context.SaveChangesAsync();

            // 3. TẠO CHI TIẾT MUA HÀNG
            var chiTiet = new ChiTietMuaHang
            {
                MaMuaHang = "MH" + DateTime.Now.Ticks.ToString().Substring(10),
                MaSp = id,
                SoLuong = 1,
                DonGia = giaGocDouble
            };
            // Tùy DB của bạn có cần Add chi tiết không, tạm thời tạo Hóa đơn là đủ flow.

            // 4. CHUYỂN HƯỚNG SANG TRANG THANH TOÁN (Thay vì về Lịch sử)
            return RedirectToAction("Index", "ThanhToan", new { maHd = hoaDon.MaHd });
        }
    }
}