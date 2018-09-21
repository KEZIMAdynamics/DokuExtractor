namespace DokuExtractorGUI
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
            this.tbTemplateBox = new System.Windows.Forms.TextBox();
            this.btIgnoreTemplate = new System.Windows.Forms.Button();
            this.btSaveTemplate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbTemplateBox
            // 
            this.tbTemplateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTemplateBox.Location = new System.Drawing.Point(12, 85);
            this.tbTemplateBox.Multiline = true;
            this.tbTemplateBox.Name = "tbTemplateBox";
            this.tbTemplateBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTemplateBox.Size = new System.Drawing.Size(621, 450);
            this.tbTemplateBox.TabIndex = 0;
            // 
            // btIgnoreTemplate
            // 
            this.btIgnoreTemplate.Location = new System.Drawing.Point(12, 12);
            this.btIgnoreTemplate.Name = "btIgnoreTemplate";
            this.btIgnoreTemplate.Size = new System.Drawing.Size(242, 67);
            this.btIgnoreTemplate.TabIndex = 1;
            this.btIgnoreTemplate.Text = "Ignore Template";
            this.btIgnoreTemplate.UseVisualStyleBackColor = true;
            this.btIgnoreTemplate.Click += new System.EventHandler(this.btIgnoreTemplate_Click);
            // 
            // btSaveTemplate
            // 
            this.btSaveTemplate.Location = new System.Drawing.Point(260, 12);
            this.btSaveTemplate.Name = "btSaveTemplate";
            this.btSaveTemplate.Size = new System.Drawing.Size(373, 67);
            this.btSaveTemplate.TabIndex = 2;
            this.btSaveTemplate.Text = "Save Template";
            this.btSaveTemplate.UseVisualStyleBackColor = true;
            this.btSaveTemplate.Click += new System.EventHandler(this.btSaveTemplate_Click);
            // 
            // frmTemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 547);
            this.Controls.Add(this.btSaveTemplate);
            this.Controls.Add(this.btIgnoreTemplate);
            this.Controls.Add(this.tbTemplateBox);
            this.Name = "frmTemplateEditor";
            this.Text = "frmTemplateEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTemplateBox;
        private System.Windows.Forms.Button btIgnoreTemplate;
        private System.Windows.Forms.Button btSaveTemplate;
    }
}