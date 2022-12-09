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
    public partial class Form3 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtTable
        SqlDataAdapter daTable = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtTable = null;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                conn =new SqlConnection(strConnectionString);
                int intDM = Convert.ToInt32(this.Text);
                switch(intDM)
                {
                    case 1:
                        lblDanhMuc.Text = "Danh Mục Thành Phố";
                        daTable = new SqlDataAdapter("SELECT ThanhPho, TenThanhPho FROM THANHPHO", conn);
                        break;
                    case 2:
                        lblDanhMuc.Text = "Danh Mục Khách Hàng";
                        daTable = new SqlDataAdapter("SELECT MaKH, TenCTy FROM KHACHHANG", conn);
                        break;
                    case 3:
                        lblDanhMuc.Text = "Danh Mục Nhân Viên";
                        daTable = new SqlDataAdapter("SELECT MaNV, Ho,Ten FROM NHANVIEN", conn);
                        break;
                    case 4:
                        lblDanhMuc.Text = "Danh Mục Sản Phẩm";
                        daTable = new SqlDataAdapter("SELECT MaSP, TenSP, DonViTinh, DonGia FROM SANPHAM", conn);
                        break;
                    case 5:
                        lblDanhMuc.Text = "Danh Mục Hoá Đơn";
                        daTable = new SqlDataAdapter("SELECT MaHD, MaKH, MaNV FROM HOADON", conn);
                        break;
                    case 6:
                        lblDanhMuc.Text = "Danh Mục Chi Tiết Hoá Đơn";
                        daTable = new SqlDataAdapter("SELECT *FROM CHITIETHOADON", conn);
                        break;
                    default:
                        break;
                }
                dtTable = new DataTable();
                dtTable.Clear();
                daTable.Fill(dtTable);
                dgvDanhMuc.DataSource = dtTable;
                dgvDanhMuc.AutoResizeColumns();
            }
            catch(SqlException)
            {
                MessageBox.Show("Không lấy được nội dung", "Lỗi rồi");
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
