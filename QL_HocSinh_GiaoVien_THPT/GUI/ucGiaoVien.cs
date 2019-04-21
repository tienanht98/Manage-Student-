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

namespace QL_HocSinh_GiaoVien_THPT.GUI
{

    public partial class ucGiaoVien : UserControl
    {
        bool themmoi = false;
        int dong = -1;
        DataTable dtMon = new DataTable();

        public ucGiaoVien()
        {
            InitializeComponent();
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
           
            
           
        }           

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text == "" || txtTen.Text == "")
            {
                MessageBox.Show("Xin mời nhập đầy đủ thông tin");
                Khoa_btn();
                return;
            }
            else
            {
                //Them GV
                #region
                if (themmoi == true)
                {
                    try
                    {

                        MessageBox.Show("Thêm mới thành công");
                        //
                        txtMaGV.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                #endregion

                //Sua GV
                #region
                else
                {
                    try
                    {
                       
                        MessageBox.Show("Thay đổi thông tin giáo viên thành công");
                        btnThem.Enabled = true;
                        btnLuu.Enabled = false;
                        btnXoa.Enabled = true;
                       
                        Khoa_btn();/*không cho thao tác*/
                        LoadGV();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
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
           
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            //Mở nút lưu 
            txtMaGV.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtMaGV.Focus();
            Mo_txt();
           
            txtLuong.Text = "1000000";
            //hienthi ds Ma Mon
            show_cboMonhoc();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            themmoi = false;
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
               
                MessageBox.Show("Xóa thành công!");
                LoadGV();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Lỗi" + ex.Message);
                //}
            }
        }
        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
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
