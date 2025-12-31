namespace PetCare_WinForm.Forms
{
    partial class PhanCa
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
            textBox_MaNV_TimKiem = new TextBox();
            label1 = new Label();
            dataGridView_TiemKiemCaLam = new DataGridView();
            button_HienThi = new Button();
            textBox_MaNV_Them = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button_Them = new Button();
            textBox_MaCa_Them = new TextBox();
            dateTimePicker_ChonNgay1 = new DateTimePicker();
            label4 = new Label();
            dateTimePicker_ChonNgay2 = new DateTimePicker();
            textBox_MaCa_Xoa = new TextBox();
            button_Xoa = new Button();
            textBox_MaNV_Xoa = new TextBox();
            dateTimePicker_TuNgay = new DateTimePicker();
            dateTimePicker_DenNgay = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_TiemKiemCaLam).BeginInit();
            SuspendLayout();
            // 
            // textBox_MaNV_TimKiem
            // 
            textBox_MaNV_TimKiem.Font = new Font("Segoe UI", 12F);
            textBox_MaNV_TimKiem.Location = new Point(164, 64);
            textBox_MaNV_TimKiem.Name = "textBox_MaNV_TimKiem";
            textBox_MaNV_TimKiem.PlaceholderText = "Nhập mã nhân viên";
            textBox_MaNV_TimKiem.Size = new Size(99, 34);
            textBox_MaNV_TimKiem.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(28, 67);
            label1.Name = "label1";
            label1.Size = new Size(133, 28);
            label1.TabIndex = 1;
            label1.Text = "Mã nhân viên:";
            // 
            // dataGridView_TiemKiemCaLam
            // 
            dataGridView_TiemKiemCaLam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_TiemKiemCaLam.Location = new Point(291, 25);
            dataGridView_TiemKiemCaLam.Name = "dataGridView_TiemKiemCaLam";
            dataGridView_TiemKiemCaLam.RowHeadersWidth = 51;
            dataGridView_TiemKiemCaLam.Size = new Size(491, 156);
            dataGridView_TiemKiemCaLam.TabIndex = 2;
            // 
            // button_HienThi
            // 
            button_HienThi.Location = new Point(28, 205);
            button_HienThi.Name = "button_HienThi";
            button_HienThi.Size = new Size(235, 37);
            button_HienThi.TabIndex = 3;
            button_HienThi.Text = "Hiển thị";
            button_HienThi.UseVisualStyleBackColor = true;
            button_HienThi.Click += button_HienThi_Click;
            // 
            // textBox_MaNV_Them
            // 
            textBox_MaNV_Them.Location = new Point(315, 238);
            textBox_MaNV_Them.Name = "textBox_MaNV_Them";
            textBox_MaNV_Them.PlaceholderText = "Mã nhân viên";
            textBox_MaNV_Them.Size = new Size(213, 27);
            textBox_MaNV_Them.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 23);
            label2.Name = "label2";
            label2.Size = new Size(212, 28);
            label2.TabIndex = 5;
            label2.Text = "Tìm kiếm ca làm việc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(330, 191);
            label3.Name = "label3";
            label3.Size = new Size(177, 28);
            label3.TabIndex = 6;
            label3.Text = "Thêm ca làm việc";
            // 
            // button_Them
            // 
            button_Them.Location = new Point(354, 399);
            button_Them.Name = "button_Them";
            button_Them.Size = new Size(128, 29);
            button_Them.TabIndex = 7;
            button_Them.Text = "Thêm ca làm";
            button_Them.UseVisualStyleBackColor = true;
            button_Them.Click += button_Them_Click;
            // 
            // textBox_MaCa_Them
            // 
            textBox_MaCa_Them.Location = new Point(315, 287);
            textBox_MaCa_Them.Name = "textBox_MaCa_Them";
            textBox_MaCa_Them.PlaceholderText = "Mã ca";
            textBox_MaCa_Them.Size = new Size(213, 27);
            textBox_MaCa_Them.TabIndex = 8;
            // 
            // dateTimePicker_ChonNgay1
            // 
            dateTimePicker_ChonNgay1.Format = DateTimePickerFormat.Short;
            dateTimePicker_ChonNgay1.Location = new Point(315, 341);
            dateTimePicker_ChonNgay1.Name = "dateTimePicker_ChonNgay1";
            dateTimePicker_ChonNgay1.Size = new Size(213, 27);
            dateTimePicker_ChonNgay1.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(594, 191);
            label4.Name = "label4";
            label4.Size = new Size(160, 28);
            label4.TabIndex = 10;
            label4.Text = "Xóa ca làm việc";
            label4.Click += label4_Click;
            // 
            // dateTimePicker_ChonNgay2
            // 
            dateTimePicker_ChonNgay2.Format = DateTimePickerFormat.Short;
            dateTimePicker_ChonNgay2.Location = new Point(568, 341);
            dateTimePicker_ChonNgay2.Name = "dateTimePicker_ChonNgay2";
            dateTimePicker_ChonNgay2.Size = new Size(213, 27);
            dateTimePicker_ChonNgay2.TabIndex = 14;
            // 
            // textBox_MaCa_Xoa
            // 
            textBox_MaCa_Xoa.Location = new Point(569, 287);
            textBox_MaCa_Xoa.Name = "textBox_MaCa_Xoa";
            textBox_MaCa_Xoa.PlaceholderText = "Mã ca";
            textBox_MaCa_Xoa.Size = new Size(213, 27);
            textBox_MaCa_Xoa.TabIndex = 13;
            // 
            // button_Xoa
            // 
            button_Xoa.Location = new Point(608, 399);
            button_Xoa.Name = "button_Xoa";
            button_Xoa.Size = new Size(128, 29);
            button_Xoa.TabIndex = 12;
            button_Xoa.Text = "Xóa ca làm";
            button_Xoa.UseVisualStyleBackColor = true;
            button_Xoa.Click += button_Xoa_Click;
            // 
            // textBox_MaNV_Xoa
            // 
            textBox_MaNV_Xoa.Location = new Point(569, 238);
            textBox_MaNV_Xoa.Name = "textBox_MaNV_Xoa";
            textBox_MaNV_Xoa.PlaceholderText = "Mã nhân viên";
            textBox_MaNV_Xoa.Size = new Size(213, 27);
            textBox_MaNV_Xoa.TabIndex = 11;
            // 
            // dateTimePicker_TuNgay
            // 
            dateTimePicker_TuNgay.Format = DateTimePickerFormat.Short;
            dateTimePicker_TuNgay.Location = new Point(164, 113);
            dateTimePicker_TuNgay.Name = "dateTimePicker_TuNgay";
            dateTimePicker_TuNgay.ShowCheckBox = true;
            dateTimePicker_TuNgay.Size = new Size(99, 27);
            dateTimePicker_TuNgay.TabIndex = 15;
            // 
            // dateTimePicker_DenNgay
            // 
            dateTimePicker_DenNgay.Format = DateTimePickerFormat.Short;
            dateTimePicker_DenNgay.Location = new Point(164, 157);
            dateTimePicker_DenNgay.Name = "dateTimePicker_DenNgay";
            dateTimePicker_DenNgay.ShowCheckBox = true;
            dateTimePicker_DenNgay.Size = new Size(99, 27);
            dateTimePicker_DenNgay.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(28, 111);
            label5.Name = "label5";
            label5.Size = new Size(86, 28);
            label5.TabIndex = 17;
            label5.Text = "Từ ngày:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(28, 155);
            label6.Name = "label6";
            label6.Size = new Size(99, 28);
            label6.TabIndex = 18;
            label6.Text = "Đến ngày:";
            // 
            // PhanCa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dateTimePicker_DenNgay);
            Controls.Add(dateTimePicker_TuNgay);
            Controls.Add(dateTimePicker_ChonNgay2);
            Controls.Add(textBox_MaCa_Xoa);
            Controls.Add(button_Xoa);
            Controls.Add(textBox_MaNV_Xoa);
            Controls.Add(label4);
            Controls.Add(dateTimePicker_ChonNgay1);
            Controls.Add(textBox_MaCa_Them);
            Controls.Add(button_Them);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox_MaNV_Them);
            Controls.Add(button_HienThi);
            Controls.Add(dataGridView_TiemKiemCaLam);
            Controls.Add(label1);
            Controls.Add(textBox_MaNV_TimKiem);
            Name = "PhanCa";
            Text = "Phân Ca";
            Load += PhanCa_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView_TiemKiemCaLam).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_MaNV_TimKiem;
        private Label label1;
        private DataGridView dataGridView_TiemKiemCaLam;
        private Button button_HienThi;
        private TextBox textBox_MaNV_Them;
        private Label label2;
        private Label label3;
        private Button button_Them;
        private TextBox textBox_MaCa_Them;
        private DateTimePicker dateTimePicker_ChonNgay1;
        private Label label4;
        private DateTimePicker dateTimePicker_ChonNgay2;
        private TextBox textBox_MaCa_Xoa;
        private Button button_Xoa;
        private TextBox textBox_MaNV_Xoa;
        private DateTimePicker dateTimePicker_TuNgay;
        private DateTimePicker dateTimePicker_DenNgay;
        private Label label5;
        private Label label6;
    }
}