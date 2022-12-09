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
    public partial class Form4 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        SqlConnection conn = null;
        SqlDataAdapter daThanhPho = null;
        DataTable dtThanhPho = null;
        bool Them;

        public Form4()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtThanhPho
                daThanhPho = new SqlDataAdapter("SELECT * FROM THANHPHO", conn);
                dtThanhPho = new DataTable();
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);
                // Đưa dữ liệu lên DataGridView
                dgvThanhPho.DataSource = dtThanhPho;
                // Thay đổi độ rộng cột
                dgvThanhPho.AutoResizeColumns();
                // Xóa trống các đối tượng trong Panel
                this.txtThanhPho.ResetText();
                this.txtTenThanhPho.ResetText();
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
            catch(SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table THANHPHO.Lỗi rồi!!!");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtThanhPho.Dispose();
            dtThanhPho = null;
            conn = null;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtThanhPho.ResetText();
            this.txtTenThanhPho.ResetText();
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
            this.txtThanhPho.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            this.panel1.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvThanhPho.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtThanhPho.Text =
            dgvThanhPho.Rows[r].Cells[0].Value.ToString();
            this.txtTenThanhPho.Text =
            dgvThanhPho.Rows[r].Cells[1].Value.ToString();
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
            this.txtThanhPho.Focus();
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
                int r = dgvThanhPho.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strTHANHPHO =
                dgvThanhPho.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From ThanhPho Where ThanhPho = '" + strTHANHPHO + "'");
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
            // Đóng kết nối
            conn.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtThanhPho.ResetText();
            this.txtTenThanhPho.ResetText();
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
                    cmd.CommandText = System.String.Concat("Insert Into ThanhPho Values(" + "'" +this.txtThanhPho.Text.ToString() + "','" +this.txtTenThanhPho.Text.ToString() + "')");
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
                int r = dgvThanhPho.CurrentCell.RowIndex;
                // MaKH hiện hành
                string strTHANHPHO =
                dgvThanhPho.Rows[r].Cells[0].Value.ToString();
                // Câu lệnh SQL
                cmd.CommandText = System.String.Concat("Update ThanhPho Set TenThanhPho = '" +
                this.txtTenThanhPho.Text.ToString() + "' Where ThanhPho = '" + strTHANHPHO + "'");
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
    }
 }

