using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QuanLyNhanSu
{
    public partial class Reporting : Form
    {

        string maBP;
        public Reporting()
        {
            InitializeComponent();
            
        }

        string reportType;

        public string ReportType { get => reportType; set => reportType = value; }
        public string MaBP { get => maBP; set => maBP = value; }

        public void ShowReport(string reportType)
        {
            switch (reportType)
            {
                case "KyLuat":
                    ReportKyLuat reportKyLuat = new ReportKyLuat();
                    crystalReportViewer1.ReportSource = reportKyLuat;
                    reportKyLuat.SetDatabaseLogon("sa", "123", "A208PC30", "QLSINHVIEN");
                    break;

                case "ThaiSan":
                    ReportThaiSan reportThaiSan = new ReportThaiSan();
                    crystalReportViewer1.ReportSource = reportThaiSan;
                    reportThaiSan.SetDatabaseLogon("sa", "123", "A208PC30", "QLSINHVIEN");
                    break;
                case "ChamCong":
                    ReportChamCong ReportChamCong = new ReportChamCong();
                    crystalReportViewer1.ReportSource = ReportChamCong;
                    ReportChamCong.SetDatabaseLogon("sa", "123", "A208PC30", "QLSINHVIEN");
                    break;
                case "KhenThuong":
                    ReportKhenThuong reportKhenThuong = new ReportKhenThuong();                             
                    reportKhenThuong.SetDatabaseLogon("sa", "123", "A208PC30", "QLSINHVIEN");
                    crystalReportViewer1.ReportSource = reportKhenThuong;            
                    break;

                case "BoPhan":
                    ReportNVtheoMaBP report = new ReportNVtheoMaBP();
                    report.SetDatabaseLogon("sa", "123", "A208PC30", "QLSINHVIEN");
                    report.SetParameterValue("LocMaBP", MaBP);
                    crystalReportViewer1.ReportSource = report;
                    crystalReportViewer1.Refresh();

                    crystalReportViewer1.DisplayToolbar = false;
                    break;
            }

            crystalReportViewer1.Refresh();
            crystalReportViewer1.DisplayToolbar = false;
        }
        private void Reporting_Load(object sender, EventArgs e)
        {
            ShowReport(ReportType);
        }
        
    }
}
