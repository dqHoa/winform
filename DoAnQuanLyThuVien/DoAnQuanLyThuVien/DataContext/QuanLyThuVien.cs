using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAnQuanLyThuVien.DataContext
{
    public partial class QuanLyThuVien : DbContext
    {
        public QuanLyThuVien()
            : base("name=QuanLyThuVien")
        {
        }

        public virtual DbSet<Chude> Chudes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuMuonSach> PhieuMuonSaches { get; set; }
        public virtual DbSet<PhieuPhat> PhieuPhats { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TheDocGia> TheDocGias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chude>()
                .Property(e => e.MaCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuonSach>()
                .Property(e => e.MaPhieu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuonSach>()
                .Property(e => e.MaThe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuonSach>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuonSach>()
                .Property(e => e.Masach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuPhat>()
                .Property(e => e.MaPhieuPhat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuPhat>()
                .Property(e => e.MaPhieu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuPhat>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuPhat>()
                .Property(e => e.MaThe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuPhat>()
                .Property(e => e.Masach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuPhat>()
                .Property(e => e.PhiPhat)
                .HasPrecision(9, 3);

            modelBuilder.Entity<Sach>()
                .Property(e => e.Masach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaCD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TheDocGia>()
                .Property(e => e.MaThe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TheDocGia>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
