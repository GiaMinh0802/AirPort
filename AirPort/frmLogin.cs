using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirPort
{
    public partial class frmLogin : Form
    {
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        public frmLogin()
        {
            InitializeComponent();
            LoadForm();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                var dtAcc = from acc in db.ACCOUNTs
                                     where acc.USERNAME == txtUsername.Text && acc.PASSWORD == txtPassword.Text
                                     select acc;
                ConvertToDataTable cv = new ConvertToDataTable();
                DataTable dt = cv.LINQResultToDataTable(dtAcc);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Form frm = new frmMain(row);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadForm()
        {
            txtUsername.Focus();
            
            txtUsername.TabIndex = 0;
            txtPassword.TabIndex = 1;
            btnDangNhap.TabIndex = 2;
            btnThoat.TabIndex = 3;

            txtPassword.UseSystemPasswordChar = true;

            AcceptButton = btnDangNhap;
            CancelButton = btnThoat;
        }
    }
}
