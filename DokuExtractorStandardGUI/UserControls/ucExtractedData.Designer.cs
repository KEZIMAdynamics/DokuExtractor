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
            this.lblTemplateGroupName = new System.Windows.Forms.Label();
            this.lblTemplateClassName = new System.Windows.Forms.Label();
            this.dgvDataFields = new System.Windows.Forms.DataGridView();
            this.dgvCalculationFields = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataFieldResultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.calculationFieldResultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucExtractedDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCalcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalcCalculationValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalcCalculationEqualsValidation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCalcFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculationFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFieldResultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculationFieldResultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedDataBindingSource)).BeginInit();
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
            // lblTemplateGroupName
            // 
            this.lblTemplateGroupName.AutoSize = true;
            this.lblTemplateGroupName.Location = new System.Drawing.Point(18, 41);
            this.lblTemplateGroupName.Name = "lblTemplateGroupName";
            this.lblTemplateGroupName.Size = new System.Drawing.Size(114, 13);
            this.lblTemplateGroupName.TabIndex = 7;
            this.lblTemplateGroupName.Text = "Template Group Name";
            // 
            // lblTemplateClassName
            // 
            this.lblTemplateClassName.AutoSize = true;
            this.lblTemplateClassName.Location = new System.Drawing.Point(18, 15);
            this.lblTemplateClassName.Name = "lblTemplateClassName";
            this.lblTemplateClassName.Size = new System.Drawing.Size(110, 13);
            this.lblTemplateClassName.TabIndex = 6;
            this.lblTemplateClassName.Text = "Template Class Name";
            // 
            // dgvDataFields
            // 
            this.dgvDataFields.AutoGenerateColumns = false;
            this.dgvDataFields.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colValue,
            this.colFieldType});
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
            this.colCalcName,
            this.colCalcCalculationValue,
            this.colCalcCalculationEqualsValidation,
            this.colCalcFieldType});
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn1.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 78;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn2.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 78;
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn3.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 78;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn4.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 78;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn5.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn6.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 78;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn7.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // ucExtractedDataBindingSource
            // 
            this.ucExtractedDataBindingSource.DataSource = typeof(DokuExtractorStandardGUI.UserControls.ucExtractedData);
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
            // colCalcCalculationEqualsValidation
            // 
            this.colCalcCalculationEqualsValidation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCalcCalculationEqualsValidation.DataPropertyName = "CalculationEqualsValidation";
            this.colCalcCalculationEqualsValidation.HeaderText = "CalculationEqualsValidation";
            this.colCalcCalculationEqualsValidation.Name = "colCalcCalculationEqualsValidation";
            this.colCalcCalculationEqualsValidation.ReadOnly = true;
            this.colCalcCalculationEqualsValidation.Width = 143;
            // 
            // colCalcFieldType
            // 
            this.colCalcFieldType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCalcFieldType.DataPropertyName = "FieldType";
            this.colCalcFieldType.HeaderText = "FieldType";
            this.colCalcFieldType.Name = "colCalcFieldType";
            this.colCalcFieldType.ReadOnly = true;
            this.colCalcFieldType.Width = 78;
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
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colValue.DataPropertyName = "Value";
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Width = 59;
            // 
            // colFieldType
            // 
            this.colFieldType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFieldType.DataPropertyName = "FieldType";
            this.colFieldType.HeaderText = "FieldType";
            this.colFieldType.Name = "colFieldType";
            this.colFieldType.ReadOnly = true;
            this.colFieldType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFieldType.Width = 78;
            // 
            // ucExtractedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.lblTemplateGroupName);
            this.Controls.Add(this.lblTemplateClassName);
            this.Name = "ucExtractedData";
            this.Size = new System.Drawing.Size(531, 600);
            this.Load += new System.EventHandler(this.ucExtractedData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculationFields)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataFieldResultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculationFieldResultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label lblTemplateGroupName;
        private System.Windows.Forms.Label lblTemplateClassName;
        private System.Windows.Forms.DataGridView dgvDataFields;
        private System.Windows.Forms.DataGridView dgvCalculationFields;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource ucExtractedDataBindingSource;
        private System.Windows.Forms.BindingSource dataFieldResultsBindingSource;
        private System.Windows.Forms.BindingSource calculationFieldResultsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalcFieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalcCalculationValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCalcCalculationEqualsValidation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldType;
    }
}
