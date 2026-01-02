namespace PetCare_WinForm
{
    partial class FrmDuyetLich
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
            dgvLichHen = new DataGridView();
            btnDuyet = new Button();
            btnTaoLichKham = new Button();
            btnRefresh = new Button();
            lblTitle = new Label();
            groupBoxTaoLich = new GroupBox();
            cmbThuCung = new ComboBox();
            lblThuCung = new Label();
            btnTimKiem = new Button();
            lblTenKH = new Label();
            txtTenKH = new TextBox();
            lblSoDT = new Label();
            txtSoDT = new TextBox();
            lblNgayHen = new Label();
            dtpNgayHen = new DateTimePicker();
            lblGioHen = new Label();
            dtpGioHen = new DateTimePicker();
            lblBacSi = new Label();
            cmbBacSi = new ComboBox();
            lblChiNhanh = new Label();
            cmbChiNhanh = new ComboBox();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            btnLuuLichMoi = new Button();
            btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLichHen).BeginInit();
            groupBoxTaoLich.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLichHen
            // 
            dgvLichHen.AllowUserToAddRows = false;
            dgvLichHen.AllowUserToDeleteRows = false;
            dgvLichHen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichHen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichHen.Location = new Point(12, 50);
            dgvLichHen.MultiSelect = false;
            dgvLichHen.Name = "dgvLichHen";
            dgvLichHen.ReadOnly = true;
            dgvLichHen.RowHeadersWidth = 51;
            dgvLichHen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichHen.Size = new Size(760, 250);
            dgvLichHen.TabIndex = 1;
            // 
            // btnDuyet
            // 
            btnDuyet.BackColor = Color.LimeGreen;
            btnDuyet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDuyet.ForeColor = Color.White;
            btnDuyet.Location = new Point(12, 310);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(120, 40);
            btnDuyet.TabIndex = 2;
            btnDuyet.Text = "DUYỆT";
            btnDuyet.UseVisualStyleBackColor = false;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // btnTaoLichKham
            // 
            btnTaoLichKham.BackColor = Color.DodgerBlue;
            btnTaoLichKham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaoLichKham.ForeColor = Color.White;
            btnTaoLichKham.Location = new Point(150, 310);
            btnTaoLichKham.Name = "btnTaoLichKham";
            btnTaoLichKham.Size = new Size(150, 40);
            btnTaoLichKham.TabIndex = 3;
            btnTaoLichKham.Text = "TẠO LỊCH KHÁM";
            btnTaoLichKham.UseVisualStyleBackColor = false;
            btnTaoLichKham.Click += btnTaoLichKham_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Orange;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(652, 310);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "LÀM MỚI";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(290, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ DUYỆT LỊCH HẸN";
            // 
            // groupBoxTaoLich
            // 
            groupBoxTaoLich.Controls.Add(cmbThuCung);
            groupBoxTaoLich.Controls.Add(lblThuCung);
            groupBoxTaoLich.Controls.Add(btnTimKiem);
            groupBoxTaoLich.Controls.Add(lblTenKH);
            groupBoxTaoLich.Controls.Add(txtTenKH);
            groupBoxTaoLich.Controls.Add(lblSoDT);
            groupBoxTaoLich.Controls.Add(txtSoDT);
            groupBoxTaoLich.Controls.Add(lblNgayHen);
            groupBoxTaoLich.Controls.Add(dtpNgayHen);
            groupBoxTaoLich.Controls.Add(lblGioHen);
            groupBoxTaoLich.Controls.Add(dtpGioHen);
            groupBoxTaoLich.Controls.Add(lblBacSi);
            groupBoxTaoLich.Controls.Add(cmbBacSi);
            groupBoxTaoLich.Controls.Add(lblChiNhanh);
            groupBoxTaoLich.Controls.Add(cmbChiNhanh);
            groupBoxTaoLich.Controls.Add(lblGhiChu);
            groupBoxTaoLich.Controls.Add(txtGhiChu);
            groupBoxTaoLich.Controls.Add(btnLuuLichMoi);
            groupBoxTaoLich.Controls.Add(btnHuy);
            groupBoxTaoLich.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxTaoLich.ForeColor = Color.DarkBlue;
            groupBoxTaoLich.Location = new Point(12, 360);
            groupBoxTaoLich.Name = "groupBoxTaoLich";
            groupBoxTaoLich.Size = new Size(760, 246);
            groupBoxTaoLich.TabIndex = 5;
            groupBoxTaoLich.TabStop = false;
            groupBoxTaoLich.Text = "TẠO LỊCH KHÁM CHO KHÁCH";
            groupBoxTaoLich.Visible = false;
            groupBoxTaoLich.Enter += groupBoxTaoLich_Enter;
            // 
            // cmbThuCung
            // 
            cmbThuCung.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbThuCung.Font = new Font("Segoe UI", 10F);
            cmbThuCung.FormattingEnabled = true;
            cmbThuCung.Location = new Point(411, 70);
            cmbThuCung.Name = "cmbThuCung";
            cmbThuCung.Size = new Size(191, 25);
            cmbThuCung.TabIndex = 16;
            // 
            // lblThuCung
            // 
            lblThuCung.AutoSize = true;
            lblThuCung.Font = new Font("Segoe UI", 9F);
            lblThuCung.ForeColor = Color.Black;
            lblThuCung.Location = new Point(344, 75);
            lblThuCung.Name = "lblThuCung";
            lblThuCung.Size = new Size(61, 15);
            lblThuCung.TabIndex = 15;
            lblThuCung.Text = "Thú cưng:";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(0, 123, 255);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(283, 28);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 28);
            btnTimKiem.TabIndex = 14;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // lblTenKH
            // 
            lblTenKH.AutoSize = true;
            lblTenKH.Font = new Font("Segoe UI", 9F);
            lblTenKH.ForeColor = Color.Black;
            lblTenKH.Location = new Point(23, 75);
            lblTenKH.Name = "lblTenKH";
            lblTenKH.Size = new Size(94, 15);
            lblTenKH.TabIndex = 0;
            lblTenKH.Text = "Tên khách hàng:";
            // 
            // txtTenKH
            // 
            txtTenKH.Font = new Font("Segoe UI", 9F);
            txtTenKH.Location = new Point(123, 72);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(200, 23);
            txtTenKH.TabIndex = 1;
            // 
            // lblSoDT
            // 
            lblSoDT.AutoSize = true;
            lblSoDT.Font = new Font("Segoe UI", 9F);
            lblSoDT.ForeColor = Color.Black;
            lblSoDT.Location = new Point(23, 35);
            lblSoDT.Name = "lblSoDT";
            lblSoDT.Size = new Size(79, 15);
            lblSoDT.TabIndex = 2;
            lblSoDT.Text = "Số điện thoại:";
            // 
            // txtSoDT
            // 
            txtSoDT.Font = new Font("Segoe UI", 9F);
            txtSoDT.Location = new Point(108, 32);
            txtSoDT.Name = "txtSoDT";
            txtSoDT.Size = new Size(150, 23);
            txtSoDT.TabIndex = 3;
            // 
            // lblNgayHen
            // 
            lblNgayHen.AutoSize = true;
            lblNgayHen.Font = new Font("Segoe UI", 9F);
            lblNgayHen.ForeColor = Color.Black;
            lblNgayHen.Location = new Point(23, 123);
            lblNgayHen.Name = "lblNgayHen";
            lblNgayHen.Size = new Size(61, 15);
            lblNgayHen.TabIndex = 4;
            lblNgayHen.Text = "Ngày hẹn:";
            // 
            // dtpNgayHen
            // 
            dtpNgayHen.Font = new Font("Segoe UI", 9F);
            dtpNgayHen.Format = DateTimePickerFormat.Short;
            dtpNgayHen.Location = new Point(123, 120);
            dtpNgayHen.Name = "dtpNgayHen";
            dtpNgayHen.Size = new Size(120, 23);
            dtpNgayHen.TabIndex = 5;
            // 
            // lblGioHen
            // 
            lblGioHen.AutoSize = true;
            lblGioHen.Font = new Font("Segoe UI", 9F);
            lblGioHen.ForeColor = Color.Black;
            lblGioHen.Location = new Point(263, 123);
            lblGioHen.Name = "lblGioHen";
            lblGioHen.Size = new Size(51, 15);
            lblGioHen.TabIndex = 6;
            lblGioHen.Text = "Giờ hẹn:";
            // 
            // dtpGioHen
            // 
            dtpGioHen.Font = new Font("Segoe UI", 9F);
            dtpGioHen.Format = DateTimePickerFormat.Time;
            dtpGioHen.Location = new Point(323, 120);
            dtpGioHen.Name = "dtpGioHen";
            dtpGioHen.ShowUpDown = true;
            dtpGioHen.Size = new Size(100, 23);
            dtpGioHen.TabIndex = 7;
            // 
            // lblBacSi
            // 
            lblBacSi.AutoSize = true;
            lblBacSi.Font = new Font("Segoe UI", 9F);
            lblBacSi.ForeColor = Color.Black;
            lblBacSi.Location = new Point(443, 123);
            lblBacSi.Name = "lblBacSi";
            lblBacSi.Size = new Size(40, 15);
            lblBacSi.TabIndex = 8;
            lblBacSi.Text = "Bác sĩ:";
            // 
            // cmbBacSi
            // 
            cmbBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBacSi.Font = new Font("Segoe UI", 9F);
            cmbBacSi.Location = new Point(493, 120);
            cmbBacSi.Name = "cmbBacSi";
            cmbBacSi.Size = new Size(250, 23);
            cmbBacSi.TabIndex = 9;
            // 
            // lblChiNhanh
            // 
            lblChiNhanh.AutoSize = true;
            lblChiNhanh.Font = new Font("Segoe UI", 9F);
            lblChiNhanh.ForeColor = Color.Black;
            lblChiNhanh.Location = new Point(23, 158);
            lblChiNhanh.Name = "lblChiNhanh";
            lblChiNhanh.Size = new Size(65, 15);
            lblChiNhanh.TabIndex = 10;
            lblChiNhanh.Text = "Chi nhánh:";
            // 
            // cmbChiNhanh
            // 
            cmbChiNhanh.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChiNhanh.Font = new Font("Segoe UI", 9F);
            cmbChiNhanh.Location = new Point(123, 155);
            cmbChiNhanh.Name = "cmbChiNhanh";
            cmbChiNhanh.Size = new Size(300, 23);
            cmbChiNhanh.TabIndex = 11;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Segoe UI", 9F);
            lblGhiChu.ForeColor = Color.Black;
            lblGhiChu.Location = new Point(443, 158);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(51, 15);
            lblGhiChu.TabIndex = 12;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 9F);
            txtGhiChu.Location = new Point(493, 155);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(250, 23);
            txtGhiChu.TabIndex = 13;
            // 
            // btnLuuLichMoi
            // 
            btnLuuLichMoi.BackColor = Color.LimeGreen;
            btnLuuLichMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuuLichMoi.ForeColor = Color.White;
            btnLuuLichMoi.Location = new Point(493, 198);
            btnLuuLichMoi.Name = "btnLuuLichMoi";
            btnLuuLichMoi.Size = new Size(120, 35);
            btnLuuLichMoi.TabIndex = 6;
            btnLuuLichMoi.Text = "LƯU";
            btnLuuLichMoi.UseVisualStyleBackColor = false;
            btnLuuLichMoi.Click += btnLuuLichMoi_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Gray;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(623, 198);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(120, 35);
            btnHuy.TabIndex = 7;
            btnHuy.Text = "HỦY";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // FrmDuyetLich
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 618);
            Controls.Add(lblTitle);
            Controls.Add(dgvLichHen);
            Controls.Add(btnDuyet);
            Controls.Add(btnTaoLichKham);
            Controls.Add(btnRefresh);
            Controls.Add(groupBoxTaoLich);
            Name = "FrmDuyetLich";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Duyệt Lịch Hẹn";
            Load += FrmDuyetLich_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLichHen).EndInit();
            groupBoxTaoLich.ResumeLayout(false);
            groupBoxTaoLich.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLichHen;
        private Button btnDuyet;
        private Button btnTaoLichKham;
        private Button btnRefresh;
        private Label lblTitle;
        private GroupBox groupBoxTaoLich;
        private Label lblTenKH;
        private TextBox txtTenKH;
        private Label lblSoDT;
        private TextBox txtSoDT;
        private Label lblNgayHen;
        private DateTimePicker dtpNgayHen;
        private Label lblGioHen;
        private DateTimePicker dtpGioHen;
        private Label lblBacSi;
        private ComboBox cmbBacSi;
        private Label lblChiNhanh;
        private ComboBox cmbChiNhanh;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnLuuLichMoi;
        private Button btnHuy;
        private Button btnTimKiem;
        private Label lblThuCung;
        private ComboBox cmbThuCung;
    }
}