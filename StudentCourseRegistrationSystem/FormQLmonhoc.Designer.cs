namespace StudentCourseRegistrationSystem
{
    partial class FormQLmonhoc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.đăngKýTínChỉToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngKýMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng ký môn học";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 49);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(-1, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 501);
            this.panel2.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngKýTínChỉToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(184, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // đăngKýTínChỉToolStripMenuItem
            // 
            this.đăngKýTínChỉToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngKýMônHọcToolStripMenuItem,
            this.danhSáchMônHọcToolStripMenuItem});
            this.đăngKýTínChỉToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.đăngKýTínChỉToolStripMenuItem.Name = "đăngKýTínChỉToolStripMenuItem";
            this.đăngKýTínChỉToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.đăngKýTínChỉToolStripMenuItem.Text = "Đăng ký tín chỉ";
            // 
            // đăngKýMônHọcToolStripMenuItem
            // 
            this.đăngKýMônHọcToolStripMenuItem.Name = "đăngKýMônHọcToolStripMenuItem";
            this.đăngKýMônHọcToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đăngKýMônHọcToolStripMenuItem.Text = "Đăng ký môn học ";
            // 
            // danhSáchMônHọcToolStripMenuItem
            // 
            this.danhSáchMônHọcToolStripMenuItem.Name = "danhSáchMônHọcToolStripMenuItem";
            this.danhSáchMônHọcToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.danhSáchMônHọcToolStripMenuItem.Text = "Danh sách môn học ";
            // 
            // FormQLmonhoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 570);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormQLmonhoc";
            this.Text = "FormQLmonhoc";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem đăngKýTínChỉToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngKýMônHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchMônHọcToolStripMenuItem;
    }
}