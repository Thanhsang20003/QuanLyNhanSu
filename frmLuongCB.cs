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
    public partial class frmLuongCB : Form
    {
        DuLieu csdl = new DuLieu();
        DataTable dt = new DataTable();
        public frmLuongCB()
        {
            InitializeComponent();
            LoadData();
            LoadCboNV();
        }
        private void LoadData()
        {
            string sql = "SELECT * FROM Luong";
            dt = csdl.GetDataTable(sql);
            dgrvBangLuong.DataSource = dt;
        }
        public void LoadCboNV()
        {
            String sql = "select * from Luong";
            DataTable dt_nv = new DataTable();
            dt_nv = csdl.GetDataTable(sql);

            cboMaNV.DataSource = dt_nv;
            cboMaNV.ValueMember = "MaNV";
            cboViTri.DataSource = dt_nv;
            cboViTri.DisplayMember = "ChucVu";
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các trường dữ liệu cần thiết không rỗng
            if (string.IsNullOrEmpty(cboMaNV.Text) || string.IsNullOrEmpty(txtLuongCB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo câu lệnh SQL để cập nhật thông tin lương cơ bản
            string sql = @"
                UPDATE Luong 
                SET 
                    LuongCB = @LuongCB,
                    ChucVu = @ChucVu
                WHERE 
                    MaNV = @MaNV";

            // Tạo các tham số cho câu lệnh SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", cboMaNV.SelectedValue.ToString().Trim()),  // Lấy mã nhân viên từ ComboBox
                new SqlParameter("@LuongCB", txtLuongCB.Text.Trim()),                // Lấy lương cơ bản từ TextBox
                new SqlParameter("@ChucVu", cboViTri.Text.Trim())                    // Lấy chức vụ từ ComboBox
            };

            try
            {
                // Thực hiện cập nhật thông tin lương trong cơ sở dữ liệu
                int result = csdl.GetDuLieu(sql, parameters);

                // Kiểm tra kết quả cập nhật
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();  // Tải lại dữ liệu để hiển thị thông tin mới nhất
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công, vui lòng kiểm tra lại dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgrvBangLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgrvBangLuong.Rows[e.RowIndex];

                cboMaNV.Text = selectedRow.Cells[0].Value.ToString();  // Cột đầu tiên là MaNV
                txtLuongCB.Text = selectedRow.Cells[1].Value.ToString(); // Cột thứ hai là LuongCB
                cboViTri.Text = selectedRow.Cells[2].Value.ToString();   // Cột thứ ba là ChucVu
            }
        }

        private void dgrvBangLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
