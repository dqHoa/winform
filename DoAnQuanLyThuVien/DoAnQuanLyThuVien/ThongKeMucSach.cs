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
    public partial class ThongKeMucSach : Form
    {
        private int total = 0;
        QuanLyThuVien context;
        public ThongKeMucSach()
        {
            InitializeComponent();
            context = new QuanLyThuVien();
        }

        private void ThongKeMucSach_Load(object sender, EventArgs e)
        {
            List<Sach> list = context.Saches.ToList();
            List<rpMucSach> listReport = new List<rpMucSach>();
            foreach (Sach i in list)
            {
                rpMucSach temp = new rpMucSach();              
                    temp.Masach = i.Masach;
                    temp.Tensach = i.Tensach;
                    temp.Tacgia = i.Tacgia;
                    temp.TenNXB = i.TenNXB;
                    temp.Chude = i.Chude.TenCD;
                    temp.Ngaynhap = (DateTime)i.Ngaynhap;
                    listReport.Add(temp);                
            }
            total = listReport.Count;
            this.reportViewer1.LocalReport.ReportPath = "ThongKeMucSach.rdlc";
            var reportDataSource = new ReportDataSource("MucSach", listReport);
            ReportParameter rpt1 = new ReportParameter("total", total.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rpt1 });
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);            
            this.reportViewer1.RefreshReport();
        }
    }
}
