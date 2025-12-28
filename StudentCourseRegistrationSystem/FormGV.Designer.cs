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
            this.btnXemttcn = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQLMonHoc
            // 
            this.btnQLMonHoc.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLMonHoc.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLMonHoc.Location = new System.Drawing.Point(6, 92);
            this.btnQLMonHoc.Name = "btnQLMonHoc";
            this.btnQLMonHoc.Size = new System.Drawing.Size(277, 130);
            this.btnQLMonHoc.TabIndex = 1;
            this.btnQLMonHoc.Text = "Quản lí môn học";
            this.btnQLMonHoc.UseVisualStyleBackColor = false;
            this.btnQLMonHoc.Click += new System.EventHandler(this.btnQLMonHoc_Click);
            // 
            // btnQLSinhVien
            // 
            this.btnQLSinhVien.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLSinhVien.Location = new System.Drawing.Point(304, 92);
            this.btnQLSinhVien.Name = "btnQLSinhVien";
            this.btnQLSinhVien.Size = new System.Drawing.Size(283, 130);
            this.btnQLSinhVien.TabIndex = 2;
            this.btnQLSinhVien.Text = "Quản lí sinh viên";
            this.btnQLSinhVien.UseVisualStyleBackColor = false;
            // 
            // btnQLLopHP
            // 
            this.btnQLLopHP.BackColor = System.Drawing.Color.LightBlue;
            this.btnQLLopHP.Location = new System.Drawing.Point(6, 282);
            this.btnQLLopHP.Name = "btnQLLopHP";
            this.btnQLLopHP.Size = new System.Drawing.Size(277, 130);
            this.btnQLLopHP.TabIndex = 3;
            this.btnQLLopHP.Text = "Quản lí lớp học phần";
            this.btnQLLopHP.UseVisualStyleBackColor = false;
            // 
            // btnXemBC
            // 
            this.btnXemBC.BackColor = System.Drawing.Color.LightBlue;
            this.btnXemBC.Location = new System.Drawing.Point(304, 282);
            this.btnXemBC.Name = "btnXemBC";
            this.btnXemBC.Size = new System.Drawing.Size(283, 130);
            this.btnXemBC.TabIndex = 4;
            this.btnXemBC.Text = "Xem báo cáo đăng ký";
            this.btnXemBC.UseVisualStyleBackColor = false;
            // 
            // btnXemttcn
            // 
            this.btnXemttcn.BackColor = System.Drawing.Color.LightBlue;
            this.btnXemttcn.Location = new System.Drawing.Point(640, 196);
            this.btnXemttcn.Name = "btnXemttcn";
            this.btnXemttcn.Size = new System.Drawing.Size(303, 111);
            this.btnXemttcn.TabIndex = 5;
            this.btnXemttcn.Text = "Xem thông tin cá nhân";
            this.btnXemttcn.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.LightGray;
            this.btnThoat.Location = new System.Drawing.Point(762, 378);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(181, 109);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Đăng xuất";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnQLMonHoc);
            this.groupBox1.Controls.Add(this.btnXemBC);
            this.groupBox1.Controls.Add(this.btnXemttcn);
            this.groupBox1.Controls.Add(this.btnQLLopHP);
            this.groupBox1.Controls.Add(this.btnQLSinhVien);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 513);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giảng viên";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // FormGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(982, 518);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGV";
            this.Text = "FormGV";
            this.Load += new System.EventHandler(this.FormGV_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnQLMonHoc;
        private System.Windows.Forms.Button btnQLSinhVien;
        private System.Windows.Forms.Button btnQLLopHP;
        private System.Windows.Forms.Button btnXemBC;
        private System.Windows.Forms.Button btnXemttcn;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}