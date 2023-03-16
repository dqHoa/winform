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
    public partial class GiaoDien : Form
    {
        private NhanVien nhanvien;
        public GiaoDien(NhanVien nv )
        {           
            nhanvien = nv;
            InitializeComponent();
            this.Load += GiaoDien_Load1;
        }

        private void GiaoDien_Load1(object sender, EventArgs e)
        {
            if (nhanvien.ChucVu == "Quản Lý")
            {
                menuQuanLyNV.Enabled = true;
            }
            else
            {
                menuQuanLyNV.Enabled = false;
            }
            tssLoiChao.Text = nhanvien.TenNV;
  
            
        }
        private void menuDangNhap_Click(object sender, EventArgs e)
        {
            DoiMatKhau form = new DoiMatKhau(nhanvien);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();

        }
        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            foreach(Form item in this.MdiChildren)
            {
                item.Close();
            }
            DangNhap form = new DangNhap();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();           
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
            ("Bạn có chắc muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (h == DialogResult.Yes)
                Application.Exit();
        }

        private void quảnLýDanhMụcSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLMucSach form = new QLMucSach();           
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void quảnLýPhiếuPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLPhieuPhat form = new QLPhieuPhat();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void sáchĐãNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeMucSach form = new ThongKeMucSach();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void thôngKêPhiếuPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpPhieuPhat form = new rpPhieuPhat();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void quảnLýThẻĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTheDocGia form = new QLTheDocGia();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void quảnLýPhiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLPhieuMuon form = new QLPhieuMuon();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void quảnLýChủĐềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLChude form = new QLChude();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void sáchĐangChoMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeSachDangMuon form = new ThongKeSachDangMuon();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeDocGia form = new ThongKeDocGia();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        private void menuQuanLyNV_Click(object sender, EventArgs e)
        {          
            QLNhanVien form = new QLNhanVien();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
