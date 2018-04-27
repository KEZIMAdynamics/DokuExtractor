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
        public void ShowPropertiesAndDataFields(DocumentClassTemplate classTemplate)
        {
            ShowGeneralProperties(classTemplate);
            ShowDataFields(classTemplate);
        }

        /// <summary>
        /// Shows general properties and data fields of a group template
        /// </summary>
        public void ShowPropertiesAndDataFields(DocumentGroupTemplate groupTemplate)
        {
            ShowGeneralProperties(groupTemplate);
            ShowDataFields(groupTemplate);
        }

        /// <summary>
        /// Adds a new data field to ucDataFieldEditor
        /// </summary>
        public void AddDataFieldClassTemplate()
        {
            ucDataFieldEditor1.AddDataFieldClassTemplate();
        }

        /// <summary>
        /// Adds a new data field (group template) to ucDataFieldEditor
        /// </summary>
        public void AddDataFieldGroupTemplate()
        {
            ucDataFieldEditor1.AddDataFieldGroupTemplate();
        }

        /// <summary>
        /// Returns the class template with changed general properties
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedGeneralProperties()
        {
            return ucGeneralPropertyEditor1.GetDocumentClassTemplateWithChangedGeneralProperties();
        }

        /// <summary>
        /// Returns the group template with changed general properties
        /// </summary>
        public DocumentGroupTemplate GetDocumentGroupTemplateWithChangedGeneralProperties()
        {
            return ucGeneralPropertyEditor1.GetDocumentGroupTemplateWithChangedGeneralProperties();
        }

        /// <summary>
        /// Returns the class template with changed data fields
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedDataFields()
        {
            return ucDataFieldEditor1.GetDocumentClassTemplateWithChangedDataFields();
        }

        public DocumentGroupTemplate GetDocumentGroupTemplateWithChangedDataFields()
        {
            return ucDataFieldEditor1.GetDocumentGroupTemplateWithChangedDataFields();
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
        /// Shows the general properties of a group template
        /// </summary>
        private void ShowGeneralProperties(DocumentGroupTemplate groupTemplate)
        {
            ucGeneralPropertyEditor1.ShowGeneralProperties(groupTemplate);
        }

        /// <summary>
        /// Shows the data fields of a class template
        /// </summary>
        private void ShowDataFields(DocumentClassTemplate classTemplate)
        {
            ucDataFieldEditor1.ShowDataFields(classTemplate);
        }

        private void ShowDataFields(DocumentGroupTemplate groupTemplate)
        {
            ucDataFieldEditor1.ShowDataFields(groupTemplate);
        }

        private void FireRegexExpressionHelper(Guid id, DataFieldTypes dataFieldType)
        {
            RegexExpressionHelper?.Invoke(id, dataFieldType);
        }
    }
}
