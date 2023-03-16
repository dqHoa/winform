using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnQuanLyThuVien.DataContext;
using DoAnQuanLyThuVien.DataTier;
using DoAnQuanLyThuVien.Libs;

namespace DoAnQuanLyThuVien.BusinessTier
{
    class TaiKhoanBT
    {
        private readonly TaiKhoanDT taikhoanDT;
        public TaiKhoanBT()
        {
            taikhoanDT = new TaiKhoanDT();
        }
        public NhanVien LayTaiKhoan(string tenDangNhap,string matKhau)
        {
            matKhau = Helpers.MaHoaMD5(matKhau);
            return taikhoanDT.LayTaiKhoan(tenDangNhap, matKhau);
            
        }

        internal bool LuuTaiKhoan(NhanVien tk, out string error)
        {
            try
            {
                tk.MatKhau = Helpers.MaHoaMD5(tk.MatKhau);
                return taikhoanDT.LuuTaiKhoan(tk, out error);
            }
            catch(Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
