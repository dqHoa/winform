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
    public partial class rpPhieuPhat : Form
    {
        QuanLyThuVien context;
        public rpPhieuPhat()
        {
            InitializeComponent();
            context = new QuanLyThuVien();
        }
        private void Fillcombobox(List<TheDocGia> listDG)
        {
            comboBox2.DataSource = listDG;
            comboBox2.DisplayMember = "TenDocGia";
            comboBox2.ValueMember = "MaThe";
        }
        private void rpPhieuPhat_Load(object sender, EventArgs e)
        {                        
            Fillcombobox(context.TheDocGias.ToList<TheDocGia>());            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PhieuPhat> list = context.PhieuPhats.ToList();
            List<rpPP> listReport = new List<rpPP>();
       
                foreach (PhieuPhat i in list)
                {
                    if (comboBox2.Text == i.TheDocGia.TenDocGia.ToString())
                    {
                        rpPP temp = new rpPP();
                        temp.MaPhieuPhat = i.MaPhieuPhat;
                        temp.MaPhieu = i.MaPhieu;
                        temp.TenNV = i.NhanVien.TenNV;
                        temp.TenDG = i.TheDocGia.TenDocGia;
                        temp.Masach = i.Masach;
                        temp.PhiPhat = i.PhiPhat;
                        temp.NoiDung = i.NoiDung;
                        temp.Ngay = i.Ngay;
                        listReport.Add(temp);
                    }
                }
                this.reportViewer1.LocalReport.ReportPath = "PhieuPhat.rdlc";
                var reportDataSource = new ReportDataSource("PhieuPhat", listReport);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            List<PhieuPhat> list = context.PhieuPhats.ToList();
            List<rpPP> listReport = new List<rpPP>();
            if (checkBox1.Checked == true)
            {

                foreach (PhieuPhat i in list)
                {
                    rpPP temp = new rpPP();
                    temp.MaPhieuPhat = i.MaPhieuPhat;
                    temp.MaPhieu = i.MaPhieu;
                    temp.TenNV = i.NhanVien.TenNV;
                    temp.TenDG = i.TheDocGia.TenDocGia;
                    temp.Masach = i.Masach;
                    temp.PhiPhat = i.PhiPhat;
                    temp.NoiDung = i.NoiDung;
                    temp.Ngay = i.Ngay;
                    listReport.Add(temp);
                }
                this.reportViewer1.LocalReport.ReportPath = "PhieuPhat.rdlc";
                var reportDataSource = new ReportDataSource("PhieuPhat", listReport);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                foreach (PhieuPhat i in list)
                {
                    if (comboBox2.Text == i.TheDocGia.TenDocGia.ToString())
                    {
                        rpPP temp = new rpPP();
                        temp.MaPhieuPhat = i.MaPhieuPhat;
                        temp.MaPhieu = i.MaPhieu;
                        temp.TenNV = i.NhanVien.TenNV;
                        temp.TenDG = i.TheDocGia.TenDocGia;
                        temp.Masach = i.Masach;
                        temp.PhiPhat = i.PhiPhat;
                        temp.NoiDung = i.NoiDung;
                        temp.Ngay = i.Ngay;
                        listReport.Add(temp);
                    }
                }
                this.reportViewer1.LocalReport.ReportPath = "PhieuPhat.rdlc";
                var reportDataSource = new ReportDataSource("PhieuPhat", listReport);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
