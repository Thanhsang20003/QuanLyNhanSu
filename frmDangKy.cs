using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nhom8_QuanLyNhanSu
{
    public partial class frmDangKy : Form
    {
        
        DuLieu csdl = new DuLieu();
        DataTable dt = new DataTable();
        DataTable dtLoaiTK = new DataTable(); 
        public frmDangKy()
        {        
            InitializeComponent();
            LoadData();
            LoadLoaiTK();

        }
        private void LoadData()
        {
            string sql = "SELECT * FROM account"; 
            dt = csdl.GetDataTable(sql);
            dgrvTK.DataSource = dt;
        }

        private void LoadLoaiTK()
        {
    
            cboLTK.Items.Add("Admin");
            cboLTK.Items.Add("Nhân viên");
            cboLTK.SelectedIndex = 01; 
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtTenDN.Text.Trim();
            string displayName = txtTenHT.Text.Trim();
            string password = txtMK.Text.Trim();
            string confirmPassword = txtNhapLaiMK.Text.Trim();
            int accountType = cboLTK.SelectedItem != null && cboLTK.SelectedItem.ToString() == "Admin" ? 0 : 3;  // 0 là Admin, 3 là Nhân viên


            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra xem Username có tồn tại chưa (Khóa chính)
            if (csdl.KiemTraTrungKhoaChinh("account", "Username", username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO account (Username, DisplayName, Password, Type) VALUES (@username, @displayName, @password, @type)";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@displayName", displayName),
                    new SqlParameter("@password", password),
                    new SqlParameter("@type", accountType)
                };

                int result = csdl.GetDuLieu(sql, parameters); 

                if (result > 0)
                {
                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đăng ký tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Clear()
        {
            txtTenDN.Clear();
            txtTenHT.Clear();
            txtMK.Clear();
            txtNhapLaiMK.Clear();
            cboLTK.SelectedIndex = 0; 
        }

        private void dgrvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgrvTK.Rows[e.RowIndex];

                // Dùng chỉ mục cột thay vì tên cột
                txtTenDN.Text = selectedRow.Cells[0].Value.ToString(); // Chỉ mục 0 là Username
                txtTenHT.Text = selectedRow.Cells[1].Value.ToString(); // Chỉ mục 1 là DisplayName
                txtMK.Text = selectedRow.Cells[2].Value.ToString(); // Chỉ mục 2 là Password

                cboLTK.SelectedIndex = (selectedRow.Cells[3].Value.ToString() == "0") ? 0 : 1; // Chỉ mục 3 là Type
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(txtTenDN.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtTenDN.Text.Trim();
            if (csdl.KiemTraKhoaNgoai("NhanVien", "Username", username))
            {
                MessageBox.Show("Không thể xóa tài khoản vì nó đang được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "DELETE FROM account WHERE Username = @username";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@username", username)
                };

                int result = csdl.GetDuLieu(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDN.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtTenDN.Text.Trim();
            string displayName = txtTenHT.Text.Trim();
            string password = txtMK.Text.Trim();
            int accountType = cboLTK.SelectedItem != null && cboLTK.SelectedItem.ToString() == "Admin" ? 0 : 3; // 0 là Admin, 3 là Nhân viên

            string sql = "UPDATE account SET DisplayName = @displayName, Password = @password, Type = @type WHERE Username = @username";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@displayName", displayName),
                    new SqlParameter("@password", password),
                    new SqlParameter("@type", accountType)
                };

                int result = csdl.GetDuLieu(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
