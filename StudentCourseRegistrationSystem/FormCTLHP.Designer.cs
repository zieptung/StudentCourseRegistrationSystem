namespace StudentCourseRegistrationSystem
{
    partial class FormCTLHP
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSoLuongSV = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaSinhVien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvChiTietLHP = new System.Windows.Forms.DataGridView();
            this.ma_sv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ho_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioi_tinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay_sinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay_dang_ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trang_thai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietLHP)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightCyan;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1294, 61);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chi Tiết Lớp Học Phần";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 22);
            this.label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox1.Controls.Add(this.lblSoLuongSV);
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtKhoa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaSinhVien);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(3, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1294, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // lblSoLuongSV
            // 
            this.lblSoLuongSV.AutoSize = true;
            this.lblSoLuongSV.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSoLuongSV.Location = new System.Drawing.Point(22, 105);
            this.lblSoLuongSV.Name = "lblSoLuongSV";
            this.lblSoLuongSV.Size = new System.Drawing.Size(218, 22);
            this.lblSoLuongSV.TabIndex = 12;
            this.lblSoLuongSV.Text = "Số sinh viên đã đăng ký: 0";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.PaleGreen;
            this.btnLamMoi.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnLamMoi.Location = new System.Drawing.Point(1092, 83);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(132, 39);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.PaleGreen;
            this.btnTimKiem.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnTimKiem.Location = new System.Drawing.Point(1088, 28);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(136, 39);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtHoTen.Location = new System.Drawing.Point(263, 56);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(168, 28);
            this.txtHoTen.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(261, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Họ Tên";
            // 
            // txtKhoa
            // 
            this.txtKhoa.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhoa.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtKhoa.Location = new System.Drawing.Point(510, 56);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.Size = new System.Drawing.Size(168, 28);
            this.txtKhoa.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(508, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Khoa";
            // 
            // txtLop
            // 
            this.txtLop.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLop.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLop.Location = new System.Drawing.Point(755, 56);
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(168, 28);
            this.txtLop.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(753, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lớp";
            // 
            // txtMaSinhVien
            // 
            this.txtMaSinhVien.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSinhVien.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtMaSinhVien.Location = new System.Drawing.Point(21, 56);
            this.txtMaSinhVien.Name = "txtMaSinhVien";
            this.txtMaSinhVien.Size = new System.Drawing.Size(168, 28);
            this.txtMaSinhVien.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(19, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Sinh Viên";
            // 
            // dgvChiTietLHP
            // 
            this.dgvChiTietLHP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietLHP.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dgvChiTietLHP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietLHP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma_sv,
            this.ho_ten,
            this.gioi_tinh,
            this.ngay_sinh,
            this.lop,
            this.khoa,
            this.ngay_dang_ky,
            this.trang_thai});
            this.dgvChiTietLHP.Location = new System.Drawing.Point(3, 215);
            this.dgvChiTietLHP.Name = "dgvChiTietLHP";
            this.dgvChiTietLHP.RowHeadersVisible = false;
            this.dgvChiTietLHP.RowHeadersWidth = 51;
            this.dgvChiTietLHP.RowTemplate.Height = 24;
            this.dgvChiTietLHP.Size = new System.Drawing.Size(1294, 421);
            this.dgvChiTietLHP.TabIndex = 2;
            // 
            // ma_sv
            // 
            this.ma_sv.DataPropertyName = "ma_sv";
            this.ma_sv.HeaderText = "Mã Sinh Viên";
            this.ma_sv.MinimumWidth = 6;
            this.ma_sv.Name = "ma_sv";
            // 
            // ho_ten
            // 
            this.ho_ten.DataPropertyName = "ho_ten";
            this.ho_ten.HeaderText = "Họ Tên";
            this.ho_ten.MinimumWidth = 6;
            this.ho_ten.Name = "ho_ten";
            // 
            // gioi_tinh
            // 
            this.gioi_tinh.DataPropertyName = "gioi_tinh";
            this.gioi_tinh.HeaderText = "Giới Tính";
            this.gioi_tinh.MinimumWidth = 6;
            this.gioi_tinh.Name = "gioi_tinh";
            // 
            // ngay_sinh
            // 
            this.ngay_sinh.DataPropertyName = "ngay_sinh";
            this.ngay_sinh.HeaderText = "Ngày Sinh";
            this.ngay_sinh.MinimumWidth = 6;
            this.ngay_sinh.Name = "ngay_sinh";
            // 
            // lop
            // 
            this.lop.DataPropertyName = "lop";
            this.lop.HeaderText = "Lớp";
            this.lop.MinimumWidth = 6;
            this.lop.Name = "lop";
            // 
            // khoa
            // 
            this.khoa.DataPropertyName = "khoa";
            this.khoa.HeaderText = "Khoa";
            this.khoa.MinimumWidth = 6;
            this.khoa.Name = "khoa";
            // 
            // ngay_dang_ky
            // 
            this.ngay_dang_ky.DataPropertyName = "ngay_dang_ky";
            this.ngay_dang_ky.HeaderText = "Ngày Đăng Ký";
            this.ngay_dang_ky.MinimumWidth = 6;
            this.ngay_dang_ky.Name = "ngay_dang_ky";
            // 
            // trang_thai
            // 
            this.trang_thai.DataPropertyName = "trang_thai";
            this.trang_thai.HeaderText = "Trạng Thái";
            this.trang_thai.MinimumWidth = 6;
            this.trang_thai.Name = "trang_thai";
            // 
            // FormCTLHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1299, 636);
            this.Controls.Add(this.dgvChiTietLHP);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Name = "FormCTLHP";
            this.Text = "FormCTDK";
            this.Load += new System.EventHandler(this.FormCTLHP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietLHP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaSinhVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvChiTietLHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma_sv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ho_ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioi_tinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay_sinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn khoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay_dang_ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn trang_thai;
        private System.Windows.Forms.Label lblSoLuongSV;
    }
}