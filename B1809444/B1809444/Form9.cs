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
    public partial class Form9 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        SqlConnection conn = null;

        SqlDataAdapter daChiTietHoaDon = null;
        DataTable dtChiTietHoaDon = null;

        SqlDataAdapter daHoaDon = null;
        DataTable dtHoaDon = null;

        SqlDataAdapter daSanPham = null;
        DataTable dtSanPham = null;
        bool Them;
        public Form9()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daHoaDon = new SqlDataAdapter("SELECT *FROM HOADON", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                (dgvChiTietHoaDon.Columns["MaHD"] as DataGridViewComboBoxColumn).DataSource = dtHoaDon;
                (dgvChiTietHoaDon.Columns["MaHD"] as DataGridViewComboBoxColumn).DisplayMember = "MaHD";
                (dgvChiTietHoaDon.Columns["MaHD"] as DataGridViewComboBoxColumn).ValueMember = "MaHD";


                daSanPham = new SqlDataAdapter("SELECT *FROM SANPHAM", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                (dgvChiTietHoaDon.Columns["MaSP"] as DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgvChiTietHoaDon.Columns["MaSP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                (dgvChiTietHoaDon.Columns["MaSP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";

                daChiTietHoaDon = new SqlDataAdapter("select *from CHITIETHOADON", conn);
                dtChiTietHoaDon= new DataTable();
                dtChiTietHoaDon.Clear();
                daChiTietHoaDon.Fill(dtChiTietHoaDon);

                dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;

                this.txtSoLuong.ResetText();


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
                MessageBox.Show("Không lấy được nội dung trong table chi tiet hoa don.Lỗi rồi!!!");
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtChiTietHoaDon.Dispose();
            dtChiTietHoaDon = null;
            conn = null;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtSoLuong.ResetText();
           

            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel1.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;

            this.cbMaHD.DataSource = dtHoaDon;
            this.cbMaHD.DisplayMember = "MaHD";
            this.cbMaHD.ValueMember = "MaHD";

            this.cbMaSP.DataSource = dtSanPham;
            this.cbMaSP.DisplayMember = "TenSP";
            this.cbMaSP.ValueMember = "MaSP";
            this.txtSoLuong.Focus();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.txtSoLuong.ResetText();
            
            

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;

            this.btnHuyBo.Enabled = false;
            this.btnLuu.Enabled = false;
            this.panel1.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;

            this.cbMaHD.DataSource = dtHoaDon;
            this.cbMaHD.DisplayMember = "MaHD";
            this.cbMaHD.ValueMember = "MaHD";

            this.cbMaSP.DataSource = dtSanPham;
            this.cbMaSP.DisplayMember = "TenSP";
            this.cbMaSP.ValueMember = "MaSP";

            this.panel1.Enabled = true;
            int r = dgvChiTietHoaDon.CurrentCell.RowIndex;
           
            this.cbMaHD.SelectedValue = dgvChiTietHoaDon.Rows[r].Cells[0].Value.ToString();
            this.cbMaSP.SelectedValue = dgvChiTietHoaDon.Rows[r].Cells[1].Value.ToString();
            this.txtSoLuong.Text =Convert.ToString(dgvChiTietHoaDon.Rows[r].Cells[2].Value);


            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel1.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;

            this.txtSoLuong.Focus();
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
                    cmd.CommandText = System.String.Concat("INSERT INTO CHITIETHOADON VALUES('" + this.cbMaHD.SelectedValue.ToString() + "','" + cbMaSP.SelectedValue.ToString() + "','" + this.txtSoLuong.Text.ToString() + "')");
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
                    int r = dgvChiTietHoaDon.CurrentCell.RowIndex;

                    String strMaHD = dgvChiTietHoaDon.Rows[r].Cells[0].Value.ToString();
                    String strMaSP = dgvChiTietHoaDon.Rows[r].Cells[1].Value.ToString();
                    cmd.CommandText = System.String.Concat("UPDATE CHITIETHOADON SET SoLuong ='" + 
                        this.txtSoLuong.Text.ToString() + "' WHERE MaHD='"+ 
                        strMaHD + "' AND  MaSP='" + 
                        strMaSP + "'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Cập nhật thành công '"+strMaHD+"'");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Khoong cap nhat duoc!!!!","Loi roi");
                }

            }
            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dgvChiTietHoaDon.CurrentCell.RowIndex;

                string strMaHD = dgvChiTietHoaDon.Rows[r].Cells[0].Value.ToString();
                string strMaSP = dgvChiTietHoaDon.Rows[r].Cells[1].Value.ToString();
                cmd.CommandText = System.String.Concat("DELETE FROM CHITIETHOADON WHERE MaHD='" + 
                    strMaHD + "' AND MaSP='" + 
                    strMaSP + "'");
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
    }
}
