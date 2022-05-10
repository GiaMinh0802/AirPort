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
    public partial class frmQuanLySanBay : Form
    {

        #region Properties
        SanBayBUS busSanBay = new SanBayBUS();
        #endregion

        #region Initializes
        public frmQuanLySanBay()
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
            LoadDTGVSanBay();
            txtMaSanBay.Clear();
            txtTenSanBay.Clear();
            txtTenThanhPho.Clear();
            txtTenSanBay.Focus();
        }

        private void LoadForm()
        {
            LoadDTGVSanBay();
            txtTenSanBay.Focus();
        }

        private void LoadDTGVSanBay()
        {
            DataTable dtSanBay = busSanBay.GetForDisplay();
            dtgvSanBay.DataSource = dtSanBay;
            dtgvSanBay.Columns["MASANBAY"].HeaderText = "Mã Sân Bay";
            dtgvSanBay.Columns["TENSANBAY"].HeaderText = "Tên Sân Bay";
            dtgvSanBay.Columns["TENTHANHPHO"].HeaderText = "Tên Thành Phố";
            dtgvSanBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvSanBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvSanBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvSanBay.Rows[e.RowIndex];
            txtMaSanBay.Text = row.Cells[0].Value.ToString();
            txtTenSanBay.Text = row.Cells[1].Value.ToString();
            txtTenThanhPho.Text = row.Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSanBay.Text.Trim() != "")
            {
                try
                {
                    string maSanBay = txtMaSanBay.Text;
                    if (busSanBay.Delete(maSanBay))
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
            if (txtTenSanBay.Text.Trim() != "" && txtTenThanhPho.Text.Trim() != "")
            {
                if (busSanBay.CheckSanBay(txtTenSanBay.Text, txtTenThanhPho.Text))
                {
                    MessageBox.Show("Sân bay đã tồn tại, vui lòng nhập lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    SanBayDTO dto = new SanBayDTO(txtMaSanBay.Text, txtTenSanBay.Text, txtTenThanhPho.Text);
                    if (busSanBay.Add(dto))
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
            if (txtMaSanBay.Text.Trim() != "")
            {
                if (txtTenSanBay.Text.Trim() != "" && txtTenThanhPho.Text.Trim() != "")
                {
                    try
                    {
                        SanBayDTO dto = new SanBayDTO(txtMaSanBay.Text, txtTenSanBay.Text, txtTenThanhPho.Text);
                        if (busSanBay.Update(dto))
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
            dtgvSanBay.DataSource = busSanBay.SearchOfMaSanBay(txtTimKiem.Text);
        }
        #endregion        
    }
}
