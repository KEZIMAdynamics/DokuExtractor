namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    partial class ucSingleTemplateEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucGeneralPropertyEditor1 = new DokuExtractorStandardGUI.UserControlsTemplateEditor.ucGeneralPropertyEditor();
            this.ucDataFieldEditor1 = new DokuExtractorStandardGUI.UserControlsTemplateEditor.ucDataFieldEditor();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucGeneralPropertyEditor1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucDataFieldEditor1);
            this.splitContainer1.Size = new System.Drawing.Size(964, 487);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucGeneralPropertyEditor1
            // 
            this.ucGeneralPropertyEditor1.BackColor = System.Drawing.Color.White;
            this.ucGeneralPropertyEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGeneralPropertyEditor1.Location = new System.Drawing.Point(0, 0);
            this.ucGeneralPropertyEditor1.Name = "ucGeneralPropertyEditor1";
            this.ucGeneralPropertyEditor1.Size = new System.Drawing.Size(964, 155);
            this.ucGeneralPropertyEditor1.TabIndex = 0;
            // 
            // ucDataFieldEditor1
            // 
            this.ucDataFieldEditor1.BackColor = System.Drawing.Color.White;
            this.ucDataFieldEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataFieldEditor1.Location = new System.Drawing.Point(0, 0);
            this.ucDataFieldEditor1.Name = "ucDataFieldEditor1";
            this.ucDataFieldEditor1.Size = new System.Drawing.Size(964, 328);
            this.ucDataFieldEditor1.TabIndex = 0;
            // 
            // ucSingleTemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucSingleTemplateEditor";
            this.Size = new System.Drawing.Size(964, 487);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucGeneralPropertyEditor ucGeneralPropertyEditor1;
        private ucDataFieldEditor ucDataFieldEditor1;
    }
}
