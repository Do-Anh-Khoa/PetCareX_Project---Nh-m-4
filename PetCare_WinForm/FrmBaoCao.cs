
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Data;
using System.Collections.Generic;

namespace PetCare_WinForm
{
    public partial class FrmBaoCao : Form
    {
        public class ChiNhanhItem
        {
            public string? MaCN { get; set; }
            public string? TenCN { get; set; }
            public override string ToString() { return TenCN ?? ""; }
        }

        public FrmBaoCao()
        {
            InitializeComponent();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            // Load Năm
            cboNam.Items.Add("--- Tất cả ---");
            int namHienTai = DateTime.Now.Year;
            for (int i = namHienTai; i >= namHienTai - 5; i--)
                cboNam.Items.Add(i.ToString());
            cboNam.SelectedIndex = 0;

            // Load Chi Nhánh
            try 
            {
                using (var context = new PetCareContext())
                {
                    string connStr = context.Database.GetConnectionString() ?? "";
                    using (var conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        using (var cmd = new SqlCommand("SELECT MaCN, TenChiNhanh FROM CHI_NHANH", conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            cboChiNhanh.Items.Add(new ChiNhanhItem { MaCN = null, TenCN = "--- Tất cả Chi Nhánh ---" });
                            while (reader.Read())
                            {
                                cboChiNhanh.Items.Add(new ChiNhanhItem 
                                { 
                                    MaCN = reader["MaCN"]?.ToString() ?? "", 
                                    TenCN = reader["TenChiNhanh"]?.ToString() ?? "" 
                                });
                            }
                        }
                    }
                }
                cboChiNhanh.SelectedIndex = 0;
            }
            catch { }
        }

        // --- SỰ KIỆN CLICK NÚT LỌC ---
        private void BtnXemBaoCao_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đang ở Tab nào để load dữ liệu tương ứng
            if (tabControlBaoCao.SelectedTab == tabTongHop)
            {
                LoadDataTongHop();
            }
            else if (tabControlBaoCao.SelectedTab == tabBacSi)
            {
                LoadDataBacSi();
            }
            else if (tabControlBaoCao.SelectedTab == tabSanPham)
            {
                LoadDataSanPham();
            }
        }

        // --- HÀM 1: TẢI TAB TỔNG HỢP ---
        private void LoadDataTongHop()
        {
            try
            {
                var filters = GetFilterParams(); // Lấy tham số lọc

                using (var context = new PetCareContext())
                {
                    string connStr = context.Database.GetConnectionString() ?? "";
                    using (var conn = new SqlConnection(connStr))
                    {
                        conn.Open();

                        // 1. Doanh Thu
                        using (var cmd = new SqlCommand("sp_GetDoanhThu_NangCao", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            AddParams(cmd, filters);
                            
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvDoanhThu.DataSource = dt;

                            // Tính tổng hiển thị Label
                            decimal tong = 0;
                            foreach (DataRow row in dt.Rows)
                                if (row["TongDoanhThu"] != DBNull.Value) 
                                    tong += Convert.ToDecimal(row["TongDoanhThu"]);
                            lblTongDoanhThu.Text = $"Tổng Doanh Thu: {tong:N0} VNĐ";
                        }

                        // 2. Lượt Khám
                        using (var cmd = new SqlCommand("sp_GetSoLuotKham", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            AddParams(cmd, filters);

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvLuotKham.DataSource = dt;

                            // Tính tổng hiển thị Label
                            int tong = 0;
                            foreach (DataRow row in dt.Rows)
                                if (row["TongSoLuotKham"] != DBNull.Value)
                                    tong += Convert.ToInt32(row["TongSoLuotKham"]);
                            lblTongLuotKham.Text = $"Tổng Lượt Khám: {tong}";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- HÀM 2: TẢI TAB BÁC SĨ ---
        private void LoadDataBacSi()
        {
            // Gọi hàm dùng chung (Generic) cho gọn code
            LoadGenericReport("sp_GetDoanhThu_TheoBacSi", dgvBacSi);
        }

        // --- HÀM 3: TẢI TAB SẢN PHẨM ---
        private void LoadDataSanPham()
        {
            LoadGenericReport("sp_GetDoanhThu_SanPham", dgvSanPham);
        }

        // --- CÁC HÀM HỖ TRỢ (HELPER) ---
        
        // Hàm load dữ liệu chung cho 1 grid bất kỳ
        private void LoadGenericReport(string spName, DataGridView grid)
        {
            try
            {
                var filters = GetFilterParams();
                using (var context = new PetCareContext())
                {
                    string connStr = context.Database.GetConnectionString() ?? "";
                    using (var conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        using (var cmd = new SqlCommand(spName, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 300;
                            AddParams(cmd, filters);

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            grid.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải báo cáo: " + ex.Message); }
        }

        // Hàm lấy tham số từ giao diện
        private (object MaCN, object TuNgay, object DenNgay) GetFilterParams()
        {
            object maCN = DBNull.Value;
            object tuNgay = DBNull.Value;
            object denNgay = DBNull.Value;

            if (cboChiNhanh.SelectedItem is ChiNhanhItem item && item.MaCN != null)
                maCN = item.MaCN;

            if (cboNam.SelectedIndex > 0)
            {
                int nam = int.Parse(cboNam.SelectedItem?.ToString() ?? "0");
                tuNgay = new DateTime(nam, 1, 1);
                denNgay = new DateTime(nam, 12, 31);
            }
            return (maCN, tuNgay, denNgay);
        }

        // Hàm thêm tham số vào SqlCommand
        private void AddParams(SqlCommand cmd, (object MaCN, object TuNgay, object DenNgay) filters)
        {
            cmd.Parameters.AddWithValue("@MaCN", filters.MaCN);
            cmd.Parameters.AddWithValue("@TuNgay", filters.TuNgay);
            cmd.Parameters.AddWithValue("@DenNgay", filters.DenNgay);
        }
         
    }
}