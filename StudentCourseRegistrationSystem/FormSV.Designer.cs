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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSV = new System.Windows.Forms.Label();
            this.btnDX = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDSTCDK = new System.Windows.Forms.Button();
            this.btnDKTC = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox1.Controls.Add(this.lblSV);
            this.groupBox1.Controls.Add(this.btnDX);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1538, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chào mừng sinh viên";
            // 
            // lblSV
            // 
            this.lblSV.AutoSize = true;
            this.lblSV.Location = new System.Drawing.Point(79, 43);
            this.lblSV.Name = "lblSV";
            this.lblSV.Size = new System.Drawing.Size(0, 33);
            this.lblSV.TabIndex = 12;
            // 
            // btnDX
            // 
            this.btnDX.BackColor = System.Drawing.Color.LightCoral;
            this.btnDX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDX.ForeColor = System.Drawing.Color.LightCyan;
            this.btnDX.Location = new System.Drawing.Point(1308, 34);
            this.btnDX.Name = "btnDX";
            this.btnDX.Size = new System.Drawing.Size(214, 46);
            this.btnDX.TabIndex = 11;
            this.btnDX.Text = "Đăng xuất";
            this.btnDX.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox2.Controls.Add(this.btnDSTCDK);
            this.groupBox2.Controls.Add(this.btnDKTC);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 520);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnDSTCDK
            // 
            this.btnDSTCDK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSTCDK.Location = new System.Drawing.Point(0, 65);
            this.btnDSTCDK.Name = "btnDSTCDK";
            this.btnDSTCDK.Size = new System.Drawing.Size(214, 46);
            this.btnDSTCDK.TabIndex = 10;
            this.btnDSTCDK.Text = "DS tín chỉ đăng ký";
            this.btnDSTCDK.UseVisualStyleBackColor = true;
            this.btnDSTCDK.Click += new System.EventHandler(this.btnDSTCDK_Click);
            // 
            // btnDKTC
            // 
            this.btnDKTC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDKTC.Location = new System.Drawing.Point(0, 13);
            this.btnDKTC.Name = "btnDKTC";
            this.btnDKTC.Size = new System.Drawing.Size(214, 46);
            this.btnDKTC.TabIndex = 9;
            this.btnDKTC.Text = "Đăng ký tín chỉ";
            this.btnDKTC.UseVisualStyleBackColor = true;
            this.btnDKTC.Click += new System.EventHandler(this.btnDKTC_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.LightCyan;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(232, 118);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1318, 520);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // FormSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1562, 650);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSV";
            this.Text = "FormSV";
            this.Load += new System.EventHandler(this.FormSV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnDKTC;
        private System.Windows.Forms.Button btnDSTCDK;
        private System.Windows.Forms.Button btnDX;
        private System.Windows.Forms.Label lblSV;
    }
}