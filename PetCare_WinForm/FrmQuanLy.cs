// Function -> Chức năng cần thiết của chương trình
// Effect only -> Chỉ là hiệu ứng giao diện, không tác động

namespace PetCare_WinForm
{
    public partial class FrmQuanLy : Form
    {
        private Button? currentButton;
        private Form? activeForm;

        string maNV_DangNhap;
        string tenNV_DangNhap;
        string chucVu_DangNhap;

        // Constructor
        public FrmQuanLy(string maNV_DangNhap, string tenNV_DangNhap, string chucVu_DangNhap)
        {
            InitializeComponent();
            this.maNV_DangNhap = maNV_DangNhap;
            this.tenNV_DangNhap = tenNV_DangNhap;
            this.chucVu_DangNhap = chucVu_DangNhap;
        }

        // Load dashboard
        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (chucVu_DangNhap == "QuanLy")
            {
                chucVu_DangNhap = "Quản Lý";
            }
            else if(chucVu_DangNhap == "NhanVien")
            {
                chucVu_DangNhap = "Nhân Viên";
            }
            else if (chucVu_DangNhap == "BacSi")
            {
                chucVu_DangNhap = "Bác Sĩ";
            }

            lbl_ThongTin.Text = $"{tenNV_DangNhap} ({chucVu_DangNhap})";
        }

        // Helper methods for button activation (Effect only)
        private void ActivateButton(object sender)
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender)
                {
                    DisableButton();
                    Color color = Color.Orange;
                    currentButton = (Button)sender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                }
            }
        }

        // Disable previously active button (Effect only)
        private void DisableButton()
        {
            foreach (Control previousBtn in PanelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
                }
            }
        }

        // Open child form inside the dashboard (Function)
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitle.Text = childForm.Text;
            labelTitle.AutoSize = false;
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Doanh Thu Button Click (Functiona)
        private void ButtonDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DoanhThu(), sender);
        }

        // Cham Cong Button Click (Function)
        private void ButtonChamCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChamCongNV(maNV_DangNhap), sender);
        }

        // Phan Ca Button Click (Function)
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhanCaNewLayout(), sender);
        }

        //// Update clock in real time (Function)
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        //}


        // Quan ly Nhan Vien Button Click (Function)
        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TinhLuongNV(), sender);
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
