﻿namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    partial class ucCalculationFieldTemplate
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
            this.butDeleteCalculationField = new System.Windows.Forms.Button();
            this.lblValidationExpressions = new System.Windows.Forms.Label();
            this.txtValidationExpressions = new System.Windows.Forms.TextBox();
            this.lbxFieldType = new System.Windows.Forms.ListBox();
            this.lblFieldType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCalculationExpression = new System.Windows.Forms.TextBox();
            this.lblCalculationExpression = new System.Windows.Forms.Label();
            this.cbxCalculationPrecision = new System.Windows.Forms.ComboBox();
            this.cbxValidationPrecision = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // butDeleteCalculationField
            // 
            this.butDeleteCalculationField.BackColor = System.Drawing.Color.White;
            this.butDeleteCalculationField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteCalculationField.Location = new System.Drawing.Point(12, 273);
            this.butDeleteCalculationField.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.butDeleteCalculationField.Name = "butDeleteCalculationField";
            this.butDeleteCalculationField.Size = new System.Drawing.Size(270, 23);
            this.butDeleteCalculationField.TabIndex = 20;
            this.butDeleteCalculationField.Text = "Delete Calculation Field";
            this.butDeleteCalculationField.UseVisualStyleBackColor = false;
            this.butDeleteCalculationField.Click += new System.EventHandler(this.butDeleteCalculationField_Click);
            // 
            // lblValidationExpressions
            // 
            this.lblValidationExpressions.AutoSize = true;
            this.lblValidationExpressions.Location = new System.Drawing.Point(10, 200);
            this.lblValidationExpressions.Name = "lblValidationExpressions";
            this.lblValidationExpressions.Size = new System.Drawing.Size(185, 13);
            this.lblValidationExpressions.TabIndex = 19;
            this.lblValidationExpressions.Text = "Validation Expressions (and Precision)";
            // 
            // txtValidationExpressions
            // 
            this.txtValidationExpressions.Location = new System.Drawing.Point(12, 216);
            this.txtValidationExpressions.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtValidationExpressions.Multiline = true;
            this.txtValidationExpressions.Name = "txtValidationExpressions";
            this.txtValidationExpressions.Size = new System.Drawing.Size(226, 51);
            this.txtValidationExpressions.TabIndex = 18;
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
            this.lbxFieldType.Location = new System.Drawing.Point(12, 74);
            this.lbxFieldType.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.lbxFieldType.Name = "lbxFieldType";
            this.lbxFieldType.Size = new System.Drawing.Size(270, 69);
            this.lbxFieldType.TabIndex = 17;
            // 
            // lblFieldType
            // 
            this.lblFieldType.AutoSize = true;
            this.lblFieldType.Location = new System.Drawing.Point(9, 58);
            this.lblFieldType.Name = "lblFieldType";
            this.lblFieldType.Size = new System.Drawing.Size(56, 13);
            this.lblFieldType.TabIndex = 16;
            this.lblFieldType.Text = "Field Type";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 20);
            this.txtName.TabIndex = 14;
            // 
            // txtCalculationExpression
            // 
            this.txtCalculationExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCalculationExpression.Location = new System.Drawing.Point(12, 172);
            this.txtCalculationExpression.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtCalculationExpression.Name = "txtCalculationExpression";
            this.txtCalculationExpression.Size = new System.Drawing.Size(226, 20);
            this.txtCalculationExpression.TabIndex = 21;
            // 
            // lblCalculationExpression
            // 
            this.lblCalculationExpression.AutoSize = true;
            this.lblCalculationExpression.Location = new System.Drawing.Point(10, 156);
            this.lblCalculationExpression.Name = "lblCalculationExpression";
            this.lblCalculationExpression.Size = new System.Drawing.Size(186, 13);
            this.lblCalculationExpression.TabIndex = 22;
            this.lblCalculationExpression.Text = "Calculation Expression (and Precision)";
            // 
            // cbxCalculationPrecision
            // 
            this.cbxCalculationPrecision.FormattingEnabled = true;
            this.cbxCalculationPrecision.Items.AddRange(new object[] {
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbxCalculationPrecision.Location = new System.Drawing.Point(244, 172);
            this.cbxCalculationPrecision.Name = "cbxCalculationPrecision";
            this.cbxCalculationPrecision.Size = new System.Drawing.Size(38, 21);
            this.cbxCalculationPrecision.TabIndex = 25;
            // 
            // cbxValidationPrecision
            // 
            this.cbxValidationPrecision.FormattingEnabled = true;
            this.cbxValidationPrecision.Items.AddRange(new object[] {
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbxValidationPrecision.Location = new System.Drawing.Point(244, 216);
            this.cbxValidationPrecision.Name = "cbxValidationPrecision";
            this.cbxValidationPrecision.Size = new System.Drawing.Size(38, 21);
            this.cbxValidationPrecision.TabIndex = 26;
            // 
            // ucCalculationFieldTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.cbxValidationPrecision);
            this.Controls.Add(this.cbxCalculationPrecision);
            this.Controls.Add(this.lblCalculationExpression);
            this.Controls.Add(this.txtCalculationExpression);
            this.Controls.Add(this.butDeleteCalculationField);
            this.Controls.Add(this.lblValidationExpressions);
            this.Controls.Add(this.txtValidationExpressions);
            this.Controls.Add(this.lbxFieldType);
            this.Controls.Add(this.lblFieldType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Name = "ucCalculationFieldTemplate";
            this.Size = new System.Drawing.Size(292, 303);
            this.Load += new System.EventHandler(this.ucCalculationFieldTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDeleteCalculationField;
        private System.Windows.Forms.Label lblValidationExpressions;
        private System.Windows.Forms.TextBox txtValidationExpressions;
        private System.Windows.Forms.ListBox lbxFieldType;
        private System.Windows.Forms.Label lblFieldType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCalculationExpression;
        private System.Windows.Forms.Label lblCalculationExpression;
        private System.Windows.Forms.ComboBox cbxCalculationPrecision;
        private System.Windows.Forms.ComboBox cbxValidationPrecision;
    }
}
