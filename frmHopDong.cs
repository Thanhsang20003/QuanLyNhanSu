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
    public partial class frmHopDong : Form
    {
        DuLieu csdl = new DuLieu();
        DataTable dt = new DataTable();
        public frmHopDong()
        {
            InitializeComponent();
            LoadData();
            LoadCboNV();
        }
        private void LoadData()
        {
            string sql = "SELECT * FROM HopDong";
            dt = csdl.GetDataTable(sql);
            dgrvHD.DataSource = dt;
        }
        public void LoadCboNV()
        {
            String sql = "select * from NhanVien";
            DataTable dt_nv = new DataTable();
            dt_nv = csdl.GetDataTable(sql);

            cboMaNV.DataSource = dt_nv;
            cboMaNV.ValueMember = "MaNV";
        }

        private void dgrvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu chọn một dòng hợp lệ
            {
                DataGridViewRow selectedRow = dgrvHD.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox bằng cách sử dụng chỉ mục cột
                txtMaHD.Text = selectedRow.Cells[0].Value.ToString(); // Cột đầu tiên là MaHD
                txtLoaiHD.Text = selectedRow.Cells[2].Value.ToString(); // Cột thứ hai là LoaiHD

                // Sử dụng SelectedValue thay vì SelectedText cho các ComboBox bằng chỉ mục cột
                string maNV = selectedRow.Cells[1].Value.ToString(); // Cột thứ ba là MaNV
                cboMaNV.SelectedValue = maNV; // Cập nhật giá trị cho ComboBox

                // Lấy giá trị từ cột ngày tháng của dòng được chọn và gán vào DateTimePicker bằng chỉ mục cột
                var cellValueNgayBD = selectedRow.Cells[3].Value; // Cột thứ sáu là NgayBD
                if (DateTime.TryParse(cellValueNgayBD.ToString(), out DateTime selectedDateBD))
                {
                    dtNgayBD.Value = selectedDateBD;
                }

                var cellValueNgayKT = selectedRow.Cells[4].Value; // Cột thứ bảy là NgayKT
                if (DateTime.TryParse(cellValueNgayKT.ToString(), out DateTime selectedDateKT))
                {
                    dtNgayKT.Value = selectedDateKT;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim();
            string loaiHD = txtLoaiHD.Text;
            string maNV = cboMaNV.Text.Trim();


            string dt_BD = dtNgayBD.Value.ToString("dd/MM/yyyy");
            string dt_KT = dtNgayKT.Value.ToString("dd/MM/yyyy");

            if (csdl.KiemTraTrungKhoaChinh("HopDong", "MaHD", maHD))
            {
                MessageBox.Show("Hợp đồng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "INSERT INTO HopDong (MaHD, LoaiHD, MaNV, NgayBD, NgayKT) VALUES (@maHD, @loaiHD, @maNV,  @dt_BD, @dt_KT)";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@maHD", maHD),
                    new SqlParameter("@loaiHD", loaiHD),
                    new SqlParameter("@maNV", maNV),
                    new SqlParameter("@dt_BD", dt_BD),
                    new SqlParameter("@dt_KT", dt_KT)
                };

                int result = csdl.GetDuLieu(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtMaHD.Clear();
            txtLoaiHD.Clear();
            cboMaNV.ResetText();
            txtMaHD.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHD = txtMaHD.Text.Trim();

            string sql = "DELETE FROM HopDong WHERE MaHD = @maHD";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@maHD", maHD)
                };

                int result = csdl.GetDuLieu(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa hợp đồng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHD = txtMaHD.Text.Trim();
            string loaiHD = txtLoaiHD.Text;
            string maNV = cboMaNV.Text.Trim();
            string dt_BD = dtNgayBD.Value.ToString("dd/MM/yyyy");
            string dt_KT = dtNgayKT.Value.ToString("dd/MM/yyyy");

            string sql = "UPDATE HopDong SET LoaiHD = @loaiHD, MaNV = @maNV, NgayBD = @dt_BD, NgayKT = @dt_KT WHERE MaHD = @maHD";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@maHD", maHD),
                    new SqlParameter("@loaiHD", loaiHD),
                    new SqlParameter("@maNV", maNV),
                    new SqlParameter("@dt_BD", dt_BD),
                    new SqlParameter("@dt_KT", dt_KT)
                };


                int result = csdl.GetDuLieu(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật hợp đồng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
