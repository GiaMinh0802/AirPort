using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirPort
{
    public partial class frmQuanLyNhanVien : Form
    {
        #region Properties
        NhanVienBUS busNhanVien = new NhanVienBUS();
        #endregion

        #region Initializes
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            LoadForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }
        #endregion

        #region Methods
        private void Recreate()
        {
            LoadDTGVNhanVien();
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void LoadForm()
        {
            LoadDTGVNhanVien();
            txtTenNhanVien.Focus();
        }

        private void LoadDTGVNhanVien()
        {
            DataTable dtNhanVien = busNhanVien.GetForDisplay();
            dtgvNhanVien.DataSource = dtNhanVien;
            dtgvNhanVien.Columns["MANHANVIEN"].HeaderText = "Mã Nhân Viên";
            dtgvNhanVien.Columns["TENNHANVIEN"].HeaderText = "Tên Nhân Viên";
            dtgvNhanVien.Columns["USERNAME"].HeaderText = "Username";
            dtgvNhanVien.Columns["PASSWORD"].HeaderText = "Password";
            dtgvNhanVien.Columns["TYPE"].HeaderText = "Loại Nhân Viên";
            dtgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvNhanVien.Rows[e.RowIndex];
            txtMaNhanVien.Text = row.Cells[0].Value.ToString();
            txtTenNhanVien.Text = row.Cells[1].Value.ToString();
            txtUsername.Text = row.Cells[2].Value.ToString();
            txtPassword.Text = row.Cells[3].Value.ToString();
            if (row.Cells[4].Value.ToString() == "0")
            {
                rdbtnNVQuanTri.Checked = true;
                rdbtnNVBanVe.Checked = false;
            }     
            else
            {
                rdbtnNVQuanTri.Checked = false;
                rdbtnNVBanVe.Checked = true;
            }    
                
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
