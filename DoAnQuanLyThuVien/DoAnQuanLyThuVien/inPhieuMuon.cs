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
using Microsoft.Reporting.WinForms;

namespace DoAnQuanLyThuVien
{
    public partial class inPhieuMuon : Form
    {
        QuanLyThuVien context;
        public inPhieuMuon()
        {
            InitializeComponent();
            context = new QuanLyThuVien();
        }
        private void Fillcombobox(List<PhieuMuonSach> listDG)
        {
            comboBox1.DataSource = listDG;            
            comboBox1.ValueMember = "MaThe";
        }
        private void inPhieuMuon_Load(object sender, EventArgs e)
        {
            Fillcombobox(context.PhieuMuonSaches.ToList<PhieuMuonSach>());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PhieuMuonSach> list = context.PhieuMuonSaches.ToList();
            List<rpPhieuMuon> listReport = new List<rpPhieuMuon>();

            foreach (PhieuMuonSach i in list)
            {
                if (comboBox1.Text == i.MaThe.ToString())
                {
                    rpPhieuMuon temp = new rpPhieuMuon();                   
                    temp.MaPhieu = i.MaPhieu;
                    temp.TenNV = i.NhanVien.TenNV;
                    temp.TenDG = i.TheDocGia.TenDocGia;
                    temp.TenSach = i.Sach.Tensach;
                    temp.Ngaymuon = i.Ngaymuon;
                    temp.NgayTra = i.NgayTra;
                    listReport.Add(temp);
                }
            }
            this.reportViewer1.LocalReport.ReportPath = "inPhieuMuon.rdlc";
            var reportDataSource = new ReportDataSource("PhieuMuon", listReport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();

        }
    
    }
}
