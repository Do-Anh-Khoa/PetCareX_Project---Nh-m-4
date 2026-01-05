using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using PetCare_Web.Data;
using PetCare_Web.Models;

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
                MessageBox.Show("Vui lòng nhập lại thông tin!");
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
                            // Lấy thông tin bác sĩ từ database
                            var bacSi = context.NhanViens
                                .FirstOrDefault(nv => nv.UserName == username);

                            if (bacSi != null)
                            {
                                // Lưu thông tin bác sĩ vào Session
                                UserSession.MaNhanVien = bacSi.MaNv;
                                UserSession.TenNhanVien = bacSi.HoTen;
                                UserSession.UserName = username;
                                UserSession.QuyenHan = user.QuyenHan;
                            }

                            // Mở form Bác sĩ dưới dạng Dialog (Chương trình sẽ dừng ở dòng này chờ Bác sĩ đóng form)
                            Lich_Hen frmBacSi = new Lich_Hen();
                            frmBacSi.ShowDialog();
                        }

                        // TH3: NHÂN VIÊN (NV...) -> Mở Trang Chủ / Dashboard
                        else if (username.StartsWith("NV", StringComparison.OrdinalIgnoreCase))
                        {
                            // Lấy thông tin nhân viên từ database
                            var nhanVien = context.NhanViens
                                .FirstOrDefault(nv => nv.UserName == username);

                            if (nhanVien != null)
                            {
                                // Lưu thông tin nhân viên vào Session
                                UserSession.MaNhanVien = nhanVien.MaNv;
                                UserSession.TenNhanVien = nhanVien.HoTen;
                                UserSession.UserName = username;
                                UserSession.QuyenHan = user.QuyenHan;
                            }

                            // Mở form Quản lý dưới dạng Dialog (Chờ đóng form)
                            FrmHome frmNhanVien = new FrmHome();
                            frmNhanVien.ShowDialog();
                        }

                        // TH4: QUẢN LÝ (QL...) -> Mở Trang Chủ / Quản lý
                        else if (username.StartsWith("QL", StringComparison.OrdinalIgnoreCase))
                        {
                            // Lấy thông tin quản lý từ database
                            var quanLy = context.NhanViens
                                .FirstOrDefault(nv => nv.UserName == username);

                            if (quanLy != null)
                            {
                                // Lưu thông tin quản lý vào Session
                                UserSession.MaNhanVien = quanLy.MaNv;
                                UserSession.TenNhanVien = quanLy.HoTen;
                                UserSession.UserName = username;
                                UserSession.QuyenHan = user.QuyenHan;
                            }

                            // Mở form Quản lý dưới dạng Dialog (Chờ đóng form)
                            FrmQuanLy frmQuanLy = new FrmQuanLy();
                            frmQuanLy.ShowDialog();
                        }

                        // Trường hợp khác
                        else
                        {
                            MessageBox.Show("Tài khoản này chưa được phân quyền cụ thể.");
                        }

                        // 4. HIỆN LẠI FORM LOGIN (Logic Đăng Xuất)
                        // ---------------------------------------------------------
                        // Khi code chạy đến đây nghĩa là các form con (Lich_Hen, FrmHome) đã bị đóng lại

                        // Xóa thông tin phiên làm việc
                        UserSession.Clear();

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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}