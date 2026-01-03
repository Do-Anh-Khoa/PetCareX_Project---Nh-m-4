
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetCare_WinForm
{
    public partial class FrmHome : Form
    {
        // Cache các form con để không phải load lại
        private FrmDuyetLich _frmDuyetLich;
        private Lich_Hen _frmLichHen; // Danh sach lich hen (chon de kham)
        private FormPOS _frmPOS;
        private FormThanhToan _frmThanhToan;
        private FrmBaoCao _frmBaoCao;
        private ChamCongNV ChamCongNV;

        private Form _currentForm; // Form đang hiển thị

        public FrmHome()
        {
            InitializeComponent();
        }

        // Thêm hàm này vào trong class Dashboard

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận (cho chuyên nghiệp)
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng Dashboard -> Code bên FrmLogin sẽ tự chạy tiếp để hiện lại màn hình đăng nhập
            }
        }
        /// <summary>
        /// Hàm chung để hiển thị form con vào panel chính
        /// </summary>
        private void ShowChildForm(Form childForm)
        {
            // Nếu form đang chọn chính là form này rồi thì không làm gì
            if (_currentForm == childForm) return;

            // Ẩn form hiện tại đi (không đóng)
            if (_currentForm != null)
            {
                _currentForm.Hide();
            }

            // Gán form mới là active
            _currentForm = childForm;

            // Cấu hình form con để nhúng được vào Panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Nếu chưa add vào panel thì add vào
            if (!pnlContent.Controls.Contains(childForm))
            {
                pnlContent.Controls.Add(childForm);
                pnlContent.Tag = childForm;
                childForm.Show(); // Load sự kiện Load lần đầu
            }
            else
            {
                childForm.Show(); // Chỉ hiển thị lại
            }

            childForm.BringToFront();
            lblWelcome.Visible = false; // Ẩn lời chào
        }

        private void btnDuyetLich_Click(object sender, EventArgs e)
        {
            if (_frmDuyetLich == null || _frmDuyetLich.IsDisposed)
            {
                _frmDuyetLich = new FrmDuyetLich();
            }
            ShowChildForm(_frmDuyetLich);
        }

        private void btnKhamBenh_Click(object sender, EventArgs e)
        {
            if (_frmLichHen == null || _frmLichHen.IsDisposed)
            {
                _frmLichHen = new Lich_Hen();
            }
            ShowChildForm(_frmLichHen);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            if (_frmPOS == null || _frmPOS.IsDisposed)
            {
                _frmPOS = new FormPOS();
            }
            ShowChildForm(_frmPOS);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_frmThanhToan == null || _frmThanhToan.IsDisposed)
            {
                _frmThanhToan = new FormThanhToan();
            }
            ShowChildForm(_frmThanhToan);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (_frmBaoCao == null || _frmBaoCao.IsDisposed)
            {
                _frmBaoCao = new FrmBaoCao();
            }
            ShowChildForm(_frmBaoCao);
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            if (ChamCongNV == null || ChamCongNV.IsDisposed)
            {
                ChamCongNV = new ChamCongNV();
            }
            ShowChildForm(ChamCongNV);
        }
    }
}
