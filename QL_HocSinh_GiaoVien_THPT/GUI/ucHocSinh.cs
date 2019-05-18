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
using QL_HocSinh_GiaoVien_THPT.EF;
using QL_HocSinh_GiaoVien_THPT.DAO;
namespace QL_HocSinh_GiaoVien_THPT.GUI
{
    public partial class ucHocSinh : UserControl
    {
        public ucHocSinh()
        {
            InitializeComponent();
        }




        public void LockControl()
        {
            txtMaHS.Enabled = false;
            txtTenHS.Enabled = false;
            cbmLop.Enabled = false;
            txtDT.Enabled = false;
            txtDC.Enabled = false;
            cboTG.Enabled = false;

        }
        public void UnLockControl()
        {
            txtMaHS.Enabled = true;
            cbmLop.Enabled = true;
            txtDT.Enabled = true;
            txtTenHS.Enabled = true;
            txtDC.Enabled = true;
            cboTG.Enabled = true;
        }
        public void Setnull()
        {
            txtMaHS.Text = "";

            txtTenHS.Text = "";
            txtDC.Text = "";
            dtpNgaySinh.Value = new DateTime(1900, 1, 1);
        }

        private void ucHocSinh_Load(object sender, EventArgs e)
        {

            loadHS();

        }

        private void loadHS()
        {

            SqlConnection conn = new SqlConnection(DTO.ConnectString.StringConnect);
            conn.Open();
            string sql = "select hs.MaHS , hs.TenHS, hs.GT , hs.NgaySinh,hs.DiaChi, hs.DanToc,hs.TonGiao,lop.TenLop from tblHocSinh hs join tblLop lop on hs.MaLop = lop.MaLop ";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            dgvHS.DataSource = dt;
            show_cbm_lop();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            txtMaHS.Enabled = true;
            btnLuu.Enabled = true;
            btnThayDoi.Enabled = false;
            btnXoa.Enabled = false;



            txtTenHS.Focus();
            UnLockControl();
            Setnull();
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            UnLockControl();
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnThayDoi.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHS.Text == "" || txtTenHS.Text == "" || txtDT.Text == "" || txtDC.Text == "")
            {
                MessageBox.Show("Xin mời nhập đầy đủ thông tin");
                LockControl();
                return;
            }
            else
            {

                tblHocSinh tblHocSinh = new tblHocSinh();
               
                tblHocSinh.TenHS = txtTenHS.Text;
                if (rdbNam.Checked)
                {
                    tblHocSinh.GT = "Nam";
                }
                else
                {
                    tblHocSinh.GT = "Nữ";
                }
                tblHocSinh.NgaySinh = dtpNgaySinh.Value;
                tblHocSinh.DiaChi = txtDC.Text;
                tblHocSinh.DanToc = txtDT.Text;
                tblHocSinh.MaLop = (int)cbmLop.SelectedValue;
                tblHocSinh.TonGiao = cboTG.SelectedItem.ToString();
                QLHSContex db = new QLHSContex();
                db.Entry(tblHocSinh).State = (tblHocSinh.MaHS == 0) ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
                MessageBox.Show("Lưu thành công");

                db.SaveChanges();
                loadHS();
            }
        }

        private void dgvHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaHS.Text = dgvHS.CurrentRow.Cells["MaHS"].Value.ToString();
                txtTenHS.Text = dgvHS.CurrentRow.Cells["TenHS"].Value.ToString();
                txtTenHS.Text = Convert.ToString(dgvHS.CurrentRow.Cells["TenHS"].Value);
                if (dgvHS.Rows[e.RowIndex].Cells["GT"].Value.ToString() == "Nam") rdbNam.Checked = true;
                else rdbNu.Checked = true;
                dtpNgaySinh.Text = dgvHS.CurrentRow.Cells["NgaySinh"].Value.ToString();
                // txtMaLp.Text = dgvHS.CurrentRow.Cells["MaLop"].Value.ToString();
                txtDT.Text = dgvHS.CurrentRow.Cells["DanToc"].Value.ToString();
                //Show_CboTG(dgvHS.CurrentRow.Cells["TonGiao"].Value.ToString());
                cboTG.Text = dgvHS.CurrentRow.Cells["TonGiao"].Value.ToString();
                txtDC.Text = dgvHS.CurrentRow.Cells["DiaChi"].Value.ToString();
                cboTG.DataBindings.Clear();
                cboTG.DataBindings.Add("Text", dgvHS.DataSource, "TonGiao");

                SqlConnection conn = new SqlConnection(DTO.ConnectString.StringConnect);
                conn.Open();
                string strSQL = "select * from tblLop where TenLop = '" + dgvHS.CurrentRow.Cells["TenLop"].Value.ToString() + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDa = new SqlDataAdapter(strSQL, conn);
                sqlDa.Fill(dt);
                cbmLop.DataSource = dt;
                cbmLop.ValueMember = "MaLop";
                cbmLop.DisplayMember = "TenLop";
                conn.Close();
                for (int i = 0; i < cbmLop.Items.Count; i++)
                {
                    if (dgvHS.CurrentRow.Cells["TenLop"].Value.ToString() == cbmLop.GetItemText(cbmLop.Items[i]))
                    {
                        cbmLop.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QLHSContex db = new QLHSContex();
                tblHocSinh tblHocSinh = new tblHocSinh();
                tblHocSinh.MaHS = Convert.ToInt16(txtMaHS.Text);
                db.Entry(tblHocSinh).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                MessageBox.Show("Xóa thành công!");
                loadHS();

            }
        }

        private void show_cbm_lop()
        {

            SqlConnection conn = new SqlConnection(DTO.ConnectString.StringConnect);
            conn.Open();
            string strSQL = "select * from tblLop";
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDa = new SqlDataAdapter(strSQL, conn);
            sqlDa.Fill(dt);
            cbmLop.DataSource = dt;
            cbmLop.DisplayMember = "TenLop";
            cbmLop.ValueMember = "MaLop";
            conn.Close();
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboTimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTimKiem_Click(null, null);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //if (cboTimkiem.SelectedIndex == 0)
            //{
            //    giaoVienDAO.searchModelBasic(rdTKMa.Text, txtTimKiem.Text, dgvGiaoVien);
            //}
            //else if (cboTimkiem.SelectedIndex == 1)
            //{
            //    giaoVienDAO.searchModelBasic(rdTKTen.Text, txtTimKiem.Text, dgvGiaoVien);
            //}
            //else
            //{
            //    //MessageBox.Show(" Mời bạn chọn lại!!!!");
            //    return;
            //}
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

            LockControl();
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnThayDoi.Enabled = true;
        }


    }
}