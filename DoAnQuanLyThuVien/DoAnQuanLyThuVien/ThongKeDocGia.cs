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
    public partial class ThongKeDocGia : Form
    {
        private int total = 0;
        QuanLyThuVien context;
        public ThongKeDocGia()
        {
            InitializeComponent();
            context = new QuanLyThuVien();
        }

        private void ThongKeDocGia_Load(object sender, EventArgs e)
        {
            List<TheDocGia> list = context.TheDocGias.ToList();
            List<rpDG> listReport = new List<rpDG>();
            foreach (TheDocGia i in list)
            {
                rpDG temp = new rpDG();
                temp.MaThe = i.MaThe;
                temp.TenDocGia = i.TenDocGia;
                temp.GioiTinh = i.GioiTinh;
                temp.NgaySinh = i.NgaySinh.Value.ToString("dd/MM/yyyy");                
                temp.SDT = i.SDT;
                temp.Diachi = i.Diachi;
                temp.NgayCapThe = i.NgayCapThe.Value.ToString("dd/MM/yyyy");
                temp.NgayHetHan = i.NgayHetHan.Value.ToString("dd/MM/yyyy");
                listReport.Add(temp);
            }
            total = listReport.Count;
            this.reportViewer1.LocalReport.ReportPath = "rpDG.rdlc";
            var reportDataSource = new ReportDataSource("DocGia", listReport);
            ReportParameter rpt1 = new ReportParameter("total", total.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rpt1 });
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
