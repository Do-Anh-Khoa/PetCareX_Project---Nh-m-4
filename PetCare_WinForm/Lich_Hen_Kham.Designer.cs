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
            dsLich_Hen = new DataGridView();
            maLichHen = new DataGridViewTextBoxColumn();
            ngayHen = new DataGridViewTextBoxColumn();
            gioHen = new DataGridViewTextBoxColumn();
            trang_thai = new DataGridViewTextBoxColumn();
            ghiChu = new DataGridViewTextBoxColumn();
            maKH = new DataGridViewTextBoxColumn();
            btnKhamBenh = new Button();
            ((System.ComponentModel.ISupportInitialize)dsLich_Hen).BeginInit();
            SuspendLayout();
            // 
            // dsLich_Hen
            // 
            dsLich_Hen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dsLich_Hen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dsLich_Hen.Columns.AddRange(new DataGridViewColumn[] { maLichHen, ngayHen, gioHen, trang_thai, ghiChu, maKH });
            dsLich_Hen.Location = new Point(12, 12);
            dsLich_Hen.Name = "dsLich_Hen";
            dsLich_Hen.Size = new Size(864, 442);
            dsLich_Hen.TabIndex = 0;
            dsLich_Hen.CellContentClick += dataGridView1_CellContentClick;
            // 
            // maLichHen
            // 
            maLichHen.HeaderText = "Mã lịch hẹn";
            maLichHen.Name = "maLichHen";
            // 
            // ngayHen
            // 
            ngayHen.HeaderText = "Ngày hẹn";
            ngayHen.Name = "ngayHen";
            // 
            // gioHen
            // 
            gioHen.HeaderText = "Giờ hẹn";
            gioHen.Name = "gioHen";
            // 
            // trang_thai
            // 
            trang_thai.HeaderText = "Trạng thái";
            trang_thai.Name = "trang_thai";
            // 
            // ghiChu
            // 
            ghiChu.HeaderText = "Ghi chú";
            ghiChu.Name = "ghiChu";
            // 
            // maKH
            // 
            maKH.HeaderText = "Mã khách hàng";
            maKH.Name = "maKH";
            // 
            // btnKhamBenh
            // 
            btnKhamBenh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKhamBenh.Location = new Point(12, 472);
            btnKhamBenh.Name = "btnKhamBenh";
            btnKhamBenh.Size = new Size(119, 31);
            btnKhamBenh.TabIndex = 1;
            btnKhamBenh.Text = "Khám bệnh";
            btnKhamBenh.UseVisualStyleBackColor = true;
            // 
            // Lich_Hen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 534);
            Controls.Add(btnKhamBenh);
            Controls.Add(dsLich_Hen);
            Name = "Lich_Hen";
            Text = "LỊCH HẸN KHÁM";
            Load += lich_Hen_Load;
            ((System.ComponentModel.ISupportInitialize)dsLich_Hen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dsLich_Hen;
        private Button btnKhamBenh;
        private DataGridViewTextBoxColumn maLichHen;
        private DataGridViewTextBoxColumn ngayHen;
        private DataGridViewTextBoxColumn gioHen;
        private DataGridViewTextBoxColumn trang_thai;
        private DataGridViewTextBoxColumn ghiChu;
        private DataGridViewTextBoxColumn maKH;
    }
}
