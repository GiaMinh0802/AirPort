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
    public partial class frmQuanLyDonGia : Form
    {
        #region Properties
        DonGiaBUS busDonGia = new DonGiaBUS();
        TuyenBayBUS busTuyenBay = new TuyenBayBUS();
        HangVeBUS busHangVe = new HangVeBUS();
        SanBayBUS busSanBay = new SanBayBUS();
        bool flagCellClick;
        #endregion

        #region Initializes
        public frmQuanLyDonGia()
        {
            InitializeComponent();
            flagCellClick = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }
        #endregion

        #region Methods

        private void Recreate()
        {
            LoadDTGVDonGia();
            txtDonGia.Clear();
        }

        private void LoadForm()
        {
            DataTable dtTuyenBay = busTuyenBay.Get();
            cboMaTuyenBay.DataSource = dtTuyenBay;
            cboMaTuyenBay.DisplayMember = "MATUYENBAY";
            cboMaTuyenBay.ValueMember = "MATUYENBAY";

            DataTable dtHangVe = busHangVe.Get();
            cboMaHangVe.DataSource = dtHangVe;
            cboMaHangVe.DisplayMember = "TENHANGVE";
            cboMaHangVe.ValueMember = "MAHANGVE";

            DataTable dtSanBayDi = busSanBay.Get();
            cboSanBayDi.DataSource = dtSanBayDi;
            cboSanBayDi.DisplayMember = "TENSANBAY";
            cboSanBayDi.ValueMember = "MASANBAY";

            DataTable dtSanBayDen = busSanBay.Get();
            cboSanBayDen.DataSource = dtSanBayDen;
            cboSanBayDen.DisplayMember = "TENSANBAY";
            cboSanBayDen.ValueMember = "MASANBAY";

            LoadDTGVDonGia();

            cboSanBayDi.Focus();
        }

        private void LoadDTGVDonGia()
        {
            DataTable dtDonGia = busDonGia.GetForDisplay();
            dtgvDonGia.DataSource = dtDonGia;
            dtgvDonGia.Columns["MATUYENBAY"].HeaderText = "Mã Tuyến Bay";
            dtgvDonGia.Columns["MAHANGVE"].HeaderText = "Mã Hạng Vé";
            dtgvDonGia.Columns["DONGIA1"].HeaderText = "Đơn Giá";
            dtgvDonGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvDonGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dtgvDonGia.Columns[2].DefaultCellStyle.Format = "#,####.####";
        }

        private void dtgvDonGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvDonGia.Rows[e.RowIndex];
            cboMaTuyenBay.SelectedValue = row.Cells[0].Value.ToString();
            cboMaHangVe.SelectedValue = row.Cells[1].Value.ToString();
            txtDonGia.Text = row.Cells[2].Value.ToString();
            flagCellClick = true;
            cboMaTuyenBay_SelectionChangeCommitted(sender, e);
        }
        private void cboMaTuyenBay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtTuyenBay = busTuyenBay.GetOfMaTuyenBay(cboMaTuyenBay.SelectedValue.ToString());
            if (dtTuyenBay.Rows.Count == 0)
                return;
            DataRow row = dtTuyenBay.Rows[0];

            cboSanBayDi.SelectedValue = row["MaSanBayDi"].ToString();

            cboSanBayDen.SelectedValue = row["MaSanBayDen"].ToString();
        }

        private void cboSanBayDi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtTuyenBay = busTuyenBay.GetOfMaSanBay(cboSanBayDi.SelectedValue.ToString(), cboSanBayDen.SelectedValue.ToString());
            if (dtTuyenBay.Rows.Count == 0)
            {
                cboMaTuyenBay.Text = "";
            }
            else
            {
                DataRow row = dtTuyenBay.Rows[0];
                cboMaTuyenBay.Text = row["MATUYENBAY"].ToString();
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                lbDonGia.Text = "";
                return;
            }
            decimal value = Convert.ToDecimal(txtDonGia.Text);
            lbDonGia.Text = string.Format("{0:0,0 VNĐ}", value);
        }

        private void frmQuanLyDonGia_Shown(object sender, EventArgs e)
        {
            LoadForm();
            cboMaTuyenBay_SelectionChangeCommitted(sender, e);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (flagCellClick)
            {

                if (cboSanBayDi.Text == cboSanBayDen.Text)
                {
                    MessageBox.Show("Sân bay đến và sân bay đi phải khác nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboSanBayDen.Text.Trim() != "" && cboSanBayDi.Text.Trim() != "")
                {
                    try
                    {
                        DonGiaDTO dto = new DonGiaDTO(cboMaTuyenBay.Text, cboMaHangVe.SelectedValue.ToString(), Convert.ToInt32(txtDonGia.Text));
                        if (busDonGia.Update(dto))
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
                        flagCellClick = false;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboMaTuyenBay.Text.Trim() != "" && cboMaHangVe.Text.Trim() != "" && txtDonGia.Text != "")
            {
                if (cboSanBayDi.Text == cboSanBayDen.Text)
                {
                    MessageBox.Show("Sân bay đến và sân bay đi phải khác nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    DonGiaDTO dto = new DonGiaDTO(cboMaTuyenBay.Text, cboMaHangVe.SelectedValue.ToString(), Convert.ToInt32(txtDonGia.Text));
                    if (busDonGia.Add(dto))
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (flagCellClick)
            {
                try
                {
                    DonGiaDTO dto = new DonGiaDTO(cboMaTuyenBay.Text, cboMaHangVe.SelectedValue.ToString(), Convert.ToInt32(txtDonGia.Text));
                    if (busDonGia.Delete(dto))
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
                    flagCellClick = false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgvDonGia.DataSource = busDonGia.SearchOfMaTuyenBay(txtTimKiem.Text);
        }
        #endregion

        
    }
}
