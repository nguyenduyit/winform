using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace B1809444
{
    public partial class Form12 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        SqlConnection conn = null;

        SqlDataAdapter daHoaDon_SanPham = null;
        DataTable dtHoaDon_SanPham = null;

        SqlDataAdapter daSanPham = null;
        DataTable dtSanPham = null;

        SqlDataAdapter daNhanVien = null;
        DataTable dtNhanVien = null;

       
        SqlDataAdapter daHoaDon = null;
        DataTable dtHoaDon = null;

        public Form12()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                

                daNhanVien = new SqlDataAdapter("SELECT distinct *FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                (dgvHD_SP.Columns["MaNV"] as DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgvHD_SP.Columns["MaNV"] as DataGridViewComboBoxColumn).DisplayMember = "Ten";
                (dgvHD_SP.Columns["MaNV"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";

                daSanPham = new SqlDataAdapter("SELECT distinct *FROM SANPHAM", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                (dgvHD_SP.Columns["MaSP"] as DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgvHD_SP.Columns["MaSP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                (dgvHD_SP.Columns["MaSP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";

                

                daHoaDon_SanPham = new SqlDataAdapter("SELECT distinct " +
                    "CHITIETHOADON.MaHD," +
                    
                    "NHANVIEN.MaNV," +
                    "SANPHAM.MaSP," +
                    "HOADON.NgayLapHD," +
                    "HOADON.NgayNhanHang," +
                    "CHITIETHOADON.SoLuong," +
                    "SANPHAM.DonGia FROM SANPHAM,NHANVIEN,HOADON,CHITIETHOADON WHERE " +
                    "HOADON.MaHD=CHITIETHOADON.MaHD " , conn);
                dtHoaDon_SanPham = new DataTable();
                dtHoaDon_SanPham.Clear();
                daHoaDon_SanPham.Fill(dtHoaDon_SanPham);

                daHoaDon = new SqlDataAdapter("SELECT distinct *FROM HOADON", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                this.cbMaHD.DataSource = dtHoaDon;
                this.cbMaHD.DisplayMember = "MaHD";
                this.cbMaHD.ValueMember = "MaHD";

                this.cbMaNV.DataSource = dtNhanVien;
                this.cbMaNV.DisplayMember = "Ten";
                this.cbMaNV.ValueMember = "MaNV";

                this.cbMaSP.DataSource = dtSanPham;
                this.cbMaSP.DisplayMember = "TenSP";
                this.cbMaSP.ValueMember = "MaSP";

                dgvHD_SP.DataSource = dtHoaDon_SanPham;
                this.txtTongHD.Enabled = false;



            }
            catch (SqlException)
            {
                MessageBox.Show("Không láy được dữ liệu", "Error");
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            this.txtTongHD.Enabled = false;
            this.txtTongHD.Text = "";
            LoadData();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            this.txtTongHD.Text = "";
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnMaHD_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                daHoaDon_SanPham = new SqlDataAdapter("SELECT distinct " +
                     "CHITIETHOADON.MaHD," +
                     "NHANVIEN.MaNV," +
                     "SANPHAM.MaSP," +
                     "HOADON.NgayLapHD," +
                     "HOADON.NgayNhanHang," +
                     "CHITIETHOADON.SoLuong," +
                     "SANPHAM.DonGia FROM SANPHAM,NHANVIEN,HOADON,CHITIETHOADON WHERE " +
                     "CHITIETHOADON.MaHD='"+ this.cbMaHD.SelectedValue.ToString()+ "' " +
                     "AND CHITIETHOADON.MaSP=SANPHAM.MaSP  " +
                     "AND HOADON.MaNV=NHANVIEN.MaNV", conn);
                dtHoaDon_SanPham = new DataTable();
                dtHoaDon_SanPham.Clear();
                daHoaDon_SanPham.Fill(dtHoaDon_SanPham);
                dgvHD_SP.DataSource = dtHoaDon_SanPham;
                if(dgvHD_SP.RowCount>1)
                this.txtTongHD.Text = (dgvHD_SP.RowCount - 1).ToString();
                else
                {
                    this.txtTongHD.Text = "0";
                }


            }
            catch (SqlException)
            {
                MessageBox.Show("KHông lấy  được dữ liệu !!!", "lỗi rồi");
            }
        }

        private void btnMaNV_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                daHoaDon_SanPham = new SqlDataAdapter("SELECT distinct " +
                     "CHITIETHOADON.MaHD," +
                     "HOADON.MaNV," +
                     "SANPHAM.MaSP," +
                     "HOADON.NgayLapHD," +
                     "HOADON.NgayNhanHang," +
                     "CHITIETHOADON.SoLuong," +
                     "SANPHAM.DonGia FROM SANPHAM,NHANVIEN,HOADON,CHITIETHOADON WHERE " +
                     "CHITIETHOADON.MaHD=HOADON.MaHD " +
                     "AND CHITIETHOADON.MaSP=SANPHAM.MaSP  " +
                     "AND HOADON.MaNV='"+this.cbMaNV.SelectedValue.ToString()+"'", conn);
                dtHoaDon_SanPham = new DataTable();
                dtHoaDon_SanPham.Clear();
                daHoaDon_SanPham.Fill(dtHoaDon_SanPham);
                dgvHD_SP.DataSource = dtHoaDon_SanPham;
                if (dgvHD_SP.RowCount > 1)
                    this.txtTongHD.Text = (dgvHD_SP.RowCount - 1).ToString();
                else
                {
                    this.txtTongHD.Text = "0";
                }


            }
            catch (SqlException)
            {
                MessageBox.Show("KHông lấy  được dữ liệu !!!", "lỗi rồi");
            }
        }

        private void btnMaSP_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                daHoaDon_SanPham = new SqlDataAdapter("SELECT distinct " +
                     "CHITIETHOADON.MaHD," +
                     "HOADON.MaNV," +
                     "SANPHAM.MaSP," +
                     "HOADON.NgayLapHD," +
                     "HOADON.NgayNhanHang," +
                     "CHITIETHOADON.SoLuong," +
                     "SANPHAM.DonGia FROM SANPHAM,NHANVIEN,HOADON,CHITIETHOADON WHERE " +
                     "CHITIETHOADON.MaHD=HOADON.MaHD " +
                     "AND SANPHAM.MaSP='"+this.cbMaNV.SelectedValue.ToString()+"'  " +
                     "AND HOADON.MaNV=NHANVIEN.MaNV", conn);
                dtHoaDon_SanPham = new DataTable();
                dtHoaDon_SanPham.Clear();
                daHoaDon_SanPham.Fill(dtHoaDon_SanPham);
                dgvHD_SP.DataSource = dtHoaDon_SanPham;
                if (dgvHD_SP.RowCount > 1)
                    this.txtTongHD.Text = (dgvHD_SP.RowCount - 1).ToString();
                else
                {
                    this.txtTongHD.Text = "0";
                }


            }
            catch (SqlException)
            {
                MessageBox.Show("KHông lấy  được dữ liệu !!!", "lỗi rồi");
            }
        }
    }
}
