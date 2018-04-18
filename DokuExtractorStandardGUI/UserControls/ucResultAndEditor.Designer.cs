namespace DokuExtractorStandardGUI.UserControls
{
    partial class ucResultAndEditor
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
            this.ucExtractedData1 = new DokuExtractorStandardGUI.UserControls.ucExtractedData();
            this.tabExtractedData = new System.Windows.Forms.TabPage();
            this.ucSingleTemplateEditor1 = new DokuExtractorStandardGUI.UserControlsTemplateEditor.ucSingleTemplateEditor();
            this.tabSingleTemplateEditor = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabExtractedData.SuspendLayout();
            this.tabSingleTemplateEditor.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucExtractedData1
            // 
            this.ucExtractedData1.BackColor = System.Drawing.Color.White;
            this.ucExtractedData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExtractedData1.Location = new System.Drawing.Point(3, 3);
            this.ucExtractedData1.Name = "ucExtractedData1";
            this.ucExtractedData1.Size = new System.Drawing.Size(584, 433);
            this.ucExtractedData1.TabIndex = 0;
            // 
            // tabExtractedData
            // 
            this.tabExtractedData.Controls.Add(this.ucExtractedData1);
            this.tabExtractedData.Location = new System.Drawing.Point(4, 22);
            this.tabExtractedData.Name = "tabExtractedData";
            this.tabExtractedData.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtractedData.Size = new System.Drawing.Size(590, 439);
            this.tabExtractedData.TabIndex = 0;
            this.tabExtractedData.Text = "Extracted Data";
            this.tabExtractedData.UseVisualStyleBackColor = true;
            // 
            // ucSingleTemplateEditor1
            // 
            this.ucSingleTemplateEditor1.BackColor = System.Drawing.Color.White;
            this.ucSingleTemplateEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSingleTemplateEditor1.Location = new System.Drawing.Point(3, 3);
            this.ucSingleTemplateEditor1.Name = "ucSingleTemplateEditor1";
            this.ucSingleTemplateEditor1.Size = new System.Drawing.Size(584, 433);
            this.ucSingleTemplateEditor1.TabIndex = 0;
            // 
            // tabSingleTemplateEditor
            // 
            this.tabSingleTemplateEditor.Controls.Add(this.ucSingleTemplateEditor1);
            this.tabSingleTemplateEditor.Location = new System.Drawing.Point(4, 22);
            this.tabSingleTemplateEditor.Name = "tabSingleTemplateEditor";
            this.tabSingleTemplateEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabSingleTemplateEditor.Size = new System.Drawing.Size(590, 439);
            this.tabSingleTemplateEditor.TabIndex = 1;
            this.tabSingleTemplateEditor.Text = "Single Template Editor";
            this.tabSingleTemplateEditor.UseVisualStyleBackColor = true;
            this.tabSingleTemplateEditor.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabExtractedData);
            this.tabControl1.Controls.Add(this.tabSingleTemplateEditor);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(598, 465);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // ucResultAndEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucResultAndEditor";
            this.Size = new System.Drawing.Size(598, 465);
            this.tabExtractedData.ResumeLayout(false);
            this.tabSingleTemplateEditor.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucExtractedData ucExtractedData1;
        private System.Windows.Forms.TabPage tabExtractedData;
        private UserControlsTemplateEditor.ucSingleTemplateEditor ucSingleTemplateEditor1;
        private System.Windows.Forms.TabPage tabSingleTemplateEditor;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
