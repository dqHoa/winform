namespace DoAnQuanLyThuVien.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            PhieuMuonSaches = new HashSet<PhieuMuonSach>();
            PhieuPhats = new HashSet<PhieuPhat>();
        }

        [Key]
        [StringLength(6)]
        public string Masach { get; set; }

        [StringLength(30)]
        public string Tensach { get; set; }

        [StringLength(20)]
        public string Tacgia { get; set; }

        public DateTime? Ngaynhap { get; set; }

        [StringLength(2)]
        public string MaCD { get; set; }

        [StringLength(50)]
        public string TenNXB { get; set; }

        public virtual Chude Chude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuonSach> PhieuMuonSaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuPhat> PhieuPhats { get; set; }
    }
}
