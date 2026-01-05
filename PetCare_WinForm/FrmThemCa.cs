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

namespace PetCare_WinForm
{
    public partial class FrmThemCa : Form
    {
        private readonly PetCareContext _context;

        public bool TimKiemTheo { get; private set; } // true: Mã nhân viên, false: Tên nhân viên
        public string TuKhoa { get; private set; }

        public FrmThemCa()
        {
            InitializeComponent();
            _context = new PetCareContext();
        }

        private void FrmThemCa_Load(object sender, EventArgs e)
        {
            comboBox_ChonCa.Visible = false;
            dateTimePicker_ChonNgay.Visible = false;
            textBox_DienThongTin.Visible = false;
            btn_ThemCa.Visible = false;
        }

        private void comboBox_ChonLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_ChonCa.Visible = true;
            textBox_DienThongTin.Visible = true;
            btn_ThemCa.Visible = true;
            dateTimePicker_ChonNgay.Visible = true;
            
            if (comboBox_ChonLoai.SelectedItem.ToString() == "Thêm bằng mã nhân viên")
            {
                textBox_DienThongTin.PlaceholderText = "Nhập mã nhân viên";
            }
            else if (comboBox_ChonLoai.SelectedItem.ToString() == "Thêm bằng tên nhân viên")
            {
                textBox_DienThongTin.PlaceholderText = "Nhập tên nhân viên";
            }
        }

        private void btn_ThemCa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_DienThongTin.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin nhân viên");
                return;
            }

            if (comboBox_ChonCa.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm việc");
                return;
            }

            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC sp_ThemPhanCa @p0, @p1, @p2",
                    comboBox_ChonCa.SelectedItem.ToString(),      // @TenCa
                    textBox_DienThongTin.Text,   // @InputNhanVien
                    dateTimePicker_ChonNgay.Value.Date      // @NgayLamViec
                );
                MessageBox.Show("Thêm thành công!", "Thông báo");
                DialogResult = DialogResult.OK;

                TuKhoa = textBox_DienThongTin.Text;
                if (comboBox_ChonLoai.SelectedItem.ToString() == "Thêm bằng mã nhân viên")
                {
                    TimKiemTheo = true;
                }
                else
                {
                    TimKiemTheo = false;
                }

                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }
    }
}
