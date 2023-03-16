namespace DoAnQuanLyThuVien.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuMuonSach")]
    public partial class PhieuMuonSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuMuonSach()
        {
            PhieuPhats = new HashSet<PhieuPhat>();
        }

        [Key]
        [StringLength(6)]
        public string MaPhieu { get; set; }

        [StringLength(6)]
        public string MaThe { get; set; }

        [StringLength(6)]
        public string MaNV { get; set; }

        [StringLength(6)]
        public string Masach { get; set; }

        public DateTime? Ngaymuon { get; set; }

        public DateTime? NgayTra { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TheDocGia TheDocGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuPhat> PhieuPhats { get; set; }
    }
}
