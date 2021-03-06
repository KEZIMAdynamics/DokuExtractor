﻿namespace DokuExtractorStandardGUI
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
            this.panDrop = new System.Windows.Forms.Panel();
            this.butDeleteFile = new System.Windows.Forms.Button();
            this.ucFileSelector1 = new DokuExtractorStandardGUI.UserControls.ucFileSelector();
            this.ucViewer1 = new DokuExtractorStandardGUI.UserControls.ucViewer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ucResultAndEditor1 = new DokuExtractorStandardGUI.UserControls.ucResultAndEditor();
            this.butReCalculate = new System.Windows.Forms.Button();
            this.butAddConditionalField = new System.Windows.Forms.Button();
            this.butLanguageEditor = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butAddDataField = new System.Windows.Forms.Button();
            this.butSaveTemplate = new System.Windows.Forms.Button();
            this.butGo = new System.Windows.Forms.Button();
            this.butTemplateEditor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panDrop.SuspendLayout();
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
            this.splitContainer1.SplitterDistance = 1017;
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
            this.splitContainer2.Panel1.Controls.Add(this.panDrop);
            this.splitContainer2.Panel1.Controls.Add(this.butDeleteFile);
            this.splitContainer2.Panel1.Controls.Add(this.ucFileSelector1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ucViewer1);
            this.splitContainer2.Size = new System.Drawing.Size(1017, 836);
            this.splitContainer2.SplitterDistance = 261;
            this.splitContainer2.TabIndex = 0;
            // 
            // panDrop
            // 
            this.panDrop.AllowDrop = true;
            this.panDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDrop.BackColor = System.Drawing.Color.LightGreen;
            this.panDrop.Controls.Add(this.label1);
            this.panDrop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panDrop.Location = new System.Drawing.Point(3, 745);
            this.panDrop.Name = "panDrop";
            this.panDrop.Size = new System.Drawing.Size(255, 47);
            this.panDrop.TabIndex = 10;
            this.panDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.panDrop_DragDrop);
            this.panDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.panDrop_DragEnter);
            // 
            // butDeleteFile
            // 
            this.butDeleteFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteFile.Location = new System.Drawing.Point(3, 798);
            this.butDeleteFile.Name = "butDeleteFile";
            this.butDeleteFile.Size = new System.Drawing.Size(255, 35);
            this.butDeleteFile.TabIndex = 9;
            this.butDeleteFile.Text = "Delete File";
            this.butDeleteFile.UseVisualStyleBackColor = true;
            this.butDeleteFile.Click += new System.EventHandler(this.butDeleteFile_Click);
            // 
            // ucFileSelector1
            // 
            this.ucFileSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFileSelector1.BackColor = System.Drawing.Color.White;
            this.ucFileSelector1.Location = new System.Drawing.Point(3, 3);
            this.ucFileSelector1.Name = "ucFileSelector1";
            this.ucFileSelector1.Padding = new System.Windows.Forms.Padding(3);
            this.ucFileSelector1.Size = new System.Drawing.Size(255, 734);
            this.ucFileSelector1.TabIndex = 0;
            // 
            // ucViewer1
            // 
            this.ucViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucViewer1.Location = new System.Drawing.Point(0, 0);
            this.ucViewer1.Name = "ucViewer1";
            this.ucViewer1.Size = new System.Drawing.Size(752, 836);
            this.ucViewer1.TabIndex = 0;
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
            this.splitContainer3.Panel2.Controls.Add(this.butReCalculate);
            this.splitContainer3.Panel2.Controls.Add(this.butAddConditionalField);
            this.splitContainer3.Panel2.Controls.Add(this.butLanguageEditor);
            this.splitContainer3.Panel2.Controls.Add(this.lblInstruction);
            this.splitContainer3.Panel2.Controls.Add(this.butOk);
            this.splitContainer3.Panel2.Controls.Add(this.butAddDataField);
            this.splitContainer3.Panel2.Controls.Add(this.butSaveTemplate);
            this.splitContainer3.Panel2.Controls.Add(this.butGo);
            this.splitContainer3.Panel2.Controls.Add(this.butTemplateEditor);
            this.splitContainer3.Size = new System.Drawing.Size(545, 836);
            this.splitContainer3.SplitterDistance = 700;
            this.splitContainer3.TabIndex = 0;
            // 
            // ucResultAndEditor1
            // 
            this.ucResultAndEditor1.BackColor = System.Drawing.Color.White;
            this.ucResultAndEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucResultAndEditor1.Location = new System.Drawing.Point(0, 0);
            this.ucResultAndEditor1.Name = "ucResultAndEditor1";
            this.ucResultAndEditor1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.ucResultAndEditor1.Size = new System.Drawing.Size(545, 700);
            this.ucResultAndEditor1.TabIndex = 0;
            // 
            // butReCalculate
            // 
            this.butReCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butReCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butReCalculate.ForeColor = System.Drawing.Color.Brown;
            this.butReCalculate.Location = new System.Drawing.Point(150, 41);
            this.butReCalculate.Name = "butReCalculate";
            this.butReCalculate.Size = new System.Drawing.Size(65, 88);
            this.butReCalculate.TabIndex = 9;
            this.butReCalculate.Text = "Calculate Again";
            this.butReCalculate.UseVisualStyleBackColor = true;
            this.butReCalculate.Click += new System.EventHandler(this.butReCalculate_Click);
            // 
            // butAddConditionalField
            // 
            this.butAddConditionalField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddConditionalField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butAddConditionalField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddConditionalField.Location = new System.Drawing.Point(380, 41);
            this.butAddConditionalField.Name = "butAddConditionalField";
            this.butAddConditionalField.Size = new System.Drawing.Size(153, 35);
            this.butAddConditionalField.TabIndex = 8;
            this.butAddConditionalField.Text = "Add Conditional Field";
            this.butAddConditionalField.UseVisualStyleBackColor = false;
            this.butAddConditionalField.Click += new System.EventHandler(this.butAddConditionalField_Click);
            // 
            // butLanguageEditor
            // 
            this.butLanguageEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLanguageEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLanguageEditor.Location = new System.Drawing.Point(221, 82);
            this.butLanguageEditor.Name = "butLanguageEditor";
            this.butLanguageEditor.Size = new System.Drawing.Size(100, 47);
            this.butLanguageEditor.TabIndex = 7;
            this.butLanguageEditor.Text = "Language Editor";
            this.butLanguageEditor.UseVisualStyleBackColor = true;
            this.butLanguageEditor.Click += new System.EventHandler(this.butLanguageEditor_Click);
            // 
            // lblInstruction
            // 
            this.lblInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(19, 10);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(523, 23);
            this.lblInstruction.TabIndex = 6;
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOk.ForeColor = System.Drawing.Color.Green;
            this.butOk.Location = new System.Drawing.Point(79, 41);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(65, 88);
            this.butOk.TabIndex = 5;
            this.butOk.Text = "OK!";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butAddDataField
            // 
            this.butAddDataField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddDataField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butAddDataField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddDataField.Location = new System.Drawing.Point(221, 41);
            this.butAddDataField.Name = "butAddDataField";
            this.butAddDataField.Size = new System.Drawing.Size(153, 35);
            this.butAddDataField.TabIndex = 3;
            this.butAddDataField.Text = "Add Data Field";
            this.butAddDataField.UseVisualStyleBackColor = false;
            this.butAddDataField.Click += new System.EventHandler(this.butAddDataField_Click);
            // 
            // butSaveTemplate
            // 
            this.butSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSaveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSaveTemplate.ForeColor = System.Drawing.Color.Green;
            this.butSaveTemplate.Location = new System.Drawing.Point(327, 82);
            this.butSaveTemplate.Name = "butSaveTemplate";
            this.butSaveTemplate.Size = new System.Drawing.Size(100, 47);
            this.butSaveTemplate.TabIndex = 2;
            this.butSaveTemplate.Text = "Save Template";
            this.butSaveTemplate.UseVisualStyleBackColor = true;
            this.butSaveTemplate.Click += new System.EventHandler(this.butSaveTemplate_Click);
            // 
            // butGo
            // 
            this.butGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butGo.ForeColor = System.Drawing.Color.Blue;
            this.butGo.Location = new System.Drawing.Point(8, 41);
            this.butGo.Name = "butGo";
            this.butGo.Size = new System.Drawing.Size(65, 88);
            this.butGo.TabIndex = 1;
            this.butGo.Text = "Go!";
            this.butGo.UseVisualStyleBackColor = true;
            this.butGo.Click += new System.EventHandler(this.butGo_Click);
            // 
            // butTemplateEditor
            // 
            this.butTemplateEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butTemplateEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTemplateEditor.Location = new System.Drawing.Point(433, 82);
            this.butTemplateEditor.Name = "butTemplateEditor";
            this.butTemplateEditor.Size = new System.Drawing.Size(100, 47);
            this.butTemplateEditor.TabIndex = 0;
            this.butTemplateEditor.Text = "Template Editor";
            this.butTemplateEditor.UseVisualStyleBackColor = true;
            this.butTemplateEditor.Click += new System.EventHandler(this.butTemplateEditor_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "DROPZONE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Text = "Doku Extractor";
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
            this.panDrop.ResumeLayout(false);
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
        private System.Windows.Forms.Button butAddConditionalField;
        private System.Windows.Forms.Button butDeleteFile;
        private System.Windows.Forms.Button butReCalculate;
        private System.Windows.Forms.Panel panDrop;
        private System.Windows.Forms.Label label1;
    }
}

