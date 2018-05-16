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
        public delegate void ConditionalFieldCellDoubleClickHandler(object sender, DataGridViewCellEventArgs e);
        /// <summary>
        /// Fired, when a cell in dgvConditionalFields has been double clicked
        /// </summary>
        public event ConditionalFieldCellDoubleClickHandler ConditionalFieldCellDoubleClick;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<DataFieldResultDisplay> DataFieldResultsDisplayBinding { get; set; } = new BindingList<DataFieldResultDisplay>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<CalculationFieldResultDisplay> CalculationFieldResultsDisplayBinding { get; set; } = new BindingList<CalculationFieldResultDisplay>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<ConditionalFieldResult> ConditionalFieldResultBinding { get; set; } = new BindingList<ConditionalFieldResult>();

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

            DataFieldResultsDisplayBinding = new BindingList<DataFieldResultDisplay>();
            foreach (var dataField in extractionResult.DataFields)
            {
                DataFieldResultsDisplayBinding.Add(new DataFieldResultDisplay()
                {
                    Name = dataField.Name,
                    Value = dataField.Value,
                    FieldType = dataField.FieldType,
                    FieldTypeDisplayValue = Translation.TranslateFieldTypeEnum(dataField.FieldType)
                });
            }

            CalculationFieldResultsDisplayBinding = new BindingList<CalculationFieldResultDisplay>();
            foreach (var calcField in extractionResult.CalculationFields)
            {
                CalculationFieldResultsDisplayBinding.Add(new CalculationFieldResultDisplay()
                {
                    Name = calcField.Name,
                    CalculationValue = calcField.CalculationValue,
                    ValidationValues = calcField.ValidationValues,
                    CalculationEqualsValidation = calcField.CalculationEqualsValidation,
                    FieldType = calcField.FieldType,
                    FieldTypeDisplayValue = Translation.TranslateFieldTypeEnum(calcField.FieldType)
                });
            }

            ConditionalFieldResultBinding = new BindingList<ConditionalFieldResult>(extractionResult.ConditionalFields);

            dgvDataFields.DataSource = DataFieldResultsDisplayBinding;
            dgvCalculationFields.DataSource = CalculationFieldResultsDisplayBinding;
            dgvConditionalFields.DataSource = ConditionalFieldResultBinding;
        }

        /// <summary>
        /// Checks, if all data fields are filled with data
        /// </summary>
        public bool CheckIfAllDataFieldsAreFilled()
        {
            foreach (DataFieldResultDisplay dataField in dgvDataFields.DataSource as BindingList<DataFieldResultDisplay>)
            {
                if (string.IsNullOrWhiteSpace(dataField.Value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks, if all calculation results equal with their validation value(s)
        /// </summary>
        public bool CheckIfAllCalculationResultsEqualValidation()
        {
            foreach (CalculationFieldResultDisplay calcField in dgvCalculationFields.DataSource as BindingList<CalculationFieldResultDisplay>)
            {
                if (calcField.CalculationEqualsValidation == false)
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

            foreach (DataFieldResultDisplay dataField in dgvDataFields.DataSource as List<DataFieldResultDisplay>)
            {
                retVal.DataFields.Add(dataField);
            }

            foreach (CalculationFieldResultDisplay calcField in dgvCalculationFields.DataSource as List<CalculationFieldResultDisplay>)
            {
                retVal.CalculationFields.Add(calcField);
            }

            return retVal;
        }

        private void dgvConditionalFields_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FireConditionalFieldCellDoubleClick(sender, e);
        }

        private void FireConditionalFieldCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConditionalFieldCellDoubleClick?.Invoke(sender, e);
        }

        private void Localize()
        {
            lblTemplateClassName.Text = Translation.LanguageStrings.TemplateClassName;
            lblTemplateGroupName.Text = Translation.LanguageStrings.TemplateGroupName;

            dgvDataFields.Columns["colDat" + nameof(DataFieldResultDisplay.Name)].HeaderText = Translation.LanguageStrings.DataFieldName;
            dgvDataFields.Columns["colDat" + nameof(DataFieldResultDisplay.Value)].HeaderText = Translation.LanguageStrings.DataFieldValue;
            dgvDataFields.Columns["colDat" + nameof(DataFieldResultDisplay.FieldTypeDisplayValue)].HeaderText = Translation.LanguageStrings.DataFieldType;

            dgvCalculationFields.Columns["colCalc" + nameof(CalculationFieldResultDisplay.Name)].HeaderText = Translation.LanguageStrings.CalculationFieldName;
            dgvCalculationFields.Columns["colCalc" + nameof(CalculationFieldResultDisplay.CalculationValue)].HeaderText = Translation.LanguageStrings.CalculationValue;
            dgvCalculationFields.Columns["colCalc" + nameof(CalculationFieldResultDisplay.FieldTypeDisplayValue)].HeaderText = Translation.LanguageStrings.CalculationFieldType;
            dgvCalculationFields.Columns["colCalc" + nameof(CalculationFieldResultDisplay.CalculationEqualsValidation)].HeaderText = Translation.LanguageStrings.CalculationEqualsValidation;

            dgvConditionalFields.Columns["colCond" + nameof(ConditionalFieldResult.Name)].HeaderText = Translation.LanguageStrings.ConditionalFieldName;
            dgvConditionalFields.Columns["colCond" + nameof(ConditionalFieldResult.Value)].HeaderText = Translation.LanguageStrings.ConditionValue;
        }
    }
}
