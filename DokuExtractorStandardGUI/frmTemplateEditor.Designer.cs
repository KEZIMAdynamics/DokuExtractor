namespace DokuExtractorStandardGUI
{
    partial class frmTemplateEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplateEditor));
            this.butSaveTemplate = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ucSingleTemplateEditor1 = new DokuExtractorStandardGUI.UserControlsTemplateEditor.ucSingleTemplateEditor();
            this.butAddDataField = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucTemplateSelector1 = new DokuExtractorStandardGUI.UserControlsTemplateEditor.ucTemplateSelector();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butSaveTemplate
            // 
            this.butSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSaveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSaveTemplate.Location = new System.Drawing.Point(561, 12);
            this.butSaveTemplate.Name = "butSaveTemplate";
            this.butSaveTemplate.Size = new System.Drawing.Size(170, 35);
            this.butSaveTemplate.TabIndex = 0;
            this.butSaveTemplate.Text = "Save selected Template";
            this.butSaveTemplate.UseVisualStyleBackColor = true;
            this.butSaveTemplate.Click += new System.EventHandler(this.butSaveTemplate_Click);
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
            this.splitContainer2.Size = new System.Drawing.Size(734, 579);
            this.splitContainer2.SplitterDistance = 525;
            this.splitContainer2.TabIndex = 0;
            // 
            // ucSingleTemplateEditor1
            // 
            this.ucSingleTemplateEditor1.BackColor = System.Drawing.Color.White;
            this.ucSingleTemplateEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSingleTemplateEditor1.Location = new System.Drawing.Point(0, 0);
            this.ucSingleTemplateEditor1.Name = "ucSingleTemplateEditor1";
            this.ucSingleTemplateEditor1.Size = new System.Drawing.Size(734, 525);
            this.ucSingleTemplateEditor1.TabIndex = 0;
            // 
            // butAddDataField
            // 
            this.butAddDataField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddDataField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddDataField.Location = new System.Drawing.Point(385, 12);
            this.butAddDataField.Name = "butAddDataField";
            this.butAddDataField.Size = new System.Drawing.Size(170, 35);
            this.butAddDataField.TabIndex = 3;
            this.butAddDataField.Text = "Add Data Field";
            this.butAddDataField.UseVisualStyleBackColor = true;
            this.butAddDataField.Click += new System.EventHandler(this.butAddDataField_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(1104, 579);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucTemplateSelector1
            // 
            this.ucTemplateSelector1.BackColor = System.Drawing.Color.White;
            this.ucTemplateSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemplateSelector1.Location = new System.Drawing.Point(0, 0);
            this.ucTemplateSelector1.Name = "ucTemplateSelector1";
            this.ucTemplateSelector1.Size = new System.Drawing.Size(366, 579);
            this.ucTemplateSelector1.TabIndex = 0;
            // 
            // frmTemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1104, 579);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTemplateEditor";
            this.Text = "TemplateEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTemplateEditor_FormClosing);
            this.Load += new System.EventHandler(this.frmTemplateEditor_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butSaveTemplate;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControlsTemplateEditor.ucTemplateSelector ucTemplateSelector1;
        private System.Windows.Forms.Button butAddDataField;
        private UserControlsTemplateEditor.ucSingleTemplateEditor ucSingleTemplateEditor1;
    }
}