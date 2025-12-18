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
using PetCare_WinForm.Data;
using PetCare_WinForm.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PetCare_WinForm.Forms
{
    public partial class PhanCa : Form
    {

        private readonly PetCareContext _context;
        public PhanCa()
        {
            _context = new PetCareContext();
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PhanCa_Load_1(object sender, EventArgs e)
        {
            HienThiTimKiem();
        }

        private void HienThiTimKiem()
        {
            try
            {
                SqlCommand c = new SqlCommand("sp_TimKiemCaLamViec");
                var data = _context.Database
                    .SqlQuery<TiemKiemCaLamViecVm>(
                        $@"
                    EXEC sp_TimKiemCaLamViec
                        @TuNgay = {(null)},
                        @DenNgay = {(null)},
                        @MaNV = {(null)}")
                    .ToList();

                dataGridView_TiemKiemCaLam.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_HienThi_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand c = new SqlCommand("sp_TimKiemCaLamViec");
                var data = _context.Database
                    .SqlQuery<TiemKiemCaLamViecVm>(
                        $@"
                    EXEC sp_TimKiemCaLamViec
                        @TuNgay = {(dateTimePicker_TuNgay.Checked ? dateTimePicker_TuNgay.Value.Date : null)},
                        @DenNgay = {(dateTimePicker_DenNgay.Checked ? dateTimePicker_DenNgay.Value.Date : null)},
                        @MaNV = {(string.IsNullOrWhiteSpace(textBox_MaNV_TimKiem.Text) ? null : textBox_MaNV_TimKiem.Text)}")
                    .ToList();
                dataGridView_TiemKiemCaLam.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_MaNV_Them.Text))
            {
                MessageBox.Show("Không được để trống Mã Nhân viên", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_MaNV_Them.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBox_MaCa_Them.Text))
            {
                MessageBox.Show("Không được để trống Mã Ca", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_MaCa_Them.Focus();
                return;
            }


            try
            {
                var result = _context.Database.ExecuteSqlRaw(
                    "EXEC sp_ThemCaLamViec @MaCa, @MaNV, @NgayLamViec",
                    new SqlParameter("@MaCa", textBox_MaCa_Them.Text),
                    new SqlParameter("@MaNV", textBox_MaNV_Them.Text),
                    new SqlParameter("@NgayLamViec", dateTimePicker_ChonNgay1.Value.Date)
                );

                MessageBox.Show(
                    "Thêm ca làm việc thành công",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                HienThiTimKiem();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_MaNV_Xoa.Text))
            {
                MessageBox.Show("Không được để trống Mã Nhân viên", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_MaNV_Xoa.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBox_MaCa_Xoa.Text))
            {
                MessageBox.Show("Không được để trống Mã Ca", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_MaCa_Xoa.Focus();
                return;
            }


            try
            {
                var result = _context.Database.ExecuteSqlRaw(
                    "EXEC sp_XoaCaLamViec @MaCa, @MaNV, @NgayLamViec",
                    new SqlParameter("@MaCa", textBox_MaCa_Xoa.Text),
                    new SqlParameter("@MaNV", textBox_MaNV_Xoa.Text),
                    new SqlParameter("@NgayLamViec", dateTimePicker_ChonNgay2.Value.Date)
                );

                MessageBox.Show(
                    "Xóa ca làm việc thành công",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                HienThiTimKiem();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
