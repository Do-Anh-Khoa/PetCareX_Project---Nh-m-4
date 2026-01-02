// using System;
// using System.Diagnostics; // <-- QUAN TRỌNG: Để mở trình duyệt Web
// using System.Linq;
// using System.Windows.Forms;
// using PetCare_Web.Data;
// using PetCare_Web.Models;

// namespace PetCare_WinForm
// {
//     public partial class FrmLogin : Form
//     {
//         public FrmLogin()
//         {
//             InitializeComponent();
//         }

//         private void btnLogin_Click(object sender, EventArgs e)
//         {
//             string username = txtUserName.Text.Trim();
//             string password = txtPassword.Text.Trim();

//             if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//             {
//                 MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
//                 return;
//             }

//             try
//             {
//                 using (var context = new PetCareContext())
//                 {
//                     // 1. Kiểm tra tài khoản trong CSDL
//                    var user = context.TaiKhoans
//                                      .FirstOrDefault(u => u.UserName == username && u.MatKhau == password);
//                     if (user != null)
//                     {
//                         MessageBox.Show("Đăng nhập thành công!");
                        
//                         // 2. XỬ LÝ PHÂN QUYỀN VÀ ĐIỀU HƯỚNG
                        
//                         // --- TRƯỜNG HỢP 1: KHÁCH HÀNG (KH...) -> Sang Website ---
//                         if (username.StartsWith("KH", StringComparison.OrdinalIgnoreCase))
//                         {
//                             // Mở trình duyệt mặc định trỏ tới Web
//                             // LƯU Ý: Thay 5039 bằng cổng localhost máy bạn đang chạy
//                             OpenWebsite("http://localhost:5039"); 
//                         }
                        
//                         // --- TRƯỜNG HỢP 2: BÁC SĨ (BS...) -> Vào form Khám Bệnh ---
//                         else if (username.StartsWith("BS", StringComparison.OrdinalIgnoreCase))
//                         {
//                             this.Hide(); 
//                             Lich_Hen frmBacSi = new Lich_Hen(); // Mở form Lich_Hen.cs
//                             frmBacSi.ShowDialog();
//                             this.Close();
//                         }

//                         // --- TRƯỜNG HỢP 3: NHÂN VIÊN (NV...) -> Vào Dashboard chung ---
//                         else if (username.StartsWith("NV", StringComparison.OrdinalIgnoreCase))
//                         {
//                             this.Hide();
//                             FrmHome frmAdmin = new FrmHome(); // Mở Dashboard quản lý
//                             frmAdmin.ShowDialog();
//                             this.Close();
//                         }
                        
//                         // --- TRƯỜNG HỢP KHÁC ---
//                         else
//                         {
//                             MessageBox.Show("Tài khoản này chưa được cấp quyền truy cập vào hệ thống này.");
//                         }
//                     }
//                     else
//                     {
//                         MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 MessageBox.Show("Lỗi kết nối: " + ex.Message);
//             }
//         }

//         // Hàm phụ trợ để mở trình duyệt web an toàn
//         private void OpenWebsite(string url)
//         {
//             try
//             {
//                 Process.Start(new ProcessStartInfo
//                 {
//                     FileName = url,
//                     UseShellExecute = true
//                 });
//             }
//             catch (Exception ex)
//             {
//                 MessageBox.Show("Không thể mở trình duyệt: " + ex.Message);
//             }
//         }
//     }
// }

using System;
using System.Diagnostics; // Dùng để mở trình duyệt Web
using System.Linq;
using System.Windows.Forms;
using PetCare_Web.Data;   // Namespace chứa DB Context
using PetCare_Web.Models; // Namespace chứa Models (TaiKhoan)

namespace PetCare_WinForm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                txtUserName.Focus();
                return;
            }

            try
            {
                using (var context = new PetCareContext())
                {
                    // 2. Tìm tài khoản trong Database
                    // Lưu ý: Đảm bảo bảng trong DB của bạn tên là TaiKhoans và cột mật khẩu là MatKhau
                    var user = context.TaiKhoans
                                      .FirstOrDefault(u => u.UserName == username && u.MatKhau == password);

                    if (user != null)
                    {
                        // --- ĐĂNG NHẬP THÀNH CÔNG ---
                        
                        // Ẩn form đăng nhập đi để màn hình thoáng
                        this.Hide(); 

                        // 3. PHÂN QUYỀN & ĐIỀU HƯỚNG
                        // ---------------------------------------------------------
                        
                        // TH1: KHÁCH HÀNG (KH...) -> Mở Website
                        if (username.StartsWith("KH", StringComparison.OrdinalIgnoreCase))
                        {
                            OpenWebsite("http://localhost:5039");
                            // Với Web, mở xong thì code chạy tiếp xuống dưới để hiện lại Login luôn
                        }
                        
                        // TH2: BÁC SĨ (BS...) -> Mở Lịch Hẹn / Khám Bệnh
                        else if (username.StartsWith("BS", StringComparison.OrdinalIgnoreCase))
                        {
                            // Mở form Bác sĩ dưới dạng Dialog (Chương trình sẽ dừng ở dòng này chờ Bác sĩ đóng form)
                            Lich_Hen frmBacSi = new Lich_Hen(); 
                            frmBacSi.ShowDialog(); 
                        }
                        
                        // TH3: NHÂN VIÊN (NV...) -> Mở Trang Chủ / Dashboard
                        else if (username.StartsWith("NV", StringComparison.OrdinalIgnoreCase))
                        {
                            // Mở form Quản lý dưới dạng Dialog (Chờ đóng form)
                            FrmHome frmAdmin = new FrmHome(); 
                            frmAdmin.ShowDialog(); 
                        }
                        
                        // Trường hợp khác (ví dụ admin hệ thống)
                        else
                        {
                            MessageBox.Show("Tài khoản này chưa được phân quyền cụ thể.");
                        }

                        // 4. HIỆN LẠI FORM LOGIN (Logic Đăng Xuất)
                        // ---------------------------------------------------------
                        // Khi code chạy đến đây nghĩa là các form con (Lich_Hen, FrmHome) đã bị đóng lại
                        
                        this.Show();             // Hiện lại bảng đăng nhập
                        txtPassword.Text = "";   // Xóa mật khẩu cũ
                        txtUserName.Text = "";   // Xóa tên đăng nhập cũ (nếu thích)
                        txtUserName.Focus();     // Đưa con trỏ chuột về ô nhập tên
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.SelectAll();
                        txtPassword.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
                // Mẹo: Nếu chưa chạy SQL Server hoặc sai chuỗi kết nối sẽ nhảy vào đây
            }
        }

        // Hàm mở trình duyệt Web (Giữ nguyên)
        private void OpenWebsite(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở trình duyệt: " + ex.Message);
            }
        }
    }
}