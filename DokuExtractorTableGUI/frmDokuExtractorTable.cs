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

namespace DokuExtractorTableGUI
{
    public partial class frmDokuExtractorTable : Form
    {
        #region Variables
        private bool isTableDefined = false;
        private string allTableLines = string.Empty;
        private string allTableColumns = string.Empty;

        private float tableFrameLeft = 0;
        private float tableFrameTop = 0;
        private float tableFrameWidth = 0;
        private float tableFrameHeight = 0;

        private GdPicturePDF gdPdf = new GdPicturePDF();
        private AnnotationManager annotManager = new AnnotationManager();
        #endregion Variables

        #region Initialization
        public frmDokuExtractorTable()
        {
            InitializeComponent();

            var license = new GdPicture14.LicenseManager();
            license.RegisterKEY("***REMOVED***");

            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
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
            }

            UpdateInstructionLabel(gdStatus);
            DisableColumnButtons();
        }
        #endregion Initialization

        #region ButtonClicks
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

        private void butAddColumnRight_Click(object sender, EventArgs e)
        {
            DisableTableDefinitionButtons();

            float srcTop = this.tableFrameTop - (this.tableFrameHeight / 2);
            float srcLeft = this.tableFrameLeft + (this.tableFrameWidth / 2) - 0.1F;
            float dstTop = srcTop + this.tableFrameHeight;
            float dstLeft = this.tableFrameLeft + (this.tableFrameWidth / 2) - 0.1F;

            var line = annotManager.AddLineAnnot(Color.Blue, srcLeft, srcTop, dstLeft, dstTop);
            line.BorderWidth = 0.05F;
            line.CanResize = false;
            line.CanRotate = false;
        }

