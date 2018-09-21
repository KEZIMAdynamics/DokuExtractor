namespace DokuExtractorStandardGUI
{
    partial class frmGroupTemplateSelection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupTemplateSelection));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butOk = new System.Windows.Forms.Button();
            this.groupTemplatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTemplateGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frmGroupTemplateSelectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTemplatesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmGroupTemplateSelectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTemplateGroupName});
            this.dataGridView1.DataSource = this.groupTemplatesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(465, 199);
            this.dataGridView1.TabIndex = 0;
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOk.BackColor = System.Drawing.Color.White;
            this.butOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOk.Location = new System.Drawing.Point(377, 217);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(100, 47);
            this.butOk.TabIndex = 1;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = false;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // groupTemplatesBindingSource
            // 
            this.groupTemplatesBindingSource.DataMember = "GroupTemplates";
            this.groupTemplatesBindingSource.DataSource = this.frmGroupTemplateSelectionBindingSource;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PreSelectionCondition";
            this.dataGridViewTextBoxColumn1.HeaderText = "PreSelectionCondition";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // colTemplateGroupName
            // 
            this.colTemplateGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTemplateGroupName.DataPropertyName = "TemplateGroupName";
            this.colTemplateGroupName.HeaderText = "TemplateGroupName";
            this.colTemplateGroupName.Name = "colTemplateGroupName";
            this.colTemplateGroupName.ReadOnly = true;
            // 
            // frmGroupTemplateSelectionBindingSource
            // 
            this.frmGroupTemplateSelectionBindingSource.DataSource = typeof(DokuExtractorStandardGUI.frmGroupTemplateSelection);
            // 
            // frmGroupTemplateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 276);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGroupTemplateSelection";
            this.Text = "Group Template Selection";
            this.Load += new System.EventHandler(this.frmGroupTemplateSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTemplatesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmGroupTemplateSelectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.BindingSource groupTemplatesBindingSource;
        private System.Windows.Forms.BindingSource frmGroupTemplateSelectionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTemplateGroupName;
    }
}