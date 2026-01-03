using Microsoft.EntityFrameworkCore;
using PetCare_Web.Data;

namespace PetCare_WinForm
{
    public partial class Lich_Hen : Form
    {
        private readonly PetCareContext _context;

        public Lich_Hen()
        {
            InitializeComponent();
            _context = new PetCareContext();
            btnKhamBenh.Click += btnKhamBenh_Click;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void lich_Hen_Load(object sender, EventArgs e)
        {
            LoadComboBoxTrangThai();
            LoadLichHen();
        }

        /// <summary>
        /// Load ComboBox trạng thái lọc
        /// </summary>
        private void LoadComboBoxTrangThai()
        {
            var trangThaiList = new List<KeyValuePair<string, string>>
            {
                new("", "-- Tất cả --"),
                new("ChoXacNhan", "Chờ xác nhận"),
                new("DaXacNhan", "Đã xác nhận"),
                new("DaHoanThanh", "Đã hoàn thành"),
                new("DaHuy", "Đã hủy")
            };

            cmbLocTrangThai.DataSource = trangThaiList;
            cmbLocTrangThai.DisplayMember = "Value";
            cmbLocTrangThai.ValueMember = "Key";

            // Đặt ngày mặc định
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now.AddMonths(1);
        }

        /// <summary>
        /// Load danh sách lịch hẹn
        /// </summary>
        private void LoadLichHen(string? trangThai = null, DateOnly? tuNgay = null, DateOnly? denNgay = null)
        {
            try
            {
                dsLich_Hen.Columns.Clear();
                dsLich_Hen.AutoGenerateColumns = true;

                var query = _context.LichHens
                    .Include(l => l.MaKhNavigation)
                    .Include(l => l.MaBsNavigation)
                    .Include(l => l.MaCnNavigation)
                    .AsQueryable();

                // Lọc theo trạng thái
                if (!string.IsNullOrEmpty(trangThai))
                {
                    query = query.Where(l => l.TrangThai == trangThai);
                }

                // Lọc theo ngày
                if (tuNgay.HasValue)
                {
                    query = query.Where(l => l.NgayHen >= tuNgay.Value);
                }

                if (denNgay.HasValue)
                {
                    query = query.Where(l => l.NgayHen <= denNgay.Value);
                }

                var lichHenList = query
                    .OrderByDescending(l => l.NgayHen)
                    .ThenByDescending(l => l.GioHen)
                    .Select(l => new
                    {
                        l.MaLichHen,
                        l.NgayHen,
                        l.GioHen,
                        l.TrangThai,
                        l.GhiChu,
                        TenKhachHang = l.MaKhNavigation != null ? l.MaKhNavigation.HoTen : "Khách vãng lai",
                        SoDT = l.MaKhNavigation != null ? l.MaKhNavigation.SoDt : "",
                        TenBacSi = l.MaBsNavigation != null ? l.MaBsNavigation.HoTen : "",
                        MaBacSi = l.MaBs,
                        TenChiNhanh = l.MaCnNavigation != null ? l.MaCnNavigation.TenChiNhanh : ""
                    })
                    .ToList();

                dsLich_Hen.DataSource = lichHenList;

                // Đặt tên cột hiển thị
                if (dsLich_Hen.Columns.Count > 0)
                {
                    dsLich_Hen.Columns["MaLichHen"].HeaderText = "Mã Lịch Hẹn";
                    dsLich_Hen.Columns["NgayHen"].HeaderText = "Ngày Hẹn";
                    dsLich_Hen.Columns["GioHen"].HeaderText = "Giờ Hẹn";
                    dsLich_Hen.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    dsLich_Hen.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dsLich_Hen.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                    dsLich_Hen.Columns["SoDT"].HeaderText = "Số ĐT";
                    dsLich_Hen.Columns["TenBacSi"].HeaderText = "Bác Sĩ";
                    dsLich_Hen.Columns["MaBacSi"].Visible = false;
                    dsLich_Hen.Columns["TenChiNhanh"].HeaderText = "Chi Nhánh";
                }

                // Cập nhật label tổng số
                lblTongSo.Text = $"Tổng: {lichHenList.Count} lịch hẹn";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Tìm kiếm
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string? trangThai = cmbLocTrangThai.SelectedValue?.ToString();
            DateOnly? tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value);
            DateOnly? denNgay = DateOnly.FromDateTime(dtpDenNgay.Value);

            LoadLichHen(trangThai, tuNgay, denNgay);
        }

        /// <summary>
        /// Nút Xóa lọc
        /// </summary>
        private void btnXoaLoc_Click(object sender, EventArgs e)
        {
            cmbLocTrangThai.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now.AddMonths(1);
            LoadLichHen();
        }

        /// <summary>
        /// Nút Làm mới
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLichHen();
            MessageBox.Show("Đã làm mới danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Nút Xem chi tiết
        /// </summary>
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dsLich_Hen.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dsLich_Hen.SelectedRows[0];
            string maLichHen = selectedRow.Cells["MaLichHen"].Value?.ToString() ?? "";
            string tenKhachHang = selectedRow.Cells["TenKhachHang"].Value?.ToString() ?? "";
            string soDT = selectedRow.Cells["SoDT"].Value?.ToString() ?? "";
            string tenBacSi = selectedRow.Cells["TenBacSi"].Value?.ToString() ?? "";
            string tenChiNhanh = selectedRow.Cells["TenChiNhanh"].Value?.ToString() ?? "";
            string trangThai = selectedRow.Cells["TrangThai"].Value?.ToString() ?? "";
            string ghiChu = selectedRow.Cells["GhiChu"].Value?.ToString() ?? "";
            var ngayHen = selectedRow.Cells["NgayHen"].Value;
            var gioHen = selectedRow.Cells["GioHen"].Value;

            string chiTiet = $"=== CHI TIẾT LỊCH HẸN ===\n\n" +
                            $"Mã lịch hẹn: {maLichHen}\n" +
                            $"Khách hàng: {tenKhachHang}\n" +
                            $"Số điện thoại: {soDT}\n" +
                            $"Ngày hẹn: {ngayHen}\n" +
                            $"Giờ hẹn: {gioHen}\n" +
                            $"Bác sĩ: {tenBacSi}\n" +
                            $"Chi nhánh: {tenChiNhanh}\n" +
                            $"Trạng thái: {trangThai}\n" +
                            $"Ghi chú: {ghiChu}";

            MessageBox.Show(chiTiet, "Chi tiết lịch hẹn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Double click để mở form khám bệnh
        /// </summary>
        private void dsLich_Hen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnKhamBenh_Click(sender, e);
            }
        }

        /// <summary>
        /// Nút Khám bệnh
        /// </summary>
        private void btnKhamBenh_Click(object sender, EventArgs e)
        {
            if (dsLich_Hen.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn để khám bệnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dsLich_Hen.SelectedRows[0];
            string trangThai = selectedRow.Cells["TrangThai"].Value?.ToString() ?? "";

            // Kiểm tra trạng thái
            if (trangThai == "DaKham")
            {
                MessageBox.Show("Lịch hẹn này đã được khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (trangThai == "DaHuy")
            {
                MessageBox.Show("Lịch hẹn này đã bị hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLichHen = selectedRow.Cells["MaLichHen"].Value?.ToString() ?? "";
            string tenKhachHang = selectedRow.Cells["TenKhachHang"].Value?.ToString() ?? "";
            string tenBacSi = selectedRow.Cells["TenBacSi"].Value?.ToString() ?? "";
            string maBacSi = selectedRow.Cells["MaBacSi"].Value?.ToString() ?? "";
            DateOnly? ngayHen = selectedRow.Cells["NgayHen"].Value as DateOnly?;

            var formKhamBenh = new Kham_Benh(maLichHen, tenKhachHang, tenBacSi, maBacSi, ngayHen);
            formKhamBenh.ShowDialog();

            // Reload lịch hẹn sau khi khám xong
            LoadLichHen();
        }

        // Thêm vào file Lich_Hen.cs

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bác sĩ có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng Form Bác sĩ -> Code bên FrmLogin sẽ tự chạy tiếp để hiện lại màn hình Đăng nhập
            }
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            ChamCongNV frmChamCong = new ChamCongNV();
            frmChamCong.ShowDialog();
        }
    }
}
