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
    public partial class frmBaoCaoNam : Form
    {
        public frmBaoCaoNam()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            string year = dtpNam.Value.Year.ToString();
            DoanhThuBUS DoanhThuNam = new DoanhThuBUS();
            DataTable dtDoanhThuNam = DoanhThuNam.GetOfNam(year);
            dtgvNam.DataSource = dtDoanhThuNam;
            dtgvNam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvNam.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
    }
}
