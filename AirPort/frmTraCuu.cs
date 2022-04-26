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
        public frmTraCuu()
        {
            InitializeComponent();
            LoadForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }
        
        private void LoadForm()
        {
            if (txtMaChuyenBay.Text == "")
            {
                btnChonChuyenBay.Visible = false;
                lbBanVe.Visible = false;
                btnTimKiem.Location = new Point(125, 22);
                lbTimKiem.Location = new Point(123, 65);
            }
            txtMaChuyenBay.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnChonChuyenBay_Click(object sender, EventArgs e)
        {

        }
    }
}
