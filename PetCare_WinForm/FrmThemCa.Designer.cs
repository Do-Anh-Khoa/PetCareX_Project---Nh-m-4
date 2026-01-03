namespace PetCare_WinForm
{
    partial class FrmThemCa
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
            label1 = new Label();
            dateTimePicker_ChonNgay = new DateTimePicker();
            comboBox_ChonCa = new ComboBox();
            comboBox_ChonLoai = new ComboBox();
            textBox_DienThongTin = new TextBox();
            btn_ThemCa = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(245, 41);
            label1.TabIndex = 0;
            label1.Text = "Thêm ca làm việc";
            // 
            // dateTimePicker_ChonNgay
            // 
            dateTimePicker_ChonNgay.Format = DateTimePickerFormat.Short;
            dateTimePicker_ChonNgay.Location = new Point(8, 142);
            dateTimePicker_ChonNgay.Name = "dateTimePicker_ChonNgay";
            dateTimePicker_ChonNgay.Size = new Size(107, 27);
            dateTimePicker_ChonNgay.TabIndex = 1;
            // 
            // comboBox_ChonCa
            // 
            comboBox_ChonCa.FormattingEnabled = true;
            comboBox_ChonCa.Items.AddRange(new object[] { "Sáng", "Chiều", "Tối" });
            comboBox_ChonCa.Location = new Point(137, 142);
            comboBox_ChonCa.Name = "comboBox_ChonCa";
            comboBox_ChonCa.Size = new Size(97, 28);
            comboBox_ChonCa.TabIndex = 2;
            // 
            // comboBox_ChonLoai
            // 
            comboBox_ChonLoai.FormattingEnabled = true;
            comboBox_ChonLoai.Items.AddRange(new object[] { "Thêm bằng mã nhân viên", "Thêm bằng tên nhân viên" });
            comboBox_ChonLoai.Location = new Point(8, 55);
            comboBox_ChonLoai.Name = "comboBox_ChonLoai";
            comboBox_ChonLoai.Size = new Size(226, 28);
            comboBox_ChonLoai.TabIndex = 3;
            comboBox_ChonLoai.SelectedIndexChanged += comboBox_ChonLoai_SelectedIndexChanged;
            // 
            // textBox_DienThongTin
            // 
            textBox_DienThongTin.Location = new Point(8, 95);
            textBox_DienThongTin.Name = "textBox_DienThongTin";
            textBox_DienThongTin.Size = new Size(226, 27);
            textBox_DienThongTin.TabIndex = 4;
            // 
            // btn_ThemCa
            // 
            btn_ThemCa.Font = new Font("Segoe UI", 16F);
            btn_ThemCa.Location = new Point(10, 187);
            btn_ThemCa.Name = "btn_ThemCa";
            btn_ThemCa.Size = new Size(224, 49);
            btn_ThemCa.TabIndex = 5;
            btn_ThemCa.Text = "Thêm ca";
            btn_ThemCa.UseVisualStyleBackColor = true;
            btn_ThemCa.Click += btn_ThemCa_Click;
            // 
            // FrmThemCa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 248);
            Controls.Add(btn_ThemCa);
            Controls.Add(textBox_DienThongTin);
            Controls.Add(comboBox_ChonLoai);
            Controls.Add(comboBox_ChonCa);
            Controls.Add(dateTimePicker_ChonNgay);
            Controls.Add(label1);
            Name = "FrmThemCa";
            Text = "Thêm ca làm việc";
            Load += FrmThemCa_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePicker_ChonNgay;
        private ComboBox comboBox_ChonCa;
        private ComboBox comboBox_ChonLoai;
        private TextBox textBox_DienThongTin;
        private Button btn_ThemCa;
    }
}