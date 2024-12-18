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
    public partial class frmTinhLuong : Form
    {
        DuLieu duLieu = new DuLieu();
        DataTable dt = new DataTable();
        public frmTinhLuong()
        {
            InitializeComponent();
        }

        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadData();
        }
        private void LoadData()
        {
            string sql = "SELECT * FROM TongLuong";
            dt = duLieu.GetDataTable(sql);
            dgvTongLuong.DataSource = dt;
        }
        private void LoadNhanVien()
        {
            try
            {
                string sql = "SELECT MaNV, TenNV FROM NhanVien";
                DataTable dt = duLieu.GetDataTable(sql);
                cboMaNV.DataSource = dt;
                cboMaNV.DisplayMember = "TenNV";
                cboMaNV.ValueMember = "MaNV";
                cboMaNV.SelectedIndex = -1; // Đảm bảo không có lựa chọn mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex == -1) return; // Kiểm tra nếu chưa chọn nhân viên

            string maNV = cboMaNV.SelectedValue.ToString();
            LoadThongTinLuong(maNV);
            LoadThongTinPhuCap(maNV);
        }
        private void LoadThongTinLuong(string maNV)
        {
            try
            {
                // Lấy lương cơ bản của nhân viên
                string sqlLuongCB = "SELECT LuongCB FROM Luong WHERE MaNV = @MaNV";
                SqlParameter[] parametersLuongCB = { new SqlParameter("@MaNV", maNV) };
                object resultLuongCB = duLieu.ExecuteScalar2(sqlLuongCB, parametersLuongCB);

                if (resultLuongCB != DBNull.Value && resultLuongCB != null)
                {
                    cboLuongCB.Text = resultLuongCB.ToString();
                }
                else
                {
                    cboLuongCB.Text = "0"; // Trường hợp không có lương cơ bản
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin lương cơ bản: " + ex.Message);
            }
        }
        private void LoadThongTinPhuCap(string maNV)
        {
            try
            {
                // Load thông tin số ngày công
                string sqlSoNgayCong = "SELECT COUNT(*) FROM ChamCong WHERE MaNV = @MaNV";
                SqlParameter[] parametersSoNgayCong = { new SqlParameter("@MaNV", maNV) };
                object resultSoNgayCong = duLieu.ExecuteScalar2(sqlSoNgayCong, parametersSoNgayCong);
                int soNgayCong = resultSoNgayCong != DBNull.Value ? Convert.ToInt32(resultSoNgayCong) : 0;
                txtSoNgayCong.Text = soNgayCong.ToString();

                // Load thông tin tiền thưởng
                string sqlTienThuong = "SELECT SUM(TienThuong) FROM DSKhenThuong WHERE MaNV = @MaNV";
                SqlParameter[] parametersThuong = { new SqlParameter("@MaNV", maNV) };
                object resultTienThuong = duLieu.ExecuteScalar2(sqlTienThuong, parametersThuong);
                double tienThuong = resultTienThuong != DBNull.Value ? Convert.ToDouble(resultTienThuong) : 0;
                txtTienThuong.Text = tienThuong.ToString("0.00");

                // Load thông tin tiền phạt
                string sqlTienPhat = "SELECT SUM(TienPhat) FROM DSKyLuat WHERE MaNV = @MaNV";
                SqlParameter[] parametersPhat = { new SqlParameter("@MaNV", maNV) };
                object resultTienPhat = duLieu.ExecuteScalar2(sqlTienPhat, parametersPhat);
                double tienPhat = resultTienPhat != DBNull.Value ? Convert.ToDouble(resultTienPhat) : 0;
                txtTienPhat.Text = tienPhat.ToString("0.00");

                // Load thông tin tiền bảo hiểm
                string sqlTienBaoHiem = "SELECT SUM(PhiBaoHiem) FROM DSBaoHiem WHERE MaNV = @MaNV";
                SqlParameter[] parametersBaoHiem = { new SqlParameter("@MaNV", maNV) };
                object resultTienBaoHiem = duLieu.ExecuteScalar2(sqlTienBaoHiem, parametersBaoHiem);
                double tienBaoHiem = resultTienBaoHiem != DBNull.Value ? Convert.ToDouble(resultTienBaoHiem) : 0;
                txtTienBaoHiem.Text = tienBaoHiem.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin phụ cấp: " + ex.Message);
            }
        }


        

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = cboMaNV.SelectedValue.ToString();
            DateTime tuNgay = dtTuNgay.Value;
            DateTime denNgay = dtDenNgay.Value;

            try
            {
                // Lấy lương cơ bản từ bảng Luong
                string sqlLuongCB = "SELECT LuongCB FROM Luong WHERE MaNV = @MaNV";
                SqlParameter[] parametersLuongCB = { new SqlParameter("@MaNV", maNV) };
                object resultLuongCB = duLieu.ExecuteScalar2(sqlLuongCB, parametersLuongCB);
                double luongCB = resultLuongCB != DBNull.Value ? Convert.ToDouble(resultLuongCB) : 0;

                // Lấy số ngày công từ bảng ChamCong
                string sqlSoNgayCong = @"
            SELECT COUNT(*) 
            FROM ChamCong 
            WHERE MaNV = @MaNV AND Ngaycham BETWEEN @TuNgay AND @DenNgay";
                SqlParameter[] parametersSoNgayCong = {
            new SqlParameter("@MaNV", maNV),
            new SqlParameter("@TuNgay", tuNgay.ToString("yyyy-MM-dd")),
            new SqlParameter("@DenNgay", denNgay.ToString("yyyy-MM-dd"))
        };
                object resultSoNgayCong = duLieu.ExecuteScalar2(sqlSoNgayCong, parametersSoNgayCong);
                double soNgayLamViec = resultSoNgayCong != DBNull.Value ? Convert.ToDouble(resultSoNgayCong) : 0;

                if (soNgayLamViec == 0)
                {
                    MessageBox.Show("Nhân viên không có ngày công trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tính lương và các phụ cấp, phạt
                double luongHangNgay = luongCB / 22; // Giả sử 22 ngày làm việc trong tháng
                double tienThuong = Convert.ToDouble(txtTienThuong.Text);
                double tienPhat = Convert.ToDouble(txtTienPhat.Text);
                double tienBaoHiem = Convert.ToDouble(txtTienBaoHiem.Text);
                double tongLuong = (luongHangNgay * soNgayLamViec) + tienThuong - tienPhat - tienBaoHiem;

                // Lưu vào bảng TongLuong
                string sqlInsertTongLuong = @"
            INSERT INTO TongLuong (MaNV, TuNgay, DenNgay, SoNgayCong, TongPhiBH, TongTienThuong, TongTienPhat, TongLuong)
            VALUES (@MaNV, @TuNgay, @DenNgay, @SoNgayCong, @TongPhiBH, @TongTienThuong, @TongTienPhat, @TongLuong)";
                SqlParameter[] parametersTongLuong = {
            new SqlParameter("@MaNV", maNV),
            new SqlParameter("@TuNgay", tuNgay.ToString("yyyy-MM-dd")),
            new SqlParameter("@DenNgay", denNgay.ToString("yyyy-MM-dd")),
            new SqlParameter("@SoNgayCong", soNgayLamViec),
            new SqlParameter("@TongPhiBH", tienBaoHiem),
            new SqlParameter("@TongTienThuong", tienThuong),
            new SqlParameter("@TongTienPhat", tienPhat),
            new SqlParameter("@TongLuong", tongLuong)
        };

                duLieu.GetDuLieu(sqlInsertTongLuong, parametersTongLuong); // Thực thi câu lệnh INSERT
                MessageBox.Show("Tính lương thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
    }
