namespace DokuExtractorStandardGUI.Localization
{
    partial class frmLanguageEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLanguageEditor));
            this.butSave = new System.Windows.Forms.Button();
            this.butAddLanguage = new System.Windows.Forms.Button();
            this.butDeleteLanguage = new System.Windows.Forms.Button();
            this.dgvRotatedLanguages = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotatedLanguages)).BeginInit();
            this.SuspendLayout();
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.Green;
            this.butSave.Location = new System.Drawing.Point(724, 548);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(105, 35);
            this.butSave.TabIndex = 3;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butAddLanguage
            // 
            this.butAddLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddLanguage.ForeColor = System.Drawing.Color.Blue;
            this.butAddLanguage.Location = new System.Drawing.Point(613, 548);
            this.butAddLanguage.Name = "butAddLanguage";
            this.butAddLanguage.Size = new System.Drawing.Size(105, 35);
            this.butAddLanguage.TabIndex = 4;
            this.butAddLanguage.Text = "Add language";
            this.butAddLanguage.UseVisualStyleBackColor = true;
            this.butAddLanguage.Click += new System.EventHandler(this.butAddLanguage_Click);
            // 
            // butDeleteLanguage
            // 
            this.butDeleteLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDeleteLanguage.ForeColor = System.Drawing.Color.Red;
            this.butDeleteLanguage.Location = new System.Drawing.Point(835, 548);
            this.butDeleteLanguage.Name = "butDeleteLanguage";
            this.butDeleteLanguage.Size = new System.Drawing.Size(105, 35);
            this.butDeleteLanguage.TabIndex = 5;
            this.butDeleteLanguage.Text = "Delete language";
            this.butDeleteLanguage.UseVisualStyleBackColor = true;
            this.butDeleteLanguage.Click += new System.EventHandler(this.butDeleteLanguage_Click);
            // 
            // dgvRotatedLanguages
            // 
            this.dgvRotatedLanguages.AllowUserToAddRows = false;
            this.dgvRotatedLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRotatedLanguages.BackgroundColor = System.Drawing.Color.White;
            this.dgvRotatedLanguages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRotatedLanguages.Location = new System.Drawing.Point(12, 12);
            this.dgvRotatedLanguages.Name = "dgvRotatedLanguages";
            this.dgvRotatedLanguages.Size = new System.Drawing.Size(928, 530);
            this.dgvRotatedLanguages.TabIndex = 6;
            // 
            // frmLanguageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 595);
            this.Controls.Add(this.dgvRotatedLanguages);
            this.Controls.Add(this.butDeleteLanguage);
            this.Controls.Add(this.butAddLanguage);
            this.Controls.Add(this.butSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLanguageEditor";
            this.Text = "LanguageEditor";
            this.Load += new System.EventHandler(this.frmLanguageEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRotatedLanguages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butAddLanguage;
        private System.Windows.Forms.Button butDeleteLanguage;
        private System.Windows.Forms.DataGridView dgvRotatedLanguages;
    }
}