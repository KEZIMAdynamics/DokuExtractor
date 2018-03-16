using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GdPicture14;
using System.IO;
using GdPicture14.Annotations;
using DokuExtractorCore;

namespace DokuExtractorTableGUI
{
    public partial class frmDokuExtractorTable : Form
    {
        #region Variables
        private bool isTableDefined = false;

        /// <summary>
        /// Text of the complete table frame (line by line)
        /// </summary>
        private string allTableLines = string.Empty;

        /// <summary>
        /// Text of all table colums (line by line) seperated by ||| between each column
        /// </summary>
        private string allTableColumns = string.Empty;

        // These four variables remember the position and size of the table frame
        private float tableFrameLeft = 0;
        private float tableFrameTop = 0;
        private float tableFrameWidth = 0;
        private float tableFrameHeight = 0;

        /// <summary>
        /// The AnnotationManager is necessary to add annotations (in this case: column separation lines) by code
        /// </summary>
        private AnnotationManager annotManager = new AnnotationManager();
        private GdPicturePDF gdPdf = new GdPicturePDF();
        #endregion Variables

        #region Initialization
        public frmDokuExtractorTable()
        {
            InitializeComponent();

            var license = new GdPicture14.LicenseManager();
            license.RegisterKEY("***REMOVED***");

            this.CenterToScreen();
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
        }

        private void frmDokuExtractorTable_Load(object sender, EventArgs e)
        {
            var pdfPath = Path.Combine(Application.StartupPath, "TableFiles", "TableFile1.pdf");
            var gdStatus = gdPdf.LoadFromFile(pdfPath, false);

            if (gdStatus == GdPictureStatus.OK)
            {
                gdViewer1.DisplayFromGdPicturePDF(gdPdf);
                annotManager = gdViewer1.GetAnnotationManager();
                //gdPdf.SetMeasurementUnit(PdfMeasurementUnit.PdfMeasurementUnitInch);
                this.WindowState = FormWindowState.Maximized;
            }

            UpdateInstructionLabel(gdStatus);
            DisableColumnButtons();
        }
        #endregion Initialization

        #region ButtonClicks
        /// <summary>
        /// After clicking the user can draw a frame to define the position and size of the table
        /// </summary>
        private void butAddTableDefinition_Click(object sender, EventArgs e)
        {
            isTableDefined = false;
            UpdateInstructionLabel(GdPictureStatus.OK);

            DisableColumnButtons();
            RemoveAllAnnotations();

            gdViewer1.ClearRect();
            gdViewer1.AddRectangleAnnotInteractive(false, true, Color.Empty, Color.Red, 0.05F, 1);

            isTableDefined = true;
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

            if (rotation == 270)
            {
                srcTop = this.tableFrameTop + (this.tableFrameHeight / 2) - 0.1F;
                srcLeft = this.tableFrameLeft + (this.tableFrameWidth / 2);
                dstTop = this.tableFrameTop + (this.tableFrameHeight / 2) - 0.1F;
                dstLeft = this.tableFrameLeft - (this.tableFrameWidth / 2);
            }
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

            if (rotation == 270)
            {
                srcTop = this.tableFrameTop - (this.tableFrameHeight / 2) + 0.1F;
                srcLeft = this.tableFrameLeft + (this.tableFrameWidth / 2);
                dstTop = this.tableFrameTop - (this.tableFrameHeight / 2) + 0.1F;
                dstLeft = this.tableFrameLeft - (this.tableFrameWidth / 2);
            }
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
        /// Fills the variables allTableLines and allTableColumns and displays all the extracted text within the textBox
        /// </summary>
        private void butTest_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            allTableLines = string.Empty;
            allTableColumns = string.Empty;

            ExtractAllTableLines();
            ExtractAllTableColumns();

            textBox1.Text = "All Table Lines:" + Environment.NewLine + Environment.NewLine
                            + allTableLines + Environment.NewLine + Environment.NewLine + Environment.NewLine
                            + "All Table Columns:" + Environment.NewLine + Environment.NewLine
                            + allTableColumns;

            var tableProcessor = new TableProcessor(Application.StartupPath);
            var table = tableProcessor.BuildTableFromLinesAndColumns(tableProcessor.LoadTableLinesFromString(allTableLines), tableProcessor.LoadTableColumnsFromString(allTableColumns));

            var tableViewer = new frmTableViewer();
            tableViewer.ShowTable(table);
            tableViewer.Show();

            // var lines = 
        }

        /// <summary>
        /// Removes all Annotations (table frame and column separation lines) and resets variables and output text
        /// </summary>
        private void butUndoAll_Click(object sender, EventArgs e)
        {
            RemoveAllAnnotations();
            UndefineColumns();
            UndefineTable();
            UpdateTableFrameMemory(0, 0, 0, 0);
            textBox1.Text = string.Empty;

            butTest.Enabled = true;
        }
        #endregion ButtonClicks

