namespace PetCare_WinForm
{
    partial class ChamCongNV : Form // Ensure ChamCongNV inherits from Form
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textMaNhanVien = new TextBox();
            dataGridView1 = new DataGridView();
            TimerChamCong = new System.Windows.Forms.Timer(components);
            lblThoiGianHienTai = new Label();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(186, 97);
            label1.Name = "label1";
            label1.Size = new Size(204, 41);
            label1.TabIndex = 2;
            label1.Text = "NHÂN VIÊN: ";
            // 
            // textMaNhanVien
            // 
            textMaNhanVien.Font = new Font("Segoe UI", 14F);
            textMaNhanVien.Location = new Point(391, 98);
            textMaNhanVien.Name = "textMaNhanVien";
            textMaNhanVien.PlaceholderText = "Mã nhân viên";
            textMaNhanVien.Size = new Size(161, 39);
            textMaNhanVien.TabIndex = 3;
            textMaNhanVien.TextChanged += textMaNhanVien_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(38, 241);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(717, 173);
            dataGridView1.TabIndex = 4;
            // 
            // TimerChamCong
            // 
            TimerChamCong.Interval = 1000;
            TimerChamCong.Tick += TimerChamCong_Tick;
            // 
            // lblThoiGianHienTai
            // 
            lblThoiGianHienTai.AutoSize = true;
            lblThoiGianHienTai.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblThoiGianHienTai.Location = new Point(295, 30);
            lblThoiGianHienTai.Name = "lblThoiGianHienTai";
            lblThoiGianHienTai.Size = new Size(150, 32);
            lblThoiGianHienTai.TabIndex = 6;
            lblThoiGianHienTai.Text = "--/--/-- --:--";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 18F);
            button2.Location = new Point(362, 151);
            button2.Name = "button2";
            button2.Size = new Size(190, 54);
            button2.TabIndex = 8;
            button2.Text = "Check-Out";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 18F);
            button3.Location = new Point(186, 151);
            button3.Name = "button3";
            button3.Size = new Size(161, 54);
            button3.TabIndex = 9;
            button3.Text = "Check-In";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ChamCongNV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(lblThoiGianHienTai);
            Controls.Add(dataGridView1);
            Controls.Add(textMaNhanVien);
            Controls.Add(label1);
            Name = "ChamCongNV";
            Text = "Chấm công NV";
            Load += ChamCongNV_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textMaNhanVien;
        private DataGridView dataGridView1;
        private System.Windows.Forms.Timer TimerChamCong;
        private Label lblThoiGianHienTai;
        private Button button2;
        private Button button3;
    }
}