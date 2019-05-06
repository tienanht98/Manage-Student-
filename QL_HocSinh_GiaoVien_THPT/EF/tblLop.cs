namespace QL_HocSinh_GiaoVien_THPT.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLop")]
    public partial class tblLop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblLop()
        {
            tblHocSinh = new HashSet<tblHocSinh>();
        }

        [Key]
        public int MaLop { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        public int? GVCN { get; set; }

        public virtual tblGiaovien tblGiaovien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHocSinh> tblHocSinh { get; set; }
    }
}
