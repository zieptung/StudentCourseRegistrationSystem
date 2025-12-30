namespace StudentCourseRegistrationSystem
{
    partial class FormSV
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
            this.avatar = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDangxuat = new System.Windows.Forms.Button();
            this.txtSV = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btntkb = new System.Windows.Forms.Button();
            this.btnDsdk = new System.Windows.Forms.Button();
            this.btnDkhp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvhocphan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhocphan)).BeginInit();
            this.SuspendLayout();
            // 
            // avatar
            // 
            this.avatar.Location = new System.Drawing.Point(9, 29);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(70, 64);
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            this.avatar.Click += new System.EventHandler(this.avatar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.groupBox1.Controls.Add(this.btnDangxuat);
            this.groupBox1.Controls.Add(this.txtSV);
            this.groupBox1.Controls.Add(this.avatar);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 106);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // btnDangxuat
            // 
            this.btnDangxuat.BackColor = System.Drawing.Color.LightGray;
            this.btnDangxuat.ForeColor = System.Drawing.Color.Black;
            this.btnDangxuat.Location = new System.Drawing.Point(809, 33);
            this.btnDangxuat.Name = "btnDangxuat";
            this.btnDangxuat.Size = new System.Drawing.Size(135, 53);
            this.btnDangxuat.TabIndex = 7;
            this.btnDangxuat.Text = "Đăng xuất";
            this.btnDangxuat.UseVisualStyleBackColor = false;
            this.btnDangxuat.Click += new System.EventHandler(this.btnDangxuat_Click_1);
            // 
            // txtSV
            // 
            this.txtSV.Location = new System.Drawing.Point(101, 43);
            this.txtSV.Name = "txtSV";
            this.txtSV.Size = new System.Drawing.Size(186, 34);
            this.txtSV.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkCyan;
            this.groupBox2.Controls.Add(this.btntkb);
            this.groupBox2.Controls.Add(this.btnDsdk);
            this.groupBox2.Controls.Add(this.btnDkhp);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 442);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btntkb
            // 
            this.btntkb.BackColor = System.Drawing.Color.LightBlue;
            this.btntkb.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntkb.ForeColor = System.Drawing.Color.Black;
            this.btntkb.Location = new System.Drawing.Point(0, 143);
            this.btntkb.Name = "btntkb";
            this.btntkb.Size = new System.Drawing.Size(271, 47);
            this.btntkb.TabIndex = 6;
            this.btntkb.Text = "Thời khoá biểu";
            this.btntkb.UseVisualStyleBackColor = false;
            this.btntkb.Click += new System.EventHandler(this.btntkb_Click);
            // 
            // btnDsdk
            // 
            this.btnDsdk.BackColor = System.Drawing.Color.LightBlue;
            this.btnDsdk.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDsdk.ForeColor = System.Drawing.Color.Black;
            this.btnDsdk.Location = new System.Drawing.Point(0, 90);
            this.btnDsdk.Name = "btnDsdk";
            this.btnDsdk.Size = new System.Drawing.Size(271, 47);
            this.btnDsdk.TabIndex = 5;
            this.btnDsdk.Text = "Danh sách đăng ký";
            this.btnDsdk.UseVisualStyleBackColor = false;
            this.btnDsdk.Click += new System.EventHandler(this.btnDsdk_Click);
            // 
            // btnDkhp
            // 
            this.btnDkhp.BackColor = System.Drawing.Color.LightBlue;
            this.btnDkhp.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDkhp.ForeColor = System.Drawing.Color.Black;
            this.btnDkhp.Location = new System.Drawing.Point(0, 37);
            this.btnDkhp.Name = "btnDkhp";
            this.btnDkhp.Size = new System.Drawing.Size(271, 47);
            this.btnDkhp.TabIndex = 4;
            this.btnDkhp.Text = "Đăng ký học phần";
            this.btnDkhp.UseVisualStyleBackColor = false;
            this.btnDkhp.Click += new System.EventHandler(this.btnDkhp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkCyan;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(280, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(685, 84);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(190, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách các học phần";
            // 
            // dgvhocphan
            // 
            this.dgvhocphan.BackgroundColor = System.Drawing.Color.White;
            this.dgvhocphan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhocphan.Location = new System.Drawing.Point(280, 206);
            this.dgvhocphan.Name = "dgvhocphan";
            this.dgvhocphan.RowHeadersVisible = false;
            this.dgvhocphan.RowHeadersWidth = 51;
            this.dgvhocphan.RowTemplate.Height = 24;
            this.dgvhocphan.Size = new System.Drawing.Size(685, 352);
            this.dgvhocphan.TabIndex = 7;
            this.dgvhocphan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvhocphan_CellContentClick);
            // 
            // FormSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(974, 561);
            this.Controls.Add(this.dgvhocphan);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSV";
            this.Text = "FormQLmonhoc";
            this.Load += new System.EventHandler(this.FormSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhocphan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSV;
        private System.Windows.Forms.Button btnDangxuat;
        private System.Windows.Forms.Button btnDsdk;
        private System.Windows.Forms.Button btnDkhp;
        private System.Windows.Forms.Button btntkb;
        private System.Windows.Forms.DataGridView dgvhocphan;
    }
}