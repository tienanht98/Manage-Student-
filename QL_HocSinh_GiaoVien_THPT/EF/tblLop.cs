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
            tblGiangday = new HashSet<tblGiangday>();
            tblHocSinh = new HashSet<tblHocSinh>();
        }

        [Key]
        [StringLength(10)]
        public string MaLop { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        [StringLength(10)]
        public string GVCN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGiangday> tblGiangday { get; set; }

        public virtual tblGiaovien tblGiaovien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHocSinh> tblHocSinh { get; set; }
    }
}
