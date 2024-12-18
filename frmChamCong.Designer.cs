namespace Nhom8_QuanLyNhanSu
{
    partial class frmChamCong
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giovao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaycham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.macc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Giora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChamCong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dtGioLamViec = new System.Windows.Forms.DateTimePicker();
            this.btnVaoLam = new System.Windows.Forms.Button();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.guna2ColorTransition2 = new Guna.UI2.WinForms.Guna2ColorTransition(this.components);
            this.guna2ColorTransition1 = new Guna.UI2.WinForms.Guna2ColorTransition(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnRaVe = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).BeginInit();
            this.SuspendLayout();
            // 
            // statusout
            // 
            this.statusout.DataPropertyName = "statusout";
            this.statusout.HeaderText = "Status Out";
            this.statusout.MinimumWidth = 6;
            this.statusout.Name = "statusout";
            // 
            // statusin
            // 
            this.statusin.DataPropertyName = "statusin";
            this.statusin.HeaderText = "Status In";
            this.statusin.MinimumWidth = 6;
            this.statusin.Name = "statusin";
            // 
            // giovao
            // 
            this.giovao.DataPropertyName = "giovao";
            this.giovao.HeaderText = "Giờ Vào";
            this.giovao.MinimumWidth = 6;
            this.giovao.Name = "giovao";
            // 
            // Ngaycham
            // 
            this.Ngaycham.DataPropertyName = "ngaycham";
            this.Ngaycham.HeaderText = "Ngày Chấm";
            this.Ngaycham.MinimumWidth = 6;
            this.Ngaycham.Name = "Ngaycham";
            // 
            // manv
            // 
            this.manv.DataPropertyName = "manv";
            this.manv.HeaderText = "Mã NV";
            this.manv.MinimumWidth = 6;
            this.manv.Name = "manv";
            // 
            // macc
            // 
            this.macc.DataPropertyName = "macc";
            this.macc.HeaderText = "Mã Chấm Công";
            this.macc.MinimumWidth = 6;
            this.macc.Name = "macc";
            // 
            // Giora
            // 
            this.Giora.DataPropertyName = "giora";
            this.Giora.HeaderText = "Giờ Ra";
            this.Giora.MinimumWidth = 6;
            this.Giora.Name = "Giora";
            // 
            // dgvChamCong
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChamCong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChamCong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChamCong.ColumnHeadersHeight = 50;
            this.dgvChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChamCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.macc,
            this.manv,
            this.Ngaycham,
            this.giovao,
            this.statusin,
            this.Giora,
            this.statusout});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChamCong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChamCong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChamCong.Location = new System.Drawing.Point(212, 280);
            this.dgvChamCong.Name = "dgvChamCong";
            this.dgvChamCong.RowHeadersVisible = false;
            this.dgvChamCong.RowHeadersWidth = 51;
            this.dgvChamCong.RowTemplate.Height = 24;
            this.dgvChamCong.Size = new System.Drawing.Size(565, 150);
            this.dgvChamCong.TabIndex = 33;
            this.dgvChamCong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChamCong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvChamCong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvChamCong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvChamCong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvChamCong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChamCong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChamCong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvChamCong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChamCong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChamCong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChamCong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChamCong.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvChamCong.ThemeStyle.ReadOnly = false;
            this.dgvChamCong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChamCong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChamCong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChamCong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChamCong.ThemeStyle.RowsStyle.Height = 24;
            this.dgvChamCong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChamCong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dtGioLamViec
            // 
            this.dtGioLamViec.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtGioLamViec.Location = new System.Drawing.Point(356, 159);
            this.dtGioLamViec.Name = "dtGioLamViec";
            this.dtGioLamViec.Size = new System.Drawing.Size(100, 22);
            this.dtGioLamViec.TabIndex = 32;
            // 
            // btnVaoLam
            // 
            this.btnVaoLam.Location = new System.Drawing.Point(212, 205);
            this.btnVaoLam.Name = "btnVaoLam";
            this.btnVaoLam.Size = new System.Drawing.Size(86, 23);
            this.btnVaoLam.TabIndex = 29;
            this.btnVaoLam.Text = "Vào làm";
            this.btnVaoLam.UseVisualStyleBackColor = true;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(356, 102);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 22);
            this.txtMaNV.TabIndex = 28;
            // 
            // guna2ColorTransition2
            // 
            this.guna2ColorTransition2.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Orange};
            // 
            // guna2ColorTransition1
            // 
            this.guna2ColorTransition1.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Orange};
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(507, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 24);
            this.label6.TabIndex = 31;
            this.label6.Text = "08:00 AM";
            // 
            // btnRaVe
            // 
            this.btnRaVe.Location = new System.Drawing.Point(356, 205);
            this.btnRaVe.Name = "btnRaVe";
            this.btnRaVe.Size = new System.Drawing.Size(86, 23);
            this.btnRaVe.TabIndex = 30;
            this.btnRaVe.Text = "Ra về";
            this.btnRaVe.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Giờ làm việc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mã nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(461, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "Chấm Công";
            // 
            // frmChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(986, 578);
            this.Controls.Add(this.dgvChamCong);
            this.Controls.Add(this.dtGioLamViec);
            this.Controls.Add(this.btnVaoLam);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRaVe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmChamCong";
            this.Text = "frmChamCong";
            this.Load += new System.EventHandler(this.frmChamCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn statusout;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusin;
        private System.Windows.Forms.DataGridViewTextBoxColumn giovao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaycham;
        private System.Windows.Forms.DataGridViewTextBoxColumn manv;
        private System.Windows.Forms.DataGridViewTextBoxColumn macc;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Giora;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChamCong;
        private System.Windows.Forms.DateTimePicker dtGioLamViec;
        private System.Windows.Forms.Button btnVaoLam;
        private System.Windows.Forms.TextBox txtMaNV;
        private Guna.UI2.WinForms.Guna2ColorTransition guna2ColorTransition2;
        private Guna.UI2.WinForms.Guna2ColorTransition guna2ColorTransition1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRaVe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}