namespace DokuExtractorTableGUI
{
    partial class frmDokuExtractorTable
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
            this.ucDokuViewerGdPicture1 = new DokuExtractorTableGUI.UserControls.ucDokuViewerGdPicture();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.butUndoAll = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.butTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.ucDokuViewerGdPicture1);
            this.splitContainer1.Panel1.Controls.Add(this.lblInstruction);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.butUndoAll);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.butTest);
            this.splitContainer1.Size = new System.Drawing.Size(886, 593);
            this.splitContainer1.SplitterDistance = 495;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucDokuViewerGdPicture1
            // 
            this.ucDokuViewerGdPicture1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDokuViewerGdPicture1.BackColor = System.Drawing.Color.White;
            this.ucDokuViewerGdPicture1.Location = new System.Drawing.Point(3, 37);
            this.ucDokuViewerGdPicture1.Name = "ucDokuViewerGdPicture1";
            this.ucDokuViewerGdPicture1.Size = new System.Drawing.Size(489, 553);
            this.ucDokuViewerGdPicture1.TabIndex = 0;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(28, 9);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(439, 23);
            this.lblInstruction.TabIndex = 12;
            this.lblInstruction.Text = "Hello!";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butUndoAll
            // 
            this.butUndoAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butUndoAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butUndoAll.Location = new System.Drawing.Point(3, 524);
            this.butUndoAll.Name = "butUndoAll";
            this.butUndoAll.Size = new System.Drawing.Size(381, 30);
            this.butUndoAll.TabIndex = 2;
            this.butUndoAll.Text = "Undo All";
            this.butUndoAll.UseVisualStyleBackColor = true;
            this.butUndoAll.Click += new System.EventHandler(this.butUndoAll_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(381, 481);
            this.textBox1.TabIndex = 1;
            // 
            // butTest
            // 
            this.butTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTest.Location = new System.Drawing.Point(3, 560);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(381, 30);
            this.butTest.TabIndex = 0;
            this.butTest.Text = "Test";
            this.butTest.UseVisualStyleBackColor = true;
            this.butTest.Click += new System.EventHandler(this.butTest_Click);
            // 
            // frmDokuExtractorTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(886, 593);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDokuExtractorTable";
            this.Text = "DokuExtractorTable";
            this.Load += new System.EventHandler(this.frmDokuExtractorTable_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button butTest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button butUndoAll;
        private System.Windows.Forms.Label lblInstruction;
        private UserControls.ucDokuViewerGdPicture ucDokuViewerGdPicture1;
    }
}

