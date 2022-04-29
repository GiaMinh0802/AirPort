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
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            //var data = from acc in db.ACCOUNTs
            //        join nv in db.NHANVIENs
            //        on acc.MANHANVIEN equals nv.MANHANVIEN
            //        select new
            //        {
            //            MaNhanVien = nv.MANHANVIEN,
            //            TenNhanVien = nv.TENNHANVIEN,
            //            Username = acc.USERNAME,
            //            Password = acc.PASSWORD,
            //            Type = acc.TYPE
            //        };
            //dtgvNhanVien.DataSource = data;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
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
    }
}
