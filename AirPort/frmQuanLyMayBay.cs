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
    public partial class frmQuanLyMayBay : Form
    {
        #region Properties
        MayBayBUS busMayBay = new MayBayBUS();
        #endregion

        #region Initializes
        public frmQuanLyMayBay()
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
            LoadDTGVMayBay();
            txtMaMayBay.Clear();
            txtTenMayBay.Clear();
            txtSoLuongGhe.Clear();
            txtTenMayBay.Focus();
        }

        private void LoadForm()
        {
            LoadDTGVMayBay();
            txtTenMayBay.Focus();
        }

        private void LoadDTGVMayBay()
        {
            DataTable dtTuyenBay = busMayBay.GetForDisplay();
            dtgvMayBay.DataSource = dtTuyenBay;
            dtgvMayBay.Columns["MAMAYBAY"].HeaderText = "Mã Máy Bay";
            dtgvMayBay.Columns["TENMAYBAY"].HeaderText = "Tên Máy Bay";
            dtgvMayBay.Columns["SOLUONGGHE"].HeaderText = "Số Lượng Ghế";
            dtgvMayBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvMayBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvMayBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvMayBay.Rows[e.RowIndex];
            txtMaMayBay.Text = row.Cells[0].Value.ToString();
            txtTenMayBay.Text = row.Cells[1].Value.ToString();
            txtSoLuongGhe.Text = row.Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaMayBay.Text.Trim() != "")
            {
                try
                {
                    if (busMayBay.Delete(txtMaMayBay.Text))
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch
                {
                    MessageBox.Show("Xóa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Recreate();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenMayBay.Text.Trim() != "" && txtSoLuongGhe.Text.Trim() != "")
            {
                try
                {
                    MayBayDTO dto = new MayBayDTO(txtMaMayBay.Text, txtTenMayBay.Text, Convert.ToInt32(txtSoLuongGhe.Text));
                    if (busMayBay.Add(dto))
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaMayBay.Text.Trim() != "")
            {
                if (txtTenMayBay.Text.Trim() != "" && txtSoLuongGhe.Text.Trim() != "")
                {
                    try
                    {
                        MayBayDTO dto = new MayBayDTO(txtMaMayBay.Text, txtTenMayBay.Text, Convert.ToInt32(txtSoLuongGhe.Text));
                        if (busMayBay.Update(dto))
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
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgvMayBay.DataSource = busMayBay.SearchOfMaMayBay(txtTimKiem.Text);
        }

        #endregion
    }
}
