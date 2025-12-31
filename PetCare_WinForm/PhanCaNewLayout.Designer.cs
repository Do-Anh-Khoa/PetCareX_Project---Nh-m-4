namespace PetCare_WinForm
{
    partial class PhanCaNewLayout
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
            dataGridView_Chinh = new DataGridView();
            btn_ThemCaLam = new Button();
            btn_XoaCaLam = new Button();
            btn_TimKiemCaLam = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Chinh).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_Chinh
            // 
            dataGridView_Chinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Chinh.Location = new Point(1, 12);
            dataGridView_Chinh.Name = "dataGridView_Chinh";
            dataGridView_Chinh.RowHeadersWidth = 51;
            dataGridView_Chinh.Size = new Size(798, 333);
            dataGridView_Chinh.TabIndex = 0;
            // 
            // btn_ThemCaLam
            // 
            btn_ThemCaLam.Font = new Font("Segoe UI", 16F);
            btn_ThemCaLam.Location = new Point(273, 368);
            btn_ThemCaLam.Name = "btn_ThemCaLam";
            btn_ThemCaLam.Size = new Size(243, 55);
            btn_ThemCaLam.TabIndex = 2;
            btn_ThemCaLam.Text = "Thêm ca làm";
            btn_ThemCaLam.UseVisualStyleBackColor = true;
            btn_ThemCaLam.Click += btn_ThemCaLam_Click;
            // 
            // btn_XoaCaLam
            // 
            btn_XoaCaLam.Font = new Font("Segoe UI", 16F);
            btn_XoaCaLam.Location = new Point(534, 368);
            btn_XoaCaLam.Name = "btn_XoaCaLam";
            btn_XoaCaLam.Size = new Size(243, 55);
            btn_XoaCaLam.TabIndex = 3;
            btn_XoaCaLam.Text = "Xóa ca làm";
            btn_XoaCaLam.UseVisualStyleBackColor = true;
            btn_XoaCaLam.Click += btn_XoaCaLam_Click;
            // 
            // btn_TimKiemCaLam
            // 
            btn_TimKiemCaLam.Font = new Font("Segoe UI", 16F);
            btn_TimKiemCaLam.Location = new Point(12, 368);
            btn_TimKiemCaLam.Name = "btn_TimKiemCaLam";
            btn_TimKiemCaLam.Size = new Size(243, 55);
            btn_TimKiemCaLam.TabIndex = 4;
            btn_TimKiemCaLam.Text = "Tìm kiếm ca làm";
            btn_TimKiemCaLam.UseVisualStyleBackColor = true;
            btn_TimKiemCaLam.Click += btn_TimKiemCaLam_Click;
            // 
            // PhanCaNewLayout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_TimKiemCaLam);
            Controls.Add(btn_XoaCaLam);
            Controls.Add(btn_ThemCaLam);
            Controls.Add(dataGridView_Chinh);
            Name = "PhanCaNewLayout";
            Text = "Phân ca";
            Load += PhanCaNewLayout_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_Chinh).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView_Chinh;
        private Button btn_ThemCaLam;
        private Button btn_XoaCaLam;
        private Button btn_TimKiemCaLam;
    }
}