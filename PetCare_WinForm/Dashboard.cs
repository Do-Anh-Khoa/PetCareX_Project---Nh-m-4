// Function -> Chức năng cần thiết của chương trình
// Effect only -> Chỉ là hiệu ứng giao diện, không tác động

namespace PetCare_WinForm
{
    public partial class Dashboard : Form
    {
        private Button? currentButton;
        private Form? activeForm;

        // Constructor
        public Dashboard()
        {
            InitializeComponent();
        }

        // Load dashboard
        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
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
            OpenChildForm(new ChamCongNV(), sender);
        }

        // Phan Ca Button Click (Function)
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhanCaNewLayout(), sender);
        }

        // Update clock in real time (Function)
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }


        // Quan ly Nhan Vien Button Click (Function)
        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TinhLuongNV(), sender);
        }
    }
}
