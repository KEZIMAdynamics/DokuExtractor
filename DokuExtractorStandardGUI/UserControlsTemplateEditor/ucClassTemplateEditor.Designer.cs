namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    partial class ucClassTemplateEditor
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
            this.ucTemplateSelector1 = new DokuExtractorStandardGUI.UserControlsTemplateEditor.ucTemplateSelector();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ucSingleTemplateEditor1 = new DokuExtractorStandardGUI.UserControlsTemplateEditor.ucSingleTemplateEditor();
            this.butAddDataField = new System.Windows.Forms.Button();
            this.butSaveTemplate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucTemplateSelector1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(688, 471);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 1;
            // 
            // ucTemplateSelector1
            // 
            this.ucTemplateSelector1.BackColor = System.Drawing.Color.White;
            this.ucTemplateSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemplateSelector1.Location = new System.Drawing.Point(0, 0);
            this.ucTemplateSelector1.Name = "ucTemplateSelector1";
            this.ucTemplateSelector1.Size = new System.Drawing.Size(227, 471);
            this.ucTemplateSelector1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ucSingleTemplateEditor1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.butAddDataField);
            this.splitContainer2.Panel2.Controls.Add(this.butSaveTemplate);
            this.splitContainer2.Size = new System.Drawing.Size(457, 471);
            this.splitContainer2.SplitterDistance = 417;
            this.splitContainer2.TabIndex = 0;
            // 
            // ucSingleTemplateEditor1
            // 
            this.ucSingleTemplateEditor1.BackColor = System.Drawing.Color.White;
            this.ucSingleTemplateEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSingleTemplateEditor1.Location = new System.Drawing.Point(0, 0);
            this.ucSingleTemplateEditor1.Name = "ucSingleTemplateEditor1";
            this.ucSingleTemplateEditor1.Size = new System.Drawing.Size(457, 417);
            this.ucSingleTemplateEditor1.TabIndex = 0;
            // 
            // butAddDataField
            // 
            this.butAddDataField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddDataField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddDataField.Location = new System.Drawing.Point(108, 12);
            this.butAddDataField.Name = "butAddDataField";
            this.butAddDataField.Size = new System.Drawing.Size(170, 35);
            this.butAddDataField.TabIndex = 3;
            this.butAddDataField.Text = "Add Data Field";
            this.butAddDataField.UseVisualStyleBackColor = true;
            this.butAddDataField.Click += new System.EventHandler(this.butAddDataField_Click);
            // 
            // butSaveTemplate
            // 
            this.butSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSaveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSaveTemplate.Location = new System.Drawing.Point(284, 12);
            this.butSaveTemplate.Name = "butSaveTemplate";
            this.butSaveTemplate.Size = new System.Drawing.Size(170, 35);
            this.butSaveTemplate.TabIndex = 0;
            this.butSaveTemplate.Text = "Save selected Template";
            this.butSaveTemplate.UseVisualStyleBackColor = true;
            this.butSaveTemplate.Click += new System.EventHandler(this.butSaveTemplate_Click);
            // 
            // ucClassTemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucClassTemplateEditor";
            this.Size = new System.Drawing.Size(688, 471);
            this.Load += new System.EventHandler(this.ucClassTemplateEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucTemplateSelector ucTemplateSelector1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ucSingleTemplateEditor ucSingleTemplateEditor1;
        private System.Windows.Forms.Button butAddDataField;
        private System.Windows.Forms.Button butSaveTemplate;
    }
}
