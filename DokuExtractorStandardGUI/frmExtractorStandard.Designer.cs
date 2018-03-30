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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ucExtractedData1 = new DokuExtractorStandardGUI.UserControls.ucExtractedData();
            this.butTemplateEditor = new System.Windows.Forms.Button();
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(946, 538);
            this.splitContainer1.SplitterDistance = 696;
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
            this.splitContainer2.Size = new System.Drawing.Size(696, 538);
            this.splitContainer2.SplitterDistance = 181;
            this.splitContainer2.TabIndex = 0;
            // 
            // ucFileSelector1
            // 
            this.ucFileSelector1.BackColor = System.Drawing.Color.White;
            this.ucFileSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFileSelector1.Location = new System.Drawing.Point(0, 0);
            this.ucFileSelector1.Name = "ucFileSelector1";
            this.ucFileSelector1.Padding = new System.Windows.Forms.Padding(3);
            this.ucFileSelector1.Size = new System.Drawing.Size(181, 538);
            this.ucFileSelector1.TabIndex = 0;
            // 
            // ucViewer1
            // 
            this.ucViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucViewer1.Location = new System.Drawing.Point(0, 0);
            this.ucViewer1.Name = "ucViewer1";
            this.ucViewer1.Size = new System.Drawing.Size(511, 538);
            this.ucViewer1.TabIndex = 0;
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
            this.splitContainer3.Panel1.Controls.Add(this.ucExtractedData1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.butTemplateEditor);
            this.splitContainer3.Size = new System.Drawing.Size(246, 538);
            this.splitContainer3.SplitterDistance = 439;
            this.splitContainer3.TabIndex = 0;
            // 
            // ucExtractedData1
            // 
            this.ucExtractedData1.BackColor = System.Drawing.Color.White;
            this.ucExtractedData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExtractedData1.Location = new System.Drawing.Point(0, 0);
            this.ucExtractedData1.Name = "ucExtractedData1";
            this.ucExtractedData1.Size = new System.Drawing.Size(246, 439);
            this.ucExtractedData1.TabIndex = 0;
            // 
            // butTemplateEditor
            // 
            this.butTemplateEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butTemplateEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTemplateEditor.Location = new System.Drawing.Point(138, 57);
            this.butTemplateEditor.Name = "butTemplateEditor";
            this.butTemplateEditor.Size = new System.Drawing.Size(105, 35);
            this.butTemplateEditor.TabIndex = 0;
            this.butTemplateEditor.Text = "Template Editor";
            this.butTemplateEditor.UseVisualStyleBackColor = true;
            this.butTemplateEditor.Click += new System.EventHandler(this.butTemplateEditor_Click);
            // 
            // frmExtractorStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(946, 538);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmExtractorStandard";
            this.Text = "frmExtractorStandard";
            this.Load += new System.EventHandler(this.frmExtractorStandard_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
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

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private UserControls.ucFileSelector ucFileSelector1;
        private UserControls.ucViewer ucViewer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private UserControls.ucExtractedData ucExtractedData1;
        private System.Windows.Forms.Button butTemplateEditor;
    }
}

