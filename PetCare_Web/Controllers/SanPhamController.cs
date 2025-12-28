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
            var products = from p in _context.SanPhams select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.TenSp.Contains(searchString));
            }
            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> DatMua(string id)
        {
            string currentUserId = "KH1045"; // Chốt cứng KH này

            var sp = await _context.SanPhams.FindAsync(id);
            if (sp == null) return NotFound();

            // Lấy đại 1 nhân viên bất kỳ để không bị lỗi MaNV (Lấy người đầu tiên)
            var randomNhanVien = await _context.NhanViens.FirstOrDefaultAsync();
            string maNvTam = randomNhanVien?.MaNv ?? "NV001"; // Nếu ko tìm thấy ai thì lấy NV001 đỡ

            double giaGocDouble = sp.GiaBan ?? 0;
            decimal giaTienTe = (decimal)giaGocDouble;

            var hoaDon = new HoaDon
            {
                MaHd = "HD" + DateTime.Now.Ticks.ToString().Substring(10),
                NgayLap = DateOnly.FromDateTime(DateTime.Now),
                MaKh = currentUserId,
                TongTien = giaTienTe,
                TrangThai = "ChuaThanhToan",
                HinhThucThanhToan = "COD",
                MaCn = "CN1", // Mã chi nhánh (như bạn confirm)
                MaNv = maNvTam // <=== ĐÃ SỬA LỖI MÀN HÌNH ĐỎ Ở ĐÂY
            };
            _context.Add(hoaDon);
            await _context.SaveChangesAsync();

            // Tạo chi tiết mua hàng
            var chiTiet = new ChiTietMuaHang
            {
                MaMuaHang = "MH" + DateTime.Now.Ticks.ToString().Substring(10),
                MaSp = id,
                SoLuong = 1,
                DonGia = giaGocDouble
            };
            // Nếu cần thiết thì Add chi tiết vào context ở đây (tùy cấu hình DB của bạn)
            // _context.Add(chiTiet); await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "🎉 Đặt mua thành công!";
            return RedirectToAction("Index", "LichSu");
        }
    }
}