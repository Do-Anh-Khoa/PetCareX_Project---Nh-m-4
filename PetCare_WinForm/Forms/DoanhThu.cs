using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PetCare_Web.Data;
using PetCare_Web.Models;
using PetCare_Web.Models;
using PetCare_WebS.Models;

namespace PetCare_WinForm.Forms
{
    public partial class DoanhThu : Form
    {
        private readonly PetCareContext _context;
        
        public DoanhThu()
        {
            _context = new PetCareContext();
            InitializeComponent();
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            Choice_ChiNhanh.SelectedIndex = 0;
            Choice_ChiNhanh.Visible = false;
            textBox1.Visible = false;
            try
            {
                var data = _context.Set<Top10BacSiDoanhThu>()
                    .FromSqlRaw("SELECT * FROM dbo.v_TopDoctorRevenue")
                    .AsNoTracking()
                    .Select(x => new
                    {
                        x.MaBs,
                        x.HoTen,
                        x.MaCn,
                        x.TongDoanhThu,
                    })
                    .ToList();

                dsTop10BS.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dsTop10BS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadLuotKhamTheoChiNhanh()
        {
            try
            {
                SqlCommand c = new SqlCommand("sp_ThongKe_LuotKhamTheoChiNhanh");
                var data = _context.Database
                    .SqlQuery<LuotKhamTheoChiNhanhVm>(
                        $@"
                    EXEC sp_ThongKe_LuotKhamTheoChiNhanh 
                        @TuNgay = {(dateTimePicker_TuNgay.Checked ? dateTimePicker_TuNgay.Value.Date : null)},
                        @DenNgay = {(dateTimePicker_DenNgay.Checked ? dateTimePicker_DenNgay.Value.Date : null)}")
                    .ToList();

                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoanhThuTatCaChiNhanh()
        {
            try
            {
                var data = _context.Database
                    .SqlQuery<DoanhThuTatCaChiNhanhVm>(
                        $@"EXEC sp_ThongKe_DoanhThuTatCaChiNhanh 
                        @TuNgay = {(dateTimePicker_TuNgay.Checked ? dateTimePicker_TuNgay.Value.Date : null)},
                        @DenNgay = {(dateTimePicker_DenNgay.Checked ? dateTimePicker_DenNgay.Value.Date : null)}")
                    .ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoanhThuSanPham()
        {
            try
            {
                var data = _context.Database
                    .SqlQuery<DoanhThuSanPhamVm>(
                        $@"
                    EXEC sp_ThongKe_DoanhThuSanPham 
                        @TuNgay = {(dateTimePicker_TuNgay.Checked ? dateTimePicker_TuNgay.Value.Date : null)},
                        @DenNgay = {(dateTimePicker_DenNgay.Checked ? dateTimePicker_DenNgay.Value.Date : null)},
                        @MaCN = {(Choice_ChiNhanh.SelectedItem)}")
                    .ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSoLuotKham()
        {
            try
            {
                var data = _context.Database
                    .SqlQuery<SoLuotKhamVm>(
                        $@"
                    EXEC sp_ThongKe_SoLuotKham 
                        @TuNgay = {(dateTimePicker_TuNgay.Checked ? dateTimePicker_TuNgay.Value.Date : null)},
                        @DenNgay = {(dateTimePicker_DenNgay.Checked ? dateTimePicker_DenNgay.Value.Date : null)},
                        @MaCN = {(Choice_ChiNhanh.SelectedItem)}")
                    .ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoanhThuTheoBacSi()
        {
            try
            {
                var data = _context.Database
                    .SqlQuery<DoanhThuTheoBacSiVm>(
                        $@"
                    EXEC sp_ThongKe_DoanhThuTheoBacSi 
                        @TuNgay = {(dateTimePicker_TuNgay.Checked ? dateTimePicker_TuNgay.Value.Date : null)},
                        @DenNgay = {(dateTimePicker_DenNgay.Checked ? dateTimePicker_DenNgay.Value.Date : null)},
                        @MaCN = {(Choice_ChiNhanh.SelectedItem)}")
                    .ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHoaDonChiTiet()
        {
            try
            {
                var data = _context.Database
                    .SqlQuery<HoaDonChiTietVm>(
                        $@"
                    EXEC sp_ThongKe_DoanhThuPhongKham
                        @TuNgay = {(dateTimePicker_TuNgay.Checked ? dateTimePicker_TuNgay.Value.Date : null)},
                        @DenNgay = {(dateTimePicker_DenNgay.Checked ? dateTimePicker_DenNgay.Value.Date : null)},
                        @MaCN = {(Choice_ChiNhanh.SelectedItem)},
                        @TuKhoa = {(textBox1.Text)},
                        @SortOption = {(0)}")
                    .ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Choice_ChonThongKe.SelectedIndex == -1)
                return;

            switch (Choice_ChonThongKe.SelectedIndex)
            {
                case 0:
                    LoadHoaDonChiTiet();
                    break;

                case 1:
                    LoadDoanhThuTheoBacSi();
                    break;

                case 2:
                    LoadSoLuotKham();
                    break;

                case 3:
                    LoadDoanhThuSanPham();
                    break;

                case 4:
                    LoadDoanhThuTatCaChiNhanh();
                    break;

                case 5:
                    LoadLuotKhamTheoChiNhanh();
                    break;
            }
        }

        private void Choice_ChonThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Choice_ChonThongKe.SelectedIndex == -1)
                return;

            switch (Choice_ChonThongKe.SelectedIndex)
            {
                case 0:
                    textBox1.Visible = true;
                    Choice_ChiNhanh.Visible = true;
                    break;

                case 1:
                    textBox1.Visible = false;
                    Choice_ChiNhanh.Visible = true;
                    break;

                case 2:
                    textBox1.Visible = false;
                    Choice_ChiNhanh.Visible = true;
                    break;

                case 3:
                    textBox1.Visible = false;
                    Choice_ChiNhanh.Visible = true;
                    break;

                case 4:
                    textBox1.Visible = false;
                    Choice_ChiNhanh.Visible = false;
                    break;

                case 5:
                    textBox1.Visible = false;
                    Choice_ChiNhanh.Visible = false;
                    break;
            }

        }

        private void Choice_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
