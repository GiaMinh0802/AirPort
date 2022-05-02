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
    public partial class frmQuanLyMayBay : Form
    {
        #region Properties
        MayBayBUS busMayBay = new MayBayBUS();
        #endregion

        #region Initializes
        public frmQuanLyMayBay()
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
            LoadDTGVMayBay();
            txtMaMayBay.Clear();
            txtTenMayBay.Clear();
            txtSoLuongGhe.Clear();
            txtTenMayBay.Focus();
        }

        private void LoadForm()
        {
            LoadDTGVMayBay();
            txtTenMayBay.Focus();
        }

        private void LoadDTGVMayBay()
        {
            DataTable dtTuyenBay = busMayBay.GetForDisplay();
            dtgvMayBay.DataSource = dtTuyenBay;
            dtgvMayBay.Columns["MAMAYBAY"].HeaderText = "Mã Máy Bay";
            dtgvMayBay.Columns["TENMAYBAY"].HeaderText = "Tên Máy Bay";
            dtgvMayBay.Columns["SOLUONGGHE"].HeaderText = "Số Lượng Ghế";
            dtgvMayBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvMayBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvMayBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvMayBay.Rows[e.RowIndex];
            txtMaMayBay.Text = row.Cells[0].Value.ToString();
            txtTenMayBay.Text = row.Cells[1].Value.ToString();
            txtSoLuongGhe.Text = row.Cells[2].Value.ToString();
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
