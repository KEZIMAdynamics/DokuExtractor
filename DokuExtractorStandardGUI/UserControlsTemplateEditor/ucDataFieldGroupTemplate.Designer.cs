namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    partial class ucDataFieldGroupTemplate
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
            this.butDeleteDataField = new System.Windows.Forms.Button();
            this.lblTextAnchors = new System.Windows.Forms.Label();
            this.txtTextAnchors = new System.Windows.Forms.TextBox();
            this.lbxFieldType = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butDeleteDataField
            // 
            this.butDeleteDataField.BackColor = System.Drawing.Color.White;
            this.butDeleteDataField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteDataField.Location = new System.Drawing.Point(10, 270);
            this.butDeleteDataField.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.butDeleteDataField.Name = "butDeleteDataField";
            this.butDeleteDataField.Size = new System.Drawing.Size(270, 23);
            this.butDeleteDataField.TabIndex = 13;
            this.butDeleteDataField.Text = "Delete Data Field";
            this.butDeleteDataField.UseVisualStyleBackColor = false;
            this.butDeleteDataField.Click += new System.EventHandler(this.butDeleteDataField_Click);
            // 
            // lblTextAnchors
            // 
            this.lblTextAnchors.AutoSize = true;
            this.lblTextAnchors.Location = new System.Drawing.Point(7, 153);
            this.lblTextAnchors.Name = "lblTextAnchors";
            this.lblTextAnchors.Size = new System.Drawing.Size(70, 13);
            this.lblTextAnchors.TabIndex = 12;
            this.lblTextAnchors.Text = "Text Anchors";
            // 
            // txtTextAnchors
            // 
            this.txtTextAnchors.Location = new System.Drawing.Point(10, 169);
            this.txtTextAnchors.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtTextAnchors.Multiline = true;
            this.txtTextAnchors.Name = "txtTextAnchors";
            this.txtTextAnchors.Size = new System.Drawing.Size(270, 95);
            this.txtTextAnchors.TabIndex = 11;
            // 
            // lbxFieldType
            // 
            this.lbxFieldType.FormattingEnabled = true;
            this.lbxFieldType.Items.AddRange(new object[] {
            "Text",
            "Date",
            "Currency",
            "IBAN",
            "AnchorLessIBAN",
            "VatId",
            "Term"});
            this.lbxFieldType.Location = new System.Drawing.Point(10, 71);
            this.lbxFieldType.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.lbxFieldType.Name = "lbxFieldType";
            this.lbxFieldType.Size = new System.Drawing.Size(270, 69);
            this.lbxFieldType.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Field Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(10, 20);
            this.txtName.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 20);
            this.txtName.TabIndex = 7;
            // 
            // ucDataFieldGroupTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.butDeleteDataField);
            this.Controls.Add(this.lblTextAnchors);
            this.Controls.Add(this.txtTextAnchors);
            this.Controls.Add(this.lbxFieldType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "ucDataFieldGroupTemplate";
            this.Size = new System.Drawing.Size(292, 303);
            this.Load += new System.EventHandler(this.ucDataFieldGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDeleteDataField;
        private System.Windows.Forms.Label lblTextAnchors;
        private System.Windows.Forms.TextBox txtTextAnchors;
        private System.Windows.Forms.ListBox lbxFieldType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
    }
}
