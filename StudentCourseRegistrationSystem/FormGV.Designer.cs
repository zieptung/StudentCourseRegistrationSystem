namespace StudentCourseRegistrationSystem
{
    partial class FormGV
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
            this.btnQLMonHoc = new System.Windows.Forms.Button();
            this.btnQLSinhVien = new System.Windows.Forms.Button();
            this.btnQLLopHP = new System.Windows.Forms.Button();
            this.btnXemBC = new System.Windows.Forms.Button();
            this.btnDangxuat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvtkb = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtkb)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQLMonHoc
            // 
            this.btnQLMonHoc.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLMonHoc.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLMonHoc.ForeColor = System.Drawing.Color.Black;
            this.btnQLMonHoc.Location = new System.Drawing.Point(-1, 38);
            this.btnQLMonHoc.Name = "btnQLMonHoc";
            this.btnQLMonHoc.Size = new System.Drawing.Size(260, 47);
            this.btnQLMonHoc.TabIndex = 1;
            this.btnQLMonHoc.Text = "Quản lí môn học";
            this.btnQLMonHoc.UseVisualStyleBackColor = false;
            this.btnQLMonHoc.Click += new System.EventHandler(this.btnQLMonHoc_Click);
            // 
            // btnQLSinhVien
            // 
            this.btnQLSinhVien.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLSinhVien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLSinhVien.ForeColor = System.Drawing.Color.Black;
            this.btnQLSinhVien.Location = new System.Drawing.Point(-1, 91);
            this.btnQLSinhVien.Name = "btnQLSinhVien";
            this.btnQLSinhVien.Size = new System.Drawing.Size(260, 47);
            this.btnQLSinhVien.TabIndex = 2;
            this.btnQLSinhVien.Text = "Quản lí sinh viên";
            this.btnQLSinhVien.UseVisualStyleBackColor = false;
            // 
            // btnQLLopHP
            // 
            this.btnQLLopHP.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLLopHP.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLLopHP.ForeColor = System.Drawing.Color.Black;
            this.btnQLLopHP.Location = new System.Drawing.Point(-1, 197);
            this.btnQLLopHP.Name = "btnQLLopHP";
            this.btnQLLopHP.Size = new System.Drawing.Size(260, 47);
            this.btnQLLopHP.TabIndex = 3;
            this.btnQLLopHP.Text = "Quản lí lớp học phần";
            this.btnQLLopHP.UseVisualStyleBackColor = false;
            // 
            // btnXemBC
            // 
            this.btnXemBC.BackColor = System.Drawing.Color.LightBlue;
            this.btnXemBC.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemBC.ForeColor = System.Drawing.Color.Black;
            this.btnXemBC.Location = new System.Drawing.Point(-1, 144);
            this.btnXemBC.Name = "btnXemBC";
            this.btnXemBC.Size = new System.Drawing.Size(260, 47);
            this.btnXemBC.TabIndex = 4;
            this.btnXemBC.Text = "Xem báo cáo đăng ký";
            this.btnXemBC.UseVisualStyleBackColor = false;
            // 
            // btnDangxuat
            // 
            this.btnDangxuat.BackColor = System.Drawing.Color.LightGray;
            this.btnDangxuat.ForeColor = System.Drawing.Color.Black;
            this.btnDangxuat.Location = new System.Drawing.Point(812, 29);
            this.btnDangxuat.Name = "btnDangxuat";
            this.btnDangxuat.Size = new System.Drawing.Size(135, 53);
            this.btnDangxuat.TabIndex = 6;
            this.btnDangxuat.Text = "Đăng xuất";
            this.btnDangxuat.UseVisualStyleBackColor = false;
            this.btnDangxuat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.groupBox1.Controls.Add(this.btnDangxuat);
            this.groupBox1.Controls.Add(this.txtGV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 103);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin giảng viên";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtGV
            // 
            this.txtGV.Location = new System.Drawing.Point(144, 45);
            this.txtGV.Name = "txtGV";
            this.txtGV.Size = new System.Drawing.Size(186, 34);
            this.txtGV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giảng viên";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkCyan;
            this.groupBox2.Controls.Add(this.btnQLMonHoc);
            this.groupBox2.Controls.Add(this.btnQLSinhVien);
            this.groupBox2.Controls.Add(this.btnXemBC);
            this.groupBox2.Controls.Add(this.btnQLLopHP);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 401);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkCyan;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(268, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(697, 85);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(198, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thời khoá biểu giảng viên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvtkb
            // 
            this.dgvtkb.BackgroundColor = System.Drawing.Color.White;
            this.dgvtkb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtkb.GridColor = System.Drawing.Color.DarkGray;
            this.dgvtkb.Location = new System.Drawing.Point(268, 207);
            this.dgvtkb.Name = "dgvtkb";
            this.dgvtkb.RowHeadersWidth = 51;
            this.dgvtkb.RowTemplate.Height = 24;
            this.dgvtkb.Size = new System.Drawing.Size(697, 307);
            this.dgvtkb.TabIndex = 10;
            this.dgvtkb.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvtkb_CellContentClick);
            // 
            // FormGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(973, 518);
            this.Controls.Add(this.dgvtkb);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGV";
            this.Text = "FormGV";
            this.Load += new System.EventHandler(this.FormGV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtkb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnQLMonHoc;
        private System.Windows.Forms.Button btnQLSinhVien;
        private System.Windows.Forms.Button btnQLLopHP;
        private System.Windows.Forms.Button btnXemBC;
        private System.Windows.Forms.Button btnDangxuat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvtkb;
    }
}