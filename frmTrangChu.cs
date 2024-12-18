using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QuanLyNhanSu
{
    public partial class frmTrangChu : Form
    {
      
        public frmTrangChu(string role)
        {
            InitializeComponent();
            // Hiển thị menu theo quyền hạn

            if (role == "Staff")
            {
                adminToolStripMenuItem.Enabled = false;
                quảnLýToolStripMenuItem.Enabled = false;
                chếĐộToolStripMenuItem.Enabled = false;
                chứcNăngToolStripMenuItem.Enabled = false;
            }
            lblTenTk.Text = "Chào mừng, " + LuuTkDN.TenDangNhapHienTai + "!";
        }

        public frmTrangChu()
        {
        }

        private void LoadFormIntoPanel(Form form)
        {
            // Xóa các control cũ trong panel
            panelContent.Controls.Clear();

            // Đặt TopLevel = false để form con không là form chính
            form.TopLevel = false;

            // Ẩn viền và tiêu đề của form con
            form.FormBorderStyle = FormBorderStyle.None;

            // Đặt DockStyle.Fill để form lấp đầy panel
            form.Dock = DockStyle.Fill;

            // Thêm form vào panel
            panelContent.Controls.Add(form);

            // Hiển thị form
            form.Show();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongBan phongBan = new frmPhongBan();
            LoadFormIntoPanel(phongBan);
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangKy k = new frmDangKy();
            LoadFormIntoPanel(k);
        }

        private void thayĐổiThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tenDN = LuuTkDN.TenDangNhapHienTai;

            frmDoiMK k = new frmDoiMK(tenDN);
            LoadFormIntoPanel(k);
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            LoadFormIntoPanel(nv);
        }

        private void danhSáchThaiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThaiSan nv = new frmThaiSan();
            LoadFormIntoPanel(nv);
        }

        private void lươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLuongCB nv = new frmLuongCB();
            LoadFormIntoPanel(nv);
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDong nv = new frmHopDong();
            LoadFormIntoPanel(nv);
        }

        private void danhSáchKỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKyLuat nv = new frmKyLuat();
            LoadFormIntoPanel(nv);
        }

        private void danhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoHiem nv = new frmBaoHiem();
            LoadFormIntoPanel(nv);
        }

        private void tínhLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBoPhan nv = new frmBoPhan();
            LoadFormIntoPanel(nv);
        }

        private void danhSáchKhenThưởngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSKhenThuong nv = new frmDSKhenThuong();
            LoadFormIntoPanel(nv);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhapMoi = new frmDangNhap();
            frmDangNhapMoi.Show();

            this.Close();
        }

        private void chấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChamCong f = new frmChamCong();
            f.Show();
            LoadFormIntoPanel(f);
        }

        private void tínhLươngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTinhLuong f = new frmTinhLuong();
            f.Show();
            LoadFormIntoPanel(f);
        }

        private void dSKỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting reporting = new Reporting();
            reporting.ShowReport("KyLuat");
            reporting.ShowDialog();
            

        }

        private void dSThaiSanrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting reporting = new Reporting();
            reporting.ShowReport("ThaiSan");
            reporting.ShowDialog();
            
        }

        private void dSChấmCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting reporting = new Reporting();
            reporting.ShowReport("ChamCong");
            reporting.ShowDialog();

        }

      

        private void dSKhenThưởngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting reporting = new Reporting();
            frmDSKhenThuong f  =new frmDSKhenThuong();
            
            reporting.ShowReport("KhenThuong");
            reporting.ShowDialog();
        }
    }
}
