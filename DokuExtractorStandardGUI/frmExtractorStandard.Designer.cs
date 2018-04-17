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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtractorStandard));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ucFileSelector1 = new DokuExtractorStandardGUI.UserControls.ucFileSelector();
            this.ucViewer1 = new DokuExtractorStandardGUI.UserControls.ucViewer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ucExtractedData1 = new DokuExtractorStandardGUI.UserControls.ucExtractedData();
            this.butGo = new System.Windows.Forms.Button();
            this.butTemplateEditor = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabExtractedData = new System.Windows.Forms.TabPage();
            this.tabSingleTemplateEditor = new System.Windows.Forms.TabPage();
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
            this.tabControl1.SuspendLayout();
            this.tabExtractedData.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(962, 607);
            this.splitContainer1.SplitterDistance = 707;
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
            this.splitContainer2.Size = new System.Drawing.Size(707, 607);
            this.splitContainer2.SplitterDistance = 183;
            this.splitContainer2.TabIndex = 0;
            // 
            // ucFileSelector1
            // 
            this.ucFileSelector1.BackColor = System.Drawing.Color.White;
            this.ucFileSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFileSelector1.Location = new System.Drawing.Point(0, 0);
            this.ucFileSelector1.Name = "ucFileSelector1";
            this.ucFileSelector1.Padding = new System.Windows.Forms.Padding(3);
            this.ucFileSelector1.Size = new System.Drawing.Size(183, 607);
            this.ucFileSelector1.TabIndex = 0;
            // 
            // ucViewer1
            // 
            this.ucViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucViewer1.Location = new System.Drawing.Point(0, 0);
            this.ucViewer1.Name = "ucViewer1";
            this.ucViewer1.Size = new System.Drawing.Size(520, 607);
            this.ucViewer1.TabIndex = 0;
            this.ucViewer1.ViewerPluginPath = "G:\\DokuExtractor\\GdPicturePdfViewer\\bin\\Debug\\GdPicturePdfViewer.dll";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.butGo);
            this.splitContainer3.Panel2.Controls.Add(this.butTemplateEditor);
            this.splitContainer3.Size = new System.Drawing.Size(251, 607);
            this.splitContainer3.SplitterDistance = 560;
            this.splitContainer3.TabIndex = 0;
            // 
            // ucExtractedData1
            // 
            this.ucExtractedData1.BackColor = System.Drawing.Color.White;
            this.ucExtractedData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExtractedData1.Location = new System.Drawing.Point(3, 3);
            this.ucExtractedData1.Name = "ucExtractedData1";
            this.ucExtractedData1.Size = new System.Drawing.Size(237, 528);
            this.ucExtractedData1.TabIndex = 0;
            // 
            // butGo
            // 
            this.butGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butGo.Location = new System.Drawing.Point(32, 5);
            this.butGo.Name = "butGo";
            this.butGo.Size = new System.Drawing.Size(105, 35);
            this.butGo.TabIndex = 1;
            this.butGo.Text = "Go!";
            this.butGo.UseVisualStyleBackColor = true;
            this.butGo.Click += new System.EventHandler(this.butGo_Click);
            // 
            // butTemplateEditor
            // 
            this.butTemplateEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butTemplateEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTemplateEditor.Location = new System.Drawing.Point(143, 5);
            this.butTemplateEditor.Name = "butTemplateEditor";
            this.butTemplateEditor.Size = new System.Drawing.Size(105, 35);
            this.butTemplateEditor.TabIndex = 0;
            this.butTemplateEditor.Text = "Template Editor";
            this.butTemplateEditor.UseVisualStyleBackColor = true;
            this.butTemplateEditor.Click += new System.EventHandler(this.butTemplateEditor_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabExtractedData);
            this.tabControl1.Controls.Add(this.tabSingleTemplateEditor);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(251, 560);
            this.tabControl1.TabIndex = 1;
            // 
            // tabExtractedData
            // 
            this.tabExtractedData.Controls.Add(this.ucExtractedData1);
            this.tabExtractedData.Location = new System.Drawing.Point(4, 22);
            this.tabExtractedData.Name = "tabExtractedData";
            this.tabExtractedData.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtractedData.Size = new System.Drawing.Size(243, 534);
            this.tabExtractedData.TabIndex = 0;
            this.tabExtractedData.Text = "Extracted Data";
            this.tabExtractedData.UseVisualStyleBackColor = true;
            // 
            // tabSingleTemplateEditor
            // 
            this.tabSingleTemplateEditor.Location = new System.Drawing.Point(4, 22);
            this.tabSingleTemplateEditor.Name = "tabSingleTemplateEditor";
            this.tabSingleTemplateEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabSingleTemplateEditor.Size = new System.Drawing.Size(243, 534);
            this.tabSingleTemplateEditor.TabIndex = 1;
            this.tabSingleTemplateEditor.Text = "Single Template Editor";
            this.tabSingleTemplateEditor.UseVisualStyleBackColor = true;
            // 
            // frmExtractorStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(962, 607);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExtractorStandard";
            this.Text = "DokuExtractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExtractorStandard_FormClosing);
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
            this.tabControl1.ResumeLayout(false);
            this.tabExtractedData.ResumeLayout(false);
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
        private System.Windows.Forms.Button butGo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExtractedData;
        private System.Windows.Forms.TabPage tabSingleTemplateEditor;
    }
}

