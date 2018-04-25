namespace DokuExtractorStandardGUI.UserControls
{
    partial class ucExtractedData
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
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDataFields = new System.Windows.Forms.DataGridView();
            this.dgvCalculationFields = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucExtractedDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataFieldResultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.calculationFieldResultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldTypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculationValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculationEqualsValidationDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculationFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFieldResultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculationFieldResultsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGroupName
            // 
            this.txtGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroupName.Enabled = false;
            this.txtGroupName.Location = new System.Drawing.Point(138, 38);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(377, 20);
            this.txtGroupName.TabIndex = 9;
            // 
            // txtClassName
            // 
            this.txtClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClassName.Enabled = false;
            this.txtClassName.Location = new System.Drawing.Point(138, 12);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(377, 20);
            this.txtClassName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Template Group Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Template Class Name";
            // 
            // dgvDataFields
            // 
            this.dgvDataFields.AutoGenerateColumns = false;
            this.dgvDataFields.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.fieldTypeDataGridViewTextBoxColumn});
            this.dgvDataFields.DataSource = this.dataFieldResultsBindingSource;
            this.dgvDataFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataFields.Location = new System.Drawing.Point(0, 0);
            this.dgvDataFields.Name = "dgvDataFields";
            this.dgvDataFields.Size = new System.Drawing.Size(494, 251);
            this.dgvDataFields.TabIndex = 10;
            // 
            // dgvCalculationFields
            // 
            this.dgvCalculationFields.AutoGenerateColumns = false;
            this.dgvCalculationFields.BackgroundColor = System.Drawing.Color.White;
            this.dgvCalculationFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalculationFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.fieldTypeDataGridViewTextBoxColumn1,
            this.calculationValueDataGridViewTextBoxColumn,
            this.calculationEqualsValidationDataGridViewCheckBoxColumn});
            this.dgvCalculationFields.DataSource = this.calculationFieldResultsBindingSource;
            this.dgvCalculationFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalculationFields.Location = new System.Drawing.Point(0, 0);
            this.dgvCalculationFields.Name = "dgvCalculationFields";
            this.dgvCalculationFields.Size = new System.Drawing.Size(494, 247);
            this.dgvCalculationFields.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(21, 82);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDataFields);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCalculationFields);
            this.splitContainer1.Size = new System.Drawing.Size(494, 502);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 12;
            // 
            // ucExtractedDataBindingSource
            // 
            this.ucExtractedDataBindingSource.DataSource = typeof(DokuExtractorStandardGUI.UserControls.ucExtractedData);
            // 
            // dataFieldResultsBindingSource
            // 
            this.dataFieldResultsBindingSource.DataMember = "DataFieldResults";
            this.dataFieldResultsBindingSource.DataSource = this.ucExtractedDataBindingSource;
            // 
            // calculationFieldResultsBindingSource
            // 
            this.calculationFieldResultsBindingSource.DataMember = "CalculationFieldResults";
            this.calculationFieldResultsBindingSource.DataSource = this.ucExtractedDataBindingSource;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.Width = 59;
            // 
            // fieldTypeDataGridViewTextBoxColumn
            // 
            this.fieldTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fieldTypeDataGridViewTextBoxColumn.DataPropertyName = "FieldType";
            this.fieldTypeDataGridViewTextBoxColumn.HeaderText = "FieldType";
            this.fieldTypeDataGridViewTextBoxColumn.Name = "fieldTypeDataGridViewTextBoxColumn";
            this.fieldTypeDataGridViewTextBoxColumn.Width = 78;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.Width = 60;
            // 
            // fieldTypeDataGridViewTextBoxColumn1
            // 
            this.fieldTypeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fieldTypeDataGridViewTextBoxColumn1.DataPropertyName = "FieldType";
            this.fieldTypeDataGridViewTextBoxColumn1.HeaderText = "FieldType";
            this.fieldTypeDataGridViewTextBoxColumn1.Name = "fieldTypeDataGridViewTextBoxColumn1";
            this.fieldTypeDataGridViewTextBoxColumn1.Width = 78;
            // 
            // calculationValueDataGridViewTextBoxColumn
            // 
            this.calculationValueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.calculationValueDataGridViewTextBoxColumn.DataPropertyName = "CalculationValue";
            this.calculationValueDataGridViewTextBoxColumn.HeaderText = "CalculationValue";
            this.calculationValueDataGridViewTextBoxColumn.Name = "calculationValueDataGridViewTextBoxColumn";
            this.calculationValueDataGridViewTextBoxColumn.Width = 111;
            // 
            // calculationEqualsValidationDataGridViewCheckBoxColumn
            // 
            this.calculationEqualsValidationDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.calculationEqualsValidationDataGridViewCheckBoxColumn.DataPropertyName = "CalculationEqualsValidation";
            this.calculationEqualsValidationDataGridViewCheckBoxColumn.HeaderText = "CalculationEqualsValidation";
            this.calculationEqualsValidationDataGridViewCheckBoxColumn.Name = "calculationEqualsValidationDataGridViewCheckBoxColumn";
            this.calculationEqualsValidationDataGridViewCheckBoxColumn.Width = 143;
            // 
            // ucExtractedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucExtractedData";
            this.Size = new System.Drawing.Size(531, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculationFields)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFieldResultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculationFieldResultsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDataFields;
        private System.Windows.Forms.DataGridView dgvCalculationFields;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource ucExtractedDataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dataFieldResultsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn calculationValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn calculationEqualsValidationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource calculationFieldResultsBindingSource;
    }
}
