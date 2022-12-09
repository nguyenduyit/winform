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
    public partial class Form5 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        SqlConnection conn = null;
        SqlDataAdapter daKhachHang = null;
        DataTable dtKhachHang = null;

        SqlDataAdapter daThanhPho = null;
        DataTable dtThanhPho = null;
        bool Them;
        public Form5()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daThanhPho = new SqlDataAdapter("SELECT *FROM THANHPHO", conn);
                dtThanhPho = new DataTable();
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);
                (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DataSource = dtThanhPho;
                (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DisplayMember = "TenThanhpho";
                (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).ValueMember = "ThanhPho";

                daKhachHang = new SqlDataAdapter("SELECT *FROM KHACHHANG", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);

                dgvKhachHang.DataSource = dtKhachHang;

                this.txtMaKH.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDienThoai.ResetText();
                this.txtTenCty.ResetText();

                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel1.Enabled = false;

               
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;

            }
            
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKhachHang.Dispose();
            dtKhachHang = null;
            conn = null;
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
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaKH.ResetText();
            this.txtDiaChi.ResetText();
            this.txtTenCty.ResetText();
            this.txtDienThoai.ResetText();

            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel1.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;

            this.cbThanhPho.DataSource = dtThanhPho;
            this.cbThanhPho.DisplayMember = "TenThanhPho";
            this.cbThanhPho.ValueMember = "ThanhPho";

            this.txtMaKH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            this.cbThanhPho.DataSource = dtThanhPho;
            this.cbThanhPho.DisplayMember = "TenThanhPho";
            this.cbThanhPho.ValueMember = "ThanhPho";

            this.panel1.Enabled = true;
            int r = dgvKhachHang.CurrentCell.RowIndex;
            this.txtMaKH.Text = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            this.txtTenCty.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            this.cbThanhPho.SelectedValue = dgvKhachHang.Rows[r].Cells[3].ToString();
            this.txtDienThoai.Text = dgvKhachHang.Rows[r].Cells[4].Value.ToString();

            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel1.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;

            this.txtMaKH.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dgvKhachHang.CurrentCell.RowIndex;

                string strMaKH = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("DELETE FROM KHACHHANG WHERE MaKH='" + strMaKH + "'");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                LoadData();
                MessageBox.Show("ĐÃ XOÁ XONG");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xoá được", "Lỗi rồi");
            }
            conn.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (Them) //Thêm dữ liệu vào
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO KHACHHANG VALUES('" + txtMaKH.Text.ToString() + "','" + txtTenCty.Text.ToString() + "','" + txtDiaChi.Text.ToString() + "','" +this.cbThanhPho.SelectedValue.ToString() + "','" +this.txtDiaChi.Text.ToString() + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("ĐÃ THÊM THÀNH CÔNG");
                }
                catch (SqlException)
                {
                    MessageBox.Show("KHôn thêm được !!!", "lỗi rồi");
                }

            }
            if (!Them)// Khi sửa dữ liệu
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    int r = dgvKhachHang.CurrentCell.RowIndex;

                    String strMaKH = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                    cmd.CommandText = System.String.Concat("UPDATE KHACHHANG SET TenCty='" +
                        this.txtTenCty.Text.ToString() + "',DiaChi='" +
                        this.txtDiaChi.Text.ToString() + "',ThanhPho='" +
                        this.cbThanhPho.Text.ToString() + "',DienThoai='" +
                        this.txtDienThoai.Text.ToString() + "' WHERE MaKH='" + strMaKH + "'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Đã cập nhật thành công");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được!!!", "Lỗi rồi");
                }
               
            }
            conn.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.txtMaKH.ResetText();
            this.txtDiaChi.ResetText();
            this.txtTenCty.ResetText();
            this.txtDienThoai.ResetText();

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;

            this.btnHuyBo.Enabled = false;
            this.btnLuu.Enabled = false;
            this.panel1.Enabled=false;
        }
    }
}
