namespace DokuExtractorStandardGUI
{
    partial class frmExtractorStandard
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtractorStandard));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ucFileSelector1 = new DokuExtractorStandardGUI.UserControls.ucFileSelector();
            this.ucViewer1 = new DokuExtractorStandardGUI.UserControls.ucViewer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ucResultAndEditor1 = new DokuExtractorStandardGUI.UserControls.ucResultAndEditor();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butAddDataField = new System.Windows.Forms.Button();
            this.butSaveTemplate = new System.Windows.Forms.Button();
            this.butGo = new System.Windows.Forms.Button();
            this.butTemplateEditor = new System.Windows.Forms.Button();
            this.butLanguageEditor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1566, 836);
            this.splitContainer1.SplitterDistance = 1062;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ucFileSelector1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ucViewer1);
            this.splitContainer2.Size = new System.Drawing.Size(1062, 836);
            this.splitContainer2.SplitterDistance = 308;
            this.splitContainer2.TabIndex = 0;
            // 
            // ucFileSelector1
            // 
            this.ucFileSelector1.BackColor = System.Drawing.Color.White;
            this.ucFileSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFileSelector1.Location = new System.Drawing.Point(0, 0);
            this.ucFileSelector1.Name = "ucFileSelector1";
            this.ucFileSelector1.Padding = new System.Windows.Forms.Padding(3);
            this.ucFileSelector1.Size = new System.Drawing.Size(308, 836);
            this.ucFileSelector1.TabIndex = 0;
            // 
            // ucViewer1
            // 
            this.ucViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucViewer1.Location = new System.Drawing.Point(0, 0);
            this.ucViewer1.Name = "ucViewer1";
            this.ucViewer1.Size = new System.Drawing.Size(750, 836);
            this.ucViewer1.TabIndex = 0;
            this.ucViewer1.ViewerPluginPath = "G:\\DokuExtractor\\GdPicturePdfViewer\\bin\\Debug\\GdPicturePdfViewer.dll";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ucResultAndEditor1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.butLanguageEditor);
            this.splitContainer3.Panel2.Controls.Add(this.lblInstruction);
            this.splitContainer3.Panel2.Controls.Add(this.butOk);
            this.splitContainer3.Panel2.Controls.Add(this.butAddDataField);
            this.splitContainer3.Panel2.Controls.Add(this.butSaveTemplate);
            this.splitContainer3.Panel2.Controls.Add(this.butGo);
            this.splitContainer3.Panel2.Controls.Add(this.butTemplateEditor);
            this.splitContainer3.Size = new System.Drawing.Size(500, 836);
            this.splitContainer3.SplitterDistance = 700;
            this.splitContainer3.TabIndex = 0;
            // 
            // ucResultAndEditor1
            // 
            this.ucResultAndEditor1.BackColor = System.Drawing.Color.White;
            this.ucResultAndEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucResultAndEditor1.Location = new System.Drawing.Point(0, 0);
            this.ucResultAndEditor1.Name = "ucResultAndEditor1";
            this.ucResultAndEditor1.Size = new System.Drawing.Size(500, 700);
            this.ucResultAndEditor1.TabIndex = 0;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(19, 10);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(478, 23);
            this.lblInstruction.TabIndex = 6;
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOk.Location = new System.Drawing.Point(170, 53);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(105, 76);
            this.butOk.TabIndex = 5;
            this.butOk.Text = "OK!";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butAddDataField
            // 
            this.butAddDataField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddDataField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddDataField.Location = new System.Drawing.Point(281, 53);
            this.butAddDataField.Name = "butAddDataField";
            this.butAddDataField.Size = new System.Drawing.Size(105, 35);
            this.butAddDataField.TabIndex = 3;
            this.butAddDataField.Text = "Add Data Field";
            this.butAddDataField.UseVisualStyleBackColor = true;
            this.butAddDataField.Click += new System.EventHandler(this.butAddDataField_Click);
            // 
            // butSaveTemplate
            // 
            this.butSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSaveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSaveTemplate.Location = new System.Drawing.Point(392, 53);
            this.butSaveTemplate.Name = "butSaveTemplate";
            this.butSaveTemplate.Size = new System.Drawing.Size(105, 35);
            this.butSaveTemplate.TabIndex = 2;
            this.butSaveTemplate.Text = "Save Template";
            this.butSaveTemplate.UseVisualStyleBackColor = true;
            this.butSaveTemplate.Click += new System.EventHandler(this.butSaveTemplate_Click);
            // 
            // butGo
            // 
            this.butGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butGo.Location = new System.Drawing.Point(59, 53);
            this.butGo.Name = "butGo";
            this.butGo.Size = new System.Drawing.Size(105, 76);
            this.butGo.TabIndex = 1;
            this.butGo.Text = "Go!";
            this.butGo.UseVisualStyleBackColor = true;
            this.butGo.Click += new System.EventHandler(this.butGo_Click);
            // 
            // butTemplateEditor
            // 
            this.butTemplateEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butTemplateEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTemplateEditor.Location = new System.Drawing.Point(392, 94);
            this.butTemplateEditor.Name = "butTemplateEditor";
            this.butTemplateEditor.Size = new System.Drawing.Size(105, 35);
            this.butTemplateEditor.TabIndex = 0;
            this.butTemplateEditor.Text = "Template Editor";
            this.butTemplateEditor.UseVisualStyleBackColor = true;
            this.butTemplateEditor.Click += new System.EventHandler(this.butTemplateEditor_Click);
            // 
            // butLanguageEditor
            // 
            this.butLanguageEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLanguageEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLanguageEditor.Location = new System.Drawing.Point(281, 94);
            this.butLanguageEditor.Name = "butLanguageEditor";
            this.butLanguageEditor.Size = new System.Drawing.Size(105, 35);
            this.butLanguageEditor.TabIndex = 7;
            this.butLanguageEditor.Text = "Language Editor";
            this.butLanguageEditor.UseVisualStyleBackColor = true;
            this.butLanguageEditor.Click += new System.EventHandler(this.butLanguageEditor_Click);
            // 
            // frmExtractorStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1566, 836);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExtractorStandard";
            this.Text = "DokuExtractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExtractorStandard_FormClosing);
            this.Load += new System.EventHandler(this.frmExtractorStandard_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private UserControls.ucFileSelector ucFileSelector1;
        private UserControls.ucViewer ucViewer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button butTemplateEditor;
        private System.Windows.Forms.Button butGo;
        private System.Windows.Forms.Button butSaveTemplate;
        private UserControls.ucResultAndEditor ucResultAndEditor1;
        private System.Windows.Forms.Button butAddDataField;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Button butLanguageEditor;
    }
}

