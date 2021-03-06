﻿namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
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
            this.lblFieldType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbxFieldType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // butDeleteDataField
            // 
            this.butDeleteDataField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteDataField.BackColor = System.Drawing.Color.White;
            this.butDeleteDataField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteDataField.Location = new System.Drawing.Point(10, 217);
            this.butDeleteDataField.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.butDeleteDataField.Name = "butDeleteDataField";
            this.butDeleteDataField.Size = new System.Drawing.Size(280, 23);
            this.butDeleteDataField.TabIndex = 13;
            this.butDeleteDataField.Text = "Delete Data Field";
            this.butDeleteDataField.UseVisualStyleBackColor = false;
            this.butDeleteDataField.Click += new System.EventHandler(this.butDeleteDataField_Click);
            // 
            // lblTextAnchors
            // 
            this.lblTextAnchors.AutoSize = true;
            this.lblTextAnchors.Location = new System.Drawing.Point(9, 98);
            this.lblTextAnchors.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblTextAnchors.Name = "lblTextAnchors";
            this.lblTextAnchors.Size = new System.Drawing.Size(70, 13);
            this.lblTextAnchors.TabIndex = 12;
            this.lblTextAnchors.Text = "Text Anchors";
            // 
            // txtTextAnchors
            // 
            this.txtTextAnchors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextAnchors.Location = new System.Drawing.Point(10, 114);
            this.txtTextAnchors.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtTextAnchors.Multiline = true;
            this.txtTextAnchors.Name = "txtTextAnchors";
            this.txtTextAnchors.Size = new System.Drawing.Size(280, 97);
            this.txtTextAnchors.TabIndex = 11;
            // 
            // lblFieldType
            // 
            this.lblFieldType.AutoSize = true;
            this.lblFieldType.Location = new System.Drawing.Point(9, 52);
            this.lblFieldType.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblFieldType.Name = "lblFieldType";
            this.lblFieldType.Size = new System.Drawing.Size(56, 13);
            this.lblFieldType.TabIndex = 9;
            this.lblFieldType.Text = "Field Type";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(10, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 20);
            this.txtName.TabIndex = 7;
            // 
            // cbxFieldType
            // 
            this.cbxFieldType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFieldType.FormattingEnabled = true;
            this.cbxFieldType.Items.AddRange(new object[] {
            "Text",
            "Date",
            "Currency",
            "IBAN",
            "AnchorLessIBAN",
            "VatId",
            "Term"});
            this.cbxFieldType.Location = new System.Drawing.Point(10, 68);
            this.cbxFieldType.Name = "cbxFieldType";
            this.cbxFieldType.Size = new System.Drawing.Size(280, 21);
            this.cbxFieldType.TabIndex = 14;
            // 
            // ucDataFieldGroupTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.cbxFieldType);
            this.Controls.Add(this.butDeleteDataField);
            this.Controls.Add(this.lblTextAnchors);
            this.Controls.Add(this.txtTextAnchors);
            this.Controls.Add(this.lblFieldType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Name = "ucDataFieldGroupTemplate";
            this.Size = new System.Drawing.Size(300, 250);
            this.Load += new System.EventHandler(this.ucDataFieldGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDeleteDataField;
        private System.Windows.Forms.Label lblTextAnchors;
        private System.Windows.Forms.TextBox txtTextAnchors;
        private System.Windows.Forms.Label lblFieldType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbxFieldType;
    }
}
