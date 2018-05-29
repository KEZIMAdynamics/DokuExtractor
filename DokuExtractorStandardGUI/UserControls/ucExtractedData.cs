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
using DokuExtractorStandardGUI.Model;

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucExtractedData : UserControl
    {
        public ucExtractedData()
        {
            InitializeComponent();
        }

        private void ucExtractedData_Load(object sender, EventArgs e)
        {
            Localize();
        }

        /// <summary>
        /// Shows the content of the extraction result
        /// </summary>
        /// <param name="extractionResult">Extraction result of type FieldExtractionResult</param>
        public void ShowExtractedData(FieldExtractionResult extractionResult)
        {
            txtClassName.Text = extractionResult.TemplateClassName;
            txtGroupName.Text = extractionResult.TemplateGroupName;

            ucExtractedDataFields1.ShowExtractedDataFields(extractionResult.DataFields);
            ucExtractedCalculationFields1.ShowExtractedCalculationFields(extractionResult.CalculationFields);
            ucExtractedConditionalFields1.ShowExtractedConditionalFields(extractionResult.ConditionalFields);
        }

        /// <summary>
        /// Checks, if all data fields are filled with data
        /// </summary>
        public bool CheckIfAllDataFieldsAreFilled()
        {
            return ucExtractedDataFields1.CheckIfAllDataFieldsAreFilled();
        }

        /// <summary>
        /// Checks, if all calculation results equal with their validation value(s)
        /// </summary>
        public bool CheckIfAllCalculationResultsEqualValidation()
        {
            return ucExtractedCalculationFields1.CheckIfAllCalculationResultsEqualValidation();
        }

        /// <summary>
        /// Checks, if all conditional fields are filled with data
        /// </summary>
        public bool CheckIfAllConditionalFieldsAreFilled()
        {
            return ucExtractedConditionalFields1.CheckIfAllConditionalFieldsAreFilled();
        }

        /// <summary>
        /// Returns the shown (and maybe editted) extraction result
        /// </summary>
        public FieldExtractionResult GetFieldExtractionResult()
        {
            var retVal = new FieldExtractionResult();

            retVal.TemplateClassName = txtClassName.Text;
            retVal.TemplateGroupName = txtGroupName.Text;

            retVal.DataFields = ucExtractedDataFields1.GetDataFieldExtractionResult();
            retVal.CalculationFields = ucExtractedCalculationFields1.GetCalculationFieldExtractionResult();
            retVal.ConditionalFields = ucExtractedConditionalFields1.GetConditionalFieldExtractionResult();

            return retVal;
        }

        private void Localize()
        {
            lblTemplateClassName.Text = Translation.LanguageStrings.TemplateClassName;
            lblTemplateGroupName.Text = Translation.LanguageStrings.TemplateGroupName;
        }
    }
}
