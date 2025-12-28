namespace PetCare_WinForm
{
    partial class Kham_Benh
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnXemLichSu = new Button();
            pnlThongTin = new Panel();
            lblMaLichHen = new Label();
            lblTenChu = new Label();
            lblTenBacSi = new Label();
            lblNgayKham = new Label();
            grpKhamBenh = new GroupBox();
            lblTrieuChung = new Label();
            txtTrieuChung = new TextBox();
            lblChanDoan = new Label();
            txtChanDoan = new TextBox();
            grpDieuTri = new GroupBox();
            rBtnToaThuoc = new RadioButton();
            rBtnVacXin = new RadioButton();
            rBtnKhong = new RadioButton();
            pnlToaThuoc = new Panel();
            lblToaThuoc = new Label();
            txtToaThuoc = new TextBox();
            lblLieuDung = new Label();
            txtLieuDung = new TextBox();
            pnlVaccine = new Panel();
            lblChonVaccine = new Label();
            dgvVacXin = new DataGridView();
            grpLichSu = new GroupBox();
            dgvLichSuKham = new DataGridView();
            pnlButtons = new Panel();
            btnLuuBenhAn = new Button();
            btnHoanTatKham = new Button();
            btnHuy = new Button();
            pnlHeader.SuspendLayout();
            pnlThongTin.SuspendLayout();
            grpKhamBenh.SuspendLayout();
            grpDieuTri.SuspendLayout();
            pnlToaThuoc.SuspendLayout();
            pnlVaccine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVacXin).BeginInit();
            grpLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuKham).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(40, 167, 69);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnXemLichSu);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1159, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(293, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "KHÁM BỆNH THÚ CƯNG";
            // 
            // btnXemLichSu
            // 
            btnXemLichSu.BackColor = Color.FromArgb(255, 193, 7);
            btnXemLichSu.FlatStyle = FlatStyle.Flat;
            btnXemLichSu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXemLichSu.ForeColor = Color.Black;
            btnXemLichSu.Location = new Point(991, 15);
            btnXemLichSu.Name = "btnXemLichSu";
            btnXemLichSu.Size = new Size(150, 35);
            btnXemLichSu.TabIndex = 1;
            btnXemLichSu.Text = "XEM LỊCH SỬ";
            btnXemLichSu.UseVisualStyleBackColor = false;
            btnXemLichSu.Click += btnXemLichSu_Click;
            // 
            // pnlThongTin
            // 
            pnlThongTin.BackColor = Color.FromArgb(248, 249, 250);
            pnlThongTin.Controls.Add(lblMaLichHen);
            pnlThongTin.Controls.Add(lblTenChu);
            pnlThongTin.Controls.Add(lblTenBacSi);
            pnlThongTin.Controls.Add(lblNgayKham);
            pnlThongTin.Dock = DockStyle.Top;
            pnlThongTin.Location = new Point(0, 60);
            pnlThongTin.Name = "pnlThongTin";
            pnlThongTin.Size = new Size(1159, 70);
            pnlThongTin.TabIndex = 1;
            // 
            // lblMaLichHen
            // 
            lblMaLichHen.AutoSize = true;
            lblMaLichHen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaLichHen.ForeColor = Color.FromArgb(0, 123, 255);
            lblMaLichHen.Location = new Point(20, 10);
            lblMaLichHen.Name = "lblMaLichHen";
            lblMaLichHen.Size = new Size(93, 19);
            lblMaLichHen.TabIndex = 0;
            lblMaLichHen.Text = "Mã lịch hẹn: ";
            // 
            // lblTenChu
            // 
            lblTenChu.AutoSize = true;
            lblTenChu.Font = new Font("Segoe UI", 10F);
            lblTenChu.Location = new Point(20, 40);
            lblTenChu.Name = "lblTenChu";
            lblTenChu.Size = new Size(37, 19);
            lblTenChu.TabIndex = 1;
            lblTenChu.Text = "Chủ:";
            // 
            // lblTenBacSi
            // 
            lblTenBacSi.AutoSize = true;
            lblTenBacSi.Font = new Font("Segoe UI", 10F);
            lblTenBacSi.Location = new Point(300, 40);
            lblTenBacSi.Name = "lblTenBacSi";
            lblTenBacSi.Size = new Size(46, 19);
            lblTenBacSi.TabIndex = 2;
            lblTenBacSi.Text = "Bác sĩ:";
            // 
            // lblNgayKham
            // 
            lblNgayKham.AutoSize = true;
            lblNgayKham.Font = new Font("Segoe UI", 10F);
            lblNgayKham.Location = new Point(550, 40);
            lblNgayKham.Name = "lblNgayKham";
            lblNgayKham.Size = new Size(82, 19);
            lblNgayKham.TabIndex = 3;
            lblNgayKham.Text = "Ngày khám:";
            // 
            // grpKhamBenh
            // 
            grpKhamBenh.Controls.Add(lblTrieuChung);
            grpKhamBenh.Controls.Add(txtTrieuChung);
            grpKhamBenh.Controls.Add(lblChanDoan);
            grpKhamBenh.Controls.Add(txtChanDoan);
            grpKhamBenh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpKhamBenh.ForeColor = Color.FromArgb(40, 167, 69);
            grpKhamBenh.Location = new Point(20, 140);
            grpKhamBenh.Name = "grpKhamBenh";
            grpKhamBenh.Size = new Size(420, 221);
            grpKhamBenh.TabIndex = 2;
            grpKhamBenh.TabStop = false;
            grpKhamBenh.Text = "THÔNG TIN KHÁM";
            // 
            // lblTrieuChung
            // 
            lblTrieuChung.AutoSize = true;
            lblTrieuChung.Font = new Font("Segoe UI", 10F);
            lblTrieuChung.ForeColor = Color.Black;
            lblTrieuChung.Location = new Point(15, 35);
            lblTrieuChung.Name = "lblTrieuChung";
            lblTrieuChung.Size = new Size(83, 19);
            lblTrieuChung.TabIndex = 0;
            lblTrieuChung.Text = "Triệu chứng:";
            // 
            // txtTrieuChung
            // 
            txtTrieuChung.Font = new Font("Segoe UI", 10F);
            txtTrieuChung.Location = new Point(110, 32);
            txtTrieuChung.Multiline = true;
            txtTrieuChung.Name = "txtTrieuChung";
            txtTrieuChung.ScrollBars = ScrollBars.Vertical;
            txtTrieuChung.Size = new Size(295, 82);
            txtTrieuChung.TabIndex = 0;
            // 
            // lblChanDoan
            // 
            lblChanDoan.AutoSize = true;
            lblChanDoan.Font = new Font("Segoe UI", 10F);
            lblChanDoan.ForeColor = Color.Black;
            lblChanDoan.Location = new Point(15, 128);
            lblChanDoan.Name = "lblChanDoan";
            lblChanDoan.Size = new Size(79, 19);
            lblChanDoan.TabIndex = 1;
            lblChanDoan.Text = "Chẩn đoán:";
            // 
            // txtChanDoan
            // 
            txtChanDoan.Font = new Font("Segoe UI", 10F);
            txtChanDoan.Location = new Point(110, 128);
            txtChanDoan.Multiline = true;
            txtChanDoan.Name = "txtChanDoan";
            txtChanDoan.ScrollBars = ScrollBars.Vertical;
            txtChanDoan.Size = new Size(295, 77);
            txtChanDoan.TabIndex = 1;
            // 
            // grpDieuTri
            // 
            grpDieuTri.Controls.Add(rBtnToaThuoc);
            grpDieuTri.Controls.Add(rBtnVacXin);
            grpDieuTri.Controls.Add(rBtnKhong);
            grpDieuTri.Controls.Add(pnlToaThuoc);
            grpDieuTri.Controls.Add(pnlVaccine);
            grpDieuTri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDieuTri.ForeColor = Color.FromArgb(0, 123, 255);
            grpDieuTri.Location = new Point(20, 367);
            grpDieuTri.Name = "grpDieuTri";
            grpDieuTri.Size = new Size(1121, 250);
            grpDieuTri.TabIndex = 3;
            grpDieuTri.TabStop = false;
            grpDieuTri.Text = "ĐIỀU TRỊ";
            grpDieuTri.Enter += grpDieuTri_Enter;
            // 
            // rBtnToaThuoc
            // 
            rBtnToaThuoc.AutoSize = true;
            rBtnToaThuoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rBtnToaThuoc.ForeColor = Color.Black;
            rBtnToaThuoc.Location = new Point(20, 30);
            rBtnToaThuoc.Name = "rBtnToaThuoc";
            rBtnToaThuoc.Size = new Size(92, 23);
            rBtnToaThuoc.TabIndex = 0;
            rBtnToaThuoc.Text = "Toa thuốc";
            rBtnToaThuoc.UseVisualStyleBackColor = true;
            rBtnToaThuoc.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rBtnVacXin
            // 
            rBtnVacXin.AutoSize = true;
            rBtnVacXin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rBtnVacXin.ForeColor = Color.Black;
            rBtnVacXin.Location = new Point(150, 30);
            rBtnVacXin.Name = "rBtnVacXin";
            rBtnVacXin.Size = new Size(114, 23);
            rBtnVacXin.TabIndex = 1;
            rBtnVacXin.Text = "Tiêm Vaccine";
            rBtnVacXin.UseVisualStyleBackColor = true;
            rBtnVacXin.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rBtnKhong
            // 
            rBtnKhong.AutoSize = true;
            rBtnKhong.Checked = true;
            rBtnKhong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rBtnKhong.ForeColor = Color.Black;
            rBtnKhong.Location = new Point(300, 30);
            rBtnKhong.Name = "rBtnKhong";
            rBtnKhong.Size = new Size(122, 23);
            rBtnKhong.TabIndex = 2;
            rBtnKhong.TabStop = true;
            rBtnKhong.Text = "Không điều trị";
            rBtnKhong.UseVisualStyleBackColor = true;
            rBtnKhong.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // pnlToaThuoc
            // 
            pnlToaThuoc.Controls.Add(lblToaThuoc);
            pnlToaThuoc.Controls.Add(txtToaThuoc);
            pnlToaThuoc.Controls.Add(lblLieuDung);
            pnlToaThuoc.Controls.Add(txtLieuDung);
            pnlToaThuoc.Location = new Point(15, 60);
            pnlToaThuoc.Name = "pnlToaThuoc";
            pnlToaThuoc.Size = new Size(948, 100);
            pnlToaThuoc.TabIndex = 3;
            pnlToaThuoc.Visible = false;
            // 
            // lblToaThuoc
            // 
            lblToaThuoc.AutoSize = true;
            lblToaThuoc.Font = new Font("Segoe UI", 10F);
            lblToaThuoc.ForeColor = Color.Black;
            lblToaThuoc.Location = new Point(5, 10);
            lblToaThuoc.Name = "lblToaThuoc";
            lblToaThuoc.Size = new Size(72, 19);
            lblToaThuoc.TabIndex = 0;
            lblToaThuoc.Text = "Toa thuốc:";
            // 
            // txtToaThuoc
            // 
            txtToaThuoc.Font = new Font("Segoe UI", 10F);
            txtToaThuoc.Location = new Point(100, 7);
            txtToaThuoc.Multiline = true;
            txtToaThuoc.Name = "txtToaThuoc";
            txtToaThuoc.ScrollBars = ScrollBars.Vertical;
            txtToaThuoc.Size = new Size(836, 40);
            txtToaThuoc.TabIndex = 0;
            // 
            // lblLieuDung
            // 
            lblLieuDung.AutoSize = true;
            lblLieuDung.Font = new Font("Segoe UI", 10F);
            lblLieuDung.ForeColor = Color.Black;
            lblLieuDung.Location = new Point(5, 60);
            lblLieuDung.Name = "lblLieuDung";
            lblLieuDung.Size = new Size(73, 19);
            lblLieuDung.TabIndex = 1;
            lblLieuDung.Text = "Liều dùng:";
            // 
            // txtLieuDung
            // 
            txtLieuDung.Font = new Font("Segoe UI", 10F);
            txtLieuDung.Location = new Point(100, 57);
            txtLieuDung.Name = "txtLieuDung";
            txtLieuDung.Size = new Size(836, 25);
            txtLieuDung.TabIndex = 1;
            // 
            // pnlVaccine
            // 
            pnlVaccine.Controls.Add(lblChonVaccine);
            pnlVaccine.Controls.Add(dgvVacXin);
            pnlVaccine.Location = new Point(15, 60);
            pnlVaccine.Name = "pnlVaccine";
            pnlVaccine.Size = new Size(1100, 180);
            pnlVaccine.TabIndex = 4;
            pnlVaccine.Visible = false;
            // 
            // lblChonVaccine
            // 
            lblChonVaccine.AutoSize = true;
            lblChonVaccine.Font = new Font("Segoe UI", 10F);
            lblChonVaccine.ForeColor = Color.Black;
            lblChonVaccine.Location = new Point(5, 10);
            lblChonVaccine.Name = "lblChonVaccine";
            lblChonVaccine.Size = new Size(149, 19);
            lblChonVaccine.TabIndex = 0;
            lblChonVaccine.Text = "Chọn vaccine cần tiêm:";
            // 
            // dgvVacXin
            // 
            dgvVacXin.AllowUserToAddRows = false;
            dgvVacXin.AllowUserToDeleteRows = false;
            dgvVacXin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVacXin.BackgroundColor = Color.White;
            dgvVacXin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVacXin.Location = new Point(5, 35);
            dgvVacXin.MultiSelect = false;
            dgvVacXin.Name = "dgvVacXin";
            dgvVacXin.ReadOnly = true;
            dgvVacXin.RowHeadersWidth = 51;
            dgvVacXin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVacXin.Size = new Size(1092, 135);
            dgvVacXin.TabIndex = 0;
            // 
            // grpLichSu
            // 
            grpLichSu.Controls.Add(dgvLichSuKham);
            grpLichSu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpLichSu.ForeColor = Color.FromArgb(255, 193, 7);
            grpLichSu.Location = new Point(460, 140);
            grpLichSu.Name = "grpLichSu";
            grpLichSu.Size = new Size(687, 221);
            grpLichSu.TabIndex = 5;
            grpLichSu.TabStop = false;
            grpLichSu.Text = "LỊCH SỬ KHÁM";
            grpLichSu.Visible = false;
            // 
            // dgvLichSuKham
            // 
            dgvLichSuKham.AllowUserToAddRows = false;
            dgvLichSuKham.AllowUserToDeleteRows = false;
            dgvLichSuKham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSuKham.BackgroundColor = Color.White;
            dgvLichSuKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSuKham.Location = new Point(10, 25);
            dgvLichSuKham.MultiSelect = false;
            dgvLichSuKham.Name = "dgvLichSuKham";
            dgvLichSuKham.ReadOnly = true;
            dgvLichSuKham.RowHeadersWidth = 30;
            dgvLichSuKham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichSuKham.Size = new Size(671, 180);
            dgvLichSuKham.TabIndex = 0;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.FromArgb(248, 249, 250);
            pnlButtons.Controls.Add(btnLuuBenhAn);
            pnlButtons.Controls.Add(btnHoanTatKham);
            pnlButtons.Controls.Add(btnHuy);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 643);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(1159, 60);
            pnlButtons.TabIndex = 4;
            // 
            // btnLuuBenhAn
            // 
            btnLuuBenhAn.BackColor = Color.FromArgb(0, 123, 255);
            btnLuuBenhAn.FlatStyle = FlatStyle.Flat;
            btnLuuBenhAn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLuuBenhAn.ForeColor = Color.White;
            btnLuuBenhAn.Location = new Point(734, 10);
            btnLuuBenhAn.Name = "btnLuuBenhAn";
            btnLuuBenhAn.Size = new Size(150, 40);
            btnLuuBenhAn.TabIndex = 2;
            btnLuuBenhAn.Text = "LƯU BỆNH ÁN";
            btnLuuBenhAn.UseVisualStyleBackColor = false;
            btnLuuBenhAn.Click += btnLuuBenhAn_Click;
            // 
            // btnHoanTatKham
            // 
            btnHoanTatKham.BackColor = Color.FromArgb(40, 167, 69);
            btnHoanTatKham.FlatStyle = FlatStyle.Flat;
            btnHoanTatKham.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnHoanTatKham.ForeColor = Color.White;
            btnHoanTatKham.Location = new Point(902, 10);
            btnHoanTatKham.Name = "btnHoanTatKham";
            btnHoanTatKham.Size = new Size(150, 40);
            btnHoanTatKham.TabIndex = 0;
            btnHoanTatKham.Text = "HOÀN TẤT";
            btnHoanTatKham.UseVisualStyleBackColor = false;
            btnHoanTatKham.Click += btnHoanTatKham_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(108, 117, 125);
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(1071, 10);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(70, 40);
            btnHuy.TabIndex = 1;
            btnHuy.Text = "HỦY";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // Kham_Benh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1159, 703);
            Controls.Add(pnlButtons);
            Controls.Add(grpDieuTri);
            Controls.Add(grpLichSu);
            Controls.Add(grpKhamBenh);
            Controls.Add(pnlThongTin);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Kham_Benh";
            StartPosition = FormStartPosition.CenterParent;
            Text = "KHÁM BỆNH THÚ CƯNG";
            Load += Kham_Benh_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            grpKhamBenh.ResumeLayout(false);
            grpKhamBenh.PerformLayout();
            grpDieuTri.ResumeLayout(false);
            grpDieuTri.PerformLayout();
            pnlToaThuoc.ResumeLayout(false);
            pnlToaThuoc.PerformLayout();
            pnlVaccine.ResumeLayout(false);
            pnlVaccine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVacXin).EndInit();
            grpLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLichSuKham).EndInit();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnXemLichSu;
        private Panel pnlThongTin;
        private Label lblMaLichHen;
        private Label lblTenChu;
        private Label lblTenBacSi;
        private Label lblNgayKham;
        private GroupBox grpKhamBenh;
        private Label lblTrieuChung;
        private TextBox txtTrieuChung;
        private Label lblChanDoan;
        private TextBox txtChanDoan;
        private GroupBox grpLichSu;
        private DataGridView dgvLichSuKham;
        private GroupBox grpDieuTri;
        private RadioButton rBtnToaThuoc;
        private RadioButton rBtnVacXin;
        private RadioButton rBtnKhong;
        private Panel pnlToaThuoc;
        private Label lblToaThuoc;
        private TextBox txtToaThuoc;
        private Label lblLieuDung;
        private TextBox txtLieuDung;
        private Panel pnlVaccine;
        private Label lblChonVaccine;
        private DataGridView dgvVacXin;
        private Panel pnlButtons;
        private Button btnLuuBenhAn;
        private Button btnHoanTatKham;
        private Button btnHuy;
    }
}
