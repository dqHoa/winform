namespace DoAnQuanLyThuVien.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheDocGia")]
    public partial class TheDocGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheDocGia()
        {
            PhieuMuonSaches = new HashSet<PhieuMuonSach>();
            PhieuPhats = new HashSet<PhieuPhat>();
        }

        [Key]
        [StringLength(6)]
        public string MaThe { get; set; }

        [StringLength(50)]
        public string TenDocGia { get; set; }

        public DateTime? NgaySinh { get; set; }

        public DateTime? NgayCapThe { get; set; }

        public DateTime? NgayHetHan { get; set; }

        [StringLength(4)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuonSach> PhieuMuonSaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuPhat> PhieuPhats { get; set; }
    }
}
