using BUS;
using DTO;
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
            if (txtSoSanBayTGMax.Text.Trim() != "" && txtTGBayMin.Text.Trim() != "" && txtTGDungMax.Text.Trim() != "" && txtTGDungMin.Text.Trim() != "" && txtTGMinDatVe.Text.Trim() != "" && txtTGMinHuyVe.Text.Trim() != "")
            {
                try
                {
                    ThamSoDTO dto = new ThamSoDTO(float.Parse(txtTGBayMin.Text), int.Parse(txtSoSanBayTGMax.Text), float.Parse(txtTGDungMin.Text), float.Parse(txtTGDungMax.Text), float.Parse(txtTGMinDatVe.Text), float.Parse(txtTGMinHuyVe.Text));
                    if (busThamSo.Update(dto))
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Recreate();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