        private void butAddColumnLeft_Click(object sender, EventArgs e)
        {
            DisableTableDefinitionButtons();

            float srcTop = this.tableFrameTop - (this.tableFrameHeight / 2);
            float srcLeft = this.tableFrameLeft - (this.tableFrameWidth / 2) + 0.1F;
            float dstTop = srcTop + this.tableFrameHeight;
            float dstLeft = this.tableFrameLeft - (this.tableFrameWidth / 2) + 0.1F;

            var line = annotManager.AddLineAnnot(Color.Blue, srcLeft, srcTop, dstLeft, dstTop);
            line.BorderWidth = 0.05F;
            line.CanResize = false;
            line.CanRotate = false;
        }

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
        }

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
        private void gdViewer1_AnnotationAddedByUser(int AnnotationIdx)
        {
            if (isTableDefined && AnnotationIdx == 0)
            {
                var annot = gdViewer1.GetAnnotationFromIdx(AnnotationIdx);
                annot.CanRotate = false;

                UpdateTableFrameMemory(annot.Left, annot.Top, annot.Width, annot.Height);

                EnableColumnButtons();
            }

            UpdateInstructionLabel(GdPictureStatus.OK);
        }

        private void gdViewer1_AnnotationMoved(int AnnotationIdx)
        {
            if (AnnotationIdx == 0)
                UpdateTableFrameAndColumns(false);
            else
                TameMovedColumnLine(AnnotationIdx);
        }

        private void gdViewer1_AnnotationResized(int AnnotationIdx)
        {
            if (AnnotationIdx == 0)
                UpdateTableFrameAndColumns(true);
        }
        #endregion GdViewerEvents

        #region FrameLogic
        private void UpdateTableFrameAndColumns(bool rezised)
        {
            var tableFrame = gdViewer1.GetAnnotationFromIdx(0);

            if (tableFrame != null)
            {
                UpdateColumnPositionsAndSizes(tableFrame.Left, tableFrame.Top, tableFrame.Width, tableFrame.Height, rezised);
                UpdateTableFrameMemory(tableFrame.Left, tableFrame.Top, tableFrame.Width, tableFrame.Height);
            }
        }

        private void UpdateTableFrameMemory(float left, float top, float width, float height)
        {
            this.tableFrameLeft = left;
            this.tableFrameTop = top;
            this.tableFrameWidth = width;
            this.tableFrameHeight = height;
        }

        private void UpdateColumnPositionsAndSizes(float newTableFrameLeft, float newTableFrameTop, float newTableFrameWidth, float newTableFrameHeight, bool rezised)
        {
            var leftDif = newTableFrameLeft - this.tableFrameLeft;
            var topDif = newTableFrameTop - this.tableFrameTop;
            var widthDif = newTableFrameWidth - this.tableFrameWidth;
            var heightDif = newTableFrameHeight - this.tableFrameHeight;

            var annotCount = gdViewer1.GetAnnotationCount();

            while (annotCount > 1)
            {
                var annot = gdViewer1.GetAnnotationFromIdx(annotCount - 1);

                if (rezised)
                {
                    if (annot.Left <= newTableFrameLeft - (newTableFrameWidth / 2) || annot.Left >= newTableFrameLeft + (newTableFrameWidth / 2))
                        gdViewer1.DeleteAnnotation(annotCount - 1);

                    annot.Top = annot.Top + topDif;
                    annot.Height = annot.Height + heightDif;
                }
                else
                {
                    annot.Left = annot.Left + leftDif;
                    annot.Top = annot.Top + topDif;
                }

                annotCount--;
            }
        }

        private void TameMovedColumnLine(int annotIndex)
        {
            var annot = gdViewer1.GetAnnotationFromIdx(annotIndex);

            if (annot.Left <= this.tableFrameLeft - (this.tableFrameWidth / 2) || annot.Left >= this.tableFrameLeft + (this.tableFrameWidth / 2))
                gdViewer1.DeleteAnnotation(annotIndex);
            else
            {
                annot.Top = this.tableFrameTop;
            }
        }
        #endregion FrameLogic

        #region Extraction
        private void ExtractAllTableLines()
        {
            var left = this.tableFrameLeft - (this.tableFrameWidth / 2);
            var top = this.tableFrameTop - (this.tableFrameHeight / 2);
            allTableLines = gdViewer1.GetPageTextArea(left, top, this.tableFrameWidth, this.tableFrameHeight);
        }

        private void ExtractAllTableColumns()
        {
            var annotList = new List<Annotation>();
            var annotCount = gdViewer1.GetAnnotationCount();

            while (annotCount > 1)
            {
                var annot = gdViewer1.GetAnnotationFromIdx(annotCount - 1);
                annotList.Add(annot);

                annotCount--;
            }

            var leftFence = this.tableFrameLeft - (this.tableFrameWidth / 2);
            var rightFence = this.tableFrameLeft + (this.tableFrameWidth / 2);

            var annotListOrdered = annotList.OrderBy(x => x.Left);
            annotCount = annotListOrdered.Count();
            var columnLineNo = 0;
            Annotation prevAnnot = null;

            foreach (var annot in annotListOrdered)
            {

                if (columnLineNo == 0)
                {
                    allTableColumns = allTableColumns + gdViewer1.GetPageTextArea(leftFence, annot.Top - (annot.Height / 2), annot.Left - leftFence, annot.Height)
                                      + Environment.NewLine + "|||" + Environment.NewLine;
                }

                if (prevAnnot != null)
                {
                    allTableColumns = allTableColumns + gdViewer1.GetPageTextArea(prevAnnot.Left, annot.Top - (annot.Height / 2), annot.Left - prevAnnot.Left, annot.Height)
                                      + Environment.NewLine + "|||" + Environment.NewLine;
                }

                if (columnLineNo == annotCount - 1)
                {
                    allTableColumns = allTableColumns + gdViewer1.GetPageTextArea(annot.Left, annot.Top - (annot.Height / 2), rightFence - annot.Left, annot.Height);
                }

                prevAnnot = annot;
                columnLineNo++;
            }

            allTableColumns = allTableColumns.TrimEnd('|').TrimEnd('|').TrimEnd('|');

        }
        #endregion Extraction

        #region Clearance
        private void RemoveAllAnnotations()
        {
            var annotCount = gdViewer1.GetAnnotationCount();

            while (annotCount > 0)
            {
                gdViewer1.DeleteAnnotation(annotCount - 1);
                annotCount--;
            }
        }

        private void UndefineTable()
        {
            allTableLines = string.Empty;
            isTableDefined = false;
            UpdateInstructionLabel(GdPictureStatus.OK);

            DisableColumnButtons();
            EnableTableDefinitionButtons();
        }

        private void UndefineColumns()
        {
            allTableColumns = string.Empty;
        }
        #endregion Clearence

        #region VisualAppearance
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

        private void EnableColumnButtons()
        {
            butAddColumnLeft.Enabled = true;
            butAddColumnRight.Enabled = true;
        }

        private void DisableColumnButtons()
        {
            butAddColumnLeft.Enabled = false;
            butAddColumnRight.Enabled = false;
        }

        private void EnableTableDefinitionButtons()
        {
            butAddTableDefinitionTop.Enabled = true;
            butAddTableDefinitionBottom.Enabled = true;
        }

        private void DisableTableDefinitionButtons()
        {
            butAddTableDefinitionTop.Enabled = false;
            butAddTableDefinitionBottom.Enabled = false;
        }
        #endregion VisualAppearance
    }
}
