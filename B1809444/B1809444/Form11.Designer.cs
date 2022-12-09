
namespace B1809444
{
    partial class Form11
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbKH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongSoHD = new System.Windows.Forms.TextBox();
            this.dgvHoaDonKH = new System.Windows.Forms.DataGridView();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.btnTroVe = new System.Windows.Forms.Button();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NgayLapHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhanHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonKH)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Khách Hàng";
            // 
            // cbKH
            // 
            this.cbKH.FormattingEnabled = true;
            this.cbKH.Location = new System.Drawing.Point(167, 28);
            this.cbKH.Name = "cbKH";
            this.cbKH.Size = new System.Drawing.Size(195, 24);
            this.cbKH.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tổng Số HĐ";
            // 
            // txtTongSoHD
            // 
            this.txtTongSoHD.Location = new System.Drawing.Point(660, 34);
            this.txtTongSoHD.Name = "txtTongSoHD";
            this.txtTongSoHD.Size = new System.Drawing.Size(181, 22);
            this.txtTongSoHD.TabIndex = 3;
            // 
            // dgvHoaDonKH
            // 
            this.dgvHoaDonKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.MaKH,
            this.MaNV,
            this.NgayLapHD,
            this.NgayNhanHang});
            this.dgvHoaDonKH.Location = new System.Drawing.Point(16, 76);
            this.dgvHoaDonKH.Name = "dgvHoaDonKH";
            this.dgvHoaDonKH.RowHeadersWidth = 51;
            this.dgvHoaDonKH.RowTemplate.Height = 24;
            this.dgvHoaDonKH.Size = new System.Drawing.Size(973, 275);
            this.dgvHoaDonKH.TabIndex = 4;
            // 
            // btnReLoad
            // 
            this.btnReLoad.Location = new System.Drawing.Point(145, 369);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(75, 54);
            this.btnReLoad.TabIndex = 5;
            this.btnReLoad.Text = "ReLoad";
            this.btnReLoad.UseVisualStyleBackColor = true;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // btnTroVe
            // 
            this.btnTroVe.Location = new System.Drawing.Point(848, 369);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(75, 54);
            this.btnTroVe.TabIndex = 6;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.Frozen = true;
            this.MaHD.HeaderText = "Mã HĐ";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            this.MaHD.Width = 125;
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Mã KH";
            this.MaKH.MinimumWidth = 6;
            this.MaKH.Name = "MaKH";
            this.MaKH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaKH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaKH.Width = 125;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 125;
            // 
            // NgayLapHD
            // 
            this.NgayLapHD.DataPropertyName = "NgayLapHD";
            this.NgayLapHD.HeaderText = "Ngày Lập HĐ";
            this.NgayLapHD.MinimumWidth = 6;
            this.NgayLapHD.Name = "NgayLapHD";
            this.NgayLapHD.Width = 125;
            // 
            // NgayNhanHang
            // 
            this.NgayNhanHang.DataPropertyName = "NgayNhanHang";
            this.NgayNhanHang.HeaderText = "Ngày Nhận Hàng";
            this.NgayNhanHang.MinimumWidth = 6;
            this.NgayNhanHang.Name = "NgayNhanHang";
            this.NgayNhanHang.Width = 125;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(421, 28);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 450);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.btnReLoad);
            this.Controls.Add(this.dgvHoaDonKH);
            this.Controls.Add(this.txtTongSoHD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbKH);
            this.Controls.Add(this.label1);
            this.Name = "Form11";
            this.Text = "Form11";
            this.Load += new System.EventHandler(this.Form11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongSoHD;
        private System.Windows.Forms.DataGridView dgvHoaDonKH;
        private System.Windows.Forms.Button btnReLoad;
        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLapHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhanHang;
        private System.Windows.Forms.Button btnOK;
    }
}