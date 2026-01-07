// namespace PetCare_WinForm
// {
//     partial class FrmLogin
//     {
//         /// <summary>
//         /// Required designer variable.
//         /// </summary>
//         private System.ComponentModel.IContainer components = null;

//         /// <summary>
//         /// Clean up any resources being used.
//         /// </summary>
//         /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//         protected override void Dispose(bool disposing)
//         {
//             if (disposing && (components != null))
//             {
//                 components.Dispose();
//             }
//             base.Dispose(disposing);
//         }

//         #region Windows Form Designer generated code

//         /// <summary>
//         /// Required method for Designer support - do not modify
//         /// the contents of this method with the code editor.
//         /// </summary>
//         private void InitializeComponent()
//         {
//             this.label1 = new System.Windows.Forms.Label();
//             this.label2 = new System.Windows.Forms.Label();
//             this.txtUserName = new System.Windows.Forms.TextBox();
//             this.txtPassword = new System.Windows.Forms.TextBox();
//             this.btnLogin = new System.Windows.Forms.Button();
//             this.SuspendLayout();
//             // 
//             // label1
//             // 
//             this.label1.AutoSize = true;
//             this.label1.Location = new System.Drawing.Point(50, 50);
//             this.label1.Name = "label1";
//             this.label1.Size = new System.Drawing.Size(110, 20);
//             this.label1.TabIndex = 0;
//             this.label1.Text = "Tên đăng nhập:";
//             // 
//             // label2
//             // 
//             this.label2.AutoSize = true;
//             this.label2.Location = new System.Drawing.Point(50, 100);
//             this.label2.Name = "label2";
//             this.label2.Size = new System.Drawing.Size(73, 20);
//             this.label2.TabIndex = 1;
//             this.label2.Text = "Mật khẩu:";
//             // 
//             // txtUserName
//             // 
//             this.txtUserName.Location = new System.Drawing.Point(180, 47);
//             this.txtUserName.Name = "txtUserName";
//             this.txtUserName.Size = new System.Drawing.Size(200, 27);
//             this.txtUserName.TabIndex = 2;
//             // 
//             // txtPassword
//             // 
//             this.txtPassword.Location = new System.Drawing.Point(180, 97);
//             this.txtPassword.Name = "txtPassword";
//             this.txtPassword.PasswordChar = '*';
//             this.txtPassword.Size = new System.Drawing.Size(200, 27);
//             this.txtPassword.TabIndex = 3;
//             // 
//             // btnLogin
//             // 
//             this.btnLogin.Location = new System.Drawing.Point(180, 150);
//             this.btnLogin.Name = "btnLogin";
//             this.btnLogin.Size = new System.Drawing.Size(120, 40);
//             this.btnLogin.TabIndex = 4;
//             this.btnLogin.Text = "Đăng Nhập";
//             this.btnLogin.UseVisualStyleBackColor = true;
//             this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
//             // 
//             // FrmLogin
//             // 
//             this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
//             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//             this.ClientSize = new System.Drawing.Size(450, 250);
//             this.Controls.Add(this.btnLogin);
//             this.Controls.Add(this.txtPassword);
//             this.Controls.Add(this.txtUserName);
//             this.Controls.Add(this.label2);
//             this.Controls.Add(this.label1);
//             this.Name = "FrmLogin";
//             this.Text = "Đăng Nhập Hệ Thống";
//             this.ResumeLayout(false);
//             this.PerformLayout();
//         }

//         #endregion

//         private System.Windows.Forms.Label label1;
//         private System.Windows.Forms.Label label2;
//         private System.Windows.Forms.TextBox txtUserName;
//         private System.Windows.Forms.TextBox txtPassword;
//         private System.Windows.Forms.Button btnLogin;
//     }
// }


namespace PetCare_WinForm
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

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
            this.pnlLoginBox = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlLoginBox.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // pnlLoginBox (Khung đăng nhập màu trắng ở giữa)
            // 
            this.pnlLoginBox.BackColor = System.Drawing.Color.White;
            this.pnlLoginBox.Controls.Add(this.lblTitle);
            this.pnlLoginBox.Controls.Add(this.label1);
            this.pnlLoginBox.Controls.Add(this.txtUserName);
            this.pnlLoginBox.Controls.Add(this.label2);
            this.pnlLoginBox.Controls.Add(this.txtPassword);
            this.pnlLoginBox.Controls.Add(this.btnLogin);
            this.pnlLoginBox.Location = new System.Drawing.Point(362, 200); // Vị trí tạm, sẽ được code căn giữa lại
            this.pnlLoginBox.Name = "pnlLoginBox";
            this.pnlLoginBox.Size = new System.Drawing.Size(400, 450); // Kích thước khung nhập liệu
            this.pnlLoginBox.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 100);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PetCare Login";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(40, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên đăng nhập";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserName.Location = new System.Drawing.Point(40, 140);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(320, 36);
            this.txtUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(40, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(40, 230);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(320, 36);
            this.txtPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(40, 320);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(320, 55);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // Màu nền xanh nhẹ (giống màu bầu trời) để làm nổi bật khung trắng
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241))))); 
            this.ClientSize = new System.Drawing.Size(1125, 800); // Kích thước giống hệt FrmHome
            this.Controls.Add(this.pnlLoginBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable; // Cho phép có viền và nút phóng to thu nhỏ chuẩn
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập Hệ Thống - PetCare System";
            this.Resize += new System.EventHandler(this.FrmLogin_Resize); // Sự kiện để căn giữa khi chỉnh size
            this.pnlLoginBox.ResumeLayout(false);
            this.pnlLoginBox.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLoginBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}