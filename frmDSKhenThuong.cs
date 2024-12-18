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
    public partial class frmDSKhenThuong : Form
    {
        DuLieu dl = new DuLieu();
        DataTable dt = new DataTable();
        DataColumn[] key = new DataColumn[1];


        
        public frmDSKhenThuong()
        {
            InitializeComponent();
            string sql = "select * from DSKhenThuong ";
            dt = dl.GetDataTable(sql);
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
      
        }
        public void load_dgrv()
        {
            dgrvThuong.DataSource = dt;
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

        private void frmDSKhenThuong_Load(object sender, EventArgs e)
        {
            load_cbomanv();
            load_dgrv();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            string sql = "select * from DSKhenThuong";

            //B2: Khai báo và gán giá trị cho dòng cần thêm
            DataRow newrow = dt.NewRow();
            newrow["Manv"] = cboMaNV.Text;
            newrow["MaThuong"] = txtMaThuong.Text;
            newrow["NgayThuong"] = dtNgayThuong.Value.ToString("dd/MM/yyyy");
            newrow["LyDo"] = txtLyDo.Text;
            newrow["HinhThuc"] = txtHinhThuc.Text;
            newrow["TienThuong"] = txtTien.Text;


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
            string sql = "select * from DSKhenthuong";
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //B2: Khai báo và gán giá trị cho dòng cần thêm
                DataRow dr = dt.Rows.Find(txtMaThuong.Text);
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

        private void dgrvThuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu chọn một dòng hợp lệ
            {
                DataGridViewRow selectedRow = dgrvThuong.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox bằng cách sử dụng chỉ mục cột
                txtMaThuong.Text = selectedRow.Cells[0].Value.ToString(); // Cột thứ nhất: MaThuong
                txtLyDo.Text = selectedRow.Cells[3].Value.ToString(); // Cột thứ tư: LyDo
                txtHinhThuc.Text = selectedRow.Cells[4].Value.ToString(); // Cột thứ năm: HinhThuc
                txtTien.Text = selectedRow.Cells[5].Value.ToString(); // Cột thứ sáu: TienThuong

                // Gán giá trị vào ComboBox
                cboMaNV.SelectedValue = selectedRow.Cells[1].Value.ToString(); // Cột thứ hai: manv

                // Gán giá trị cho DateTimePicker
                if (DateTime.TryParseExact(selectedRow.Cells[2].Value.ToString(), "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime ngayThuong))
                {
                    dtNgayThuong.Value = ngayThuong; // Cột thứ ba: NgayThuong
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaThuong.Text))
            {
                MessageBox.Show("Vui lòng nhập mã Thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo câu lệnh SQL để cập nhật thông tin trong bảng dsthaisan
            string sql = @"
                UPDATE dsKhenthuong
                SET 
                    Manv = @Manv,
                    NgayThuong = @NgayThuong,
                    LyDo = @LyDo,
                    HinhThuc = @HinhThuc,
                    TienThuong = @TienThuong
                WHERE 
                    MaThuong = @MaThuong";

            // Tạo các tham số cho câu lệnh SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaThuong", txtMaThuong.Text.Trim()),
                new SqlParameter("@Manv", cboMaNV.Text.Trim()),
                new SqlParameter("@NgayThuong", dtNgayThuong.Value.ToString("dd/MM/yyyy")),
                new SqlParameter("@LyDo", txtLyDo.Text.Trim()),
                new SqlParameter("@HinhThuc", txtHinhThuc.Text.Trim()),
                new SqlParameter("@TienThuong", txtTien.Text.Trim()),
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
