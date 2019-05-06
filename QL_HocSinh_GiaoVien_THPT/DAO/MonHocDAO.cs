using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_HocSinh_GiaoVien_THPT.EF;
namespace QL_HocSinh_GiaoVien_THPT.DAO
{
    class MonHocDAO
    {
        QLHSContex db = null;
        public MonHocDAO()
        {
            db = new QLHSContex();
        }
        public tblMonhoc getByName(string name)
        {
            return db.tblMonhoc.SingleOrDefault(x => x.TenMon == name);
        }
        public  List<tblMonhoc> getALL()
        { 
            return db.tblMonhoc.OrderBy(x => x.MaMon).ToList();
        }
    }
}
