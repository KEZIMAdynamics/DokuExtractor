using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GdPicture14;
using GdPicture14.Annotations;

namespace DokuExtractorTableGUI.UserControls
{
    public partial class ucDokuViewerGdPicture : UserControl
    {
        #region Events
        public delegate void TableDefinitonStateChangedHandler(bool isTableDefined);
        public TableDefinitonStateChangedHandler TableDefinitonStateChanged;
        #endregion Events

        #region Variables
        private bool IsTableDefined
        {
            get
            {
                return isTableDefined;
            }
            set
            {
                isTableDefined = value;
                TableDefinitonStateChanged?.Invoke(value);
            }
        }
        private bool isTableDefined = false;

        private GdPicturePDF gdPdf = new GdPicturePDF();

        // These four variables remember the position and size of the table frame
        private float tableFrameLeft = 0;
        private float tableFrameTop = 0;
        private float tableFrameWidth = 0;
        private float tableFrameHeight = 0;

        private List<int> pagesWithAnnot = new List<int>();

        private int selectedThumbnailIdx = 0;
        private bool isExtractionRunning = false;
        private bool isClearanceRunning = false;

        /// <summary>
        /// The AnnotationManager is necessary to add annotations (in this case: column separation lines) by code
        /// </summary>
        private AnnotationManager annotManager = new AnnotationManager();
        #endregion Variables

        #region Initialization
        public ucDokuViewerGdPicture()
        {
            InitializeComponent();
        }

