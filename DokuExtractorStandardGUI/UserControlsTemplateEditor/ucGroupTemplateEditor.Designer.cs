namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    partial class ucGroupTemplateEditor
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
            this.butDeleteTemplate = new System.Windows.Forms.Button();
            this.butAddConditionalField = new System.Windows.Forms.Button();
            this.butAddCalculationField = new System.Windows.Forms.Button();
            this.butAddDataField = new System.Windows.Forms.Button();
            this.butSaveTemplate = new System.Windows.Forms.Button();
            this.butNewTemplate = new System.Windows.Forms.Button();
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
            this.splitContainer1.Size = new System.Drawing.Size(1200, 500);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 2;
            // 
            // ucTemplateSelector1
            // 
            this.ucTemplateSelector1.BackColor = System.Drawing.Color.White;
            this.ucTemplateSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemplateSelector1.Location = new System.Drawing.Point(0, 0);
            this.ucTemplateSelector1.Name = "ucTemplateSelector1";
            this.ucTemplateSelector1.Size = new System.Drawing.Size(300, 500);
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
            this.splitContainer2.Panel2.Controls.Add(this.butNewTemplate);
            this.splitContainer2.Panel2.Controls.Add(this.butDeleteTemplate);
            this.splitContainer2.Panel2.Controls.Add(this.butAddConditionalField);
            this.splitContainer2.Panel2.Controls.Add(this.butAddCalculationField);
            this.splitContainer2.Panel2.Controls.Add(this.butAddDataField);
            this.splitContainer2.Panel2.Controls.Add(this.butSaveTemplate);
            this.splitContainer2.Size = new System.Drawing.Size(896, 500);
            this.splitContainer2.SplitterDistance = 440;
            this.splitContainer2.TabIndex = 0;
            // 
            // ucSingleTemplateEditor1
            // 
            this.ucSingleTemplateEditor1.BackColor = System.Drawing.Color.White;
            this.ucSingleTemplateEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSingleTemplateEditor1.Location = new System.Drawing.Point(0, 0);
            this.ucSingleTemplateEditor1.Name = "ucSingleTemplateEditor1";
            this.ucSingleTemplateEditor1.Size = new System.Drawing.Size(896, 440);
            this.ucSingleTemplateEditor1.TabIndex = 0;
            // 
            // butDeleteTemplate
            // 
            this.butDeleteTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteTemplate.ForeColor = System.Drawing.Color.Red;
            this.butDeleteTemplate.Location = new System.Drawing.Point(793, 6);
            this.butDeleteTemplate.Name = "butDeleteTemplate";
            this.butDeleteTemplate.Size = new System.Drawing.Size(100, 47);
            this.butDeleteTemplate.TabIndex = 6;
            this.butDeleteTemplate.Text = "Delete selected Template";
            this.butDeleteTemplate.UseVisualStyleBackColor = true;
            this.butDeleteTemplate.Click += new System.EventHandler(this.butDeleteTemplate_Click);
            // 
            // butAddConditionalField
            // 
            this.butAddConditionalField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddConditionalField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butAddConditionalField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddConditionalField.Location = new System.Drawing.Point(581, 6);
            this.butAddConditionalField.Name = "butAddConditionalField";
            this.butAddConditionalField.Size = new System.Drawing.Size(100, 47);
            this.butAddConditionalField.TabIndex = 5;
            this.butAddConditionalField.Text = "Add Conditional Field";
            this.butAddConditionalField.UseVisualStyleBackColor = false;
            this.butAddConditionalField.Click += new System.EventHandler(this.butAddConditionalField_Click);
            // 
            // butAddCalculationField
            // 
            this.butAddCalculationField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddCalculationField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butAddCalculationField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddCalculationField.Location = new System.Drawing.Point(475, 6);
            this.butAddCalculationField.Name = "butAddCalculationField";
            this.butAddCalculationField.Size = new System.Drawing.Size(100, 47);
            this.butAddCalculationField.TabIndex = 4;
            this.butAddCalculationField.Text = "Add Calculation Field";
            this.butAddCalculationField.UseVisualStyleBackColor = false;
            this.butAddCalculationField.Click += new System.EventHandler(this.butAddCalculationField_Click);
            // 
            // butAddDataField
            // 
            this.butAddDataField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddDataField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.butAddDataField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddDataField.Location = new System.Drawing.Point(369, 6);
            this.butAddDataField.Name = "butAddDataField";
            this.butAddDataField.Size = new System.Drawing.Size(100, 47);
            this.butAddDataField.TabIndex = 3;
            this.butAddDataField.Text = "Add Data Field";
            this.butAddDataField.UseVisualStyleBackColor = false;
            this.butAddDataField.Click += new System.EventHandler(this.butAddDataField_Click);
            // 
            // butSaveTemplate
            // 
            this.butSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSaveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSaveTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSaveTemplate.ForeColor = System.Drawing.Color.Green;
            this.butSaveTemplate.Location = new System.Drawing.Point(687, 6);
            this.butSaveTemplate.Name = "butSaveTemplate";
            this.butSaveTemplate.Size = new System.Drawing.Size(100, 47);
            this.butSaveTemplate.TabIndex = 0;
            this.butSaveTemplate.Text = "Save selected Template";
            this.butSaveTemplate.UseVisualStyleBackColor = true;
            this.butSaveTemplate.Click += new System.EventHandler(this.butSaveTemplate_Click);
            // 
            // btNewTemplate
            // 
            this.butNewTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butNewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNewTemplate.Location = new System.Drawing.Point(263, 6);
            this.butNewTemplate.Name = "btNewTemplate";
            this.butNewTemplate.Size = new System.Drawing.Size(100, 47);
            this.butNewTemplate.TabIndex = 7;
            this.butNewTemplate.Text = "New Template";
            this.butNewTemplate.UseVisualStyleBackColor = false;
            this.butNewTemplate.Click += new System.EventHandler(this.butNewTemplate_Click);
            // 
            // ucGroupTemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucGroupTemplateEditor";
            this.Size = new System.Drawing.Size(1200, 500);
            this.Load += new System.EventHandler(this.ucGroupTemplateEditor_Load);
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
        private System.Windows.Forms.Button butAddCalculationField;
        private System.Windows.Forms.Button butAddConditionalField;
        private System.Windows.Forms.Button butDeleteTemplate;
        private System.Windows.Forms.Button butNewTemplate;
    }
}
