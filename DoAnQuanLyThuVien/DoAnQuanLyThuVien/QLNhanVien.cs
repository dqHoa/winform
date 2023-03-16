using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnQuanLyThuVien.DataContext;
namespace DoAnQuanLyThuVien
{
    public partial class QLNhanVien : Form
    {
        QuanLyThuVien dbcontext;
        public QLNhanVien()
        {
            InitializeComponent();
            dbcontext = new QuanLyThuVien();
        }
        private void FillDataToListView(List<NhanVien> listnv)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();
            List<string> nv;
            foreach (NhanVien s in listnv)
            {
                nv = new List<string>();
                nv.Add(s.MaNV);
                nv.Add(s.TenNV);
                nv.Add(s.NgaySinh.Value.ToString("dd/MM/yyyy"));
                nv.Add(s.NgayVaoLam.Value.ToString("dd/MM/yyyy"));
                nv.Add(s.GioiTinh);
                nv.Add(s.Diachi);
                nv.Add(s.SDT);
                ListViewItem listViewItem = new ListViewItem(nv.ToArray());
                listView1.Items.Add(listViewItem);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Mã NV", 100);
            listView1.Columns.Add("Tên NV", 100);
            listView1.Columns.Add("Ngày Sinh", 100);
            listView1.Columns.Add("Ngày Vào Làm", 100);
            listView1.Columns.Add("Giới Tính", 100);
            listView1.Columns.Add("Địa Chỉ", 100);
            listView1.Columns.Add("Số ĐT", 100);
            button4.Enabled = false;
            button5.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            listView1.FullRowSelect = true;
            radioButton2.Checked = true;
            textBox1.MaxLength = 6;
            textBox2.MaxLength = 50;
            textBox3.MaxLength = 100;
            textBox4.MaxLength = 15;
            
            List<string> Listtimkiem = new List<string>();
            Listtimkiem.Add("Mã NV");
            Listtimkiem.Add("Tên NV");            
            foreach (var item in Listtimkiem)
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.Text = "Mã NV";
            FillDataToListView(dbcontext.NhanViens.ToList<NhanVien>());
        }
        private string FindID(string manv)
        {
            NhanVien nv = dbcontext.NhanViens.FirstOrDefault<NhanVien>(s => s.MaNV.ToString().CompareTo(manv) == 0);
            if (nv != null)
            {
                return nv.MaNV;
            }
            return null;
        }

        private bool Kiemtradulieu()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text)|| string.IsNullOrWhiteSpace(textBox4.Text))
            {
                return false;
            }
            else
                if (!double.TryParse(textBox3.Text, out double n))
            {
                return false;
            }
            return true;
        }

        private void reset()
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            radioButton2.Checked = true;
            textBox4.Text = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Kiemtradulieu())
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                if (string.IsNullOrEmpty(FindID(textBox1.Text)))
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    button5.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Đã có mã nhân viên này ! Bạn có thể bấm sửa để sửa thông tin nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool Remove = false;
            if (MessageBox.Show("Bạn có muốn xoá nhân viên này không? ", "Thông Báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (FindID(textBox1.Text) != null)
                {
                    NhanVien sa = dbcontext.NhanViens.FirstOrDefault<NhanVien>(s => s.MaNV.ToString().CompareTo(textBox1.Text) == 0);
                    dbcontext.NhanViens.Remove(sa);
                    dbcontext.SaveChanges();
                    Remove = true;
                    MessageBox.Show("Xoá thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                }
            }
            else
            {
                return;
            }
            if (!Remove)
            {
                MessageBox.Show("Không tìm thấy nhân viên cần xoá !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reset();
            FillDataToListView(dbcontext.NhanViens.ToList());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Kiemtradulieu())
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (string.IsNullOrEmpty(FindID(textBox1.Text)))
                {
                    MessageBox.Show("Nhân viên này chưa đc thêm ! Bạn hãy bấm thêm để thêm nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    button5.Enabled = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FindID(textBox1.Text)))
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = textBox1.Text;
                nv.TenNV = textBox2.Text;
                nv.Diachi = textBox4.Text;
                nv.SDT = textBox3.Text;
                nv.NgaySinh = dateTimePicker2.Value;
                nv.NgayVaoLam = dateTimePicker1.Value;
                nv.MatKhau = "202cb962ac59075b964b07152d234b70";
                if (radioButton1.Checked)
                {
                    nv.GioiTinh = "Nam";
                }
                else
                {
                    nv.GioiTinh = "Nữ";
                }
                dbcontext.NhanViens.Add(nv);
                dbcontext.SaveChanges();
            }
            else
            {
                NhanVien nv = dbcontext.NhanViens.FirstOrDefault<NhanVien>(s => s.MaNV.ToString().CompareTo(textBox1.Text) == 0);
                nv.TenNV = textBox2.Text;
                nv.Diachi = textBox4.Text;
                nv.SDT = textBox3.Text;
                nv.NgaySinh = dateTimePicker2.Value;
                nv.NgayVaoLam = dateTimePicker1.Value;
                if (radioButton1.Checked)
                {
                    nv.GioiTinh = "Nam";

                }
                else
                {
                    nv.GioiTinh = "Nữ";
                }

                dbcontext.SaveChanges();
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            reset();
            FillDataToListView(dbcontext.NhanViens.ToList());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn không lưu dữ liệu vừa nhập?", "Thông Báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                reset();
            }
            else
            {
                return;
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string manv = listView1.SelectedItems[0].SubItems[0].Text;
                NhanVien nv = dbcontext.NhanViens.FirstOrDefault<NhanVien>(s => s.MaNV.ToString().CompareTo(manv) == 0);
                if (nv != null)
                {
                    textBox1.Text = nv.MaNV;
                    textBox2.Text = nv.TenNV;
                    textBox4.Text = nv.Diachi;
                    textBox3.Text = nv.SDT;
                    dateTimePicker2.Value = (DateTime)nv.NgaySinh;
                    dateTimePicker1.Value = (DateTime)nv.NgayVaoLam;
                    if (nv.GioiTinh == "Nam")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
            }
        }
        private void timkiem()
        {
            List<NhanVien> stdList = new List<NhanVien>();
            if (comboBox2.Text == "Mã NV")
            {
                stdList = dbcontext.NhanViens.Where(s =>
                         s.MaNV.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Tên NV")
            {
                stdList = dbcontext.NhanViens.Where(s =>
                         s.TenNV.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            FillDataToListView(stdList);
        }
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            timkiem();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtFind.Text = "";
            comboBox2.Text = "Mã NV";
            FillDataToListView(dbcontext.NhanViens.ToList<NhanVien>());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timkiem();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ThongKeNhanVien form = new ThongKeNhanVien();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
