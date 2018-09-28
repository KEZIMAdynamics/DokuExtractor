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
using DokuExtractorStandardGUI.UserControls;

namespace GdPicturePdfViewer
{
    public partial class ucGdPicturePdfViewer : ucViewerBase
    {
        private GdPicturePDF gdPdf = new GdPicturePDF();
        private ToolTip tooltip = new ToolTip();

        public ucGdPicturePdfViewer()
        {
            InitializeComponent();

            var license = new GdPicture14.LicenseManager();
            //TODO: Enter License Key here:
            license.RegisterKEY("");
        }

        /// <summary>
        /// Loads a PDF file into the file viewer
        /// </summary>
        /// <param name="pdfPath">Path of the PDF file</param>
        public override async Task LoadPdf(string pdfPath)
        {
            gdPdf = new GdPicturePDF();
            var gdStatus = gdPdf.LoadFromFile(pdfPath, false);
            if (gdStatus == GdPictureStatus.OK)
            {
                gdViewer1.DisplayFromGdPicturePDF(gdPdf);
                thumbnailEx1.LoadFromGdViewer(gdViewer1);
            }
        }

        public override void CloseDisplayedPdf()
        {
            gdPdf.CloseDocument();
            gdViewer1.CloseDocument();
        }

        private void gdViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            if (gdViewer1.IsRect() && e.Button == MouseButtons.Left)
            {
                float left = 0;
                float top = 0;
                float width = 0;
                float height = 0;

                gdViewer1.GetRectCoordinatesOnDocumentInches(ref left, ref top, ref width, ref height);
                var text = gdViewer1.GetPageTextArea(gdViewer1.CurrentPage, left, top, width, height);
                if (string.IsNullOrEmpty(text) == false)
                {
                    tooltip.Hide(this);

                    float percentalTopLeftX = (float)gdViewer1.GetRectLeftOnDocument() / (float)gdViewer1.PageWidth;
                    float percentalTopLeftY = (float)gdViewer1.GetRectTopOnDocument() / (float)gdViewer1.PageHeight;
                    float percentalWidth = (float)gdViewer1.GetRectWidthOnDocument() / (float)gdViewer1.PageWidth;
                    float percentalHeight = (float)gdViewer1.GetRectHeightOnDocument() / (float)gdViewer1.PageHeight;

                    FireTextSelected(text, gdViewer1.CurrentPage, percentalTopLeftX, percentalTopLeftY, percentalWidth, percentalHeight);
                    Clipboard.SetText(text);
                    tooltip.Show(text, this, this.PointToClient(Control.MousePosition), 5000);
                }
            }
        }
    }
}
