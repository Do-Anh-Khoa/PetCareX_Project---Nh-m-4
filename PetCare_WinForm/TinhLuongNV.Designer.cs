using System.Windows.Forms;

namespace PetCare_WinForm
{
    partial class TinhLuongNV
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
            buttonXemLuong = new Button();
            dataGridView1 = new DataGridView();
            dateTimePicker_ChonThangNam = new DateTimePicker();
            buttonTinhLuong = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonXemLuong
            // 
            buttonXemLuong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonXemLuong.Location = new Point(250, 95);
            buttonXemLuong.Name = "buttonXemLuong";
            buttonXemLuong.Size = new Size(139, 47);
            buttonXemLuong.TabIndex = 3;
            buttonXemLuong.Text = "Xem lương";
            buttonXemLuong.UseVisualStyleBackColor = true;
            buttonXemLuong.Click += buttonXemLuong_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 166);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 284);
            dataGridView1.TabIndex = 4;
            // 
            // dateTimePicker_ChonThangNam
            // 
            dateTimePicker_ChonThangNam.CalendarFont = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker_ChonThangNam.CustomFormat = "MM/yyyy";
            dateTimePicker_ChonThangNam.Font = new Font("Segoe UI", 16F);
            dateTimePicker_ChonThangNam.Format = DateTimePickerFormat.Custom;
            dateTimePicker_ChonThangNam.Location = new Point(250, 35);
            dateTimePicker_ChonThangNam.Name = "dateTimePicker_ChonThangNam";
            dateTimePicker_ChonThangNam.ShowUpDown = true;
            dateTimePicker_ChonThangNam.Size = new Size(310, 43);
            dateTimePicker_ChonThangNam.TabIndex = 5;
            // 
            // buttonTinhLuong
            // 
            buttonTinhLuong.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonTinhLuong.Location = new Point(419, 95);
            buttonTinhLuong.Name = "buttonTinhLuong";
            buttonTinhLuong.Size = new Size(141, 47);
            buttonTinhLuong.TabIndex = 6;
            buttonTinhLuong.Text = "Tính lương";
            buttonTinhLuong.UseVisualStyleBackColor = true;
            buttonTinhLuong.Click += buttonTinhLuong_Click;
            // 
            // TinhLuongNV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonTinhLuong);
            Controls.Add(dateTimePicker_ChonThangNam);
            Controls.Add(dataGridView1);
            Controls.Add(buttonXemLuong);
            Name = "TinhLuongNV";
            Text = "Quản lý lương";
            Load += TinhLuongNV_Load;
            Resize += TinhLuongNV_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonXemLuong;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker_ChonThangNam;
        private Button buttonTinhLuong;
    }
}