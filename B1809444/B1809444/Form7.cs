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
    public partial class Form7 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        SqlConnection conn = null;
        SqlDataAdapter daSanPham = null;
        DataTable dtSanPham = null;

        bool Them;
        public Form7()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtThanhPho
                daSanPham = new SqlDataAdapter("SELECT * FROM SANPHAM", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                // Đưa dữ liệu lên DataGridView
                dgvSanPham.DataSource = dtSanPham;
                // Thay đổi độ rộng cột
                dgvSanPham.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                this.txtMaSP.ResetText();
                this.txtTenSP.ResetText();
                this.txtDonViTinh.ResetText();
                this.txtDonGia.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel1.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table SanPham","Lỗi rồi!!!");
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDonViTinh.ResetText();
            this.txtDonGia.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtThanhPho
            this.txtMaSP.Focus();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtSanPham.Dispose();
            dtSanPham = null;
            conn = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            this.panel1.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvSanPham.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaSP.Text =
            dgvSanPham.Rows[r].Cells[0].Value.ToString();
            this.txtTenSP.Text =
            dgvSanPham.Rows[r].Cells[1].Value.ToString();
            this.txtDonViTinh.Text =
           dgvSanPham.Rows[r].Cells[2].Value.ToString();
            this.txtDonGia.Text =
           dgvSanPham.Rows[r].Cells[3].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaSP.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (Them)
            {
               
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText =System.String.Concat( "Insert Into SANPHAM(MaSP,TenSP,DonViTinh,DonGia) Values('" + 
                        this.txtMaSP.Text.ToString() + "','" + 
                        this.txtTenSP.Text.ToString() + "','" +
                        this.txtDonViTinh.Text.ToString() + "','" +
                        this.txtDonGia.Text.ToString() + "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }

            }
            if (!Them)
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Thứ tự dòng hiện hành
                int r = dgvSanPham.CurrentCell.RowIndex;
                // MaKH hiện hành
                string strSanPham =
                dgvSanPham.Rows[r].Cells[0].Value.ToString();
                // Câu lệnh SQL
                cmd.CommandText = System.String.Concat("Update SanPham Set TenSP = '" +
                this.txtTenSP.Text.ToString() + "', DonViTinh = '"+
                this.txtDonViTinh.Text.ToString()+ "', DonGia = '"+
                this.txtDonGia.Text.ToString()+ "' Where MaSP = '" + strSanPham + "'");
                // Cập nhật
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                // Load lại dữ liệu trên DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã sửa xong!");
            }
            // Đóng kết nối
            conn.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDonGia.ResetText();
            this.txtDonViTinh.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel1.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvSanPham.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMaSP =
                dgvSanPham.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From SanPham Where MaSP = '" + strMaSP + "'");
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã xóa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
