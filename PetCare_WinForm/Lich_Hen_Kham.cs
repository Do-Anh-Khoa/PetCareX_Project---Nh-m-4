using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PetCare_WinForm
{
    public partial class Lich_Hen : Form
    {
        private readonly PetCareContext _context;

        public Lich_Hen()
        {
            InitializeComponent();
            _context = new PetCareContext();
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
                new("Huy", "Đã hủy")
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
                // Chuẩn bị tham số cho SP
                var pTrangThai = new SqlParameter("@TrangThai", (object?)trangThai ?? DBNull.Value);
                var pTuNgay = new SqlParameter("@TuNgay", (object?)tuNgay ?? DBNull.Value);
                var pDenNgay = new SqlParameter("@DenNgay", (object?)denNgay ?? DBNull.Value);

                // Gọi SP và map vào ViewModel
                var lichHenList = _context.LichHenKhamViews
                    .FromSqlRaw("EXEC sp_GetDanhSachLichHenKham @TrangThai, @TuNgay, @DenNgay", pTrangThai, pTuNgay, pDenNgay)
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
            if (trangThai == "DaHoanThanh")
            {
                MessageBox.Show("Lịch hẹn này đã được khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (trangThai == "Huy")
            {
                MessageBox.Show("Lịch hẹn này đã bị hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (trangThai == "ChoXacNhan")
            {
                MessageBox.Show("Lịch hẹn này chưa được duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }

    public class LichHenKhamView
    {
        public string MaLichHen { get; set; }
        public DateOnly? NgayHen { get; set; }
        public TimeOnly? GioHen { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDT { get; set; }
        public string TenBacSi { get; set; }
        public string MaBacSi { get; set; }
        public string TenChiNhanh { get; set; }
    }
}
