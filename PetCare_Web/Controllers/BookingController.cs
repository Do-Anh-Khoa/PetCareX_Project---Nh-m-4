using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetCare_Web.Data;
using PetCare_Web.Models;

namespace PetCare_Web.Controllers
{
    public class BookingController : Controller
    {
        // Khai báo biến để kết nối Database
        private readonly PetCareContext _context;

        // Hàm khởi tạo: Giúp Controller này kết nối được với SQL
        public BookingController(PetCareContext context)
        {
            _context = context;
        }

        // --- HÀNH ĐỘNG 1: HIỆN FORM ĐẶT LỊCH ---
        [HttpGet]
        public IActionResult Index()
        {
            // Bản chất: Vào bảng NHAN_VIEN, lọc lấy những người là 'BacSi'.
            // Mục đích: Để đổ dữ liệu vào cái ô chọn Bác sĩ trên giao diện.
            var danhSachBacSi = _context.NhanViens
                .Where(nv => nv.ChucVu == "BacSi" || nv.ChucVu.Contains("BS"))
                .Select(nv => new { nv.MaNv, nv.HoTen }) // Chỉ lấy Mã và Tên cho nhẹ
                .ToList();

            // Đóng gói danh sách này vào ViewBag để bắn sang bên View (Giao diện)
            ViewBag.ListBacSi = new SelectList(danhSachBacSi, "MaNv", "HoTen");

            return View(); // Mở giao diện Index
        }

        // --- HÀNH ĐỘNG 2: XỬ LÝ KHI KHÁCH BẤM NÚT "ĐẶT LỊCH" ---
        [HttpPost]
        public IActionResult Create(DateTime NgayHen, string MaBs, string GhiChu)
        {
            try
            {
                // Giả lập mã khách hàng
                // --- ĐOẠN CODE MỚI: TỰ ĐỘNG LẤY KHÁCH HÀNG THẬT ---
                var khachHangThat = _context.KhachHangs.FirstOrDefault();
                if (khachHangThat == null)
                {
                    return Content("LỖI: Database chưa có dữ liệu Khách Hàng nào cả. Nhờ Quang bơm dữ liệu vào đi!");
                }
                string maKhachHang = khachHangThat.MaKh;
                // --------------------------------------------------

                var lichHenMoi = new LichHen();

                // --- SỬA LẠI ĐOẠN NÀY CHO KHỚP KIỂU DỮ LIỆU MỚI ---

                lichHenMoi.MaLichHen = "LH" + DateTime.Now.ToString("ddHHmmss");

                // 1. Chuyển DateTime sang DateOnly
                lichHenMoi.NgayHen = DateOnly.FromDateTime(NgayHen);

                // 2. Chuyển TimeSpan sang TimeOnly
                lichHenMoi.GioHen = TimeOnly.FromTimeSpan(NgayHen.TimeOfDay);

                // ----------------------------------------------------

                lichHenMoi.MaKh = maKhachHang;
                lichHenMoi.MaBs = MaBs;
                lichHenMoi.TrangThai = "ChoXacNhan";
                lichHenMoi.GhiChu = GhiChu;
                lichHenMoi.MaCn = "CN1";

                _context.LichHens.Add(lichHenMoi);
                _context.SaveChanges();

                return RedirectToAction("Success");
            }
            catch (Exception ex)
            {
                // In cả lỗi bên trong (InnerException) để dễ soi nếu có lỗi tiếp
                return Content("LỖI: " + ex.Message + (ex.InnerException != null ? " - " + ex.InnerException.Message : ""));
            }
        }

        // --- HÀNH ĐỘNG 3: TRANG THÔNG BÁO THÀNH CÔNG ---
        public IActionResult Success()
        {
            return View();
        }
    }
}