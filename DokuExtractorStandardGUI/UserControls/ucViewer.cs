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
        /// <summary>
        /// Path of the used viewer plugin for viewing PDF files
        /// </summary>

        //TODO: Set path of used viewer plugin
        public string ViewerPluginPath { get; set; } = @"..\..\..\KezimaPdfViewer\bin\Debug\KezimaPdfViewer.dll";
        //public string ViewerPluginPath { get; set; } = @"..\..\..\GdPicturePdfViewer\bin\Debug\GdPicturePdfViewer.dll";

        public delegate void TextSelectedHandler(string selectedText);
        /// <summary>
        /// Fired, when some text has been selected within the viewer (contains the selected text)
        /// </summary>
        public event TextSelectedHandler TextSelected;

        ucViewerBase viewerControlBase;

        public ucViewer()
        {
            InitializeComponent();
            if (DesignMode == false)
                LoadViewerPlugin(ViewerPluginPath);
        }

        private void ucViewer_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Loads the viewer plugin, which shall be used for viewing PDF files
        /// </summary>
        /// <param name="pluginPath"></param>
        private void LoadViewerPlugin(string pluginPath)
        {
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

        /// <summary>
        /// Loads a PDF file into the file viewer
        /// </summary>
        /// <param name="pdfPath">Path of the PDF file</param>
        public async Task LoadPdf(string pdfPath)
        {
            if (viewerControlBase != null)
                await viewerControlBase?.LoadPdf(pdfPath);
        }

        public void CloseDisplayedPdf()
        {
            viewerControlBase?.CloseDisplayedPdf();
        }

        private void ViewerControlBase_TextSelected(string selectedText)
        {
            TextSelected?.Invoke(selectedText);
        }
    }
}
