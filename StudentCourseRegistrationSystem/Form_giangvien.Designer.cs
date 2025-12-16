namespace StudentCourseRegistrationSystem
{
    partial class Form_giangvien
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnQLMonHoc = new System.Windows.Forms.Button();
            this.btnQLSinhVien = new System.Windows.Forms.Button();
            this.btnQLLopHP = new System.Windows.Forms.Button();
            this.btnXemBC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "GIẢNG VIÊN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnQLMonHoc
            // 
            this.btnQLMonHoc.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLMonHoc.Location = new System.Drawing.Point(195, 86);
            this.btnQLMonHoc.Name = "btnQLMonHoc";
            this.btnQLMonHoc.Size = new System.Drawing.Size(172, 32);
            this.btnQLMonHoc.TabIndex = 1;
            this.btnQLMonHoc.Text = "Quản lí môn học";
            this.btnQLMonHoc.UseVisualStyleBackColor = true;
            this.btnQLMonHoc.Click += new System.EventHandler(this.btnQLMonHoc_Click);
            // 
            // btnQLSinhVien
            // 
            this.btnQLSinhVien.Location = new System.Drawing.Point(195, 133);
            this.btnQLSinhVien.Name = "btnQLSinhVien";
            this.btnQLSinhVien.Size = new System.Drawing.Size(172, 31);
            this.btnQLSinhVien.TabIndex = 2;
            this.btnQLSinhVien.Text = "Quản lí sinh viên";
            this.btnQLSinhVien.UseVisualStyleBackColor = true;
            // 
            // btnQLLopHP
            // 
            this.btnQLLopHP.Location = new System.Drawing.Point(452, 86);
            this.btnQLLopHP.Name = "btnQLLopHP";
            this.btnQLLopHP.Size = new System.Drawing.Size(173, 32);
            this.btnQLLopHP.TabIndex = 3;
            this.btnQLLopHP.Text = "Quản lí lớp học phần";
            this.btnQLLopHP.UseVisualStyleBackColor = true;
            // 
            // btnXemBC
            // 
            this.btnXemBC.Location = new System.Drawing.Point(452, 133);
            this.btnXemBC.Name = "btnXemBC";
            this.btnXemBC.Size = new System.Drawing.Size(173, 31);
            this.btnXemBC.TabIndex = 4;
            this.btnXemBC.Text = "Xem báo cáo đăng ký";
            this.btnXemBC.UseVisualStyleBackColor = true;
            // 
            // Form_giangvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.btnXemBC);
            this.Controls.Add(this.btnQLLopHP);
            this.Controls.Add(this.btnQLSinhVien);
            this.Controls.Add(this.btnQLMonHoc);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_giangvien";
            this.Text = "Form_giangvien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQLMonHoc;
        private System.Windows.Forms.Button btnQLSinhVien;
        private System.Windows.Forms.Button btnQLLopHP;
        private System.Windows.Forms.Button btnXemBC;
    }
}