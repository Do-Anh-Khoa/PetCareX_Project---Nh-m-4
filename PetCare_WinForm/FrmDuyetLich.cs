using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using PetCare_Web.Data;
using PetCare_Web.Models;

namespace PetCare_WinForm
{
    public partial class FrmDuyetLich : Form
    {
        private readonly PetCareContext _context;

        // Biến lưu mã khách hàng nếu tìm thấy (để phân biệt khách cũ/mới)
        private string _maKhachHangHienTai = null;

        public FrmDuyetLich()
        {
            InitializeComponent();
            _context = new PetCareContext();
        }

        private void FrmDuyetLich_Load(object sender, EventArgs e)
        {
            LoadLichHen();
            LoadComboBoxData();

            ToggleCheDoNhapThuCung(false);
        }

        /// <summary>
        /// HÀM HỖ TRỢ: Ẩn/Hiện ô nhập thú cưng mới
        /// </summary>
        private void ToggleCheDoNhapThuCung(bool isNhapMoi)
        {
            if (isNhapMoi)
            {
                // KHÁCH MỚI: Hiện ô nhập Textbox, Ẩn ComboBox
                cmbThuCung.Visible = false;
                txtTenPetMoi.Visible = true;
                lblLoaiPetMoi.Visible = true;
                txtLoaiPetMoi.Visible = true;
                txtTenPetMoi.Clear();
            }
            else
            {
                // KHÁCH CŨ: Hiện ComboBox, Ẩn ô nhập Textbox
                cmbThuCung.Visible = true;
                txtTenPetMoi.Visible = false;
                lblLoaiPetMoi.Visible = false;
                txtLoaiPetMoi.Visible = false;
            }
        }

