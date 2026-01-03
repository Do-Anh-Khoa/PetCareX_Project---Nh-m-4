namespace PetCare_WinForm
{
    partial class Lich_Hen
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubTitle = new Label();
            pnlFilter = new Panel();
            lblLocTheo = new Label();
            cmbLocTrangThai = new ComboBox();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            btnTimKiem = new Button();
            btnXoaLoc = new Button();
            dsLich_Hen = new DataGridView();
            pnlButtons = new Panel();
            btnKhamBenh = new Button();
            btnRefresh = new Button();
            btnXemChiTiet = new Button();
            lblTongSo = new Label();
            btnDangXuat = new Button();
            btnChamCong = new Button();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dsLich_Hen).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 123, 255);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1125, 93);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(394, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ LỊCH HẸN KHÁM";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.White;
            lblSubTitle.Location = new Point(25, 60);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(357, 23);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Xem và quản lý lịch hẹn khám bệnh thú cưng";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(248, 249, 250);
            pnlFilter.Controls.Add(lblLocTheo);
            pnlFilter.Controls.Add(cmbLocTrangThai);
            pnlFilter.Controls.Add(lblTuNgay);
            pnlFilter.Controls.Add(dtpTuNgay);
            pnlFilter.Controls.Add(lblDenNgay);
            pnlFilter.Controls.Add(dtpDenNgay);
            pnlFilter.Controls.Add(btnTimKiem);
            pnlFilter.Controls.Add(btnXoaLoc);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 93);
            pnlFilter.Margin = new Padding(3, 4, 3, 4);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1125, 67);
            pnlFilter.TabIndex = 1;
            // 
            // lblLocTheo
            // 
            lblLocTheo.AutoSize = true;
            lblLocTheo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocTheo.Location = new Point(23, 21);
            lblLocTheo.Name = "lblLocTheo";
            lblLocTheo.Size = new Size(84, 20);
            lblLocTheo.TabIndex = 0;
            lblLocTheo.Text = "Trạng thái:";
            // 
            // cmbLocTrangThai
            // 
            cmbLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocTrangThai.Font = new Font("Segoe UI", 9F);
            cmbLocTrangThai.Location = new Point(109, 16);
            cmbLocTrangThai.Margin = new Padding(3, 4, 3, 4);
            cmbLocTrangThai.Name = "cmbLocTrangThai";
            cmbLocTrangThai.Size = new Size(159, 28);
            cmbLocTrangThai.TabIndex = 0;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTuNgay.Location = new Point(297, 21);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(70, 20);
            lblTuNgay.TabIndex = 1;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Font = new Font("Segoe UI", 9F);
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(366, 16);
            dtpTuNgay.Margin = new Padding(3, 4, 3, 4);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(125, 27);
            dtpTuNgay.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDenNgay.Location = new Point(514, 21);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(79, 20);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Font = new Font("Segoe UI", 9F);
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(591, 16);
            dtpDenNgay.Margin = new Padding(3, 4, 3, 4);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(125, 27);
            dtpDenNgay.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(0, 123, 255);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(743, 13);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(114, 37);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnXoaLoc
            // 
            btnXoaLoc.BackColor = Color.FromArgb(108, 117, 125);
            btnXoaLoc.FlatStyle = FlatStyle.Flat;
            btnXoaLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoaLoc.ForeColor = Color.White;
            btnXoaLoc.Location = new Point(869, 13);
            btnXoaLoc.Margin = new Padding(3, 4, 3, 4);
            btnXoaLoc.Name = "btnXoaLoc";
            btnXoaLoc.Size = new Size(114, 37);
            btnXoaLoc.TabIndex = 4;
            btnXoaLoc.Text = "Xóa lọc";
            btnXoaLoc.UseVisualStyleBackColor = false;
            btnXoaLoc.Click += btnXoaLoc_Click;
            // 
            // dsLich_Hen
            // 
            dsLich_Hen.AllowUserToAddRows = false;
            dsLich_Hen.AllowUserToDeleteRows = false;
            dsLich_Hen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dsLich_Hen.BackgroundColor = Color.White;
            dsLich_Hen.BorderStyle = BorderStyle.None;
            dsLich_Hen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dsLich_Hen.Location = new Point(23, 173);
            dsLich_Hen.Margin = new Padding(3, 4, 3, 4);
            dsLich_Hen.MultiSelect = false;
            dsLich_Hen.Name = "dsLich_Hen";
            dsLich_Hen.ReadOnly = true;
            dsLich_Hen.RowHeadersWidth = 51;
            dsLich_Hen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dsLich_Hen.Size = new Size(1079, 507);
            dsLich_Hen.TabIndex = 2;
            dsLich_Hen.CellContentClick += dataGridView1_CellContentClick;
            dsLich_Hen.CellDoubleClick += dsLich_Hen_CellDoubleClick;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.FromArgb(248, 249, 250);
            pnlButtons.Controls.Add(btnChamCong);
            pnlButtons.Controls.Add(btnKhamBenh);
            pnlButtons.Controls.Add(btnRefresh);
            pnlButtons.Controls.Add(btnXemChiTiet);
            pnlButtons.Controls.Add(lblTongSo);
            pnlButtons.Controls.Add(btnDangXuat);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 693);
            pnlButtons.Margin = new Padding(3, 4, 3, 4);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(1125, 80);
            pnlButtons.TabIndex = 3;
            // 
            // btnKhamBenh
            // 
            btnKhamBenh.BackColor = Color.FromArgb(40, 167, 69);
            btnKhamBenh.FlatStyle = FlatStyle.Flat;
            btnKhamBenh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnKhamBenh.ForeColor = Color.White;
            btnKhamBenh.Location = new Point(23, 16);
            btnKhamBenh.Margin = new Padding(3, 4, 3, 4);
            btnKhamBenh.Name = "btnKhamBenh";
            btnKhamBenh.Size = new Size(171, 51);
            btnKhamBenh.TabIndex = 0;
            btnKhamBenh.Text = "KHÁM BỆNH";
            btnKhamBenh.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(255, 193, 7);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(377, 16);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(137, 51);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.BackColor = Color.FromArgb(0, 123, 255);
            btnXemChiTiet.FlatStyle = FlatStyle.Flat;
            btnXemChiTiet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXemChiTiet.ForeColor = Color.White;
            btnXemChiTiet.Location = new Point(211, 16);
            btnXemChiTiet.Margin = new Padding(3, 4, 3, 4);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(149, 51);
            btnXemChiTiet.TabIndex = 1;
            btnXemChiTiet.Text = "Chi tiết";
            btnXemChiTiet.UseVisualStyleBackColor = false;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // lblTongSo
            // 
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongSo.ForeColor = Color.FromArgb(0, 123, 255);
            lblTongSo.Location = new Point(914, 29);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(138, 23);
            lblTongSo.TabIndex = 3;
            lblTongSo.Text = "Tổng: 0 lịch hẹn";
            // 
            // btnDangXuat
            // 
            btnDangXuat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDangXuat.BackColor = Color.LightCoral;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(754, 13);
            btnDangXuat.Margin = new Padding(3, 4, 3, 4);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(137, 53);
            btnDangXuat.TabIndex = 99;
            btnDangXuat.Text = "Đăng Xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnChamCong
            // 
            btnChamCong.BackColor = Color.Gray;
            btnChamCong.FlatStyle = FlatStyle.Flat;
            btnChamCong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChamCong.ForeColor = SystemColors.ActiveCaptionText;
            btnChamCong.Location = new Point(533, 14);
            btnChamCong.Margin = new Padding(3, 4, 3, 4);
            btnChamCong.Name = "btnChamCong";
            btnChamCong.Size = new Size(137, 51);
            btnChamCong.TabIndex = 100;
            btnChamCong.Text = "Chấm công";
            btnChamCong.UseVisualStyleBackColor = false;
            btnChamCong.Click += btnChamCong_Click;
            // 
            // Lich_Hen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1125, 773);
            Controls.Add(pnlButtons);
            Controls.Add(dsLich_Hen);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Lich_Hen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ LỊCH HẸN KHÁM";
            Load += lich_Hen_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dsLich_Hen).EndInit();
            pnlButtons.ResumeLayout(false);
            pnlButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubTitle;
        private Panel pnlFilter;
        private Label lblLocTheo;
        private ComboBox cmbLocTrangThai;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnTimKiem;
        private Button btnXoaLoc;
        private DataGridView dsLich_Hen;
        private Panel pnlButtons;
        private Button btnKhamBenh;
        private Button btnXemChiTiet;
        private Button btnRefresh;
        private Label lblTongSo;
        private System.Windows.Forms.Button btnDangXuat; // <-- Thêm dòng này
        private Button btnChamCong;
    }
}
