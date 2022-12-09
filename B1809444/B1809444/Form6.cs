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
    public partial class Form6 : Form
    {
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        SqlConnection conn ;
        SqlDataAdapter daNhanVien ;
        DataTable dtNhanVien;
        bool Them=false;
        public Form6()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu lên DataTable dtThanhPho
                daNhanVien = new SqlDataAdapter("SELECT * FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                
              
                // Đưa dữ liệu lên DataGridView
                dgvNhanVien.DataSource = dtNhanVien;
                // Thay đổi độ rộng cột
               
                // Xóa trống các đối tượng trong Panel
                this.txtMaNV.ResetText();
                this.txtHo.ResetText();
                this.txtTen.ResetText();
                this.dtimeNgayNV.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDienThoai.ResetText();
                this.chkNu.Checked = false;
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table THANHPHo","Lỗi rồi!!!");
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtNhanVien.Dispose();
            dtNhanVien = null;
            conn =null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;

            this.txtMaNV.ResetText();
            this.txtHo.ResetText();
            this.txtTen.ResetText();
            this.dtimeNgayNV.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            this.chkNu.Checked = false;

            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnSua.Enabled = false;

            this.panel.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;

            this.txtMaNV.Focus();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            Them = false;

            this.panel.Enabled = true;
            int r = dgvNhanVien.CurrentCell.RowIndex;
            this.txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.txtHo.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.txtTen.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.chkNu.Checked = Convert.ToBoolean(dgvNhanVien.Rows[r].Cells[3].Value);
            this.dtimeNgayNV.Value= Convert.ToDateTime(dgvNhanVien.Rows[r].Cells[4].Value);
            this.txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            this.txtDienThoai.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();

            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnTroVe.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;

            this.txtMaNV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (Them) //Thêm dữ liệu vào
            {
                var val = this.chkNu.Checked ? 1 : 0;
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                   
                    cmd.CommandText = System.String.Concat("INSERT INTO NHANVIEN(MaNV,Ho,Ten,Nu,NgayNV,DiaChi,DienThoai) VALUES (" + "'" +
                        this.txtMaNV.Text.ToString() + "','" +
                        this.txtHo.Text.ToString() + "', '"  +
                        this.txtTen.Text.ToString() + "','" +
                        val.ToString() + "','" +
                        this.dtimeNgayNV.Value.ToString() + "', '" + 
                        this.txtDiaChi.Text.ToString()+ "', '" + 
                        this.txtDienThoai.Text.ToString() + "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Thêm thành công");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            if (!Them)// Khi sửa dữ liệu
            {

                int temp = Convert.ToInt32(this.chkNu.Checked);
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    int r = dgvNhanVien.CurrentCell.RowIndex;
                   
                    String strMaNV = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                    
                    DateTime dt = Convert.ToDateTime(dtimeNgayNV.Text);
                    cmd.CommandText = "UPDATE NHANVIEN SET Ho='" + txtHo.Text.ToString() + "',Ten='" + txtTen.Text.ToString()+ "',Nu= '" + temp.ToString()+ "',NgayNV='" + dtimeNgayNV.Value + "',DiaChi='"+ txtDiaChi.Text.ToString()+"',DienThoai='"+ this.txtDienThoai.Text.ToString()+"' WHERE MaNV='" + strMaNV + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Đã cập nhật thành công ");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được!!!" + "+ temp +", "Lỗi rồi");
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
                int r = dgvNhanVien.CurrentCell.RowIndex;

                string strMaNV = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("DELETE FROM NHANVIEN WHERE MaNV='" + strMaNV + "'");
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

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.txtMaNV.ResetText();
            this.txtHo.ResetText();
            this.txtTen.ResetText();
            this.txtDiaChi.ResetText();
            this.dtimeNgayNV.ResetText();
            this.txtDienThoai.ResetText();
            this.chkNu.CheckState = 0;

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;

            this.btnHuyBo.Enabled = false;
            this.btnLuu.Enabled = false;
            this.panel.Enabled = false;
        }
    }
}
