using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Data;
using PetCare_Web.Models;

namespace PetCare_WinForm
{
    public partial class Kham_Benh : Form
    {
        private readonly PetCareContext _context;
        private readonly string _maLichHen;
        private readonly string _maBacSi;
        private string? _maKhachHang;
        private string? _maChiNhanh;

        public Kham_Benh()
        {
            InitializeComponent();
            _context = new PetCareContext();
            _maLichHen = "";
            _maBacSi = "";
        }

        public Kham_Benh(string maLichHen, string tenKhachHang, string tenBacSi, string maBacSi, DateOnly? ngayKham)
        {
            InitializeComponent();
            _context = new PetCareContext();
            _maLichHen = maLichHen;
            _maBacSi = maBacSi;

            // Hiển thị thông tin
            lblMaLichHen.Text = $"Mã lịch hẹn: {maLichHen}";
            lblTenChu.Text = $"Chủ: {tenKhachHang}";
            lblTenBacSi.Text = $"Bác sĩ: {tenBacSi}";
            lblNgayKham.Text = $"Ngày: {ngayKham?.ToString("dd/MM/yyyy") ?? DateTime.Now.ToString("dd/MM/yyyy")}";

            // Lấy thông tin khách hàng và chi nhánh từ lịch hẹn
            var lichHen = _context.LichHens.FirstOrDefault(l => l.MaLichHen == maLichHen);
            if (lichHen != null)
            {
                _maKhachHang = lichHen.MaKh;
                _maChiNhanh = lichHen.MaCn;

                // Tu dong dien Trieu Chung tu Ghi Chu cua lich hen
                if (!string.IsNullOrEmpty(lichHen.GhiChu))
                {
                    txtTrieuChung.Text = lichHen.GhiChu;
                }
            }
        }

        private void Kham_Benh_Load(object sender, EventArgs e)
        {
            LoadVaccine();
        }

        /// <summary>
        /// Xử lý khi thay đổi radio button điều trị
        /// </summary>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Ẩn tất cả panel
            pnlToaThuoc.Visible = false;
            pnlVaccine.Visible = false;

            // Hiển thị panel tương ứng
            if (rBtnToaThuoc.Checked)
            {
                pnlToaThuoc.Visible = true;
            }
            else if (rBtnVacXin.Checked)
            {
                pnlVaccine.Visible = true;
            }
        }

