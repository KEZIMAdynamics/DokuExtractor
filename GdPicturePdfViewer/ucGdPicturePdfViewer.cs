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

        public ucGdPicturePdfViewer()
        {
            InitializeComponent();
            var license = new GdPicture14.LicenseManager();
            license.RegisterKEY("***REMOVED***");
        }

        public override void LoadPdf(string pdfPath)
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
                    FireTextSelected(text);
                    Clipboard.SetText(text);
                }
            }
        }
    }
}
