using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PetCare_Web.Models;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Data;

namespace PetCare_WinForm
{
    public class HoaDonViewModel
    {
        public string MaHd { get; set; }
        public DateOnly? NgayLap { get; set; }
        public string TrangThai { get; set; }
        public decimal? TongTien { get; set; }

        public string TenKh { get; set; }
        public string SoDt { get; set; }
        public string CapHoiVien { get; set; }

        public string TenNv { get; set; }
        public string TenCn { get; set; }

        public string KhuyenMai { get; set; }
        public string HinhThucThanhToan { get; set; }
    }


    public partial class FormThanhToan : Form
    {
        private TextBox txtSearchCustomer;
        private FlowLayoutPanel flowPanelInvoices;
        private PetCareContext dbContext;

        public FormThanhToan()
        {
            InitializeComponent();
            dbContext = new PetCareContext();
            ShowNoDataMessage(); // Hiển thị thông báo mặc định khi mở form
        }

        // Event handler cho nút tìm kiếm
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        // Event handler cho phím Enter trong TextBox
        private void TxtSearchCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PerformSearch();
            }
        }

        // Hàm thực hiện tìm kiếm
        private void PerformSearch()
        {
            string customerSearch = txtSearchCustomer.Text.Trim();

            if (string.IsNullOrEmpty(customerSearch))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên hoặc số điện thoại khách hàng để tìm kiếm!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            LoadUnpaidInvoices(customerSearch);
        }

        private void LoadUnpaidInvoices(string customerSearch = "")
        {
            flowPanelInvoices.Controls.Clear();

            if (string.IsNullOrEmpty(customerSearch))
            {
                ShowNoDataMessage();
                return;
            }

            try
            {
                var query = dbContext.HoaDons
                    .AsNoTracking()
                    .Where(h => h.MaKhNavigation.SoDt.Contains(customerSearch) ||
                                h.MaKhNavigation.HoTen.Contains(customerSearch))
                    .Where(h => h.TrangThai == "ChuaThanhToan");

                List<HoaDonViewModel> invoices = query
                    .Select(h => new HoaDonViewModel
                    {
                        MaHd = h.MaHd,
                        NgayLap = h.NgayLap,
                        TrangThai = h.TrangThai,
                        TongTien = h.TongTien,

                        TenKh = h.MaKhNavigation.HoTen,
                        SoDt = h.MaKhNavigation.SoDt,
                        CapHoiVien = h.MaKhNavigation.CapHoiVien,

                        TenNv = h.MaNvNavigation.HoTen,
                        TenCn = h.MaCnNavigation.TenChiNhanh,

                        KhuyenMai = h.KhuyenMai,
                        HinhThucThanhToan = h.HinhThucThanhToan
                    })
                    .ToList();

                if (invoices.Count == 0)
                {
                    ShowNoDataMessage();
                    return;
                }

                foreach (HoaDonViewModel invoice in invoices)
                {
                    Panel card = CreateInvoiceCard(invoice);
                    flowPanelInvoices.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tìm kiếm: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ShowNoDataMessage();
            }
        }


        private void ShowNoDataMessage()
        {
            Label lblNoData = new Label();
            lblNoData.Text = "Không có hóa đơn chưa thanh toán";
            lblNoData.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblNoData.ForeColor = Color.Gray;
            lblNoData.AutoSize = true;
            lblNoData.Padding = new Padding(20);
            flowPanelInvoices.Controls.Add(lblNoData);
        }

        private Panel CreateInvoiceCard(HoaDonViewModel invoice)
        {
            Panel card = new Panel();
            card.Size = new Size(300, 300);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(10);
            card.Padding = new Padding(15);

            // Tạo nội dung hóa đơn
            RichTextBox rtbInvoice = new RichTextBox();
            rtbInvoice.Location = new Point(15, 15);
            rtbInvoice.Size = new Size(300, 230);
            rtbInvoice.Font = new Font("Courier New", 9F);
            rtbInvoice.ReadOnly = true;
            rtbInvoice.BorderStyle = BorderStyle.None;
            rtbInvoice.BackColor = Color.White;
            rtbInvoice.Text = GenerateInvoiceText(invoice);

            card.Controls.Add(rtbInvoice);

            // Nút thanh toán
            Button btnPay = new Button();
            btnPay.Text = "THANH TOÁN";
            btnPay.Location = new Point(15, 245);
            btnPay.Size = new Size(280, 35);
            btnPay.BackColor = Color.FromArgb(46, 204, 113);
            btnPay.ForeColor = Color.White;
            btnPay.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.Cursor = Cursors.Hand;
            btnPay.FlatAppearance.BorderSize = 0;
            btnPay.Click += (s, e) => ProcessPayment(invoice);
            card.Controls.Add(btnPay);

            return card;
        }

        private string GenerateInvoiceText(HoaDonViewModel invoice)
        {
            string text = "═══════════════════════════════════════\n";
            text += "           HÓA ĐƠN BÁN HÀNG\n";
            text += "═══════════════════════════════════════\n";
            text += $"Mã HĐ: {invoice.MaHd}\n";
            text += $"Ngày: {invoice.NgayLap?.ToString("dd/MM/yyyy") ?? "N/A"}\n";
            text += $"Chi nhánh: {invoice.TenCn ?? "N/A"}\n";
            text += $"Nhân viên: {invoice.TenNv ?? "N/A"}\n";

            text += $"Khách hàng: {invoice.TenKh}\n";
            text += $"SĐT: {invoice.SoDt}\n";
            text += $"Hạng: {invoice.CapHoiVien ?? "Thường"}\n";

            text += "───────────────────────────────────────\n\n";

            if (!string.IsNullOrEmpty(invoice.KhuyenMai))
            {
                text += $"Khuyến mãi: {invoice.KhuyenMai}\n";
            }

            text += $"TỔNG CỘNG: {invoice.TongTien:N0}đ\n";
            text += $"Thanh toán: {invoice.HinhThucThanhToan ?? "Chưa chọn"}\n";
            text += $"Trạng thái: Chưa thanh toán\n";
            text += "═══════════════════════════════════════\n";

            return text;
        }

        private void ProcessPayment(HoaDonViewModel invoice)
        {
            DialogResult result = MessageBox.Show(
                $"Xác nhận thanh toán hóa đơn {invoice.MaHd}?\nTổng tiền: {invoice.TongTien:N0}đ",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var hoaDon = dbContext.HoaDons.FirstOrDefault(h => h.MaHd == invoice.MaHd);

                    if (hoaDon == null)
                    {
                        MessageBox.Show(
                            "Không tìm thấy hóa đơn!",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    hoaDon.TrangThai = "DaThanhToan";
                    dbContext.SaveChanges();

                    ShowSuccessMessage(invoice);
                    LoadUnpaidInvoices(txtSearchCustomer.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Lỗi khi thanh toán: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void ShowSuccessMessage(HoaDonViewModel invoice)
        {
            string message = "══════════════════════════════════════════════════\n";
            message += "       HÓA ĐƠN THANH TOÁN THÀNH CÔNG\n";
            message += "══════════════════════════════════════════════════\n\n";
            message += $"   Số hóa đơn:              {invoice.MaHd}\n\n";
            message += $"   Ngày thanh toán:         {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n";
            message += $"   Tên khách hàng:           {invoice.TenKh ?? "N/A"}\n\n";
            message += $"   Số tiền:                 {invoice.TongTien:N0}đ\n\n";
            message += $"   Phương thức thanh toán:  {invoice.HinhThucThanhToan ?? "Chưa chọn"}\n\n";
            message += "══════════════════════════════════════════════════\n\n";
            message += "                  Cảm ơn quý khách!\n";
            message += "           Hẹn gặp lại quý khách lần sau!";

            MessageBox.Show(
                message,
                "Thanh toán thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}