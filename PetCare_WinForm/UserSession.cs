using System;

namespace PetCare_WinForm
{
    /// <summary>
    /// Class static ?? l?u thông tin phiên ??ng nh?p c?a ng??i dùng
    /// Có th? truy c?p t? b?t k? form nào trong ?ng d?ng
    /// </summary>
    public static class UserSession
    {
        public static string MaNhanVien { get; set; }
        public static string TenNhanVien { get; set; }
        public static string UserName { get; set; }
        public static string QuyenHan { get; set; }

        /// <summary>
        /// Xóa toàn b? thông tin phiên làm vi?c (dùng khi ??ng xu?t)
        /// </summary>
        public static void Clear()
        {
            MaNhanVien = null;
            TenNhanVien = null;
            UserName = null;
            QuyenHan = null;
        }
    }
}
