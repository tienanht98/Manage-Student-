using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_HocSinh_GiaoVien_THPT.EF;
namespace QL_HocSinh_GiaoVien_THPT.DAO
{
    class UserDAO
    {
        private QLHSContex db = null;

        public UserDAO()
        {
            db = new QLHSContex();
        }

        public tblUser login(string username, string pass)
        {
            return db.tblUser.SingleOrDefault(x => x.Username == username && x.Password == pass);
        }
    }
}
