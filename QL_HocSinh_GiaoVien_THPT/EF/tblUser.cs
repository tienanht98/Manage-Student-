namespace QL_HocSinh_GiaoVien_THPT.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class tblUser
    {
        [Key]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(10)]
        public string MaGV { get; set; }

        public int Quyen { get; set; }

        public virtual tblPhanquyen tblPhanquyen { get; set; }
    }
}
