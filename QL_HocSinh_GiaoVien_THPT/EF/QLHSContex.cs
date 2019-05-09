namespace QL_HocSinh_GiaoVien_THPT.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLHSContex : DbContext
    {
        public QLHSContex()
            : base("name=QLHSContex")
        {
        }

        public virtual DbSet<tblGiangday> tblGiangday { get; set; }
        public virtual DbSet<tblGiaovien> tblGiaovien { get; set; }
        public virtual DbSet<tblHocSinh> tblHocSinh { get; set; }
        public virtual DbSet<tblLop> tblLop { get; set; }
        public virtual DbSet<tblMonhoc> tblMonhoc { get; set; }
        public virtual DbSet<tblPhanquyen> tblPhanquyen { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblGiaovien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<tblGiaovien>()
                .HasMany(e => e.tblLop)
                .WithOptional(e => e.tblGiaovien)
                .HasForeignKey(e => e.GVCN);

            modelBuilder.Entity<tblLop>()
                .HasMany(e => e.tblHocSinh)
                .WithRequired(e => e.tblLop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPhanquyen>()
                .HasMany(e => e.tblUser)
                .WithRequired(e => e.tblPhanquyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.MaGV)
                .IsUnicode(false);
        }
    }
}
