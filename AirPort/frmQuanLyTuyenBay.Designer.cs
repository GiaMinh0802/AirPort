﻿
namespace AirPort
{
    partial class frmQuanLyTuyenBay
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
            this.txtMaTuyenBay = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSanBayDi = new System.Windows.Forms.ComboBox();
            this.cboSanBayDen = new System.Windows.Forms.ComboBox();
            this.gbxTTTuyenBay = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxDSTuyenBay = new System.Windows.Forms.GroupBox();
            this.dtgvTuyenBay = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbxThaoTac = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.gbxTTTuyenBay.SuspendLayout();
            this.gbxDSTuyenBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTuyenBay)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbxThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaTuyenBay
            // 
            this.txtMaTuyenBay.Location = new System.Drawing.Point(260, 44);
            this.txtMaTuyenBay.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMaTuyenBay.Name = "txtMaTuyenBay";
            this.txtMaTuyenBay.ReadOnly = true;
            this.txtMaTuyenBay.Size = new System.Drawing.Size(298, 31);
            this.txtMaTuyenBay.TabIndex = 17;
            this.txtMaTuyenBay.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 52);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(148, 25);
            this.label20.TabIndex = 15;
            this.label20.Text = "Mã tuyến bay ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 109);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(114, 25);
            this.label19.TabIndex = 16;
            this.label19.Text = "Sân bay đi";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 159);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(133, 25);
            this.label18.TabIndex = 13;
            this.label18.Text = "Sân bay đến";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(718, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 42);
            this.label1.TabIndex = 39;
            this.label1.Text = "QUẢN LÝ TUYẾN BAY";
            // 
            // cboSanBayDi
            // 
            this.cboSanBayDi.FormattingEnabled = true;
            this.cboSanBayDi.Location = new System.Drawing.Point(261, 98);
            this.cboSanBayDi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSanBayDi.Name = "cboSanBayDi";
            this.cboSanBayDi.Size = new System.Drawing.Size(298, 33);
            this.cboSanBayDi.TabIndex = 1;
            // 
            // cboSanBayDen
            // 
            this.cboSanBayDen.FormattingEnabled = true;
            this.cboSanBayDen.Location = new System.Drawing.Point(261, 148);
            this.cboSanBayDen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSanBayDen.Name = "cboSanBayDen";
            this.cboSanBayDen.Size = new System.Drawing.Size(298, 33);
            this.cboSanBayDen.TabIndex = 2;
            // 
            // gbxTTTuyenBay
            // 
            this.gbxTTTuyenBay.Controls.Add(this.label20);
            this.gbxTTTuyenBay.Controls.Add(this.label18);
            this.gbxTTTuyenBay.Controls.Add(this.cboSanBayDen);
            this.gbxTTTuyenBay.Controls.Add(this.label19);
            this.gbxTTTuyenBay.Controls.Add(this.cboSanBayDi);
            this.gbxTTTuyenBay.Controls.Add(this.txtMaTuyenBay);
            this.gbxTTTuyenBay.Location = new System.Drawing.Point(18, 100);
            this.gbxTTTuyenBay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxTTTuyenBay.Name = "gbxTTTuyenBay";
            this.gbxTTTuyenBay.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxTTTuyenBay.Size = new System.Drawing.Size(570, 773);
            this.gbxTTTuyenBay.TabIndex = 1;
            this.gbxTTTuyenBay.TabStop = false;
            this.gbxTTTuyenBay.Text = "Thông tin tuyến bay";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(962, 38);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(246, 31);
            this.txtTimKiem.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(848, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tìm kiếm ";
            // 
            // gbxDSTuyenBay
            // 
            this.gbxDSTuyenBay.Controls.Add(this.dtgvTuyenBay);
            this.gbxDSTuyenBay.Controls.Add(this.label2);
            this.gbxDSTuyenBay.Controls.Add(this.txtTimKiem);
            this.gbxDSTuyenBay.Controls.Add(this.btnTimKiem);
            this.gbxDSTuyenBay.Location = new System.Drawing.Point(597, 100);
            this.gbxDSTuyenBay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxDSTuyenBay.Name = "gbxDSTuyenBay";
            this.gbxDSTuyenBay.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxDSTuyenBay.Size = new System.Drawing.Size(1281, 941);
            this.gbxDSTuyenBay.TabIndex = 3;
            this.gbxDSTuyenBay.TabStop = false;
            this.gbxDSTuyenBay.Text = "Danh sách tuyến bay";
            // 
            // dtgvTuyenBay
            // 
            this.dtgvTuyenBay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTuyenBay.Location = new System.Drawing.Point(9, 98);
            this.dtgvTuyenBay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgvTuyenBay.Name = "dtgvTuyenBay";
            this.dtgvTuyenBay.RowHeadersWidth = 82;
            this.dtgvTuyenBay.RowTemplate.Height = 24;
            this.dtgvTuyenBay.Size = new System.Drawing.Size(1263, 833);
            this.dtgvTuyenBay.TabIndex = 8;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackgroundImage = global::AirPort.Properties.Resources.btnTimKiem;
            this.btnTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Location = new System.Drawing.Point(1221, 31);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(50, 47);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(-6, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1914, 91);
            this.panel1.TabIndex = 48;
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
            this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(82, 78);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.UseVisualStyleBackColor = false;
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
            this.btnThem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 78);
            this.btnThem.TabIndex = 3;
            this.btnThem.UseCompatibleTextRendering = true;
            this.btnThem.UseVisualStyleBackColor = true;
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
            this.btnSua.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 78);
            this.btnSua.TabIndex = 4;
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = global::AirPort.Properties.Resources.btnXoa;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Location = new System.Drawing.Point(435, 34);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 78);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // frmQuanLyTuyenBay
            // 
            this.AcceptButton = this.btnThem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(1896, 1059);
            this.Controls.Add(this.gbxThaoTac);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxDSTuyenBay);
            this.Controls.Add(this.gbxTTTuyenBay);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmQuanLyTuyenBay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm tuyến bay";
            this.gbxTTTuyenBay.ResumeLayout(false);
            this.gbxTTTuyenBay.PerformLayout();
            this.gbxDSTuyenBay.ResumeLayout(false);
            this.gbxDSTuyenBay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTuyenBay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxThaoTac.ResumeLayout(false);
            this.gbxThaoTac.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtMaTuyenBay;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cboSanBayDi;
        private System.Windows.Forms.ComboBox cboSanBayDen;
        private System.Windows.Forms.GroupBox gbxTTTuyenBay;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbxDSTuyenBay;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox gbxThaoTac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtgvTuyenBay;
    }
}