
namespace AirPort
{
    partial class frmQuanLyDonGia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.gbxThaoTac = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gboDSMayBay = new System.Windows.Forms.GroupBox();
            this.dtgvDonGia = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.gbxTTMayBay = new System.Windows.Forms.GroupBox();
            this.lbDonGia = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboSanBayDen = new System.Windows.Forms.ComboBox();
            this.cboSanBayDi = new System.Windows.Forms.ComboBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.cboMaHangVe = new System.Windows.Forms.ComboBox();
            this.cboMaTuyenBay = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.gbxThaoTac.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gboDSMayBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDonGia)).BeginInit();
            this.gbxTTMayBay.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 42);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(148, 25);
            this.label20.TabIndex = 45;
            this.label20.Text = "Mã tuyến bay ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 225);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 25);
            this.label19.TabIndex = 46;
            this.label19.Text = "Tên hạng vé";
            // 
            // gbxThaoTac
            // 
            this.gbxThaoTac.Controls.Add(this.btnThem);
            this.gbxThaoTac.Controls.Add(this.label5);
            this.gbxThaoTac.Controls.Add(this.label4);
            this.gbxThaoTac.Controls.Add(this.label3);
            this.gbxThaoTac.Controls.Add(this.btnSua);
            this.gbxThaoTac.Controls.Add(this.btnXoa);
            this.gbxThaoTac.Location = new System.Drawing.Point(18, 883);
            this.gbxThaoTac.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxThaoTac.Name = "gbxThaoTac";
            this.gbxThaoTac.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxThaoTac.Size = new System.Drawing.Size(570, 158);
            this.gbxThaoTac.TabIndex = 2;
            this.gbxThaoTac.TabStop = false;
            this.gbxThaoTac.Text = "Thao tác";
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = global::AirPort.Properties.Resources.btnThem;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Location = new System.Drawing.Point(56, 34);
            this.btnThem.Margin = new System.Windows.Forms.Padding(6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 78);
            this.btnThem.TabIndex = 6;
            this.btnThem.UseCompatibleTextRendering = true;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Xóa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Sửa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Thêm";
            // 
            // btnSua
            // 
            this.btnSua.BackgroundImage = global::AirPort.Properties.Resources.btnSua;
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Location = new System.Drawing.Point(250, 34);
            this.btnSua.Margin = new System.Windows.Forms.Padding(6);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 78);
            this.btnSua.TabIndex = 7;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = global::AirPort.Properties.Resources.btnXoa;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Location = new System.Drawing.Point(435, 34);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 78);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(-6, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1914, 91);
            this.panel1.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(718, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 42);
            this.label2.TabIndex = 39;
            this.label2.Text = "QUẢN LÝ ĐƠN GIÁ";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnThoat.BackgroundImage = global::AirPort.Properties.Resources.btnCancel;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(1809, 6);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(82, 78);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // gboDSMayBay
            // 
            this.gboDSMayBay.Controls.Add(this.dtgvDonGia);
            this.gboDSMayBay.Controls.Add(this.label6);
            this.gboDSMayBay.Controls.Add(this.txtTimKiem);
            this.gboDSMayBay.Controls.Add(this.btnTimKiem);
            this.gboDSMayBay.Location = new System.Drawing.Point(597, 100);
            this.gboDSMayBay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gboDSMayBay.Name = "gboDSMayBay";
            this.gboDSMayBay.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gboDSMayBay.Size = new System.Drawing.Size(1281, 941);
            this.gboDSMayBay.TabIndex = 3;
            this.gboDSMayBay.TabStop = false;
            this.gboDSMayBay.Text = "Danh sách đơn giá";
            // 
            // dtgvDonGia
            // 
            this.dtgvDonGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDonGia.Location = new System.Drawing.Point(9, 98);
            this.dtgvDonGia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgvDonGia.Name = "dtgvDonGia";
            this.dtgvDonGia.RowHeadersWidth = 82;
            this.dtgvDonGia.RowTemplate.Height = 24;
            this.dtgvDonGia.Size = new System.Drawing.Size(1263, 833);
            this.dtgvDonGia.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(848, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tìm kiếm ";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(962, 38);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(246, 31);
            this.txtTimKiem.TabIndex = 9;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackgroundImage = global::AirPort.Properties.Resources.btnTimKiem;
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Location = new System.Drawing.Point(1221, 31);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(6);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(50, 47);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // gbxTTMayBay
            // 
            this.gbxTTMayBay.Controls.Add(this.lbDonGia);
            this.gbxTTMayBay.Controls.Add(this.label15);
            this.gbxTTMayBay.Controls.Add(this.label14);
            this.gbxTTMayBay.Controls.Add(this.cboSanBayDen);
            this.gbxTTMayBay.Controls.Add(this.cboSanBayDi);
            this.gbxTTMayBay.Controls.Add(this.txtDonGia);
            this.gbxTTMayBay.Controls.Add(this.cboMaHangVe);
            this.gbxTTMayBay.Controls.Add(this.cboMaTuyenBay);
            this.gbxTTMayBay.Controls.Add(this.label18);
            this.gbxTTMayBay.Controls.Add(this.label20);
            this.gbxTTMayBay.Controls.Add(this.label19);
            this.gbxTTMayBay.Location = new System.Drawing.Point(18, 100);
            this.gbxTTMayBay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxTTMayBay.Name = "gbxTTMayBay";
            this.gbxTTMayBay.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxTTMayBay.Size = new System.Drawing.Size(570, 773);
            this.gbxTTMayBay.TabIndex = 1;
            this.gbxTTMayBay.TabStop = false;
            this.gbxTTMayBay.Text = "Thông tin đơn giá";
            // 
            // lbDonGia
            // 
            this.lbDonGia.AutoSize = true;
            this.lbDonGia.Location = new System.Drawing.Point(386, 278);
            this.lbDonGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDonGia.Name = "lbDonGia";
            this.lbDonGia.Size = new System.Drawing.Size(0, 25);
            this.lbDonGia.TabIndex = 59;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 162);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 25);
            this.label15.TabIndex = 55;
            this.label15.Text = "Sân bay đến";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 102);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 25);
            this.label14.TabIndex = 56;
            this.label14.Text = "Sân bay đi";
            // 
            // cboSanBayDen
            // 
            this.cboSanBayDen.FormattingEnabled = true;
            this.cboSanBayDen.Location = new System.Drawing.Point(212, 152);
            this.cboSanBayDen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSanBayDen.Name = "cboSanBayDen";
            this.cboSanBayDen.Size = new System.Drawing.Size(348, 33);
            this.cboSanBayDen.TabIndex = 3;
            // 
            // cboSanBayDi
            // 
            this.cboSanBayDi.FormattingEnabled = true;
            this.cboSanBayDi.Location = new System.Drawing.Point(212, 91);
            this.cboSanBayDi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSanBayDi.Name = "cboSanBayDi";
            this.cboSanBayDi.Size = new System.Drawing.Size(348, 33);
            this.cboSanBayDi.TabIndex = 2;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(212, 270);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(163, 31);
            this.txtDonGia.TabIndex = 5;
            // 
            // cboMaHangVe
            // 
            this.cboMaHangVe.FormattingEnabled = true;
            this.cboMaHangVe.Location = new System.Drawing.Point(212, 211);
            this.cboMaHangVe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboMaHangVe.Name = "cboMaHangVe";
            this.cboMaHangVe.Size = new System.Drawing.Size(348, 33);
            this.cboMaHangVe.TabIndex = 4;
            // 
            // cboMaTuyenBay
            // 
            this.cboMaTuyenBay.FormattingEnabled = true;
            this.cboMaTuyenBay.Location = new System.Drawing.Point(212, 31);
            this.cboMaTuyenBay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboMaTuyenBay.Name = "cboMaTuyenBay";
            this.cboMaTuyenBay.Size = new System.Drawing.Size(348, 33);
            this.cboMaTuyenBay.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 278);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 25);
            this.label18.TabIndex = 44;
            this.label18.Text = "Đơn giá";
            // 
            // frmQuanLyDonGia
            // 
            this.AcceptButton = this.btnThem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(1896, 1059);
            this.Controls.Add(this.gbxThaoTac);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gboDSMayBay);
            this.Controls.Add(this.gbxTTMayBay);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmQuanLyDonGia";
            this.Text = "Thêm đơn giá";
            this.gbxThaoTac.ResumeLayout(false);
            this.gbxThaoTac.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gboDSMayBay.ResumeLayout(false);
            this.gboDSMayBay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDonGia)).EndInit();
            this.gbxTTMayBay.ResumeLayout(false);
            this.gbxTTMayBay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox gbxThaoTac;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox gboDSMayBay;
        private System.Windows.Forms.DataGridView dtgvDonGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox gbxTTMayBay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lbDonGia;
        private System.Windows.Forms.ComboBox cboSanBayDen;
        private System.Windows.Forms.ComboBox cboSanBayDi;
        private System.Windows.Forms.ComboBox cboMaHangVe;
        private System.Windows.Forms.ComboBox cboMaTuyenBay;
        private System.Windows.Forms.Label label18;
    }
}