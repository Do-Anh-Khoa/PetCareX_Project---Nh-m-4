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

            //Mặc định khóa chọn thú cưng khi mới vào
            cmbThuCung.Enabled = false;
        }

        /// <summary>
        /// Load danh sách lịch hẹn chờ duyệt (TrangThai = 'ChoXacNhan' hoặc NULL)
        /// </summary>
        private void LoadLichHen()
        {
            try
            {
                var lichHenList = _context.LichHens
                    .Include(l => l.MaKhNavigation)
                    .Include(l => l.MaBsNavigation)
                    .Include(l => l.MaCnNavigation)
                    .Where(l => l.TrangThai == "ChoXacNhan" || l.TrangThai == null || l.TrangThai == "")
                    .Select(l => new
                    {
                        l.MaLichHen,
                        TenKhachHang = l.MaKhNavigation != null ? l.MaKhNavigation.HoTen : "Khách vãng lai",
                        SoDT = l.MaKhNavigation != null ? l.MaKhNavigation.SoDt : "",
                        l.NgayHen,
                        l.GioHen,
                        TenBacSi = l.MaBsNavigation != null ? l.MaBsNavigation.HoTen : "",
                        TenChiNhanh = l.MaCnNavigation != null ? l.MaCnNavigation.TenChiNhanh : "",
                        l.TrangThai,
                        l.GhiChu
                    })
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
                // Load danh sách bác sĩ
                var bacSiList = _context.NhanViens
                    .Where(nv => nv.ChucVu == "BacSi" || nv.ChucVu == "Bác sĩ")
                    .Select(nv => new { nv.MaNv, nv.HoTen })
                    .ToList();

                cmbBacSi.DataSource = bacSiList;
                cmbBacSi.DisplayMember = "HoTen";
                cmbBacSi.ValueMember = "MaNv";

                // Load danh sách chi nhánh
                var chiNhanhList = _context.ChiNhanhs
                    .Select(cn => new { cn.MaCn, cn.TenChiNhanh })
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
                var khachHang = _context.KhachHangs
                    .Include(k => k.ThuCungs)
                    .FirstOrDefault(k => k.SoDt == sdt);

                if (khachHang != null)
                {
                    // === KHÁCH CŨ ===
                    _maKhachHangHienTai = khachHang.MaKh; // Lưu lại mã

                    // Điền thông tin lên form
                    txtTenKH.Text = khachHang.HoTen;
                    txtTenKH.ReadOnly = true; // Khóa không cho sửa tên khách cũ (tuỳ bạn chọn)

                    // Xử lý ComboBox Thú Cưng
                    cmbThuCung.Enabled = true;
                    cmbThuCung.DataSource = null;

                    if (khachHang.ThuCungs.Any())
                    {
                        cmbThuCung.DataSource = khachHang.ThuCungs.ToList();
                        cmbThuCung.DisplayMember = "TenThuCung"; // Tên cột hiển thị (VD: Milu, Kiki)
                        cmbThuCung.ValueMember = "TenTc";        // Tên cột giá trị (Tên thú cưng)
                    }
                    else
                    {
                        cmbThuCung.Items.Clear();
                        cmbThuCung.Items.Add("Chưa có thú cưng");
                        cmbThuCung.SelectedIndex = 0;
                    }

                    MessageBox.Show($"Tìm thấy khách hàng: {khachHang.HoTen}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // === KHÁCH MỚI ===
                    _maKhachHangHienTai = null; // Reset biến

                    txtTenKH.Clear();
                    txtTenKH.ReadOnly = false; // Mở khóa cho nhập tên mới

                    cmbThuCung.DataSource = null;
                    cmbThuCung.Items.Clear();
                    cmbThuCung.Enabled = false; // Khách mới chưa có thú cưng trong DB

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
                if (string.IsNullOrWhiteSpace(txtSoDT.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }

                string finalMaKh = "";

                // 2. XỬ LÝ KHÁCH HÀNG
                if (_maKhachHangHienTai != null)
                {
                    // TRƯỜNG HỢP KHÁCH CŨ: Dùng lại mã đã tìm thấy
                    finalMaKh = _maKhachHangHienTai;
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
                        CapHoiVien = "VangLai",
                        DiemTichLuy = 0
                    };
                    _context.KhachHangs.Add(khachHangMoi);
                }

                // 3. XỬ LÝ GHI CHÚ (Ghép tên thú cưng vào ghi chú nếu có chọn)
                string ghiChuFinal = txtGhiChu.Text.Trim();
                if (cmbThuCung.Enabled && cmbThuCung.SelectedItem != null && cmbThuCung.DataSource != null)
                {
                    // Lấy object thú cưng đang chọn
                    var pet = cmbThuCung.SelectedItem as ThuCung;
                    if (pet != null)
                    {
                        ghiChuFinal = $"[Bé: {pet.TenTc}] " + ghiChuFinal;
                    }
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

            // Reset combo thú cưng
            cmbThuCung.DataSource = null;
            cmbThuCung.Items.Clear();
            cmbThuCung.Enabled = false;
        }

        private void groupBoxTaoLich_Enter(object sender, EventArgs e)
        {

        }
    }
}
