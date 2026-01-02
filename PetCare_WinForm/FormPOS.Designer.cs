using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetCare_WinForm
{
    partial class FormPOS
    { 
        // này giao diên form
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private Panel leftPanel;
        private Panel rightPanel;
        private Label lblTitle;
        private Panel topControlPanel;
        private ComboBox cboChiNhanh;
        private Label lblChiNhanh;
        private Label lblEmployee;
        private TextBox txtEmployee;
        private Button btnSearchEmployee;
        private Label lblEmployeeInfo;
        private Panel searchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private FlowLayoutPanel pnlProducts;
        private Label lblInvoiceTitle;
        private Panel customerPanel;
        private Label lblCustomer;
        private TextBox txtCustomer;
        private Button btnSearchCustomer;
        private Button btnCreateCustomer;
        private Label lblCustomerInfo;
        private Label lblCustomerPoints;
        private Label lblCustomerRank;
        private Label lblCustomerDiscount;
        private DataGridView dgvInvoice;
        private Panel bottomPanel;
        private Label lblSubTotal;
        private Label lblDiscount;
        private Label lblTotal;
        private ComboBox cboPaymentMethod;
        private Label lblPayment;
        private Button btnCreateInvoice;
        private Button btnClearInvoice;

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
            this.mainLayout = new TableLayoutPanel();
            this.leftPanel = new Panel();
            this.rightPanel = new Panel();
            this.lblTitle = new Label();
            this.topControlPanel = new Panel();
            this.cboChiNhanh = new ComboBox();
            this.lblChiNhanh = new Label();
            this.lblEmployee = new Label();
            this.txtEmployee = new TextBox();
            this.btnSearchEmployee = new Button();
            this.lblEmployeeInfo = new Label();
            this.searchPanel = new Panel();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.pnlProducts = new FlowLayoutPanel();
            this.lblInvoiceTitle = new Label();
            this.customerPanel = new Panel();
            this.lblCustomer = new Label();
            this.txtCustomer = new TextBox();
            this.btnSearchCustomer = new Button();
            this.btnCreateCustomer = new Button();
            this.lblCustomerInfo = new Label();
            this.lblCustomerPoints = new Label();
            this.lblCustomerRank = new Label();
            this.lblCustomerDiscount = new Label();
            this.dgvInvoice = new DataGridView();
            this.bottomPanel = new Panel();
            this.lblSubTotal = new Label();
            this.lblDiscount = new Label();
            this.lblTotal = new Label();
            this.cboPaymentMethod = new ComboBox();
            this.lblPayment = new Label();
            this.btnCreateInvoice = new Button();
            this.btnClearInvoice = new Button();

            this.mainLayout.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.topControlPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.customerPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.SuspendLayout();

            // Main Layout
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.67F));
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.mainLayout.Controls.Add(this.leftPanel, 0, 0);
            this.mainLayout.Controls.Add(this.rightPanel, 1, 0);
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.Padding = new Padding(10);
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Left Panel
            this.leftPanel.BackColor = Color.White;
            this.leftPanel.Controls.Add(this.pnlProducts);
            this.leftPanel.Controls.Add(this.searchPanel);
            this.leftPanel.Controls.Add(this.topControlPanel);
            this.leftPanel.Controls.Add(this.lblTitle);
            this.leftPanel.Dock = DockStyle.Fill;
            this.leftPanel.Padding = new Padding(15);

            // Title
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTitle.Height = 40;
            this.lblTitle.Text = "SẢN PHẨM";
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // Top Control Panel
            this.topControlPanel.Dock = DockStyle.Top;
            this.topControlPanel.Height = 120;
            this.topControlPanel.Padding = new Padding(0, 5, 0, 10);
            this.topControlPanel.BackColor = Color.FromArgb(245, 247, 250);

            this.lblChiNhanh.Location = new Point(10, 10);
            this.lblChiNhanh.Size = new Size(80, 20);
            this.lblChiNhanh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblChiNhanh.Text = "Chi nhánh:";
            this.lblChiNhanh.TextAlign = ContentAlignment.MiddleLeft;

            this.cboChiNhanh.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboChiNhanh.Font = new Font("Segoe UI", 9F);
            this.cboChiNhanh.Location = new Point(95, 10);
            this.cboChiNhanh.Size = new Size(250, 25);
            this.cboChiNhanh.SelectedIndexChanged += new EventHandler(this.CboChiNhanh_SelectedIndexChanged);

            this.lblEmployee.Location = new Point(10, 45);
            this.lblEmployee.Size = new Size(80, 20);
            this.lblEmployee.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblEmployee.Text = "Nhân viên:";
            this.lblEmployee.TextAlign = ContentAlignment.MiddleLeft;

            this.txtEmployee.Font = new Font("Segoe UI", 9F);
            this.txtEmployee.Location = new Point(95, 45);
            this.txtEmployee.Size = new Size(160, 25);
            this.txtEmployee.PlaceholderText = "Mã hoặc tên NV";

            this.btnSearchEmployee.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSearchEmployee.Cursor = Cursors.Hand;
            this.btnSearchEmployee.FlatAppearance.BorderSize = 0;
            this.btnSearchEmployee.FlatStyle = FlatStyle.Flat;
            this.btnSearchEmployee.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnSearchEmployee.ForeColor = Color.White;
            this.btnSearchEmployee.Location = new Point(265, 45);
            this.btnSearchEmployee.Size = new Size(80, 25);
            this.btnSearchEmployee.Text = "Tìm NV";
            this.btnSearchEmployee.Click += new EventHandler(this.BtnSearchEmployee_Click);

            this.lblEmployeeInfo.Location = new Point(95, 75);
            this.lblEmployeeInfo.Size = new Size(450, 20);
            this.lblEmployeeInfo.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblEmployeeInfo.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblEmployeeInfo.Text = "Chưa chọn nhân viên";
            this.lblEmployeeInfo.TextAlign = ContentAlignment.MiddleLeft;

            this.topControlPanel.Controls.Add(this.lblChiNhanh);
            this.topControlPanel.Controls.Add(this.cboChiNhanh);
            this.topControlPanel.Controls.Add(this.lblEmployee);
            this.topControlPanel.Controls.Add(this.txtEmployee);
            this.topControlPanel.Controls.Add(this.btnSearchEmployee);
            this.topControlPanel.Controls.Add(this.lblEmployeeInfo);

            // Search Panel
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Dock = DockStyle.Top;
            this.searchPanel.Height = 50;
            this.searchPanel.Padding = new Padding(0, 10, 0, 10);

            this.txtSearch.Font = new Font("Segoe UI", 11F);
            this.txtSearch.Location = new Point(0, 10);
            this.txtSearch.Size = new Size(500, 30);
            this.txtSearch.PlaceholderText = "Tìm kiếm sản phẩm...";
            this.txtSearch.TextChanged += new EventHandler(this.TxtSearch_TextChanged);

            this.btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSearch.Cursor = Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Location = new Point(510, 10);
            this.btnSearch.Size = new Size(100, 30);
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new EventHandler(this.BtnSearch_Click);

            // Products Panel
            this.pnlProducts.AutoScroll = true;
            this.pnlProducts.BackColor = Color.FromArgb(250, 250, 250);
            this.pnlProducts.Dock = DockStyle.Fill;
            this.pnlProducts.Padding = new Padding(5);

            // Right Panel
            this.rightPanel.BackColor = Color.White;
            this.rightPanel.Controls.Add(this.dgvInvoice);
            this.rightPanel.Controls.Add(this.bottomPanel);
            this.rightPanel.Controls.Add(this.customerPanel);
            this.rightPanel.Controls.Add(this.lblInvoiceTitle);
            this.rightPanel.Dock = DockStyle.Fill;
            this.rightPanel.Padding = new Padding(15);

            // Invoice Title
            this.lblInvoiceTitle.Dock = DockStyle.Top;
            this.lblInvoiceTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblInvoiceTitle.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblInvoiceTitle.Height = 40;
            this.lblInvoiceTitle.Text = "HÓA ĐƠN";
            this.lblInvoiceTitle.TextAlign = ContentAlignment.MiddleLeft;

            // Customer Panel
            this.customerPanel.Dock = DockStyle.Top;
            this.customerPanel.Height = 130;
            this.customerPanel.Padding = new Padding(0, 5, 0, 10);
            this.customerPanel.BackColor = Color.FromArgb(245, 247, 250);

            this.lblCustomer.Location = new Point(10, 10);
            this.lblCustomer.Size = new Size(100, 20);
            this.lblCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCustomer.Text = "Khách hàng:";
            this.lblCustomer.TextAlign = ContentAlignment.MiddleLeft;

            this.txtCustomer.Font = new Font("Segoe UI", 9F);
            this.txtCustomer.Location = new Point(10, 32);
            this.txtCustomer.Size = new Size(180, 25);
            this.txtCustomer.PlaceholderText = "SĐT hoặc tên KH";

            this.btnSearchCustomer.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSearchCustomer.Cursor = Cursors.Hand;
            this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
            this.btnSearchCustomer.FlatStyle = FlatStyle.Flat;
            this.btnSearchCustomer.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnSearchCustomer.ForeColor = Color.White;
            this.btnSearchCustomer.Location = new Point(200, 32);
            this.btnSearchCustomer.Size = new Size(70, 25);
            this.btnSearchCustomer.Text = "Tìm KH";
            this.btnSearchCustomer.Click += new EventHandler(this.BtnSearchCustomer_Click);

            this.btnCreateCustomer.BackColor = Color.FromArgb(46, 204, 113);
            this.btnCreateCustomer.Cursor = Cursors.Hand;
            this.btnCreateCustomer.FlatAppearance.BorderSize = 0;
            this.btnCreateCustomer.FlatStyle = FlatStyle.Flat;
            this.btnCreateCustomer.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnCreateCustomer.ForeColor = Color.White;
            this.btnCreateCustomer.Location = new Point(280, 32);
            this.btnCreateCustomer.Size = new Size(60, 25);
            this.btnCreateCustomer.Text = "Tạo";
            this.btnCreateCustomer.Click += new EventHandler(this.BtnCreateCustomer_Click);

            this.lblCustomerInfo.Location = new Point(10, 62);
            this.lblCustomerInfo.Size = new Size(330, 20);
            this.lblCustomerInfo.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblCustomerInfo.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblCustomerInfo.Text = "Chưa chọn khách hàng";
            this.lblCustomerInfo.TextAlign = ContentAlignment.MiddleLeft;

            this.lblCustomerPoints.Location = new Point(10, 85);
            this.lblCustomerPoints.Size = new Size(100, 18);
            this.lblCustomerPoints.Font = new Font("Segoe UI", 8F);
            this.lblCustomerPoints.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblCustomerPoints.TextAlign = ContentAlignment.MiddleLeft;

            this.lblCustomerRank.Location = new Point(120, 85);
            this.lblCustomerRank.Size = new Size(100, 18);
            this.lblCustomerRank.Font = new Font("Segoe UI", 8F);
            this.lblCustomerRank.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblCustomerRank.TextAlign = ContentAlignment.MiddleLeft;

            this.lblCustomerDiscount.Location = new Point(10, 105);
            this.lblCustomerDiscount.Size = new Size(200, 18);
            this.lblCustomerDiscount.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblCustomerDiscount.ForeColor = Color.FromArgb(230, 126, 34);
            this.lblCustomerDiscount.TextAlign = ContentAlignment.MiddleLeft;

            this.customerPanel.Controls.Add(this.lblCustomer);
            this.customerPanel.Controls.Add(this.txtCustomer);
            this.customerPanel.Controls.Add(this.btnSearchCustomer);
            this.customerPanel.Controls.Add(this.btnCreateCustomer);
            this.customerPanel.Controls.Add(this.lblCustomerInfo);
            this.customerPanel.Controls.Add(this.lblCustomerPoints);
            this.customerPanel.Controls.Add(this.lblCustomerRank);
            this.customerPanel.Controls.Add(this.lblCustomerDiscount);

            // DataGridView
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            this.dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoice.BackgroundColor = Color.White;
            this.dgvInvoice.BorderStyle = BorderStyle.None;
            this.dgvInvoice.Dock = DockStyle.Fill;
            this.dgvInvoice.Font = new Font("Segoe UI", 9F);
            this.dgvInvoice.ReadOnly = true;
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Bottom Panel
            this.bottomPanel.Controls.Add(this.btnCreateInvoice);
            this.bottomPanel.Controls.Add(this.btnClearInvoice);
            this.bottomPanel.Controls.Add(this.lblTotal);
            this.bottomPanel.Controls.Add(this.lblDiscount);
            this.bottomPanel.Controls.Add(this.lblSubTotal);
            this.bottomPanel.Controls.Add(this.cboPaymentMethod);
            this.bottomPanel.Controls.Add(this.lblPayment);
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Height = 210;
            this.bottomPanel.Padding = new Padding(0, 10, 0, 0);

            this.lblPayment.Location = new Point(0, 10);
            this.lblPayment.Size = new Size(150, 25);
            this.lblPayment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblPayment.Text = "Hình thức thanh toán:";
            this.lblPayment.TextAlign = ContentAlignment.MiddleLeft;

            this.cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Font = new Font("Segoe UI", 9F);
            this.cboPaymentMethod.Location = new Point(0, 35);
            this.cboPaymentMethod.Size = new Size(358, 25);

            this.lblSubTotal.Location = new Point(0, 70);
            this.lblSubTotal.Height = 25;
            this.lblSubTotal.Font = new Font("Segoe UI", 10F);
            this.lblSubTotal.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblSubTotal.Text = "Tạm tính: 0 đ";
            this.lblSubTotal.TextAlign = ContentAlignment.MiddleLeft;

            this.lblDiscount.Location = new Point(0, 95);
            this.lblDiscount.Height = 25;
            this.lblDiscount.Font = new Font("Segoe UI", 9F);
            this.lblDiscount.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblDiscount.Text = "Giảm giá (0%): -0 đ";
            this.lblDiscount.TextAlign = ContentAlignment.MiddleLeft;

            this.lblTotal.Location = new Point(0, 120);
            this.lblTotal.Height = 30;
            this.lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblTotal.Text = "TỔNG TIỀN: 0 đ";
            this.lblTotal.TextAlign = ContentAlignment.MiddleLeft;

            int w = bottomPanel.ClientSize.Width;

            lblSubTotal.Size = new Size(w, 25);
            lblDiscount.Size = new Size(w, 25);
            lblTotal.Size = new Size(w, 30);

            this.btnClearInvoice.BackColor = Color.FromArgb(231, 76, 60);
            this.btnClearInvoice.Cursor = Cursors.Hand;
            this.btnClearInvoice.FlatAppearance.BorderSize = 0;
            this.btnClearInvoice.FlatStyle = FlatStyle.Flat;
            this.btnClearInvoice.Font = new Font("Segoe UI", 10F);
            this.btnClearInvoice.ForeColor = Color.White;
            this.btnClearInvoice.Location = new Point(0, 160);
            this.btnClearInvoice.Size = new Size(175, 35);
            this.btnClearInvoice.Text = "XÓA HÓA ĐƠN";
            this.btnClearInvoice.Click += new EventHandler(this.BtnClearInvoice_Click);

            this.btnCreateInvoice.BackColor = Color.FromArgb(46, 204, 113);
            this.btnCreateInvoice.Cursor = Cursors.Hand;
            this.btnCreateInvoice.FlatAppearance.BorderSize = 0;
            this.btnCreateInvoice.FlatStyle = FlatStyle.Flat;
            this.btnCreateInvoice.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnCreateInvoice.ForeColor = Color.White;
            this.btnCreateInvoice.Location = new Point(183, 160);
            this.btnCreateInvoice.Size = new Size(175, 35);
            this.btnCreateInvoice.Text = "TẠO HÓA ĐƠN";
            this.btnCreateInvoice.Click += new EventHandler(this.BtnCreateInvoice_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(1200, 750);
            this.Controls.Add(this.mainLayout);
            this.Name = "FormPOS";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "QT-06: Bán Hàng Lẻ";
            this.Load += new EventHandler(this.FormPOS_Load);

            this.mainLayout.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.topControlPanel.ResumeLayout(false);
            this.topControlPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.customerPanel.ResumeLayout(false);
            this.customerPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.ResumeLayout(false);
        }
    }
}