namespace QL_HocSinh_GiaoVien_THPT.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGiangday")]
    public partial class tblGiangday
    {
        [Required]
        [StringLength(10)]
        public string MaGV { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaLop { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Thu { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tietday { get; set; }

        public virtual tblGiaovien tblGiaovien { get; set; }

        public virtual tblLop tblLop { get; set; }
    }
}
