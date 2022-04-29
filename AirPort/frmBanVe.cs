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
        AirPortDataContextDataContext db = new AirPortDataContextDataContext();
        ConvertToDataTable cv = new ConvertToDataTable();
        string maNhanVien;
        public frmBanVe(DataRow row)
        {
            InitializeComponent();
            this.maNhanVien = row["MANHANVIEN"].ToString();
            LoadForm();
        }
        private void LoadForm()
        {
            var dtVe = from v in db.VECHUYENBAYs
                        join k in db.KHACHHANGs
                        on v.MAKHACHHANG equals k.MAKHACHHANG
                        join h in db.HANGVEs
                        on v.MAHANGVE equals h.MAHANGVE
                        select new
                        {
                            MaVe = v.MAHANGVE,
                            TenKhachHang = k.TENKHACHHANG,
                            CMND = k.CMND,
                            MaChuyenBay = v.MACHUYENBAY,
                            TenHangVe = h.TENHANGVE,
                            GiaTien = v.GIATIEN,
                            NgayGioGD = v.NGAYGIOGD,
                            NgayHuy = v.NGAYHUY,
                            LoaiVe = v.LOAIVE
                        };
            DataTable dtV = cv.LINQResultToDataTable(dtVe);
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

            var dtChuyenBay = from i in db.CHUYENBAYs select i;
            DataTable dtCB = cv.LINQResultToDataTable(dtChuyenBay);
            cboMaChuyenBay.DataSource = dtCB;
            cboMaChuyenBay.DisplayMember = "MACHUYENBAY";
            cboMaChuyenBay.ValueMember = "MACHUYENBAY";

            var dtHangVe = from i in db.HANGVEs select i;
            DataTable dtHV = cv.LINQResultToDataTable(dtHangVe);
            cboHangVe.DataSource = dtHV;
            cboHangVe.DisplayMember = "TENHANGVE";
            cboHangVe.ValueMember = "MAHANGVE";
        }

        private void cboMaChuyenBay_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void LoadDaTatxtSoGheTrong()
        {
            if (cboHangVe.SelectedValue != null)
            {
                var query = from i in db.TINHTRANGVEs
                            where i.MACHUYENBAY == cboMaChuyenBay.Text && i.MAHANGVE == cboHangVe.SelectedValue.ToString()
                            select i;
                DataTable dt = cv.LINQResultToDataTable(query);
                if (dt.Rows.Count != 0)
                {
                    DataRow row = dt.Rows[0];
                    txtSoGheTrong.Text = row[0].ToString();
                }
                else
                {
                    txtSoGheTrong.Text = "0";
                }
            }
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
            Form frm = new frmTinhTrangVe();
            frm.Show();
        }

        
    }
}
