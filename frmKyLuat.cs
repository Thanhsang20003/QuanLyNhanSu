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
    public partial class frmKyLuat : Form
    {
        DuLieu csdl = new DuLieu();
        DataTable dt = new DataTable();
        public frmKyLuat()
        {
            InitializeComponent();
            LoadData();
            LoadCboNV();
        }
        private void LoadData()
        {
            string sql = "SELECT * FROM DSKyLuat";
            dt = csdl.GetDataTable(sql);
            dgrvKL.DataSource = dt;
        }
        public void LoadCboNV()
        {
            DataTable dt_manv = new DataTable();
            string sql = "select * from nhanvien";
            dt_manv = csdl.GetDataTable(sql);

            cboMaNV.DataSource = dt_manv;
            cboMaNV.ValueMember = "manv";
            cboMaNV.DisplayMember = "manv";

        }

        private void dgrvKL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu chọn một dòng hợp lệ
            {
                DataGridViewRow selectedRow = dgrvKL.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox theo thứ tự cột
                txtMaKL.Text = selectedRow.Cells[0].Value.ToString(); // Cột đầu tiên là MaKyLuat
                txtHinhThuc.Text = selectedRow.Cells[4].Value.ToString(); // Cột thứ hai là HinhThuc
                txtLyDo.Text = selectedRow.Cells[3].Value.ToString(); // Cột thứ ba là LyDo
                txtTien.Text = selectedRow.Cells[5].Value.ToString(); // Cột thứ tư là TienPhat

                cboMaNV.SelectedValue = selectedRow.Cells[1].Value.ToString(); // Cột thứ hai: manv

                // Lấy giá trị từ cột ngày tháng của dòng được chọn và gán vào DateTimePicker
                var cellValueNgayLap = selectedRow.Cells[2].Value; // Cột thứ sáu là NgayKyLuat
                if (DateTime.TryParse(cellValueNgayLap.ToString(), out DateTime selectedDate))
                {
                    dtNgayLap.Value = selectedDate; // Gán giá trị vào DateTimePicker dtNgayLap
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maKL = txtMaKL.Text.Trim();
            string hinhthuc = txtHinhThuc.Text;
            string lydo = txtLyDo.Text;
            string tien = txtTien.Text;
            string maNV = cboMaNV.Text.Trim();
            string dt_Lap = dtNgayLap.Value.ToString("dd/MM/yyyy");
            if (csdl.KiemTraTrungKhoaChinh("DSKyLuat", "MaKyLuat", maKL))
            {
                MessageBox.Show("Mã kỹ luật đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "SET IDENTITY_INSERT DSKyLuat ON; INSERT INTO DSKyLuat (MaKyLuat, HinhThuc, MaNV, LyDo, TienPhat, NgayKyLuat) VALUES (@maKL, @hinhthuc, @maNV, @lydo, @tien, @ngaylap)";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@maKL", maKL),
                    new SqlParameter("@hinhthuc", hinhthuc),
                    new SqlParameter("@maNV", maNV),
                    new SqlParameter("@lydo", lydo),
                    new SqlParameter("@tien", tien),
                    new SqlParameter("@ngaylap", dt_Lap)
                };

                int result = csdl.GetDuLieu(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Clear()
        {
            txtMaKL.Clear();
            txtHinhThuc.Clear();
            cboMaNV.ResetText();
            txtTien.Clear();
            txtLyDo.Clear();
            txtMaKL.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKL.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKL = txtMaKL.Text.Trim();
            string hinhthuc = txtHinhThuc.Text;
            string lydo = txtLyDo.Text;
            string tien = txtTien.Text;
            string maNV = cboMaNV.Text.Trim();
            string dt_Lap = dtNgayLap.Value.ToString("đ/MM/yyyy");
            

            string sql = "UPDATE DSKyLuat SET HinhThuc = @hinhthuc, MaNV = @maNV, LyDo = @lydo, TienPhat = @tien, NgayKyLuat = @ngaylap WHERE MaKyLuat = @maKL";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@maKL", maKL),
                    new SqlParameter("@hinhthuc", hinhthuc),
                    new SqlParameter("@maNV", maNV),
                    new SqlParameter("@lydo", lydo),
                    new SqlParameter("@tien", tien),
                    new SqlParameter("@ngaylap", dt_Lap)
                };


                int result = csdl.GetDuLieu(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật kỹ luật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật kỹ luật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKL.Text))
            {
                MessageBox.Show("Vui lòng chọn một kỹ luật để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKL = txtMaKL.Text.Trim();

            string sql = "DELETE FROM DSKyLuat WHERE MaKyLuat = @maKL";

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@maKL", maKL)
                };

                int result = csdl.GetDuLieu(sql, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa một kỹ luật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa một kỹ luật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
    
    }
}
