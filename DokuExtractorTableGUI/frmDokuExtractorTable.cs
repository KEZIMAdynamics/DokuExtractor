﻿using System;
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
        #region Initialization
        public frmDokuExtractorTable()
        {
            InitializeComponent();

            var license = new GdPicture14.LicenseManager();
            //TODO: Enter License Key here:
            license.RegisterKEY("");

            this.CenterToScreen();
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;

            ucDokuViewerGdPicture1.TableDefinitonStateChanged += UpdateInstructionLabel;
        }

        private void frmDokuExtractorTable_Load(object sender, EventArgs e)
        {
            var pdfPath = Path.Combine(Application.StartupPath, "TableFiles", "TableFileMultiPage1.pdf");
            var gdPdf = new GdPicturePDF();

            var gdStatus = gdPdf.LoadFromFile(pdfPath, false);
            if (gdStatus == GdPictureStatus.OK)
                ucDokuViewerGdPicture1.LoadGdPdf(gdPdf);

            this.WindowState = FormWindowState.Maximized;
            UpdateInstructionLabel(false);
        }
        #endregion Initialization

        #region ButtonClicks
        /// <summary>
        /// Fills the variables ucDokuViewerGdPicture1.AllTableLines and allTableColumns and displays all the extracted text within the textBox
        /// </summary>
        private void butTest_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;

            var extractionResult = ucDokuViewerGdPicture1.ExtractAllTableLinesAndColumns();

            foreach (var extractionObject in extractionResult)
            {
                var allTableLines = extractionObject[0];
                var allTableColumns = extractionObject[1];

                textBox1.Text = textBox1.Text + "All Table Lines:" + Environment.NewLine + Environment.NewLine
                                + allTableLines + Environment.NewLine + Environment.NewLine + Environment.NewLine
                                + "All Table Columns:" + Environment.NewLine + Environment.NewLine
                                + allTableColumns + Environment.NewLine + Environment.NewLine
                                + "__________________________________________________" + Environment.NewLine + Environment.NewLine;

                var tableProcessor = new TableProcessor(Application.StartupPath);
                var table = tableProcessor.BuildTableFromLinesAndColumns(tableProcessor.LoadTableLinesFromString(allTableLines), tableProcessor.LoadTableColumnsFromString(allTableColumns));

                var tableViewer = new frmTableViewer();
                tableViewer.ShowTable(table);
                tableViewer.Show();
            }
        }

        /// <summary>
        /// Removes all annotations (table frame and column separation lines) of the displayed page and resets variables and output text
        /// </summary>
        private void butUndoPage_Click(object sender, EventArgs e)
        {
            ucDokuViewerGdPicture1.UndoPage();
            textBox1.Text = string.Empty;
        }

        /// <summary>
        /// Removes all annotations (table frame and column separation lines) of all pages and resets variables and output text
        /// </summary>
        private void butUndoAll_Click(object sender, EventArgs e)
        {
            ucDokuViewerGdPicture1.UndoAll();
            textBox1.Text = string.Empty;
        }
        #endregion ButtonClicks

        #region VisualAppearance
        /// <summary>
        /// Updates the displayed instruction text
        /// </summary>
        /// <param name="gdStatus">Status of processed GdPicture function</param>
        private void UpdateInstructionLabel(bool isTableDefined)
        {
            if (isTableDefined)
                lblInstruction.Text = "Please add some column definitions";
            else
                lblInstruction.Text = "Please add a table definition";

        }
        #endregion VisualAppearance
    }
}
