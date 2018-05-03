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
    public partial class ucExtractedData : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<DataFieldResult> DataFieldResults { get; set; } = new BindingList<DataFieldResult>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<CalculationFieldResult> CalculationFieldResults { get; set; } = new BindingList<CalculationFieldResult>();

        public ucExtractedData()
        {
            InitializeComponent();
        }

        private void ucExtractedData_Load(object sender, EventArgs e)
        {
            Localization();
        }

        /// <summary>
        /// Shows the content of the extraction result
        /// </summary>
        /// <param name="extractionResult">Extraction result of type FieldExtractionResult</param>
        public void ShowExtractedData(FieldExtractionResult extractionResult)
        {
            txtClassName.Text = extractionResult.TemplateClassName;
            txtGroupName.Text = extractionResult.TemplateGroupName;

            DataFieldResults = new BindingList<DataFieldResult>(extractionResult.DataFields);
            CalculationFieldResults = new BindingList<CalculationFieldResult>(extractionResult.CalculationFields);

            dgvDataFields.DataSource = extractionResult.DataFields;
            dgvCalculationFields.DataSource = extractionResult.CalculationFields;
        }

        /// <summary>
        /// Checks, if all data fields are filled with data
        /// </summary>
        public bool CheckIfAllDataFieldsAreFilled()
        {
            foreach (DataFieldResult dataField in dgvDataFields.DataSource as List<DataFieldResult>)
            {
                if (string.IsNullOrWhiteSpace(dataField.Value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the shown (and maybe editted) extraction result
        /// </summary>
        public FieldExtractionResult GetFieldExtractionResult()
        {
            var retVal = new FieldExtractionResult();

            retVal.TemplateClassName = txtClassName.Text;
            retVal.TemplateGroupName = txtGroupName.Text;

            foreach (DataFieldResult dataField in dgvDataFields.DataSource as List<DataFieldResult>)
            {
                retVal.DataFields.Add(dataField);
            }

            foreach (CalculationFieldResult calcField in dgvCalculationFields.DataSource as List<CalculationFieldResult>)
            {
                retVal.CalculationFields.Add(calcField);
            }

            return retVal;
        }

        private void Localization()
        {
            lblTemplateClassName.Text = Translation.LanguageStrings.TemplateClassName;
            lblTemplateGroupName.Text = Translation.LanguageStrings.TemplateGroupName;

            dgvDataFields.Columns["col" + nameof(DataFieldResult.Name)].HeaderText = Translation.LanguageStrings.DataFieldName;
            dgvDataFields.Columns["col" + nameof(DataFieldResult.Value)].HeaderText = Translation.LanguageStrings.DataFieldValue;
            dgvDataFields.Columns["col" + nameof(DataFieldResult.FieldType)].HeaderText = Translation.LanguageStrings.DataFieldType;

            dgvCalculationFields.Columns["colCalc" + nameof(CalculationFieldResult.Name)].HeaderText = Translation.LanguageStrings.CalculationFieldName;
            dgvCalculationFields.Columns["colCalc" + nameof(CalculationFieldResult.CalculationValue)].HeaderText = Translation.LanguageStrings.CalculationValue;
            dgvCalculationFields.Columns["colCalc" + nameof(CalculationFieldResult.FieldType)].HeaderText = Translation.LanguageStrings.CalculationFieldType;
            dgvCalculationFields.Columns["colCalc" + nameof(CalculationFieldResult.CalculationEqualsValidation)].HeaderText = Translation.LanguageStrings.CalculationEqualsValidation;
        }
    }
}
