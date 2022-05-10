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
    public partial class frmQuanLyTuyenBay : Form
    {
        #region Properties
        TuyenBayBUS busTuyenBay = new TuyenBayBUS();
        SanBayBUS busSanBay = new SanBayBUS();
        #endregion

        #region Initializes
        public frmQuanLyTuyenBay()
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
        private void LoadForm()
        {
            
            DataTable dtSanBayDen = busSanBay.Get();
            DataTable dtSanBayDi = busSanBay.Get();

            cboSanBayDen.DataSource = dtSanBayDen;
            cboSanBayDen.DisplayMember = "TENSANBAY";
            cboSanBayDen.ValueMember = "MASANBAY";

            cboSanBayDi.DataSource = dtSanBayDi;
            cboSanBayDi.DisplayMember = "TENSANBAY";
            cboSanBayDi.ValueMember = "MASANBAY";

            LoadDTGVTuyenBay();

            cboSanBayDi.Focus();
        }

        private void LoadDTGVTuyenBay()
        {
            DataTable dtTuyenBay = busTuyenBay.GetForDSTuyenBay();
            dtgvTuyenBay.DataSource = dtTuyenBay;
            dtgvTuyenBay.Columns["MATUYENBAY"].HeaderText = "Mã Tuyến Bay";
            dtgvTuyenBay.Columns["TenSanBayDi"].HeaderText = "Tên Sân Bay Đi";
            dtgvTuyenBay.Columns["TenSanBayDen"].HeaderText = "Tên Sân Bay Đến";
            dtgvTuyenBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvTuyenBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void Recreate()
        {
            LoadDTGVTuyenBay();
            txtMaTuyenBay.Clear();
            cboSanBayDen.Text = "";
            cboSanBayDi.Text = "";
            cboSanBayDi.Focus();
        }

        private void dtgvTuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvTuyenBay.Rows[e.RowIndex];
            txtMaTuyenBay.Text = row.Cells[0].Value.ToString();
            cboSanBayDi.Text = row.Cells[1].Value.ToString();
            cboSanBayDen.Text = row.Cells[2].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgvTuyenBay.DataSource = busTuyenBay.SearchOfMaTuyenBay(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanBayDen.Text.Trim() != "" && cboSanBayDi.Text.Trim() != "")
            {
                if (cboSanBayDi.Text == cboSanBayDen.Text)
                {
                    MessageBox.Show("Sân bay đến và sân bay đi phải khác nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    TuyenBayDTO dto = new TuyenBayDTO(txtMaTuyenBay.Text, cboSanBayDi.SelectedValue.ToString(), cboSanBayDen.SelectedValue.ToString());
                    if (busTuyenBay.Add(dto))
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
            if (txtMaTuyenBay.Text.Trim() != "")
            {
                if (cboSanBayDen.Text.Trim() != "" && cboSanBayDi.Text.Trim() != "")
                {
                    if (cboSanBayDi.Text == cboSanBayDen.Text)
                    {
                        MessageBox.Show("Sân bay đến và sân bay đi phải khác nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {
                        TuyenBayDTO dto = new TuyenBayDTO(txtMaTuyenBay.Text, cboSanBayDi.SelectedValue.ToString(), cboSanBayDen.SelectedValue.ToString());
                        if (busTuyenBay.Update(dto))
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
            if (txtMaTuyenBay.Text.Trim() != "")
            {
                try
                {
                    if (busTuyenBay.Delete(txtMaTuyenBay.Text))
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
        #endregion
    }
}
