namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    partial class ucConditionalFieldTemplate
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
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblConditionValues = new System.Windows.Forms.Label();
            this.dgvConditions = new System.Windows.Forms.DataGridView();
            this.conditionsBindingListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.butDeleteConditionalField = new System.Windows.Forms.Button();
            this.butAddCondition = new System.Windows.Forms.Button();
            this.butDeleteCondition = new System.Windows.Forms.Button();
            this.lblConditionalFieldType = new System.Windows.Forms.Label();
            this.cbxConditionalFieldType = new System.Windows.Forms.ComboBox();
            this.colCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucConditionalFieldClassTemplateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionsBindingListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucConditionalFieldClassTemplateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 10;
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
            this.txtName.TabIndex = 9;
            // 
            // lblConditionValues
            // 
            this.lblConditionValues.AutoSize = true;
            this.lblConditionValues.Location = new System.Drawing.Point(9, 98);
            this.lblConditionValues.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblConditionValues.Name = "lblConditionValues";
            this.lblConditionValues.Size = new System.Drawing.Size(56, 13);
            this.lblConditionValues.TabIndex = 11;
            this.lblConditionValues.Text = "Conditions";
            // 
            // dgvConditions
            // 
            this.dgvConditions.AllowUserToAddRows = false;
            this.dgvConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConditions.AutoGenerateColumns = false;
            this.dgvConditions.BackgroundColor = System.Drawing.Color.White;
            this.dgvConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCondition,
            this.colValue});
            this.dgvConditions.DataSource = this.conditionsBindingListBindingSource;
            this.dgvConditions.Location = new System.Drawing.Point(10, 114);
            this.dgvConditions.Name = "dgvConditions";
            this.dgvConditions.Size = new System.Drawing.Size(236, 97);
            this.dgvConditions.TabIndex = 12;
            this.dgvConditions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConditions_CellDoubleClick);
            // 
            // conditionsBindingListBindingSource
            // 
            this.conditionsBindingListBindingSource.DataMember = "ConditionsBindingList";
            this.conditionsBindingListBindingSource.DataSource = this.ucConditionalFieldClassTemplateBindingSource;
            // 
            // butDeleteConditionalField
            // 
            this.butDeleteConditionalField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteConditionalField.BackColor = System.Drawing.Color.White;
            this.butDeleteConditionalField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteConditionalField.Location = new System.Drawing.Point(10, 217);
            this.butDeleteConditionalField.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.butDeleteConditionalField.Name = "butDeleteConditionalField";
            this.butDeleteConditionalField.Size = new System.Drawing.Size(280, 23);
            this.butDeleteConditionalField.TabIndex = 14;
            this.butDeleteConditionalField.Text = "Delete Conditional Field";
            this.butDeleteConditionalField.UseVisualStyleBackColor = false;
            this.butDeleteConditionalField.Click += new System.EventHandler(this.butDeleteConditionalField_Click);
            // 
            // butAddCondition
            // 
            this.butAddCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAddCondition.BackColor = System.Drawing.Color.White;
            this.butAddCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddCondition.Location = new System.Drawing.Point(252, 114);
            this.butAddCondition.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.butAddCondition.Name = "butAddCondition";
            this.butAddCondition.Size = new System.Drawing.Size(38, 45);
            this.butAddCondition.TabIndex = 15;
            this.butAddCondition.Text = "Add";
            this.butAddCondition.UseVisualStyleBackColor = false;
            this.butAddCondition.Click += new System.EventHandler(this.butAddCondition_Click);
            // 
            // butDeleteCondition
            // 
            this.butDeleteCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteCondition.BackColor = System.Drawing.Color.White;
            this.butDeleteCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteCondition.Location = new System.Drawing.Point(252, 166);
            this.butDeleteCondition.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.butDeleteCondition.Name = "butDeleteCondition";
            this.butDeleteCondition.Size = new System.Drawing.Size(38, 45);
            this.butDeleteCondition.TabIndex = 16;
            this.butDeleteCondition.Text = "Del";
            this.butDeleteCondition.UseVisualStyleBackColor = false;
            this.butDeleteCondition.Click += new System.EventHandler(this.butDeleteCondition_Click);
            // 
            // lblConditionalFieldType
            // 
            this.lblConditionalFieldType.AutoSize = true;
            this.lblConditionalFieldType.Location = new System.Drawing.Point(9, 52);
            this.lblConditionalFieldType.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblConditionalFieldType.Name = "lblConditionalFieldType";
            this.lblConditionalFieldType.Size = new System.Drawing.Size(111, 13);
            this.lblConditionalFieldType.TabIndex = 17;
            this.lblConditionalFieldType.Text = "Conditional Field Type";
            // 
            // cbxConditionalFieldType
            // 
            this.cbxConditionalFieldType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxConditionalFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConditionalFieldType.FormattingEnabled = true;
            this.cbxConditionalFieldType.Items.AddRange(new object[] {
            "Text",
            "Bool",
            "Number",
            "Date",
            "UserId",
            "UserGroupId",
            "UserOrUserGroupId"});
            this.cbxConditionalFieldType.Location = new System.Drawing.Point(10, 68);
            this.cbxConditionalFieldType.Name = "cbxConditionalFieldType";
            this.cbxConditionalFieldType.Size = new System.Drawing.Size(280, 21);
            this.cbxConditionalFieldType.TabIndex = 18;
            // 
            // colCondition
            // 
            this.colCondition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCondition.DataPropertyName = "Condition";
            this.colCondition.HeaderText = "Condition";
            this.colCondition.Name = "colCondition";
            this.colCondition.Width = 76;
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colValue.DataPropertyName = "Value";
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Width = 59;
            // 
            // ucConditionalFieldClassTemplateBindingSource
            // 
            this.ucConditionalFieldClassTemplateBindingSource.DataSource = typeof(DokuExtractorStandardGUI.UserControlsTemplateEditor.ucConditionalFieldTemplate);
            // 
            // ucConditionalFieldTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.cbxConditionalFieldType);
            this.Controls.Add(this.lblConditionalFieldType);
            this.Controls.Add(this.butDeleteCondition);
            this.Controls.Add(this.butAddCondition);
            this.Controls.Add(this.butDeleteConditionalField);
            this.Controls.Add(this.dgvConditions);
            this.Controls.Add(this.lblConditionValues);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Name = "ucConditionalFieldTemplate";
            this.Size = new System.Drawing.Size(300, 250);
            this.Load += new System.EventHandler(this.ucConditionalFieldClassTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConditions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionsBindingListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucConditionalFieldClassTemplateBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblConditionValues;
        private System.Windows.Forms.DataGridView dgvConditions;
        private System.Windows.Forms.Button butDeleteConditionalField;
        private System.Windows.Forms.Button butAddCondition;
        private System.Windows.Forms.Button butDeleteCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.BindingSource conditionsBindingListBindingSource;
        private System.Windows.Forms.BindingSource ucConditionalFieldClassTemplateBindingSource;
        private System.Windows.Forms.Label lblConditionalFieldType;
        private System.Windows.Forms.ComboBox cbxConditionalFieldType;
    }
}
