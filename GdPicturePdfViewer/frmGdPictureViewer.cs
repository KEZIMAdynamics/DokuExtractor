using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GdPicturePdfViewer
{
    public partial class frmGdPictureViewer : Form
    {
        public frmGdPictureViewer()
        {
            InitializeComponent();
        }

        private void frmGdPictureViewer_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                var pdfPath = Path.Combine(Application.StartupPath, "Files", "File1.pdf");
                ucGdPicturePdfViewer1.LoadPdf(pdfPath);
            }
        }
    }
}
