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
            lblTenThuCung = new Label();
            lblTenBacSi = new Label();
            lblTenChu = new Label();
            lblNgayKham = new Label();
            label1 = new Label();
            txtTrieuChung = new TextBox();
            label2 = new Label();
            txtChanDoan = new TextBox();
            dgvVacXin = new DataGridView();
            tenVacXin = new DataGridViewTextBoxColumn();
            loaiVacXin = new DataGridViewTextBoxColumn();
            lieuLuong = new DataGridViewTextBoxColumn();
            ngayTiem = new DataGridViewTextBoxColumn();
            btnHoanTatKham = new Button();
            rBtnToaThuoc = new RadioButton();
            rBtnVacXin = new RadioButton();
            lblToaThuoc = new Label();
            txtToaThuoc = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvVacXin).BeginInit();
            SuspendLayout();
            // 
            // lblTenThuCung
            // 
            lblTenThuCung.AutoSize = true;
            lblTenThuCung.Font = new Font("Segoe UI", 10F);
            lblTenThuCung.Location = new Point(12, 19);
            lblTenThuCung.Name = "lblTenThuCung";
            lblTenThuCung.Size = new Size(69, 19);
            lblTenThuCung.TabIndex = 0;
            lblTenThuCung.Text = "Thú cưng:";
            // 
            // lblTenBacSi
            // 
            lblTenBacSi.AutoSize = true;
            lblTenBacSi.Font = new Font("Segoe UI", 10F);
            lblTenBacSi.Location = new Point(12, 66);
            lblTenBacSi.Name = "lblTenBacSi";
            lblTenBacSi.Size = new Size(46, 19);
            lblTenBacSi.TabIndex = 1;
            lblTenBacSi.Text = "Bác sĩ:";
            // 
            // lblTenChu
            // 
            lblTenChu.AutoSize = true;
            lblTenChu.Font = new Font("Segoe UI", 10F);
            lblTenChu.Location = new Point(260, 19);
            lblTenChu.Name = "lblTenChu";
            lblTenChu.Size = new Size(37, 19);
            lblTenChu.TabIndex = 2;
            lblTenChu.Text = "Chủ:";
            // 
            // lblNgayKham
            // 
            lblNgayKham.AutoSize = true;
            lblNgayKham.Font = new Font("Segoe UI", 10F);
            lblNgayKham.Location = new Point(260, 66);
            lblNgayKham.Name = "lblNgayKham";
            lblNgayKham.Size = new Size(82, 19);
            lblNgayKham.TabIndex = 3;
            lblNgayKham.Text = "Ngày khám:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(12, 114);
            label1.Name = "label1";
            label1.Size = new Size(83, 19);
            label1.TabIndex = 4;
            label1.Text = "Triệu chứng:";
            // 
            // txtTrieuChung
            // 
            txtTrieuChung.Font = new Font("Segoe UI", 10F);
            txtTrieuChung.Location = new Point(101, 114);
            txtTrieuChung.Multiline = true;
            txtTrieuChung.Name = "txtTrieuChung";
            txtTrieuChung.Size = new Size(372, 23);
            txtTrieuChung.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(12, 180);
            label2.Name = "label2";
            label2.Size = new Size(79, 19);
            label2.TabIndex = 6;
            label2.Text = "Chẩn đoán:";
            // 
            // txtChanDoan
            // 
            txtChanDoan.Font = new Font("Segoe UI", 10F);
            txtChanDoan.Location = new Point(101, 180);
            txtChanDoan.Multiline = true;
            txtChanDoan.Name = "txtChanDoan";
            txtChanDoan.Size = new Size(372, 23);
            txtChanDoan.TabIndex = 7;
            // 
            // dgvVacXin
            // 
            dgvVacXin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVacXin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVacXin.Columns.AddRange(new DataGridViewColumn[] { tenVacXin, loaiVacXin, lieuLuong, ngayTiem });
            dgvVacXin.Enabled = false;
            dgvVacXin.Location = new Point(12, 303);
            dgvVacXin.Name = "dgvVacXin";
            dgvVacXin.Size = new Size(489, 169);
            dgvVacXin.TabIndex = 9;
            // 
            // tenVacXin
            // 
            tenVacXin.HeaderText = "Tên Vắc-xin";
            tenVacXin.Name = "tenVacXin";
            // 
            // loaiVacXin
            // 
            loaiVacXin.HeaderText = "Loại Vắc-xin";
            loaiVacXin.Name = "loaiVacXin";
            // 
            // lieuLuong
            // 
            lieuLuong.HeaderText = "Liều lượng";
            lieuLuong.Name = "lieuLuong";
            // 
            // ngayTiem
            // 
            ngayTiem.HeaderText = "Ngày tiêm";
            ngayTiem.Name = "ngayTiem";
            // 
            // btnHoanTatKham
            // 
            btnHoanTatKham.Font = new Font("Segoe UI", 10F);
            btnHoanTatKham.Location = new Point(176, 490);
            btnHoanTatKham.Name = "btnHoanTatKham";
            btnHoanTatKham.Size = new Size(134, 28);
            btnHoanTatKham.TabIndex = 10;
            btnHoanTatKham.Text = "Hoàn tất khám";
            btnHoanTatKham.UseVisualStyleBackColor = true;
            btnHoanTatKham.Click += btnHoanTatKham_Click;
            // 
            // rBtnToaThuoc
            // 
            rBtnToaThuoc.AutoSize = true;
            rBtnToaThuoc.Font = new Font("Segoe UI", 10F);
            rBtnToaThuoc.Location = new Point(17, 228);
            rBtnToaThuoc.Name = "rBtnToaThuoc";
            rBtnToaThuoc.Size = new Size(87, 23);
            rBtnToaThuoc.TabIndex = 0;
            rBtnToaThuoc.TabStop = true;
            rBtnToaThuoc.Text = "Toa thuốc";
            rBtnToaThuoc.UseVisualStyleBackColor = true;
            rBtnToaThuoc.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rBtnVacXin
            // 
            rBtnVacXin.AutoSize = true;
            rBtnVacXin.Font = new Font("Segoe UI", 10F);
            rBtnVacXin.Location = new Point(119, 228);
            rBtnVacXin.Name = "rBtnVacXin";
            rBtnVacXin.Size = new Size(72, 23);
            rBtnVacXin.TabIndex = 1;
            rBtnVacXin.TabStop = true;
            rBtnVacXin.Text = "Vắc-xin";
            rBtnVacXin.UseVisualStyleBackColor = true;
            // 
            // lblToaThuoc
            // 
            lblToaThuoc.AutoSize = true;
            lblToaThuoc.Enabled = false;
            lblToaThuoc.Font = new Font("Segoe UI", 10F);
            lblToaThuoc.Location = new Point(19, 264);
            lblToaThuoc.Name = "lblToaThuoc";
            lblToaThuoc.Size = new Size(76, 19);
            lblToaThuoc.TabIndex = 11;
            lblToaThuoc.Text = "Toa thuốc: ";
            // 
            // txtToaThuoc
            // 
            txtToaThuoc.Enabled = false;
            txtToaThuoc.Font = new Font("Segoe UI", 10F);
            txtToaThuoc.Location = new Point(101, 261);
            txtToaThuoc.Multiline = true;
            txtToaThuoc.Name = "txtToaThuoc";
            txtToaThuoc.Size = new Size(372, 23);
            txtToaThuoc.TabIndex = 12;
            // 
            // Kham_Benh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 532);
            Controls.Add(txtToaThuoc);
            Controls.Add(lblToaThuoc);
            Controls.Add(rBtnVacXin);
            Controls.Add(rBtnToaThuoc);
            Controls.Add(btnHoanTatKham);
            Controls.Add(dgvVacXin);
            Controls.Add(txtChanDoan);
            Controls.Add(label2);
            Controls.Add(txtTrieuChung);
            Controls.Add(label1);
            Controls.Add(lblNgayKham);
            Controls.Add(lblTenChu);
            Controls.Add(lblTenBacSi);
            Controls.Add(lblTenThuCung);
            Name = "Kham_Benh";
            Text = "KHÁM BỆNH";
            Load += Kham_Benh_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVacXin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenThuCung;
        private Label lblTenBacSi;
        private Label lblTenChu;
        private Label lblNgayKham;
        private Label label1;
        private TextBox txtTrieuChung;
        private Label label2;
        private TextBox txtChanDoan;
        private DataGridView dgvVacXin;
        private DataGridViewTextBoxColumn tenVacXin;
        private DataGridViewTextBoxColumn loaiVacXin;
        private DataGridViewTextBoxColumn lieuLuong;
        private DataGridViewTextBoxColumn ngayTiem;
        private Button btnHoanTatKham;
        private RadioButton rBtnToaThuoc;
        private RadioButton rBtnVacXin;
        private Label lblToaThuoc;
        private TextBox txtToaThuoc;
    }
}