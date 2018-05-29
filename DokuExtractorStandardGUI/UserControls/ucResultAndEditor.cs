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
using DokuExtractorStandardGUI.Localization;

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucResultAndEditor : UserControl
    {
        public delegate void TabSwitchedHandler(bool switchedToSingleTemplateEditor);
        /// <summary>
        /// Fired, when user or program has switched to another tab of the tab control
        /// </summary>
        public event TabSwitchedHandler TabSwitched;

        public delegate void RegexExpressionHelperHandler(Guid id, DataFieldType dataFieldType);
        /// <summary>
        /// Fired, when user wishes to start the regex expression helper
        /// </summary>
        public event RegexExpressionHelperHandler RegexExpressionHelper;

        public ucResultAndEditor()
        {
            InitializeComponent();
            ucSingleTemplateEditor1.RegexExpressionHelper += FireRegexExpressionHelper;
        }

        private void ucResultAndEditor_Load(object sender, EventArgs e)
        {
            Localize();
        }

        /// <summary>
        /// Disables the built in editor
        /// </summary>
        public void DisableBuiltInEditor()
        {
            tabSingleTemplateEditor.Enabled = false;
        }

        /// <summary>
        /// Switches to single template editor tab or to extracted data tab
        /// </summary>
        /// <param name="switchToSingleTemplateEditor">Switch to single template editor? (Or to extracted data tab?)</param>
        public void SwitchTab(bool switchToSingleTemplateEditor)
        {
            if (switchToSingleTemplateEditor == true)
                tabControl1.SelectedTab = tabSingleTemplateEditor;
            else
                tabControl1.SelectedTab = tabExtractedData;
        }

        /// <summary>
        /// Shows the extracted date within ucExtractedData and the used template within ucSingleTemplateEditor
        /// </summary>
        /// <param name="result">Extracted data</param>
        /// <param name="classTemplate">Used class template</param>
        public void ShowExtractedData(FieldExtractionResult result, DocumentClassTemplate classTemplate)
        {
            ucExtractedData1.ShowExtractedData(result);
            ucSingleTemplateEditor1.ShowPropertiesAndDataFields(classTemplate);
            ucSingleTemplateEditor1.ActivateRegexExpressionHelper();
        }

        /// <summary>
        /// Shows a class template (general properties and data fields) within ucSingleTemplateEditor
        /// </summary>
        /// <param name="classTemplate">Class template</param>
        public void ShowPropertiesAndDataFields(DocumentClassTemplate classTemplate)
        {
            ucSingleTemplateEditor1.ShowPropertiesAndDataFields(classTemplate);
            ucExtractedData1.ShowExtractedData(new FieldExtractionResult());
            ucSingleTemplateEditor1.ActivateRegexExpressionHelper();
        }

        /// <summary>
        /// Returns the class (changed) class template, which is shown within ucSingleTemplateEditor
        /// </summary>
        public DocumentClassTemplate GetChangedDocumentClassTemplate()
        {
            var retVal = new DocumentClassTemplate();
            retVal = ucSingleTemplateEditor1.GetDocumentClassTemplateWithChangedGeneralProperties();
            var classTemplateWithChangedDataFields = ucSingleTemplateEditor1.GetDocumentClassTemplateWithChangedFields();
            retVal.DataFields = classTemplateWithChangedDataFields.DataFields;

            return retVal;
        }

        /// <summary>
        /// Adds a new data field to ucDataField
        /// </summary>
        public void AddDataField()
        {
            ucSingleTemplateEditor1.AddDataFieldClassTemplate();
            ucSingleTemplateEditor1.ActivateRegexExpressionHelper();
        }

        /// <summary>
        /// Adds a new conditional field to ucDataField
        /// </summary>
        public void AddConditionalField()
        {
            ucSingleTemplateEditor1.AddConditionalField();
        }

        /// <summary>
        /// Checks, if all data fields are filled with data
        /// </summary>
        public bool CheckIfAllDataFieldsAreFilled()
        {
            return ucExtractedData1.CheckIfAllDataFieldsAreFilled();
        }

        /// <summary>
        /// Checks, if all calculation results equal with their validation value(s)
        /// </summary>
        public bool CheckIfAllCalculationResultsEqualValidation()
        {
            return ucExtractedData1.CheckIfAllCalculationResultsEqualValidation();
        }

        /// <summary>
        /// Checks, if all conditional fields are filled with data
        /// </summary>
        public bool CheckIfAllConditionalFieldsAreFilled()
        {
            return ucExtractedData1.CheckIfAllConditionalFieldsAreFilled();
        }

        /// <summary>
        /// Returns the shown (and maybe editted) extraction result of ucExtractedData
        /// </summary>
        public FieldExtractionResult GetFieldExtractionResult()
        {
            return ucExtractedData1.GetFieldExtractionResult();
        }

        /// <summary>
        /// Chagnes a regex expression or adds an addtional regex string to the regex expression list
        /// </summary>
        /// <param name="regexHelperID">ID of the regex expression, which shall be changed</param>
        /// <param name="regex">Regex expression</param>
        /// <param name="additionalRegex">Shall the regex expression be added to the regex expression list or shall it overwrite the list completely?</param>
        public void ChangeOrAddRegexExpression(Guid regexHelperID, string regex, bool additionalRegex)
        {
            ucSingleTemplateEditor1.ChangeOrAddRegexExpression(regexHelperID, regex, additionalRegex);
        }

        private void Localize()
        {
            tabExtractedData.Text = Translation.LanguageStrings.ExtractedData;
            tabSingleTemplateEditor.Text = Translation.LanguageStrings.SingleTemplateEditor;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabSingleTemplateEditor)
                FireTabSwitched(true);
            else if (tabControl1.SelectedTab == tabExtractedData)
                FireTabSwitched(false);
        }

        private void FireTabSwitched(bool switchedToSingleTemplateEditor)
        {
            TabSwitched?.Invoke(switchedToSingleTemplateEditor);
        }

        private void FireRegexExpressionHelper(Guid id, DataFieldType dataFieldType)
        {
            RegexExpressionHelper?.Invoke(id, dataFieldType);
        }
    }
}
