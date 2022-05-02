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
    public partial class frmQuanLyHangVe : Form
    {
        #region Properties
        HangVeBUS busHangVe = new HangVeBUS();
        #endregion

        #region Initializes
        public frmQuanLyHangVe()
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
            LoadDTGVHangVe();
            txtMaHangVe.Clear();
            txtTenHangVe.Clear();
        }

        private void LoadDTGVHangVe()
        {
            DataTable dtHangVe = busHangVe.GetForDisplay();
            dtgvHangVe.DataSource = dtHangVe;
            dtgvHangVe.Columns["MAHANGVE"].HeaderText = "Mã Hạng Vé";
            dtgvHangVe.Columns["TENHANGVE"].HeaderText = "Tên Hạng Vé";
            dtgvHangVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHangVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void LoadForm()
        {
            LoadDTGVHangVe();
            txtTenHangVe.Focus();
        }

        private void dtgvHangVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvHangVe.Rows[e.RowIndex];
            txtMaHangVe.Text = row.Cells[0].Value.ToString();
            txtTenHangVe.Text = row.Cells[1].Value.ToString();
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
