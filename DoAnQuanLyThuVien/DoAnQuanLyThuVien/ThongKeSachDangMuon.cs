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
    public partial class ThongKeSachDangMuon : Form
    {
        private int total = 0;
        QuanLyThuVien context;
        public ThongKeSachDangMuon()
        {
            InitializeComponent();
            context = new QuanLyThuVien();
        }

        private void ThongKeSachDangMuon_Load(object sender, EventArgs e)
        {

            List<PhieuMuonSach> list = context.PhieuMuonSaches.ToList();
            List<rpSachDangMuon> listReport = new List<rpSachDangMuon>();
            foreach (PhieuMuonSach i in list)
            {
                rpSachDangMuon temp = new rpSachDangMuon();
                temp.MaPhieu = i.MaPhieu;
                temp.TenSach = i.Sach.Tensach;
                temp.TenDocGia= i.TheDocGia.TenDocGia;
                temp.SDT = i.TheDocGia.SDT;                              
                temp.Ngaymuon = i.Ngaymuon.Value.ToString("dd/MM/yyyy");
                temp.NgayTra = i.NgayTra.Value.ToString("dd/MM/yyyy");
                listReport.Add(temp);
            }
            total = listReport.Count;
            this.reportViewer1.LocalReport.ReportPath = "rpDangMuon.rdlc";
            var reportDataSource = new ReportDataSource("DangMuon", listReport);
            ReportParameter rpt1 = new ReportParameter("total", total.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rpt1 });
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();            
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            List<PhieuMuonSach> list = context.PhieuMuonSaches.ToList();
            List<rpSachDangMuon> listReport = new List<rpSachDangMuon>();
            if (checkBox1.Checked == true)
            {
                
                foreach (PhieuMuonSach i in list)
                {
                    if (i.NgayTra < DateTime.Now)
                    {
                        rpSachDangMuon temp = new rpSachDangMuon();
                        temp.MaPhieu = i.MaPhieu;
                        temp.TenSach = i.Sach.Tensach;
                        temp.TenDocGia = i.TheDocGia.TenDocGia;
                        temp.SDT = i.TheDocGia.SDT;
                        temp.Ngaymuon = i.Ngaymuon.Value.ToString("dd/MM/yyyy");
                        temp.NgayTra = i.NgayTra.Value.ToString("dd/MM/yyyy");
                        listReport.Add(temp);
                    }
                }
                total = listReport.Count;
            }
            else
            {
                foreach (PhieuMuonSach i in list)
                {
                    rpSachDangMuon temp = new rpSachDangMuon();
                    temp.MaPhieu = i.MaPhieu;
                    temp.TenSach = i.Sach.Tensach;
                    temp.TenDocGia = i.TheDocGia.TenDocGia;
                    temp.SDT = i.TheDocGia.SDT;
                    temp.Ngaymuon = i.Ngaymuon.Value.ToString("dd/MM/yyyy");
                    temp.NgayTra = i.NgayTra.Value.ToString("dd/MM/yyyy");
                    listReport.Add(temp);
                }
                total = listReport.Count;
            }
            this.reportViewer1.LocalReport.ReportPath = "rpDangMuon.rdlc";
            var reportDataSource = new ReportDataSource("DangMuon", listReport);
            ReportParameter rpt1 = new ReportParameter("total", total.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rpt1 });
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }   
}
