using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_HocSinh_GiaoVien_THPT.EF;
namespace QL_HocSinh_GiaoVien_THPT.DAO
{
    class GiaoVienDAO
    {
        QLHSContex db = null;
        public GiaoVienDAO()
        {
            db = new QLHSContex();
        }
        public bool Insert(tblGiaovien tblGiaovien)
        {
            db.tblGiaovien.Add(tblGiaovien);
            db.SaveChanges();
            return true;

        }
    }
}
