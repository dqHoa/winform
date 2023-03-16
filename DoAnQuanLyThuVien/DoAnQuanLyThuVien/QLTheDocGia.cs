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
    public partial class QLTheDocGia : Form
    {
        QuanLyThuVien dbcontext;
        public QLTheDocGia()
        {
            InitializeComponent();
            dbcontext = new QuanLyThuVien();
        }
        private void FillDataToListView(List<TheDocGia> listnv)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();
            List<string> nv;
            foreach (TheDocGia s in listnv)
            {
                nv = new List<string>();
                nv.Add(s.MaThe);
                nv.Add(s.TenDocGia);
                nv.Add(s.NgaySinh.Value.ToString("dd/MM/yyyy"));
                nv.Add(s.NgayCapThe.Value.ToString("dd/MM/yyyy"));
                nv.Add(s.NgayHetHan.Value.ToString("dd/MM/yyyy"));
                nv.Add(s.GioiTinh);
                nv.Add(s.Diachi);
                nv.Add(s.SDT);
                ListViewItem listViewItem = new ListViewItem(nv.ToArray());
                listView1.Items.Add(listViewItem);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Mã Thẻ", 100);
            listView1.Columns.Add("Tên Đọc Giả", 100);
            listView1.Columns.Add("Ngày Sinh", 100);
            listView1.Columns.Add("Ngày Cấp Thẻ", 100);
            listView1.Columns.Add("Ngày Hết Hạn", 100);
            listView1.Columns.Add("Giới Tính", 100);
            listView1.Columns.Add("Địa Chỉ", 100);
            listView1.Columns.Add("Số ĐT", 100);
            button4.Enabled = false;
            button5.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            listView1.FullRowSelect = true;
            radioButton2.Checked = true;
            textBox1.MaxLength = 6;
            textBox2.MaxLength = 50;
            textBox3.MaxLength = 100;
            textBox4.MaxLength = 15;           
            List<string> Listtimkiem = new List<string>();
            Listtimkiem.Add("Mã Thẻ");
            Listtimkiem.Add("Tên Đọc Giả");            
            foreach (var item in Listtimkiem)
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.Text = "Mã Thẻ";
            FillDataToListView(dbcontext.TheDocGias.ToList<TheDocGia>());
        }
        private string FindID(string ma)
        {
            TheDocGia nv = dbcontext.TheDocGias.FirstOrDefault<TheDocGia>(s => s.MaThe.ToString().CompareTo(ma) == 0);
            if (nv != null)
            {
                return nv.MaThe;
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
            dateTimePicker3.Value = DateTime.Now;
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
                    MessageBox.Show("Đã có mã thẻ này ! Bạn có thể bấm sửa để sửa thông tin thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool Remove = false;
            if (MessageBox.Show("Bạn có muốn xoá thẻ này không? ", "Thông Báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (FindID(textBox1.Text) != null)
                {
                    TheDocGia sa = dbcontext.TheDocGias.FirstOrDefault<TheDocGia>(s => s.MaThe.ToString().CompareTo(textBox1.Text) == 0);
                    dbcontext.TheDocGias.Remove(sa);
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
                MessageBox.Show("Không tìm thấy thẻ cần xoá !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reset();
            FillDataToListView(dbcontext.TheDocGias.ToList());

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
                    MessageBox.Show("Thẻ này chưa đc thêm ! Bạn hãy bấm thêm để thêm thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TheDocGia nv = new TheDocGia();
                nv.MaThe = textBox1.Text;
                nv.TenDocGia = textBox2.Text;
                nv.Diachi = textBox4.Text;
                nv.SDT = textBox3.Text;
                nv.NgaySinh = dateTimePicker2.Value;
                nv.NgayCapThe = dateTimePicker1.Value;
                nv.NgayHetHan = dateTimePicker1.Value;
                if (radioButton1.Checked)
                {
                    nv.GioiTinh = "Nam";
                }
                else
                {
                    nv.GioiTinh = "Nữ";
                }
                dbcontext.TheDocGias.Add(nv);
                dbcontext.SaveChanges();
            }
            else
            {
                TheDocGia nv = dbcontext.TheDocGias.FirstOrDefault<TheDocGia>(s => s.MaThe.ToString().CompareTo(textBox1.Text) == 0);
                nv.TenDocGia = textBox2.Text;
                nv.Diachi = textBox4.Text;
                nv.SDT = textBox3.Text;
                nv.NgaySinh = dateTimePicker2.Value;
                nv.NgayCapThe = dateTimePicker1.Value;
                nv.NgayHetHan = dateTimePicker1.Value;
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
            FillDataToListView(dbcontext.TheDocGias.ToList());
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
                TheDocGia nv = dbcontext.TheDocGias.FirstOrDefault<TheDocGia>(s => s.MaThe.ToString().CompareTo(manv) == 0);
                if (nv != null)
                {
                    textBox1.Text = nv.MaThe;
                    textBox2.Text = nv.TenDocGia;
                    textBox4.Text = nv.Diachi;
                    textBox3.Text = nv.SDT;
                    dateTimePicker2.Value = (DateTime)nv.NgaySinh;
                    dateTimePicker1.Value = (DateTime)nv.NgayCapThe;
                    dateTimePicker1.Value = (DateTime)nv.NgayHetHan;
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
            List<TheDocGia> stdList = new List<TheDocGia>();
            if (comboBox2.Text == "Mã Thẻ")
            {
                stdList = dbcontext.TheDocGias.Where(s =>
                         s.MaThe.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Tên Đọc Giả")
            {
                stdList = dbcontext.TheDocGias.Where(s =>
                         s.TenDocGia.Contains(txtFind.Text.ToUpper())
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
            comboBox2.Text = "Mã Thẻ";
            FillDataToListView(dbcontext.TheDocGias.ToList<TheDocGia>());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timkiem();
        }
    }
}
