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

namespace GdPicturePdfViewer
{
    public partial class ucGdPicturePdfViewer : UserControl
    {
        public delegate void TextSelectedHandler(string selectedText);
        public event TextSelectedHandler TextSelected;

        public ucGdPicturePdfViewer()
        {
            InitializeComponent();
            var license = new GdPicture14.LicenseManager();
            license.RegisterKEY("***REMOVED***");
        }

        public void LoadPdf(string pdfPath)
        {
            var gdPdf = new GdPicturePDF();
            var gdStatus = gdPdf.LoadFromFile(pdfPath, false);
            if (gdStatus == GdPictureStatus.OK)
            {
                gdViewer1.DisplayFromGdPicturePDF(gdPdf);
                thumbnailEx1.LoadFromGdViewer(gdViewer1);
            }
        }

        private void gdViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            if (gdViewer1.IsRect())
            {
                float left = 0;
                float top = 0;
                float width = 0;
                float height = 0;

                gdViewer1.GetRectCoordinatesOnDocumentInches(ref left, ref top, ref width, ref height);
                var text = gdViewer1.GetPageTextArea(gdViewer1.CurrentPage, left, top, width, height);
                TextSelected?.Invoke(text);
            }
        }
    }
}
