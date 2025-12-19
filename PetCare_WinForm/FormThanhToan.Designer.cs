using System;
using System.Drawing;
using System.Windows.Forms;
namespace PetCare_WinForm
{
    partial class FormThanhToan
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // Form properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Text = "Thanh Toán Hóa Đơn";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 242, 245);

            // Title Label
            Label lblTitle = new Label();
            lblTitle.Text = "THANH TOÁN HÓA ĐƠN";
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 20);
            this.Controls.Add(lblTitle);

            // Panel chứa ô tìm kiếm
            Panel searchPanel = new Panel();
            searchPanel.Location = new Point(30, 80);
            searchPanel.Size = new Size(1140, 50);
            searchPanel.BackColor = Color.Transparent;

            // Label tìm kiếm
            Label lblSearchCustomer = new Label();
            lblSearchCustomer.Text = "Tìm theo khách hàng:";
            lblSearchCustomer.Location = new Point(0, 0);
            lblSearchCustomer.Size = new Size(150, 20);
            lblSearchCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            searchPanel.Controls.Add(lblSearchCustomer);

            // TextBox tìm kiếm
            txtSearchCustomer = new TextBox();
            txtSearchCustomer.Location = new Point(0, 25);
            txtSearchCustomer.Size = new Size(400, 30);
            txtSearchCustomer.Font = new Font("Segoe UI", 11F);
            txtSearchCustomer.PlaceholderText = "Nhập tên hoặc sdt khách hàng...";
            txtSearchCustomer.KeyPress += TxtSearchCustomer_KeyPress;
            searchPanel.Controls.Add(txtSearchCustomer);

            // Nút tìm kiếm
            btnSearch = new Button();
            btnSearch.Text = "TÌM KIẾM";
            btnSearch.Location = new Point(410, 25);
            btnSearch.Size = new Size(120, 30);
            btnSearch.BackColor = Color.FromArgb(41, 128, 185);
            btnSearch.ForeColor = Color.White;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += BtnSearch_Click;
            searchPanel.Controls.Add(btnSearch);

            this.Controls.Add(searchPanel);

            // FlowLayoutPanel để hiển thị các hóa đơn
            flowPanelInvoices = new FlowLayoutPanel();
            flowPanelInvoices.Location = new Point(30, 150);
            flowPanelInvoices.Size = new Size(1140, 600);
            flowPanelInvoices.AutoScroll = true;
            flowPanelInvoices.BackColor = Color.White;
            flowPanelInvoices.BorderStyle = BorderStyle.FixedSingle;
            flowPanelInvoices.Padding = new Padding(10);
            this.Controls.Add(flowPanelInvoices);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}