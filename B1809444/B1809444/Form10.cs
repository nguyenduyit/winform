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
    public partial class Form10 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        SqlConnection conn = null;

        SqlDataAdapter daThanhPho = null;
        DataTable dtThanhPho = null;

        SqlDataAdapter daKhachHang = null;
        DataTable dtKhachHang = null;

        public void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daThanhPho = new SqlDataAdapter("SELECT *FROM THANHPHO", conn);
                dtThanhPho = new DataTable();
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);
                (dgvThanhPho.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DataSource = dtThanhPho;
                (dgvThanhPho.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DisplayMember = "TenThanhPho";
                (dgvThanhPho.Columns["ThanhPho"] as DataGridViewComboBoxColumn).ValueMember = "ThanhPho";




                daKhachHang = new SqlDataAdapter("select KHACHHANG.MaKH,KHACHHANG.TenCty,KHACHHANG.DiaChi,KHACHHANG.ThanhPho,KHACHHANG.DienThoai FROM KHACHHANG,THANHPHO where KHACHHANG.ThanhPho=THANHPHO.ThanhPho", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);

                this.cbThanhPho.DataSource = dtThanhPho;
                this.cbThanhPho.DisplayMember = "TenThanhPho";
                this.cbThanhPho.ValueMember = "ThanhPho";
                dgvThanhPho.DataSource = dtKhachHang;

                this.txtTongSoKH.Enabled = false;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không láy được dữ liệu", "Error");
            }
           
        }


       
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKhachHang.Dispose();
            dtThanhPho.Dispose();
            dtKhachHang = null;
            dtThanhPho = null;
            conn = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                daKhachHang = new SqlDataAdapter("select KHACHHANG.MaKH,KHACHHANG.TenCty,KHACHHANG.DiaChi,KHACHHANG.ThanhPho,KHACHHANG.DienThoai FROM KHACHHANG,THANHPHO where KHACHHANG.ThanhPho='" +
                    this.cbThanhPho.SelectedValue.ToString()+ "' AND THANHPHO.ThanhPho='"+this.cbThanhPho.SelectedValue.ToString()+"'", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                dgvThanhPho.DataSource = dtKhachHang;
           
                this.txtTongSoKH.Text = (dgvThanhPho.RowCount - 1).ToString();
               
               
            }
            catch (SqlException)
            {
                MessageBox.Show("KHông lấy  được dữ liệu !!!", "lỗi rồi");
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            this.txtTongSoKH.Text = "";
            LoadData();

        }
    }
}
