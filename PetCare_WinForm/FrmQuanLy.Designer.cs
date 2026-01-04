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
            panel4 = new Panel();
            lbl_ThongTin = new Label();
            panel3 = new Panel();
            btn_DangXuat = new Button();
            button2 = new Button();
            button1 = new Button();
            ButtonChamCong = new Button();
            ButtonDoanhThu = new Button();
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            labelTitle = new Label();
            panelDesktopPane = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            PanelMenu.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = Color.FromArgb(51, 51, 76);
            PanelMenu.Controls.Add(panel4);
            PanelMenu.Controls.Add(panel3);
            PanelMenu.Controls.Add(button2);
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
            // panel4
            // 
            panel4.Controls.Add(lbl_ThongTin);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 430);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 62);
            panel4.TabIndex = 9;
            // 
            // lbl_ThongTin
            // 
            lbl_ThongTin.Dock = DockStyle.Fill;
            lbl_ThongTin.Font = new Font("Segoe UI", 10F);
            lbl_ThongTin.ForeColor = SystemColors.ButtonHighlight;
            lbl_ThongTin.Location = new Point(0, 0);
            lbl_ThongTin.Name = "lbl_ThongTin";
            lbl_ThongTin.Size = new Size(220, 62);
            lbl_ThongTin.TabIndex = 6;
            lbl_ThongTin.Text = "---- / ----";
            lbl_ThongTin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_DangXuat);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 492);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 62);
            panel3.TabIndex = 8;
            // 
            // btn_DangXuat
            // 
            btn_DangXuat.BackColor = Color.FromArgb(255, 128, 128);
            btn_DangXuat.Dock = DockStyle.Fill;
            btn_DangXuat.FlatAppearance.BorderSize = 0;
            btn_DangXuat.FlatStyle = FlatStyle.Flat;
            btn_DangXuat.Font = new Font("Segoe UI", 12F);
            btn_DangXuat.ForeColor = Color.Black;
            btn_DangXuat.Location = new Point(0, 0);
            btn_DangXuat.Name = "btn_DangXuat";
            btn_DangXuat.Size = new Size(220, 62);
            btn_DangXuat.TabIndex = 10;
            btn_DangXuat.Text = "Đăng xuất";
            btn_DangXuat.UseVisualStyleBackColor = false;
            btn_DangXuat.Click += btn_DangXuat_Click;
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
            labelTitle.Location = new Point(145, 23);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(474, 38);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "TRANG CHỦ QUẢN LÝ NHÂN VIÊN";
            labelTitle.TextAlign = ContentAlignment.TopCenter;
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
            // 
            // FrmQuanLy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 554);
            Controls.Add(panelDesktopPane);
            Controls.Add(panel2);
            Controls.Add(PanelMenu);
            Name = "FrmQuanLy";
            Text = "Quản lý nhân viên";
            Load += Dashboard_Load;
            PanelMenu.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Timer timer1;
        private Button button2;
        private Panel panel3;
        private Panel panel4;
        private Label lbl_ThongTin;
        private Button btn_DangXuat;
    }
}
