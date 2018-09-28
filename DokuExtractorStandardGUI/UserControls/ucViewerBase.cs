using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokuExtractorStandardGUI.Localization;
using DokuExtractorCore.Model;

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucViewerBase : UserControl
    {
        public delegate void TextSelectedHandler(string selectedText, PercentalAreaInfo areaInfo);
        public event TextSelectedHandler TextSelected;

        public ucViewerBase()
        {
            InitializeComponent();
        }

        public virtual async Task LoadPdf(string pdfPath)
        {
            MessageBox.Show(Translation.LanguageStrings.MsgDllNotFound, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public virtual void CloseDisplayedPdf()
        {
            MessageBox.Show(Translation.LanguageStrings.MsgDllNotFound, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void FireTextSelected(string selectedText, int pageNumber, float percentalTopLeftX, float percentalTopLeftY, float percentalWidth, float percentalHeight)
        {
            var areaInfo = new PercentalAreaInfo()
            {
                PageNumber = pageNumber,
                TopLeftX = percentalTopLeftX,
                TopLeftY = percentalTopLeftY,
                Width = percentalWidth,
                Height = percentalHeight
            };

            TextSelected?.Invoke(selectedText, areaInfo);
        }
    }
}
