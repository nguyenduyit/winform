
namespace B1809444
{
    partial class Form12
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMaHD = new System.Windows.Forms.ComboBox();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.cbMaSP = new System.Windows.Forms.ComboBox();
            this.btnMaHD = new System.Windows.Forms.Button();
            this.btnMaNV = new System.Windows.Forms.Button();
            this.btnMaSP = new System.Windows.Forms.Button();
            this.dgvHD_SP = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NgayLapHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhanHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.btnTroVe = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongHD = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD_SP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã HĐ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã NV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã SP";
            // 
            // cbMaHD
            // 
            this.cbMaHD.FormattingEnabled = true;
            this.cbMaHD.Location = new System.Drawing.Point(103, 4);
            this.cbMaHD.Name = "cbMaHD";
            this.cbMaHD.Size = new System.Drawing.Size(214, 24);
            this.cbMaHD.TabIndex = 3;
            // 
            // cbMaNV
            // 
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(103, 48);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(214, 24);
            this.cbMaNV.TabIndex = 4;
            // 
            // cbMaSP
            // 
            this.cbMaSP.FormattingEnabled = true;
            this.cbMaSP.Location = new System.Drawing.Point(103, 94);
            this.cbMaSP.Name = "cbMaSP";
            this.cbMaSP.Size = new System.Drawing.Size(214, 24);
            this.cbMaSP.TabIndex = 5;
            // 
            // btnMaHD
            // 
            this.btnMaHD.Location = new System.Drawing.Point(409, 4);
            this.btnMaHD.Name = "btnMaHD";
            this.btnMaHD.Size = new System.Drawing.Size(142, 26);
            this.btnMaHD.TabIndex = 6;
            this.btnMaHD.Text = "Tìm theo Mã HĐ";
            this.btnMaHD.UseVisualStyleBackColor = true;
            this.btnMaHD.Click += new System.EventHandler(this.btnMaHD_Click);
            // 
            // btnMaNV
            // 
            this.btnMaNV.Location = new System.Drawing.Point(409, 48);
            this.btnMaNV.Name = "btnMaNV";
            this.btnMaNV.Size = new System.Drawing.Size(142, 27);
            this.btnMaNV.TabIndex = 7;
            this.btnMaNV.Text = "Tìm theo Nhân Viên";
            this.btnMaNV.UseVisualStyleBackColor = true;
            this.btnMaNV.Click += new System.EventHandler(this.btnMaNV_Click);
            // 
            // btnMaSP
            // 
            this.btnMaSP.Location = new System.Drawing.Point(409, 94);
            this.btnMaSP.Name = "btnMaSP";
            this.btnMaSP.Size = new System.Drawing.Size(142, 29);
            this.btnMaSP.TabIndex = 8;
            this.btnMaSP.Text = "Tìm Theo Mã SP";
            this.btnMaSP.UseVisualStyleBackColor = true;
            this.btnMaSP.Click += new System.EventHandler(this.btnMaSP_Click);
            // 
            // dgvHD_SP
            // 
            this.dgvHD_SP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHD_SP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.MaNV,
            this.MaSP,
            this.NgayLapHD,
            this.NgayNhanHang,
            this.SoLuong,
            this.DonGia});
            this.dgvHD_SP.Location = new System.Drawing.Point(19, 151);
            this.dgvHD_SP.Name = "dgvHD_SP";
            this.dgvHD_SP.RowHeadersWidth = 51;
            this.dgvHD_SP.RowTemplate.Height = 24;
            this.dgvHD_SP.Size = new System.Drawing.Size(1287, 221);
            this.dgvHD_SP.TabIndex = 9;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.Frozen = true;
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            this.MaHD.Width = 125;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaNV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaNV.Width = 125;
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.Width = 125;
            // 
            // NgayLapHD
            // 
            this.NgayLapHD.DataPropertyName = "NgayLapHD";
            this.NgayLapHD.HeaderText = "Ngày Lập HD";
            this.NgayLapHD.MinimumWidth = 6;
            this.NgayLapHD.Name = "NgayLapHD";
            this.NgayLapHD.Width = 125;
            // 
            // NgayNhanHang
            // 
            this.NgayNhanHang.DataPropertyName = "NgayNhanHang";
            this.NgayNhanHang.HeaderText = "NgayNhanHang";
            this.NgayNhanHang.MinimumWidth = 6;
            this.NgayNhanHang.Name = "NgayNhanHang";
            this.NgayNhanHang.Width = 125;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 125;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Giá Tiền";
            this.DonGia.MinimumWidth = 6;
            this.DonGia.Name = "DonGia";
            this.DonGia.Width = 125;
            // 
            // btnReLoad
            // 
            this.btnReLoad.Location = new System.Drawing.Point(42, 398);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(75, 40);
            this.btnReLoad.TabIndex = 10;
            this.btnReLoad.Text = "ReLoad";
            this.btnReLoad.UseVisualStyleBackColor = true;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // btnTroVe
            // 
            this.btnTroVe.Location = new System.Drawing.Point(1214, 398);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(75, 39);
            this.btnTroVe.TabIndex = 11;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(714, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tổng số HĐ";
            // 
            // txtTongHD
            // 
            this.txtTongHD.Location = new System.Drawing.Point(904, 52);
            this.txtTongHD.Name = "txtTongHD";
            this.txtTongHD.Size = new System.Drawing.Size(198, 22);
            this.txtTongHD.TabIndex = 13;
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 450);
            this.Controls.Add(this.txtTongHD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.btnReLoad);
            this.Controls.Add(this.dgvHD_SP);
            this.Controls.Add(this.btnMaSP);
            this.Controls.Add(this.btnMaNV);
            this.Controls.Add(this.btnMaHD);
            this.Controls.Add(this.cbMaSP);
            this.Controls.Add(this.cbMaNV);
            this.Controls.Add(this.cbMaHD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form12";
            this.Text = "Form12";
            this.Load += new System.EventHandler(this.Form12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD_SP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMaHD;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.ComboBox cbMaSP;
        private System.Windows.Forms.Button btnMaHD;
        private System.Windows.Forms.Button btnMaNV;
        private System.Windows.Forms.Button btnMaSP;
        private System.Windows.Forms.DataGridView dgvHD_SP;
        private System.Windows.Forms.Button btnReLoad;
        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLapHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhanHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
    }
}