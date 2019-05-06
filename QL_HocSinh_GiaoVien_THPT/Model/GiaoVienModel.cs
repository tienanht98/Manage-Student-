using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_HocSinh_GiaoVien_THPT.EF;
namespace QL_HocSinh_GiaoVien_THPT.Model
{
    class GiaoVienModel
    {
       
        public int MaGV { get; set; }

        
        public string TenGV { get; set; }

        
        public string GT { get; set; }

       
        public DateTime? NgaySinh { get; set; }

      
        public string SDT { get; set; }
        
        public string DiaChi { get; set; }

        public int? Luong { get; set; }

        public string MonHoc { get; set; }
        public GiaoVienModel(tblGiaovien tblGiaovien)
        {
            this.MaGV = tblGiaovien.MaGV;
            this.TenGV = tblGiaovien.TenGV;
            this.GT = tblGiaovien.GT;
            this.NgaySinh = tblGiaovien.NgaySinh;
            this.SDT = tblGiaovien.SDT;
            this.DiaChi = tblGiaovien.DiaChi;
            this.Luong = Luong;
            this.MonHoc = tblGiaovien.tblMonhoc.TenMon;
        }
    }
}
