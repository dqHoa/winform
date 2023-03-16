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
    public partial class QLPhieuMuon : Form
    {
        QuanLyThuVien dbcontext;       
        public QLPhieuMuon()
        {
            InitializeComponent();
            dbcontext = new QuanLyThuVien();            
        }
        private void FillDataToListView(List<PhieuMuonSach> listPHIEU)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();
            List<string> phieu;
            foreach (PhieuMuonSach s in listPHIEU)
            {
                phieu = new List<string>();
                phieu.Add(s.MaPhieu);               
                phieu.Add(s.MaNV);
                phieu.Add(s.MaThe);
                phieu.Add(s.Masach);
                phieu.Add(s.Ngaymuon.Value.ToString("dd//MM/yyyy"));
                phieu.Add(s.NgayTra.Value.ToString("dd//MM/yyyy"));              
                ListViewItem listViewItem = new ListViewItem(phieu.ToArray());
                listView1.Items.Add(listViewItem);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Mã Phiếu Mượn", 100);
            listView1.Columns.Add("Mã Nhân Viên", 100);
            listView1.Columns.Add("Mã Mã Thẻ", 100);
            listView1.Columns.Add("Mã Sách", 100);           
            listView1.Columns.Add("Nội Mượn", 100);
            listView1.Columns.Add("Ngày Trả", 100);
            button4.Enabled = false;
            button5.Enabled = false;                     
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;           
            listView1.FullRowSelect = true;
            textBoxMP.MaxLength = 6;            
            textBoxMNV.MaxLength = 6;
            textBoxMT.MaxLength = 6;
            textBoxS.MaxLength = 6;                       
            List<string> Listtimkiem = new List<string>();
            Listtimkiem.Add("Mã Thẻ");
            Listtimkiem.Add("Mã Phiếu");            
            Listtimkiem.Add("Mã Nhân Viên");
            foreach (var item in Listtimkiem)
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.Text = "Mã Thẻ";
            FillDataToListView(dbcontext.PhieuMuonSaches.ToList<PhieuMuonSach>());
        }
        private string FindID(string maphieu)
        {
            PhieuMuonSach sa = dbcontext.PhieuMuonSaches.FirstOrDefault<PhieuMuonSach>(s => s.MaPhieu.ToString().CompareTo(maphieu) == 0);
            if (sa != null)
            {
                return sa.MaPhieu;
            }

            return null;
        }

        private bool Kiemtradulieu()
        {
            if (string.IsNullOrWhiteSpace(textBoxMP.Text)  ||
                string.IsNullOrWhiteSpace(textBoxMNV.Text)|| string.IsNullOrWhiteSpace(textBoxMT.Text)|| string.IsNullOrWhiteSpace(textBoxS.Text)
                 )
            {
                return false;
            }
            return true;
        }
        private void reset()
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBoxMP.Text = null;            
            textBoxMNV.Text = null;
            textBoxMT.Text = null;
            textBoxS.Text = null;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Kiemtradulieu())
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                if (string.IsNullOrEmpty(FindID(textBoxMP.Text)))
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
                if (FindID(textBoxMP.Text) != null)
                {
                    PhieuMuonSach sa = dbcontext.PhieuMuonSaches.FirstOrDefault<PhieuMuonSach>(s => s.MaPhieu.ToString().CompareTo(textBoxMP.Text) == 0);
                    dbcontext.PhieuMuonSaches.Remove(sa);
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
            FillDataToListView(dbcontext.PhieuMuonSaches.ToList());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Kiemtradulieu())
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (string.IsNullOrEmpty(FindID(textBoxMP.Text)))
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
                if (string.IsNullOrEmpty(FindID(textBoxMP.Text)))
                {
                    PhieuMuonSach sa = new PhieuMuonSach();
                    sa.MaPhieu = textBoxMP.Text;                    
                    sa.MaNV = textBoxMNV.Text;
                    sa.MaThe = textBoxMT.Text;
                    sa.Masach = textBoxS.Text;                                       
                    sa.Ngaymuon = dateTimePicker1.Value;
                    sa.NgayTra = dateTimePicker2.Value;
                    dbcontext.PhieuMuonSaches.Add(sa);
                    dbcontext.SaveChanges();
                }
                else
                {
                    PhieuMuonSach sa = dbcontext.PhieuMuonSaches.FirstOrDefault<PhieuMuonSach>(s => s.MaPhieu.ToString().CompareTo(textBoxMP.Text) == 0);
                    sa.MaPhieu = textBoxMP.Text;
                    sa.MaNV = textBoxMNV.Text;
                    sa.MaThe = textBoxMT.Text;
                    sa.Masach = textBoxS.Text;
                    sa.Ngaymuon = dateTimePicker1.Value;
                    sa.NgayTra = dateTimePicker2.Value;
                    dbcontext.SaveChanges();
                }
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                button5.Enabled = false;
                reset();
                FillDataToListView(dbcontext.PhieuMuonSaches.ToList());
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
                PhieuMuonSach sa = dbcontext.PhieuMuonSaches.FirstOrDefault<PhieuMuonSach>(s => s.MaPhieu.ToString().CompareTo(maphieu) == 0);
                if (sa != null)
                {
                    textBoxMP.Text = sa.MaPhieu;                    
                    textBoxMNV.Text = sa.MaNV;
                    textBoxMT.Text = sa.MaThe;
                    textBoxS.Text = sa.Masach;
                    dateTimePicker1.Value = (DateTime)sa.Ngaymuon;
                    dateTimePicker2.Value = (DateTime)sa.NgayTra;                                      
                }
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            timkiem();
        }
        private void timkiem()
        {
            List<PhieuMuonSach> stdList = new List<PhieuMuonSach>();
            if (comboBox2.Text == "Mã Thẻ")
            {
                stdList = dbcontext.PhieuMuonSaches.Where(s =>
                         s.MaThe.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Mã Phiếu")
            {
                stdList = dbcontext.PhieuMuonSaches.Where(s =>
                         s.MaPhieu.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            if (comboBox2.Text == "Mã Nhân Viên")
            {
                stdList = dbcontext.PhieuMuonSaches.Where(s =>
                         s.MaNV.Contains(txtFind.Text.ToUpper())
                         ).ToList();
            }
            FillDataToListView(stdList);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            txtFind.Text = "";
            comboBox2.Text = "Mã Thẻ";
            FillDataToListView(dbcontext.PhieuMuonSaches.ToList<PhieuMuonSach>());
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            timkiem();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inPhieuMuon form = new inPhieuMuon();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
