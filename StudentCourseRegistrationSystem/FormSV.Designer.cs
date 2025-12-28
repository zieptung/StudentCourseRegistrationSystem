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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltensv = new System.Windows.Forms.Label();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.đăngKýTínChỉToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngKýMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchMônĐãĐăngKýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnthongtin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lbltensv);
            this.panel1.Controls.Add(this.avatar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 49);
            this.panel1.TabIndex = 2;
            // 
            // lbltensv
            // 
            this.lbltensv.AutoSize = true;
            this.lbltensv.Location = new System.Drawing.Point(799, 9);
            this.lbltensv.Name = "lbltensv";
            this.lbltensv.Size = new System.Drawing.Size(112, 20);
            this.lbltensv.TabIndex = 1;
            this.lbltensv.Text = "Tên sinh viên";
            this.lbltensv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // avatar
            // 
            this.avatar.Location = new System.Drawing.Point(917, 3);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(49, 42);
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnthongtin);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 521);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(187, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(790, 469);
            this.panel3.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngKýTínChỉToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(188, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // đăngKýTínChỉToolStripMenuItem
            // 
            this.đăngKýTínChỉToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngKýMônHọcToolStripMenuItem,
            this.danhSáchMônHọcToolStripMenuItem,
            this.danhSáchMônĐãĐăngKýToolStripMenuItem});
            this.đăngKýTínChỉToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.đăngKýTínChỉToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.đăngKýTínChỉToolStripMenuItem.Name = "đăngKýTínChỉToolStripMenuItem";
            this.đăngKýTínChỉToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.đăngKýTínChỉToolStripMenuItem.Text = "Đăng ký tín chỉ";
            // 
            // đăngKýMônHọcToolStripMenuItem
            // 
            this.đăngKýMônHọcToolStripMenuItem.Name = "đăngKýMônHọcToolStripMenuItem";
            this.đăngKýMônHọcToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.đăngKýMônHọcToolStripMenuItem.Text = "Đăng ký môn học ";
            this.đăngKýMônHọcToolStripMenuItem.Click += new System.EventHandler(this.đăngKýMônHọcToolStripMenuItem_Click);
            // 
            // danhSáchMônHọcToolStripMenuItem
            // 
            this.danhSáchMônHọcToolStripMenuItem.Name = "danhSáchMônHọcToolStripMenuItem";
            this.danhSáchMônHọcToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.danhSáchMônHọcToolStripMenuItem.Text = "Danh sách môn học ";
            this.danhSáchMônHọcToolStripMenuItem.Click += new System.EventHandler(this.danhSáchMônHọcToolStripMenuItem_Click);
            // 
            // danhSáchMônĐãĐăngKýToolStripMenuItem
            // 
            this.danhSáchMônĐãĐăngKýToolStripMenuItem.Name = "danhSáchMônĐãĐăngKýToolStripMenuItem";
            this.danhSáchMônĐãĐăngKýToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.danhSáchMônĐãĐăngKýToolStripMenuItem.Text = "Danh sách môn đã đăng ký";
            this.danhSáchMônĐãĐăngKýToolStripMenuItem.Click += new System.EventHandler(this.danhSáchMônĐãĐăngKýToolStripMenuItem_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMain.Location = new System.Drawing.Point(188, 49);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(789, 521);
            this.panelMain.TabIndex = 4;
            // 
            // btnthongtin
            // 
            this.btnthongtin.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthongtin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnthongtin.Location = new System.Drawing.Point(-11, 31);
            this.btnthongtin.Name = "btnthongtin";
            this.btnthongtin.Size = new System.Drawing.Size(199, 29);
            this.btnthongtin.TabIndex = 5;
            this.btnthongtin.Text = "Thông tin sinh viên";
            this.btnthongtin.UseVisualStyleBackColor = true;
            this.btnthongtin.Click += new System.EventHandler(this.btnthongtin_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(-3, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Lịch học";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 570);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSV";
            this.Text = "FormQLmonhoc";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem đăngKýTínChỉToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngKýMônHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchMônHọcToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Label lbltensv;
        private System.Windows.Forms.ToolStripMenuItem danhSáchMônĐãĐăngKýToolStripMenuItem;
        private System.Windows.Forms.Button btnthongtin;
        private System.Windows.Forms.Button button1;
    }
}