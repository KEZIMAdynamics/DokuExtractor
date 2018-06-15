namespace GdPicturePdfViewer
{
    partial class ucGdPicturePdfViewer
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
            this.gdViewer1 = new GdPicture14.GdViewer();
            this.thumbnailEx1 = new GdPicture14.ThumbnailEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdViewer1
            // 
            this.gdViewer1.AllowDropFile = false;
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
            this.gdViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdViewer1.DocumentAlignment = GdPicture14.ViewerDocumentAlignment.DocumentAlignmentMiddleCenter;
            this.gdViewer1.DocumentPosition = GdPicture14.ViewerDocumentPosition.DocumentPositionMiddleCenter;
            this.gdViewer1.EnableDeferredPainting = true;
            this.gdViewer1.EnabledProgressBar = true;
            this.gdViewer1.EnableICM = false;
            this.gdViewer1.EnableMenu = false;
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
            this.gdViewer1.Location = new System.Drawing.Point(0, 0);
            this.gdViewer1.LockViewer = false;
            this.gdViewer1.MagnifierHeight = 90;
            this.gdViewer1.MagnifierWidth = 160;
            this.gdViewer1.MagnifierZoomX = 2F;
            this.gdViewer1.MagnifierZoomY = 2F;
            this.gdViewer1.MouseButtonForMouseMode = GdPicture14.MouseButton.MouseButtonLeft;
            this.gdViewer1.MouseMode = GdPicture14.ViewerMouseMode.MouseModeAreaSelection;
            this.gdViewer1.MouseWheelMode = GdPicture14.ViewerMouseWheelMode.MouseWheelModeZoom;
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
            this.gdViewer1.RectIsEditable = false;
            this.gdViewer1.RegionsAreEditable = true;
            this.gdViewer1.ScrollBars = true;
            this.gdViewer1.ScrollLargeChange = ((short)(50));
            this.gdViewer1.ScrollSmallChange = ((short)(1));
            this.gdViewer1.SilentMode = true;
            this.gdViewer1.Size = new System.Drawing.Size(575, 516);
            this.gdViewer1.TabIndex = 0;
            this.gdViewer1.ViewRotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.gdViewer1.Zoom = 1D;
            this.gdViewer1.ZoomCenterAtMousePosition = false;
            this.gdViewer1.ZoomMode = GdPicture14.ViewerZoomMode.ZoomModeHeightViewer;
            this.gdViewer1.ZoomStep = 25;
            this.gdViewer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gdViewer1_MouseUp);
            // 
            // thumbnailEx1
            // 
            this.thumbnailEx1.AllowDropFiles = false;
            this.thumbnailEx1.AllowMoveItems = false;
            this.thumbnailEx1.BackColor = System.Drawing.SystemColors.Control;
            this.thumbnailEx1.CheckBoxes = false;
            this.thumbnailEx1.CheckBoxesMarginLeft = 0;
            this.thumbnailEx1.CheckBoxesMarginTop = 0;
            this.thumbnailEx1.DefaultItemTextPrefixe = "";
            this.thumbnailEx1.DisplayAnnotations = true;
            this.thumbnailEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thumbnailEx1.HorizontalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter;
            this.thumbnailEx1.HotTracking = false;
            this.thumbnailEx1.Location = new System.Drawing.Point(0, 0);
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
            this.thumbnailEx1.Size = new System.Drawing.Size(210, 516);
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
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.thumbnailEx1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gdViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(789, 516);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 1;
            // 
            // ucGdPicturePdfViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucGdPicturePdfViewer";
            this.Size = new System.Drawing.Size(789, 516);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GdPicture14.GdViewer gdViewer1;
        private GdPicture14.ThumbnailEx thumbnailEx1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
