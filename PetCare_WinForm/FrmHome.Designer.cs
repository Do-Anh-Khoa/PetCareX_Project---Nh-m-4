
namespace PetCare_WinForm
{
    partial class FrmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnBaoCao = new Button();
            btnThanhToan = new Button();
            btnBanHang = new Button();
            btnKhamBenh = new Button();
            btnDuyetLich = new Button();
            pnlLogo = new Panel();
            lblLogo = new Label();
            pnlContent = new Panel();
            lblWelcome = new Label();
            pnlSidebar.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(52, 58, 64);
            pnlSidebar.Controls.Add(btnBaoCao);
            pnlSidebar.Controls.Add(btnThanhToan);
            pnlSidebar.Controls.Add(btnBanHang);
            pnlSidebar.Controls.Add(btnKhamBenh);
            pnlSidebar.Controls.Add(btnDuyetLich);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 600);
            pnlSidebar.TabIndex = 0;
            // 
            // btnBaoCao
            // 
            btnBaoCao.Dock = DockStyle.Top;
            btnBaoCao.FlatAppearance.BorderSize = 0;
            btnBaoCao.FlatStyle = FlatStyle.Flat;
            btnBaoCao.Font = new Font("Segoe UI", 12F);
            btnBaoCao.ForeColor = Color.White;
            btnBaoCao.Location = new Point(0, 300);
            btnBaoCao.Name = "btnBaoCao";
            btnBaoCao.Padding = new Padding(20, 0, 0, 0);
            btnBaoCao.Size = new Size(250, 60);
            btnBaoCao.TabIndex = 5;
            btnBaoCao.Text = "Báo Cáo Thống Kê";
            btnBaoCao.TextAlign = ContentAlignment.MiddleLeft;
            btnBaoCao.UseVisualStyleBackColor = true;
            btnBaoCao.Click += btnBaoCao_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Dock = DockStyle.Top;
            btnThanhToan.FlatAppearance.BorderSize = 0;
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.Font = new Font("Segoe UI", 12F);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(0, 240);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Padding = new Padding(20, 0, 0, 0);
            btnThanhToan.Size = new Size(250, 60);
            btnThanhToan.TabIndex = 4;
            btnThanhToan.Text = "Hóa Đơn & Thanh Toán";
            btnThanhToan.TextAlign = ContentAlignment.MiddleLeft;
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnBanHang
            // 
            btnBanHang.Dock = DockStyle.Top;
            btnBanHang.FlatAppearance.BorderSize = 0;
            btnBanHang.FlatStyle = FlatStyle.Flat;
            btnBanHang.Font = new Font("Segoe UI", 12F);
            btnBanHang.ForeColor = Color.White;
            btnBanHang.Location = new Point(0, 180);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Padding = new Padding(20, 0, 0, 0);
            btnBanHang.Size = new Size(250, 60);
            btnBanHang.TabIndex = 3;
            btnBanHang.Text = "Bán Hàng (POS)";
            btnBanHang.TextAlign = ContentAlignment.MiddleLeft;
            btnBanHang.UseVisualStyleBackColor = true;
            btnBanHang.Click += btnBanHang_Click;
            // 
            // btnKhamBenh
            // 
            btnKhamBenh.Dock = DockStyle.Top;
            btnKhamBenh.FlatAppearance.BorderSize = 0;
            btnKhamBenh.FlatStyle = FlatStyle.Flat;
            btnKhamBenh.Font = new Font("Segoe UI", 12F);
            btnKhamBenh.ForeColor = Color.White;
            btnKhamBenh.Location = new Point(0, 120);
            btnKhamBenh.Name = "btnKhamBenh";
            btnKhamBenh.Padding = new Padding(20, 0, 0, 0);
            btnKhamBenh.Size = new Size(250, 60);
            btnKhamBenh.TabIndex = 2;
            btnKhamBenh.Text = "Lịch Hẹn & Khám Bệnh";
            btnKhamBenh.TextAlign = ContentAlignment.MiddleLeft;
            btnKhamBenh.UseVisualStyleBackColor = true;
            btnKhamBenh.Click += btnKhamBenh_Click;
            // 
            // btnDuyetLich
            // 
            btnDuyetLich.Dock = DockStyle.Top;
            btnDuyetLich.FlatAppearance.BorderSize = 0;
            btnDuyetLich.FlatStyle = FlatStyle.Flat;
            btnDuyetLich.Font = new Font("Segoe UI", 12F);
            btnDuyetLich.ForeColor = Color.White;
            btnDuyetLich.Location = new Point(0, 60);
            btnDuyetLich.Name = "btnDuyetLich";
            btnDuyetLich.Padding = new Padding(20, 0, 0, 0);
            btnDuyetLich.Size = new Size(250, 60);
            btnDuyetLich.TabIndex = 1;
            btnDuyetLich.Text = "Duyệt Lịch Hẹn";
            btnDuyetLich.TextAlign = ContentAlignment.MiddleLeft;
            btnDuyetLich.UseVisualStyleBackColor = true;
            btnDuyetLich.Click += btnDuyetLich_Click;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(40, 44, 52);
            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(250, 60);
            pnlLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(250, 60);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "PetCare System";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Controls.Add(lblWelcome);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(250, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(734, 600);
            pnlContent.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.Dock = DockStyle.Fill;
            lblWelcome.Font = new Font("Segoe UI Light", 24F);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(734, 600);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng đến với hệ thống quản lý PetCare\r\nVui lòng chọn chức năng từ menu bên trái";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 600);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "FrmHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang Chủ - PetCare System";
            pnlSidebar.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnDuyetLich;
        private Panel pnlLogo;
        private Label lblLogo;
        private Button btnBaoCao;
        private Button btnThanhToan;
        private Button btnBanHang;
        private Button btnKhamBenh;
        private Panel pnlContent;
        private Label lblWelcome;
    }

    
}
