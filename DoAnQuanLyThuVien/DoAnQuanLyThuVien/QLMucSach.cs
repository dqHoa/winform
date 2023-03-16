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
    public partial class QLMucSach : Form
    {
        QuanLyThuVien dbcontext;       
        public QLMucSach()
        {
            InitializeComponent();
            dbcontext = new QuanLyThuVien();            
        }
        private void FillDataToListView(List<Sach> listSach)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();
            List<string> Sach;
            foreach (Sach s in listSach)
            {
                Sach = new List<string>();
                Sach.Add(s.Masach);
                Sach.Add(s.Tensach);
                Sach.Add(s.Tacgia);
                Sach.Add(s.Ngaynhap.Value.ToString("dd/MM/yyyy"));              
                Sach.Add(s.Chude.TenCD);
                Sach.Add(s.TenNXB);
                ListViewItem listViewItem = new ListViewItem(Sach.ToArray());
                listView1.Items.Add(listViewItem);
            }
        }
        private void Fillcombobox(List<Chude> listCD)
        {
            comboBox1.DataSource = listCD;
            comboBox1.DisplayMember = "TenCD";
            comboBox1.ValueMember = "MaCD";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Mã Sách", 100);
            listView1.Columns.Add("Tên Sách", 100);
            listView1.Columns.Add("Tác Giả", 100);
            listView1.Columns.Add("Ngày Nhập", 100);
            listView1.Columns.Add("Chủ Đề", 100);
            listView1.Columns.Add("Nhà Xuất Bản", 100);
            button4.Enabled = false;
            button5.Enabled = false;
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Công nghệ");           
            dateTimePicker1.Value = DateTime.Now;
            Fillcombobox(dbcontext.Chudes.ToList<Chude>());            
            listView1.FullRowSelect = true;
            textBox1.MaxLength = 6;
            textBox2.MaxLength = 30;
            textBox3.MaxLength = 30;
            List<string> Listtimkiem = new List<string>();
            Listtimkiem.Add("Mã Sách");
            Listtimkiem.Add("Tên Sách");
            Listtimkiem.Add("Tác Giả");
            Listtimkiem.Add("Chủ Đề");
            Listtimkiem.Add("NXB");            
            foreach (var item in Listtimkiem)
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.Text = "Mã Sách";
            FillDataToListView(dbcontext.Saches.ToList<Sach>());
        }
        private string FindID(string masach)
        {
            Sach sa = dbcontext.Saches.FirstOrDefault<Sach>(s => s.Masach.ToString().CompareTo(masach) == 0);
            if (sa != null)
            {
                return sa.Masach;
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
            return true;
        }

        private void reset()
        {
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Công nghệ");            
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
                    MessageBox.Show("Đã có mã sách này ! Bạn có thể bấm sửa để sửa thông tin sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool Remove = false;
            if (MessageBox.Show("Bạn có muốn xoá sách này không? ", "Thông Báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (FindID(textBox1.Text) != null)
                {
                    Sach sa = dbcontext.Saches.FirstOrDefault<Sach>(s => s.Masach.ToString().CompareTo(textBox1.Text) == 0);
                    dbcontext.Saches.Remove(sa);
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
                MessageBox.Show("Không tìm thấy sách cần xoá !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reset();
            FillDataToListView(dbcontext.Saches.ToList());

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
                    MessageBox.Show("Sách này chưa đc thêm ! Bạn hãy bấm thêm để thêm Sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Sach sa = new Sach();
                sa.Masach = textBox1.Text;
                sa.Tensach = textBox2.Text;
                sa.Tacgia = textBox3.Text;
                sa.TenNXB = textBox4.Text;
                sa.Ngaynhap = dateTimePicker1.Value;                                
                Chude cd = dbcontext.Chudes.FirstOrDefault<Chude>(l => l.TenCD.ToString().CompareTo(comboBox1.Text) == 0);
                if (cd != null)
                {
                    sa.MaCD = cd.MaCD;
                }
                dbcontext.Saches.Add(sa);
                dbcontext.SaveChanges();
            }
            else
            {
                Sach sa = dbcontext.Saches.FirstOrDefault<Sach>(s => s.Masach.ToString().CompareTo(textBox1.Text) == 0);
                sa.Tensach = textBox2.Text;
                sa.Tacgia = textBox3.Text;
                sa.TenNXB = textBox4.Text;
                sa.Ngaynhap = dateTimePicker1.Value;
                Chude cd = dbcontext.Chudes.FirstOrDefault<Chude>(l => l.TenCD.ToString().CompareTo(comboBox1.Text) == 0);
                if (cd != null)
                {
                    sa.MaCD = cd.MaCD;
                }

                dbcontext.SaveChanges();
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            reset();
            FillDataToListView(dbcontext.Saches.ToList());
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
                string masach = listView1.SelectedItems[0].SubItems[0].Text;
                Sach sa = dbcontext.Saches.FirstOrDefault<Sach>(s => s.Masach.ToString().CompareTo(masach) == 0);
                if (sa != null)
                {
                    textBox1.Text = sa.Masach;
                    textBox2.Text = sa.Tensach;
                    textBox3.Text = sa.Tacgia;
                    textBox4.Text = sa.TenNXB;
                    dateTimePicker1.Value = (DateTime)sa.Ngaynhap;                   
                    Chude cd = dbcontext.Chudes.FirstOrDefault<Chude>(l => l.MaCD.ToString().CompareTo(sa.MaCD) == 0);
                    if (cd != null)
                    {
                        comboBox1.SelectedIndex = comboBox1.FindStringExact(cd.TenCD);
                    }
                }
            }
        }
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            timkiem();
        }

        private void button6_Click(object sender, EventArgs e)
        {            
            txtFind.Text = "";
            comboBox2.Text = "Mã Sách";
            FillDataToListView(dbcontext.Saches.ToList<Sach>());
        }
        private void timkiem()
        {
            List<Sach> stdList = new List<Sach>();
            if (comboBox2.Text == "Mã Sách")
            {
                stdList = dbcontext.Saches.Where(s =>
                         s.Masach.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Tên Sách")
            {
                stdList = dbcontext.Saches.Where(s =>
                         s.Tensach.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Tác Giả")
            {
                stdList = dbcontext.Saches.Where(s =>
                         s.Tacgia.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Chủ Đề")
            {
                stdList = dbcontext.Saches.Where(s =>
                         s.Chude.TenCD.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "NXB")
            {
                stdList = dbcontext.Saches.Where(s =>
                         s.TenNXB.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            FillDataToListView(stdList);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timkiem();
        }
    }
    
}
