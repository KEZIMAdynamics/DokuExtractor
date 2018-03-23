namespace DokuExtractorTableGUI.UserControls
{
    partial class ucDokuViewerGdPicture
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butAddTableDefinitionTop = new System.Windows.Forms.Button();
            this.butAddTableDefinitionBottom = new System.Windows.Forms.Button();
            this.butAddColumnLeft = new System.Windows.Forms.Button();
            this.butAddColumnRight = new System.Windows.Forms.Button();
            this.gdViewer1 = new GdPicture14.GdViewer();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.thumbnailEx1 = new GdPicture14.ThumbnailEx();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(265, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 25);
            this.label2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(746, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 25);
            this.label1.TabIndex = 15;
            // 
            // butAddTableDefinitionTop
            // 
            this.butAddTableDefinitionTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddTableDefinitionTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddTableDefinitionTop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(158)))), ((int)(((byte)(60)))));
            this.butAddTableDefinitionTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddTableDefinitionTop.Location = new System.Drawing.Point(290, 0);
            this.butAddTableDefinitionTop.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.butAddTableDefinitionTop.Name = "butAddTableDefinitionTop";
            this.butAddTableDefinitionTop.Size = new System.Drawing.Size(456, 25);
            this.butAddTableDefinitionTop.TabIndex = 14;
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
            this.butAddTableDefinitionBottom.Location = new System.Drawing.Point(290, 562);
            this.butAddTableDefinitionBottom.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.butAddTableDefinitionBottom.Name = "butAddTableDefinitionBottom";
            this.butAddTableDefinitionBottom.Size = new System.Drawing.Size(456, 25);
            this.butAddTableDefinitionBottom.TabIndex = 13;
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
            this.butAddColumnLeft.Location = new System.Drawing.Point(265, 25);
            this.butAddColumnLeft.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.butAddColumnLeft.Name = "butAddColumnLeft";
            this.butAddColumnLeft.Size = new System.Drawing.Size(25, 537);
            this.butAddColumnLeft.TabIndex = 12;
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
            this.butAddColumnRight.Location = new System.Drawing.Point(746, 25);
            this.butAddColumnRight.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.butAddColumnRight.Name = "butAddColumnRight";
            this.butAddColumnRight.Size = new System.Drawing.Size(25, 537);
            this.butAddColumnRight.TabIndex = 11;
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
            this.gdViewer1.Location = new System.Drawing.Point(290, 25);
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
            this.gdViewer1.Size = new System.Drawing.Size(456, 537);
            this.gdViewer1.TabIndex = 10;
            this.gdViewer1.ViewRotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.gdViewer1.Zoom = 1D;
            this.gdViewer1.ZoomCenterAtMousePosition = false;
            this.gdViewer1.ZoomMode = GdPicture14.ViewerZoomMode.ZoomModeFitToViewer;
            this.gdViewer1.ZoomStep = 25;
            this.gdViewer1.AnnotationAddedByUser += new GdPicture14.GdViewer.AnnotationAddedByUserEventHandler(this.gdViewer1_AnnotationAddedByUser);
            this.gdViewer1.AnnotationMoved += new GdPicture14.GdViewer.AnnotationMovedEventHandler(this.gdViewer1_AnnotationMoved);
            this.gdViewer1.AnnotationResized += new GdPicture14.GdViewer.AnnotationResizedEventHandler(this.gdViewer1_AnnotationResized);
            this.gdViewer1.PageChanged += new GdPicture14.GdViewer.PageChangedEventHandler(this.gdViewer1_PageChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(265, 562);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 25);
            this.label4.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(746, 562);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 25);
            this.label3.TabIndex = 17;
            // 
            // thumbnailEx1
            // 
            this.thumbnailEx1.AllowDropFiles = false;
            this.thumbnailEx1.AllowMoveItems = false;
            this.thumbnailEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.thumbnailEx1.BackColor = System.Drawing.SystemColors.Control;
            this.thumbnailEx1.CheckBoxes = false;
            this.thumbnailEx1.CheckBoxesMarginLeft = 0;
            this.thumbnailEx1.CheckBoxesMarginTop = 0;
            this.thumbnailEx1.DefaultItemTextPrefixe = "Page ";
            this.thumbnailEx1.DisplayAnnotations = true;
            this.thumbnailEx1.HorizontalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter;
            this.thumbnailEx1.HotTracking = false;
            this.thumbnailEx1.Location = new System.Drawing.Point(3, 3);
            this.thumbnailEx1.LockGdViewerEvents = false;
            this.thumbnailEx1.MultiSelect = false;
            this.thumbnailEx1.Name = "thumbnailEx1";
            this.thumbnailEx1.OwnDrop = false;
            this.thumbnailEx1.PauseThumbsLoading = false;
            this.thumbnailEx1.PdfIncreaseTextContrast = false;
            this.thumbnailEx1.PdfRasterizerEngine = GdPicture14.PdfRasterizerEngine.PdfRasterizerEngineHybrid;
            this.thumbnailEx1.PreloadAllItems = true;
            this.thumbnailEx1.RotateExif = true;
            this.thumbnailEx1.SelectedThumbnailBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.thumbnailEx1.ShowText = true;
            this.thumbnailEx1.Size = new System.Drawing.Size(256, 581);
            this.thumbnailEx1.TabIndex = 0;
            this.thumbnailEx1.TextMarginLeft = 0;
            this.thumbnailEx1.TextMarginTop = 0;
            this.thumbnailEx1.ThumbnailAlignment = GdPicture14.ThumbnailAlignment.ThumbnailAlignmentVertical;
            this.thumbnailEx1.ThumbnailBackColor = System.Drawing.Color.Gray;
            this.thumbnailEx1.ThumbnailBorder = true;
            this.thumbnailEx1.ThumbnailForeColor = System.Drawing.Color.Black;
            this.thumbnailEx1.ThumbnailSize = new System.Drawing.Size(128, 128);
            this.thumbnailEx1.ThumbnailSpacing = new System.Drawing.Size(0, 0);
            this.thumbnailEx1.VerticalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter;
            this.thumbnailEx1.ItemSelectionChanged += new GdPicture14.ThumbnailEx.ItemSelectionChangedEventHandler(this.thumbnailEx1_ItemSelectionChanged);
            // 
            // ucDokuViewerGdPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.thumbnailEx1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butAddTableDefinitionTop);
            this.Controls.Add(this.butAddTableDefinitionBottom);
            this.Controls.Add(this.butAddColumnLeft);
            this.Controls.Add(this.butAddColumnRight);
            this.Controls.Add(this.gdViewer1);
            this.Name = "ucDokuViewerGdPicture";
            this.Size = new System.Drawing.Size(771, 587);
            this.Load += new System.EventHandler(this.ucDokuViewerGdPicture_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butAddTableDefinitionTop;
        private System.Windows.Forms.Button butAddTableDefinitionBottom;
        private System.Windows.Forms.Button butAddColumnLeft;
        private System.Windows.Forms.Button butAddColumnRight;
        private GdPicture14.GdViewer gdViewer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private GdPicture14.ThumbnailEx thumbnailEx1;
    }
}
