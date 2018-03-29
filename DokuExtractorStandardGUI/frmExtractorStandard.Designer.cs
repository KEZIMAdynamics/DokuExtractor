namespace DokuExtractorStandardGUI
{
    partial class frmExtractorStandard
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ucFileSelector1 = new DokuExtractorStandardGUI.UserControls.ucFileSelector();
            this.ucViewer1 = new DokuExtractorStandardGUI.UserControls.ucViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(907, 509);
            this.splitContainer1.SplitterDistance = 633;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ucFileSelector1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ucViewer1);
            this.splitContainer2.Size = new System.Drawing.Size(633, 509);
            this.splitContainer2.SplitterDistance = 195;
            this.splitContainer2.TabIndex = 0;
            // 
            // ucFileSelector1
            // 
            this.ucFileSelector1.BackColor = System.Drawing.Color.White;
            this.ucFileSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFileSelector1.Location = new System.Drawing.Point(0, 0);
            this.ucFileSelector1.Name = "ucFileSelector1";
            this.ucFileSelector1.Padding = new System.Windows.Forms.Padding(3);
            this.ucFileSelector1.Size = new System.Drawing.Size(195, 509);
            this.ucFileSelector1.TabIndex = 0;
            // 
            // ucViewer1
            // 
            this.ucViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucViewer1.Location = new System.Drawing.Point(0, 0);
            this.ucViewer1.Name = "ucViewer1";
            this.ucViewer1.Size = new System.Drawing.Size(434, 509);
            this.ucViewer1.TabIndex = 0;
            // 
            // frmExtractorStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(907, 509);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmExtractorStandard";
            this.Text = "frmExtractorStandard";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private UserControls.ucFileSelector ucFileSelector1;
        private UserControls.ucViewer ucViewer1;
    }
}

