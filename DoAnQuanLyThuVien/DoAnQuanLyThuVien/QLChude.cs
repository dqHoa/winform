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
    public partial class QLChude : Form
    {
        QuanLyThuVien dbcontext;       
        public QLChude()
        {
            InitializeComponent();
            dbcontext = new QuanLyThuVien();            
        }
        private void FillDataToListView(List<Chude> listSach)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();
            List<string> Sach;
            foreach (Chude s in listSach)
            {
                Sach = new List<string>();
                Sach.Add(s.MaCD);
                Sach.Add(s.TenCD);
                ListViewItem listViewItem = new ListViewItem(Sach.ToArray());
                listView1.Items.Add(listViewItem);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Mã Chủ Đề", 100);
            listView1.Columns.Add("Tên Chủ Đề", 100);
            button4.Enabled = false;
            button5.Enabled = false;
            FillDataToListView(dbcontext.Chudes.ToList<Chude>());
            listView1.FullRowSelect = true;
            textBox1.MaxLength = 2;
            textBox2.MaxLength = 30;           
        }
        private string FindID(string masach)
        {
            Chude sa = dbcontext.Chudes.FirstOrDefault<Chude>(s => s.MaCD.ToString().CompareTo(masach) == 0);
            if (sa != null)
            {
                return sa.MaCD;
            }

            return null;
        }

        private bool Kiemtradulieu()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)
                )
            {
                return false;
            }
            return true;
        }

        private void reset()
        {          
            textBox1.Text = null;
            textBox2.Text = null;          
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
                    MessageBox.Show("Đã có chủ đề này ! Bạn có thể bấm sửa để sửa thông chủ đề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool Remove = false;
            if (MessageBox.Show("Bạn có muốn xoá chủ đề này không? ", "Thông Báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (FindID(textBox1.Text) != null)
                {
                    Chude sa = dbcontext.Chudes.FirstOrDefault<Chude>(s => s.MaCD.ToString().CompareTo(textBox1.Text) == 0);
                    dbcontext.Chudes.Remove(sa);
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
                MessageBox.Show("Không tìm thấy chủ đề cần xoá !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reset();
            FillDataToListView(dbcontext.Chudes.ToList());

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
                    MessageBox.Show("Chủ đề này chưa đc thêm ! Bạn hãy bấm thêm để thêm chủ đề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Chude sa = new Chude();
                sa.MaCD = textBox1.Text;
                sa.TenCD = textBox2.Text;               
                dbcontext.Chudes.Add(sa);
                dbcontext.SaveChanges();
            }
            else
            {
                Chude sa = dbcontext.Chudes.FirstOrDefault<Chude>(s => s.MaCD.ToString().CompareTo(textBox1.Text) == 0);
                sa.TenCD = textBox2.Text;
                dbcontext.SaveChanges();
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            reset();
            FillDataToListView(dbcontext.Chudes.ToList());
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
                Chude sa = dbcontext.Chudes.FirstOrDefault<Chude>(s => s.MaCD.ToString().CompareTo(masach) == 0);
                if (sa != null)
                {
                    textBox1.Text = sa.MaCD;
                    textBox2.Text = sa.TenCD;                   
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
            FillDataToListView(dbcontext.Chudes.ToList<Chude>());
        }
        private void timkiem()
        {
            List<Chude> stdList = new List<Chude>();
                stdList = dbcontext.Chudes.Where(s =>
                         s.TenCD.Contains(txtFind.Text.ToUpper())
                         ).ToList();                       
            FillDataToListView(stdList);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timkiem();
        }
    }
    
}
