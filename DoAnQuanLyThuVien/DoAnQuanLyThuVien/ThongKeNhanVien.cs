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
    public partial class ThongKeNhanVien : Form
    {
        private int total = 0;
        QuanLyThuVien context;
        public ThongKeNhanVien()
        {
            InitializeComponent();
            context = new QuanLyThuVien();
        }

        private void ThongKeNhanVien_Load(object sender, EventArgs e)
        {
            List<NhanVien> list = context.NhanViens.ToList();
            List<rpNhanVien> listReport = new List<rpNhanVien>();
            foreach (NhanVien i in list)
            {
                rpNhanVien temp = new rpNhanVien();
                temp.MaNV = i.MaNV;
                temp.TenNV = i.TenNV;
                temp.GioiTinh = i.GioiTinh;
                temp.NgaySinh = i.NgaySinh.Value.ToString("dd/MM/yyyy");
                temp.NgayVaoLam = i.NgayVaoLam.Value.ToString("dd/MM/yyyy");
                temp.SDT = i.SDT;
                temp.Diachi = i.Diachi;
                listReport.Add(temp);
            }
            total = listReport.Count;
            this.reportViewer1.LocalReport.ReportPath = "rpNV.rdlc";
            var reportDataSource = new ReportDataSource("NhanVien", listReport);
            ReportParameter rpt1 = new ReportParameter("total", total.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rpt1 });
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();                       
        }
    }
}
