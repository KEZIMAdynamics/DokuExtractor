using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucViewerBase : UserControl
    {
        public delegate void TextSelectedHandler(string selectedText);
        public event TextSelectedHandler TextSelected;

        public ucViewerBase()
        {
            InitializeComponent();
        }

        public virtual void LoadPdf(string pdfPath)
        {
            MessageBox.Show("DLL not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void FireTextSelected(string selectedText)
        {
            TextSelected?.Invoke(selectedText);
        }
    }
}
