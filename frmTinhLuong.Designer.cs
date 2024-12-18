namespace Nhom8_QuanLyNhanSu
{
    partial class frmTinhLuong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.cboLuongCB = new System.Windows.Forms.ComboBox();
            this.txtTienThuong = new System.Windows.Forms.TextBox();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.txtTienBaoHiem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSoNgayCong = new System.Windows.Forms.TextBox();
            this.btnTinh = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTongLuong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.matongluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soNgayCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienthuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienphat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienbaohiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tungay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(305, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bảng tính lương nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lương cơ bản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tiền thưởng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tiền phạt";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tiền bảo hiểm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(425, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Từ ngày";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Đến ngày";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.Location = new System.Drawing.Point(515, 255);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(200, 22);
            this.dtTuNgay.TabIndex = 10;
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.Location = new System.Drawing.Point(515, 302);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(200, 22);
            this.dtDenNgay.TabIndex = 11;
            // 
            // cboMaNV
            // 
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(210, 103);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(121, 24);
            this.cboMaNV.TabIndex = 12;
            this.cboMaNV.SelectedIndexChanged += new System.EventHandler(this.cboMaNV_SelectedIndexChanged);
            // 
            // cboLuongCB
            // 
            this.cboLuongCB.FormattingEnabled = true;
            this.cboLuongCB.Location = new System.Drawing.Point(210, 154);
            this.cboLuongCB.Name = "cboLuongCB";
            this.cboLuongCB.Size = new System.Drawing.Size(121, 24);
            this.cboLuongCB.TabIndex = 13;
            // 
            // txtTienThuong
            // 
            this.txtTienThuong.Location = new System.Drawing.Point(540, 111);
            this.txtTienThuong.Name = "txtTienThuong";
            this.txtTienThuong.Size = new System.Drawing.Size(117, 22);
            this.txtTienThuong.TabIndex = 14;
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Location = new System.Drawing.Point(540, 154);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.Size = new System.Drawing.Size(117, 22);
            this.txtTienPhat.TabIndex = 15;
            // 
            // txtTienBaoHiem
            // 
            this.txtTienBaoHiem.Location = new System.Drawing.Point(540, 205);
            this.txtTienBaoHiem.Name = "txtTienBaoHiem";
            this.txtTienBaoHiem.Size = new System.Drawing.Size(117, 22);
            this.txtTienBaoHiem.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(98, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Số ngày công";
            // 
            // txtSoNgayCong
            // 
            this.txtSoNgayCong.Location = new System.Drawing.Point(210, 218);
            this.txtSoNgayCong.Name = "txtSoNgayCong";
            this.txtSoNgayCong.Size = new System.Drawing.Size(121, 22);
            this.txtSoNgayCong.TabIndex = 18;
            // 
            // btnTinh
            // 
            this.btnTinh.BorderRadius = 15;
            this.btnTinh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTinh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTinh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTinh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTinh.ForeColor = System.Drawing.Color.White;
            this.btnTinh.Location = new System.Drawing.Point(726, 162);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(135, 45);
            this.btnTinh.TabIndex = 21;
            this.btnTinh.Text = "Tính Lương";
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // dgvTongLuong
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTongLuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTongLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTongLuong.ColumnHeadersHeight = 40;
            this.dgvTongLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTongLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matongluong,
            this.manv,
            this.soNgayCong,
            this.tienthuong,
            this.tienphat,
            this.tienbaohiem,
            this.tungay,
            this.denngay,
            this.tongluong});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTongLuong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTongLuong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTongLuong.Location = new System.Drawing.Point(101, 330);
            this.dgvTongLuong.Name = "dgvTongLuong";
            this.dgvTongLuong.RowHeadersVisible = false;
            this.dgvTongLuong.RowHeadersWidth = 51;
            this.dgvTongLuong.RowTemplate.Height = 24;
            this.dgvTongLuong.Size = new System.Drawing.Size(848, 150);
            this.dgvTongLuong.TabIndex = 22;
            this.dgvTongLuong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTongLuong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTongLuong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTongLuong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTongLuong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTongLuong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTongLuong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTongLuong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTongLuong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTongLuong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTongLuong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTongLuong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTongLuong.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvTongLuong.ThemeStyle.ReadOnly = false;
            this.dgvTongLuong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTongLuong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTongLuong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTongLuong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTongLuong.ThemeStyle.RowsStyle.Height = 24;
            this.dgvTongLuong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTongLuong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // matongluong
            // 
            this.matongluong.DataPropertyName = "matongluong";
            this.matongluong.HeaderText = "Mã Tổng lương";
            this.matongluong.MinimumWidth = 6;
            this.matongluong.Name = "matongluong";
            // 
            // manv
            // 
            this.manv.DataPropertyName = "manv";
            this.manv.HeaderText = "Mã Nhân Viên";
            this.manv.MinimumWidth = 6;
            this.manv.Name = "manv";
            // 
            // soNgayCong
            // 
            this.soNgayCong.DataPropertyName = "songaycong";
            this.soNgayCong.HeaderText = "Số Ngày Công";
            this.soNgayCong.MinimumWidth = 6;
            this.soNgayCong.Name = "soNgayCong";
            // 
            // tienthuong
            // 
            this.tienthuong.DataPropertyName = "tongtienthuong";
            this.tienthuong.HeaderText = "Tiền Thưởng";
            this.tienthuong.MinimumWidth = 6;
            this.tienthuong.Name = "tienthuong";
            // 
            // tienphat
            // 
            this.tienphat.DataPropertyName = "tongtienphat";
            this.tienphat.HeaderText = "Tiền Phạt";
            this.tienphat.MinimumWidth = 6;
            this.tienphat.Name = "tienphat";
            // 
            // tienbaohiem
            // 
            this.tienbaohiem.DataPropertyName = "tongphibh";
            this.tienbaohiem.HeaderText = "Tiền Bảo Hiểm";
            this.tienbaohiem.MinimumWidth = 6;
            this.tienbaohiem.Name = "tienbaohiem";
            // 
            // tungay
            // 
            this.tungay.DataPropertyName = "tungay";
            this.tungay.HeaderText = "Từ Ngày";
            this.tungay.MinimumWidth = 6;
            this.tungay.Name = "tungay";
            // 
            // denngay
            // 
            this.denngay.DataPropertyName = "denngay";
            this.denngay.HeaderText = "Đến Ngày";
            this.denngay.MinimumWidth = 6;
            this.denngay.Name = "denngay";
            // 
            // tongluong
            // 
            this.tongluong.DataPropertyName = "tongluong";
            this.tongluong.HeaderText = "Tổng Lương";
            this.tongluong.MinimumWidth = 6;
            this.tongluong.Name = "tongluong";
            // 
            // frmTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(1016, 514);
            this.Controls.Add(this.dgvTongLuong);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.txtSoNgayCong);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTienBaoHiem);
            this.Controls.Add(this.txtTienPhat);
            this.Controls.Add(this.txtTienThuong);
            this.Controls.Add(this.cboLuongCB);
            this.Controls.Add(this.cboMaNV);
            this.Controls.Add(this.dtDenNgay);
            this.Controls.Add(this.dtTuNgay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTinhLuong";
            this.Text = "frmTinhLuong";
            this.Load += new System.EventHandler(this.frmTinhLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.ComboBox cboLuongCB;
        private System.Windows.Forms.TextBox txtTienThuong;
        private System.Windows.Forms.TextBox txtTienPhat;
        private System.Windows.Forms.TextBox txtTienBaoHiem;
        private System.Windows.Forms.TextBox txtSoNgayCong;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Button btnTinh;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTongLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn matongluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn manv;
        private System.Windows.Forms.DataGridViewTextBoxColumn soNgayCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienthuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienphat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienbaohiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tungay;
        private System.Windows.Forms.DataGridViewTextBoxColumn denngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongluong;
    }
}