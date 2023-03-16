using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnQuanLyThuVien.DataContext;
namespace DoAnQuanLyThuVien.DataTier
{
    class TaiKhoanDT
    {
        public NhanVien LayTaiKhoan(string tenTaiKhoan,string matKhau)
        {
            using( var dbcontext = new QuanLyThuVien())
            {
                return dbcontext.NhanViens.Where(s => s.MaNV == tenTaiKhoan && s.MatKhau == matKhau).FirstOrDefault();
            }
        }

        internal bool LuuTaiKhoan(NhanVien tk, out string error)
        {
            error = string.Empty;
            try
            {
                
                using (var dbcontext = new QuanLyThuVien())
                {
                    NhanVien nv = dbcontext.NhanViens.Where(s => s.MaNV == tk.MaNV).FirstOrDefault<NhanVien>();
                    nv.MatKhau = tk.MatKhau;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
