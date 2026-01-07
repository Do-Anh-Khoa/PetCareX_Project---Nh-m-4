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
    public partial class TinhLuongNV : Form
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> ControlBounds = new Dictionary<Control, Rectangle>();
        private readonly PetCareContext _context;
        public TinhLuongNV()
        {
            _context = new PetCareContext();
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        // Hàm hỗ trợ load bản lương, tách ra để có thể gọi khi xem lương và sau khi tính lương
        private void XemLuongNV_Load()
        {
            try
            {
                var data = _context.Database
                    .SqlQuery<XemLuongVm>(
                        $@"EXEC sp_XemBangLuong
                               @Thang = {dateTimePicker_ChonThangNam.Value.Month},
                               @Nam = {dateTimePicker_ChonThangNam.Value.Year}")
                    .ToList();
                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TinhLuongNV_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            StoreControlBounds(this);
        }

        private void TinhLuongNV_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)this.Width / (float)originalFormSize.Width;
            float yRatio = (float)this.Height / (float)originalFormSize.Height;
            foreach (Control ctrl in this.Controls)
            {
                if (!ControlBounds.ContainsKey(ctrl)) return;
                Rectangle r = ControlBounds[ctrl];
                int newX = (int)(r.X * xRatio);
                int newY = (int)(r.Y * yRatio);
                int newWidth = (int)(r.Width * xRatio);
                int newHeight = (int)(r.Height * yRatio);
                ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
            }
        }

        private void StoreControlBounds(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ControlBounds[ctrl] = ctrl.Bounds;

                if (ctrl.Controls.Count > 0)
                {
                    StoreControlBounds(ctrl);
                }
            }
        }

        private void buttonXemLuong_Click(object sender, EventArgs e)
        {
            XemLuongNV_Load();
        }

        private void buttonTinhLuong_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có muốn thực hiện lệnh tính lương?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _context.Database.ExecuteSqlRaw(
                        "EXEC sp_TinhLuong @Thang, @Nam",
                        new SqlParameter("@Thang", dateTimePicker_ChonThangNam.Value.Month),
                        new SqlParameter("@Nam", dateTimePicker_ChonThangNam.Value.Year)
                    );

                    MessageBox.Show(
                        "Tinh lương thành công",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    XemLuongNV_Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}