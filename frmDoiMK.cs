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
    public partial class frmDoiMK : Form
    {
        DuLieu csdl = new DuLieu();
        public string tenDN; 
        public string tenHT; 
        public frmDoiMK(string tenDN)
        {
            InitializeComponent();
            this.tenDN = tenDN;
            txtTenDN.Text = tenDN;
        }

        private void frmDoiMK_Load(object sender, EventArgs e)
        {

            txtTenDN.Text = LuuTkDN.TenDangNhapHienTai;
            txtTenDN.Enabled = false;
            txtMK.Clear();
            txtMKMoi.Clear();
            txtNhapLai.Clear();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrWhiteSpace(txtMK.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMKMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNhapLai.Text))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu mới.");
                return;
            }

            if (txtMKMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            // Kiểm tra mật khẩu hiện tại
            string sqlCheckPassword = "SELECT COUNT(*) FROM Account WHERE UserName = @tenDN AND Password = @matKhau";
            SqlParameter[] parametersCheck = new SqlParameter[]
            {
                new SqlParameter("@tenDN", tenDN),
                new SqlParameter("@matKhau", txtMK.Text)
            };

            try
            {
                int count = csdl.ExecuteScalar(sqlCheckPassword, parametersCheck);

                if (count == 0)
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng.");
                    return;
                }

                // Cập nhật mật khẩu mới
                string sqlUpdatePassword = "UPDATE Account SET Password = @newPassword WHERE UserName = @tenDN";
                SqlParameter[] parametersUpdate = new SqlParameter[]
                {
                    new SqlParameter("@newPassword", txtMKMoi.Text),
                    new SqlParameter("@tenDN", tenDN)
                };

                int result = csdl.GetDuLieu(sqlUpdatePassword, parametersUpdate);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật mật khẩu thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
