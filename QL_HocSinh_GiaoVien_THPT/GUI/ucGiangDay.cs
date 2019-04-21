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
using System.Data;

namespace QL_HocSinh_GiaoVien_THPT.GUI
{
    public partial class ucGiangDay : UserControl
    {
        public ucGiangDay()
        {
            InitializeComponent();
        }

        private DataTable dtGiaoVien = new DataTable();
        private DataTable dtLop = new DataTable();
        private DataTable dtDuLieu = new DataTable();
        private DataTable dtThu = new DataTable();
        //
        DataView dvDuLieu = new DataView();
        DataView dvGiaoVien = new DataView();
        DataView dvLop = new DataView();
        DataView dvThu = new DataView();
        DataView dvXGiaoVien = new DataView();
        DataView dvXLop = new DataView();
        DataView dvXThu = new DataView();

        private void loadData()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy dữ liệu từ Server.\nVui lòng kiểm tra lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void displayData()
        {
            try
            {

                dvDuLieu = new DataView(dtDuLieu);
                dvGiaoVien = new DataView(dtGiaoVien);
                dvLop = new DataView(dtLop);
                dvXGiaoVien = new DataView(dtGiaoVien);
                dvXLop = new DataView(dtLop);
                dvThu = new DataView(dtThu);
                dvXThu = new DataView(dtThu);
                // blind datasource
                //dgvData.DataSource = new DataView(); ;
                //this.dgvData.ClearSelection();
                dgvData.DataSource = dvDuLieu;


                cboGiaoVien.DataSource = dvGiaoVien;
                cboGiaoVien.DisplayMember = "TenGV";
                cboGiaoVien.ValueMember = "MaGV";

                cboLop.DataSource = dvLop;
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";

                cboXemGiaoVien.DataSource = dvXGiaoVien;
                cboXemGiaoVien.DisplayMember = "TenGV";
                cboXemGiaoVien.ValueMember = "MaGV";

                cboXemLop.DataSource = dvXLop;
                cboXemLop.DisplayMember = "TenLop";
                cboXemLop.ValueMember = "MaLop";

                cboThu.DataSource = dvThu;
                cboThu.DisplayMember = "Ten";
                cboThu.ValueMember = "ID";

                cboXemTheoThu.DataSource = dvXThu;
                cboXemTheoThu.DisplayMember = "Ten";
                cboXemTheoThu.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Don't display data.\nERROR:" + ex.Message);
            }



        }
        private void bindingData()
        {
            this.cboGiaoVien.DataBindings.Clear();
            this.cboGiaoVien.DataBindings.Add("SelectedValue", dgvData.DataSource, "MaGV", true, DataSourceUpdateMode.Never);
            this.cboGiaoVien.DataBindings.Add("Text", dgvData.DataSource, "TenGV", true, DataSourceUpdateMode.Never);
            this.cboLop.DataBindings.Add("SelectedValue", dgvData.DataSource, "MaLop", true, DataSourceUpdateMode.Never);
            this.cboLop.DataBindings.Add("Text", dgvData.DataSource, "TenLop", true, DataSourceUpdateMode.Never);

            this.cboThu.DataBindings.Add("SelectedValue", dgvData.DataSource, "idthu", true, DataSourceUpdateMode.Never);
            this.cboThu.DataBindings.Add("Text", dgvData.DataSource, "Thu", true, DataSourceUpdateMode.Never);

            this.txtTiet.DataBindings.Add("Text", dgvData.DataSource, "Tiet", true, DataSourceUpdateMode.Never);

        }

        private void ucGiangDay_Load(object sender, EventArgs e)
        {
            loadData();
            displayData();
            bindingData();
        }

        private void cboXemLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dvDuLieu.RowFilter = string.Empty;
                dvDuLieu.RowFilter = "MaLop=" + cboXemLop.SelectedValue;

            }
            catch (Exception ex)
            {

            }
        }

        private void cboXemGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dvDuLieu.RowFilter = string.Empty;
                dvDuLieu.RowFilter = "MaGV=" + cboXemGiaoVien.SelectedValue;

            }
            catch (Exception ex)
            {

            }
        }

        private void cboXemTheoThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dvDuLieu.RowFilter = string.Empty;
                dvDuLieu.RowFilter = "idthu=" + cboXemTheoThu.SelectedValue;

            }
            catch (Exception ex)
            {

            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            dvDuLieu.RowFilter = string.Empty;
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int index = dgvData.CurrentRow.Index;
                int count = dgvData.Rows.Count;

                //MessageBox.Show(index.ToString() + " " + count.ToString());
                if (index == count - 1)
                {
                    this.btnAdd.Enabled = true;
                    this.btnUpdate.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
                else
                {
                    this.btnAdd.Enabled = false;
                    this.btnUpdate.Enabled = true;
                    this.btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string str = "INSERT INTO dbo.tblGiangDay (MaGV, MaLop, Thu, Tiet) VALUES('" + cboGiaoVien.SelectedValue.ToString().Trim() + "','" + cboLop.SelectedValue.ToString() + "'," + cboThu.SelectedValue.ToString() + "," + txtTiet.Text.Trim() + ")";
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var num = true;
                if (num )
                {
                    MessageBox.Show("Không Thể Update. Kiểm Tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("Updated!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    displayData();
                    this.btnFilter_Click(null, null);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var num = true;
                if (num)
                {
                    MessageBox.Show("Không Thể Delete. Kiểm Tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("Deleted!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    displayData();
                    this.btnFilter_Click(null, null);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }












    }
}
