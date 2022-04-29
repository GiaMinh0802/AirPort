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
        string maChuyenBay;
        public frmTinhTrangVe(string maChuyenBay)
        {
            InitializeComponent();
            this.maChuyenBay = maChuyenBay;
            LoadForm();
        }

        private void LoadForm()
        {
            //var query = from s in db.CHUYENBAYs
            //            select s;
            //DataTable dtChuyenBay = cv.LINQResultToDataTable(query);
            //cboMaChuyenBay.DataSource = dtChuyenBay;
            //cboMaChuyenBay.DisplayMember = "MACHUYENBAY";
            //cboMaChuyenBay.ValueMember = "MACHUYENBAY";
            //cboMaChuyenBay.SelectedValue = maChuyenBay;

            //cboMaChuyenBay.Focus();

        }

        private void LoadDtgv(string maChuyenBay)
        {
            //var query = from t in db.TINHTRANGVEs
            //            join h in db.HANGVEs
            //            on t.MAHANGVE equals h.MAHANGVE
            //            where t.MACHUYENBAY == maChuyenBay
            //            select new
            //            {
            //                TenHangVe = h.TENHANGVE,
            //                TongSoGhe = t.TONGSOGHE,
            //                SoGheTrong = t.SOGHETRONG
            //            };
            //DataTable dtTinhTrangVe = cv.LINQResultToDataTable(query);
            //dtgvTinhTrangVe.DataSource = dtTinhTrangVe;
            //dtgvTinhTrangVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dtgvTinhTrangVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void cboMaChuyenBay_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDtgv(cboMaChuyenBay.Text);
        }
    }
}
