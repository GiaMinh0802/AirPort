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
    public partial class frmTraCuu : Form
    {
        #region Properties
        ComboBox cboMaChuyenBay;
        ChuyenBayBUS busChuyenBay = new ChuyenBayBUS();
        SanBayBUS busSanBay = new SanBayBUS();
        #endregion

        #region Initialize
        public frmTraCuu()
        {
            InitializeComponent();
        }

        public frmTraCuu(ComboBox cboMaChuyenBay)
        {
            InitializeComponent();
            this.cboMaChuyenBay = cboMaChuyenBay;
        }
        private void frmTraCuu_Shown(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (cboMaChuyenBay == null)
                this.Parent.Dispose();
            else
                this.Close();

        }
        #endregion

        #region Methods
        private void LoadForm()
        {
            cboSanBayDi.DataSource = busSanBay.Get();
            cboSanBayDi.DisplayMember = "TENSANBAY";
            cboSanBayDi.ValueMember = "MASANBAY";

            cboSanBayDen.DataSource = busSanBay.Get();
            cboSanBayDen.DisplayMember = "TENSANBAY";
            cboSanBayDen.ValueMember = "MASANBAY";

            if (cboMaChuyenBay == null)
            {
                btnChonChuyenBay.Visible = false;
                lbBanVe.Visible = false;
                btnTimKiem.Location = new Point(125, 22);
                lbTimKiem.Location = new Point(123, 65);
            }
            cboSanBayDi.Focus();
        }
        private void LoadDTGVChuyenBay(string maSanBayDen, string maSanBayDi, DateTime thoiGianKHTu, DateTime thoiGianKHDen)
        {
            dtgvChuyenBay.DataSource = busChuyenBay.Search(maSanBayDen, maSanBayDi, thoiGianKHTu, thoiGianKHDen);
            dtgvChuyenBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvChuyenBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        private void dtgvChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvChuyenBay.Rows[e.RowIndex];
            txtMaChuyenBay.Text = row.Cells[0].Value.ToString();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboSanBayDi.Text != "" && cboSanBayDen.Text != "" && dtpNgayKHTu.Text != "" && dtpNgayKHDen.Text != "")
            {
                try
                {
                    string maSanBayDi = cboSanBayDi.SelectedValue.ToString();
                    string maSanBayDen = cboSanBayDen.SelectedValue.ToString();
                    DateTime ngayKHTu = dtpNgayKHTu.Value;
                    DateTime ngayKHDen = dtpNgayKHDen.Value;
                    LoadDTGVChuyenBay(maSanBayDi, maSanBayDen, ngayKHTu, ngayKHDen);
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnBanVe_Click(object sender, EventArgs e)
        {
            cboMaChuyenBay.Text = txtMaChuyenBay.Text;
            this.Close();
        }
        #endregion
    }
}
