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
            textMaNhanVien = new TextBox();
            dataGridView1 = new DataGridView();
            TimerChamCong = new System.Windows.Forms.Timer(components);
            lblThoiGianHienTai = new Label();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textMaNhanVien
            // 
            textMaNhanVien.Font = new Font("Segoe UI", 22F);
            textMaNhanVien.Location = new Point(385, 94);
            textMaNhanVien.Name = "textMaNhanVien";
            textMaNhanVien.PlaceholderText = "Mã nhân viên";
            textMaNhanVien.Size = new Size(230, 56);
            textMaNhanVien.TabIndex = 3;
            textMaNhanVien.TextChanged += textMaNhanVien_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 240);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 210);
            dataGridView1.TabIndex = 4;
            // 
            // TimerChamCong
            // 
            TimerChamCong.Interval = 1000;
            TimerChamCong.Tick += TimerChamCong_Tick;
            // 
            // lblThoiGianHienTai
            // 
            lblThoiGianHienTai.Dock = DockStyle.Top;
            lblThoiGianHienTai.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblThoiGianHienTai.Location = new Point(0, 0);
            lblThoiGianHienTai.Name = "lblThoiGianHienTai";
            lblThoiGianHienTai.Size = new Size(800, 74);
            lblThoiGianHienTai.TabIndex = 6;
            lblThoiGianHienTai.Text = "--/--/-- --:--";
            lblThoiGianHienTai.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 18F);
            button2.Location = new Point(406, 168);
            button2.Name = "button2";
            button2.Size = new Size(306, 54);
            button2.TabIndex = 8;
            button2.Text = "Check-Out";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 18F);
            button3.Location = new Point(60, 168);
            button3.Name = "button3";
            button3.Size = new Size(303, 54);
            button3.TabIndex = 9;
            button3.Text = "Check-In";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(151, 94);
            label1.Name = "label1";
            label1.Size = new Size(212, 54);
            label1.TabIndex = 10;
            label1.Text = "Nhân viên:";
            // 
            // ChamCongNV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(lblThoiGianHienTai);
            Controls.Add(dataGridView1);
            Controls.Add(textMaNhanVien);
            Name = "ChamCongNV";
            Text = "Chấm công NV";
            Load += ChamCongNV_Load;
            Resize += ChamCongNV_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textMaNhanVien;
        private DataGridView dataGridView1;
        private System.Windows.Forms.Timer TimerChamCong;
        private Label lblThoiGianHienTai;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}