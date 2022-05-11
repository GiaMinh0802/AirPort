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
    public partial class frmTinhTrangVe : Form
    {
        ChuyenBayBUS busChuyenBay = new ChuyenBayBUS();
        TinhTrangVeBUS busTinhTrangVe = new TinhTrangVeBUS();
        HangVeBUS busHangVe = new HangVeBUS();
        string maChuyenBay;
        public frmTinhTrangVe(string maChuyenBay)
        {
            InitializeComponent();
            this.maChuyenBay = maChuyenBay;
            LoadForm();
        }

        private void LoadForm()
        {
            button81.BackColor = SystemColors.Control;
            DataTable dtChuyenBay = busChuyenBay.Get();
            cboMaChuyenBay.DataSource = dtChuyenBay;
            cboMaChuyenBay.DisplayMember = "MACHUYENBAY";
            cboMaChuyenBay.ValueMember = "MACHUYENBAY";
            cboMaChuyenBay.SelectedValue = maChuyenBay;

            cboMaChuyenBay.Focus();
            LoadDtgv(maChuyenBay);

        }

        private void LoadDtgv(string maChuyenBay)
        {
            DataTable dtTinhTrangVe = busTinhTrangVe.GetForDisplayOfMaChuyenBay(maChuyenBay);
            dtgvTinhTrangVe.DataSource = dtTinhTrangVe;
            dtgvTinhTrangVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvTinhTrangVe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void cboMaChuyenBay_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDtgv(cboMaChuyenBay.Text);
            foreach (Button btn in this.groupBox1.Controls.OfType<Button>())
            {
                btn.BackColor = SystemColors.Control;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            txtbox.Text = "";
            Button num = (Button)sender;
            txtbox.Text = txtbox.Text + num.Text;
            num.BackColor = System.Drawing.Color.Lime;
            foreach (Button btn in this.groupBox1.Controls.OfType<Button>())
            {
                if (btn.Name != num.Name && btn.BackColor != System.Drawing.Color.Red)
                {
                    btn.BackColor = SystemColors.Control;
                }
            }

        }
        private void dtgvTinhTrangVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Button btn in this.groupBox1.Controls.OfType<Button>())
            {
                btn.BackColor = SystemColors.Control;
            }
            if (e.RowIndex == -1)
                return;
            DataGridViewRow row = dtgvTinhTrangVe.Rows[e.RowIndex];
            string maChuyenBay = cboMaChuyenBay.Text;
            string maHangVe = busHangVe.GetMaHangVeByTenHangVe(row.Cells[0].Value.ToString());
            string sodoghe = busTinhTrangVe.GetSoDoGheByMaChuyenBayAndMaHangVe(maChuyenBay, maHangVe);
            for (int i=0; i < sodoghe.Length; i++)
            {
                if (sodoghe[i] == '1')
                {
                    string soghe = i.ToString();
                    if (soghe.Length == 1)
                        soghe = 'A' + soghe; 
                    else
                    {
                        if (soghe[0] == '1')
                            soghe = 'B' + soghe[1].ToString();
                        else if (soghe[0] == '2')
                            soghe = 'C' + soghe[1].ToString();
                        else if (soghe[0] == '3')
                            soghe = 'D' + soghe[1].ToString();
                        else if (soghe[0] == '4')
                            soghe = 'E' + soghe[1].ToString();
                        else if (soghe[0] == '3')
                            soghe = 'F' + soghe[1].ToString();
                        else if (soghe[0] == '3')
                            soghe = 'G' + soghe[1].ToString();
                        else
                            soghe = 'H' + soghe[1].ToString();
                    }
                    foreach (Button btn in this.groupBox1.Controls.OfType<Button>())
                    {
                        if (btn.Text == soghe)
                        {
                            btn.BackColor = System.Drawing.Color.Red;
                        }
                    }
                }    
            } 
                
            if (row.Cells[0].Value.ToString() == "Thương gia")
            {
                foreach (Button btn in this.groupBox1.Controls.OfType<Button>())
                {
                    if (btn.Text.Contains("A") || btn.Text.Contains("B") || btn.Text.Contains("G") || btn.Text.Contains("H"))
                    {
                        btn.Enabled = false;
                        btn.BackColor = SystemColors.Control;
                    }
                }
            }
            else
            {
                foreach (Button btn in this.groupBox1.Controls.OfType<Button>())
                {
                    btn.Enabled = true;
                }
            }
        }

    }
}
