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
            this.calculationFieldResultsDisplayBindingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucExtractedCalculationFieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCalcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalcCalculationValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalcFieldTypeDisplayValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalcCalculationEqualsValidation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCalcFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.colCalcName,
            this.colCalcCalculationValue,
            this.colCalcFieldTypeDisplayValue,
            this.colCalcCalculationEqualsValidation,
            this.colCalcFieldType});
            this.dgvCalculationFields.DataSource = this.calculationFieldResultsDisplayBindingBindingSource;
            this.dgvCalculationFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalculationFields.Location = new System.Drawing.Point(0, 0);
            this.dgvCalculationFields.Name = "dgvCalculationFields";
            this.dgvCalculationFields.Size = new System.Drawing.Size(536, 446);
            this.dgvCalculationFields.TabIndex = 0;
            // 
            // calculationFieldResultsDisplayBindingBindingSource
            // 
            this.calculationFieldResultsDisplayBindingBindingSource.DataMember = "CalculationFieldResultsDisplayBinding";
            this.calculationFieldResultsDisplayBindingBindingSource.DataSource = this.ucExtractedCalculationFieldsBindingSource;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn1.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 78;
            // 
            // ucExtractedCalculationFieldsBindingSource
            // 
            this.ucExtractedCalculationFieldsBindingSource.DataSource = typeof(DokuExtractorStandardGUI.UserControls.ucExtractedCalculationFields);
            // 
            // colCalcName
            // 
            this.colCalcName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCalcName.DataPropertyName = "Name";
            this.colCalcName.HeaderText = "Name";
            this.colCalcName.Name = "colCalcName";
            this.colCalcName.ReadOnly = true;
            this.colCalcName.Width = 60;
            // 
            // colCalcCalculationValue
            // 
            this.colCalcCalculationValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCalcCalculationValue.DataPropertyName = "CalculationValue";
            this.colCalcCalculationValue.HeaderText = "CalculationValue";
            this.colCalcCalculationValue.Name = "colCalcCalculationValue";
            this.colCalcCalculationValue.Width = 111;
            // 
            // colCalcFieldTypeDisplayValue
            // 
            this.colCalcFieldTypeDisplayValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCalcFieldTypeDisplayValue.DataPropertyName = "FieldTypeDisplayValue";
            this.colCalcFieldTypeDisplayValue.HeaderText = "FieldTypeDisplayValue";
            this.colCalcFieldTypeDisplayValue.Name = "colCalcFieldTypeDisplayValue";
            this.colCalcFieldTypeDisplayValue.ReadOnly = true;
            this.colCalcFieldTypeDisplayValue.Width = 139;
            // 
            // colCalcCalculationEqualsValidation
            // 
            this.colCalcCalculationEqualsValidation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCalcCalculationEqualsValidation.DataPropertyName = "CalculationEqualsValidation";
            this.colCalcCalculationEqualsValidation.HeaderText = "CalculationEqualsValidation";
            this.colCalcCalculationEqualsValidation.Name = "colCalcCalculationEqualsValidation";
            this.colCalcCalculationEqualsValidation.Width = 143;
            // 
            // colCalcFieldType
            // 
            this.colCalcFieldType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCalcFieldType.DataPropertyName = "FieldType";
            this.colCalcFieldType.HeaderText = "FieldType";
            this.colCalcFieldType.Name = "colCalcFieldType";
            this.colCalcFieldType.ReadOnly = true;
            this.colCalcFieldType.Visible = false;
            this.colCalcFieldType.Width = 78;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalcCalculationValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalcFieldTypeDisplayValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCalcCalculationEqualsValidation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalcFieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
