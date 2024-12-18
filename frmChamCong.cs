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
    public partial class frmChamCong : Form
    {
        DuLieu duLieu = new DuLieu();
        public frmChamCong()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void LoadChamCong()
        {
            string sql = "SELECT * FROM ChamCong";
            DataTable dt = duLieu.GetDataTable(sql);
            dgvChamCong.DataSource = dt; 
        }
        private void frmChamCong_Load(object sender, EventArgs e)
        {
            dtGioLamViec.Value = DateTime.Now;
            dtGioLamViec.Enabled = false;
            txtMaNV.Text = LuuTkDN.MaNVHienTai;  // Gán MaNV vào textbox
            LoadChamCong();
        }

        private void btnVaoLam_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string ngayCham = DateTime.Now.ToString("yyyy-MM-dd");  // Chuyển ngày thành chuỗi
            string gioVao = dtGioLamViec.Value.ToString("HH:mm");  // Giờ vào

            // Giả sử giờ vào quy định là 7:00 sáng
            DateTime gioQuyDinh = DateTime.Parse("07:00");

            // Kiểm tra nếu giờ vào trễ so với giờ quy định
            string statusIn = DateTime.Parse(gioVao) > gioQuyDinh ? "Đi trễ" : "Đúng giờ";

            string sqlInsert = @"INSERT INTO ChamCong (MaNV, NgayCham, GioVao, StatusIn)
                         VALUES (@MaNV, @NgayCham, @GioVao, @StatusIn)";

                    SqlParameter[] parameters = {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@NgayCham", ngayCham),
                new SqlParameter("@GioVao", gioVao),
                new SqlParameter("@StatusIn", statusIn)
            };

            int kq = duLieu.GetDuLieu(sqlInsert, parameters);
            if (kq > 0)
            {
                MessageBox.Show("Chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Chấm công không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRaVe_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string ngayCham = DateTime.Now.ToString("yyyy-MM-dd");  // Ngày hiện tại
            string gioRa = dtGioLamViec.Value.ToString("HH:mm");  // Giờ ra

            // Giả sử giờ ra quy định là 17:00 (5 giờ chiều)
            DateTime gioQuyDinh = DateTime.Parse("17:00"); // Giờ quy định
            string statusOut;

            // Kiểm tra nếu giờ ra trước 5 giờ chiều
            if (DateTime.Parse(gioRa) < gioQuyDinh)
            {
                statusOut = "Về sớm";
            }
            else // Nếu giờ ra sau 5 giờ chiều
            {
                statusOut = "Đúng giờ";
            }

            // Tiến hành UPDATE vào cơ sở dữ liệu
            string sqlUpdateChamCong = @"
            UPDATE ChamCong 
            SET GioRa = @GioRa, StatusOut = @StatusOut 
            WHERE MaNV = @MaNV AND NgayCham = @NgayCham";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@NgayCham", ngayCham),
                new SqlParameter("@GioRa", gioRa),
                new SqlParameter("@StatusOut", statusOut)  // Truyền trạng thái ra có dấu
            };

            try
            {
                duLieu.GetDuLieu(sqlUpdateChamCong, parameters);  // Thực thi câu lệnh SQL UPDATE
                MessageBox.Show("Chấm công thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            LoadChamCong();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtGioLamViec.Value = DateTime.Now;  // Cập nhật giờ liên tục
        }
    }
}
