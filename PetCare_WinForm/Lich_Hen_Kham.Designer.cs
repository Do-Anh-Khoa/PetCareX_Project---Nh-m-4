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
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(984, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ LỊCH HẸN KHÁM";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.White;
            lblSubTitle.Location = new Point(22, 45);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(280, 19);
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
            pnlFilter.Location = new Point(0, 70);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(984, 50);
            pnlFilter.TabIndex = 1;
            // 
            // lblLocTheo
            // 
            lblLocTheo.AutoSize = true;
            lblLocTheo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocTheo.Location = new Point(20, 16);
            lblLocTheo.Name = "lblLocTheo";
            lblLocTheo.Size = new Size(70, 15);
            lblLocTheo.Text = "Trạng thái:";
            // 
            // cmbLocTrangThai
            // 
            cmbLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocTrangThai.Font = new Font("Segoe UI", 9F);
            cmbLocTrangThai.Location = new Point(95, 12);
            cmbLocTrangThai.Name = "cmbLocTrangThai";
            cmbLocTrangThai.Size = new Size(140, 23);
            cmbLocTrangThai.TabIndex = 0;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTuNgay.Location = new Point(260, 16);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(55, 15);
            lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Font = new Font("Segoe UI", 9F);
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(320, 12);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(110, 23);
            dtpTuNgay.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDenNgay.Location = new Point(450, 16);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(62, 15);
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Font = new Font("Segoe UI", 9F);
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(517, 12);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(110, 23);
            dtpDenNgay.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(0, 123, 255);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(650, 10);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 28);
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
            btnXoaLoc.Location = new Point(760, 10);
            btnXoaLoc.Name = "btnXoaLoc";
            btnXoaLoc.Size = new Size(100, 28);
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
            dsLich_Hen.Location = new Point(20, 130);
            dsLich_Hen.MultiSelect = false;
            dsLich_Hen.Name = "dsLich_Hen";
            dsLich_Hen.ReadOnly = true;
            dsLich_Hen.RowHeadersWidth = 51;
            dsLich_Hen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dsLich_Hen.Size = new Size(944, 380);
            dsLich_Hen.TabIndex = 2;
            dsLich_Hen.CellContentClick += dataGridView1_CellContentClick;
            dsLich_Hen.CellDoubleClick += dsLich_Hen_CellDoubleClick;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.FromArgb(248, 249, 250);
            pnlButtons.Controls.Add(btnKhamBenh);
            pnlButtons.Controls.Add(btnRefresh);
            pnlButtons.Controls.Add(btnXemChiTiet);
            pnlButtons.Controls.Add(lblTongSo);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 520);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(984, 60);
            pnlButtons.TabIndex = 3;
            // 
            // btnKhamBenh
            // 
            btnKhamBenh.BackColor = Color.FromArgb(40, 167, 69);
            btnKhamBenh.FlatStyle = FlatStyle.Flat;
            btnKhamBenh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnKhamBenh.ForeColor = Color.White;
            btnKhamBenh.Location = new Point(20, 12);
            btnKhamBenh.Name = "btnKhamBenh";
            btnKhamBenh.Size = new Size(150, 38);
            btnKhamBenh.TabIndex = 0;
            btnKhamBenh.Text = "KHÁM BỆNH";
            btnKhamBenh.UseVisualStyleBackColor = false;
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.BackColor = Color.FromArgb(0, 123, 255);
            btnXemChiTiet.FlatStyle = FlatStyle.Flat;
            btnXemChiTiet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXemChiTiet.ForeColor = Color.White;
            btnXemChiTiet.Location = new Point(185, 12);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(130, 38);
            btnXemChiTiet.TabIndex = 1;
            btnXemChiTiet.Text = "Chi tiết";
            btnXemChiTiet.UseVisualStyleBackColor = false;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(255, 193, 7);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(330, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 38);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTongSo
            // 
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongSo.ForeColor = Color.FromArgb(0, 123, 255);
            lblTongSo.Location = new Point(800, 22);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(120, 19);
            lblTongSo.TabIndex = 3;
            lblTongSo.Text = "Tổng: 0 lịch hẹn";
            // 
            // Lich_Hen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 580);
            Controls.Add(pnlButtons);
            Controls.Add(dsLich_Hen);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
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
    }
}
