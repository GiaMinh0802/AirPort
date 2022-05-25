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
    public partial class frmBaoCaoThang : Form
    {
        public frmBaoCaoThang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            
            string month = dtpThangNam.Value.Month.ToString();
            string year = dtpThangNam.Value.Year.ToString();
            DoanhThuBUS DoanhThuThang = new DoanhThuBUS();
            DataTable dtDoanhThuThang = DoanhThuThang.GetOfThangNam(month, year);
            dtgvThang.DataSource = dtDoanhThuThang;
            dtgvThang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvThang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            chartThang.Titles.Clear();
            DataTable chartDoanhThu = DoanhThuThang.GetOfNam(year);
            chartThang.DataSource = chartDoanhThu;
            chartThang.Series["Doanh Thu"].XValueMember = "THANG";
            chartThang.Series["Doanh Thu"].YValueMembers = "DOANHTHU";
            chartThang.Titles.Add("Doanh Thu Theo Tháng");
        }
    }
}
