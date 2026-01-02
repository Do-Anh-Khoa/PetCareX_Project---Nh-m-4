namespace PetCare_WinForm
{
    partial class FrmQuanLy
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PanelMenu = new Panel();
            lblClock = new Label();
            button1 = new Button();
            ButtonChamCong = new Button();
            ButtonDoanhThu = new Button();
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            labelTitle = new Label();
            panelDesktopPane = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            PanelMenu.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = Color.FromArgb(51, 51, 76);
            PanelMenu.Controls.Add(button2);
            PanelMenu.Controls.Add(lblClock);
            PanelMenu.Controls.Add(button1);
            PanelMenu.Controls.Add(ButtonChamCong);
            PanelMenu.Controls.Add(ButtonDoanhThu);
            PanelMenu.Controls.Add(panel1);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(220, 554);
            PanelMenu.TabIndex = 0;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClock.ForeColor = SystemColors.ButtonHighlight;
            lblClock.Location = new Point(66, 502);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(78, 31);
            lblClock.TabIndex = 6;
            lblClock.Text = "--:--:--";
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(0, 200);
            button1.Name = "button1";
            button1.Size = new Size(220, 60);
            button1.TabIndex = 5;
            button1.Text = "Phân ca";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ButtonChamCong
            // 
            ButtonChamCong.Dock = DockStyle.Top;
            ButtonChamCong.FlatAppearance.BorderSize = 0;
            ButtonChamCong.FlatStyle = FlatStyle.Flat;
            ButtonChamCong.Font = new Font("Segoe UI", 10F);
            ButtonChamCong.ForeColor = Color.WhiteSmoke;
            ButtonChamCong.Location = new Point(0, 140);
            ButtonChamCong.Name = "ButtonChamCong";
            ButtonChamCong.Size = new Size(220, 60);
            ButtonChamCong.TabIndex = 4;
            ButtonChamCong.Text = "Chấm công";
            ButtonChamCong.UseVisualStyleBackColor = true;
            ButtonChamCong.Click += ButtonChamCong_Click;
            // 
            // ButtonDoanhThu
            // 
            ButtonDoanhThu.Dock = DockStyle.Top;
            ButtonDoanhThu.FlatAppearance.BorderSize = 0;
            ButtonDoanhThu.FlatStyle = FlatStyle.Flat;
            ButtonDoanhThu.Font = new Font("Segoe UI", 10F);
            ButtonDoanhThu.ForeColor = Color.WhiteSmoke;
            ButtonDoanhThu.Location = new Point(0, 80);
            ButtonDoanhThu.Name = "ButtonDoanhThu";
            ButtonDoanhThu.Size = new Size(220, 60);
            ButtonDoanhThu.TabIndex = 1;
            ButtonDoanhThu.Text = "Doanh thu";
            ButtonDoanhThu.UseVisualStyleBackColor = true;
            ButtonDoanhThu.Click += ButtonDoanhThu_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(39, 39, 58);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 80);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(57, 25);
            label2.Name = "label2";
            label2.Size = new Size(106, 31);
            label2.TabIndex = 0;
            label2.Text = "PetCareX";
            label2.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Orange;
            panel2.Controls.Add(labelTitle);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(220, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(777, 80);
            panel2.TabIndex = 1;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.None;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(311, 22);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(179, 38);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "TRANG CHỦ";
            labelTitle.Click += label1_Click;
            // 
            // panelDesktopPane
            // 
            panelDesktopPane.Dock = DockStyle.Fill;
            panelDesktopPane.Location = new Point(220, 80);
            panelDesktopPane.Name = "panelDesktopPane";
            panelDesktopPane.Size = new Size(777, 474);
            panelDesktopPane.TabIndex = 2;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F);
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(0, 260);
            button2.Name = "button2";
            button2.Size = new Size(220, 60);
            button2.TabIndex = 7;
            button2.Text = "Quản lý lương";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 554);
            Controls.Add(panelDesktopPane);
            Controls.Add(panel2);
            Controls.Add(PanelMenu);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            PanelMenu.ResumeLayout(false);
            PanelMenu.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMenu;
        private Panel panel1;
        private Button ButtonDoanhThu;
        private Panel panel2;
        private Label labelTitle;
        private Label label2;
        private Panel panelDesktopPane;
        private Button ButtonChamCong;
        private Button button1;
        private Label lblClock;
        private System.Windows.Forms.Timer timer1;
        private Button button2;
    }
}