        #region GdViewerEvents
        /// <summary>
        /// Fired, when an annotation is added by user
        /// </summary>
        /// <param name="AnnotationIdx">Index of added annotation</param>
        private void gdViewer1_AnnotationAddedByUser(int AnnotationIdx)
        {
            if (isTableDefined && AnnotationIdx == 0) // Annotation with Index 0 is table frame, others are column separation 
            {
                var annot = gdViewer1.GetAnnotationFromIdx(AnnotationIdx);
                annot.CanRotate = false;

                if (gdPdf.GetPageRotation() == 270)
                {
                    if (annot.Rotation == 270 || annot.Rotation == 90)
                    {
                        annot.Rotation = 0;
                        var newWidth = annot.Height;
                        var newHeight = annot.Width;
                        annot.Width = newWidth;
                        annot.Height = newHeight;
                    }
                }
                UpdateTableFrameMemory(annot.Left, annot.Top, annot.Width, annot.Height);

                EnableColumnButtons();
            }

            UpdateInstructionLabel(GdPictureStatus.OK);
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
                    if (rotation == 270)
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

            if (rotation == 270)
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

        #region Extraction
        /// <summary>
        /// Extracts text of the complete table frame (line by line)
        /// </summary>
        private void ExtractAllTableLines()
        {
            var left = this.tableFrameLeft - (this.tableFrameWidth / 2);
            var top = this.tableFrameTop - (this.tableFrameHeight / 2);
            allTableLines = gdViewer1.GetPageTextArea(left, top, this.tableFrameWidth, this.tableFrameHeight);
        }

        /// <summary>
        /// Extracts text of all table colums (line by line) seperated by ||| between each column
        /// </summary>
        private void ExtractAllTableColumns()
        {
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

            if (rotation == 270)
            {
                leftFence = this.tableFrameTop - (this.tableFrameHeight / 2); // Left border of the table frame
                rightFence = this.tableFrameTop + (this.tableFrameHeight / 2); // Right border of the table frame
            }
            else
            {
                leftFence = this.tableFrameLeft - (this.tableFrameWidth / 2); // Left border of the table frame
                rightFence = this.tableFrameLeft + (this.tableFrameWidth / 2); // Right border of the table frame
            }

            var annotListOrdered = new List<Annotation>();

            if (rotation == 270)
                annotListOrdered = annotList.OrderBy(x => x.Top).ToList(); // Orders column separation lines by position (from left to right)
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
                    if (rotation == 270)
                        allTableColumns = allTableColumns + gdViewer1.GetPageTextArea(tableFrameLeft - (tableFrameWidth / 2), leftFence, annot.Width, annot.Top - leftFence)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                    else
                        allTableColumns = allTableColumns + gdViewer1.GetPageTextArea(leftFence, annot.Top - (annot.Height / 2), annot.Left - leftFence, annot.Height)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                }

                // If there is a previous handled column seperation line, the text of the area between that line an the currently handled line is extracted
                if (prevAnnot != null)
                {
                    if (rotation == 270)
                        allTableColumns = allTableColumns + gdViewer1.GetPageTextArea(tableFrameLeft - (tableFrameWidth / 2), prevAnnot.Top, annot.Width, annot.Top - prevAnnot.Top)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                    else
                        allTableColumns = allTableColumns + gdViewer1.GetPageTextArea(prevAnnot.Left, annot.Top - (annot.Height / 2), annot.Left - prevAnnot.Left, annot.Height)
                                          + Environment.NewLine + "|||" + Environment.NewLine;
                }

                // If it is the last column separation line, the text of the area between the right border of the table frame and the currently handled line is extracted
                if (columnLineNo == annotCount - 1)
                {
                    if (rotation == 270)
                        allTableColumns = allTableColumns + gdViewer1.GetPageTextArea(tableFrameLeft - (tableFrameWidth / 2), annot.Top, annot.Width, rightFence - annot.Top);
                    else
                        allTableColumns = allTableColumns + gdViewer1.GetPageTextArea(annot.Left, annot.Top - (annot.Height / 2), rightFence - annot.Left, annot.Height);
                }

                prevAnnot = annot;
                columnLineNo++;
            }

            allTableColumns = allTableColumns.TrimEnd('|').TrimEnd('|').TrimEnd('|');
        }
        #endregion Extraction

        #region Clearance
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
        /// Resets allTableLines and switches enabling of buttons
        /// </summary>
        private void UndefineTable()
        {
            allTableLines = string.Empty;
            isTableDefined = false;
            UpdateInstructionLabel(GdPictureStatus.OK);

            DisableColumnButtons();
            EnableTableDefinitionButtons();
        }

        /// <summary>
        /// Resets allTableColumns
        /// </summary>
        private void UndefineColumns()
        {
            allTableColumns = string.Empty;
        }
        #endregion Clearence

        #region VisualAppearance
        /// <summary>
        /// Updates the displayed instruction text
        /// </summary>
        /// <param name="gdStatus">Status of processed GdPicture function</param>
        private void UpdateInstructionLabel(GdPictureStatus gdStatus)
        {
            if (gdStatus == GdPictureStatus.OK)
            {
                if (isTableDefined)
                    lblInstruction.Text = "Please add some column definitions";
                else
                    lblInstruction.Text = "Please add a table definition";
            }
            else
                lblInstruction.Text = "ERROR: " + gdStatus.ToString();
        }

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
    }
}
