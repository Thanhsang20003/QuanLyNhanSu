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
    public partial class frmNhanVien : Form
    {
        DuLieu dl = new DuLieu();
        DataTable dt = new DataTable();
        DataColumn[] key = new DataColumn[1];
        public frmNhanVien()
        {
            InitializeComponent();
            string sql = "select * from nhanvien ";
            dt = dl.GetDataTable(sql);
            key[0] = dt.Columns["MaNV"]; 
            dt.PrimaryKey = key;

        }
        public void load_dgrv()
        {
            dgrvNhanVien.DataSource = dt;
        }
        public void load_cbogt()
        {
            string[] sql = { "Nam", "Nữ" };

            foreach (string s in sql)
            {
                cboGioiTinh.Items.Add(s);
            }
            cboGioiTinh.SelectedIndex = 0;

        }
        public void load_cbottrang()
        {
            string[] sql = { "Đang Làm Việc", "Không làm việc " };

            foreach (string s in sql)
            {
                cboHienTrang.Items.Add(s);
            }
            cboHienTrang.SelectedIndex = 0;


        }
        public void load_cbotkhoan()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM account";
            dt = dl.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                cboTaiKhoan.DataSource = dt;
                cboTaiKhoan.ValueMember = "Username";
                cboTaiKhoan.DisplayMember = "Username";
                cboTaiKhoan.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
        }
        public void load_cbobphan()
        {
            DataTable dt_bp = new DataTable();
            string sql = "select * from bophan ";
            dt_bp = dl.GetDataTable(sql);

            cboMaBP.DataSource = dt_bp;
            cboMaBP.ValueMember = "mabp";
            cboMaBP.DisplayMember = "mabp";
        }

        public void load_cbopban()
        {
            DataTable dt_pb = new DataTable();
            string sql = "select * from phongban where mabp='" + cboMaBP.SelectedValue.ToString() + "'";
            dt_pb = dl.GetDataTable(sql);

            cboMaPB.DataSource = dt_pb;
            cboMaPB.ValueMember = "maphong";
            cboMaPB.DisplayMember = "maphong";
        }
        private void cboMaBP_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_cbopban();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "select * from nhanvien";

            // Kiểm tra trùng khóa chính
            if (dt.Rows.Find(txtMaNV.Text) != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.");
                txtMaNV.Focus();
                return;
            }

            // B2: Khai báo và gán giá trị cho dòng cần thêm
            DataRow newrow = dt.NewRow();
            newrow["Manv"] = txtMaNV.Text;
            newrow["Tennv"] = txtTenNV.Text;
            newrow["NgaySinh"] = dtNgaySinh.Value.ToString("dd/MM/yyyy");
            newrow["Gioitinh"] = cboGioiTinh.Text;
            newrow["QueQuan"] = txtQueQuan.Text;
            newrow["SDT"] = txtSDT.Text;
            newrow["DiaChi"] = txtDiaChi.Text;
            newrow["CMND"] = txtCMND.Text;
            newrow["Email"] = txtEmail.Text;
            newrow["TenTDHV"] = txtTrinhDoHV.Text;
            newrow["CNganh"] = txtChuyenNganh.Text;
            newrow["ChucVu"] = txtViTri.Text;
            newrow["Username"] = cboTaiKhoan.Text;
            newrow["MaPhong"] = cboMaPB.Text;
            newrow["MaBP"] = cboMaBP.Text;
            newrow["TinhTrang"] = cboHienTrang.Text;
            newrow["NgayVaoLam"] = dtNgayVaoLam.Value.ToString("dd/MM/yyyy");

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

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            load_cbogt();
            load_cbottrang();
            load_cbotkhoan();
            load_cbobphan();

            load_dgrv();
        }

        private void dgrvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dgrvNhanVien.DataSource, "Manv");

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", dgrvNhanVien.DataSource, "tennv");

            cboGioiTinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Add("Text", dgrvNhanVien.DataSource, "gioitinh");

            dtNgaySinh.DataBindings.Clear();
            dtNgaySinh.DataBindings.Add("Text", dgrvNhanVien.DataSource, "ngaysinh");

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", dgrvNhanVien.DataSource, "cmnd");

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgrvNhanVien.DataSource, "sdt");

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgrvNhanVien.DataSource, "email");

            txtQueQuan.DataBindings.Clear();
            txtQueQuan.DataBindings.Add("Text", dgrvNhanVien.DataSource, "quequan");

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgrvNhanVien.DataSource, "diachi");

            cboMaBP.DataBindings.Clear();
            cboMaBP.DataBindings.Add("Text", dgrvNhanVien.DataSource, "mabp");

            cboMaPB.DataBindings.Clear();
            cboMaPB.DataBindings.Add("Text", dgrvNhanVien.DataSource, "maphong");

            cboHienTrang.DataBindings.Clear();
            cboHienTrang.DataBindings.Add("Text", dgrvNhanVien.DataSource, "tinhtrang");

            dtNgayVaoLam.DataBindings.Clear();
            dtNgayVaoLam.DataBindings.Add("Text", dgrvNhanVien.DataSource, "ngayvaolam");

            txtViTri.DataBindings.Clear();
            txtViTri.DataBindings.Add("Text", dgrvNhanVien.DataSource, "chucvu");

            cboTaiKhoan.DataBindings.Clear();
            cboTaiKhoan.DataBindings.Add("Text", dgrvNhanVien.DataSource, "username");

            txtTrinhDoHV.DataBindings.Clear();
            txtTrinhDoHV.DataBindings.Add("Text", dgrvNhanVien.DataSource, "tentdhv");

            txtChuyenNganh.DataBindings.Clear();
            txtChuyenNganh.DataBindings.Add("Text", dgrvNhanVien.DataSource, "cnganh");
        }
        private void ClearInputFields()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            dtNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = -1;
            txtQueQuan.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtCMND.Clear();
            txtEmail.Clear();
            txtTrinhDoHV.Clear();
            txtChuyenNganh.Clear();
            txtViTri.Clear();
            cboTaiKhoan.SelectedIndex = -1;
            cboMaPB.SelectedIndex = -1;
            cboHienTrang.SelectedIndex = -1;
            dtNgayVaoLam.Value = DateTime.Now;
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();
            string gioiTinh = cboGioiTinh.Text.Trim();
            string queQuan = txtQueQuan.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string email = txtEmail.Text.Trim();
            string chucVu = txtViTri.Text.Trim();
            string tinhTrang = cboHienTrang.Text.Trim();
            string userName = cboTaiKhoan.Text.Trim();
            string maPhong = cboMaPB.Text.Trim();
            string maBP = cboMaBP.Text.Trim();

            string ngaySinh = dtNgaySinh.Value.ToString("dd-MM-yyyy");
            string ngayVaoLam = dtNgayVaoLam.Value.ToString("dd-MM-yyyy");

            // Kiểm tra nếu mã nhân viên không rỗng
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Mã nhân viên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = @"
                UPDATE NhanVien 
                SET 
                    TenNV = @TenNV,
                    GioiTinh = @GioiTinh,
                    NgaySinh = @NgaySinh,
                    QueQuan = @QueQuan,
                    SDT = @SDT,
                    DiaChi = @DiaChi,
                    Email = @Email,
                    ChucVu = @ChucVu,
                    TinhTrang = @TinhTrang,
                    NgayVaoLam = @NgayVaoLam,
                    UserName = @UserName,         
                    MaPhong = @MaPhong,           
                    MaBP = @MaBP                 
                WHERE 
                    MaNV = @MaNV";

            // Tạo các tham số cho câu lệnh SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@TenNV", tenNV),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@QueQuan", queQuan),
                new SqlParameter("@SDT", sdt),
                new SqlParameter("@DiaChi", diaChi),
                new SqlParameter("@Email", email),
                new SqlParameter("@ChucVu", chucVu),
                new SqlParameter("@TinhTrang", tinhTrang),
                new SqlParameter("@NgayVaoLam", ngayVaoLam),
                new SqlParameter("@UserName", userName),
                new SqlParameter("@MaPhong", maPhong),
                new SqlParameter("@MaBP", maBP)
            };

            try
            {
                // Gọi phương thức để thực hiện cập nhật
                int result = dl.GetDuLieu(sql, parameters);

                // Kiểm tra kết quả cập nhật
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string[] tables = { "ChamCong", "Luong", "DSBaoHiem", "DSKhenThuong", "DSKyLuat", "DSThaiSan", "HopDong" };

                bool hasReferences = false;

                foreach (string table in tables)
                {
                    if (dl.KiemTraKhoaNgoai(table, "MaNV", txtMaNV.Text))
                    {
                        hasReferences = true;
                        MessageBox.Show($"Không thể xóa nhân viên này vì nó đang được sử dụng trong bảng {table}.");
                        break; 
                    }
                }

                if (!hasReferences)
                {
                    // Nếu không có bảng nào liên quan, tiến hành xóa nhân viên
                    string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                    SqlParameter[] parameters = { new SqlParameter("@MaNV", txtMaNV.Text) };
                    int kq = dl.GetDuLieu(sql, parameters);

                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công.");
                        load_dgrv();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công.");
                    }

                   
                }
            }
        }

    

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int maxLength = 12;


            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }


            if (txtCMND.Text.Length >= maxLength && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.");
                txtEmail.Focus();
            }
        }

        private void txtTenNV_Leave(object sender, EventArgs e)
        {
            if (txtTenNV.Text == string.Empty)
                errorProvider1.SetError(txtTenNV, "Bạn phải nhập tên nhân viên");
        }

        private void cboMaBP_SelectedValueChanged(object sender, EventArgs e)
        {
            load_cbopban();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Reporting rpt = new Reporting();
            rpt.MaBP= cboMaBP.SelectedValue.ToString();
            rpt.ShowReport("BoPhan");
            rpt.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Lấy giá trị mã nhân viên từ TextBox
            string maNV = txtMaNV.Text.Trim();

            // Kiểm tra nếu TextBox trống
            if (string.IsNullOrEmpty(maNV))
            {
                load_dgrv();
                return;
            }

            // Tạo một bản sao cấu trúc của DataTable
            DataTable filteredTable = dt.Clone();

            // Tìm các dòng trong DataTable dựa trên mã nhân viên
            DataRow[] foundRows = dt.Select($"MaNV = '{maNV}'");

            if (foundRows.Length > 0)
            {
                // Thêm các dòng tìm thấy vào bảng lọc
                foreach (DataRow row in foundRows)
                {
                    filteredTable.ImportRow(row);
                }

                // Gán DataGridView hiển thị bảng lọc
                dgrvNhanVien.DataSource = filteredTable;
            }
            else
            {
                // Hiển thị thông báo nếu không tìm thấy
                MessageBox.Show("Không tìm thấy nhân viên với mã: " + maNV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Xóa dữ liệu trong DataGridView
                dgrvNhanVien.DataSource = null;
            }
        }
    }
}
