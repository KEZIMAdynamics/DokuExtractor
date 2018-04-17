using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucViewer : UserControl
    {
        public string ViewerPluginPath { get; set; } = @"G:\DokuExtractor\GdPicturePdfViewer\bin\Debug\GdPicturePdfViewer.dll";

        public delegate void TextSelectedHandler(string selectedText);
        public event TextSelectedHandler TextSelected;

        ucViewerBase viewerControlBase;

        public ucViewer()
        {
            InitializeComponent();
        }

        private void ucViewer_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
                LoadViewerPlugin(ViewerPluginPath);
        }

        private void LoadViewerPlugin(string pluginPath)
        {
            //var viewerControl = new ucViewerBase();
            var plugin = Assembly.LoadFrom(pluginPath);

            var types = plugin.GetTypes();
            foreach (var type in types)
            {
                if (typeof(ucViewerBase).IsAssignableFrom(type))
                {
                    viewerControlBase = (ucViewerBase)Activator.CreateInstance(type);
                }
            }

            if (viewerControlBase != null)
            {
                viewerControlBase.TextSelected += ViewerControlBase_TextSelected;
                viewerControlBase.Dock = DockStyle.Fill;
                Controls.Add(viewerControlBase);
            }
        }

        private void ViewerControlBase_TextSelected(string selectedText)
        {
            TextSelected?.Invoke(selectedText);
        }

        public void LoadPdf(string pdfPath)
        {
            viewerControlBase?.LoadPdf(pdfPath);
        }
    }
}
