using DokuExtractorStandardGUI.Logic;
using System;

namespace DokuExtractorStandardGUI.UserControls
{
    partial class ucExtractedData
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
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblTemplateGroupName = new System.Windows.Forms.Label();
            this.lblTemplateClassName = new System.Windows.Forms.Label();
            this.ucExtractedDataFields1 = (ucExtractedDataFields)Activator.CreateInstance(UserControlSelector.ExtractedDataFieldsUserControl);
            this.ucExtractedCalculationFields1 = (ucExtractedCalculationFields)Activator.CreateInstance(UserControlSelector.ExtractedCalculationFieldsUserControl);
            this.ucExtractedConditionalFields1 = (ucExtractedConditionalFields)Activator.CreateInstance(UserControlSelector.ExtractedConditionalFieldsUserControl);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGroupName
            // 
            this.txtGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroupName.Enabled = false;
            this.txtGroupName.Location = new System.Drawing.Point(138, 32);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(390, 20);
            this.txtGroupName.TabIndex = 9;
            // 
            // txtClassName
            // 
            this.txtClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClassName.Enabled = false;
            this.txtClassName.Location = new System.Drawing.Point(138, 6);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(390, 20);
            this.txtClassName.TabIndex = 8;
            // 
            // lblTemplateGroupName
            // 
            this.lblTemplateGroupName.AutoSize = true;
            this.lblTemplateGroupName.Location = new System.Drawing.Point(3, 35);
            this.lblTemplateGroupName.Name = "lblTemplateGroupName";
            this.lblTemplateGroupName.Size = new System.Drawing.Size(114, 13);
            this.lblTemplateGroupName.TabIndex = 7;
            this.lblTemplateGroupName.Text = "Template Group Name";
            // 
            // lblTemplateClassName
            // 
            this.lblTemplateClassName.AutoSize = true;
            this.lblTemplateClassName.Location = new System.Drawing.Point(3, 9);
            this.lblTemplateClassName.Name = "lblTemplateClassName";
            this.lblTemplateClassName.Size = new System.Drawing.Size(110, 13);
            this.lblTemplateClassName.TabIndex = 6;
            this.lblTemplateClassName.Text = "Template Class Name";
            // 
            // ucExtractedDataFields1
            // 
            this.ucExtractedDataFields1.BackColor = System.Drawing.Color.White;
            this.ucExtractedDataFields1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExtractedDataFields1.Location = new System.Drawing.Point(0, 0);
            this.ucExtractedDataFields1.Name = "ucExtractedDataFields1";
            this.ucExtractedDataFields1.Size = new System.Drawing.Size(531, 184);
            this.ucExtractedDataFields1.TabIndex = 0;
            // 
            // ucExtractedCalculationFields1
            // 
            this.ucExtractedCalculationFields1.BackColor = System.Drawing.Color.White;
            this.ucExtractedCalculationFields1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExtractedCalculationFields1.Location = new System.Drawing.Point(0, 0);
            this.ucExtractedCalculationFields1.Name = "ucExtractedCalculationFields1";
            this.ucExtractedCalculationFields1.Size = new System.Drawing.Size(531, 139);
            this.ucExtractedCalculationFields1.TabIndex = 0;
            // 
            // ucExtractedConditionalFields1
            // 
            this.ucExtractedConditionalFields1.BackColor = System.Drawing.Color.White;
            this.ucExtractedConditionalFields1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExtractedConditionalFields1.Location = new System.Drawing.Point(0, 0);
            this.ucExtractedConditionalFields1.Name = "ucExtractedConditionalFields1";
            this.ucExtractedConditionalFields1.Size = new System.Drawing.Size(531, 172);
            this.ucExtractedConditionalFields1.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn1.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn2.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn3.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn4.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn5.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn6.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FieldType";
            this.dataGridViewTextBoxColumn7.HeaderText = "FieldType";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblTemplateClassName);
            this.splitContainer1.Panel1.Controls.Add(this.lblTemplateGroupName);
            this.splitContainer1.Panel1.Controls.Add(this.txtGroupName);
            this.splitContainer1.Panel1.Controls.Add(this.txtClassName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(531, 600);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ucExtractedDataFields1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(531, 503);
            this.splitContainer2.SplitterDistance = 184;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ucExtractedCalculationFields1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ucExtractedConditionalFields1);
            this.splitContainer3.Size = new System.Drawing.Size(531, 315);
            this.splitContainer3.SplitterDistance = 139;
            this.splitContainer3.TabIndex = 0;
            // 
            // ucExtractedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucExtractedData";
            this.Size = new System.Drawing.Size(531, 600);
            this.Load += new System.EventHandler(this.ucExtractedData_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label lblTemplateGroupName;
        private System.Windows.Forms.Label lblTemplateClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private ucExtractedConditionalFields ucExtractedConditionalFields1;
        private ucExtractedCalculationFields ucExtractedCalculationFields1;
        private ucExtractedDataFields ucExtractedDataFields1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}
