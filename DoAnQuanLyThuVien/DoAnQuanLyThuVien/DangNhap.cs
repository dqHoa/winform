using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnQuanLyThuVien.BusinessTier;
using DoAnQuanLyThuVien.DataContext;
namespace DoAnQuanLyThuVien
{    
    public partial class DangNhap : Form
    {

        private TaiKhoanBT taiKhoanBT;
        public DangNhap()
        {
            InitializeComponent();
            taiKhoanBT = new TaiKhoanBT();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui Lòng Nhập Tên Đăng Nhập !!");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Vui Lòng Nhập Mật Khẩu !!");
                return;
            }
            string tenDangNhap = textBox1.Text;
            string matKhau = textBox2.Text;
            NhanVien taiKhoan = taiKhoanBT.LayTaiKhoan(tenDangNhap, matKhau);
            if (taiKhoan!=null)
            {
                    MessageBox.Show("Đăng Nhập Thành Công");                    
                    GiaoDien form = new GiaoDien(taiKhoan);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
            ("Bạn có chắc muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (h == DialogResult.Yes)
                Application.Exit();
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            DangNhap formDangNhap = new DangNhap();            
            formDangNhap.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
