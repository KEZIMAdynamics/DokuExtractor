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
            this.lblInstruction = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butAddTableDefinitionTop = new System.Windows.Forms.Button();
            this.butAddTableDefinitionBottom = new System.Windows.Forms.Button();
            this.butAddColumnLeft = new System.Windows.Forms.Button();
            this.butAddColumnRight = new System.Windows.Forms.Button();
            this.gdViewer1 = new GdPicture14.GdViewer();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblInstruction);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.butAddTableDefinitionTop);
            this.splitContainer1.Panel1.Controls.Add(this.butAddTableDefinitionBottom);
            this.splitContainer1.Panel1.Controls.Add(this.butAddColumnLeft);
            this.splitContainer1.Panel1.Controls.Add(this.butAddColumnRight);
            this.splitContainer1.Panel1.Controls.Add(this.gdViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.butUndoAll);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.butTest);
            this.splitContainer1.Size = new System.Drawing.Size(886, 593);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(28, 9);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(377, 23);
            this.lblInstruction.TabIndex = 12;
            this.lblInstruction.Text = "Hello!";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 565);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 25);
            this.label4.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(405, 565);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 25);
            this.label3.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 25);
            this.label2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(405, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 25);
            this.label1.TabIndex = 8;
            // 
            // butAddTableDefinitionTop
            // 
            this.butAddTableDefinitionTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddTableDefinitionTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddTableDefinitionTop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddTableDefinitionTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddTableDefinitionTop.Location = new System.Drawing.Point(28, 37);
            this.butAddTableDefinitionTop.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.butAddTableDefinitionTop.Name = "butAddTableDefinitionTop";
            this.butAddTableDefinitionTop.Size = new System.Drawing.Size(377, 25);
            this.butAddTableDefinitionTop.TabIndex = 7;
            this.butAddTableDefinitionTop.Text = "Add Table Definition";
            this.butAddTableDefinitionTop.UseVisualStyleBackColor = false;
            this.butAddTableDefinitionTop.Click += new System.EventHandler(this.butAddTableDefinition_Click);
            // 
            // butAddTableDefinitionBottom
            // 
            this.butAddTableDefinitionBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddTableDefinitionBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddTableDefinitionBottom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddTableDefinitionBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddTableDefinitionBottom.Location = new System.Drawing.Point(28, 565);
            this.butAddTableDefinitionBottom.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.butAddTableDefinitionBottom.Name = "butAddTableDefinitionBottom";
            this.butAddTableDefinitionBottom.Size = new System.Drawing.Size(377, 25);
            this.butAddTableDefinitionBottom.TabIndex = 6;
            this.butAddTableDefinitionBottom.Text = "Add Table Definition";
            this.butAddTableDefinitionBottom.UseVisualStyleBackColor = false;
            this.butAddTableDefinitionBottom.Click += new System.EventHandler(this.butAddTableDefinition_Click);
            // 
            // butAddColumnLeft
            // 
            this.butAddColumnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.butAddColumnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddColumnLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddColumnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddColumnLeft.Location = new System.Drawing.Point(3, 62);
            this.butAddColumnLeft.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.butAddColumnLeft.Name = "butAddColumnLeft";
            this.butAddColumnLeft.Size = new System.Drawing.Size(25, 503);
            this.butAddColumnLeft.TabIndex = 5;
            this.butAddColumnLeft.Text = "+";
            this.butAddColumnLeft.UseVisualStyleBackColor = false;
            this.butAddColumnLeft.Click += new System.EventHandler(this.butAddColumnLeft_Click);
            // 
            // butAddColumnRight
            // 
            this.butAddColumnRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddColumnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddColumnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddColumnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddColumnRight.Location = new System.Drawing.Point(405, 62);
            this.butAddColumnRight.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.butAddColumnRight.Name = "butAddColumnRight";
            this.butAddColumnRight.Size = new System.Drawing.Size(25, 503);
            this.butAddColumnRight.TabIndex = 4;
            this.butAddColumnRight.Text = "+";
            this.butAddColumnRight.UseVisualStyleBackColor = false;
            this.butAddColumnRight.Click += new System.EventHandler(this.butAddColumnRight_Click);
            // 
            // gdViewer1
            // 
            this.gdViewer1.AllowDropFile = false;
            this.gdViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdViewer1.AnimateGIF = true;
            this.gdViewer1.AnnotationDropShadow = false;
            this.gdViewer1.AnnotationResizeRotateHandlesColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.gdViewer1.AnnotationResizeRotateHandlesScale = 1F;
            this.gdViewer1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.gdViewer1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.gdViewer1.BackColor = System.Drawing.Color.Black;
            this.gdViewer1.BackgroundImage = null;
            this.gdViewer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gdViewer1.ContinuousViewMode = true;
            this.gdViewer1.DisplayQuality = GdPicture14.DisplayQuality.DisplayQualityAutomatic;
            this.gdViewer1.DisplayQualityAuto = true;
            this.gdViewer1.DocumentAlignment = GdPicture14.ViewerDocumentAlignment.DocumentAlignmentMiddleCenter;
            this.gdViewer1.DocumentPosition = GdPicture14.ViewerDocumentPosition.DocumentPositionMiddleCenter;
            this.gdViewer1.EnableDeferredPainting = true;
            this.gdViewer1.EnabledProgressBar = true;
            this.gdViewer1.EnableICM = false;
            this.gdViewer1.EnableMenu = true;
            this.gdViewer1.EnableMouseWheel = true;
            this.gdViewer1.EnableTextSelection = true;
            this.gdViewer1.ForceScrollBars = false;
            this.gdViewer1.ForceTemporaryModeForImage = false;
            this.gdViewer1.ForceTemporaryModeForPDF = false;
            this.gdViewer1.ForeColor = System.Drawing.Color.Black;
            this.gdViewer1.Gamma = 1F;
            this.gdViewer1.HQAnnotationRendering = true;
            this.gdViewer1.IgnoreDocumentResolution = false;
            this.gdViewer1.KeepDocumentPosition = false;
            this.gdViewer1.Location = new System.Drawing.Point(28, 62);
            this.gdViewer1.LockViewer = false;
            this.gdViewer1.MagnifierHeight = 90;
            this.gdViewer1.MagnifierWidth = 160;
            this.gdViewer1.MagnifierZoomX = 2F;
            this.gdViewer1.MagnifierZoomY = 2F;
            this.gdViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.gdViewer1.MouseButtonForMouseMode = GdPicture14.MouseButton.MouseButtonLeft;
            this.gdViewer1.MouseMode = GdPicture14.ViewerMouseMode.MouseModeAreaSelection;
            this.gdViewer1.MouseWheelMode = GdPicture14.ViewerMouseWheelMode.MouseWheelModeVerticalScroll;
            this.gdViewer1.Name = "gdViewer1";
            //this.gdViewer1.OptimizeDrawingSpeed = true;
            this.gdViewer1.PageDisplayMode = GdPicture14.PageDisplayMode.SinglePageView;
            this.gdViewer1.PdfDisplayFormField = true;
            this.gdViewer1.PdfEnableFileLinks = true;
            this.gdViewer1.PdfEnableLinks = true;
            this.gdViewer1.PdfIncreaseTextContrast = false;
            this.gdViewer1.PdfRasterizerEngine = GdPicture14.PdfRasterizerEngine.PdfRasterizerEngineHybrid;
            this.gdViewer1.PdfShowDialogForPassword = true;
            this.gdViewer1.PdfShowOpenFileDialogForDecryption = true;
            this.gdViewer1.PdfVerifyDigitalCertificates = false;
            this.gdViewer1.RectBorderColor = System.Drawing.Color.Black;
            this.gdViewer1.RectBorderSize = 1;
            this.gdViewer1.RectIsEditable = true;
            this.gdViewer1.RegionsAreEditable = true;
            this.gdViewer1.ScrollBars = true;
            this.gdViewer1.ScrollLargeChange = ((short)(50));
            this.gdViewer1.ScrollSmallChange = ((short)(1));
            this.gdViewer1.SilentMode = true;
            this.gdViewer1.Size = new System.Drawing.Size(377, 503);
            this.gdViewer1.TabIndex = 0;
            this.gdViewer1.ViewRotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.gdViewer1.Zoom = 1D;
            this.gdViewer1.ZoomCenterAtMousePosition = false;
            this.gdViewer1.ZoomMode = GdPicture14.ViewerZoomMode.ZoomModeFitToViewer;
            this.gdViewer1.ZoomStep = 25;
            this.gdViewer1.AnnotationAddedByUser += new GdPicture14.GdViewer.AnnotationAddedByUserEventHandler(this.gdViewer1_AnnotationAddedByUser);
            this.gdViewer1.AnnotationMoved += new GdPicture14.GdViewer.AnnotationMovedEventHandler(this.gdViewer1_AnnotationMoved);
            this.gdViewer1.AnnotationResized += new GdPicture14.GdViewer.AnnotationResizedEventHandler(this.gdViewer1_AnnotationResized);
            // 
            // butUndoAll
            // 
            this.butUndoAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butUndoAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butUndoAll.Location = new System.Drawing.Point(3, 524);
            this.butUndoAll.Name = "butUndoAll";
            this.butUndoAll.Size = new System.Drawing.Size(443, 30);
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
            this.textBox1.Size = new System.Drawing.Size(443, 481);
            this.textBox1.TabIndex = 1;
            // 
            // butTest
            // 
            this.butTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTest.Location = new System.Drawing.Point(3, 560);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(443, 30);
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
        private GdPicture14.GdViewer gdViewer1;
        private System.Windows.Forms.Button butTest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button butUndoAll;
        private System.Windows.Forms.Button butAddColumnRight;
        private System.Windows.Forms.Button butAddColumnLeft;
        private System.Windows.Forms.Button butAddTableDefinitionBottom;
        private System.Windows.Forms.Button butAddTableDefinitionTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInstruction;
    }
}

