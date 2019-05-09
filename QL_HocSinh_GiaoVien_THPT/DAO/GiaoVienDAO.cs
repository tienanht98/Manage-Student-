using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_HocSinh_GiaoVien_THPT.EF;
using System.Windows.Forms;

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

        public void searchModelBasic(string luaChon, string tuKhoa, DataGridView data)
        {
            // Truy vấn -> đổ dữ liệu vào DataGridView
            //string sql = "select MASACH,TENSACH,TACGIA,NHAXUATBAN,MALV,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU from tblSach where " + luaChon + " like N'%" + tuKhoa + "%'";
            //connectSer.LoadDataDataGridView(data, sql);

        }
    }
}
