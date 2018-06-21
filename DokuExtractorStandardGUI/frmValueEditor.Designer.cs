namespace DokuExtractorStandardGUI
{
    partial class frmValueEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValueEditor));
            this.txtRetVal = new System.Windows.Forms.TextBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.cbxRetVal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtRetVal
            // 
            this.txtRetVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRetVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetVal.Location = new System.Drawing.Point(12, 12);
            this.txtRetVal.Name = "txtRetVal";
            this.txtRetVal.Size = new System.Drawing.Size(386, 23);
            this.txtRetVal.TabIndex = 0;
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOk.Location = new System.Drawing.Point(212, 50);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(90, 35);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCancel.Location = new System.Drawing.Point(308, 50);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(90, 35);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // cbxRetVal
            // 
            this.cbxRetVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRetVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRetVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRetVal.FormattingEnabled = true;
            this.cbxRetVal.Location = new System.Drawing.Point(12, 12);
            this.cbxRetVal.Name = "cbxRetVal";
            this.cbxRetVal.Size = new System.Drawing.Size(386, 24);
            this.cbxRetVal.TabIndex = 6;
            // 
            // frmValueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 97);
            this.Controls.Add(this.cbxRetVal);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.txtRetVal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(900, 136);
            this.MinimumSize = new System.Drawing.Size(16, 136);
            this.Name = "frmValueEditor";
            this.Text = "Doku Extractor";
            this.Load += new System.EventHandler(this.frmTextEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRetVal;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.ComboBox cbxRetVal;
    }
}