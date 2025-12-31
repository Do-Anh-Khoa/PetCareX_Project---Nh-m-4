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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// Check-in và check-out chỉ thực hiện được 1 lần trong ngày

namespace PetCare_WinForm.Forms
{
    public partial class ChamCongNV : Form
    {
        private readonly PetCareContext _context = new PetCareContext();
        public ChamCongNV()
        {
            InitializeComponent();
        }

        private void ChamCongNV_Load(object sender, EventArgs e)
        {
            TimerChamCong.Start();
        }

        private void TimerChamCong_Tick(object sender, EventArgs e)
        {
            lblThoiGianHienTai.Text = DateTime.Now.ToString("dd/MM/yy HH:mm");
        }

        private void LoadChamCongNV()
        {
            try
            {
                var data = _context.Database
                    .SqlQuery<ChamCongLichSuVm>(
                        $@"EXEC sp_ChamCong_XemLichSu
                               @MaNV = {textMaNhanVien.Text}")
                    .ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textMaNhanVien_TextChanged(object sender, EventArgs e)
        {
            bool exists = _context.NhanViens.Any(nv => nv.MaNv == textMaNhanVien.Text);

            // Nếu tồn tại mã nhân viên, xem toàn bộ lịch sử chấm công trong 31 ngày gần nhất
            // Hơi thiếu tối ưu nhưng chạy vẫn nhanh do csdl nhỏ
            if (exists)
            {
                LoadChamCongNV();
            }
        }

        // Nút CHECK-IN
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    _context.Database.ExecuteSqlRaw(
                        "EXEC sp_ChamCong_CheckIn @MaNV",
                        new SqlParameter("@MaNV", textMaNhanVien.Text)
                    );

                    MessageBox.Show(
                        "Check-in thành công",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadChamCongNV(); // Tải lại bảng sau khi check-in
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút CHECK-OUT
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    _context.Database.ExecuteSqlRaw(
                        "EXEC sp_ChamCong_CheckOut @MaNV",
                        new SqlParameter("@MaNV", textMaNhanVien.Text)
                    );

                    MessageBox.Show(
                        "Check-out thành công",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadChamCongNV(); // Tải lại bảng sau khi check-out
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}

