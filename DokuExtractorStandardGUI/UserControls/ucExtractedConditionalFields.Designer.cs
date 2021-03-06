﻿namespace DokuExtractorStandardGUI.UserControls
{
    partial class ucExtractedConditionalFields
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
            this.dgvConditionalFields = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConditionalFieldTypeDisplayValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConditionalFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conditionalFieldResultDisplayBindingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucExtractedConditionalFieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditionalFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionalFieldResultDisplayBindingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedConditionalFieldsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConditionalFields
            // 
            this.dgvConditionalFields.AllowUserToAddRows = false;
            this.dgvConditionalFields.AutoGenerateColumns = false;
            this.dgvConditionalFields.BackgroundColor = System.Drawing.Color.White;
            this.dgvConditionalFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditionalFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colDisplayValue,
            this.colValue,
            this.colConditionalFieldTypeDisplayValue,
            this.colConditionalFieldType});
            this.dgvConditionalFields.DataSource = this.conditionalFieldResultDisplayBindingBindingSource;
            this.dgvConditionalFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConditionalFields.Location = new System.Drawing.Point(0, 0);
            this.dgvConditionalFields.Name = "dgvConditionalFields";
            this.dgvConditionalFields.Size = new System.Drawing.Size(444, 503);
            this.dgvConditionalFields.TabIndex = 0;
            this.dgvConditionalFields.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditionalFields_CellDoubleClick);
            this.dgvConditionalFields.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditionalFields_CellValueChanged);
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
            // colDisplayValue
            // 
            this.colDisplayValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDisplayValue.DataPropertyName = "DisplayValue";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDisplayValue.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDisplayValue.HeaderText = "DisplayValue";
            this.colDisplayValue.Name = "colDisplayValue";
            this.colDisplayValue.ReadOnly = true;
            this.colDisplayValue.Width = 93;
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colValue.DataPropertyName = "Value";
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.Visible = false;
            // 
            // colConditionalFieldTypeDisplayValue
            // 
            this.colConditionalFieldTypeDisplayValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colConditionalFieldTypeDisplayValue.DataPropertyName = "ConditionalFieldTypeDisplayValue";
            this.colConditionalFieldTypeDisplayValue.HeaderText = "ConditionalFieldTypeDisplayValue";
            this.colConditionalFieldTypeDisplayValue.Name = "colConditionalFieldTypeDisplayValue";
            this.colConditionalFieldTypeDisplayValue.ReadOnly = true;
            // 
            // colConditionalFieldType
            // 
            this.colConditionalFieldType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colConditionalFieldType.DataPropertyName = "ConditionalFieldType";
            this.colConditionalFieldType.HeaderText = "ConditionalFieldType";
            this.colConditionalFieldType.Name = "colConditionalFieldType";
            this.colConditionalFieldType.ReadOnly = true;
            this.colConditionalFieldType.Visible = false;
            // 
            // conditionalFieldResultDisplayBindingBindingSource
            // 
            this.conditionalFieldResultDisplayBindingBindingSource.DataMember = "ConditionalFieldResultDisplayBinding";
            this.conditionalFieldResultDisplayBindingBindingSource.DataSource = this.ucExtractedConditionalFieldsBindingSource;
            // 
            // ucExtractedConditionalFieldsBindingSource
            // 
            this.ucExtractedConditionalFieldsBindingSource.DataSource = typeof(DokuExtractorStandardGUI.UserControls.ucExtractedConditionalFields);
            // 
            // ucExtractedConditionalFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvConditionalFields);
            this.Name = "ucExtractedConditionalFields";
            this.Size = new System.Drawing.Size(444, 503);
            this.Load += new System.EventHandler(this.ucExtractedConditionalFields_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditionalFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionalFieldResultDisplayBindingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedConditionalFieldsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConditionalFields;
        private System.Windows.Forms.BindingSource conditionalFieldResultDisplayBindingBindingSource;
        private System.Windows.Forms.BindingSource ucExtractedConditionalFieldsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConditionalFieldTypeDisplayValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConditionalFieldType;
    }
}
