namespace StudentCourseRegistrationSystem
{
    partial class Formdangky
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btndangky = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.txttenmon = new System.Windows.Forms.TextBox();
            this.txtmamon = new System.Windows.Forms.TextBox();
            this.DRVdangky = new System.Windows.Forms.DataGridView();
            this.dangKyHocPhanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTCDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTCDataSet = new StudentCourseRegistrationSystem.QLTCDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.monHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monHocTableAdapter = new StudentCourseRegistrationSystem.QLTCDataSetTableAdapters.MonHocTableAdapter();
            this.dangKyHocPhanTableAdapter = new StudentCourseRegistrationSystem.QLTCDataSetTableAdapters.DangKyHocPhanTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DRVdangky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dangKyHocPhanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTCDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTCDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monHocBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên môn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã môn";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btndangky
            // 
            this.btndangky.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangky.Location = new System.Drawing.Point(643, 171);
            this.btndangky.Name = "btndangky";
            this.btndangky.Size = new System.Drawing.Size(75, 37);
            this.btndangky.TabIndex = 7;
            this.btndangky.Text = "Đăng ký";
            this.btndangky.UseVisualStyleBackColor = true;
            this.btndangky.Click += new System.EventHandler(this.btndangky_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btntimkiem);
            this.groupBox1.Controls.Add(this.txttenmon);
            this.groupBox1.Controls.Add(this.txtmamon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 145);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông  tin môn học";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.Location = new System.Drawing.Point(465, 102);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(98, 37);
            this.btntimkiem.TabIndex = 12;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            // 
            // txttenmon
            // 
            this.txttenmon.Location = new System.Drawing.Point(393, 51);
            this.txttenmon.Name = "txttenmon";
            this.txttenmon.Size = new System.Drawing.Size(170, 27);
            this.txttenmon.TabIndex = 7;
            // 
            // txtmamon
            // 
            this.txtmamon.Location = new System.Drawing.Point(86, 51);
            this.txtmamon.Name = "txtmamon";
            this.txtmamon.Size = new System.Drawing.Size(170, 27);
            this.txtmamon.TabIndex = 6;
            // 
            // DRVdangky
            // 
            this.DRVdangky.AutoGenerateColumns = false;
            this.DRVdangky.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DRVdangky.DataSource = this.dangKyHocPhanBindingSource;
            this.DRVdangky.Location = new System.Drawing.Point(6, 214);
            this.DRVdangky.Name = "DRVdangky";
            this.DRVdangky.RowHeadersWidth = 51;
            this.DRVdangky.RowTemplate.Height = 24;
            this.DRVdangky.Size = new System.Drawing.Size(712, 224);
            this.DRVdangky.TabIndex = 9;
            // 
            // dangKyHocPhanBindingSource
            // 
            this.dangKyHocPhanBindingSource.DataMember = "DangKyHocPhan";
            this.dangKyHocPhanBindingSource.DataSource = this.qLTCDataSetBindingSource;
            // 
            // qLTCDataSetBindingSource
            // 
            this.qLTCDataSetBindingSource.DataSource = this.qLTCDataSet;
            this.qLTCDataSetBindingSource.Position = 0;
            // 
            // qLTCDataSet
            // 
            this.qLTCDataSet.DataSetName = "QLTCDataSet";
            this.qLTCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(8, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 52);
            this.panel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(220, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 35);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đăng ký môn học";
            // 
            // monHocBindingSource
            // 
            this.monHocBindingSource.DataMember = "MonHoc";
            this.monHocBindingSource.DataSource = this.qLTCDataSetBindingSource;
            // 
            // monHocTableAdapter
            // 
            this.monHocTableAdapter.ClearBeforeFill = true;
            // 
            // dangKyHocPhanTableAdapter
            // 
            this.dangKyHocPhanTableAdapter.ClearBeforeFill = true;
            // 
            // Formdangky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(730, 450);
            this.Controls.Add(this.btndangky);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DRVdangky);
            this.Name = "Formdangky";
            this.Text = "Formdangky";
            this.Load += new System.EventHandler(this.Formdangky_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DRVdangky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dangKyHocPhanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTCDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTCDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monHocBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btndangky;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DRVdangky;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.TextBox txtmamon;
        private System.Windows.Forms.TextBox txttenmon;
        private System.Windows.Forms.BindingSource qLTCDataSetBindingSource;
        private QLTCDataSet qLTCDataSet;
        private System.Windows.Forms.BindingSource monHocBindingSource;
        private QLTCDataSetTableAdapters.MonHocTableAdapter monHocTableAdapter;
        private System.Windows.Forms.BindingSource dangKyHocPhanBindingSource;
        private QLTCDataSetTableAdapters.DangKyHocPhanTableAdapter dangKyHocPhanTableAdapter;
    }
}