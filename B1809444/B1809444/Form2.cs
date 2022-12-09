using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace B1809444
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if( (this.txtUser.Text.Equals("teonv")) && (this.txtPass.Text.Equals("123"))){
                this.Close();
            }
            else
            {
                MessageBox.Show("Không đúng người dùng / mật khẩu ", "Thông báo");
                this.txtUser.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Có muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(traloi==DialogResult.OK)
            {
                Application.Exit();
            }
          
        }
    }
}
