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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fileInfosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucFileSelectorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isReadOnlyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.existsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationTimeUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastAccessTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastAccessTimeUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastWriteTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastWriteTimeUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attributesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.nameDataGridViewTextBoxColumn,
            this.lengthDataGridViewTextBoxColumn,
            this.directoryNameDataGridViewTextBoxColumn,
            this.directoryDataGridViewTextBoxColumn,
            this.isReadOnlyDataGridViewCheckBoxColumn,
            this.existsDataGridViewCheckBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.extensionDataGridViewTextBoxColumn,
            this.creationTimeDataGridViewTextBoxColumn,
            this.creationTimeUtcDataGridViewTextBoxColumn,
            this.lastAccessTimeDataGridViewTextBoxColumn,
            this.lastAccessTimeUtcDataGridViewTextBoxColumn,
            this.lastWriteTimeDataGridViewTextBoxColumn,
            this.lastWriteTimeUtcDataGridViewTextBoxColumn,
            this.attributesDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fileInfosBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(451, 490);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
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
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "Length";
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            this.lengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.lengthDataGridViewTextBoxColumn.Width = 65;
            // 
            // directoryNameDataGridViewTextBoxColumn
            // 
            this.directoryNameDataGridViewTextBoxColumn.DataPropertyName = "DirectoryName";
            this.directoryNameDataGridViewTextBoxColumn.HeaderText = "DirectoryName";
            this.directoryNameDataGridViewTextBoxColumn.Name = "directoryNameDataGridViewTextBoxColumn";
            this.directoryNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.directoryNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // directoryDataGridViewTextBoxColumn
            // 
            this.directoryDataGridViewTextBoxColumn.DataPropertyName = "Directory";
            this.directoryDataGridViewTextBoxColumn.HeaderText = "Directory";
            this.directoryDataGridViewTextBoxColumn.Name = "directoryDataGridViewTextBoxColumn";
            this.directoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.directoryDataGridViewTextBoxColumn.Visible = false;
            // 
            // isReadOnlyDataGridViewCheckBoxColumn
            // 
            this.isReadOnlyDataGridViewCheckBoxColumn.DataPropertyName = "IsReadOnly";
            this.isReadOnlyDataGridViewCheckBoxColumn.HeaderText = "IsReadOnly";
            this.isReadOnlyDataGridViewCheckBoxColumn.Name = "isReadOnlyDataGridViewCheckBoxColumn";
            this.isReadOnlyDataGridViewCheckBoxColumn.Visible = false;
            // 
            // existsDataGridViewCheckBoxColumn
            // 
            this.existsDataGridViewCheckBoxColumn.DataPropertyName = "Exists";
            this.existsDataGridViewCheckBoxColumn.HeaderText = "Exists";
            this.existsDataGridViewCheckBoxColumn.Name = "existsDataGridViewCheckBoxColumn";
            this.existsDataGridViewCheckBoxColumn.ReadOnly = true;
            this.existsDataGridViewCheckBoxColumn.Visible = false;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // extensionDataGridViewTextBoxColumn
            // 
            this.extensionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.extensionDataGridViewTextBoxColumn.DataPropertyName = "Extension";
            this.extensionDataGridViewTextBoxColumn.HeaderText = "Extension";
            this.extensionDataGridViewTextBoxColumn.Name = "extensionDataGridViewTextBoxColumn";
            this.extensionDataGridViewTextBoxColumn.ReadOnly = true;
            this.extensionDataGridViewTextBoxColumn.Visible = false;
            this.extensionDataGridViewTextBoxColumn.Width = 78;
            // 
            // creationTimeDataGridViewTextBoxColumn
            // 
            this.creationTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.creationTimeDataGridViewTextBoxColumn.DataPropertyName = "CreationTime";
            this.creationTimeDataGridViewTextBoxColumn.HeaderText = "CreationTime";
            this.creationTimeDataGridViewTextBoxColumn.Name = "creationTimeDataGridViewTextBoxColumn";
            this.creationTimeDataGridViewTextBoxColumn.Visible = false;
            this.creationTimeDataGridViewTextBoxColumn.Width = 94;
            // 
            // creationTimeUtcDataGridViewTextBoxColumn
            // 
            this.creationTimeUtcDataGridViewTextBoxColumn.DataPropertyName = "CreationTimeUtc";
            this.creationTimeUtcDataGridViewTextBoxColumn.HeaderText = "CreationTimeUtc";
            this.creationTimeUtcDataGridViewTextBoxColumn.Name = "creationTimeUtcDataGridViewTextBoxColumn";
            this.creationTimeUtcDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastAccessTimeDataGridViewTextBoxColumn
            // 
            this.lastAccessTimeDataGridViewTextBoxColumn.DataPropertyName = "LastAccessTime";
            this.lastAccessTimeDataGridViewTextBoxColumn.HeaderText = "LastAccessTime";
            this.lastAccessTimeDataGridViewTextBoxColumn.Name = "lastAccessTimeDataGridViewTextBoxColumn";
            this.lastAccessTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastAccessTimeUtcDataGridViewTextBoxColumn
            // 
            this.lastAccessTimeUtcDataGridViewTextBoxColumn.DataPropertyName = "LastAccessTimeUtc";
            this.lastAccessTimeUtcDataGridViewTextBoxColumn.HeaderText = "LastAccessTimeUtc";
            this.lastAccessTimeUtcDataGridViewTextBoxColumn.Name = "lastAccessTimeUtcDataGridViewTextBoxColumn";
            this.lastAccessTimeUtcDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastWriteTimeDataGridViewTextBoxColumn
            // 
            this.lastWriteTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lastWriteTimeDataGridViewTextBoxColumn.DataPropertyName = "LastWriteTime";
            this.lastWriteTimeDataGridViewTextBoxColumn.HeaderText = "LastWriteTime";
            this.lastWriteTimeDataGridViewTextBoxColumn.Name = "lastWriteTimeDataGridViewTextBoxColumn";
            // 
            // lastWriteTimeUtcDataGridViewTextBoxColumn
            // 
            this.lastWriteTimeUtcDataGridViewTextBoxColumn.DataPropertyName = "LastWriteTimeUtc";
            this.lastWriteTimeUtcDataGridViewTextBoxColumn.HeaderText = "LastWriteTimeUtc";
            this.lastWriteTimeUtcDataGridViewTextBoxColumn.Name = "lastWriteTimeUtcDataGridViewTextBoxColumn";
            this.lastWriteTimeUtcDataGridViewTextBoxColumn.Visible = false;
            // 
            // attributesDataGridViewTextBoxColumn
            // 
            this.attributesDataGridViewTextBoxColumn.DataPropertyName = "Attributes";
            this.attributesDataGridViewTextBoxColumn.HeaderText = "Attributes";
            this.attributesDataGridViewTextBoxColumn.Name = "attributesDataGridViewTextBoxColumn";
            this.attributesDataGridViewTextBoxColumn.Visible = false;
            // 
            // ucFileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridView1);
            this.Name = "ucFileSelector";
            this.Size = new System.Drawing.Size(451, 490);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileInfosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucFileSelectorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource fileInfosBindingSource;
        private System.Windows.Forms.BindingSource ucFileSelectorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadOnlyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn existsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationTimeUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastAccessTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastAccessTimeUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastWriteTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastWriteTimeUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attributesDataGridViewTextBoxColumn;
    }
}
