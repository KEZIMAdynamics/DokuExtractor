using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokuExtractorStandardGUI.Model;
using DokuExtractorCore.Model;
using DokuExtractorStandardGUI.Localization;
using DokuExtractorCore;

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucExtractedCalculationFields : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<CalculationFieldResultDisplay> CalculationFieldResultsDisplayBinding { get; set; } = new BindingList<CalculationFieldResultDisplay>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private List<CalculationFieldTemplate> calculationFieldsTemplate = new List<CalculationFieldTemplate>();

        public ucExtractedCalculationFields()
        {
            InitializeComponent();
        }

        private void ucExtractedCalculationFields_Load(object sender, EventArgs e)
        {
            Localize();
        }

        /// <summary>
        /// Shows the content of the extracted calculation fields
        /// </summary>
        /// <param name="extractedCalculationFields">List of calculation field results</param>
        public void ShowExtractedCalculationFields(List<CalculationFieldResult> extractedCalculationFields)
        {
            CalculationFieldResultsDisplayBinding = new BindingList<CalculationFieldResultDisplay>();
            foreach (var calcField in extractedCalculationFields)
            {
                CalculationFieldResultsDisplayBinding.Add(new CalculationFieldResultDisplay()
                {
                    Name = calcField.Name,
                    CalculationValue = calcField.CalculationValue,
                    ValidationValues = calcField.ValidationValues,
                    CalculationEqualsValidation = calcField.CalculationEqualsValidation,
                    FieldType = calcField.FieldType,
                    FieldTypeDisplayValue = Translation.TranslateDataFieldTypeEnum(calcField.FieldType)
                });
            }
            dgvCalculationFields.DataSource = CalculationFieldResultsDisplayBinding;

            foreach (DataGridViewRow row in dgvCalculationFields.Rows)
            {
                try
                {
                    DataGridViewCell calcOkCell = row.Cells["col" + nameof(CalculationFieldResultDisplay.CalculationEqualsValidation)];
                    if (calcOkCell != null)
                    {
                        if ((bool)(calcOkCell.Value) == false)
                            row.DefaultCellStyle.BackColor = Color.OrangeRed;
                        else if((bool)(calcOkCell.Value) == true)
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
                catch (Exception ex)
                { }
            }
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
        /// Returns the shown (and maybe editted) calculation field extraction result
        /// </summary>
        public List<CalculationFieldResult> GetCalculationFieldExtractionResult()
        {
            var retVal = new List<CalculationFieldResult>();

            foreach (CalculationFieldResultDisplay calcField in dgvCalculationFields.DataSource as BindingList<CalculationFieldResultDisplay>)
            {
                retVal.Add(calcField);
            }

            return retVal;
        }

        public void ReCalculate(List<CalculationFieldTemplate> calculationFieldsTemplate, List<DataFieldResult> dataFieldResultList)
        {
            var fieldCalculator = new FieldCalculator();
            var calculationFieldResults = new List<CalculationFieldResult>();

            foreach (var item in calculationFieldsTemplate)
            {
                calculationFieldResults.Add(fieldCalculator.CompareExpressionResults(item, dataFieldResultList));
            }

            ShowExtractedCalculationFields(calculationFieldResults);
        }

        /// <summary>
        /// Overridable function, which is called by a double click within a calculation field cell of dgvCalculationFields
        /// </summary>
        /// <param name="sender">DataGridView</param>
        /// <param name="e">DataGridViewCellEventArgs</param>
        protected virtual void OnDgvCalculationFieldsCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Localize()
        {
            dgvCalculationFields.Columns["col" + nameof(CalculationFieldResultDisplay.Name)].HeaderText = Translation.LanguageStrings.CalculationFieldName;
            dgvCalculationFields.Columns["col" + nameof(CalculationFieldResultDisplay.CalculationValue)].HeaderText = Translation.LanguageStrings.CalculationValue;
            dgvCalculationFields.Columns["col" + nameof(CalculationFieldResultDisplay.FieldTypeDisplayValue)].HeaderText = Translation.LanguageStrings.CalculationFieldType;
            dgvCalculationFields.Columns["col" + nameof(CalculationFieldResultDisplay.CalculationEqualsValidation)].HeaderText = Translation.LanguageStrings.CalculationEqualsValidation;
        }

        private void dgvCalculationFields_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDgvCalculationFieldsCellContentDoubleClick(sender, e);
        }
    }
}
