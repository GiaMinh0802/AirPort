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
        string maNhanVien;

        public frmBanVe(DataRow row)
        {
            InitializeComponent();
            this.maNhanVien = row["MANHANVIEN"].ToString();
            LoadForm();
        }
        private void LoadForm()
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

            ChuyenBayBUS busChuyenBay = new ChuyenBayBUS();
            DataTable dtCB = busChuyenBay.Get();
            cboMaChuyenBay.DataSource = dtCB;
            cboMaChuyenBay.DisplayMember = "MACHUYENBAY";
            cboMaChuyenBay.ValueMember = "MACHUYENBAY";

            HangVeBUS busHangVe = new HangVeBUS();
            DataTable dtHV = busHangVe.Get();
            cboHangVe.DataSource = dtHV;
            cboHangVe.DisplayMember = "TENHANGVE";
            cboHangVe.ValueMember = "MAHANGVE";
        }

        private void cboMaChuyenBay_SelectedValueChanged(object sender, EventArgs e)
        {
            //var query = from c in db.CHUYENBAYs
            //            join t in db.TUYENBAYs
            //            on c.MATUYENBAY equals t.MATUYENBAY
            //            join s1 in db.SANBAYs
            //            on t.MASANBAYDI equals s1.MASANBAY
            //            join s2 in db.SANBAYs
            //            on t.MASANBAYDEN equals s2.MASANBAY
            //            where c.MACHUYENBAY == cboMaChuyenBay.Text
            //            select new
            //            {
            //                MaChuyenBay = c.MACHUYENBAY,
            //                MaTuyenBay = t.MATUYENBAY,
            //                MaMayBay = c.MAMAYBAY,
            //                ThoiGianKhoiHanh = c.THOIGIANKHOIHANH,
            //                ThoiGianBay = c.THOIGIANBAY,
            //                TenSanBayDi = s1.TENSANBAY,
            //                TenSanBayDen = s2.TENSANBAY
            //            };
            //DataTable dtChuyenBay = cv.LINQResultToDataTable(query);
            //if (dtChuyenBay.Rows.Count == 0)
            //{
            //    txtMaTuyenBay.Clear();
            //    txtSanBayDi.Clear();
            //    txtSanBayDen.Clear();
            //    txtThoiGianKhoiHanh.Clear();
            //    txtThoiGIanBay.Clear();
            //}
            //else
            //{
            //    DataRow row = dtChuyenBay.Rows[0];
            //    txtMaTuyenBay.Text = row["MATUYENBAY"].ToString();
            //    txtSanBayDi.Text = row["TENSANBAYDI"].ToString();
            //    txtSanBayDen.Text = row["TENSANBAYDEN"].ToString();
            //    txtThoiGianKhoiHanh.Text = row["THOIGIANKHOIHANH"].ToString();
            //    txtThoiGIanBay.Text = row["THOIGIANBAY"].ToString();
            //    LoadDaTatxtSoGheTrong();
            //}
        }

        private void cboHangVe_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cboHangVe.SelectedValue != null)
            //{
            //    var query = from g in db.DONGIAs
            //                where g.MATUYENBAY == txtMaTuyenBay.Text && g.MAHANGVE == cboHangVe.SelectedValue.ToString()
            //                select g;
            //    DataTable dtDonGia = cv.LINQResultToDataTable(query);
            //    foreach (DataRow row in dtDonGia.Rows)
            //    {
            //        txtGiaTien.Text = row["DONGIA1"].ToString();
            //    }
            //    LoadDaTatxtSoGheTrong();
            //}
        }

        private void LoadDaTatxtSoGheTrong()
        {
            //if (cboHangVe.SelectedValue != null)
            //{
            //    var query = from i in db.TINHTRANGVEs
            //                where i.MACHUYENBAY == cboMaChuyenBay.Text && i.MAHANGVE == cboHangVe.SelectedValue.ToString()
            //                select i;
            //    DataTable dt = cv.LINQResultToDataTable(query);
            //    if (dt.Rows.Count != 0)
            //    {
            //        DataRow row = dt.Rows[0];
            //        txtSoGheTrong.Text = row["SOGHETRONG"].ToString();
            //    }
            //    else
            //    {
            //        txtSoGheTrong.Text = "0";
            //    }
            //}
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
