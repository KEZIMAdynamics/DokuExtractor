namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    partial class ucDataField
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.txtName.Location = new System.Drawing.Point(3, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(286, 20);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Field Type";
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
            this.lbxFieldType.Location = new System.Drawing.Point(3, 71);
            this.lbxFieldType.Name = "lbxFieldType";
            this.lbxFieldType.Size = new System.Drawing.Size(284, 69);
            this.lbxFieldType.TabIndex = 3;
            // 
            // txtRegexExpression
            // 
            this.txtRegexExpression.Location = new System.Drawing.Point(3, 169);
            this.txtRegexExpression.Multiline = true;
            this.txtRegexExpression.Name = "txtRegexExpression";
            this.txtRegexExpression.Size = new System.Drawing.Size(284, 99);
            this.txtRegexExpression.TabIndex = 4;
            // 
            // lblRegexExpression
            // 
            this.lblRegexExpression.AutoSize = true;
            this.lblRegexExpression.Location = new System.Drawing.Point(0, 153);
            this.lblRegexExpression.Name = "lblRegexExpression";
            this.lblRegexExpression.Size = new System.Drawing.Size(97, 13);
            this.lblRegexExpression.TabIndex = 5;
            this.lblRegexExpression.Text = "Regex Expressions";
            // 
            // butDeleteDataField
            // 
            this.butDeleteDataField.Location = new System.Drawing.Point(3, 277);
            this.butDeleteDataField.Name = "butDeleteDataField";
            this.butDeleteDataField.Size = new System.Drawing.Size(284, 23);
            this.butDeleteDataField.TabIndex = 6;
            this.butDeleteDataField.Text = "Delete Data Field";
            this.butDeleteDataField.UseVisualStyleBackColor = true;
            this.butDeleteDataField.Click += new System.EventHandler(this.butDeleteDataField_Click);
            // 
            // ucDataField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.butDeleteDataField);
            this.Controls.Add(this.lblRegexExpression);
            this.Controls.Add(this.txtRegexExpression);
            this.Controls.Add(this.lbxFieldType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "ucDataField";
            this.Size = new System.Drawing.Size(292, 303);
            this.Load += new System.EventHandler(this.ucDataField_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxFieldType;
        private System.Windows.Forms.TextBox txtRegexExpression;
        private System.Windows.Forms.Label lblRegexExpression;
        private System.Windows.Forms.Button butDeleteDataField;
    }
}
