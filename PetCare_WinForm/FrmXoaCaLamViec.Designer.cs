namespace PetCare_WinForm
{
    partial class FrmXoaCaLamViec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            dateTimePicker_ChonNgay = new DateTimePicker();
            comboBox_ChonCa = new ComboBox();
            comboBox_ChonLoai = new ComboBox();
            textBox_DienThongTin = new TextBox();
            btn_XoaCa = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(221, 41);
            label1.TabIndex = 0;
            label1.Text = "Xóa ca làm việc";
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
            comboBox_ChonLoai.Items.AddRange(new object[] { "Xóa bằng mã nhân viên", "Xóa bằng tên nhân viên" });
            comboBox_ChonLoai.Location = new Point(8, 55);
            comboBox_ChonLoai.Name = "comboBox_ChonLoai";
            comboBox_ChonLoai.Size = new Size(226, 28);
            comboBox_ChonLoai.TabIndex = 3;
            comboBox_ChonLoai.SelectedIndexChanged += comboBox_ChonLoai_SelectedIndexChanged_1;
            // 
            // textBox_DienThongTin
            // 
            textBox_DienThongTin.Location = new Point(8, 95);
            textBox_DienThongTin.Name = "textBox_DienThongTin";
            textBox_DienThongTin.Size = new Size(226, 27);
            textBox_DienThongTin.TabIndex = 4;
            // 
            // btn_XoaCa
            // 
            btn_XoaCa.Font = new Font("Segoe UI", 16F);
            btn_XoaCa.Location = new Point(10, 187);
            btn_XoaCa.Name = "btn_XoaCa";
            btn_XoaCa.Size = new Size(224, 49);
            btn_XoaCa.TabIndex = 5;
            btn_XoaCa.Text = "Xóa ca";
            btn_XoaCa.UseVisualStyleBackColor = true;
            btn_XoaCa.Click += btn_XoaCa_Click_1;
            // 
            // FrmXoaCaLamViec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 248);
            Controls.Add(btn_XoaCa);
            Controls.Add(textBox_DienThongTin);
            Controls.Add(comboBox_ChonLoai);
            Controls.Add(comboBox_ChonCa);
            Controls.Add(dateTimePicker_ChonNgay);
            Controls.Add(label1);
            Name = "FrmXoaCaLamViec";
            Text = "Xóa ca làm việc";
            Load += FrmXoaCaLamViec_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePicker_ChonNgay;
        private ComboBox comboBox_ChonCa;
        private ComboBox comboBox_ChonLoai;
        private TextBox textBox_DienThongTin;
        private Button btn_XoaCa;
    }
}
