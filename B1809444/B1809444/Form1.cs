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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public void frmlogin()
        {
            Form frm = new Form2();
            frm.ShowDialog();
        }

        public void XemDanhMuc(int intDanhMuc)
        {
            Form frm = new Form3();
            frm.Text = intDanhMuc.ToString();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmlogin();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlogin();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(traloi == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void danhMụcThànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(1);
        }

        private void danhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(2);
        }

        private void danhMụcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(3);
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(4);
        }

        private void danhMụcHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(5);
        }

        private void danhMụcChiTiếtHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(6);
        }

        private void danhMụcThànhPhốToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.Text = "Quán Lý Danh Mục Thành Phố";
            frm.ShowDialog();
        }

        private void danhMụcKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.Text = "Quản Lý Danh Mục Khách Hàng";
            frm.ShowDialog();
        }

        private void danhMụcNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.Text = "Quản Lý Danh Mục Nhân Viên";
            frm.ShowDialog();
        }

        private void danhMụcSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form7();
            frm.Text = "Quản Lý Danh Mục Sản Phẩm";
            frm.ShowDialog();
        }

        private void danhMụcHoáĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form8();
            frm.Text = "QuẢN Lý Danh Mục Hoá Đơn";
            frm.ShowDialog();
        }

        private void danhMụcChiTiếtHoáĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form9();
            frm.Text = "Quản Lý Chi Tiết Hoá Đơn";
            frm.ShowDialog();
        }

        private void kháchHàngTheoThànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form10();
            frm.Text = "Quản Lý Khách Hàng Theo Thành Phố";
            frm.ShowDialog();
        }

        private void hoáĐơnTheoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form11();
            frm.Text = "Hoá đơn Theo Khách Hàng";
            frm.ShowDialog();
        }

        private void hoáĐơnTheoSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form12();
            frm.Text = "HOÁ ĐƠN THEO SẢN PHẨM";
            frm.ShowDialog();
        }
    }
}
