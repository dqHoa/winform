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
using DoAnQuanLyThuVien.Libs;

namespace DoAnQuanLyThuVien
{
    public partial class DoiMatKhau : Form
    {
        private TaiKhoanBT taiKhoanBT;
        QuanLyThuVien dbcontext;
        private NhanVien nhanvien;
        public DoiMatKhau(NhanVien nv)
        {
            nhanvien = nv;
            InitializeComponent();
            dbcontext = new QuanLyThuVien();
            taiKhoanBT = new TaiKhoanBT();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                string oldPass = Helpers.MaHoaMD5(textBox2.Text);
                if (oldPass.CompareTo(nhanvien.MatKhau)==0)
                {
                    if (textBox3.Text.CompareTo(textBox4.Text) == 0)
                    {
                        string error;                        
                        nhanvien.MatKhau = textBox3.Text;
                        if (taiKhoanBT.LuuTaiKhoan(nhanvien, out error))
                        {
                            MessageBox.Show("Lưu Thành Công");
                            
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lưu Thất Bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu không đúng !");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng");
                }
            }
            else
            {
                MessageBox.Show("Điền đủ thông tin !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            textBox1.Text = nhanvien.MaNV;
        }
    }
}
