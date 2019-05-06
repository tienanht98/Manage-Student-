using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_HocSinh_GiaoVien_THPT.DTO
{
    class Connect
    {
        public static SqlConnection myconnect = new SqlConnection(DTO.ConnectString.StringConnect);

        public static void openConnect()
        {
            myconnect.Open();
        }

        public static void closeConnect()
        {
            myconnect.Close();
        }
    }
}
