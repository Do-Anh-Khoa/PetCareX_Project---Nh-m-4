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

        private void ButtonDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.DoanhThu(), sender);
        }

        //private void ButtonHieuSuatCV_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new Forms.HieuSuat(), sender); 
        //}

        //private void ButtonPhanHoiKH_Click(object sender, EventArgs e)
        //{
        //    ActivateButton(sender);
        //}

        private void ButtonChamCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ChamCongNV(), sender);
            
        }
    }
}
