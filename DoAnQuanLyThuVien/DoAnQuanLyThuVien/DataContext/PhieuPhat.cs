namespace DoAnQuanLyThuVien.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuPhat")]
    public partial class PhieuPhat
    {
        [Key]
        [StringLength(6)]
        public string MaPhieuPhat { get; set; }

        [StringLength(6)]
        public string MaPhieu { get; set; }

        [StringLength(6)]
        public string MaNV { get; set; }

        [StringLength(6)]
        public string MaThe { get; set; }

        [StringLength(6)]
        public string Masach { get; set; }

        public decimal? PhiPhat { get; set; }

        [StringLength(100)]
        public string NoiDung { get; set; }

        public DateTime? Ngay { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuMuonSach PhieuMuonSach { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TheDocGia TheDocGia { get; set; }
    }
}
