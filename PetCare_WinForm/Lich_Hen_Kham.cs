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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void lich_Hen_Load(object sender, EventArgs e)
        {
            LoadLichHen();
        }

        private void LoadLichHen()
        {
            try
            {
                // Xóa các cột được định nghĩa sẵn trong Designer
                dsLich_Hen.Columns.Clear();
                dsLich_Hen.AutoGenerateColumns = true;

                var lichHenList = _context.LichHens
                    .Include(l => l.MaKhNavigation)
                    .Include(l => l.MaBsNavigation)
                    .Include(l => l.MaCnNavigation)
                    .Select(l => new
                    {
                        l.MaLichHen,
                        l.NgayHen,
                        l.GioHen,
                        l.TrangThai,
                        l.GhiChu,
                        TenKhachHang = l.MaKhNavigation != null ? l.MaKhNavigation.HoTen : "",
                        TenBacSi = l.MaBsNavigation != null ? l.MaBsNavigation.HoTen : "",
                        MaBacSi = l.MaBs,
                        TenChiNhanh = l.MaCnNavigation != null ? l.MaCnNavigation.TenChiNhanh : ""
                    })
                    .ToList();

                dsLich_Hen.DataSource = lichHenList;

                // Đặt tên cột hiển thị
                if (dsLich_Hen.Columns.Count > 0)
                {
                    dsLich_Hen.Columns["MaLichHen"].HeaderText = "Mã Lịch Hẹn";
                    dsLich_Hen.Columns["NgayHen"].HeaderText = "Ngày Hẹn";
                    dsLich_Hen.Columns["GioHen"].HeaderText = "Giờ Hẹn";
                    dsLich_Hen.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    dsLich_Hen.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dsLich_Hen.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                    dsLich_Hen.Columns["TenBacSi"].HeaderText = "Bác Sĩ";
                    dsLich_Hen.Columns["MaBacSi"].Visible = false;
                    dsLich_Hen.Columns["TenChiNhanh"].HeaderText = "Chi Nhánh";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhamBenh_Click(object sender, EventArgs e)
        {
            if (dsLich_Hen.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn để khám bệnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dsLich_Hen.SelectedRows[0];
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
}
