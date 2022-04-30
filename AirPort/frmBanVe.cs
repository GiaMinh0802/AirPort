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
    public partial class frmBanVe : Form
    {
        VeChuyenBayBUS busVeChuyenBay = new VeChuyenBayBUS();
        ChuyenBayBUS busChuyenBay = new ChuyenBayBUS();
        HangVeBUS busHangVe = new HangVeBUS();
        DonGiaBUS busDonGia = new DonGiaBUS();
        TinhTrangVeBUS busTinhTrangVe = new TinhTrangVeBUS();
        string maNhanVien;

        public frmBanVe(DataRow row)
        {
            InitializeComponent();
            this.maNhanVien = row["MANHANVIEN"].ToString();
            LoadForm();
        }
        private void LoadForm()
        {
            DataTable dtCB = busChuyenBay.Get();
            cboMaChuyenBay.DataSource = dtCB;
            cboMaChuyenBay.DisplayMember = "MACHUYENBAY";
            cboMaChuyenBay.ValueMember = "MACHUYENBAY";

            
            DataTable dtHV = busHangVe.Get();
            cboHangVe.DataSource = dtHV;
            cboHangVe.DisplayMember = "TENHANGVE";
            cboHangVe.ValueMember = "MAHANGVE";

            LoadDTGV();
        }

        private void LoadDTGV()
        {
            DataTable dtVe = busVeChuyenBay.GetForDisplay();
            dtgvVe.DataSource = dtVe;
            dtgvVe.Columns["MaVe"].HeaderText = "Mã Vé";
            dtgvVe.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
            dtgvVe.Columns["CMND"].HeaderText = "CMND";
            dtgvVe.Columns["MaChuyenBay"].HeaderText = "Mã Chuyến Bay";
            dtgvVe.Columns["TenHangVe"].HeaderText = "Tên Hạng Vé";
            dtgvVe.Columns["GiaTien"].HeaderText = "Giá";
            dtgvVe.Columns["NgayGioGD"].HeaderText = "Ngày Giờ Giao Dịch";
            dtgvVe.Columns["NgayHuy"].HeaderText = "Ngày Hủy";
            dtgvVe.Columns["LoaiVe"].HeaderText = "Loại Vé";
            dtgvVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void ReLoadForm()
        {
            LoadDTGV();
            txtCMND.Clear();
            txtSDT.Clear();
            txtTenKhachHang.Clear();
            LoadDaTatxtSoGheTrong();
        }

        private void cboMaChuyenBay_SelectedValueChanged(object sender, EventArgs e)
        {

            DataTable dtChuyenBay = busChuyenBay.GetOfMaChuyenBay(cboMaChuyenBay.Text);
            if (dtChuyenBay.Rows.Count == 0)
            {
                txtMaTuyenBay.Clear();
                txtSanBayDi.Clear();
                txtSanBayDen.Clear();
                txtThoiGianKhoiHanh.Clear();
                txtThoiGIanBay.Clear();
            }
            else
            {
                DataRow row = dtChuyenBay.Rows[0];
                txtMaTuyenBay.Text = row["MATUYENBAY"].ToString();
                txtSanBayDi.Text = row["TENSANBAYDI"].ToString();
                txtSanBayDen.Text = row["TENSANBAYDEN"].ToString();
                txtThoiGianKhoiHanh.Text = row["THOIGIANKHOIHANH"].ToString();
                txtThoiGIanBay.Text = row["THOIGIANBAY"].ToString();
                LoadDaTatxtSoGheTrong();
            }
        }

        private void cboHangVe_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboHangVe.SelectedValue != null)
            {
                DataTable dtDonGia = busDonGia.SearchOfMaTuyenBayAndMaHangVe(txtMaTuyenBay.Text, cboHangVe.SelectedValue.ToString());
                foreach (DataRow row in dtDonGia.Rows)
                {
                    txtGiaTien.Text = row["DONGIA1"].ToString();
                }
                LoadDaTatxtSoGheTrong();
            }
        }

        private void LoadDaTatxtSoGheTrong()
        {
            if (cboHangVe.SelectedValue != null)
            {
                txtSoGheTrong.Text = busTinhTrangVe.GetSoGheTrongOfMaChuyenBayAndMaHangVe(cboMaChuyenBay.Text, cboHangVe.SelectedValue.ToString());
            }
        }

        private void dtgvVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvVe.Rows[e.RowIndex];
            txtCMND.Text = row.Cells[2].Value.ToString();
            cboMaChuyenBay.SelectedValue = row.Cells[3].Value.ToString();
            cboHangVe.Text = row.Cells[4].Value.ToString();
        }

        private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaTien.Text == "")
                return;
            string text = txtGiaTien.Text.Replace(",", "");
            decimal value = Convert.ToDecimal(text);
            txtGiaTien.Text = string.Format("{0:0,0}", value);
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            //var query = from i in db.KHACHHANGs
            //            where i.CMND == txtCMND.Text
            //            select i;
            //DataTable dtKhachHang = cv.LINQResultToDataTable(query);
            //if (dtKhachHang.Rows.Count == 0)
            //{
            //    txtTenKhachHang.Clear();
            //    txtSDT.Clear();
            //}
            //else
            //{
            //    DataRow row = dtKhachHang.Rows[0];
            //    txtTenKhachHang.Text = row["TENKHACHHANG"].ToString();
            //    txtSDT.Text = row["SDT"].ToString();
            //}
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnMuaVe_Click(object sender, EventArgs e)
        {

        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {

        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            Form frm = new frmTraCuu();
            frm.Show();
        }

        private void btnChiTietGheTrong_Click(object sender, EventArgs e)
        {
            Form frm = new frmTinhTrangVe(cboMaChuyenBay.Text);
            frm.Show();
        }

        
    }
}
