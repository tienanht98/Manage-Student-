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
    public partial class ucTaiKhoan : UserControl
    {
        public ucTaiKhoan()
        {
            InitializeComponent();
        }
        private void ketnoi()
        {
            try
            {
                
            }
            catch
            {
                MessageBox.Show("Loi Ket Noi Vui Long Kiem Tra Lai !");

            }
            finally
            {
               
            }
        }
  
        private void ucTaiKhoan_Load(object sender, EventArgs e)
        {
            ketnoi();
        }

        int index;
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            txtUsername.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtMaGV.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            txtQuyen.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
                MessageBox.Show("Lỗi, không thêm được!");
            }
            finally
            {
                
            }

        }
        string xoa;
        private void ucXoa_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch
            {
                MessageBox.Show("Lỗi, không xóa được!");
            }
            finally
            {
            }

        }
        string sua;
        private void ucSua_Click(object sender, EventArgs e)
        {

            try
            {
            }
            catch
            {
                MessageBox.Show("Lỗi, không sửa được!");
            }
            finally
            {
               
            }

        }
        string sqlTimKiem;
        private void ucTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch
            {
                MessageBox.Show(" không tìm thấy!");
            }
            finally
            {
               
            }
        }
        private void ucRefresh_Click(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
        

       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ucTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
        

       

        

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        
        

        

        
    }
}
