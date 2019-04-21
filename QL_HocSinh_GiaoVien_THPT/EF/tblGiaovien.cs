namespace QL_HocSinh_GiaoVien_THPT.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGiaovien")]
    public partial class tblGiaovien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblGiaovien()
        {
            tblGiangday = new HashSet<tblGiangday>();
            tblLop = new HashSet<tblLop>();
        }

        [Key]
        [StringLength(10)]
        public string MaGV { get; set; }

        [StringLength(50)]
        public string TenGV { get; set; }

        [StringLength(3)]
        public string GT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        public int? Luong { get; set; }

        [Required]
        [StringLength(10)]
        public string MaMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGiangday> tblGiangday { get; set; }

        public virtual tblMonhoc tblMonhoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblLop> tblLop { get; set; }
    }
}
