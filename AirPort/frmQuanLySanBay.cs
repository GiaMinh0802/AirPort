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
    public partial class frmQuanLySanBay : Form
    {

        #region Properties
        SanBayBUS busSanBay = new SanBayBUS();
        #endregion

        #region Initializes
        public frmQuanLySanBay()
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
            LoadDTGVSanBay();
            txtMaSanBay.Clear();
            txtTenSanBay.Clear();
            txtTenThanhPho.Clear();
            txtTenSanBay.Focus();
        }

        private void LoadForm()
        {
            LoadDTGVSanBay();
            txtTenSanBay.Focus();
        }

        private void LoadDTGVSanBay()
        {
            DataTable dtSanBay = busSanBay.GetForDisplay();
            dtgvSanBay.DataSource = dtSanBay;
            dtgvSanBay.Columns["MASANBAY"].HeaderText = "Mã Sân Bay";
            dtgvSanBay.Columns["TENSANBAY"].HeaderText = "Tên Sân Bay";
            dtgvSanBay.Columns["TENTHANHPHO"].HeaderText = "Tên Thành Phố";
            dtgvSanBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvSanBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvSanBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvSanBay.Rows[e.RowIndex];
            txtMaSanBay.Text = row.Cells[0].Value.ToString();
            txtTenSanBay.Text = row.Cells[1].Value.ToString();
            txtTenThanhPho.Text = row.Cells[2].Value.ToString();
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
