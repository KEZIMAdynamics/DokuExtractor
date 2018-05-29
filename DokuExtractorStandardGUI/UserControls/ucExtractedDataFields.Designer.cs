namespace DokuExtractorStandardGUI.UserControls
{
    partial class ucExtractedDataFields
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
            this.dgvDataFields = new System.Windows.Forms.DataGridView();
            this.colDatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatFieldTypeDisplayValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataFieldResultsDisplayBindingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucExtractedDataFieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFieldResultsDisplayBindingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedDataFieldsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataFields
            // 
            this.dgvDataFields.AllowUserToAddRows = false;
            this.dgvDataFields.AutoGenerateColumns = false;
            this.dgvDataFields.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDatName,
            this.colDatValue,
            this.colDatFieldTypeDisplayValue,
            this.colDatFieldType});
            this.dgvDataFields.DataSource = this.dataFieldResultsDisplayBindingBindingSource;
            this.dgvDataFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataFields.Location = new System.Drawing.Point(0, 0);
            this.dgvDataFields.Name = "dgvDataFields";
            this.dgvDataFields.Size = new System.Drawing.Size(535, 477);
            this.dgvDataFields.TabIndex = 0;
            this.dgvDataFields.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataFields_CellDoubleClick);
            // 
            // colDatName
            // 
            this.colDatName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDatName.DataPropertyName = "Name";
            this.colDatName.HeaderText = "Name";
            this.colDatName.Name = "colDatName";
            this.colDatName.ReadOnly = true;
            this.colDatName.Width = 60;
            // 
            // colDatValue
            // 
            this.colDatValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDatValue.DataPropertyName = "Value";
            this.colDatValue.HeaderText = "Value";
            this.colDatValue.Name = "colDatValue";
            this.colDatValue.Width = 59;
            // 
            // colDatFieldTypeDisplayValue
            // 
            this.colDatFieldTypeDisplayValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDatFieldTypeDisplayValue.DataPropertyName = "FieldTypeDisplayValue";
            this.colDatFieldTypeDisplayValue.HeaderText = "FieldTypeDisplayValue";
            this.colDatFieldTypeDisplayValue.Name = "colDatFieldTypeDisplayValue";
            this.colDatFieldTypeDisplayValue.ReadOnly = true;
            this.colDatFieldTypeDisplayValue.Width = 139;
            // 
            // colDatFieldType
            // 
            this.colDatFieldType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDatFieldType.DataPropertyName = "FieldType";
            this.colDatFieldType.HeaderText = "FieldType";
            this.colDatFieldType.Name = "colDatFieldType";
            this.colDatFieldType.ReadOnly = true;
            this.colDatFieldType.Visible = false;
            // 
            // dataFieldResultsDisplayBindingBindingSource
            // 
            this.dataFieldResultsDisplayBindingBindingSource.DataMember = "DataFieldResultsDisplayBinding";
            this.dataFieldResultsDisplayBindingBindingSource.DataSource = this.ucExtractedDataFieldsBindingSource;
            // 
            // ucExtractedDataFieldsBindingSource
            // 
            this.ucExtractedDataFieldsBindingSource.DataSource = typeof(DokuExtractorStandardGUI.UserControls.ucExtractedDataFields);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn1.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // ucExtractedDataFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvDataFields);
            this.Name = "ucExtractedDataFields";
            this.Size = new System.Drawing.Size(535, 477);
            this.Load += new System.EventHandler(this.ucExtractedDataFields_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFieldResultsDisplayBindingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedDataFieldsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataFields;
        private System.Windows.Forms.BindingSource dataFieldResultsDisplayBindingBindingSource;
        private System.Windows.Forms.BindingSource ucExtractedDataFieldsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatFieldTypeDisplayValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatFieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
