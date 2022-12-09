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
    public partial class Form8 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        SqlConnection conn = null;
        SqlDataAdapter daHoaDon = null;
        DataTable dtHoaDon = null;

        SqlDataAdapter daKhachHang = null;
        DataTable dtKhachHang = null;

        SqlDataAdapter daNhanVien = null;
        DataTable dtNhanVien = null;

        bool Them;
        public Form8()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daKhachHang = new SqlDataAdapter("SELECT *FROM KHACHHANG", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                (dgvHoaDon.Columns["MaKH"] as DataGridViewComboBoxColumn).DataSource = dtKhachHang;
                (dgvHoaDon.Columns["MaKH"] as DataGridViewComboBoxColumn).DisplayMember = "TenCty";
                (dgvHoaDon.Columns["MaKH"] as DataGridViewComboBoxColumn).ValueMember = "MaKH";

                daNhanVien = new SqlDataAdapter("SELECT *FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).DisplayMember = "Ten";
                (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";

                daHoaDon = new SqlDataAdapter("SELECT *FROM HOADON", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);

                dgvHoaDon.DataSource = dtHoaDon;

                this.txtMaHD.ResetText();
               
                this.dtimeNgayLapHD.ResetText();
                this.dtimeNgayNhanHang.ResetText();
                this.panel1.Enabled = false;

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
                MessageBox.Show("kKHONG LAY DUOC NOI DUNG BANG HOA DON ", "ERROR");
            }
        }

        private void Form8_Load(object sender, EventArgs e)
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
            this.txtMaHD.ResetText();
            this.dtimeNgayLapHD.ResetText();
            this.dtimeNgayNhanHang.ResetText();

            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel1.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;

            this.cbMaKH.DataSource = dtKhachHang;
            this.cbMaKH.DisplayMember = "TenCty";
            this.cbMaKH.ValueMember = "MaKH";

            this.cbMaNV.DataSource = dtNhanVien;
            this.cbMaNV.DisplayMember = "Ten";
            this.cbMaNV.ValueMember = "MaNV";
            this.txtMaHD.Focus();
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtHoaDon.Dispose();
            dtHoaDon = null;
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

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.txtMaHD.ResetText();
            this.dtimeNgayLapHD.ResetText();
            this.dtimeNgayNhanHang.ResetText();

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

            this.cbMaKH.DataSource = dtKhachHang;
            this.cbMaKH.DisplayMember = "Ten";
            this.cbMaKH.ValueMember = "MaKH";

            this.cbMaNV.DataSource = dtNhanVien;
            this.cbMaNV.DisplayMember = "Ten";
            this.cbMaNV.ValueMember = "MaNV";

            this.panel1.Enabled = true;
            int r = dgvHoaDon.CurrentCell.RowIndex;
            this.txtMaHD.Text = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            this.cbMaKH.SelectedValue = dgvHoaDon.Rows[r].Cells[1].Value.ToString();
            this.cbMaNV.SelectedValue = dgvHoaDon.Rows[r].Cells[2].Value.ToString();
            this.dtimeNgayLapHD.Value = Convert.ToDateTime(dgvHoaDon.Rows[r].Cells[3].Value);
            this.dtimeNgayNhanHang.Value = Convert.ToDateTime(dgvHoaDon.Rows[r].Cells[4].Value);

            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel1.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;

            this.txtMaHD.Focus();
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
                    cmd.CommandText = System.String.Concat("INSERT INTO HOADON VALUES("+"'" + 
                        txtMaHD.Text.ToString() + "','" + 
                        cbMaKH.SelectedValue.ToString() + "','" + 
                        cbMaNV.SelectedValue.ToString() + "','" + 
                        this.dtimeNgayLapHD.Value + "','" + 
                        this.dtimeNgayNhanHang.Value + "'"+")");
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
                    int r = dgvHoaDon.CurrentCell.RowIndex;

                    String strMaHD = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
                    cmd.CommandText = System.String.Concat("UPDATE HOADON SET MaKH='" +
                        this.cbMaKH.SelectedValue.ToString() + "',MaNV='" +
                        this.cbMaNV.SelectedValue.ToString() + "',NgayLapHD='" +
                        this.dtimeNgayLapHD.Value + "',NgayNhanHang='" +
                        this.dtimeNgayNhanHang.Value + "' WHERE MaHD='" + strMaHD + "'");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dgvHoaDon.CurrentCell.RowIndex;

                string strMaHD = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = "DELETE FROM HOADON WHERE MaHD='" + strMaHD + "'";
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
