namespace PetCare_WinForm.Forms
{
    partial class DoanhThu
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
            components = new System.ComponentModel.Container();
            hoaDonBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            label1 = new Label();
            dsTop10BS = new DataGridView();
            Choice_ChonThongKe = new ComboBox();
            dateTimePicker_DenNgay = new DateTimePicker();
            dateTimePicker_TuNgay = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            Choice_ChiNhanh = new ComboBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)hoaDonBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dsTop10BS).BeginInit();
            SuspendLayout();
            // 
            // hoaDonBindingSource
            // 
            hoaDonBindingSource.DataSource = typeof(Models.HoaDon);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(387, 111);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(370, 252);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(56, 49);
            label1.Name = "label1";
            label1.Size = new Size(229, 56);
            label1.TabIndex = 5;
            label1.Text = "Top 10 bác sĩ có doanh\r\nthu cao nhất";
            // 
            // dsTop10BS
            // 
            dsTop10BS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dsTop10BS.Location = new Point(56, 113);
            dsTop10BS.Name = "dsTop10BS";
            dsTop10BS.RowHeadersWidth = 51;
            dsTop10BS.Size = new Size(285, 250);
            dsTop10BS.TabIndex = 6;
            dsTop10BS.CellContentClick += dsTop10BS_CellContentClick;
            // 
            // Choice_ChonThongKe
            // 
            Choice_ChonThongKe.FormattingEnabled = true;
            Choice_ChonThongKe.Items.AddRange(new object[] { "1. Hóa đơn chi tiết", "2. Thống kê doanh thu theo bác sĩ", "3. Thống kê số lượt khám bệnh", "4. Thống kê doanh thu sản phẩm", "5. Thống kê doanh thu tất cả chi nhánh", "6. Thống kê lượt khám theo chi nhánh" });
            Choice_ChonThongKe.Location = new Point(387, 374);
            Choice_ChonThongKe.Name = "Choice_ChonThongKe";
            Choice_ChonThongKe.Size = new Size(370, 28);
            Choice_ChonThongKe.TabIndex = 9;
            Choice_ChonThongKe.SelectedIndexChanged += Choice_ChonThongKe_SelectedIndexChanged;
            // 
            // dateTimePicker_DenNgay
            // 
            dateTimePicker_DenNgay.Format = DateTimePickerFormat.Short;
            dateTimePicker_DenNgay.Location = new Point(507, 71);
            dateTimePicker_DenNgay.Name = "dateTimePicker_DenNgay";
            dateTimePicker_DenNgay.ShowCheckBox = true;
            dateTimePicker_DenNgay.Size = new Size(250, 27);
            dateTimePicker_DenNgay.TabIndex = 10;
            // 
            // dateTimePicker_TuNgay
            // 
            dateTimePicker_TuNgay.Format = DateTimePickerFormat.Short;
            dateTimePicker_TuNgay.Location = new Point(507, 28);
            dateTimePicker_TuNgay.Name = "dateTimePicker_TuNgay";
            dateTimePicker_TuNgay.ShowCheckBox = true;
            dateTimePicker_TuNgay.Size = new Size(250, 27);
            dateTimePicker_TuNgay.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(384, 72);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 12;
            label2.Text = "Đến ngày:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(393, 33);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 13;
            label3.Text = "Từ ngày:";
            // 
            // button1
            // 
            button1.Location = new Point(662, 411);
            button1.Name = "button1";
            button1.Size = new Size(95, 29);
            button1.TabIndex = 14;
            button1.Text = "Hiển thị";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Choice_ChiNhanh
            // 
            Choice_ChiNhanh.FormattingEnabled = true;
            Choice_ChiNhanh.Items.AddRange(new object[] { "CN1", "CN2", "CN3", "CN4", "CN5", "CN6", "CN7", "CN8", "CN9", "CN10" });
            Choice_ChiNhanh.Location = new Point(387, 412);
            Choice_ChiNhanh.Name = "Choice_ChiNhanh";
            Choice_ChiNhanh.Size = new Size(74, 28);
            Choice_ChiNhanh.TabIndex = 15;
            Choice_ChiNhanh.SelectedIndexChanged += Choice_ChiNhanh_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(472, 413);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên KH hoặc Mã HĐ";
            textBox1.Size = new Size(182, 27);
            textBox1.TabIndex = 16;
            // 
            // DoanhThu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(Choice_ChiNhanh);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dateTimePicker_TuNgay);
            Controls.Add(dateTimePicker_DenNgay);
            Controls.Add(Choice_ChonThongKe);
            Controls.Add(dsTop10BS);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "DoanhThu";
            Text = "Doanh Thu";
            Load += DoanhThu_Load;
            ((System.ComponentModel.ISupportInitialize)hoaDonBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dsTop10BS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BindingSource hoaDonBindingSource;
        private DataGridView dataGridView1;
        private Label label1;
        private DataGridView dsTop10BS;
        private ComboBox Choice_ChonThongKe;
        private DateTimePicker dateTimePicker_DenNgay;
        private DateTimePicker dateTimePicker_TuNgay;
        private Label label2;
        private Label label3;
        private Button button1;
        private ComboBox Choice_ChiNhanh;
        private TextBox textBox1;
    }
}