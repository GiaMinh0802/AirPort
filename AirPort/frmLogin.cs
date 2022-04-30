using BUS;
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
        #region Properties
        NhanVienBUS busNhanVien = new NhanVienBUS();
        #endregion

        #region Initializes
        public frmLogin()
        {
            InitializeComponent();
            LoadForm();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Methods
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                DataTable dt = busNhanVien.GetOfUsernameAndPassword(txtUsername.Text, txtPassword.Text);
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
        #endregion
    }
}
