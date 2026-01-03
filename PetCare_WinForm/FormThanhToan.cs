using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PetCare_Web.Models;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Data;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

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

        // Danh sách sản phẩm đã mua
        public List<SanPhamMuaViewModel> SanPhamsMua { get; set; }
    }

    public class SanPhamMuaViewModel
    {
        public string TenSp { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
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
            ShowNoDataMessage();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void TxtSearchCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PerformSearch();
            }
        }

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

        // Sử dụng SP: sp_TimKiemHoaDonChuaThanhToan
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
                List<HoaDonViewModel> invoices = new List<HoaDonViewModel>();

                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_TimKiemHoaDonChuaThanhToan";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CustomerSearch", customerSearch));

                    dbContext.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var invoice = new HoaDonViewModel
                            {
                                MaHd = reader["MaHD"].ToString(),
                                NgayLap = reader["NgayLap"] != DBNull.Value
                                    ? DateOnly.FromDateTime(Convert.ToDateTime(reader["NgayLap"]))
                                    : (DateOnly?)null,
                                TrangThai = reader["TrangThai"].ToString(),
                                TongTien = reader["TongTien"] != DBNull.Value
                                    ? Convert.ToDecimal(reader["TongTien"])
                                    : (decimal?)null,
                                KhuyenMai = reader["KhuyenMai"]?.ToString(),
                                HinhThucThanhToan = reader["HinhThucThanhToan"]?.ToString()
                            };

                            // Lấy thông tin khách hàng
                            LoadKhachHangInfo(invoice, reader["MaKH"].ToString());

                            // Lấy thông tin nhân viên
                            LoadNhanVienInfo(invoice, reader["MaNV"].ToString());

                            // Lấy thông tin chi nhánh
                            LoadChiNhanhInfo(invoice, reader["MaCN"].ToString());

                            // Lấy danh sách sản phẩm
                            invoice.SanPhamsMua = LoadSanPhamsByHoaDon(invoice.MaHd);

                            invoices.Add(invoice);
                        }
                    }

                    dbContext.Database.CloseConnection();
                }

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
                    $"Lỗi khi tìm kiếm: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ShowNoDataMessage();
            }
            finally
            {
                if (dbContext.Database.GetDbConnection().State == ConnectionState.Open)
                {
                    dbContext.Database.CloseConnection();
                }
            }
        }

        // Sử dụng SP: sp_LayThongTinKhachHang
        private void LoadKhachHangInfo(HoaDonViewModel invoice, string maKh)
        {
            try
            {
                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_LayThongTinKhachHang";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MaKH", maKh));

                    if (dbContext.Database.GetDbConnection().State != ConnectionState.Open)
                        dbContext.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            invoice.TenKh = reader["HoTen"]?.ToString() ?? "N/A";
                            invoice.SoDt = reader["SoDT"]?.ToString() ?? "N/A";
                            invoice.CapHoiVien = reader["CapHoiVien"]?.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi load khách hàng: {ex.Message}");
                invoice.TenKh = "N/A";
                invoice.SoDt = "N/A";
            }
        }

        // Sử dụng SP: sp_LayThongTinNhanVien
        private void LoadNhanVienInfo(HoaDonViewModel invoice, string maNv)
        {
            try
            {
                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_LayThongTinNhanVien";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MaNV", maNv));

                    if (dbContext.Database.GetDbConnection().State != ConnectionState.Open)
                        dbContext.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            invoice.TenNv = reader["HoTen"]?.ToString() ?? "N/A";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi load nhân viên: {ex.Message}");
                invoice.TenNv = "N/A";
            }
        }

        // Sử dụng SP: sp_LayThongTinChiNhanh
        private void LoadChiNhanhInfo(HoaDonViewModel invoice, string maCn)
        {
            try
            {
                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_LayThongTinChiNhanh";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MaCN", maCn));

                    if (dbContext.Database.GetDbConnection().State != ConnectionState.Open)
                        dbContext.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            invoice.TenCn = reader["TenChiNhanh"]?.ToString() ?? "N/A";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi load chi nhánh: {ex.Message}");
                invoice.TenCn = "N/A";
            }
        }

        // Sử dụng SP: sp_LayDanhSachSanPhamTheoHoaDon
        private List<SanPhamMuaViewModel> LoadSanPhamsByHoaDon(string maHd)
        {
            try
            {
                List<SanPhamMuaViewModel> sanPhams = new List<SanPhamMuaViewModel>();

                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_LayDanhSachSanPhamTheoHoaDon";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MaHD", maHd));

                    if (dbContext.Database.GetDbConnection().State != ConnectionState.Open)
                        dbContext.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sanPhams.Add(new SanPhamMuaViewModel
                            {
                                TenSp = reader["TenSP"]?.ToString() ?? "N/A",
                                SoLuong = reader["SoLuong"] != DBNull.Value
                                    ? Convert.ToInt32(reader["SoLuong"])
                                    : 0,
                                DonGia = reader["DonGia"] != DBNull.Value
                                    ? Convert.ToDouble(reader["DonGia"])
                                    : 0,
                                ThanhTien = reader["ThanhTien"] != DBNull.Value
                                    ? Convert.ToDouble(reader["ThanhTien"])
                                    : 0
                            });
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine($"Kết quả: {sanPhams.Count} sản phẩm cho hóa đơn {maHd}");
                return sanPhams;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi load sản phẩm: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                return new List<SanPhamMuaViewModel>();
            }
        }

        private void ShowNoDataMessage()
        {
            flowPanelInvoices.Controls.Clear();

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
            // Cố định chiều cao cho tất cả các card
            int cardHeight = 350;

            Panel card = new Panel();
            card.Size = new Size(320, cardHeight);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(10);
            card.Padding = new Padding(15);

            // Tạo nội dung hóa đơn
            RichTextBox rtbInvoice = new RichTextBox();
            rtbInvoice.Location = new Point(15, 15);
            rtbInvoice.Size = new Size(290, cardHeight - 70);
            rtbInvoice.Font = new Font("Courier New", 8.5F);
            rtbInvoice.ReadOnly = true;
            rtbInvoice.BorderStyle = BorderStyle.None;
            rtbInvoice.BackColor = Color.White;
            rtbInvoice.WordWrap = true;
            rtbInvoice.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbInvoice.Text = GenerateInvoiceText(invoice);

            card.Controls.Add(rtbInvoice);

            // Nút thanh toán
            Button btnPay = new Button();
            btnPay.Text = "THANH TOÁN";
            btnPay.Location = new Point(15, cardHeight - 50);
            btnPay.Size = new Size(290, 35);
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
            string text = "═════════════════════════════════════════\n";
            text += "          HÓA ĐƠN BÁN HÀNG\n";
            text += "═════════════════════════════════════════\n";
            text += $"Mã HĐ: {invoice.MaHd}\n";
            text += $"Ngày: {invoice.NgayLap?.ToString("dd/MM/yyyy") ?? "N/A"}\n";
            text += $"Chi nhánh: {invoice.TenCn ?? "N/A"}\n";
            text += $"Nhân viên: {invoice.TenNv ?? "N/A"}\n\n";

            text += $"Khách hàng: {invoice.TenKh}\n";
            text += $"SĐT: {invoice.SoDt}\n";
            text += $"Hạng: {invoice.CapHoiVien ?? "Thường"}\n";

            text += "─────────────────────────────────────────\n";

            // Hiển thị danh sách sản phẩm
            if (invoice.SanPhamsMua != null && invoice.SanPhamsMua.Count > 0)
            {
                text += "       DANH SÁCH SẢN PHẨM\n";
                text += "─────────────────────────────────────────\n";

                foreach (var sp in invoice.SanPhamsMua)
                {
                    // Rút gọn tên sản phẩm nếu quá dài (giới hạn 28 ký tự)
                    string tenSp = sp.TenSp.Length > 28 ? sp.TenSp.Substring(0, 25) + "..." : sp.TenSp;
                    text += $"{tenSp}\n";
                    text += $"  {sp.SoLuong} x {sp.DonGia:N0}đ = {sp.ThanhTien:N0}đ\n";
                }

                text += "─────────────────────────────────────────\n";
            }

            if (!string.IsNullOrEmpty(invoice.KhuyenMai))
            {
                text += $"Khuyến mãi: {invoice.KhuyenMai}%\n";
            }

            text += $"\nTỔNG CỘNG: {invoice.TongTien:N0}đ\n";
            text += $"Thanh toán: {invoice.HinhThucThanhToan ?? "Chưa chọn"}\n";
            text += $"Trạng thái: Chưa thanh toán\n";
            text += "═════════════════════════════════════════\n";

            return text;
        }

        // Sử dụng SP: sp_CapNhatTrangThaiThanhToan
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
                    using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "sp_CapNhatTrangThaiThanhToan";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@MaHD", invoice.MaHd));

                        dbContext.Database.OpenConnection();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int resultCode = Convert.ToInt32(reader["Result"]);
                                string message = reader["Message"].ToString();

                                if (resultCode == 1)
                                {
                                    ShowSuccessMessage(invoice);
                                    LoadUnpaidInvoices(txtSearchCustomer.Text);
                                }
                                else
                                {
                                    MessageBox.Show(message, "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                        dbContext.Database.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (dbContext.Database.GetDbConnection().State == ConnectionState.Open)
                    {
                        dbContext.Database.CloseConnection();
                    }
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
            message += $"   Tên khách hàng:          {invoice.TenKh ?? "N/A"}\n\n";
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