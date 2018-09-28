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
            this.txtRegexOrPosition = new System.Windows.Forms.TextBox();
            this.lblRegexOrPosition = new System.Windows.Forms.Label();
            this.butDeleteDataField = new System.Windows.Forms.Button();
            this.cbxFieldType = new System.Windows.Forms.ComboBox();
            this.butStartRegexOrPositionHelper = new System.Windows.Forms.Button();
            this.cbxFieldMode = new System.Windows.Forms.ComboBox();
            this.lblFieldMode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(10, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblFieldType
            // 
            this.lblFieldType.AutoSize = true;
            this.lblFieldType.Location = new System.Drawing.Point(9, 52);
            this.lblFieldType.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblFieldType.Name = "lblFieldType";
            this.lblFieldType.Size = new System.Drawing.Size(56, 13);
            this.lblFieldType.TabIndex = 2;
            this.lblFieldType.Text = "Field Type";
            // 
            // txtRegexOrPosition
            // 
            this.txtRegexOrPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegexOrPosition.BackColor = System.Drawing.Color.Yellow;
            this.txtRegexOrPosition.Location = new System.Drawing.Point(10, 143);
            this.txtRegexOrPosition.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtRegexOrPosition.Multiline = true;
            this.txtRegexOrPosition.Name = "txtRegexOrPosition";
            this.txtRegexOrPosition.Size = new System.Drawing.Size(280, 68);
            this.txtRegexOrPosition.TabIndex = 4;
            this.txtRegexOrPosition.TextChanged += new System.EventHandler(this.txtRegexOrPosition_TextChanged);
            // 
            // lblRegexOrPosition
            // 
            this.lblRegexOrPosition.AutoSize = true;
            this.lblRegexOrPosition.Location = new System.Drawing.Point(9, 98);
            this.lblRegexOrPosition.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblRegexOrPosition.Name = "lblRegexOrPosition";
            this.lblRegexOrPosition.Size = new System.Drawing.Size(97, 13);
            this.lblRegexOrPosition.TabIndex = 5;
            this.lblRegexOrPosition.Text = "Regex Expressions";
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
            this.butDeleteDataField.TabIndex = 6;
            this.butDeleteDataField.Text = "Delete Data Field";
            this.butDeleteDataField.UseVisualStyleBackColor = false;
            this.butDeleteDataField.Click += new System.EventHandler(this.butDeleteDataField_Click);
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
            this.cbxFieldType.Size = new System.Drawing.Size(137, 21);
            this.cbxFieldType.TabIndex = 7;
            // 
            // butStartRegexOrPositionHelper
            // 
            this.butStartRegexOrPositionHelper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butStartRegexOrPositionHelper.BackColor = System.Drawing.Color.White;
            this.butStartRegexOrPositionHelper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butStartRegexOrPositionHelper.Location = new System.Drawing.Point(10, 114);
            this.butStartRegexOrPositionHelper.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.butStartRegexOrPositionHelper.Name = "butStartRegexOrPositionHelper";
            this.butStartRegexOrPositionHelper.Size = new System.Drawing.Size(280, 23);
            this.butStartRegexOrPositionHelper.TabIndex = 8;
            this.butStartRegexOrPositionHelper.Text = "Start Regex Expression Helper";
            this.butStartRegexOrPositionHelper.UseVisualStyleBackColor = false;
            this.butStartRegexOrPositionHelper.Click += new System.EventHandler(this.butStartRegexOrPositionHelper_Click);
            // 
            // cbxFieldMode
            // 
            this.cbxFieldMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFieldMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFieldMode.FormattingEnabled = true;
            this.cbxFieldMode.Items.AddRange(new object[] {
            "Regex",
            "Position"});
            this.cbxFieldMode.Location = new System.Drawing.Point(153, 68);
            this.cbxFieldMode.Name = "cbxFieldMode";
            this.cbxFieldMode.Size = new System.Drawing.Size(137, 21);
            this.cbxFieldMode.TabIndex = 9;
            this.cbxFieldMode.SelectedIndexChanged += new System.EventHandler(this.cbxFieldMode_SelectedIndexChanged);
            // 
            // lblFieldMode
            // 
            this.lblFieldMode.AutoSize = true;
            this.lblFieldMode.Location = new System.Drawing.Point(152, 52);
            this.lblFieldMode.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblFieldMode.Name = "lblFieldMode";
            this.lblFieldMode.Size = new System.Drawing.Size(59, 13);
            this.lblFieldMode.TabIndex = 10;
            this.lblFieldMode.Text = "Field Mode";
            // 
            // ucDataFieldClassTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.lblFieldMode);
            this.Controls.Add(this.cbxFieldMode);
            this.Controls.Add(this.butStartRegexOrPositionHelper);
            this.Controls.Add(this.cbxFieldType);
            this.Controls.Add(this.butDeleteDataField);
            this.Controls.Add(this.lblRegexOrPosition);
            this.Controls.Add(this.txtRegexOrPosition);
            this.Controls.Add(this.lblFieldType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Name = "ucDataFieldClassTemplate";
            this.Size = new System.Drawing.Size(300, 250);
            this.Load += new System.EventHandler(this.ucDataField_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFieldType;
        private System.Windows.Forms.TextBox txtRegexOrPosition;
        private System.Windows.Forms.Label lblRegexOrPosition;
        private System.Windows.Forms.Button butDeleteDataField;
        private System.Windows.Forms.ComboBox cbxFieldType;
        private System.Windows.Forms.Button butStartRegexOrPositionHelper;
        private System.Windows.Forms.ComboBox cbxFieldMode;
        private System.Windows.Forms.Label lblFieldMode;
    }
}