        /// <summary>
        /// Load danh sách vaccine
        /// </summary>
        private void LoadVaccine()
        {
            try
            {
                dgvVacXin.Columns.Clear();
                dgvVacXin.AutoGenerateColumns = true;

                var vaccines = _context.Vaccines
                    .Select(v => new
                    {
                        v.MaVc,
                        v.TenVc,
                        v.LoaiVc,
                        v.GiaVc
                    })
                    .ToList();

                dgvVacXin.DataSource = vaccines;

                if (dgvVacXin.Columns.Count > 0)
                {
                    dgvVacXin.Columns["MaVc"].HeaderText = "Mã Vaccine";
                    dgvVacXin.Columns["TenVc"].HeaderText = "Tên Vaccine";
                    dgvVacXin.Columns["LoaiVc"].HeaderText = "Loại Vaccine";
                    dgvVacXin.Columns["GiaVc"].HeaderText = "Giá (VNĐ)";
                    dgvVacXin.Columns["GiaVc"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải vaccine: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Hoàn tất khám
        /// </summary>
        private void btnHoanTatKham_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate dữ liệu bắt buộc
                if (string.IsNullOrWhiteSpace(txtTrieuChung.Text))
                {
                    MessageBox.Show("Vui lòng nhập triệu chứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrieuChung.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtChanDoan.Text))
                {
                    MessageBox.Show("Vui lòng nhập chẩn đoán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChanDoan.Focus();
                    return;
                }

                // Validate toa thuốc nếu chọn
                if (rBtnToaThuoc.Checked && string.IsNullOrWhiteSpace(txtToaThuoc.Text))
                {
                    MessageBox.Show("Vui lòng nhập toa thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtToaThuoc.Focus();
                    return;
                }

                // Validate vaccine nếu chọn
                if (rBtnVacXin.Checked && dgvVacXin.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn vaccine để tiêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra mã bác sĩ
                if (string.IsNullOrEmpty(_maBacSi))
                {
                    MessageBox.Show("Không có thông tin bác sĩ phụ trách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận trước khi lưu
                var result = MessageBox.Show("Bạn có chắc muốn hoàn tất khám bệnh?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // Tạo toa thuốc (kết hợp tên thuốc + liều dùng)
                string? toaThuoc = null;
                if (rBtnToaThuoc.Checked)
                {
                    toaThuoc = txtToaThuoc.Text.Trim();
                    if (!string.IsNullOrEmpty(txtLieuDung.Text))
                    {
                        toaThuoc += $" | Liều dùng: {txtLieuDung.Text.Trim()}";
                    }
                }

                // Cập nhật trạng thái lịch hẹn thành "DaKham"
                var lichHen = _context.LichHens.FirstOrDefault(l => l.MaLichHen == _maLichHen);
                if (lichHen != null)
                {
                    lichHen.TrangThai = "DaKham";

                    // Thêm ghi chú về kết quả khám
                    string ketQuaKham = $"[Khám: {DateTime.Now:dd/MM/yyyy HH:mm}] " +
                                       $"Triệu chứng: {txtTrieuChung.Text.Trim()}. " +
                                       $"Chẩn đoán: {txtChanDoan.Text.Trim()}.";

                    if (!string.IsNullOrEmpty(toaThuoc))
                    {
                        ketQuaKham += $" Toa thuốc: {toaThuoc}.";
                    }

                    if (rBtnVacXin.Checked && dgvVacXin.SelectedRows.Count > 0)
                    {
                        string tenVaccine = dgvVacXin.SelectedRows[0].Cells["TenVc"].Value?.ToString() ?? "";
                        ketQuaKham += $" Tiêm vaccine: {tenVaccine}.";
                    }

                    // Cập nhật ghi chú
                    lichHen.GhiChu = string.IsNullOrEmpty(lichHen.GhiChu)
                        ? ketQuaKham
                        : lichHen.GhiChu + " | " + ketQuaKham;
                }

                _context.SaveChanges();

                MessageBox.Show($"Hoàn tất khám bệnh!\n\nMã lịch hẹn: {_maLichHen}\nBác sĩ: {lblTenBacSi.Text}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Hiển thị chi tiết lỗi
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nChi tiết: {ex.InnerException.Message}";
                }
                MessageBox.Show($"Lỗi: {errorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Hủy
        /// </summary>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn hủy? Dữ liệu sẽ không được lưu.",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// Nút Xem Lịch Sử - Hiển thị lịch sử khám của khách hàng
        /// </summary>
        private void btnXemLichSu_Click(object sender, EventArgs e)
        {
            try
            {
                // Toggle hiển thị panel lịch sử
                grpLichSu.Visible = !grpLichSu.Visible;

                if (grpLichSu.Visible)
                {
                    LoadLichSuKham();
                    btnXemLichSu.Text = "ẨN LỊCH SỬ";
                    btnXemLichSu.BackColor = Color.FromArgb(108, 117, 125);
                }
                else
                {
                    btnXemLichSu.Text = "XEM LỊCH SỬ";
                    btnXemLichSu.BackColor = Color.FromArgb(255, 193, 7);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load lịch sử khám của khách hàng từ bảng DV_KHAM
        /// </summary>
        private void LoadLichSuKham()
        {
            try
            {
                dgvLichSuKham.Columns.Clear();
                dgvLichSuKham.AutoGenerateColumns = true;

                // 1. Lấy MaTC (Mã thú cưng)
                // Lấy thú cưng đầu tiên của khách hàng
                string? maThuCung = null;
                if (!string.IsNullOrEmpty(_maKhachHang))
                {
                    var thuCung = _context.ThuCungs.FirstOrDefault(tc => tc.MaKh == _maKhachHang);
                    maThuCung = thuCung?.MaTc;
                }

                // Kiểm tra nếu không tìm thấy thú cưng
                if (string.IsNullOrEmpty(maThuCung))
                {
                    // Trường hợp khách chưa có thú cưng hoặc dữ liệu lỗi, load lưới trống hoặc thông báo
                    return;
                }

                // 2. Gọi Stored Procedure
                var lichSuData = _context.Database
                    .SqlQueryRaw<LichSuKhamResult>("EXEC sp_GetLichSuKham @MaTC",
                        new SqlParameter("@MaTC", maThuCung))
                    .ToList();

                // 3. Đổ dữ liệu vào GridView
                dgvLichSuKham.DataSource = lichSuData;

                // 4. Định dạng cột hiển thị
                if (dgvLichSuKham.Columns.Count > 0)
                {
                    dgvLichSuKham.Columns["NgayKham"].HeaderText = "Ngày Khám";
                    dgvLichSuKham.Columns["NgayKham"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    dgvLichSuKham.Columns["TrieuChung"].HeaderText = "Triệu Chứng";
                    dgvLichSuKham.Columns["ChuanDoan"].HeaderText = "Chẩn Đoán";
                    dgvLichSuKham.Columns["ToaThuoc"].HeaderText = "Toa Thuốc";

                    dgvLichSuKham.Columns["NgayTaiKham"].HeaderText = "Hẹn Tái Khám";
                    dgvLichSuKham.Columns["NgayTaiKham"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    dgvLichSuKham.Columns["BacSiPhuTrach"].HeaderText = "Bác Sĩ";
                    dgvLichSuKham.Columns["MaHoSo"].HeaderText = "Mã Hồ Sơ";
                    dgvLichSuKham.Columns["MaHoSo"].Visible = false; // Ẩn mã hồ sơ nếu không cần thiết
                }
            }
            catch (SqlException sqlEx)
            {
                // Bắt lỗi riêng của SQL (ví dụ lỗi 50001 bạn throw trong SP)
                MessageBox.Show($"Lỗi dữ liệu: {sqlEx.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử khám: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Lưu Bệnh Án - Insert vào bảng DICH_VU và DV_KHAM
        /// </summary>
        private void btnLuuBenhAn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate dữ liệu
                if (string.IsNullOrWhiteSpace(txtTrieuChung.Text))
                {
                    MessageBox.Show("Vui lòng nhập triệu chứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrieuChung.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtChanDoan.Text))
                {
                    MessageBox.Show("Vui lòng nhập chẩn đoán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChanDoan.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(_maBacSi))
                {
                    MessageBox.Show("Không có thông tin bác sĩ phụ trách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(_maChiNhanh))
                {
                    MessageBox.Show("Không có thông tin chi nhánh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận trước khi lưu
                var result = MessageBox.Show("Bạn có chắc muốn lưu bệnh án vào hệ thống?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // Tạo mã dịch vụ mới
                string maDichVu = "DV" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Lấy mã thú cưng (nếu có) - lấy thú cưng đầu tiên của khách hàng
                string? maThuCung = null;
                if (!string.IsNullOrEmpty(_maKhachHang))
                {
                    var thuCung = _context.ThuCungs.FirstOrDefault(tc => tc.MaKh == _maKhachHang);
                    maThuCung = thuCung?.MaTc;
                }

                // 1. Insert vào bảng DICH_VU
                var dichVu = new DichVu
                {
                    MaDv = maDichVu,
                    MaTc = maThuCung,
                    MaCn = _maChiNhanh
                };
                _context.DichVus.Add(dichVu);

                // 2. Tạo toa thuốc
                string? toaThuoc = null;
                if (rBtnToaThuoc.Checked && !string.IsNullOrWhiteSpace(txtToaThuoc.Text))
                {
                    toaThuoc = txtToaThuoc.Text.Trim();
                    if (!string.IsNullOrEmpty(txtLieuDung.Text))
                    {
                        toaThuoc += $" | Liều dùng: {txtLieuDung.Text.Trim()}";
                    }
                }

                // 3. Insert vào bảng DV_KHAM
                var dvKham = new DvKham
                {
                    MaKham = maDichVu, // MaKham = MaDv (1-1 relationship)
                    TrieuChung = txtTrieuChung.Text.Trim(),
                    ChuanDoan = txtChanDoan.Text.Trim(),
                    ToaThuoc = toaThuoc,
                    BacSiPhuTrach = _maBacSi,
                    NgayTaiKham = null,
                    GiaKhamBenh = 100000 // Giá mặc định
                };
                _context.DvKhams.Add(dvKham);

                _context.SaveChanges();

                MessageBox.Show($"Lưu bệnh án thành công!\n\nMã dịch vụ: {maDichVu}",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh lịch sử khám nếu đang hiển thị
                if (grpLichSu.Visible)
                {
                    LoadLichSuKham();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nChi tiết: {ex.InnerException.Message}";
                }
                MessageBox.Show($"Lỗi khi lưu bệnh án: {errorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grpDieuTri_Enter(object sender, EventArgs e)
        {
            // Add your logic here if needed
        }
    }
    public class LichSuKhamResult
    {
        public DateTime NgayKham { get; set; }
        public string? TrieuChung { get; set; }
        public string? ChuanDoan { get; set; }
        public string? ToaThuoc { get; set; }
        public DateTime? NgayTaiKham { get; set; }
        public string? BacSiPhuTrach { get; set; }
        public string? MaHoSo { get; set; }
    }
}
