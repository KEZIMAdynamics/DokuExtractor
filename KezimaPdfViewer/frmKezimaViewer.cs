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

namespace KezimaPdfViewer
{
    public partial class frmKezimaViewer : Form
    {
        public frmKezimaViewer()
        {
            InitializeComponent();
        }

        private async void frmKezimaViewer_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
            {
                var pdfPath = Path.Combine(Application.StartupPath, "Files", "File1.pdf");
                await ucKezimaPdfViewer1.LoadPdf(pdfPath);
            }
        }
    }
}
