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
    public partial class frmThayDoiQuyDinh : Form
    {
        #region Properties
        ThamSoBUS busThamSo = new ThamSoBUS();
        bool flagCellClick;
        #endregion

        #region Initializes
        public frmThayDoiQuyDinh()
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
            DataTable dtThamSo = busThamSo.Get();
            if (dtThamSo.Rows.Count != 0)
            {
                DataRow row = dtThamSo.Rows[0];
                txtTGBayMin.Text = row[0].ToString();
                txtSoSanBayTGMax.Text = row[1].ToString();
                txtTGDungMin.Text = row[2].ToString();
                txtTGDungMax.Text = row[3].ToString();
                txtTGMinDatVe.Text = row[4].ToString();
                txtTGMinHuyVe.Text = row[5].ToString();
            }
        }

        private void LoadForm()
        {
            DataTable dtThamSo = busThamSo.Get();
            if (dtThamSo.Rows.Count != 0)
            {
                DataRow row = dtThamSo.Rows[0];
                txtTGBayMin.Text = row[0].ToString();
                txtSoSanBayTGMax.Text = row[1].ToString();
                txtTGDungMin.Text = row[2].ToString();
                txtTGDungMax.Text = row[3].ToString();
                txtTGMinDatVe.Text = row[4].ToString();
                txtTGMinHuyVe.Text = row[5].ToString();
            }
            AcceptButton = btnSua;
            CancelButton = btnThoat;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
