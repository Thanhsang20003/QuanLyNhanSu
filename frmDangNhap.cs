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

namespace Nhom8_QuanLyNhanSu
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        DuLieu duLieu = new DuLieu();


        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Đóng úng dụng nhé ??", "xác nhận", MessageBoxButtons.YesNo);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            // Câu lệnh SQL để kiểm tra loại tài khoản
            string sqlCheckUser = "SELECT type FROM account WHERE Username = @username";

            try
            {
                // Thực hiện truy vấn để kiểm tra loại tài khoản
                SqlParameter[] userParameters = new SqlParameter[] {
            new SqlParameter("@username", username)
        };

                object result = duLieu.ExecuteScalar(sqlCheckUser, userParameters);

                if (result != null) // Tên đăng nhập tồn tại
                {
                    string sqlCheckPassword = "SELECT COUNT(*) FROM account WHERE Username = @username AND Password = @password";
                    SqlParameter[] passwordParameters = new SqlParameter[] {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

                    int passwordCount = (int)duLieu.ExecuteScalar(sqlCheckPassword, passwordParameters);

                    if (passwordCount > 0) // Mật khẩu đúng
                    {
                        int type = Convert.ToInt32(result);

                        // Truy vấn MaNV từ Username
                        string sqlGetMaNV = @"
                    SELECT nv.MaNV 
                    FROM nhanvien nv
                    INNER JOIN account acc ON nv.Username = acc.Username
                    WHERE acc.Username = @username";
                        SqlParameter[] maNVParameters = new SqlParameter[] {
                    new SqlParameter("@username", username)
                };

                        object maNV = duLieu.ExecuteScalar2(sqlGetMaNV, maNVParameters);

                        if (maNV != null && maNV != DBNull.Value) // Kiểm tra MaNV
                        {
                            // Lưu Mã nhân viên (MaNV là kiểu varchar, sẽ là chuỗi)
                            LuuTkDN.TenDangNhapHienTai = username;
                            LuuTkDN.MaNVHienTai = maNV.ToString();  // Chuyển maNV thành chuỗi


                            // Hiển thị form chính tương ứng với type
                            frmTrangChu mainForm;
                            if (type == 0)
                            {
                                mainForm = new frmTrangChu("Admin");
                            }
                            else if (type == 3)
                            {
                                mainForm = new frmTrangChu("Staff");
                            }
                            else
                            {
                                MessageBox.Show("Loại tài khoản không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            this.Hide();
                            mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Không thể lấy thông tin mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else // Mật khẩu không đúng
                    {
                        MessageBox.Show("Mật khẩu hoặc tài khoản không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else // Tên đăng nhập không tồn tại
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult r= MessageBox.Show("Đóng úng dụng nhé ??", "xác nhận", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
