using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokuExtractorCore.Model;

namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    public partial class ucGeneralPropertyEditor : UserControl
    {
        private DocumentClassTemplate classTemplate = new DocumentClassTemplate();

        public ucGeneralPropertyEditor()
        {
            InitializeComponent();
        }

        public void ShowGeneralProperties(DocumentClassTemplate classTemplate)
        {
            this.classTemplate = classTemplate;

            if (this.classTemplate != null)
            {
                txtClassName.Text = this.classTemplate.TemplateClassName;
                txtGroupName.Text = this.classTemplate.TemplateGroupName;
                txtIban.Text = this.classTemplate.PreSelectionCondition.IBANs;

                txtKeyWords.Text = string.Empty;
                if (this.classTemplate.KeyWords != null)
                    foreach (var item in this.classTemplate.KeyWords)
                    {
                        txtKeyWords.Text = txtKeyWords.Text + item + Environment.NewLine;
                    }
            }
        }

        public DocumentClassTemplate GetDocumentClassTemplateWithChangedGeneralProperties()
        {
            var retVal = this.classTemplate;

            retVal.TemplateClassName = txtClassName.Text;
            retVal.TemplateGroupName = txtGroupName.Text;
            retVal.PreSelectionCondition.IBANs = txtIban.Text;

            var splitArray = new string[1];
            splitArray[0] = Environment.NewLine;
            var regexArray = txtKeyWords.Text.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);

            retVal.KeyWords = new List<string>();
            foreach (var item in regexArray)
            {
                retVal.KeyWords.Add(item);
            }

            return retVal;
        }
    }
}
