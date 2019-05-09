namespace QL_HocSinh_GiaoVien_THPT.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHocSinh")]
    public partial class tblHocSinh
    {
        [Key]
        public int MaHS { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHS { get; set; }

        [StringLength(3)]
        public string GT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string DanToc { get; set; }

        [StringLength(50)]
        public string TonGiao { get; set; }

        public int MaLop { get; set; }

        public virtual tblLop tblLop { get; set; }
    }
}
