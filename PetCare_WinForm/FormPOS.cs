using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PetCare_Web.Models;
using PetCare_Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace PetCare_WinForm
{
    public class ProductViewModel
    {
        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public double GiaBan { get; set; }
        public string LoaiSp { get; set; }
        public int TonKho { get; set; }
        public string MaCn { get; set; }
    }

    public partial class FormPOS : Form
    {
        private PetCareContext dbContext;
        private DataTable invoiceTable;
        private List<ProductViewModel> allProducts;
        private KhachHang selectedCustomer;
        private string selectedEmployeeId;
        private string selectedEmployeeName;
        private string currentMaCn;
        private decimal discountPercent = 0;
        private string currentInvoiceId;

        public FormPOS()
        {
            InitializeComponent();
            dbContext = new PetCareContext();
            InitializeInvoiceTable();
            allProducts = new List<ProductViewModel>();
        }

        private void InitializeInvoiceTable()
        {
            invoiceTable = new DataTable();
            invoiceTable.Columns.Add("MaSP", typeof(string));
            invoiceTable.Columns.Add("TenSP", typeof(string));
            invoiceTable.Columns.Add("SoLuong", typeof(int));
            invoiceTable.Columns.Add("DonGia", typeof(decimal));
            invoiceTable.Columns.Add("ThanhTien", typeof(decimal));
            invoiceTable.Columns.Add("TonKho", typeof(int));
        }

        private void ConfigureDataGridView()
        {
            dgvInvoice.DataSource = invoiceTable;

            if (dgvInvoice.Columns["MaSP"] != null)
            {
                dgvInvoice.Columns["MaSP"].HeaderText = "Mã SP";
                dgvInvoice.Columns["MaSP"].Width = 80;
            }

            if (dgvInvoice.Columns["TenSP"] != null)
            {
                dgvInvoice.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                dgvInvoice.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (dgvInvoice.Columns["SoLuong"] != null)
            {
                dgvInvoice.Columns["SoLuong"].HeaderText = "SL";
                dgvInvoice.Columns["SoLuong"].Width = 50;
            }

            if (dgvInvoice.Columns["DonGia"] != null)
            {
                dgvInvoice.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvInvoice.Columns["DonGia"].Width = 100;
                dgvInvoice.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }

            if (dgvInvoice.Columns["ThanhTien"] != null)
            {
                dgvInvoice.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvInvoice.Columns["ThanhTien"].Width = 120;
                dgvInvoice.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            if (dgvInvoice.Columns["TonKho"] != null)
            {
                dgvInvoice.Columns["TonKho"].Visible = false;
            }

            var btnDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                Width = 50
            };
            dgvInvoice.Columns.Add(btnDelete);

            dgvInvoice.CellClick += DgvInvoice_CellClick;
            dgvInvoice.CellDoubleClick += DgvInvoice_CellDoubleClick;
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadChiNhanh();
            LoadPaymentMethods();
            UpdateTotalDisplay();
        }

        // Sử dụng SP: sp_LoadChiNhanh
        private void LoadChiNhanh()
        {
            try
            {
                var chiNhanhs = dbContext.ChiNhanhs
                    .FromSqlRaw("EXEC sp_LoadChiNhanh")
                    .ToList();

                if (chiNhanhs.Count == 0)
                {
                    MessageBox.Show("Không có chi nhánh nào trong hệ thống!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cboChiNhanh.SelectedIndexChanged -= CboChiNhanh_SelectedIndexChanged;

                cboChiNhanh.DataSource = chiNhanhs;
                cboChiNhanh.DisplayMember = "TenChiNhanh";
                cboChiNhanh.ValueMember = "MaCn";

                var chiNhanh1 = chiNhanhs.FirstOrDefault(cn => cn.MaCn == "CN1");
                if (chiNhanh1 != null)
                {
                    cboChiNhanh.SelectedValue = "CN1";
                    currentMaCn = "CN1";
                }
                else if (cboChiNhanh.Items.Count > 0)
                {
                    cboChiNhanh.SelectedIndex = 0;
                    currentMaCn = cboChiNhanh.SelectedValue?.ToString();
                }

                cboChiNhanh.SelectedIndexChanged += CboChiNhanh_SelectedIndexChanged;

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load chi nhánh:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaymentMethods()
        {
            cboPaymentMethod.Items.Clear();
            cboPaymentMethod.Items.Add("TienMat");
            cboPaymentMethod.Items.Add("ChuyenKhoan");
            cboPaymentMethod.Items.Add("TheTinDung");
            cboPaymentMethod.Items.Add("ViDienTu");
            if (cboPaymentMethod.Items.Count > 0)
                cboPaymentMethod.SelectedIndex = 0;
        }

        private void CboChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChiNhanh.SelectedValue != null)
            {
                string newMaCn = cboChiNhanh.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(currentMaCn) && currentMaCn != newMaCn)
                {
                    if (invoiceTable.Rows.Count > 0)
                    {
                        var result = MessageBox.Show(
                            "Thay đổi chi nhánh sẽ xóa toàn bộ hóa đơn hiện tại và hoàn trả tồn kho.\nBạn có chắc muốn tiếp tục?",
                            "Xác nhận",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            cboChiNhanh.SelectedIndexChanged -= CboChiNhanh_SelectedIndexChanged;
                            cboChiNhanh.SelectedValue = currentMaCn;
                            cboChiNhanh.SelectedIndexChanged += CboChiNhanh_SelectedIndexChanged;
                            return;
                        }
                        invoiceTable.Clear();
                        UpdateTotalDisplay();
                    }
                    if (!string.IsNullOrEmpty(selectedEmployeeId))
                    {
                        MessageBox.Show("Đã thay đổi chi nhánh. Vui lòng chọn lại nhân viên!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        selectedEmployeeId = null;
                        selectedEmployeeName = null;
                        txtEmployee.Clear();
                        lblEmployeeInfo.Text = "Chưa chọn nhân viên";
                        lblEmployeeInfo.ForeColor = Color.FromArgb(52, 152, 219);
                    }
                }

                currentMaCn = newMaCn;
                LoadProducts();
            }
        }

        // Sử dụng SP: sp_LoadProductsByChiNhanh
        private void LoadProducts()
        {
            if (string.IsNullOrEmpty(currentMaCn))
            {
                return;
            }

            try
            {
                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_LoadProductsByChiNhanh";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MaCN", currentMaCn));

                    dbContext.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        allProducts.Clear();

                        while (reader.Read())
                        {
                            allProducts.Add(new ProductViewModel
                            {
                                MaSp = reader["MaSP"].ToString(),
                                TenSp = reader["TenSP"].ToString(),
                                GiaBan = Convert.ToDouble(reader["GiaBan"]),
                                LoaiSp = reader["LoaiSP"].ToString(),
                                TonKho = Convert.ToInt32(reader["TonKho"]),
                                MaCn = reader["MaCN"].ToString()
                            });
                        }
                    }

                    dbContext.Database.CloseConnection();
                }

                if (allProducts.Count == 0)
                {
                    pnlProducts.Controls.Clear();
                    Label lblEmpty = new Label
                    {
                        Text = "Không có sản phẩm nào trong kho chi nhánh này",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Location = new Point(20, 20)
                    };
                    pnlProducts.Controls.Add(lblEmpty);
                    return;
                }

                DisplayProducts(allProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load sản phẩm:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dbContext.Database.GetDbConnection().State == ConnectionState.Open)
                {
                    dbContext.Database.CloseConnection();
                }
            }
        }

        private void DisplayProducts(List<ProductViewModel> products)
        {
            pnlProducts.Controls.Clear();

            if (products == null || products.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không có sản phẩm nào",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(20, 20)
                };
                pnlProducts.Controls.Add(lblEmpty);
                return;
            }

            foreach (var product in products)
            {
                Panel productCard = CreateProductCard(product);
                pnlProducts.Controls.Add(productCard);
            }
        }

        private Panel CreateProductCard(ProductViewModel product)
        {
            Panel productCard = new Panel
            {
                Width = 160,
                Height = 200,
                Margin = new Padding(10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = product
            };

            Panel imgPanel = new Panel
            {
                Width = 140,
                Height = 90,
                Location = new Point(10, 10),
                BackColor = Color.FromArgb(52, 152, 219),
                Tag = product
            };

            Label lblImg = new Label
            {
                Text = "🐾",
                Font = new Font("Segoe UI", 28),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = product
            };
            imgPanel.Controls.Add(lblImg);

            Label lblName = new Label
            {
                Text = product.TenSp,
                Location = new Point(5, 105),
                Width = 150,
                Height = 35,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                TextAlign = ContentAlignment.TopCenter,
                Tag = product
            };

            Label lblPrice = new Label
            {
                Text = product.GiaBan.ToString("N0") + " đ",
                Location = new Point(5, 145),
                Width = 150,
                Height = 20,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
                TextAlign = ContentAlignment.TopCenter,
                Tag = product
            };

            Label lblStock = new Label
            {
                Text = $"Kho: {product.TonKho}",
                Location = new Point(5, 170),
                Width = 150,
                Height = 20,
                Font = new Font("Segoe UI", 8),
                ForeColor = product.TonKho > 10 ? Color.Green : Color.Red,
                TextAlign = ContentAlignment.TopCenter,
                Tag = product
            };

            productCard.Controls.Add(imgPanel);
            productCard.Controls.Add(lblName);
            productCard.Controls.Add(lblPrice);
            productCard.Controls.Add(lblStock);

            productCard.Click += ProductCard_Click;
            imgPanel.Click += ProductCard_Click;
            lblImg.Click += ProductCard_Click;
            lblName.Click += ProductCard_Click;
            lblPrice.Click += ProductCard_Click;
            lblStock.Click += ProductCard_Click;

            return productCard;
        }

        private void ProductCard_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            ProductViewModel product = control.Tag as ProductViewModel;
            if (product != null)
            {
                AddToInvoice(product, 1);

                string searchText = txtSearch.Text.ToLower().Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    DisplayProducts(allProducts);
                }
                else
                {
                    var filtered = allProducts.Where(p =>
                        p.TenSp.ToLower().Contains(searchText) ||
                        p.MaSp.ToLower().Contains(searchText) ||
                        p.LoaiSp.ToLower().Contains(searchText)
                    ).ToList();

                    DisplayProducts(filtered);
                }
            }
        }

        private void AddToInvoice(ProductViewModel product, int quantity)
        {
            if (string.IsNullOrEmpty(currentMaCn))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedEmployeeId))
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước khi thêm sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existingRow = invoiceTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("MaSP") == product.MaSp);

            int currentQtyInInvoice = existingRow != null ? existingRow.Field<int>("SoLuong") : 0;
            int availableStock = product.TonKho - currentQtyInInvoice;

            if (quantity > availableStock)
            {
                MessageBox.Show($"Không đủ hàng trong kho!\nTồn kho khả dụng: {availableStock}",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existingRow != null)
            {
                int newQty = currentQtyInInvoice + quantity;
                existingRow["SoLuong"] = newQty;
                decimal donGia = existingRow.Field<decimal>("DonGia");
                existingRow["ThanhTien"] = donGia * newQty;
            }
            else
            {
                DataRow newRow = invoiceTable.NewRow();
                newRow["MaSP"] = product.MaSp;
                newRow["TenSP"] = product.TenSp;
                newRow["SoLuong"] = quantity;
                newRow["DonGia"] = (decimal)product.GiaBan;
                newRow["ThanhTien"] = (decimal)product.GiaBan * quantity;
                newRow["TonKho"] = product.TonKho;
                invoiceTable.Rows.Add(newRow);
            }

            UpdateProductStock(product.MaSp, -quantity);
            UpdateTotalDisplay();
        }

        private void DgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvInvoice.Columns["Delete"].Index)
            {
                string maSp = dgvInvoice.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
                int quantity = Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["SoLuong"].Value);
                RemoveFromInvoice(maSp, quantity);
            }
        }

        private void DgvInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex != dgvInvoice.Columns["Delete"].Index)
            {
                string maSp = dgvInvoice.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
                int currentQty = Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["SoLuong"].Value);
                int tonKho = Convert.ToInt32(dgvInvoice.Rows[e.RowIndex].Cells["TonKho"].Value);

                using (var form = new Form())
                {
                    form.Text = "Sửa số lượng";
                    form.Width = 300;
                    form.Height = 150;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.MaximizeBox = false;
                    form.MinimizeBox = false;

                    Label lblQuantity = new Label
                    {
                        Text = "Số lượng mới:",
                        Location = new Point(10, 20),
                        Width = 100
                    };

                    NumericUpDown numQuantity = new NumericUpDown
                    {
                        Location = new Point(120, 18),
                        Width = 100,
                        Minimum = 1,
                        Maximum = tonKho,
                        Value = currentQty
                    };

                    Button btnOK = new Button
                    {
                        Text = "OK",
                        Location = new Point(110, 60),
                        Width = 80,
                        DialogResult = DialogResult.OK
                    };

                    form.Controls.AddRange(new Control[] { lblQuantity, numQuantity, btnOK });
                    form.AcceptButton = btnOK;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int newQty = (int)numQuantity.Value;
                        int difference = newQty - currentQty;

                        var row = invoiceTable.AsEnumerable()
                            .FirstOrDefault(r => r.Field<string>("MaSP") == maSp);

                        if (row != null)
                        {
                            row["SoLuong"] = newQty;
                            decimal donGia = row.Field<decimal>("DonGia");
                            row["ThanhTien"] = donGia * newQty;

                            UpdateProductStock(maSp, -difference);
                            UpdateTotalDisplay();
                        }
                    }
                }
            }
        }

        private void RemoveFromInvoice(string maSp, int quantity)
        {
            var row = invoiceTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("MaSP") == maSp);

            if (row != null)
            {
                invoiceTable.Rows.Remove(row);
                UpdateProductStock(maSp, quantity);
                UpdateTotalDisplay();
            }
        }

        private void UpdateProductStock(string maSp, int quantityChange)
        {
            var product = allProducts.FirstOrDefault(p => p.MaSp == maSp);
            if (product != null)
            {
                product.TonKho += quantityChange;
            }
        }

        private void UpdateTotalDisplay()
        {
            try
            {
                decimal subtotal = 0;

                if (invoiceTable != null && invoiceTable.Rows.Count > 0)
                {
                    foreach (DataRow row in invoiceTable.Rows)
                    {
                        if (row["ThanhTien"] != DBNull.Value)
                        {
                            subtotal += Convert.ToDecimal(row["ThanhTien"]);
                        }
                    }
                }

                decimal discount = subtotal * discountPercent / 100;
                decimal total = subtotal - discount;
                lblSubTotal.Text = $"Tạm tính: {subtotal:N0} đ";
                lblDiscount.Text = $"Giảm giá ({discountPercent}%): -{discount:N0} đ";
                lblTotal.Text = $"TỔNG TIỀN: {total:N0} đ";

                lblSubTotal.Invalidate();
                lblDiscount.Invalidate();
                lblTotal.Invalidate();

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật tổng tiền: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sử dụng SP: sp_SearchEmployee
        private void BtnSearchEmployee_Click(object sender, EventArgs e)
        {
            string searchText = txtEmployee.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Vui lòng nhập mã hoặc tên nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(currentMaCn))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_SearchEmployee";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@SearchText", searchText));
                    command.Parameters.Add(new SqlParameter("@MaCN", currentMaCn));

                    dbContext.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            selectedEmployeeId = reader["MaNV"].ToString();
                            selectedEmployeeName = reader["HoTen"].ToString();
                            lblEmployeeInfo.Text = $"{selectedEmployeeName} - {selectedEmployeeId}";
                            lblEmployeeInfo.ForeColor = Color.FromArgb(46, 204, 113);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên hoặc nhân viên không thuộc chi nhánh này!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetEmployeeInfo();
                        }
                    }

                    dbContext.Database.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm nhân viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetEmployeeInfo();
            }
            finally
            {
                if (dbContext.Database.GetDbConnection().State == ConnectionState.Open)
                {
                    dbContext.Database.CloseConnection();
                }
            }
        }

        private void ResetEmployeeInfo()
        {
            selectedEmployeeId = null;
            selectedEmployeeName = null;
            lblEmployeeInfo.Text = "Chưa chọn nhân viên";
            lblEmployeeInfo.ForeColor = Color.FromArgb(52, 152, 219);
        }

        // Sử dụng SP: sp_SearchCustomer
        private void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            string searchText = txtCustomer.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Vui lòng nhập SĐT hoặc tên khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_SearchCustomer";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@SearchText", searchText));

                    dbContext.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            selectedCustomer = new KhachHang
                            {
                                MaKh = reader["MaKH"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                SoDt = reader["SoDT"].ToString(),
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "",
                                GioiTinh = reader["GioiTinh"] != DBNull.Value ? reader["GioiTinh"].ToString() : "",
                                CapHoiVien = reader["CapHoiVien"].ToString(),
                                DiemTichLuy = Convert.ToInt32(reader["DiemTichLuy"])
                            };

                            UpdateCustomerDisplay();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    dbContext.Database.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm khách hàng: {ex.Message}", "Lỗi",
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

        private void UpdateCustomerDisplay()
        {
            if (selectedCustomer == null)
            {
                lblCustomerInfo.Text = "Chưa chọn khách hàng";
                lblCustomerInfo.ForeColor = Color.FromArgb(52, 152, 219);
                lblCustomerPoints.Text = "";
                lblCustomerRank.Text = "";
                lblCustomerDiscount.Text = "";
                discountPercent = 0;
            }
            else
            {
                lblCustomerInfo.Text = $"{selectedCustomer.HoTen} - {selectedCustomer.SoDt}";
                lblCustomerInfo.ForeColor = Color.FromArgb(46, 204, 113);

                int points = selectedCustomer.DiemTichLuy ?? 0;
                lblCustomerPoints.Text = $"Điểm: {points}";

                string rank = selectedCustomer.CapHoiVien ?? "CoBan";
                string tmpRank = rank;
                if (tmpRank == "VIP")
                {
                    tmpRank = "VIP";
                }
                else if (tmpRank == "ThanThiet")
                {
                    tmpRank = "Thân thiết";
                }
                else
                {
                    tmpRank = "Cơ bản";
                }
                lblCustomerRank.Text = $"Hạng: {tmpRank}";

                if (rank.Equals("VIP", StringComparison.OrdinalIgnoreCase))
                {
                    discountPercent = 15;
                    lblCustomerDiscount.Text = "Giảm giá: 15%";
                    lblCustomerDiscount.ForeColor = Color.FromArgb(230, 126, 34);
                }
                else if (rank.Equals("ThanThiet", StringComparison.OrdinalIgnoreCase))
                {
                    discountPercent = 5;
                    lblCustomerDiscount.Text = "Giảm giá: 5%";
                    lblCustomerDiscount.ForeColor = Color.FromArgb(52, 152, 219);
                }
                else
                {
                    discountPercent = 0;
                    lblCustomerDiscount.Text = "Giảm giá: 0%";
                    lblCustomerDiscount.ForeColor = Color.Gray;
                }
            }

            UpdateTotalDisplay();
        }

        // Sử dụng SP: sp_CreateCustomer
        private void BtnCreateCustomer_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Tạo khách hàng mới";
                form.Width = 400;
                form.Height = 250;
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                Label lblName = new Label { Text = "Họ tên:", Location = new Point(20, 20), Width = 80 };
                TextBox txtName = new TextBox { Location = new Point(110, 18), Width = 250 };
                
                Label lblPhone = new Label { Text = "Số điện thoại:", Location = new Point(20, 55), Width = 90 };
                TextBox txtPhone = new TextBox { Location = new Point(110, 53), Width = 250 };
                
                Label lblEmail = new Label { Text = "Email:", Location = new Point(20, 90), Width = 80 };
                TextBox txtEmail = new TextBox { Location = new Point(110, 88), Width = 250 };
                
                Label lblGender = new Label { Text = "Giới tính:", Location = new Point(20, 125), Width = 80 };
                ComboBox cboGender = new ComboBox
                {
                    Location = new Point(110, 123),
                    Width = 100,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
                cboGender.SelectedIndex = 0;

                Button btnSave = new Button
                {
                    Text = "Tạo",
                    Location = new Point(190, 165),
                    Width = 80,
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    DialogResult = DialogResult.OK
                };

                Button btnCancel = new Button
                {
                    Text = "Hủy",
                    Location = new Point(280, 165),
                    Width = 80,
                    DialogResult = DialogResult.Cancel
                };

                form.Controls.AddRange(new Control[] {
                    lblName, txtName, lblPhone, txtPhone,
                    lblEmail, txtEmail, lblGender, cboGender,
                    btnSave, btnCancel
                });

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ họ tên và số điện thoại!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        string newMaKh = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");

                        using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                        {
                            command.CommandText = "sp_CreateCustomer";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add(new SqlParameter("@MaKH", newMaKh));
                            command.Parameters.Add(new SqlParameter("@HoTen", txtName.Text.Trim()));
                            command.Parameters.Add(new SqlParameter("@SoDT", txtPhone.Text.Trim()));
                            command.Parameters.Add(new SqlParameter("@Email", 
                                string.IsNullOrWhiteSpace(txtEmail.Text) ? "" : txtEmail.Text.Trim()));
                            command.Parameters.Add(new SqlParameter("@GioiTinh", cboGender.SelectedItem.ToString()));

                            dbContext.Database.OpenConnection();

                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    selectedCustomer = new KhachHang
                                    {
                                        MaKh = reader["MaKH"].ToString(),
                                        HoTen = reader["HoTen"].ToString(),
                                        SoDt = reader["SoDT"].ToString(),
                                        Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "",
                                        GioiTinh = reader["GioiTinh"] != DBNull.Value ? reader["GioiTinh"].ToString() : "",
                                        CapHoiVien = reader["CapHoiVien"].ToString(),
                                        DiemTichLuy = Convert.ToInt32(reader["DiemTichLuy"])
                                    };

                                    txtCustomer.Text = selectedCustomer.SoDt;
                                    UpdateCustomerDisplay();

                                    MessageBox.Show("Tạo khách hàng thành công!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            dbContext.Database.CloseConnection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tạo khách hàng: {ex.Message}", "Lỗi",
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
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                DisplayProducts(allProducts);
            }
            else
            {
                var filtered = allProducts.Where(p =>
                    p.TenSp.ToLower().Contains(searchText) ||
                    p.MaSp.ToLower().Contains(searchText) ||
                    p.LoaiSp.ToLower().Contains(searchText)
                ).ToList();

                DisplayProducts(filtered);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            TxtSearch_TextChanged(sender, e);
        }

        private void BtnClearInvoice_Click(object sender, EventArgs e)
        {
            if (invoiceTable.Rows.Count == 0)
                return;

            var result = MessageBox.Show("Bạn có chắc muốn xóa toàn bộ hóa đơn?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataRow row in invoiceTable.Rows)
                {
                    string maSp = row.Field<string>("MaSP");
                    int quantity = row.Field<int>("SoLuong");
                    UpdateProductStock(maSp, quantity);
                }

                invoiceTable.Clear();
                selectedCustomer = null;
                txtCustomer.Clear();
                UpdateCustomerDisplay();
            }
        }

        // Sử dụng SP: sp_CreateInvoice
        private void BtnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (invoiceTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào hóa đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedEmployeeId))
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedCustomer == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trước khi tạo hóa đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(currentMaCn))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maHd = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
                string maMuaHang = "MH" + DateTime.Now.ToString("yyyyMMddHHmmss");

                decimal subtotal = 0;
                foreach (DataRow row in invoiceTable.Rows)
                {
                    subtotal += row.Field<decimal>("ThanhTien");
                }

                decimal discount = subtotal * discountPercent / 100;
                decimal tongTien = subtotal - discount;

                // Tạo JSON cho chi tiết hóa đơn
                var invoiceDetails = new List<object>();
                foreach (DataRow row in invoiceTable.Rows)
                {
                    invoiceDetails.Add(new
                    {
                        MaSP = row.Field<string>("MaSP"),
                        SoLuong = row.Field<int>("SoLuong"),
                        DonGia = row.Field<decimal>("DonGia")
                    });
                }

                string jsonDetails = JsonSerializer.Serialize(invoiceDetails);

                using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_CreateInvoice";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MaHD", maHd));
                    command.Parameters.Add(new SqlParameter("@NgayLap", DateTime.Now.Date));
                    command.Parameters.Add(new SqlParameter("@TongTien", tongTien));
                    command.Parameters.Add(new SqlParameter("@KhuyenMai", discountPercent.ToString("0")));
                    command.Parameters.Add(new SqlParameter("@HinhThucThanhToan", cboPaymentMethod.SelectedItem?.ToString() ?? "TienMat"));
                    command.Parameters.Add(new SqlParameter("@MaNV", selectedEmployeeId));
                    command.Parameters.Add(new SqlParameter("@MaKH", selectedCustomer.MaKh));
                    command.Parameters.Add(new SqlParameter("@MaCN", currentMaCn));
                    command.Parameters.Add(new SqlParameter("@MaMuaHang", maMuaHang));
                    command.Parameters.Add(new SqlParameter("@InvoiceDetails", jsonDetails));

                    dbContext.Database.OpenConnection();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read() && reader["Status"].ToString() == "SUCCESS")
                        {
                            currentInvoiceId = maHd;

                            string message = GenerateInvoiceText(maHd, subtotal, discount, tongTien);
                            MessageBox.Show(message, "Hóa Đơn Thành Công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearForm();
                            LoadProducts();
                        }
                    }

                    dbContext.Database.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo hóa đơn:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dbContext.Database.GetDbConnection().State == ConnectionState.Open)
                {
                    dbContext.Database.CloseConnection();
                }
            }
        }

        // Sử dụng SP: sp_PayInvoice
        private void BtnPayInvoice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentInvoiceId))
            {
                MessageBox.Show("Không có hóa đơn nào để thanh toán!\nVui lòng tạo hóa đơn trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var hoaDon = dbContext.HoaDons.FirstOrDefault(hd => hd.MaHd == currentInvoiceId);

                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn trong hệ thống!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (hoaDon.TrangThai == "DaThanhToan")
                {
                    MessageBox.Show("Hóa đơn này đã được thanh toán rồi!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = MessageBox.Show(
                    $"Xác nhận thanh toán hóa đơn {currentInvoiceId}?\n\n" +
                    $"Số tiền: {hoaDon.TongTien:N0}đ\n" +
                    $"Hình thức: {hoaDon.HinhThucThanhToan}",
                    "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var command = dbContext.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "sp_PayInvoice";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@MaHD", currentInvoiceId));
                        command.Parameters.Add(new SqlParameter("@MaKH",
                            selectedCustomer?.MaKh ?? (object)DBNull.Value));

                        dbContext.Database.OpenConnection();

                        command.ExecuteNonQuery();

                        string successMessage = "═══════════════════════════════════════\n";
                        successMessage += "       THANH TOÁN THÀNH CÔNG!\n";
                        successMessage += "═══════════════════════════════════════\n";
                        successMessage += $"Mã HĐ: {currentInvoiceId}\n";
                        successMessage += $"Số tiền: {hoaDon.TongTien:N0}đ\n";
                        successMessage += $"Hình thức: {hoaDon.HinhThucThanhToan}\n";
                        successMessage += $"Ngày thanh toán: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n";

                        if (selectedCustomer != null)
                        {
                            successMessage += $"\nKhách hàng: {selectedCustomer.HoTen}\n";
                        }

                        successMessage += "═══════════════════════════════════════\n";
                        successMessage += "\nCảm ơn quý khách! Hẹn gặp lại!";

                        MessageBox.Show(successMessage, "Thanh Toán Thành Công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearForm();
                        currentInvoiceId = null;

                        dbContext.Database.CloseConnection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán hóa đơn:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dbContext.Database.GetDbConnection().State == ConnectionState.Open)
                {
                    dbContext.Database.CloseConnection();
                }
            }
        }

        private string GenerateInvoiceText(string maHd, decimal subtotal, decimal discount, decimal tongTien)
        {
            string invoice = "═══════════════════════════════════════\n";
            invoice += "         HÓA ĐƠN BÁN HÀNG\n";
            invoice += "═══════════════════════════════════════\n";
            invoice += $"Mã HĐ: {maHd}\n";
            invoice += $"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n";
            invoice += $"Chi nhánh: {cboChiNhanh.Text}\n";
            invoice += $"Nhân viên: {selectedEmployeeName}\n";

            if (selectedCustomer != null)
            {
                var rank = selectedCustomer.CapHoiVien;
                if (rank == "VIP")
                {
                    rank = "VIP";
                }
                else if (rank == "ThanThiet")
                {
                    rank = "Thân thiết";
                }
                else
                {
                    rank = "Cơ bản";
                }
                invoice += $"Khách hàng: {selectedCustomer.HoTen}\n";
                invoice += $"SĐT: {selectedCustomer.SoDt}\n";
                invoice += $"Hạng: {rank}\n";
            }

            invoice += "───────────────────────────────────────\n\n";

            foreach (DataRow row in invoiceTable.Rows)
            {
                invoice += $"{row["TenSP"]}\n";
                invoice += $"  SL: {row["SoLuong"]} x {Convert.ToDecimal(row["DonGia"]):N0}đ";
                invoice += $" = {Convert.ToDecimal(row["ThanhTien"]):N0}đ\n";
            }
            invoice += $"Trạng Thái: Chưa thanh toán\n\n";
            invoice += "───────────────────────────────────────\n";
            invoice += $"Tạm tính: {subtotal:N0}đ\n";

            if (discount > 0)
            {
                invoice += $"Giảm giá ({discountPercent}%): -{discount:N0}đ\n";
            }

            invoice += $"TỔNG CỘNG: {tongTien:N0}đ\n";
            invoice += $"Thanh toán: {cboPaymentMethod.Text}\n";
            invoice += "═══════════════════════════════════════\n";
            invoice += "\nCảm ơn quý khách! Hẹn gặp lại!";

            return invoice;
        }

        private void ClearForm()
        {
            invoiceTable.Clear();
            selectedCustomer = null;
            txtCustomer.Clear();
            UpdateCustomerDisplay();
            UpdateTotalDisplay();
        }
    }
}