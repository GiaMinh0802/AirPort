
namespace AirPort
{
    partial class frmBaoCaoNam
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.dtpNam = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvNam = new System.Windows.Forms.DataGridView();
            this.chartNam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNam)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1914, 91);
            this.panel1.TabIndex = 126;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(718, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(292, 42);
            this.label7.TabIndex = 39;
            this.label7.Text = "BÁO CÁO NĂM";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnThoat.BackgroundImage = global::AirPort.Properties.Resources.btnCancel;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(1809, 6);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(82, 78);
            this.btnThoat.TabIndex = 40;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.AutoSize = true;
            this.btnXemBaoCao.Location = new System.Drawing.Point(922, 102);
            this.btnXemBaoCao.Margin = new System.Windows.Forms.Padding(6);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(158, 44);
            this.btnXemBaoCao.TabIndex = 123;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // dtpNam
            // 
            this.dtpNam.CustomFormat = "yyyy";
            this.dtpNam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNam.Location = new System.Drawing.Point(726, 105);
            this.dtpNam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpNam.Name = "dtpNam";
            this.dtpNam.Size = new System.Drawing.Size(184, 31);
            this.dtpNam.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(662, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 25);
            this.label1.TabIndex = 128;
            this.label1.Text = "Năm";
            // 
            // dtgvNam
            // 
            this.dtgvNam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvNam.Location = new System.Drawing.Point(12, 167);
            this.dtgvNam.Name = "dtgvNam";
            this.dtgvNam.RowHeadersWidth = 82;
            this.dtgvNam.RowTemplate.Height = 33;
            this.dtgvNam.Size = new System.Drawing.Size(924, 852);
            this.dtgvNam.TabIndex = 129;
            // 
            // chartNam
            // 
            chartArea1.Name = "ChartArea1";
            this.chartNam.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartNam.Legends.Add(legend1);
            this.chartNam.Location = new System.Drawing.Point(952, 167);
            this.chartNam.Name = "chartNam";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Doanh Thu";
            this.chartNam.Series.Add(series1);
            this.chartNam.Size = new System.Drawing.Size(926, 852);
            this.chartNam.TabIndex = 130;
            this.chartNam.Text = "chart1";
            // 
            // frmBaoCaoNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 1030);
            this.Controls.Add(this.chartNam);
            this.Controls.Add(this.dtgvNam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNam);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnXemBaoCao);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBaoCaoNam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo năm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.DateTimePicker dtpNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvNam;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNam;
    }
}