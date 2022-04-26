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
    public partial class frmBanVe : Form
    {
        public frmBanVe()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnMuaVe_Click(object sender, EventArgs e)
        {

        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {

        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            Form frm = new frmTraCuu();
            frm.Show();
        }
    }
}
