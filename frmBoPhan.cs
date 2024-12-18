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
    public partial class frmBoPhan : Form
    {
        DuLieu dl = new DuLieu();
        DataTable dt = new DataTable();
        DataColumn[] key = new DataColumn[1];
        public frmBoPhan()
        {
            InitializeComponent();
            string sql = "select * from BoPhan ";
            dt = dl.GetDataTable(sql);
            key[0] = dt.Columns["MaBP"];
            dt.PrimaryKey = key;
        }
        public void load_dgrv()
        {
            dgrvBP.DataSource = dt;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "select * from BoPhan";

            // Kiểm tra trùng khóa chính
            if (dt.Rows.Find(txtMaBP.Text) != null)
            {
                MessageBox.Show("Mã Bộ Phận đã tồn tại. Vui lòng nhập mã khác.");
                txtMaBP.Focus();
                return;
            }

            // B2: Khai báo và gán giá trị cho dòng cần thêm
            DataRow newrow = dt.NewRow();
            newrow["MaBP"] = txtMaBP.Text;
            newrow["TenBP"] = txtTenBP.Text;
            newrow["NgayTL"] = dtNgayTL.Value.ToString("dd/MM/yyyy");
            newrow["GhiChu"] = txtGhiChu.Text;


            // B3: Thêm dòng mới vào DataSet
            dt.Rows.Add(newrow);
            int kq = dl.TacDongDataTable(sql, dt);
            if (kq >= 1)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
                MessageBox.Show("Thêm không thành công");
            load_dgrv();

            ClearInputFields();
        }
        private void ClearInputFields()
        {
            txtMaBP.Clear();
            txtTenBP.Clear();
            dtNgayTL.Value = DateTime.Now;
            txtGhiChu.Clear();
        }
        

      

        private void frmBoPhan_Load(object sender, EventArgs e)
        {
            load_dgrv();
        }

       

        private void txtMaBP_Leave(object sender, EventArgs e)
        {
            if (txtMaBP.Text == string.Empty)
                errorProvider1.SetError(txtMaBP, "Bạn phải nhập mã bộ phận");

        }

        private void dgrvBP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBP.DataBindings.Clear();
            txtMaBP.DataBindings.Add("Text", dgrvBP.DataSource, "MaBP");

            txtTenBP.DataBindings.Clear();
            txtTenBP.DataBindings.Add("Text", dgrvBP.DataSource, "TenBP");

            dtNgayTL.DataBindings.Clear();
            dtNgayTL.DataBindings.Add("Text", dgrvBP.DataSource, "NgayTL");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", dgrvBP.DataSource, "GhiChu");
        }

        private void dgrvBP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBP.DataBindings.Clear();
            txtMaBP.DataBindings.Add("Text", dgrvBP.DataSource, "MaBP");

            txtTenBP.DataBindings.Clear();
            txtTenBP.DataBindings.Add("Text", dgrvBP.DataSource, "TenBP");

            dtNgayTL.DataBindings.Clear();
            dtNgayTL.DataBindings.Add("Text", dgrvBP.DataSource, "NgayTL");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", dgrvBP.DataSource, "GhiChu");
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            string maBP = txtMaBP.Text.Trim();
            string tenBP = txtTenBP.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();

            string ngayTL = dtNgayTL.Value.ToString("dd-MM-yyyy");

            // Kiểm tra nếu mã nhân viên không rỗng
            if (string.IsNullOrEmpty(maBP))
            {
                MessageBox.Show("Mã Bộ Phận không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo câu lệnh SQL để cập nhật thông tin nhân viên
            string sql = @"
                         UPDATE BoPhan
                         SET 
                             TenBP = @TenBP,
                             GhiChu = @GhiChu,
                             NgayTL = @NgayTL               
                         WHERE 
                             MaBP = @MaBP";

            // Tạo các tham số cho câu lệnh SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@MaBP", maBP),
                 new SqlParameter("@TenBP", tenBP),

                 new SqlParameter("@NgayTL", ngayTL),
                 new SqlParameter("@GhiChu", ghiChu)

            };

            try
            {
                // Gọi phương thức để thực hiện cập nhật
                int result = dl.GetDuLieu(sql, parameters);

                // Kiểm tra kết quả cập nhật
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin Bộ Phận thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_dgrv();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Bộ Phận để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bộ phận này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                string[] tables = { "PhongBan", "NhanVien" };
                DuLieu dl = new DuLieu();
                bool hasReferences = false;

                foreach (string table in tables)
                {

                    if (dl.KiemTraKhoaNgoai(table, "MaBP", txtMaBP.Text))
                    {
                        hasReferences = true;
                        MessageBox.Show($"Không thể xóa Bộ Phận này vì nó đang được sử dụng trong bảng {table}.");
                        break;
                    }
                }

                if (!hasReferences)
                {

                    string sql = "DELETE FROM BoPhan WHERE MaBP = @MaBP";
                    SqlParameter[] parameters = { new SqlParameter("@MaBP", txtMaBP.Text) };
                    int kq = dl.GetDuLieu(sql, parameters);

                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa Bộ Phận thành công.");
                        load_dgrv();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công.");
                    }


                }
            }
        }

     
    }
}
