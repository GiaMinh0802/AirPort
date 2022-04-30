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
    public partial class frmQuanLyChuyenBay : Form
    {
        #region Properties
        ChuyenBayBUS busChuyenBay = new ChuyenBayBUS();
        TinhTrangVeBUS busTinhTrangVe = new TinhTrangVeBUS();
        TuyenBayBUS busTuyenBay = new TuyenBayBUS();
        MayBayBUS busMayBay = new MayBayBUS();
        HangVeBUS busHangVe = new HangVeBUS();
        SanBayBUS busSanBay = new SanBayBUS();
        CTChuyenBayBUS busCTChuyenBay = new CTChuyenBayBUS();
        #endregion

        #region Initializes
        public frmQuanLyChuyenBay()
        {
            InitializeComponent();
        }

        private void LoadAll()
        {
            LoadFormChuyenBay();
            LoadFormHangVe();
            LoadFormSBTG();
        }

        private void frmQuanLyChuyenBay_Shown(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void gbxThemHangVeChoChuyenBay_CursorChanged(object sender, EventArgs e)
        {
            AcceptButton = btnThemHV;
        }

        private void gbxThemSanBayTGChoChuyenBay_CursorChanged(object sender, EventArgs e)
        {
            AcceptButton = btnThemSBTG;
        }

        private void gbxTTChuyenBay_CursorChanged(object sender, EventArgs e)
        {
            AcceptButton = btnThem;
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        #endregion

        #region ChuyenBay
        private void RecreateChuyenBay()
        {
            LoadDTGVChuyenBay();
            gbxThemHangVeChoChuyenBay.Enabled = false;
            gbxThemSanBayTGChoChuyenBay.Enabled = false;
        }

        private void LoadFormChuyenBay()
        {
            DataTable dtTuyenBay = busTuyenBay.Get();
            DataTable dtMayBay = busMayBay.Get();
            DataTable dtHangVe = busHangVe.Get();

            cboMaTuyenBay.DataSource = dtTuyenBay;
            cboMaTuyenBay.DisplayMember = "MATUYENBAY";
            cboMaTuyenBay.ValueMember = "MATUYENBAY";

            cboMaMayBay.DataSource = dtMayBay;
            cboMaMayBay.DisplayMember = "MAMAYBAY";
            cboMaMayBay.ValueMember = "MAMAYBAY";

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

            gbxThemHangVeChoChuyenBay.Enabled = false;
            gbxThemSanBayTGChoChuyenBay.Enabled = false;

            AcceptButton = btnThem;
            CancelButton = btnThoat;

            LoadDTGVChuyenBay();
        }
        
        private void LoadDTGVChuyenBay()
        {
            DataTable dtChuyenBay = busChuyenBay.GetToDisplay();
            dtgvChuyenBay.DataSource = dtChuyenBay;
            dtgvChuyenBay.Columns["MaChuyenBay"].HeaderText = "Mã Chuyến Bay";
            dtgvChuyenBay.Columns["MaTuyenBay"].HeaderText = "Mã Tuyến Bay";
            dtgvChuyenBay.Columns["MaMayBay"].HeaderText = "Mã Máy Bay";
            dtgvChuyenBay.Columns["ThoiGianKhoiHanh"].HeaderText = "Thời Gian Khởi Hành";
            dtgvChuyenBay.Columns["ThoiGianBay"].HeaderText = "Thời Gian Bay";
            dtgvChuyenBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvChuyenBay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void cboMaTuyenBay_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboMaTuyenBay.SelectedValue != null)
            {
                DataTable dtTuyenBay = busTuyenBay.GetOfMaTuyenBay(cboMaTuyenBay.SelectedValue.ToString());
                if (dtTuyenBay.Rows.Count == 0)
                    return;
                else
                {
                    DataRow row = dtTuyenBay.Rows[0];
                    cboSanBayDi.Text = row[2].ToString();
                    cboSanBayDi.SelectedValue = row[1].ToString();
                    cboSanBayDen.Text = row[4].ToString();
                    cboSanBayDen.SelectedValue = row[3].ToString();
                }    
            }
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

        private void dtgvChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvChuyenBay.Rows[e.RowIndex];
            txtMaChuyenBay.Text = row.Cells[0].Value.ToString();
            cboMaTuyenBay.Text = row.Cells[1].Value.ToString();
            cboMaMayBay.Text = row.Cells[2].Value.ToString();
            dtpkThoiGianKhoiHanh.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
            txtThoiGianBay.Text = row.Cells[4].Value.ToString();

            gbxThemHangVeChoChuyenBay.Enabled = true;
            gbxThemSanBayTGChoChuyenBay.Enabled = true;

            LoadDTGVHangVeOfChuyenBay();
            LoadDTGVSanBayTG();
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region HangVe
        bool flagHangVeCellClick = false;
        private void RecreateHangVe()
        {
            LoadDTGVHangVeOfChuyenBay();
            txtTongSoGhe.Text = "";
            flagHangVeCellClick = false;
        }

        private void LoadFormHangVe()
        {
            DataTable dtHangVe = busHangVe.Get();
            cboMaHangVe.DataSource = dtHangVe;
            cboMaHangVe.DisplayMember = "TENHANGVE";
            cboMaHangVe.ValueMember = "MAHANGVE";
        }

        private void LoadDTGVHangVeOfChuyenBay()
        {
            DataTable dtTinhTrangVe = busTinhTrangVe.GetForDisplayOfMaChuyenBay(txtMaChuyenBay.Text);
            dtgvHangVe.DataSource = dtTinhTrangVe;
            dtgvHangVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHangVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvHangVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvHangVe.Rows[e.RowIndex];
            cboMaHangVe.Text = row.Cells[0].Value.ToString();
            txtTongSoGhe.Text = row.Cells[1].Value.ToString();

            flagHangVeCellClick = true;
        }

        private void btnThemHV_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaHV_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaHV_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region SBTG
        bool flagSBTGCellClick = false;
        private void RecreateSBTG()
        {
            LoadDTGVSanBayTG();
            txtThoiGianNghi.Clear();
            txtGhiChu.Clear();
            flagSBTGCellClick = false;
        }

        private void LoadFormSBTG()
        {
            DataTable dtSanBay = busSanBay.Get();
            cboTenSanBayTG.DataSource = dtSanBay;
            cboTenSanBayTG.DisplayMember = "TENSANBAY";
            cboTenSanBayTG.ValueMember = "MASANBAY";
        }

        private void LoadDTGVSanBayTG()
        {
            DataTable dtCTChuyenBay = busCTChuyenBay.GetForDisplayOfMaChuyenBay(txtMaChuyenBay.Text);
            dtgvSanBayTG.DataSource = dtCTChuyenBay;
            dtgvSanBayTG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvSanBayTG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dtgvSanBayTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvSanBayTG.Rows[e.RowIndex];
            cboTenSanBayTG.Text = row.Cells[0].Value.ToString();
            txtThoiGianNghi.Text = row.Cells[1].Value.ToString();
            txtGhiChu.Text = row.Cells[2].Value.ToString();

            flagSBTGCellClick = true;
        }

        private void btnThemSBTG_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaSBTG_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaSBTG_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
