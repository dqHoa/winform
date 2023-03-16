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
    public partial class QLPhieuPhat : Form
    {
        QuanLyThuVien dbcontext;       
        public QLPhieuPhat()
        {
            InitializeComponent();
            dbcontext = new QuanLyThuVien();            
        }
        private void FillDataToListView(List<PhieuPhat> listPHIEU)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();
            List<string> phieu;
            foreach (PhieuPhat s in listPHIEU)
            {
                phieu = new List<string>();
                phieu.Add(s.MaPhieuPhat);
                phieu.Add(s.MaPhieu);
                phieu.Add(s.MaNV);
                phieu.Add(s.MaThe);
                phieu.Add(s.Masach);
                phieu.Add(s.PhiPhat.ToString());
                phieu.Add(s.NoiDung);
                phieu.Add(s.Ngay.Value.ToString("dd//MM/yyyy"));              
                ListViewItem listViewItem = new ListViewItem(phieu.ToArray());
                listView1.Items.Add(listViewItem);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Mã PP", 100);
            listView1.Columns.Add("Mã PM", 100);
            listView1.Columns.Add("Mã NV", 100);
            listView1.Columns.Add("Mã Thẻ", 100);
            listView1.Columns.Add("Mã Sách", 100);
            listView1.Columns.Add("Phí Phạt", 100);
            listView1.Columns.Add("Nội Dung", 100);
            listView1.Columns.Add("Ngày Lập Phiếu", 100);
            button4.Enabled = false;
            button5.Enabled = false;                     
            dateTimePicker1.Value = DateTime.Now;           
            listView1.FullRowSelect = true;
            textBox1.MaxLength = 6;
            textBox2.MaxLength = 6;
            textBox3.MaxLength = 6;
            textBox4.MaxLength = 6;
            textBox5.MaxLength = 6;            
            textBox7.MaxLength = 100;
            List<string> Listtimkiem = new List<string>();
            Listtimkiem.Add("Mã PP");
            Listtimkiem.Add("Mã PM");
            Listtimkiem.Add("Mã Thẻ");
            Listtimkiem.Add("Mã Sách");
            foreach (var item in Listtimkiem)
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.Text = "Mã PP";
            FillDataToListView(dbcontext.PhieuPhats.ToList<PhieuPhat>());
        }
        private string FindID(string maphieu)
        {
            PhieuPhat sa = dbcontext.PhieuPhats.FirstOrDefault<PhieuPhat>(s => s.MaPhieuPhat.ToString().CompareTo(maphieu) == 0);
            if (sa != null)
            {
                return sa.MaPhieuPhat;
            }

            return null;
        }

        private bool Kiemtradulieu()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text)|| string.IsNullOrWhiteSpace(textBox4.Text)|| string.IsNullOrWhiteSpace(textBox5.Text)||
                string.IsNullOrWhiteSpace(textBox6.Text)|| string.IsNullOrWhiteSpace(textBox7.Text))
            {
                return false;
            }
            else
                if (!decimal.TryParse(textBox6.Text, out decimal n))
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
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
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
                    MessageBox.Show("Đã có mã phiếu này ! Bạn có thể bấm sửa để sửa thông tin phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool Remove = false;
            if (MessageBox.Show("Bạn có muốn xoá phiếu này không? ", "Thông Báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (FindID(textBox1.Text) != null)
                {
                    PhieuPhat sa = dbcontext.PhieuPhats.FirstOrDefault<PhieuPhat>(s => s.MaPhieuPhat.ToString().CompareTo(textBox1.Text) == 0);
                    dbcontext.PhieuPhats.Remove(sa);
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
                MessageBox.Show("Không tìm thấy phiếu cần xoá !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reset();
            FillDataToListView(dbcontext.PhieuPhats.ToList());

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
                    MessageBox.Show("Phiếu này chưa đc thêm ! Bạn hãy bấm thêm để thêm phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (string.IsNullOrEmpty(FindID(textBox1.Text)))
                {
                    PhieuPhat sa = new PhieuPhat();
                    sa.MaPhieuPhat = textBox1.Text;
                    sa.MaPhieu = textBox2.Text;
                    sa.MaNV = textBox3.Text;
                    sa.MaThe = textBox4.Text;
                    sa.Masach = textBox5.Text;
                    decimal phiphat = 0;
                    decimal.TryParse(textBox6.Text, out phiphat);
                    sa.PhiPhat = phiphat;
                    sa.NoiDung = textBox7.Text;
                    sa.Ngay = dateTimePicker1.Value;
                    dbcontext.PhieuPhats.Add(sa);
                    dbcontext.SaveChanges();
                }
                else
                {
                    PhieuPhat sa = dbcontext.PhieuPhats.FirstOrDefault<PhieuPhat>(s => s.MaPhieuPhat.ToString().CompareTo(textBox1.Text) == 0);
                    sa.MaPhieu = textBox2.Text;
                    sa.MaNV = textBox3.Text;
                    sa.MaThe = textBox4.Text;
                    sa.Masach = textBox5.Text;
                    decimal phiphat = 0;
                    decimal.TryParse(textBox6.Text, out phiphat);
                    sa.PhiPhat = phiphat;
                    sa.NoiDung = textBox7.Text;
                    sa.Ngay = dateTimePicker1.Value;
                    dbcontext.SaveChanges();
                }
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                button5.Enabled = false;
                reset();
                FillDataToListView(dbcontext.PhieuPhats.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                string maphieu = listView1.SelectedItems[0].SubItems[0].Text;
                PhieuPhat sa = dbcontext.PhieuPhats.FirstOrDefault<PhieuPhat>(s => s.MaPhieuPhat.ToString().CompareTo(maphieu) == 0);
                if (sa != null)
                {
                    textBox1.Text = sa.MaPhieuPhat;
                    textBox2.Text = sa.MaPhieu;
                    textBox3.Text = sa.MaNV;
                    textBox4.Text = sa.MaThe;
                    textBox5.Text = sa.Masach;
                    textBox6.Text = sa.PhiPhat.ToString();
                    textBox7.Text = sa.NoiDung;
                    dateTimePicker1.Value = (DateTime)sa.Ngay;                                      
                }
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            timkiem();
        }
        private void timkiem()
        {
            List<PhieuPhat> stdList = new List<PhieuPhat>();
            if (comboBox2.Text == "Mã PP")
            {
                stdList = dbcontext.PhieuPhats.Where(s =>
                         s.MaPhieuPhat.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Mã PM")
            {
                stdList = dbcontext.PhieuPhats.Where(s =>
                         s.MaPhieu.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Mã Thẻ")
            {
                stdList = dbcontext.PhieuPhats.Where(s =>
                         s.MaThe.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Mã Sách")
            {
                stdList = dbcontext.PhieuPhats.Where(s =>
                         s.Masach.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            FillDataToListView(stdList);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            txtFind.Text = "";
            comboBox2.Text = "Mã PP";
            FillDataToListView(dbcontext.PhieuPhats.ToList<PhieuPhat>());
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timkiem();
        }
    }
}
