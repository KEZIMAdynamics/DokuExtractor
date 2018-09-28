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
        public delegate void RegexOrPositionHelperHandler(Guid id, DataFieldType dataFieldType, DataFieldMode dataFieldMode);
        /// <summary>
        /// Fired, when user wishes to start the regex expression helper or area position helper
        /// </summary>
        public event RegexOrPositionHelperHandler RegexOrPositionHelper;

        public ucSingleTemplateEditor()
        {
            InitializeComponent();
            ucDataFieldEditor1.RegexOrPositionHelper += FireRegexOrPositionHelper;
        }

        /// <summary>
        /// Activates the regex expression helper for defining regex expressions
        /// </summary>
        public void ActivateRegexExpressionHelper()
        {
            ucDataFieldEditor1.ActivateRegexExpressionHelper();
        }

        /// <summary>
        /// Shows general properties and data fields of a class template
        /// </summary>
        /// <param name="classTemplate">Class template</param>
        public void ShowPropertiesAndDataFields(DocumentClassTemplate classTemplate)
        {
            ShowGeneralProperties(classTemplate);
            ShowDataFields(classTemplate);
        }

        /// <summary>
        /// Shows general properties and data fields of a group template
        /// </summary>
        /// <param name="groupTemplate">Group template</param>
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
        /// Adds a new conditional field to ucDataFieldEditor
        /// </summary>
        public void AddConditionalField(bool isGroupTemplate)
        {
            ucDataFieldEditor1.AddConditionalField(isGroupTemplate);
        }

        /// <summary>
        /// Adds a new data field (group template) to the user control
        /// </summary>
        public void AddDataFieldGroupTemplate()
        {
            ucDataFieldEditor1.AddDataFieldGroupTemplate();
        }

        /// <summary>
        /// Adds a new calculation field to the user control
        /// </summary>
        public void AddCalculationField()
        {
            ucDataFieldEditor1.AddCalculationField();
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
        /// Returns the class template with changed data fields and conditional fields
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedFields()
        {
            return ucDataFieldEditor1.GetDocumentClassTemplateWithChangedFields();
        }

        /// <summary>
        /// Returns the group template with changed data fields and calculation fields
        /// </summary>
        public DocumentGroupTemplate GetDocumentGroupTemplateWithChangedFields()
        {
            return ucDataFieldEditor1.GetDocumentGroupTemplateWithChangedFields();
        }

        /// <summary>
        /// Chagnes a regex expression or adds an addtional regex string to the regex expression list
        /// </summary>
        /// <param name="regexHelperID">ID of the regex expression, which shall be changed</param>
        /// <param name="regex">Regex expression</param>
        /// <param name="additionalRegex">Shall the regex expression be added to the regex expression list or shall it overwrite the list completely?</param>
        public void ChangeOrAddRegexExpression(Guid regexHelperID, string regex, bool additionalRegex)
        {
            ucDataFieldEditor1.ChangeOrAddRegexExpression(regexHelperID, regex, additionalRegex);
        }

        /// <summary>
        /// Changes or defines a new value area
        /// </summary>
        /// <param name="positionHelperID">ID of the area position, which shall be changed</param>
        /// <param name="areaInfo">percental area info</param>
        public void ChangeValueArea(Guid positionHelperID, PercentalAreaInfo areaInfo)
        {
            ucDataFieldEditor1.ChangeValueArea(positionHelperID, areaInfo);
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

        /// <summary>
        /// Shows the data fields of a group template
        /// </summary>
        /// <param name="groupTemplate">Group template</param>
        private void ShowDataFields(DocumentGroupTemplate groupTemplate)
        {
            ucDataFieldEditor1.ShowDataFields(groupTemplate);
        }

        private void FireRegexOrPositionHelper(Guid id, DataFieldType dataFieldType, DataFieldMode dataFieldMode)
        {
            RegexOrPositionHelper?.Invoke(id, dataFieldType, dataFieldMode);
        }
    }
}
