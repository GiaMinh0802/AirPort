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
    public partial class frmTinhTrangVe : Form
    {
        ChuyenBayBUS busChuyenBay = new ChuyenBayBUS();
        TinhTrangVeBUS busTinhTrangVe = new TinhTrangVeBUS();
        string maChuyenBay;
        public frmTinhTrangVe(string maChuyenBay)
        {
            InitializeComponent();
            this.maChuyenBay = maChuyenBay;
            LoadForm();
        }

        private void LoadForm()
        {
            DataTable dtChuyenBay = busChuyenBay.Get();
            cboMaChuyenBay.DataSource = dtChuyenBay;
            cboMaChuyenBay.DisplayMember = "MACHUYENBAY";
            cboMaChuyenBay.ValueMember = "MACHUYENBAY";
            cboMaChuyenBay.SelectedValue = maChuyenBay;

            cboMaChuyenBay.Focus();
            LoadDtgv(maChuyenBay);

        }

        private void LoadDtgv(string maChuyenBay)
        {
            DataTable dtTinhTrangVe = busTinhTrangVe.GetForDisplayOfMaChuyenBay(maChuyenBay);
            dtgvTinhTrangVe.DataSource = dtTinhTrangVe;
            dtgvTinhTrangVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvTinhTrangVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void cboMaChuyenBay_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDtgv(cboMaChuyenBay.Text);
        }
    }
}
