namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    partial class ucDataFieldClassTemplate
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFieldType = new System.Windows.Forms.Label();
            this.lbxFieldType = new System.Windows.Forms.ListBox();
            this.txtRegexExpression = new System.Windows.Forms.TextBox();
            this.lblRegexExpression = new System.Windows.Forms.Label();
            this.butDeleteDataField = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(10, 20);
            this.txtName.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblFieldType
            // 
            this.lblFieldType.AutoSize = true;
            this.lblFieldType.Location = new System.Drawing.Point(7, 55);
            this.lblFieldType.Name = "lblFieldType";
            this.lblFieldType.Size = new System.Drawing.Size(56, 13);
            this.lblFieldType.TabIndex = 2;
            this.lblFieldType.Text = "Field Type";
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
            this.lbxFieldType.TabIndex = 3;
            // 
            // txtRegexExpression
            // 
            this.txtRegexExpression.Location = new System.Drawing.Point(10, 169);
            this.txtRegexExpression.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtRegexExpression.Multiline = true;
            this.txtRegexExpression.Name = "txtRegexExpression";
            this.txtRegexExpression.Size = new System.Drawing.Size(270, 95);
            this.txtRegexExpression.TabIndex = 4;
            // 
            // lblRegexExpression
            // 
            this.lblRegexExpression.AutoSize = true;
            this.lblRegexExpression.Location = new System.Drawing.Point(7, 153);
            this.lblRegexExpression.Name = "lblRegexExpression";
            this.lblRegexExpression.Size = new System.Drawing.Size(97, 13);
            this.lblRegexExpression.TabIndex = 5;
            this.lblRegexExpression.Text = "Regex Expressions";
            // 
            // butDeleteDataField
            // 
            this.butDeleteDataField.BackColor = System.Drawing.Color.White;
            this.butDeleteDataField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteDataField.Location = new System.Drawing.Point(10, 270);
            this.butDeleteDataField.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.butDeleteDataField.Name = "butDeleteDataField";
            this.butDeleteDataField.Size = new System.Drawing.Size(270, 23);
            this.butDeleteDataField.TabIndex = 6;
            this.butDeleteDataField.Text = "Delete Data Field";
            this.butDeleteDataField.UseVisualStyleBackColor = false;
            this.butDeleteDataField.Click += new System.EventHandler(this.butDeleteDataField_Click);
            // 
            // ucDataFieldClassTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.butDeleteDataField);
            this.Controls.Add(this.lblRegexExpression);
            this.Controls.Add(this.txtRegexExpression);
            this.Controls.Add(this.lbxFieldType);
            this.Controls.Add(this.lblFieldType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Name = "ucDataFieldClassTemplate";
            this.Size = new System.Drawing.Size(292, 303);
            this.Load += new System.EventHandler(this.ucDataField_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFieldType;
        private System.Windows.Forms.ListBox lbxFieldType;
        private System.Windows.Forms.TextBox txtRegexExpression;
        private System.Windows.Forms.Label lblRegexExpression;
        private System.Windows.Forms.Button butDeleteDataField;
    }
}
