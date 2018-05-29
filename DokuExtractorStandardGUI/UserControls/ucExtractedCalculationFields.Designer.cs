namespace DokuExtractorStandardGUI.UserControls
{
    partial class ucExtractedCalculationFields
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
            this.dgvCalculationFields = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalculationValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldTypeDisplayValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalculationEqualsValidation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculationFieldResultsDisplayBindingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucExtractedCalculationFieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculationFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculationFieldResultsDisplayBindingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedCalculationFieldsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCalculationFields
            // 
            this.dgvCalculationFields.AllowUserToAddRows = false;
            this.dgvCalculationFields.AutoGenerateColumns = false;
            this.dgvCalculationFields.BackgroundColor = System.Drawing.Color.White;
            this.dgvCalculationFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalculationFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colCalculationValue,
            this.colFieldTypeDisplayValue,
            this.colCalculationEqualsValidation,
            this.colFieldType});
            this.dgvCalculationFields.DataSource = this.calculationFieldResultsDisplayBindingBindingSource;
            this.dgvCalculationFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalculationFields.Location = new System.Drawing.Point(0, 0);
            this.dgvCalculationFields.Name = "dgvCalculationFields";
            this.dgvCalculationFields.Size = new System.Drawing.Size(536, 446);
            this.dgvCalculationFields.TabIndex = 0;
            this.dgvCalculationFields.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalculationFields_CellContentDoubleClick);
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
            // colCalculationValue
            // 
            this.colCalculationValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCalculationValue.DataPropertyName = "CalculationValue";
            this.colCalculationValue.HeaderText = "CalculationValue";
            this.colCalculationValue.Name = "colCalculationValue";
            this.colCalculationValue.Width = 111;
            // 
            // colFieldTypeDisplayValue
            // 
            this.colFieldTypeDisplayValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFieldTypeDisplayValue.DataPropertyName = "FieldTypeDisplayValue";
            this.colFieldTypeDisplayValue.HeaderText = "FieldTypeDisplayValue";
            this.colFieldTypeDisplayValue.Name = "colFieldTypeDisplayValue";
            this.colFieldTypeDisplayValue.ReadOnly = true;
            this.colFieldTypeDisplayValue.Width = 139;
            // 
            // colCalculationEqualsValidation
            // 
            this.colCalculationEqualsValidation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCalculationEqualsValidation.DataPropertyName = "CalculationEqualsValidation";
            this.colCalculationEqualsValidation.HeaderText = "CalculationEqualsValidation";
            this.colCalculationEqualsValidation.Name = "colCalculationEqualsValidation";
            this.colCalculationEqualsValidation.Width = 143;
            // 
            // colFieldType
            // 
            this.colFieldType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFieldType.DataPropertyName = "FieldType";
            this.colFieldType.HeaderText = "FieldType";
            this.colFieldType.Name = "colFieldType";
            this.colFieldType.ReadOnly = true;
            this.colFieldType.Visible = false;
            // 
            // calculationFieldResultsDisplayBindingBindingSource
            // 
            this.calculationFieldResultsDisplayBindingBindingSource.DataMember = "CalculationFieldResultsDisplayBinding";
            this.calculationFieldResultsDisplayBindingBindingSource.DataSource = this.ucExtractedCalculationFieldsBindingSource;
            // 
            // ucExtractedCalculationFieldsBindingSource
            // 
            this.ucExtractedCalculationFieldsBindingSource.DataSource = typeof(DokuExtractorStandardGUI.UserControls.ucExtractedCalculationFields);
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
            // ucExtractedCalculationFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvCalculationFields);
            this.Name = "ucExtractedCalculationFields";
            this.Size = new System.Drawing.Size(536, 446);
            this.Load += new System.EventHandler(this.ucExtractedCalculationFields_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculationFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculationFieldResultsDisplayBindingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedCalculationFieldsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalculationFields;
        private System.Windows.Forms.BindingSource calculationFieldResultsDisplayBindingBindingSource;
        private System.Windows.Forms.BindingSource ucExtractedCalculationFieldsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalculationValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldTypeDisplayValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCalculationEqualsValidation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldType;
    }
}
