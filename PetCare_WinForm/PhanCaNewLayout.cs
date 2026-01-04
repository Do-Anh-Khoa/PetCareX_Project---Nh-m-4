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
    public partial class PhanCaNewLayout : Form
    {
        private readonly PetCareContext _context;
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> ControlBounds = new Dictionary<Control, Rectangle>();
        public PhanCaNewLayout()
        {
            InitializeComponent();
            _context = new PetCareContext();
        }

        private void PhanCaNewLayout_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            StoreControlBounds(this);
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void PhanCaNewLayout_Resize(object sender, EventArgs e)
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

        private void btn_TimKiemCaLam_Click(object sender, EventArgs e)
        {
            using (FrmTimKiemCaLam frm = new FrmTimKiemCaLam())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bool timKiemTheo = frm.TimKiemTheo; // 1: ID, 2: Name
                    string tuKhoa = frm.TuKhoa;

                    var pMaNV = new SqlParameter("@MaNV", string.IsNullOrEmpty(tuKhoa) ? DBNull.Value : tuKhoa);
                    var pHoTen = new SqlParameter("@HoTen", string.IsNullOrEmpty(tuKhoa) ? DBNull.Value : tuKhoa);
                    var pFlag = new SqlParameter("@Flag", timKiemTheo);

                    var results = _context.KetQuaTimKiemCaLamViec
                        .FromSqlRaw("EXEC sp_TimKiemCaLamViec @MaNV, @HoTen, @Flag", pMaNV, pHoTen, pFlag)
                        .ToList();

                    dataGridView_Chinh.DataSource = results;
                }
            }
        }

        private void btn_ThemCaLam_Click(object sender, EventArgs e)
        {
            using (FrmThemCa frm = new FrmThemCa())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bool timKiemTheo = frm.TimKiemTheo; // 1: ID, 2: Name
                    string tuKhoa = frm.TuKhoa;

                    var pMaNV = new SqlParameter("@MaNV", string.IsNullOrEmpty(tuKhoa) ? DBNull.Value : tuKhoa);
                    var pHoTen = new SqlParameter("@HoTen", string.IsNullOrEmpty(tuKhoa) ? DBNull.Value : tuKhoa);
                    var pFlag = new SqlParameter("@Flag", timKiemTheo);

                    // 3. Execute the query on the DbSet property
                    var results = _context.KetQuaTimKiemCaLamViec
                        .FromSqlRaw("EXEC sp_TimKiemCaLamViec @MaNV, @HoTen, @Flag", pMaNV, pHoTen, pFlag)
                        .ToList();

                    // 3. Bind to the DataGridView
                    dataGridView_Chinh.DataSource = results;
                }
            }
        }

        private void btn_XoaCaLam_Click(object sender, EventArgs e)
        {
            using (FrmXoaCaLamViec frm = new FrmXoaCaLamViec())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bool timKiemTheo = frm.TimKiemTheo; // 1: ID, 2: Name
                    string tuKhoa = frm.TuKhoa;

                    var pMaNV = new SqlParameter("@MaNV", string.IsNullOrEmpty(tuKhoa) ? DBNull.Value : tuKhoa);
                    var pHoTen = new SqlParameter("@HoTen", string.IsNullOrEmpty(tuKhoa) ? DBNull.Value : tuKhoa);
                    var pFlag = new SqlParameter("@Flag", timKiemTheo);

                    // 3. Execute the query on the DbSet property
                    var results = _context.KetQuaTimKiemCaLamViec
                        .FromSqlRaw("EXEC sp_TimKiemCaLamViec @MaNV, @HoTen, @Flag", pMaNV, pHoTen, pFlag)
                        .ToList();

                    // 3. Bind to the DataGridView
                    dataGridView_Chinh.DataSource = results;
                }
            }
        }
    }
}
