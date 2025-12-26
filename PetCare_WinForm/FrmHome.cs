
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetCare_WinForm
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void OpenForm(Form form)
        {
            this.Hide(); // Ẩn form chính
            form.ShowDialog(); // Hiển thị form con (dạng dialog để chặn tương tác form chính)
            this.Show(); // Hiện lại form chính khi form con đóng
        }

        private void btnDuyetLich_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmDuyetLich());
        }

        private void btnKhamBenh_Click(object sender, EventArgs e)
        {
            // Mở form Danh sách lịch hẹn (Lich_Hen) thay vì mở trực tiếp form Khám Bệnh
            // Vì form Khám Bệnh cần truyền thông tin cụ thể
            OpenForm(new Lich_Hen()); 
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            OpenForm(new FormPOS());
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            OpenForm(new FormThanhToan());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmBaoCao());
        }
    }
}
