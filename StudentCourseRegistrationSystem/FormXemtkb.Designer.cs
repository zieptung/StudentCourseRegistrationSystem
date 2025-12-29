namespace StudentCourseRegistrationSystem
{
    partial class FormXemtkb
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
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvTKB = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).BeginInit();
            this.SuspendLayout();
            // 
            // cboHocKy
            // 
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(268, 86);
            this.cboHocKy.Margin = new System.Windows.Forms.Padding(2);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(171, 24);
            this.cboHocKy.TabIndex = 0;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.Lime;
            this.btnXem.Location = new System.Drawing.Point(485, 83);
            this.btnXem.Margin = new System.Windows.Forms.Padding(2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(82, 36);
            this.btnXem.TabIndex = 1;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvTKB
            // 
            this.dgvTKB.BackgroundColor = System.Drawing.Color.White;
            this.dgvTKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKB.GridColor = System.Drawing.Color.Black;
            this.dgvTKB.Location = new System.Drawing.Point(11, 138);
            this.dgvTKB.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTKB.MultiSelect = false;
            this.dgvTKB.Name = "dgvTKB";
            this.dgvTKB.RowHeadersVisible = false;
            this.dgvTKB.RowHeadersWidth = 82;
            this.dgvTKB.RowTemplate.Height = 33;
            this.dgvTKB.Size = new System.Drawing.Size(774, 265);
            this.dgvTKB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn học kỳ";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(774, 57);
            this.label2.TabIndex = 3;
            this.label2.Text = "THỜI KHÓA BIỂU";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormXemtkb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(796, 414);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTKB);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cboHocKy);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormXemtkb";
            this.Text = "FormXemtkb";
            this.Load += new System.EventHandler(this.FormXemtkb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvTKB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}