namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    partial class ucGeneralPropertyEditor
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
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lblIban = new System.Windows.Forms.Label();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtIban = new System.Windows.Forms.TextBox();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(3, 10);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(110, 13);
            this.lblClassName.TabIndex = 0;
            this.lblClassName.Text = "Template Class Name";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(3, 49);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(114, 13);
            this.lblGroupName.TabIndex = 1;
            this.lblGroupName.Text = "Template Group Name";
            // 
            // lblIban
            // 
            this.lblIban.AutoSize = true;
            this.lblIban.Location = new System.Drawing.Point(3, 100);
            this.lblIban.Name = "lblIban";
            this.lblIban.Size = new System.Drawing.Size(32, 13);
            this.lblIban.TabIndex = 2;
            this.lblIban.Text = "IBAN";
            // 
            // lblKeywords
            // 
            this.lblKeywords.AutoSize = true;
            this.lblKeywords.Location = new System.Drawing.Point(3, 10);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(53, 13);
            this.lblKeywords.TabIndex = 3;
            this.lblKeywords.Text = "Keywords";
            // 
            // txtClassName
            // 
            this.txtClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClassName.Location = new System.Drawing.Point(6, 26);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(586, 20);
            this.txtClassName.TabIndex = 4;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroupName.Location = new System.Drawing.Point(6, 65);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(586, 20);
            this.txtGroupName.TabIndex = 5;
            // 
            // txtIban
            // 
            this.txtIban.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIban.Location = new System.Drawing.Point(6, 116);
            this.txtIban.Multiline = true;
            this.txtIban.Name = "txtIban";
            this.txtIban.Size = new System.Drawing.Size(586, 345);
            this.txtIban.TabIndex = 6;
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyWords.Location = new System.Drawing.Point(3, 26);
            this.txtKeyWords.Multiline = true;
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(465, 435);
            this.txtKeyWords.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblClassName);
            this.splitContainer1.Panel1.Controls.Add(this.txtIban);
            this.splitContainer1.Panel1.Controls.Add(this.txtClassName);
            this.splitContainer1.Panel1.Controls.Add(this.lblIban);
            this.splitContainer1.Panel1.Controls.Add(this.txtGroupName);
            this.splitContainer1.Panel1.Controls.Add(this.lblGroupName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtKeyWords);
            this.splitContainer1.Panel2.Controls.Add(this.lblKeywords);
            this.splitContainer1.Size = new System.Drawing.Size(1070, 464);
            this.splitContainer1.SplitterDistance = 595;
            this.splitContainer1.TabIndex = 8;
            // 
            // ucGeneralPropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucGeneralPropertyEditor";
            this.Size = new System.Drawing.Size(1070, 464);
            this.Load += new System.EventHandler(this.ucGeneralPropertyEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label lblIban;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtIban;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
