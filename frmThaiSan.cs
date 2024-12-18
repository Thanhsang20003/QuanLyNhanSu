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
    public partial class frmThaiSan : Form
    {
        DuLieu dl = new DuLieu();
        DataTable dt = new DataTable();
        DataColumn[] key = new DataColumn[1];
        public frmThaiSan()
        {
            InitializeComponent();
            string sql = "select * from dsthaisan ";
            dt = dl.GetDataTable(sql);
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
        }
        public void load_dgrv()
        {
            dgrvThaiSan.DataSource = dt;
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
        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_dgrv();
        }

        private void frmThaiSan_Load(object sender, EventArgs e)
        {
            load_cbomanv();
            load_dgrv();
        }

        private void dgrvThaiSan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem hàng được click có hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Xóa tất cả binding cũ trước khi thiết lập mới
                txtMaTS.DataBindings.Clear();
                txtMaTS.DataBindings.Add("Text", dgrvThaiSan.DataSource, "Mathaisan");

                cboMaNV.DataBindings.Clear();
                cboMaNV.DataBindings.Add("Text", dgrvThaiSan.DataSource, "manv");


                // Chuyển đổi ngày bắt đầu và kết thúc
                dtNgayBDNghi.DataBindings.Clear();
                dtNgayBDNghi.DataBindings.Add("Text", dgrvThaiSan.DataSource, "Ngaybatdau");


                dtNgayKT.DataBindings.Clear();
                dtNgayKT.DataBindings.Clear();
                dtNgayKT.DataBindings.Add("Text", dgrvThaiSan.DataSource, "ngayketthuc");


                txtTrangThai.DataBindings.Clear();
                txtTrangThai.DataBindings.Add("Text", dgrvThaiSan.DataSource, "trangthai");
            }

        }

       

        private void btn_them_Click(object sender, EventArgs e)
        {
            string sql = "select * from dsthaisan";

            //B2: Khai báo và gán giá trị cho dòng cần thêm
            DataRow newrow = dt.NewRow();
            newrow["Manv"] = cboMaNV.Text;
            newrow["mathaisan"] = txtMaTS.Text;
            newrow["ngaybatdau"] = dtNgayBDNghi.Value.ToString("dd/MM/yyyy");

            newrow["ngayketthuc"] = dtNgayKT.Value.ToString("dd/MM/yyyy");
            newrow["trangthai"] = txtTrangThai.Text;


            //B3: Thêm dòng mới vào DataSet
            dt.Rows.Add(newrow);
            int kq = dl.TacDongDataTable(sql, dt);
            if (kq >= 1)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
                MessageBox.Show("Thêm không thành công");
            load_dgrv();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "select * from dsthaisan";
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //B2: Khai báo và gán giá trị cho dòng cần thêm
                DataRow dr = dt.Rows.Find(txtMaTS.Text);
                if (dr != null)
                {
                    dr.Delete();
                }

                int kq = dl.TacDongDataTable(sql, dt);
                if (kq >= 1)
                {
                    MessageBox.Show("Xóa thành công");
                }
                else
                    MessageBox.Show("Xóa không thành công");


                load_dgrv();
            }

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu mã tài sản không rỗng
            if (string.IsNullOrEmpty(txtMaTS.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài sản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo câu lệnh SQL để cập nhật thông tin trong bảng dsthaisan
            string sql = @"
                UPDATE dsthaisan 
                SET 
                    Manv = @Manv,
                    NgayBatDau = @NgayBatDau,
                    NgayKetthuc = @NgayKetthuc,
                    Trangthai = @Trangthai
                WHERE 
                    Mathaisan = @Mathaisan";

            // Tạo các tham số cho câu lệnh SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Mathaisan", txtMaTS.Text.Trim()),
                new SqlParameter("@Manv", cboMaNV.Text.Trim()),
                new SqlParameter("@NgayBatDau", dtNgayBDNghi.Value.ToString("dd/MM/yyyy")),
                new SqlParameter("@NgayKetthuc", dtNgayKT.Value.ToString("dd/MM/yyyy")),
                new SqlParameter("@Trangthai", txtTrangThai.Text.Trim())
            };

            try
            {
                // Thực hiện cập nhật thông tin trong cơ sở dữ liệu
                int result = dl.GetDuLieu(sql, parameters);

                // Kiểm tra kết quả cập nhật
                if (result > 0)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
