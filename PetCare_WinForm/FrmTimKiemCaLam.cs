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
    public partial class FrmTimKiemCaLam : Form
    {

        private readonly PetCareContext _context = new PetCareContext();

        public bool TimKiemTheo { get; private set; } // true: Mã nhân viên, false: Tên nhân viên
        public string TuKhoa { get; private set; }

        public FrmTimKiemCaLam()
        {
            InitializeComponent();
            _context = new PetCareContext();
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            TimKiemTheo = TimKiemTheo;
            TuKhoa = textBox_NhapThongTin.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmTimKiemCaLam_Load(object sender, EventArgs e)
        {
            textBox_NhapThongTin.Visible = false;
            btn_TimKiem.Visible = false;
        }

        private void comboBox_TimKiemTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox_TimKiemTheo.SelectedItem?.ToString();
            textBox_NhapThongTin.Visible = true;
            btn_TimKiem.Visible = true;
            if (selected == "Mã nhân viên")
            {
                textBox_NhapThongTin.PlaceholderText = "Nhập mã nhân viên";
            }
            else if (selected == "Tên nhân viên")
            {
                textBox_NhapThongTin.PlaceholderText = "Nhập tên nhân viên";
            }
        }

        public class ExistsOnly
        {
            public int Value { get; set; }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            TuKhoa = textBox_NhapThongTin.Text;
            bool exists = false;

            string selected = comboBox_TimKiemTheo.SelectedItem?.ToString();
            if (selected == "Mã nhân viên")
            {
                TimKiemTheo = true;
                exists = _context.Set<ExistsOnly>()
                .FromSqlRaw (
                    "EXEC sp_KiemTraNhanVienTonTai @MaNV, @HoTen",
                    new SqlParameter("@MaNV", TuKhoa),
                    new SqlParameter("@HoTen", DBNull.Value)
                )
                .AsEnumerable()
                .Any();
                this.Close();
            }
            else if (selected == "Tên nhân viên")
            {
                TimKiemTheo = false;
                exists = _context.Set<ExistsOnly>()
                .FromSqlRaw (
                    "EXEC sp_KiemTraNhanVienTonTai @MaNV, @HoTen",
                    new SqlParameter("@MaNV", DBNull.Value),
                    new SqlParameter("@HoTen", TuKhoa)
                )
                .AsEnumerable()
                .Any();
            }

            if (!exists)
            {
                MessageBox.Show(
                    "Không tìm thấy nhân viên",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else if(exists)
            {
                MessageBox.Show(
                    "Tìm kiếm thành công",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
