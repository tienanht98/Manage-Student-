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
using System.Configuration;
using QL_HocSinh_GiaoVien_THPT.DAO;
using QL_HocSinh_GiaoVien_THPT.EF;
using QL_HocSinh_GiaoVien_THPT.Model;

namespace QL_HocSinh_GiaoVien_THPT.GUI
{

    public partial class ucGiaoVien : UserControl
    {
       
        int dong = -1;
       

        public ucGiaoVien()
        {
            InitializeComponent();
        }
        public void SetNull()
        {
            txtMaGV.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtLuong.Text = "";
            dtpNgaySinh.Value = new DateTime(1900, 1, 1);
        }

        public void Mo_txt()
        {
            //các txt mở lại để nhập
            txtMaGV.ReadOnly = false;
            txtTen.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtLuong.ReadOnly = false;
           
        }
        public void Khoa_btn()
        {
            //các txt khóa, ko cho nhập 
            txtMaGV.ReadOnly = true;
            txtTen.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtLuong.ReadOnly = true;
        }

        public void LoadGV()
        {

            SqlConnection conn = new SqlConnection(DTO.ConnectString.StringConnect);
            conn.Open();
            string sql = "Select giaovien.MaGV , giaovien.TenGV , giaovien.GT,giaovien.NgaySinh,giaovien.SDT,giaovien.DiaChi,giaovien.Luong , mon.TenMon from tblGiaovien giaovien join tblMonhoc mon on mon.MaMon = giaovien.MaMon";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvGiaoVien.DataSource = dt;
            conn.Close();


        }           

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ( txtTen.Text == "")
            {
                MessageBox.Show("Xin mời nhập đầy đủ thông tin");
                Khoa_btn();
                return;
            }
            else
            {
                //Them GV
                #region
                
                var giaovien = new tblGiaovien();
                giaovien.MaGV = Convert.ToInt16(txtMaGV.Text);
                if (rdbNam.Checked)
                {
                    giaovien.GT = "Nam";
                }
                else
                {
                    giaovien.GT = "Nữ";
                }

                giaovien.Luong = Convert.ToInt32(txtLuong.Text);
                giaovien.NgaySinh = dtpNgaySinh.Value;
                giaovien.SDT = txtSDT.Text;
                giaovien.TenGV = txtTen.Text;
                giaovien.DiaChi = txtDiaChi.Text;

                var monhoc = new MonHocDAO();
            
                giaovien.MaMon = (int)cboMamon.SelectedValue;

                var db = new GiaoVienDAO();
                QLHSContex context = new QLHSContex();
                context.Entry(giaovien).State = giaovien.MaGV == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
                

                        MessageBox.Show("Lưu thành công");
                        //
                        txtMaGV.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        LoadGV();
                        SetNull();
                  
                #endregion                
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn Thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
               
                Khoa_btn();/*không cho thao tác*/
                LoadGV();
            }
        }
        private void show_cboMonhoc()
        {

            SqlConnection conn = new SqlConnection(DTO.ConnectString.StringConnect);
            conn.Open();
            string strSQL = "select * from tblMonhoc";
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDa = new SqlDataAdapter(strSQL, conn);
            sqlDa.Fill(dt);
            cboMamon.DataSource = dt;
            cboMamon.DisplayMember = "TenMon";
            cboMamon.ValueMember = "MaMon";
            conn.Close();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            //Mở nút lưu 
            txtMaGV.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            SetNull();
            Mo_txt();
            txtTen.Focus();
            txtLuong.Text = "1000000";
            //hienthi ds Ma Mon
            show_cboMonhoc();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
           
            if (dong < 0)
            {
                MessageBox.Show("Chưa chọn giáo viên để sửa!");
                return;
            }
            Mo_txt();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            //hienthi ds Ma Mon
            show_cboMonhoc();            
        }

        // Tìm Kiếm
        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Tìm kiếm theo mã
                if (rdTKMa.Checked == true)
                {
                    
                }
                // Tìm kiếm theo tên
                else if (rdTKTen.Checked == true)
                {
                }
                else
                {
                    MessageBox.Show(" Mời bạn chọn lại!!!!");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void tlsRefresh_Click(object sender, EventArgs e)
        {
            LoadGV();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QLHSContex db = new QLHSContex();
                tblGiaovien tblGiaovien = new tblGiaovien();
                tblGiaovien.MaGV = Convert.ToInt16( txtMaGV.Text);
                db.Entry(tblGiaovien).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                MessageBox.Show("Xóa thành công!");
                LoadGV();
                
            }
        }
        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtMaGV.Text = dgvGiaoVien.Rows[dong].Cells[0].Value.ToString();
            txtTen.Text = dgvGiaoVien.Rows[dong].Cells[1].Value.ToString();
            if (dgvGiaoVien.Rows[e.RowIndex].Cells["GT"].Value.ToString() == "Nam") rdbNam.Checked = true;
            else rdbNu.Checked = true;
            dtpNgaySinh.Text = dgvGiaoVien.Rows[dong].Cells[3].Value.ToString();
            txtSDT.Text = dgvGiaoVien.Rows[dong].Cells[4].Value.ToString();
            txtDiaChi.Text = dgvGiaoVien.Rows[dong].Cells[5].Value.ToString();
            txtLuong.Text = dgvGiaoVien.Rows[dong].Cells[6].Value.ToString();

            SqlConnection conn = new SqlConnection(DTO.ConnectString.StringConnect);
            conn.Open();
            string strSQL = "select * from tblMonhoc where TenMon = '" + dgvGiaoVien.Rows[dong].Cells[7].Value.ToString() + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDa = new SqlDataAdapter(strSQL, conn);
            sqlDa.Fill(dt);
            
            string strSQLmonhoc = "select * from tblMonhoc";
            DataTable dtmonhoc = new DataTable();
            SqlDataAdapter monhoc = new SqlDataAdapter(strSQLmonhoc, conn);
            monhoc.Fill(dtmonhoc);
            
            cboMamon.DataSource = dtmonhoc;
            
            cboMamon.DisplayMember = "TenMon";
            cboMamon.ValueMember = "MaMon";
           
            for (int i = 0; i < cboMamon.Items.Count; i++)
            {
                if (dgvGiaoVien.Rows[dong].Cells[7].Value.ToString() == cboMamon.GetItemText(cboMamon.Items[i]))
                {
                    cboMamon.SelectedIndex = i;
                }
            }

            conn.Close();
    
            Khoa_btn();

        } 
        private void ucGiaoVien_Load(object sender, EventArgs e)
        {
            Khoa_btn();
            LoadGV();
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdTKMa.Checked == true)
            {
               
            }
            else if (rdTKTen.Checked == true)
            {
                
            }
            else
            {
                //MessageBox.Show(" Mời bạn chọn lại!!!!");
                return;
            }

        }
    }
}
