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
    public partial class frmBanVe : Form
    {
        #region Properties
        VeChuyenBayBUS busVeChuyenBay = new VeChuyenBayBUS();
        ChuyenBayBUS busChuyenBay = new ChuyenBayBUS();
        HangVeBUS busHangVe = new HangVeBUS();
        DonGiaBUS busDonGia = new DonGiaBUS();
        TinhTrangVeBUS busTinhTrangVe = new TinhTrangVeBUS();
        KhachHangBUS busKhachHang = new KhachHangBUS();
        string maNhanVien;
        string maVe;
        int SoVe = 0;
        int SoVeDau = 0;
        string GheTruoc = "";
        List<int> arr = new List<int>();
        #endregion

        #region Initializes
        public frmBanVe(DataRow row)
        {
            InitializeComponent();
            this.maNhanVien = row["MANHANVIEN"].ToString();
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
            dtgvVe.Columns["VeGhe"].HeaderText = "Vé Ghế";
            dtgvVe.Columns["KyGui"].HeaderText = "Ký Gửi";
            dtgvVe.Columns["LoaiVe"].HeaderText = "Loại Vé";           
            dtgvVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void Recreate()
        {
            LoadDTGV();
            txtCMND.Clear();
            txtSDT.Clear();
            txtTenKhachHang.Clear();
            txtViTri.Clear();
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
            this.maVe = row.Cells[0].Value.ToString();
            txtViTri.Text = row.Cells[7].Value.ToString();
            txtKyGui.Text = row.Cells[8].Value.ToString();
        }

        private void txtKyGui_Leave(object sender, EventArgs e)
        {
            int Sokg = Convert.ToInt32(txtKyGui.Text);
            DataTable dtDonGia = busDonGia.SearchOfMaTuyenBayAndMaHangVe(txtMaTuyenBay.Text, cboHangVe.SelectedValue.ToString());
            foreach (DataRow row in dtDonGia.Rows)
            {
                txtGiaTien.Text = (Convert.ToInt32(row["DONGIA1"]) * this.SoVe + Sokg * 20000).ToString();
            }
        }
        private void txtViTri_TextChanged(object sender, EventArgs e)
        {
            this.SoVe = Convert.ToInt32(txtViTri.Text.Length/3);
            DataTable dtDonGia = busDonGia.SearchOfMaTuyenBayAndMaHangVe(txtMaTuyenBay.Text, cboHangVe.SelectedValue.ToString());
            foreach (DataRow row in dtDonGia.Rows)
            {
                if (txtViTri.Text != "")
                    txtGiaTien.Text = (Convert.ToInt32(row["DONGIA1"])*this.SoVe).ToString();
                else
                    txtGiaTien.Text = (row["DONGIA1"]).ToString();
            }
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
            DataTable dtKhachHang = busKhachHang.GetOfCMND(txtCMND.Text);
            if (dtKhachHang.Rows.Count == 0)
            {
                txtTenKhachHang.Clear();
                txtSDT.Clear();
            }
            else
            {
                DataRow row = dtKhachHang.Rows[0];
                txtTenKhachHang.Text = row["TENKHACHHANG"].ToString();
                txtSDT.Text = row["SDT"].ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgvVe.DataSource = busVeChuyenBay.SearchOfSDT(txtTimKiem.Text);
        }

        private void btnMuaVe_Click(object sender, EventArgs e)
        {
            if (txtSoGheTrong.Text == "0" || txtSoGheTrong.Text == "")
            {
                MessageBox.Show("Không còn vé cho hạng vé này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboMaChuyenBay.Text.Trim() != "" && txtCMND.Text.Trim() != "" && txtTenKhachHang.Text.Trim() != "" && txtSDT.Text.Trim() != "" && cboHangVe.Text.Trim() != "")
            {
                string giokhoihang = txtThoiGianKhoiHanh.Text;
                DateTime giobay = DateTime.Parse(giokhoihang);
                if (giobay > DateTime.Now)
                {
                    try
                    {
                        string maKhachHang;
                        string loaiVe = "Vé mua";
                        DataTable dtKhachHang = busKhachHang.GetOfCMND(txtCMND.Text);

                        if (dtKhachHang.Rows.Count > 0)
                        {
                            DataRow row = dtKhachHang.Rows[0];
                            maKhachHang = row["MAKHACHHANG"].ToString();
                        }
                        else
                        {
                            KhachHangDTO dtoKhachHang = new KhachHangDTO(null, txtTenKhachHang.Text, txtCMND.Text, txtSDT.Text);
                            if (!busKhachHang.Add(dtoKhachHang))
                            {
                                MessageBox.Show("Thêm khách hàng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Recreate();
                                return;
                            }
                            dtKhachHang = busKhachHang.GetOfCMND(txtCMND.Text);
                            DataRow row = dtKhachHang.Rows[0];
                            maKhachHang = row["MAKHACHHANG"].ToString();
                        }
                        arr.Clear();
                        string maHangVe = busHangVe.GetMaHangVeByTenHangVe(cboHangVe.Text);
                        string sodoghe = busTinhTrangVe.GetSoDoGheByMaChuyenBayAndMaHangVe(cboMaChuyenBay.Text, maHangVe);
                        string ghe = txtViTri.Text;
                        for (int i = 0; i < ghe.Length; i += 3)
                        {
                            int index = 0;
                            string temp = ghe.Substring(i, 2);
                            if (temp[0] == 'A')
                            {
                                index = Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'B')
                            {
                                index = 10 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }    
                                
                            else if (temp[0] == 'C')
                            {
                                index = 20 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'D')
                            {
                                index = 30 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'E')
                            {
                                index = 40 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'F')
                            {
                                index = 50 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'G')
                            {
                                index = 60 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'H')
                            {
                                index = 70 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                        }
                        int sove = Convert.ToInt32(txtViTri.Text.Length / 3);
                        foreach (int i in arr)
                            sodoghe = sodoghe.Remove(i, 1).Insert(i, "1");
                        TinhTrangVeDTO dtoTinhTrangVe = new TinhTrangVeDTO(cboMaChuyenBay.Text, maHangVe, 0, Convert.ToInt32(txtSoGheTrong.Text) - sove, sodoghe);
                        VeChuyenBayDTO dtoVeChuyenBay = new VeChuyenBayDTO(null, maKhachHang, cboMaChuyenBay.Text, cboHangVe.SelectedValue.ToString(), maNhanVien, Convert.ToDecimal(txtGiaTien.Text), DateTime.Now, Convert.ToDateTime(null), loaiVe, txtViTri.Text.ToString(), Convert.ToInt32(txtKyGui.Text));
                        if (busTinhTrangVe.UpdateBanVe(dtoTinhTrangVe))
                            if (busVeChuyenBay.Add(dtoVeChuyenBay))
                                MessageBox.Show("Mua vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Mua vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Mua vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show("Mua vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Recreate();
                    }
                }
                else
                    MessageBox.Show("Chuyến bay đã khởi hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            string giokhoihang = txtThoiGianKhoiHanh.Text;
            DateTime giobay = DateTime.Parse(giokhoihang);
            if (cboMaChuyenBay.Text.Trim() != "" && txtCMND.Text.Trim() != "" && txtTenKhachHang.Text.Trim() != "" && txtSDT.Text.Trim() != "" && cboHangVe.Text.Trim() != "")
            {
                if (giobay > DateTime.Now)
                {
                    try
                    {
                        string maKhachHang;
                        string loaiVe = "Vé đặt";
                        DataTable dtKhachHang = busKhachHang.GetOfCMND(txtCMND.Text);
                        if (dtKhachHang.Rows.Count > 0)
                        {
                            DataRow row = dtKhachHang.Rows[0];
                            maKhachHang = row["MAKHACHHANG"].ToString();
                        }
                        else
                        {
                            KhachHangDTO dtoKhachHang = new KhachHangDTO(null, txtTenKhachHang.Text, txtCMND.Text, txtSDT.Text);
                            if (!busKhachHang.Add(dtoKhachHang))
                            {
                                MessageBox.Show("Thêm khách hàng không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Recreate();
                                return;
                            }
                            dtKhachHang = busKhachHang.GetOfCMND(txtCMND.Text);
                            DataRow row = dtKhachHang.Rows[0];
                            maKhachHang = row["MAKHACHHANG"].ToString();
                        }
                        arr.Clear();
                        string maHangVe = busHangVe.GetMaHangVeByTenHangVe(cboHangVe.Text);
                        string sodoghe = busTinhTrangVe.GetSoDoGheByMaChuyenBayAndMaHangVe(cboMaChuyenBay.Text, maHangVe);
                        string ghe = txtViTri.Text;
                        for (int i = 0; i < ghe.Length; i += 3)
                        {
                            int index = 0;
                            string temp = ghe.Substring(i, 2);
                            if (temp[0] == 'A')
                            {
                                index = Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'B')
                            {
                                index = 10 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }

                            else if (temp[0] == 'C')
                            {
                                index = 20 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'D')
                            {
                                index = 30 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'E')
                            {
                                index = 40 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'F')
                            {
                                index = 50 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'G')
                            {
                                index = 60 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                            else if (temp[0] == 'H')
                            {
                                index = 70 + Convert.ToInt32(temp[1] - '0');
                                arr.Add(index);
                            }
                        }
                        foreach (int i in arr)
                            sodoghe = sodoghe.Remove(i, 1).Insert(i, "1");
                        int sove = Convert.ToInt32(txtViTri.Text.Length / 3);
                        TinhTrangVeDTO dtoTinhTrangVe = new TinhTrangVeDTO(cboMaChuyenBay.Text, maHangVe, 0, Convert.ToInt32(txtSoGheTrong.Text) - sove, sodoghe);
                        VeChuyenBayDTO dtoVeChuyenBay = new VeChuyenBayDTO(null, maKhachHang, cboMaChuyenBay.Text, cboHangVe.SelectedValue.ToString(), maNhanVien, Convert.ToDecimal(txtGiaTien.Text), DateTime.Now, Convert.ToDateTime(null), loaiVe, txtViTri.Text.ToString(), Convert.ToInt32(txtKyGui.Text));
                        if (busTinhTrangVe.UpdateBanVe(dtoTinhTrangVe))
                            if (busVeChuyenBay.Add(dtoVeChuyenBay))
                                MessageBox.Show("Đặt vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Đặt vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Đặt vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        MessageBox.Show("Đặt vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Recreate();
                    }
                }   
                else
                    MessageBox.Show("Chuyến bay đã khởi hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            if (this.maVe != "")
            {
                try
                {
                    arr.Clear();
                    string maHangVe = busHangVe.GetMaHangVeByTenHangVe(cboHangVe.Text);
                    string sodoghe = busTinhTrangVe.GetSoDoGheByMaChuyenBayAndMaHangVe(cboMaChuyenBay.Text, maHangVe);
                    string ghe = txtViTri.Text;
                    for (int i = 0; i < ghe.Length; i += 3)
                    {
                        int index = 0;
                        string temp = ghe.Substring(i, 2);
                        if (temp[0] == 'A')
                        {
                            index = Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'B')
                        {
                            index = 10 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }

                        else if (temp[0] == 'C')
                        {
                            index = 20 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'D')
                        {
                            index = 30 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'E')
                        {
                            index = 40 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'F')
                        {
                            index = 50 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'G')
                        {
                            index = 60 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'H')
                        {
                            index = 70 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                    }
                    foreach (int i in arr)
                        sodoghe = sodoghe.Remove(i, 1).Insert(i, "0");
                    TinhTrangVeDTO dtoTinhTrangVe = new TinhTrangVeDTO(cboMaChuyenBay.Text, maHangVe, 0, Convert.ToInt32(txtSoGheTrong.Text) + this.SoVe, sodoghe);
                    if (busTinhTrangVe.UpdateBanVe(dtoTinhTrangVe))
                        if (busVeChuyenBay.Delete(this.maVe))
                            MessageBox.Show("Hủy vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Hủy vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Hủy vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch
                {
                    MessageBox.Show("Hủy vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Recreate();
                }
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            Form frm = new frmTraCuu(cboMaChuyenBay);
            frm.Show();
        }

        private void btnChiTietGheTrong_Click(object sender, EventArgs e)
        {
            this.GheTruoc = txtViTri.Text;
            this.SoVeDau = this.SoVe;
            Form frm = new frmTinhTrangVe(cboMaChuyenBay.Text, txtViTri, cboHangVe.Text);
            frm.Show();
        }

        private void btnDoiVe_Click(object sender, EventArgs e)
        {
            if (this.maVe != "")
            {
                try
                {
                    string maHangVe = busHangVe.GetMaHangVeByTenHangVe(cboHangVe.Text);
                    string sodoghe = busTinhTrangVe.GetSoDoGheByMaChuyenBayAndMaHangVe(cboMaChuyenBay.Text, maHangVe);
                    string GheSau = txtViTri.Text;

                    arr.Clear();
                    for (int i = 0; i < GheTruoc.Length; i += 3)
                    {
                        int index = 0;
                        string temp = GheTruoc.Substring(i, 2);
                        if (temp[0] == 'A')
                        {
                            index = Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'B')
                        {
                            index = 10 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }

                        else if (temp[0] == 'C')
                        {
                            index = 20 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'D')
                        {
                            index = 30 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'E')
                        {
                            index = 40 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'F')
                        {
                            index = 50 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'G')
                        {
                            index = 60 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'H')
                        {
                            index = 70 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                    }
                    foreach (int i in arr)
                        sodoghe = sodoghe.Remove(i, 1).Insert(i, "0");
                    TinhTrangVeDTO dtoTinhTrangVeTruoc = new TinhTrangVeDTO(cboMaChuyenBay.Text, maHangVe, 0, Convert.ToInt32(txtSoGheTrong.Text), sodoghe);
                    if (busTinhTrangVe.UpdateBanVe(dtoTinhTrangVeTruoc))
                    {
                        
                    } 
                    else
                    {
                        MessageBox.Show("Đổi vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }    
                    arr.Clear();
                    for (int i = 0; i < GheSau.Length; i += 3)
                    {
                        int index = 0;
                        string temp = GheSau.Substring(i, 2);
                        if (temp[0] == 'A')
                        {
                            index = Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'B')
                        {
                            index = 10 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }

                        else if (temp[0] == 'C')
                        {
                            index = 20 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'D')
                        {
                            index = 30 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'E')
                        {
                            index = 40 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'F')
                        {
                            index = 50 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'G')
                        {
                            index = 60 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                        else if (temp[0] == 'H')
                        {
                            index = 70 + Convert.ToInt32(temp[1] - '0');
                            arr.Add(index);
                        }
                    }
                    foreach (int i in arr)
                        sodoghe = sodoghe.Remove(i, 1).Insert(i, "1");
                    TinhTrangVeDTO dtoTinhTrangVeSau = new TinhTrangVeDTO(cboMaChuyenBay.Text, maHangVe, 0, Convert.ToInt32(txtSoGheTrong.Text) - (this.SoVe - this.SoVeDau), sodoghe);
                    if (busTinhTrangVe.UpdateBanVe(dtoTinhTrangVeSau))
                        if (busVeChuyenBay.Update(this.maVe, txtViTri.Text))
                            MessageBox.Show("Đổi vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Đổi vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Đổi vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Đổi vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Recreate();
                }
            }
        }



        #endregion

        
    }
}
