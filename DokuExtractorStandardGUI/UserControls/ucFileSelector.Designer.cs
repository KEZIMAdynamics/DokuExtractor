namespace DokuExtractorStandardGUI.UserControls
{
    partial class ucFileSelector
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fileInfosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucFileSelectorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirectoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsReadOnly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colExists = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreationTimeUtc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastAccessTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastAccessTimeUtc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastWriteTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastWriteTimeUtc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttributes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucFileSelectorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colLength,
            this.colDirectoryName,
            this.colDirectory,
            this.colIsReadOnly,
            this.colExists,
            this.colFullName,
            this.colExtension,
            this.colCreationTime,
            this.colCreationTimeUtc,
            this.colLastAccessTime,
            this.colLastAccessTimeUtc,
            this.colLastWriteTime,
            this.colLastWriteTimeUtc,
            this.colAttributes});
            this.dataGridView1.DataSource = this.fileInfosBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(451, 490);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // fileInfosBindingSource
            // 
            this.fileInfosBindingSource.DataMember = "FileInfos";
            this.fileInfosBindingSource.DataSource = this.ucFileSelectorBindingSource;
            // 
            // ucFileSelectorBindingSource
            // 
            this.ucFileSelectorBindingSource.DataSource = typeof(DokuExtractorStandardGUI.UserControls.ucFileSelector);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 60;
            // 
            // colLength
            // 
            this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLength.DataPropertyName = "Length";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colLength.DefaultCellStyle = dataGridViewCellStyle1;
            this.colLength.HeaderText = "Length";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            // 
            // colDirectoryName
            // 
            this.colDirectoryName.DataPropertyName = "DirectoryName";
            this.colDirectoryName.HeaderText = "DirectoryName";
            this.colDirectoryName.Name = "colDirectoryName";
            this.colDirectoryName.ReadOnly = true;
            this.colDirectoryName.Visible = false;
            // 
            // colDirectory
            // 
            this.colDirectory.DataPropertyName = "Directory";
            this.colDirectory.HeaderText = "Directory";
            this.colDirectory.Name = "colDirectory";
            this.colDirectory.ReadOnly = true;
            this.colDirectory.Visible = false;
            // 
            // colIsReadOnly
            // 
            this.colIsReadOnly.DataPropertyName = "IsReadOnly";
            this.colIsReadOnly.HeaderText = "IsReadOnly";
            this.colIsReadOnly.Name = "colIsReadOnly";
            this.colIsReadOnly.ReadOnly = true;
            this.colIsReadOnly.Visible = false;
            // 
            // colExists
            // 
            this.colExists.DataPropertyName = "Exists";
            this.colExists.HeaderText = "Exists";
            this.colExists.Name = "colExists";
            this.colExists.ReadOnly = true;
            this.colExists.Visible = false;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Visible = false;
            // 
            // colExtension
            // 
            this.colExtension.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colExtension.DataPropertyName = "Extension";
            this.colExtension.HeaderText = "Extension";
            this.colExtension.Name = "colExtension";
            this.colExtension.ReadOnly = true;
            this.colExtension.Visible = false;
            this.colExtension.Width = 78;
            // 
            // colCreationTime
            // 
            this.colCreationTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCreationTime.DataPropertyName = "CreationTime";
            this.colCreationTime.HeaderText = "CreationTime";
            this.colCreationTime.Name = "colCreationTime";
            this.colCreationTime.ReadOnly = true;
            this.colCreationTime.Visible = false;
            this.colCreationTime.Width = 94;
            // 
            // colCreationTimeUtc
            // 
            this.colCreationTimeUtc.DataPropertyName = "CreationTimeUtc";
            this.colCreationTimeUtc.HeaderText = "CreationTimeUtc";
            this.colCreationTimeUtc.Name = "colCreationTimeUtc";
            this.colCreationTimeUtc.ReadOnly = true;
            this.colCreationTimeUtc.Visible = false;
            // 
            // colLastAccessTime
            // 
            this.colLastAccessTime.DataPropertyName = "LastAccessTime";
            this.colLastAccessTime.HeaderText = "LastAccessTime";
            this.colLastAccessTime.Name = "colLastAccessTime";
            this.colLastAccessTime.ReadOnly = true;
            this.colLastAccessTime.Visible = false;
            // 
            // colLastAccessTimeUtc
            // 
            this.colLastAccessTimeUtc.DataPropertyName = "LastAccessTimeUtc";
            this.colLastAccessTimeUtc.HeaderText = "LastAccessTimeUtc";
            this.colLastAccessTimeUtc.Name = "colLastAccessTimeUtc";
            this.colLastAccessTimeUtc.ReadOnly = true;
            this.colLastAccessTimeUtc.Visible = false;
            // 
            // colLastWriteTime
            // 
            this.colLastWriteTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastWriteTime.DataPropertyName = "LastWriteTime";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colLastWriteTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLastWriteTime.HeaderText = "LastWriteTime";
            this.colLastWriteTime.Name = "colLastWriteTime";
            this.colLastWriteTime.ReadOnly = true;
            // 
            // colLastWriteTimeUtc
            // 
            this.colLastWriteTimeUtc.DataPropertyName = "LastWriteTimeUtc";
            this.colLastWriteTimeUtc.HeaderText = "LastWriteTimeUtc";
            this.colLastWriteTimeUtc.Name = "colLastWriteTimeUtc";
            this.colLastWriteTimeUtc.ReadOnly = true;
            this.colLastWriteTimeUtc.Visible = false;
            // 
            // colAttributes
            // 
            this.colAttributes.DataPropertyName = "Attributes";
            this.colAttributes.HeaderText = "Attributes";
            this.colAttributes.Name = "colAttributes";
            this.colAttributes.ReadOnly = true;
            this.colAttributes.Visible = false;
            // 
            // ucFileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridView1);
            this.Name = "ucFileSelector";
            this.Size = new System.Drawing.Size(451, 490);
            this.Load += new System.EventHandler(this.ucFileSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucFileSelectorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource fileInfosBindingSource;
        private System.Windows.Forms.BindingSource ucFileSelectorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsReadOnly;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colExists;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreationTimeUtc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastAccessTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastAccessTimeUtc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastWriteTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastWriteTimeUtc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttributes;
    }
}
