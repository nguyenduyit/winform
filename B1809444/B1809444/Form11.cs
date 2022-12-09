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
    public partial class Form11 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        SqlConnection conn = null;

        SqlDataAdapter daHoaDon = null;
        DataTable dtHoaDon = null;

        SqlDataAdapter daKhachHang = null;
        DataTable dtKhachHang = null;

        SqlDataAdapter daNhanVien = null;
        DataTable dtNhanVien = null;
        public Form11()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daKhachHang = new SqlDataAdapter("SELECT distinct *FROM KHACHHANG", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                (dgvHoaDonKH.Columns["MaKH"] as DataGridViewComboBoxColumn).DataSource = dtKhachHang;
                (dgvHoaDonKH.Columns["MaKH"] as DataGridViewComboBoxColumn).DisplayMember = "TenCty";
                (dgvHoaDonKH.Columns["MaKH"] as DataGridViewComboBoxColumn).ValueMember = "MaKH";

                daNhanVien = new SqlDataAdapter("SELECT *FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                (dgvHoaDonKH.Columns["MaNV"] as DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgvHoaDonKH.Columns["MaNV"] as DataGridViewComboBoxColumn).DisplayMember = "Ten";
                (dgvHoaDonKH.Columns["MaNV"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";

               
                daHoaDon = new SqlDataAdapter("SELECT distinct HOADON.MaHD,HOADON.MaKH,HOADON.MaNV,HOADON.NgayLapHd,HOADON.NgayNhanHang  FROM KHACHHANG,NHANVIEN,HOADON WHERE HOADON.MaKH=KHACHHANG.MaKH AND HOADON.MaNV=NHANVIEN.MaNV", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);

                this.cbKH.DataSource = dtKhachHang;
                this.cbKH.DisplayMember = "TenCty";
                this.cbKH.ValueMember = "MaKH";

                dgvHoaDonKH.DataSource = dtHoaDon;

                this.txtTongSoHD.Enabled = false;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không láy được dữ liệu", "Error");
            }

        }
        private void Form11_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                daHoaDon = new SqlDataAdapter("select distinct HOADON.MaHD,HOADON.MaKH,HOADON.MaNV,HOADON.NgayLapHd,HOADON.NgayNhanHang  FROM KHACHHANG,NHANVIEN,HOADON  where HOADON.MaKH='" +
                    this.cbKH.SelectedValue.ToString() + "' ", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                dgvHoaDonKH.DataSource = dtHoaDon;

                this.txtTongSoHD.Text = (dgvHoaDonKH.RowCount - 1).ToString();


            }
            catch (SqlException)
            {
                MessageBox.Show("KHông lấy  được dữ liệu !!!", "lỗi rồi");
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            this.txtTongSoHD.Text = "";
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
    }
}