        /// <summary>
        /// Load danh sách lịch hẹn chờ duyệt (TrangThai = 'ChoXacNhan' hoặc NULL)
        /// </summary>
        private void LoadLichHen()
        {
            try
            {
                var lichHenList = _context.LichHenViews
                    .FromSqlRaw("EXEC sp_GetLichHenChoDuyet")
                    .ToList();

                dgvLichHen.DataSource = lichHenList;

                // Đặt tên cột hiển thị
                if (dgvLichHen.Columns.Count > 0)
                {
                    dgvLichHen.Columns["MaLichHen"].HeaderText = "Mã Lịch Hẹn";
                    dgvLichHen.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
                    dgvLichHen.Columns["SoDT"].HeaderText = "Số ĐT";
                    dgvLichHen.Columns["NgayHen"].HeaderText = "Ngày Hẹn";
                    dgvLichHen.Columns["GioHen"].HeaderText = "Giờ Hẹn";
                    dgvLichHen.Columns["TenBacSi"].HeaderText = "Bác Sĩ";
                    dgvLichHen.Columns["TenChiNhanh"].HeaderText = "Chi Nhánh";
                    dgvLichHen.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    dgvLichHen.Columns["GhiChu"].HeaderText = "Ghi Chú";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load dữ liệu cho ComboBox Bác sĩ và Chi nhánh
        /// </summary>
        private void LoadComboBoxData()
        {
            try
            {
                // Gọi SP lấy Bác sĩ -> map vào BacSiView
                var bacSiList = _context.BacSiViews
                    .FromSqlRaw("EXEC sp_GetDanhSachBacSi")
                    .ToList();

                cmbBacSi.DataSource = bacSiList;
                cmbBacSi.DisplayMember = "HoTen";
                cmbBacSi.ValueMember = "MaNv";

                // Gọi SP lấy Chi nhánh -> map vào ChiNhanhView
                var chiNhanhList = _context.ChiNhanhViews
                    .FromSqlRaw("EXEC sp_GetDanhSachChiNhanh")
                    .ToList();

                cmbChiNhanh.DataSource = chiNhanhList;
                cmbChiNhanh.DisplayMember = "TenChiNhanh";
                cmbChiNhanh.ValueMember = "MaCn";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ComboBox: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút DUYỆT - Cập nhật trạng thái lịch hẹn thành 'DaXacNhan'
        /// </summary>
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLichHen.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn lịch hẹn cần duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã lịch hẹn từ dòng được chọn
                string maLichHen = dgvLichHen.SelectedRows[0].Cells["MaLichHen"].Value.ToString()!;

                // Xác nhận trước khi duyệt
                var result = MessageBox.Show($"Bạn có chắc muốn duyệt lịch hẹn [{maLichHen}]?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Tìm và cập nhật trạng thái
                    var lichHen = _context.LichHens.FirstOrDefault(l => l.MaLichHen == maLichHen);
                    if (lichHen != null)
                    {
                        lichHen.TrangThai = "DaXacNhan";
                        _context.SaveChanges();

                        MessageBox.Show("Duyệt lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLichHen(); // Refresh danh sách
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi duyệt: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút TẠO LỊCH KHÁM - Hiển thị form nhập thông tin khách vãng lai
        /// </summary>
        private void btnTaoLichKham_Click(object sender, EventArgs e)
        {
            groupBoxTaoLich.Visible = true;
            ClearInputFields();
            txtSoDT.Focus();    // Focus vào đây để nhắc người dùng nhập SĐT
        }

        /// <summary>
        /// NÚT TÌM KIẾM: Tìm theo SĐT -> Load tên & Thú cưng)
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sdt = txtSoDT.Text.Trim();
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tìm khách hàng và include luôn danh sách thú cưng
                // Gọi SP tìm khách hàng -> map vào KhachHangInfoView
                var pSdt = new Microsoft.Data.SqlClient.SqlParameter("@SoDt", sdt);

                var khachHangInfo = _context.KhachHangInfoViews
                    .FromSqlRaw("EXEC sp_GetKhachHangInfoBySDT @SoDt", pSdt)
                    .AsEnumerable()
                    .FirstOrDefault();

                if (khachHangInfo != null)
                {
                    // === KHÁCH CŨ ===
                    _maKhachHangHienTai = khachHangInfo.MaKH; // Lưu lại mã

                    // Điền thông tin lên form
                    txtTenKH.Text = khachHangInfo.HoTen;
                    txtTenKH.ReadOnly = true; // Khóa không cho sửa tên khách cũ (tuỳ bạn chọn)

                    // Xử lý ComboBox Thú Cưng
                    ToggleCheDoNhapThuCung(false);  // Chuyển sang chế độ chọn
                    cmbThuCung.Enabled = true;

                    // RESET DATASOURCE TRƯỚC KHI GÁN MỚI
                    cmbThuCung.DataSource = null;
                    cmbThuCung.Items.Clear();

                    // Gọi SP lấy thú cưng -> map vào ThuCungInfoView
                    var pMaKh = new Microsoft.Data.SqlClient.SqlParameter("@MaKh", khachHangInfo.MaKH);

                    var listThuCung = _context.ThuCungInfoViews
                        .FromSqlRaw("EXEC sp_GetThuCungInfoByMaKh @MaKh", pMaKh)
                        .ToList();

                    if (listThuCung.Any())
                    {
                        cmbThuCung.DataSource = listThuCung;
                        cmbThuCung.DisplayMember = "TenTc";     // Tên cột hiển thị (VD: Milu, Kiki)
                        cmbThuCung.ValueMember = "TenTc";        // Tên cột giá trị (Tên thú cưng)
                    }
                    else
                    {
                        cmbThuCung.Items.Clear();
                        cmbThuCung.Items.Add("Chưa có thú cưng");
                        cmbThuCung.SelectedIndex = 0;
                    }

                    MessageBox.Show($"Tìm thấy khách hàng: {khachHangInfo.HoTen}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // === KHÁCH MỚI ===
                    _maKhachHangHienTai = null; // Reset biến

                    txtTenKH.Clear();
                    txtTenKH.ReadOnly = false; // Mở khóa cho nhập tên mới
                    ToggleCheDoNhapThuCung(true); // Chuyển sang chế độ nhập mới

                    MessageBox.Show("Khách hàng chưa tồn tại. Vui lòng nhập tên để tạo mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenKH.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        /// <summary>
        /// Nút LƯU - Insert lịch hẹn mới
        /// </summary>
        private void btnLuuLichMoi_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validate
                if (string.IsNullOrWhiteSpace(txtTenKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }

                string finalMaKh = "";
                string tenThuCungGhiChu = "";

                // 2. XỬ LÝ KHÁCH HÀNG
                if (_maKhachHangHienTai != null)
                {
                    // TRƯỜNG HỢP KHÁCH CŨ: Dùng lại mã đã tìm thấy
                    finalMaKh = _maKhachHangHienTai;

                    if (cmbThuCung.Items.Count > 0 && cmbThuCung.DataSource != null)
                    {
                        tenThuCungGhiChu = cmbThuCung.Text;
                    }
                }
                else
                {
                    // TRƯỜNG HỢP KHÁCH MỚI: Tạo khách hàng mới

                    // Kiểm tra trùng lặp lần cuối
                    var checkExist = _context.KhachHangs.FirstOrDefault(k => k.SoDt == txtSoDT.Text.Trim());
                    if (checkExist != null)
                    {
                        MessageBox.Show($"SĐT này đã có chủ ({checkExist.HoTen}). Vui lòng bấm Tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    finalMaKh = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    var khachHangMoi = new KhachHang
                    {
                        MaKh = finalMaKh,
                        HoTen = txtTenKH.Text.Trim(),
                        SoDt = txtSoDT.Text.Trim(),
                        CapHoiVien = "CoBan",
                        DiemTichLuy = 0
                    };
                    _context.KhachHangs.Add(khachHangMoi);

                    if (!string.IsNullOrWhiteSpace(txtTenPetMoi.Text))
                    {
                        var thuCungMoi = new ThuCung
                        {
                            MaTc = "TC" + DateTime.Now.ToString("ddHHmmss"),
                            TenTc = txtTenPetMoi.Text.Trim(),
                            Loai = txtLoaiPetMoi.Text.Trim(),
                            MaKh = finalMaKh,
                            MaKhNavigation = khachHangMoi
                        };
                        _context.ThuCungs.Add(thuCungMoi);
                        tenThuCungGhiChu = thuCungMoi.TenTc;
                    }
                }

                // 3. XỬ LÝ GHI CHÚ (Ghép tên thú cưng vào ghi chú nếu có chọn)
                string ghiChuFinal = txtGhiChu.Text.Trim();
                if (!string.IsNullOrEmpty(tenThuCungGhiChu))
                {
                    ghiChuFinal = $"[Bé: {tenThuCungGhiChu}] " + ghiChuFinal;
                }

                // 4. TẠO LỊCH HẸN
                string maLichHen = "LH" + DateTime.Now.ToString("yyyyMMddHHmmss");
                var lichHenMoi = new LichHen
                {
                    MaLichHen = maLichHen,
                    MaKh = finalMaKh, // Dùng mã (cũ hoặc mới) ở trên
                    NgayHen = DateOnly.FromDateTime(dtpNgayHen.Value),
                    GioHen = TimeOnly.FromDateTime(dtpGioHen.Value),
                    MaBs = cmbBacSi.SelectedValue?.ToString(),
                    MaCn = cmbChiNhanh.SelectedValue?.ToString(),
                    TrangThai = "DaXacNhan",
                    GhiChu = ghiChuFinal
                };

                _context.LichHens.Add(lichHenMoi);
                _context.SaveChanges();

                MessageBox.Show("Tạo lịch thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                groupBoxTaoLich.Visible = false;
                ClearInputFields();
                LoadLichHen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút HỦY - Đóng form tạo lịch mới
        /// </summary>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            groupBoxTaoLich.Visible = false;
            ClearInputFields();
        }

        /// <summary>
        /// Nút LÀM MỚI - Refresh danh sách
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLichHen();
            MessageBox.Show("Đã làm mới danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Xóa dữ liệu các ô nhập
        /// </summary>
        private void ClearInputFields()
        {
            _maKhachHangHienTai = null; // Reset biến này

            txtTenKH.Clear();
            txtTenKH.ReadOnly = false; // Mở lại ô tên

            txtSoDT.Clear();
            txtGhiChu.Clear();
            dtpNgayHen.Value = DateTime.Now;
            dtpGioHen.Value = DateTime.Now;

            // Xóa text cho các ô nhập thú cưng mới
            txtTenPetMoi.Clear();
            txtLoaiPetMoi.Clear();

            // Reset combo thú cưng
            cmbThuCung.DataSource = null;
            cmbThuCung.Items.Clear();
            cmbThuCung.Enabled = false;

            // Đưa về chế độ mặc định (Khách cũ) để ẩn các ô nhập mới
            ToggleCheDoNhapThuCung(false);
        }

        private void groupBoxTaoLich_Enter(object sender, EventArgs e)
        {

        }
    }
    public class LichHenView
    {
        public string MaLichHen { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDT { get; set; }
        public DateOnly? NgayHen { get; set; }
        public TimeOnly? GioHen { get; set; }
        public string? TenBacSi { get; set; }
        public string? TenChiNhanh { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }
    }

    // Hứng dữ liệu cho ComboBox (Dùng chung cho Bác sĩ, Chi nhánh, Thú cưng, Khách hàng)

    public class BacSiView { public string MaNV { get; set; } public string HoTen { get; set; } }

    public class ChiNhanhView { public string MaCN { get; set; } public string TenChiNhanh { get; set; } }

    public class KhachHangInfoView { public string MaKH { get; set; } public string HoTen { get; set; } }

    public class ThuCungInfoView { public string MaTC { get; set; } public string TenTC { get; set; } }

}
