using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_HocSinh_GiaoVien_THPT.GUI
{
    public partial class ucThoiKhoaBieu : UserControl
    {
        public ucThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
               
               
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ucThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            try
            {
               
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
