using PetCare_Web.Data;
using PetCare_Web.Models;

namespace PetCare_WinForm
{
    public partial class Kham_Benh : Form
    {
        private readonly PetCareContext _context;
        private readonly string _maLichHen;
        private readonly string _maBacSi;

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
            lblTenChu.Text = $"Chủ: {tenKhachHang}";
            lblTenBacSi.Text = $"Bác sĩ: {tenBacSi}";
            lblNgayKham.Text = $"Ngày khám: {ngayKham?.ToString("dd/MM/yyyy") ?? ""}";
        }

        private void btnHoanTatKham_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTrieuChung.Text) || string.IsNullOrWhiteSpace(txtChanDoan.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ triệu chứng và chẩn đoán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo mã khám mới
                string maKham = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // Tạo dịch vụ khám mới
                var dvKham = new DvKham
                {
                    MaKham = maKham,
                    TrieuChung = txtTrieuChung.Text,
                    ChuanDoan = txtChanDoan.Text,
                    ToaThuoc = rBtnToaThuoc.Checked ? txtToaThuoc.Text : null,
                    BacSiPhuTrach = _maBacSi
                };

                _context.DvKhams.Add(dvKham);

                // Cập nhật trạng thái lịch hẹn
                var lichHen = _context.LichHens.FirstOrDefault(l => l.MaLichHen == _maLichHen);
                if (lichHen != null)
                {
                    lichHen.TrangThai = "Đã khám";
                }

                _context.SaveChanges();

                MessageBox.Show("Hoàn tất khám bệnh!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Bật/tắt textbox toa thuốc
            txtToaThuoc.Enabled = rBtnToaThuoc.Checked;
            lblToaThuoc.Enabled = rBtnToaThuoc.Checked;

            // Bật/tắt datagridview vaccine
            dgvVacXin.Enabled = rBtnVacXin.Checked;
        }

        private void Kham_Benh_Load(object sender, EventArgs e)
        {
            // Load danh sách vaccine nếu cần
            if (rBtnVacXin.Checked)
            {
                LoadVaccine();
            }
        }

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
                    dgvVacXin.Columns["GiaVc"].HeaderText = "Giá";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải vaccine: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
