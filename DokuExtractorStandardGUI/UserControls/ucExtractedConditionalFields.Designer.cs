namespace DokuExtractorStandardGUI.UserControls
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
            this.dgvConditionalFields = new System.Windows.Forms.DataGridView();
            this.ucExtractedConditionalFieldsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conditionalFieldResultBindingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCondValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditionalFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedConditionalFieldsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionalFieldResultBindingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConditionalFields
            // 
            this.dgvConditionalFields.AllowUserToAddRows = false;
            this.dgvConditionalFields.AutoGenerateColumns = false;
            this.dgvConditionalFields.BackgroundColor = System.Drawing.Color.White;
            this.dgvConditionalFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditionalFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCondName,
            this.colCondValue});
            this.dgvConditionalFields.DataSource = this.conditionalFieldResultBindingBindingSource;
            this.dgvConditionalFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConditionalFields.Location = new System.Drawing.Point(0, 0);
            this.dgvConditionalFields.Name = "dgvConditionalFields";
            this.dgvConditionalFields.Size = new System.Drawing.Size(444, 503);
            this.dgvConditionalFields.TabIndex = 0;
            this.dgvConditionalFields.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditionalFields_CellDoubleClick);
            // 
            // ucExtractedConditionalFieldsBindingSource
            // 
            this.ucExtractedConditionalFieldsBindingSource.DataSource = typeof(DokuExtractorStandardGUI.UserControls.ucExtractedConditionalFields);
            // 
            // conditionalFieldResultBindingBindingSource
            // 
            this.conditionalFieldResultBindingBindingSource.DataMember = "ConditionalFieldResultBinding";
            this.conditionalFieldResultBindingBindingSource.DataSource = this.ucExtractedConditionalFieldsBindingSource;
            // 
            // colCondName
            // 
            this.colCondName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCondName.DataPropertyName = "Name";
            this.colCondName.HeaderText = "Name";
            this.colCondName.Name = "colCondName";
            this.colCondName.ReadOnly = true;
            this.colCondName.Width = 60;
            // 
            // colCondValue
            // 
            this.colCondValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCondValue.DataPropertyName = "Value";
            this.colCondValue.HeaderText = "Value";
            this.colCondValue.Name = "colCondValue";
            this.colCondValue.Width = 59;
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
            ((System.ComponentModel.ISupportInitialize)(this.ucExtractedConditionalFieldsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionalFieldResultBindingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConditionalFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondValue;
        private System.Windows.Forms.BindingSource conditionalFieldResultBindingBindingSource;
        private System.Windows.Forms.BindingSource ucExtractedConditionalFieldsBindingSource;
    }
}
