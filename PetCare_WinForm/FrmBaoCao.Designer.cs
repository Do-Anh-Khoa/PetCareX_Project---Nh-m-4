

using System.Drawing;
using System.Windows.Forms;

namespace PetCare_WinForm
{
    partial class FrmBaoCao : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;

        // --- CÁC CONTROL CHÍNH ---
        private TabControl tabControlBaoCao;
        private TabPage tabTongHop;
        private TabPage tabBacSi;
        private TabPage tabSanPham;

        // --- CÁC GRIDVIEW ---
        private DataGridView dgvDoanhThu; // Tab 1: Trên
        private DataGridView dgvLuotKham; // Tab 1: Dưới
        private DataGridView dgvBacSi;    // Tab 2
        private DataGridView dgvSanPham;  // Tab 3

        // --- BỘ LỌC VÀ NÚT ---
        private Panel panelTop;
        private Label lblChonNam;
        private ComboBox cboNam;
        private Label lblChonCN;
        private ComboBox cboChiNhanh;
        private Button btnXemBaoCao;

        // --- LABEL TỔNG KẾT (Chỉ dùng cho Tab Tổng hợp) ---
        private Label lblTongDoanhThu;
        private Label lblTongLuotKham;

        // --- LAYOUT ---
        private SplitContainer splitContainerTongHop;
        private GroupBox grpDoanhThu;
        private GroupBox grpLuotKham;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Hệ Thống Báo Cáo Quản Trị";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            // ========================================================
            // 1. PANEL TOP (BỘ LỌC)
            // ========================================================
            panelTop = new Panel();
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 100;
            panelTop.BackColor = Color.WhiteSmoke;

            // Bộ lọc Năm
            lblChonNam = new Label { Text = "Chọn Năm:", AutoSize = true, Location = new Point(20, 20) };
            cboNam = new ComboBox { Location = new Point(100, 17), Size = new Size(100, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            
            // Bộ lọc Chi Nhánh
            lblChonCN = new Label { Text = "Chi Nhánh:", AutoSize = true, Location = new Point(220, 20) };
            cboChiNhanh = new ComboBox { Location = new Point(300, 17), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            // Nút Lọc
            btnXemBaoCao = new Button 
            { 
                Text = "Lọc Dữ Liệu", 
                Size = new Size(120, 30), 
                Location = new Point(530, 15), 
                BackColor = Color.DodgerBlue, 
                ForeColor = Color.White 
            };
            btnXemBaoCao.Click += new System.EventHandler(this.BtnXemBaoCao_Click);

            // Label Tổng kết
            lblTongDoanhThu = new Label { Text = "Tổng Doanh Thu: 0 VNĐ", AutoSize = true, Location = new Point(20, 60), Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.DarkGreen };
            lblTongLuotKham = new Label { Text = "Tổng Lượt Khám: 0", AutoSize = true, Location = new Point(450, 60), Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.DarkRed };

            panelTop.Controls.Add(lblChonNam);
            panelTop.Controls.Add(cboNam);
            panelTop.Controls.Add(lblChonCN);
            panelTop.Controls.Add(cboChiNhanh);
            panelTop.Controls.Add(btnXemBaoCao);
            panelTop.Controls.Add(lblTongDoanhThu);
            panelTop.Controls.Add(lblTongLuotKham);

            // ========================================================
            // 2. TAB CONTROL (CHỨA CÁC MÀN HÌNH BÁO CÁO)
            // ========================================================
            tabControlBaoCao = new TabControl();
            tabControlBaoCao.Dock = DockStyle.Fill;

            // --- TAB 1: TỔNG HỢP ---
            tabTongHop = new TabPage("Tổng Hợp Doanh Thu & Lượt Khám");
            
            splitContainerTongHop = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 50 };

            
            // Bảng Doanh Thu
            grpDoanhThu = new GroupBox { Text = "Chi Tiết Doanh Thu", Dock = DockStyle.Fill };
            dgvDoanhThu = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            grpDoanhThu.Controls.Add(dgvDoanhThu);
            splitContainerTongHop.Panel1.Controls.Add(grpDoanhThu);

            // Bảng Lượt Khám
            grpLuotKham = new GroupBox { Text = "Chi Tiết Lượt Khám", Dock = DockStyle.Fill };
            dgvLuotKham = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            grpLuotKham.Controls.Add(dgvLuotKham);
            splitContainerTongHop.Panel2.Controls.Add(grpLuotKham);

            tabTongHop.Controls.Add(splitContainerTongHop);

            // --- TAB 2: BÁC SĨ ---
            tabBacSi = new TabPage("Hiệu Suất Bác Sĩ");
            dgvBacSi = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabBacSi.Controls.Add(dgvBacSi);

            // --- TAB 3: SẢN PHẨM ---
            tabSanPham = new TabPage("Doanh Thu Sản Phẩm");
            dgvSanPham = new DataGridView { Dock = DockStyle.Fill, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabSanPham.Controls.Add(dgvSanPham);
             

             
            // Add các tab vào control
            tabControlBaoCao.Controls.Add(tabTongHop);
            tabControlBaoCao.Controls.Add(tabBacSi);
            tabControlBaoCao.Controls.Add(tabSanPham);

            // ========================================================
            // 3. ADD VÀO FORM
            // ========================================================
            this.Controls.Add(tabControlBaoCao); // Tab nằm dưới
            this.Controls.Add(panelTop);         // Panel nằm trên
        }
    }
}