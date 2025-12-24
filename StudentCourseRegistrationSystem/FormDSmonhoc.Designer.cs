namespace StudentCourseRegistrationSystem
{
    partial class FormDSmonhoc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DRVdanhsach = new System.Windows.Forms.DataGridView();
            this.mamonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenmonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sotinchiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sotietlythuyetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sotietthuchanhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.makhoaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monHocBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTCDataSet = new StudentCourseRegistrationSystem.QLTCDataSet();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.monHocTableAdapter = new StudentCourseRegistrationSystem.QLTCDataSetTableAdapters.MonHocTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DRVdanhsach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monHocBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTCDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 46);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(249, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách môn học";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DRVdanhsach
            // 
            this.DRVdanhsach.AutoGenerateColumns = false;
            this.DRVdanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DRVdanhsach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mamonDataGridViewTextBoxColumn,
            this.tenmonDataGridViewTextBoxColumn,
            this.sotinchiDataGridViewTextBoxColumn,
            this.sotietlythuyetDataGridViewTextBoxColumn,
            this.sotietthuchanhDataGridViewTextBoxColumn,
            this.makhoaDataGridViewTextBoxColumn});
            this.DRVdanhsach.DataSource = this.monHocBindingSource;
            this.DRVdanhsach.Location = new System.Drawing.Point(12, 109);
            this.DRVdanhsach.Name = "DRVdanhsach";
            this.DRVdanhsach.RowHeadersWidth = 51;
            this.DRVdanhsach.RowTemplate.Height = 24;
            this.DRVdanhsach.Size = new System.Drawing.Size(776, 356);
            this.DRVdanhsach.TabIndex = 1;
            // 
            // mamonDataGridViewTextBoxColumn
            // 
            this.mamonDataGridViewTextBoxColumn.DataPropertyName = "ma_mon";
            this.mamonDataGridViewTextBoxColumn.HeaderText = "Mã môn";
            this.mamonDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mamonDataGridViewTextBoxColumn.Name = "mamonDataGridViewTextBoxColumn";
            this.mamonDataGridViewTextBoxColumn.Width = 125;
            // 
            // tenmonDataGridViewTextBoxColumn
            // 
            this.tenmonDataGridViewTextBoxColumn.DataPropertyName = "ten_mon";
            this.tenmonDataGridViewTextBoxColumn.HeaderText = "Tên Môn";
            this.tenmonDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tenmonDataGridViewTextBoxColumn.Name = "tenmonDataGridViewTextBoxColumn";
            this.tenmonDataGridViewTextBoxColumn.Width = 250;
            // 
            // sotinchiDataGridViewTextBoxColumn
            // 
            this.sotinchiDataGridViewTextBoxColumn.DataPropertyName = "so_tin_chi";
            this.sotinchiDataGridViewTextBoxColumn.HeaderText = "Số tín chỉ";
            this.sotinchiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sotinchiDataGridViewTextBoxColumn.Name = "sotinchiDataGridViewTextBoxColumn";
            this.sotinchiDataGridViewTextBoxColumn.Width = 125;
            // 
            // sotietlythuyetDataGridViewTextBoxColumn
            // 
            this.sotietlythuyetDataGridViewTextBoxColumn.DataPropertyName = "so_tiet_ly_thuyet";
            this.sotietlythuyetDataGridViewTextBoxColumn.HeaderText = "Số tiết lý thuyết";
            this.sotietlythuyetDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sotietlythuyetDataGridViewTextBoxColumn.Name = "sotietlythuyetDataGridViewTextBoxColumn";
            this.sotietlythuyetDataGridViewTextBoxColumn.Width = 125;
            // 
            // sotietthuchanhDataGridViewTextBoxColumn
            // 
            this.sotietthuchanhDataGridViewTextBoxColumn.DataPropertyName = "so_tiet_thuc_hanh";
            this.sotietthuchanhDataGridViewTextBoxColumn.HeaderText = "Số tiết thực hành";
            this.sotietthuchanhDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sotietthuchanhDataGridViewTextBoxColumn.Name = "sotietthuchanhDataGridViewTextBoxColumn";
            this.sotietthuchanhDataGridViewTextBoxColumn.Width = 125;
            // 
            // makhoaDataGridViewTextBoxColumn
            // 
            this.makhoaDataGridViewTextBoxColumn.DataPropertyName = "ma_khoa";
            this.makhoaDataGridViewTextBoxColumn.HeaderText = "Mã khoa";
            this.makhoaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.makhoaDataGridViewTextBoxColumn.Name = "makhoaDataGridViewTextBoxColumn";
            this.makhoaDataGridViewTextBoxColumn.Width = 125;
            // 
            // monHocBindingSource
            // 
            this.monHocBindingSource.DataMember = "MonHoc";
            this.monHocBindingSource.DataSource = this.qLTCDataSet;
            // 
            // qLTCDataSet
            // 
            this.qLTCDataSet.DataSetName = "QLTCDataSet";
            this.qLTCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(506, 72);
            this.txttimkiem.Multiline = true;
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(201, 31);
            this.txttimkiem.TabIndex = 2;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(713, 72);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(75, 32);
            this.btntimkiem.TabIndex = 3;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // monHocTableAdapter
            // 
            this.monHocTableAdapter.ClearBeforeFill = true;
            // 
            // FormDSmonhoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.DRVdanhsach);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormDSmonhoc";
            this.Text = "FormDSmonhoc";
            this.Load += new System.EventHandler(this.FormDSmonhoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DRVdanhsach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monHocBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTCDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DRVdanhsach;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Button btntimkiem;
        private QLTCDataSet qLTCDataSet;
        private System.Windows.Forms.BindingSource monHocBindingSource;
        private QLTCDataSetTableAdapters.MonHocTableAdapter monHocTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mamonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenmonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sotinchiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sotietlythuyetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sotietthuchanhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn makhoaDataGridViewTextBoxColumn;
    }
}