        private void ucDokuViewerGdPicture_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                annotManager = gdViewer1.GetAnnotationManager();
                //gdPdf.SetMeasurementUnit(PdfMeasurementUnit.PdfMeasurementUnitInch);
                DisableColumnButtons();
            }
        }

        /// <summary>
        /// Loads a GdPicturePdf
        /// </summary>
        /// <param name="gdPdf">GdPicturePdf</param>
        public void LoadGdPdf(GdPicturePDF gdPdf)
        {
            this.gdPdf = gdPdf;
            gdViewer1.DisplayFromGdPicturePDF(this.gdPdf);
            thumbnailEx1.LoadFromGdViewer(gdViewer1);
        }
        #endregion Initialization

        #region Extraction
        /// <summary>
        /// Extracts text of all table frames and columns; Returns a list of string[2] (0: text of all table lines, 1: text of all table columns)
        /// </summary>
        public List<string[]> ExtractAllTableLinesAndColumns()
        {
            isExtractionRunning = true;
            var retVal = new List<string[]>();
            var pageCount = thumbnailEx1.ItemCount;

            if (pagesWithAnnot.Where(x => x == selectedThumbnailIdx).Count() == 0)
                if (gdViewer1.GetAnnotationFromIdx(0) != null)
                    pagesWithAnnot.Add(selectedThumbnailIdx);

            if (pagesWithAnnot.Count > 0)
            {
                var pagesWithAnnotOrdered = pagesWithAnnot.OrderBy(x => x).ToList();
                foreach (var pageIdx in pagesWithAnnotOrdered)
                {
                    var extractionObject = new string[2];
                    thumbnailEx1.SelectItem(pageIdx);
                    extractionObject[0] = ExtractTableLines();
                    extractionObject[1] = ExtractTableColumns();
                    retVal.Add(extractionObject);
                }
            }

            isExtractionRunning = false;
            return retVal;
        }

        /// <summary>
        /// Extracts text of the complete table frame (line by line)
        /// </summary>
        private string ExtractTableLines()
        {
            var retVal = string.Empty;

            var tableFrame = gdViewer1.GetAnnotationFromIdx(0);
            if (tableFrame != null)
            {
                var left = this.tableFrameLeft - (this.tableFrameWidth / 2);
                var top = this.tableFrameTop - (this.tableFrameHeight / 2);
                retVal = gdViewer1.GetPageTextArea(left, top, this.tableFrameWidth, this.tableFrameHeight);
            }

            return retVal;
        }

        /// <summary>
        /// Extracts text of all table colums (line by line) seperated by ||| between each column
        /// </summary>
        private string ExtractTableColumns()
        {
            var retVal = string.Empty;
            var annotList = new List<Annotation>();
            var annotCount = gdViewer1.GetAnnotationCount();
            var rotation = gdPdf.GetPageRotation();

            while (annotCount > 1) // Do following actions for every column separation line (but not for table frame)
            {
                var annot = gdViewer1.GetAnnotationFromIdx(annotCount - 1);
                annotList.Add(annot);

                annotCount--;
            }

            float leftFence = 0;
            float rightFence = 0;

            if (rotation == 270 || rotation == -90)
            {
                leftFence = this.tableFrameTop - (this.tableFrameHeight / 2); // Left border of the table frame
                rightFence = this.tableFrameTop + (this.tableFrameHeight / 2); // Right border of the table frame
            }
            else if (rotation == 90 || rotation == -270)
            {
                leftFence = this.tableFrameTop + (this.tableFrameHeight / 2); // Left border of the table frame
                rightFence = this.tableFrameTop - (this.tableFrameHeight / 2); // Right border of the table frame
            }
            else
            {
                leftFence = this.tableFrameLeft - (this.tableFrameWidth / 2); // Left border of the table frame
                rightFence = this.tableFrameLeft + (this.tableFrameWidth / 2); // Right border of the table frame
            }

            var annotListOrdered = new List<Annotation>();

            if (rotation == 270 || rotation == -90)
                annotListOrdered = annotList.OrderBy(x => x.Top).ToList(); // Orders column separation lines by position (from left to right)
            else if (rotation == 90 || rotation == -270)
                annotListOrdered = annotList.OrderByDescending(x => x.Top).ToList(); // Orders column separation lines by position (from left to right)
            else
                annotListOrdered = annotList.OrderBy(x => x.Left).ToList(); // Orders column separation lines by position (from left to right)

            var columnLineNo = 0; // Rememberes which column separation line is currently handled within the foreach
            Annotation prevAnnot = null; // Remembers previous handled column separation line

            annotCount = annotListOrdered.Count();

            foreach (var annot in annotListOrdered)
            {
                // In the following there are not used else-ifs because the first column separation line can also be the last and the last column separation line does
                // have a previous handled column separation line in most cases

                // If it is the first column separation line, the text of the area between the left border of the table frame and the currently handled line is extracted
                if (columnLineNo == 0)
                {
                    if (rotation == 270 || rotation == -90)
                        retVal = retVal + gdViewer1.GetPageTextArea(tableFrameLeft - (tableFrameWidth / 2), leftFence, annot.Width, annot.Top - leftFence)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                    else if (rotation == 90 || rotation == -270)
                        retVal = retVal + gdViewer1.GetPageTextArea(tableFrameLeft - (tableFrameWidth / 2), annot.Top, annot.Width, leftFence - annot.Top)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                    else
                        retVal = retVal + gdViewer1.GetPageTextArea(leftFence, annot.Top - (annot.Height / 2), annot.Left - leftFence, annot.Height)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                }

                // If there is a previous handled column seperation line, the text of the area between that line an the currently handled line is extracted
                if (prevAnnot != null)
                {
                    if (rotation == 270 || rotation == -90)
                        retVal = retVal + gdViewer1.GetPageTextArea(tableFrameLeft - (tableFrameWidth / 2), prevAnnot.Top, annot.Width, annot.Top - prevAnnot.Top)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                    else if (rotation == 90 || rotation == -270)
                        retVal = retVal + gdViewer1.GetPageTextArea(tableFrameLeft - (tableFrameWidth / 2), annot.Top, annot.Width, prevAnnot.Top - annot.Top)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                    else
                        retVal = retVal + gdViewer1.GetPageTextArea(prevAnnot.Left, annot.Top - (annot.Height / 2), annot.Left - prevAnnot.Left, annot.Height)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                }

                // If it is the last column separation line, the text of the area between the right border of the table frame and the currently handled line is extracted
                if (columnLineNo == annotCount - 1)
                {
                    if (rotation == 270 || rotation == -90)
                        retVal = retVal + gdViewer1.GetPageTextArea(tableFrameLeft - (tableFrameWidth / 2), annot.Top, annot.Width, rightFence - annot.Top);
                    else if (rotation == 90 || rotation == -270)
                        retVal = retVal + gdViewer1.GetPageTextArea(tableFrameLeft - (tableFrameWidth / 2), rightFence, annot.Width, annot.Top - rightFence);
                    else
                        retVal = retVal + gdViewer1.GetPageTextArea(annot.Left, annot.Top - (annot.Height / 2), rightFence - annot.Left, annot.Height);
                }

                prevAnnot = annot;
                columnLineNo++;
            }

            retVal = retVal.TrimEnd('|').TrimEnd('|').TrimEnd('|');
            return retVal;
        }
        #endregion Extraction

        #region GdViewerEvents
        /// <summary>
        /// Fired, when an annotation is added by user
        /// </summary>
        /// <param name="AnnotationIdx">Index of added annotation</param>
        private void gdViewer1_AnnotationAddedByUser(int AnnotationIdx)
        {
            if (AnnotationIdx == 0) // Annotation with Index 0 is table frame, others are column separation 
            {
                var annot = gdViewer1.GetAnnotationFromIdx(AnnotationIdx);
                annot.CanRotate = false;
                var rotation = gdPdf.GetPageRotation();

                if (rotation == 270 || rotation == -90 || rotation == 90 || rotation == -270)
                {
                    if (annot.Rotation == 270 || annot.Rotation == -90 || annot.Rotation == 90 || annot.Rotation == -270)
                    {
                        annot.Rotation = 0;
                        var newWidth = annot.Height;
                        var newHeight = annot.Width;
                        annot.Width = newWidth;
                        annot.Height = newHeight;
                    }
                }
                //else if (rotation == 180 || rotation == -180) // Documents rotated 180° are not readable!
                //    if (annot.Rotation == 180 || annot.Rotation == -180)
                //        annot.Rotation = 0;

                UpdateTableFrameMemory(annot.Left, annot.Top, annot.Width, annot.Height);
                IsTableDefined = true;
                EnableColumnButtons();
            }
        }

        /// <summary>
        /// Fired, when an annotation is moved by user
        /// </summary>
        /// <param name="AnnotationIdx">Index of moved annotation</param>
        private void gdViewer1_AnnotationMoved(int AnnotationIdx)
        {
            if (AnnotationIdx == 0) // Annotation with Index 0 is table frame, others are column separation 
                UpdateTableFrameAndColumns(false);
            else
                TameMovedColumnLine(AnnotationIdx);
        }

        /// <summary>
        /// Fired, when the size of an annotation is changed by user
        /// </summary>
        /// <param name="AnnotationIdx">Index of rezised annotation</param>
        private void gdViewer1_AnnotationResized(int AnnotationIdx)
        {
            if (AnnotationIdx == 0) // Annotation with Index 0 is table frame, others are column separation 
                UpdateTableFrameAndColumns(true);
        }
        #endregion GdViewerEvents

        #region FrameLogic
        /// <summary>
        /// If the table frame is moved or rezised, this function is used to update positions and sizes of the column separation lines and
        /// to update the variables, which remember the position and size of the table frame
        /// </summary>
        /// <param name="rezised">Has the table frame been rezised?</param>
        private void UpdateTableFrameAndColumns(bool rezised)
        {
            var tableFrame = gdViewer1.GetAnnotationFromIdx(0);

            if (tableFrame != null)
            {
                UpdateColumnPositionsAndSizes(tableFrame.Left, tableFrame.Top, tableFrame.Width, tableFrame.Height, rezised);
                UpdateTableFrameMemory(tableFrame.Left, tableFrame.Top, tableFrame.Width, tableFrame.Height);
            }
        }

        /// <summary>
        /// Updates the variables, which remember the position and size of the table frame
        /// </summary>
        /// <param name="left">Value for tableFrameLeft</param>
        /// <param name="top">Value for tableFrameTop</param>
        /// <param name="width">Value for tableFrameWidth</param>
        /// <param name="height">Value for tableFrameHeight</param>
        private void UpdateTableFrameMemory(float left, float top, float width, float height)
        {
            this.tableFrameLeft = left;
            this.tableFrameTop = top;
            this.tableFrameWidth = width;
            this.tableFrameHeight = height;
        }

        /// <summary>
        /// Updates positions and sizes of the column separation lines by comparing the new values of the table frame with the remembered old values
        /// </summary>
        /// <param name="rezised">Has the table frame been rezised?</param>
        private void UpdateColumnPositionsAndSizes(float newTableFrameLeft, float newTableFrameTop, float newTableFrameWidth, float newTableFrameHeight, bool rezised)
        {
            var leftDif = newTableFrameLeft - this.tableFrameLeft;
            var topDif = newTableFrameTop - this.tableFrameTop;
            var widthDif = newTableFrameWidth - this.tableFrameWidth;
            var heightDif = newTableFrameHeight - this.tableFrameHeight;

            var rotation = gdPdf.GetPageRotation();
            var annotCount = gdViewer1.GetAnnotationCount(); // Count of annotations

            while (annotCount > 1) // Do following actions for every column separation line (but not for table frame)
            {
                var annot = gdViewer1.GetAnnotationFromIdx(annotCount - 1);

                if (rezised) // Has the table frame been rezised?
                {
                    if (rotation == 270 || rotation == -90 || rotation == 90 || rotation == -270)
                    {
                        // Deletes column separation line, if it is (right or left) out of the table frame
                        if (annot.Top <= newTableFrameTop - (newTableFrameHeight / 2) || annot.Top >= newTableFrameTop + (newTableFrameHeight / 2))
                            gdViewer1.DeleteAnnotation(annotCount - 1);

                        // Moves column separation line into the table frame, if (a part of) it is (top or bottom) out of the table frame
                        annot.Left = annot.Left + leftDif;
                        annot.Width = annot.Width + widthDif;
                    }
                    else
                    {
                        // Deletes column separation line, if it is (right or left) out of the table frame
                        if (annot.Left <= newTableFrameLeft - (newTableFrameWidth / 2) || annot.Left >= newTableFrameLeft + (newTableFrameWidth / 2))
                            gdViewer1.DeleteAnnotation(annotCount - 1);

                        // Moves column separation line into the table frame, if (a part of) it is (top or bottom) out of the table frame
                        annot.Top = annot.Top + topDif;
                        annot.Height = annot.Height + heightDif;
                    }
                }
                else // Or has the table frame been moved?
                {
                    // Moves column separation line into the table frame, if (a part of) it is out of the table frame
                    annot.Left = annot.Left + leftDif;
                    annot.Top = annot.Top + topDif;
                }

                annotCount--;
            }
        }

        /// <summary>
        /// Adapts the position of (or deletes) an column separation line, which has been moved out of the table frame
        /// </summary>
        /// <param name="annotIndex"></param>
        private void TameMovedColumnLine(int annotIndex)
        {
            var annot = gdViewer1.GetAnnotationFromIdx(annotIndex);
            var rotation = gdPdf.GetPageRotation();

            if (rotation == 270 || rotation == -90 || rotation == 90 || rotation == -270)
            {
                // Deletes column separation line, if it is (right or left) out of the table frame
                if (annot.Top <= this.tableFrameTop - (this.tableFrameHeight / 2) || annot.Top >= this.tableFrameTop + (this.tableFrameHeight / 2))
                    gdViewer1.DeleteAnnotation(annotIndex);
                else // Moves column separation line into the table frame, if (a part of) it is out of the table frame
                    annot.Left = this.tableFrameLeft;
            }
            else
            {
                // Deletes column separation line, if it is (right or left) out of the table frame
                if (annot.Left <= this.tableFrameLeft - (this.tableFrameWidth / 2) || annot.Left >= this.tableFrameLeft + (this.tableFrameWidth / 2))
                    gdViewer1.DeleteAnnotation(annotIndex);
                else // Moves column separation line into the table frame, if (a part of) it is out of the table frame
                    annot.Top = this.tableFrameTop;
            }
        }
        #endregion FrameLogic

        #region ButtonClicks
        /// <summary>
        /// After clicking the user can draw a frame to define the position and size of the table
        /// </summary>
        private void butAddTableDefinition_Click(object sender, EventArgs e)
        {
            IsTableDefined = false;

            DisableColumnButtons();
            RemoveAllAnnotations();

            gdViewer1.ClearRect();
            gdViewer1.AddRectangleAnnotInteractive(false, true, Color.Empty, Color.Red, 0.05F, 1);
        }

        /// <summary>
        /// Adds a new column separation line (non-rezisable and non-rotatable) to left side of the defined table frame
        /// </summary>
        private void butAddColumnLeft_Click(object sender, EventArgs e)
        {
            DisableTableDefinitionButtons();

            float srcTop = 0;
            float srcLeft = 0;
            float dstTop = 0;
            float dstLeft = 0;
            int rotation = gdPdf.GetPageRotation();

            if (rotation == 270 || rotation == -90)
            {
                srcTop = this.tableFrameTop - (this.tableFrameHeight / 2) + 0.1F;
                srcLeft = this.tableFrameLeft + (this.tableFrameWidth / 2);
                dstTop = this.tableFrameTop - (this.tableFrameHeight / 2) + 0.1F;
                dstLeft = this.tableFrameLeft - (this.tableFrameWidth / 2);
            }
            else if (rotation == 90 || rotation == -270)
            {
                srcTop = this.tableFrameTop + (this.tableFrameHeight / 2) - 0.1F;
                srcLeft = this.tableFrameLeft + (this.tableFrameWidth / 2);
                dstTop = this.tableFrameTop + (this.tableFrameHeight / 2) - 0.1F;
                dstLeft = this.tableFrameLeft - (this.tableFrameWidth / 2);
            }
            //else if (rotation == 180 || rotation == -180) // Documents rotated 180° are not readable!
            //{
            //    srcTop = this.tableFrameTop - (this.tableFrameHeight / 2);
            //    srcLeft = this.tableFrameLeft + (this.tableFrameWidth / 2) - 0.1F;
            //    dstTop = srcTop + this.tableFrameHeight;
            //    dstLeft = this.tableFrameLeft + (this.tableFrameWidth / 2) - 0.1F;
            //}
            else
            {
                srcTop = this.tableFrameTop - (this.tableFrameHeight / 2);
                srcLeft = this.tableFrameLeft - (this.tableFrameWidth / 2) + 0.1F;
                dstTop = srcTop + this.tableFrameHeight;
                dstLeft = this.tableFrameLeft - (this.tableFrameWidth / 2) + 0.1F;
            }

            var line = annotManager.AddLineAnnot(Color.Blue, srcLeft, srcTop, dstLeft, dstTop);
            line.BorderWidth = 0.05F;
            line.CanResize = false;
            line.CanRotate = false;
        }

        /// <summary>
        /// Adds a new column separation line (non-rezisable and non-rotatable) to right side of the defined table frame
        /// </summary>
        private void butAddColumnRight_Click(object sender, EventArgs e)
        {
            DisableTableDefinitionButtons();

            float srcTop = 0;
            float srcLeft = 0;
            float dstTop = 0;
            float dstLeft = 0;
            int rotation = gdPdf.GetPageRotation();

            if (rotation == 270 || rotation == -90)
            {
                srcTop = this.tableFrameTop + (this.tableFrameHeight / 2) - 0.1F;
                srcLeft = this.tableFrameLeft + (this.tableFrameWidth / 2);
                dstTop = this.tableFrameTop + (this.tableFrameHeight / 2) - 0.1F;
                dstLeft = this.tableFrameLeft - (this.tableFrameWidth / 2);
            }
            else if (rotation == 90 || rotation == -270)
            {
                srcTop = this.tableFrameTop - (this.tableFrameHeight / 2) + 0.1F;
                srcLeft = this.tableFrameLeft + (this.tableFrameWidth / 2);
                dstTop = this.tableFrameTop - (this.tableFrameHeight / 2) + 0.1F;
                dstLeft = this.tableFrameLeft - (this.tableFrameWidth / 2);
            }
            //else if (rotation == 180 || rotation == -180) // Documents rotated 180° are not readable!
            //{
            //    srcTop = this.tableFrameTop - (this.tableFrameHeight / 2);
            //    srcLeft = this.tableFrameLeft - (this.tableFrameWidth / 2) + 0.1F;
            //    dstTop = srcTop + this.tableFrameHeight;
            //    dstLeft = this.tableFrameLeft - (this.tableFrameWidth / 2) + 0.1F;
            //}
            else
            {
                srcTop = this.tableFrameTop - (this.tableFrameHeight / 2);
                srcLeft = this.tableFrameLeft + (this.tableFrameWidth / 2) - 0.1F;
                dstTop = srcTop + this.tableFrameHeight;
                dstLeft = this.tableFrameLeft + (this.tableFrameWidth / 2) - 0.1F;
            }

            var line = annotManager.AddLineAnnot(Color.Blue, srcLeft, srcTop, dstLeft, dstTop);
            line.BorderWidth = 0.05F;
            line.CanResize = false;
            line.CanRotate = false;
        }
        #endregion ButtonClicks

        #region Clearance
        /// <summary>
        /// Removes all Annotations (table frame and column separation lines) and resets variables
        /// </summary>
        public void UndoAll()
        {
            isClearanceRunning = true;

            foreach (var pageIdx in pagesWithAnnot)
            {
                thumbnailEx1.SelectItem(pageIdx);
                RemoveAllAnnotations();
                UndefineTable();
                UpdateTableFrameMemory(0, 0, 0, 0);
            }

            pagesWithAnnot = new List<int>();

            isClearanceRunning = false;
        }

        /// <summary>
        /// Removes all annotations (table frame and column separation lines)
        /// </summary>
        private void RemoveAllAnnotations()
        {
            var annotCount = gdViewer1.GetAnnotationCount();

            while (annotCount > 0)
            {
                gdViewer1.DeleteAnnotation(annotCount - 1);
                annotCount--;
            }
        }

        /// <summary>
        /// Undifines Table and switches enabling of buttons
        /// </summary>
        private void UndefineTable()
        {
            IsTableDefined = false;
            DisableColumnButtons();
            EnableTableDefinitionButtons();
        }
        #endregion Clearence

        #region VisualAppearance
        /// <summary>
        /// Enables the buttons (left and right), with which you can add column separation lines
        /// </summary>
        private void EnableColumnButtons()
        {
            butAddColumnLeft.Enabled = true;
            butAddColumnRight.Enabled = true;
        }

        /// <summary>
        /// Disables the buttons (left and right), with which you can add column separation lines
        /// </summary>
        private void DisableColumnButtons()
        {
            butAddColumnLeft.Enabled = false;
            butAddColumnRight.Enabled = false;
        }

        /// <summary>
        /// Enables the buttons (top and bottom), with which you can add the table frame
        /// </summary>
        private void EnableTableDefinitionButtons()
        {
            butAddTableDefinitionTop.Enabled = true;
            butAddTableDefinitionBottom.Enabled = true;
        }

        /// <summary>
        /// Disables the buttons (top and bottom), with which you can add the table frame
        /// </summary>
        private void DisableTableDefinitionButtons()
        {
            butAddTableDefinitionTop.Enabled = false;
            butAddTableDefinitionBottom.Enabled = false;
        }
        #endregion VisualAppearance

        #region ThumbnailEvents
        /// <summary>
        /// Fired twice, when the selected Item has changed (first for previous selected item, second for selected item)
        /// If the previous selected item (page) has annotations, its index is added to the pagesWithAnnot list
        /// If the previous selected item (page) has no annotations, it is removed from the pagesWithAnnot list (if necessary)
        /// </summary>
        /// <param name="Idx">Index of item</param>
        /// <param name="Selected">Is it selected now (true) or is it the item, which was previously selected (false)?</param>
        private void thumbnailEx1_ItemSelectionChanged(int Idx, bool Selected)
        {
            if (Selected)
                selectedThumbnailIdx = Idx;
            else if (isExtractionRunning == false && isClearanceRunning == false)
            {
                var tableFrame = gdViewer1.GetAnnotationFromIdx(0);
                if (tableFrame != null)
                {
                    if (pagesWithAnnot.Where(x => x == Idx).Count() == 0)
                        pagesWithAnnot.Add(Idx);
                }
                else
                {
                    if (pagesWithAnnot.Where(x => x == Idx).Count() > 0)
                        pagesWithAnnot.Remove(Idx);
                }
            }
        }
        #endregion ThumbnailEvents

        /// <summary>
        /// Fired, when the shown page of the gdViewer has changed
        /// </summary>
        private void gdViewer1_PageChanged()
        {
            var tableFrame = gdViewer1.GetAnnotationFromIdx(0);
            if (tableFrame != null)
            {
                UpdateTableFrameMemory(tableFrame.Left, tableFrame.Top, tableFrame.Width, tableFrame.Height);
            }
            else
                UndefineTable();
        }
    }
}
