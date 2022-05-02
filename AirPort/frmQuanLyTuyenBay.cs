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
    public partial class frmQuanLyTuyenBay : Form
    {
        #region Properties
        TuyenBayBUS busTuyenBay = new TuyenBayBUS();
        SanBayBUS busSanBay = new SanBayBUS();
        #endregion

        #region Initializes
        public frmQuanLyTuyenBay()
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
        private void LoadForm()
        {
            
            DataTable dtSanBayDen = busSanBay.Get();
            DataTable dtSanBayDi = busSanBay.Get();

            cboSanBayDen.DataSource = dtSanBayDen;
            cboSanBayDen.DisplayMember = "TENSANBAY";
            cboSanBayDen.ValueMember = "MASANBAY";

            cboSanBayDi.DataSource = dtSanBayDi;
            cboSanBayDi.DisplayMember = "TENSANBAY";
            cboSanBayDi.ValueMember = "MASANBAY";

            LoadDTGVTuyenBay();

            cboSanBayDi.Focus();
        }

        private void LoadDTGVTuyenBay()
        {
            DataTable dtTuyenBay = busTuyenBay.GetForDSTuyenBay();
            dtgvTuyenBay.DataSource = dtTuyenBay;
            dtgvTuyenBay.Columns["MATUYENBAY"].HeaderText = "Mã Tuyến Bay";
            dtgvTuyenBay.Columns["TenSanBayDi"].HeaderText = "Tên Sân Bay Đi";
            dtgvTuyenBay.Columns["TenSanBayDen"].HeaderText = "Tên Sân Bay Đến";
            dtgvTuyenBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvTuyenBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void Recreate()
        {
            LoadDTGVTuyenBay();
            txtMaTuyenBay.Clear();
            cboSanBayDen.Text = "";
            cboSanBayDi.Text = "";
            cboSanBayDi.Focus();
        }

        private void dtgvTuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvTuyenBay.Rows[e.RowIndex];
            txtMaTuyenBay.Text = row.Cells[0].Value.ToString();
            cboSanBayDi.Text = row.Cells[1].Value.ToString();
            cboSanBayDen.Text = row.Cells[2].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
