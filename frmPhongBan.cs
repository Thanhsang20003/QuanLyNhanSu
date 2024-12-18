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
    public partial class frmPhongBan : Form
    {
        DuLieu csdl = new DuLieu(); 
        DataTable dt = new DataTable(); 
        DataTable dtBoPhan = new DataTable(); 
        public frmPhongBan()
        {
            InitializeComponent();
        }

        public void load_CboMaBP()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM PhongBan"; 

            dt = csdl.GetDataTable(sql);

            if (dt.Rows.Count > 0) 
            {
                cboMaBP.DataSource = dt;
                cboMaBP.ValueMember = "MaBP"; 
                cboMaBP.DisplayMember = "MaBP"; 
                cboMaBP.SelectedIndex=0;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị."); 
            }
        }
        private void LoadData()
        {
            string sql = "SELECT * FROM PhongBan"; 
            dt = csdl.GetDataTable(sql);
            dgrvPB.DataSource = dt; 
        }
      
        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            load_CboMaBP();
            LoadData();
        }
        private void dgrvPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgrvPB.Rows[e.RowIndex];

                txtMaPB.Text = row.Cells[0].Value?.ToString(); 
                cboMaBP.SelectedValue = row.Cells[1].Value; 
                txtTenPB.Text = row.Cells[2].Value?.ToString(); 
                txtDC.Text = row.Cells[3].Value?.ToString(); 
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPB.Text.Trim();
            string tenPhong = txtTenPB.Text.Trim();
            string diaChi = txtDC.Text.Trim();
            string maBP = cboMaBP.SelectedValue.ToString();


            // Kiểm tra xem tên phòng ban có được nhập hay không
            if (string.IsNullOrWhiteSpace(tenPhong))
            {
                MessageBox.Show("Tên phòng ban không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPB.Focus();
                return;
            }


            if (csdl.KiemTraTrungKhoaChinh("PhongBan", "MaPhong", maPhong))
            {
                MessageBox.Show("Mã phòng ban đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu lệnh SQL để thêm phòng ban
            string sql = "INSERT INTO PhongBan (MaPhong, TenPhong,  DiaChi, MaBP) VALUES (@maPhong, @tenPhong, @diaChi, @maBP)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maPhong", maPhong),
                new SqlParameter("@tenPhong", tenPhong),
                new SqlParameter("@diaChi", diaChi),
                new SqlParameter("@maBP", maBP)
            };

            try
            {
                // Thực hiện câu lệnh SQL
                int result = csdl.GetDuLieu(sql, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Thêm phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm phòng ban thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPB.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng ban để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhong = txtMaPB.Text.Trim();
            DuLieu duLieu = new DuLieu();

            if (duLieu.KiemTraKhoaNgoai("NhanVien", "MaPhong", maPhong))
            {
                MessageBox.Show("Không thể xóa phòng ban vì nó đang được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu không có khóa ngoại, tiến hành xóa
            string sql = "DELETE FROM PhongBan WHERE MaPhong = @maPhong";
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@maPhong", maPhong)
            };

            int result = duLieu.GetDuLieu(sql, parameters);

            if (result > 0)
            {
                MessageBox.Show("Xóa phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
          
                if (string.IsNullOrEmpty(txtMaPB.Text))
                {
                    MessageBox.Show("Vui lòng chọn phòng ban để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPhong = txtMaPB.Text.Trim();
                string tenBP = txtTenPB.Text.Trim();
                string diaChi = txtDC.Text.Trim();
                string maBP = cboMaBP.SelectedValue.ToString();


                string sql = "UPDATE PhongBan SET  DiaChi = @diaChi, MaBP = @maBP WHERE MaPhong = @maPhong";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@maPhong", maPhong),
                new SqlParameter("@tenBP", tenBP),
                new SqlParameter("@diaChi", diaChi),
                new SqlParameter("@maBP", maBP)
                };

                try
                {
                    int result = csdl.GetDuLieu(sql, parameters);
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật phòng ban thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

    }
}
