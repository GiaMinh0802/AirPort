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
    public partial class frmQuanLyKhachHang : Form
    {
        #region Properties
        KhachHangBUS busKhachHang = new KhachHangBUS();
        #endregion


        #region Initializes
        public frmQuanLyKhachHang()
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
            LoadDTGVKhachHang();
            txtTenKhachHang.Clear();
            txtCMND.Clear();
            txtSDT.Clear();
        }

        private void LoadForm()
        {
            LoadDTGVKhachHang();
            txtTenKhachHang.Focus();
        }

        private void LoadDTGVKhachHang()
        {
            DataTable dtKhachHang = busKhachHang.GetForDisplay();
            dtgvKhachHang.DataSource = dtKhachHang;
            dtgvKhachHang.Columns["MAKHACHHANG"].HeaderText = "Mã Khách Hàng";
            dtgvKhachHang.Columns["TENKHACHHANG"].HeaderText = "Tên Khách Hàng";
            dtgvKhachHang.Columns["CMND"].HeaderText = "CMND";
            dtgvKhachHang.Columns["SDT"].HeaderText = "SĐT";
            dtgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvKhachHang.Rows[e.RowIndex];
            txtMaKhachHang.Text = row.Cells[0].Value.ToString();
            txtTenKhachHang.Text = row.Cells[1].Value.ToString();
            txtCMND.Text = row.Cells[2].Value.ToString();
            txtSDT.Text = row.Cells[3].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKhachHang.Text.Trim() != "")
            {
                if (txtTenKhachHang.Text.Trim() != "" && txtCMND.Text.Trim() != "" && txtSDT.Text.Trim() != "")
                {
                    try
                    {
                        KhachHangDTO dto = new KhachHangDTO(txtMaKhachHang.Text, txtTenKhachHang.Text, txtCMND.Text, txtSDT.Text);
                        if (busKhachHang.Update(dto))
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhachHang.Text.Trim() != "")
            {
                try
                {
                    if (busKhachHang.Delete(txtMaKhachHang.Text))
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgvKhachHang.DataSource = busKhachHang.SearchOfMaKhachHang(txtTimKiem.Text);
        }
        #endregion

    }
}
