using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QuanLyNhanSu
{
    public partial class frmBaoHiem : Form
    {
        DuLieu dl = new DuLieu();
        DataTable dt = new DataTable();
        DataColumn[] key = new DataColumn[1];
        public frmBaoHiem()
        {
            InitializeComponent();
            string sql = "select * from DSBaoHiem ";
            dt = dl.GetDataTable(sql);
            key[0] = dt.Columns["MaBH"];
            dt.PrimaryKey = key;
        }
        public void load_dgrv()
        {
            dgrvBH.DataSource = dt;
        }
        public void load_cbomanv()
        {
            DataTable dt_manv = new DataTable();
            string sql = "select * from nhanvien";
            dt_manv = dl.GetDataTable(sql);

            cboMaNV.DataSource = dt_manv;
            cboMaNV.ValueMember = "manv";
            cboMaNV.DisplayMember = "manv";
        }

        public void load_cboLoaiBH()
        {
            string[] sql = { "BHXH", "BHYT" };

            foreach (string s in sql)
            {
                cboLoaiBH.Items.Add(s);
            }
            cboLoaiBH.SelectedIndex = 0;
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_dgrv();
        }

        private void frmBaoHiem_Load(object sender, EventArgs e)
        {
            load_cbomanv();
            load_cboLoaiBH();
            load_dgrv();

        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài sản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo câu lệnh SQL để cập nhật thông tin trong bảng dsthaisan
            string sql = @"
                UPDATE DSBaoHiem 
                SET 
                    Manv = @Manv,
                    LoaiBH = @LoaiBH,
                    MaTheBH = @MaTheBH,
                    NgayCap = @NgayCap,
                    NgayHetHan = @NgayHetHan,
                    NoiCap = @NoiCap,
                    PhiBaoHiem = @PhiBaoHiem
                WHERE 
                    MaBH = @MaBH";

            // Tạo các tham số cho câu lệnh SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaBH", txtMaBH.Text.Trim()),
                new SqlParameter("@Manv", cboMaNV.Text.Trim()),
                new SqlParameter("@LoaiBH", cboLoaiBH.Text.Trim()),
                new SqlParameter("@MaTheBH", txtMaTheBH.Text.Trim()),
                new SqlParameter("@NgayCap", dtNgayCap.Value.ToString("dd/MM/yyyy")),
                new SqlParameter("@NgayHetHan", dtNgayHetHan.Value.ToString("dd/MM/yyyy")),
                new SqlParameter("@NoiCap", txtNoiCap.Text.Trim()),
                new SqlParameter("@PhiBaoHiem", txtPhiBH.Text.Trim())
            };

            try
            {
                // Thực hiện cập nhật thông tin trong cơ sở dữ liệu
                int result = dl.GetDuLieu(sql, parameters);

                // Kiểm tra kết quả cập nhật
                if (result > 0)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_dgrv();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công, vui lòng kiểm tra lại dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgrvBH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu chọn một dòng hợp lệ
            {
                DataGridViewRow selectedRow = dgrvBH.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox bằng cách sử dụng chỉ số cột
                txtMaBH.Text = selectedRow.Cells[0].Value.ToString(); // Cột 0 là MaBH
                txtMaTheBH.Text = selectedRow.Cells[3].Value.ToString(); // Cột 1 là MaTheBH
                txtNoiCap.Text = selectedRow.Cells[6].Value.ToString(); // Cột 2 là NoiCap
                txtPhiBH.Text = selectedRow.Cells[7].Value.ToString(); // Cột 3 là PhiBaoHiem

                // Gán giá trị vào ComboBox
                cboMaNV.SelectedValue = selectedRow.Cells[1].Value.ToString(); // Cột 4 là manv
                cboLoaiBH.SelectedValue = selectedRow.Cells[2].Value.ToString(); // Cột 5 là LoaiBH

                // Gán giá trị cho DateTimePicker
                if (DateTime.TryParseExact(selectedRow.Cells[4].Value.ToString(), "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime ngayCap))
                {
                    dtNgayCap.Value = ngayCap; // Cột 6 là NgayCap
                }

                if (DateTime.TryParseExact(selectedRow.Cells[5].Value.ToString(), "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime ngayHetHan))
                {
                    dtNgayHetHan.Value = ngayHetHan; // Cột 7 là NgayHetHan
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string sql = "select * from DSBaoHiem";

            //B2: Khai báo và gán giá trị cho dòng cần thêm
            DataRow newrow = dt.NewRow();
            newrow["Manv"] = cboMaNV.Text;
            newrow["MaBH"] = txtMaBH.Text;
            newrow["LoaiBH"] = cboLoaiBH.Text;
            newrow["MaTheBH"] = txtMaTheBH.Text;
            newrow["NoiCap"] = txtNoiCap.Text;
            newrow["NgayCap"] = dtNgayCap.Value.ToString("dd/MM/yyyy");

            newrow["NgayHetHan"] = dtNgayHetHan.Value.ToString("dd/MM/yyyy");
            newrow["PhiBaoHiem"] = txtPhiBH.Text;


            //B3: Thêm dòng mới vào DataSet
            dt.Rows.Add(newrow);
            int kq = dl.TacDongDataTable(sql, dt);
            if (kq >= 1)
            {
                MessageBox.Show("Thêm thành công");
                load_dgrv();
            }
            else
                MessageBox.Show("Thêm không thành công");
            load_dgrv();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "select * from DSBaoHiem";
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //B2: Khai báo và gán giá trị cho dòng cần thêm
                DataRow dr = dt.Rows.Find(txtMaBH.Text);
                if (dr != null)
                {
                    dr.Delete();
                }

                int kq = dl.TacDongDataTable(sql, dt);
                if (kq >= 1)
                {
                    MessageBox.Show("Xóa thành công");
                    load_dgrv();
                }
                else
                    MessageBox.Show("Xóa không thành công");


                load_dgrv();
            }
        }
    }
}
