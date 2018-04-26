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
    public partial class ucSingleTemplateEditor : UserControl
    {
        public delegate void RegexExpressionHelperHandler(Guid id, DataFieldTypes dataFieldType);
        /// <summary>
        /// Fired, when user wishes to start the regex expression helper
        /// </summary>
        public event RegexExpressionHelperHandler RegexExpressionHelper;

        public ucSingleTemplateEditor()
        {
            InitializeComponent();
            ucDataFieldEditor1.RegexExpressionHelper += FireRegexExpressionHelper;
        }

        public void ActivateRegexExpressionHelper()
        {
            ucDataFieldEditor1.ActivateRegexExpressionHelper();
        }

        /// <summary>
        /// Shows general properties and data fields of a class template
        /// </summary>
        /// <param name="classTemplate"></param>
        public void ShowPropertiesAndDataFields(DocumentClassTemplate classTemplate)
        {
            ShowGeneralProperties(classTemplate);
            ShowDataFields(classTemplate);
        }

        /// <summary>
        /// Adds a new data field to ucDataField
        /// </summary>
        public void AddDataField()
        {
            ucDataFieldEditor1.AddDataField();
        }

        /// <summary>
        /// Returns the class template with changed general properties
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedGeneralProperties()
        {
            return ucGeneralPropertyEditor1.GetDocumentClassTemplateWithChangedGeneralProperties();
        }

        /// <summary>
        /// Returns the class template with changed data fields
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedDataFields()
        {
            return ucDataFieldEditor1.GetDocumentClassTemplateWithChangedDataFields();
        }

        public void ChangeOrAddRegexExpression(Guid regexHelperID, string regex, bool additionalRegex)
        {
            ucDataFieldEditor1.ChangeOrAddRegexExpression(regexHelperID, regex, additionalRegex);
        }

        /// <summary>
        /// Shows the general properties of a class template
        /// </summary>
        private void ShowGeneralProperties(DocumentClassTemplate classTemplate)
        {
            ucGeneralPropertyEditor1.ShowGeneralProperties(classTemplate);
        }

        /// <summary>
        /// Shows the data fields of a class template
        /// </summary>
        private void ShowDataFields(DocumentClassTemplate classTemplate)
        {
            ucDataFieldEditor1.ShowDataFields(classTemplate);
        }

        private void FireRegexExpressionHelper(Guid id, DataFieldTypes dataFieldType)
        {
            RegexExpressionHelper?.Invoke(id, dataFieldType);
        }
    }
}
