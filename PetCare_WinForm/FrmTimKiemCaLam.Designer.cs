namespace PetCare_WinForm
{
    partial class FrmTimKiemCaLam
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
            comboBox_TimKiemTheo = new ComboBox();
            label1 = new Label();
            textBox_NhapThongTin = new TextBox();
            btn_TimKiem = new Button();
            SuspendLayout();
            // 
            // comboBox_TimKiemTheo
            // 
            comboBox_TimKiemTheo.FormattingEnabled = true;
            comboBox_TimKiemTheo.Items.AddRange(new object[] { "Mã nhân viên", "Tên nhân viên" });
            comboBox_TimKiemTheo.Location = new Point(12, 61);
            comboBox_TimKiemTheo.Name = "comboBox_TimKiemTheo";
            comboBox_TimKiemTheo.Size = new Size(208, 28);
            comboBox_TimKiemTheo.TabIndex = 0;
            comboBox_TimKiemTheo.SelectedIndexChanged += comboBox_TimKiemTheo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(14, 9);
            label1.Name = "label1";
            label1.Size = new Size(208, 41);
            label1.TabIndex = 1;
            label1.Text = "Tìm kiếm theo";
            // 
            // textBox_NhapThongTin
            // 
            textBox_NhapThongTin.Location = new Point(12, 104);
            textBox_NhapThongTin.Name = "textBox_NhapThongTin";
            textBox_NhapThongTin.Size = new Size(208, 27);
            textBox_NhapThongTin.TabIndex = 2;
            // 
            // btn_TimKiem
            // 
            btn_TimKiem.Font = new Font("Segoe UI", 14F);
            btn_TimKiem.Location = new Point(52, 148);
            btn_TimKiem.Name = "btn_TimKiem";
            btn_TimKiem.Size = new Size(133, 41);
            btn_TimKiem.TabIndex = 3;
            btn_TimKiem.Text = "Tìm kiếm";
            btn_TimKiem.UseVisualStyleBackColor = true;
            btn_TimKiem.Click += btn_TimKiem_Click;
            // 
            // FrmTimKiemCaLam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 208);
            Controls.Add(btn_TimKiem);
            Controls.Add(textBox_NhapThongTin);
            Controls.Add(label1);
            Controls.Add(comboBox_TimKiemTheo);
            Name = "FrmTimKiemCaLam";
            Text = "Tìm kiếm ca làm";
            Load += FrmTimKiemCaLam_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_TimKiemTheo;
        private Label label1;
        private TextBox textBox_NhapThongTin;
        private Button btn_TimKiem;
    }
}