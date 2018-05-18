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

namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    public partial class ucCalculationFieldGroupTemplate : UserControl
    {
        public delegate void CalculationFieldEraserHandler(Guid id);
        /// <summary>
        /// Fired, when butDeleteCalculationField was clicked
        /// </summary>
        public event CalculationFieldEraserHandler CalculationFieldEraser;

        public string NameText { get { return txtName.Text; } }
        public int FieldTypeInt { get { return lbxFieldType.SelectedIndex; } }
        public string CalculationExpressionText { get { return txtCalculationExpression.Text; } }
        public int CalculationPrecisionInt { get { var retVal = -1; int.TryParse(cbxCalculationPrecision.SelectedText, out retVal); return retVal; } }
        public string ValidationExpressionText { get { return txtValidationExpressions.Text; } }
        public int ValidationPrecisionInt { get { var retVal = -1; int.TryParse(cbxValidationPrecision.SelectedText, out retVal); return retVal; } }

        private CalculationFieldTemplate calculationFieldTemplate { get; set; } = new CalculationFieldTemplate();

        public ucCalculationFieldGroupTemplate()
        {
            InitializeComponent();
        }

        public ucCalculationFieldGroupTemplate(CalculationFieldTemplate calculationFieldTemplate)
        {
            InitializeComponent();
            this.calculationFieldTemplate = calculationFieldTemplate;
        }

        private void ucCalculationFieldTemplate_Load(object sender, EventArgs e)
        {
            txtName.Text = this.calculationFieldTemplate.Name;

            Localize();

            lbxFieldType.SelectedIndex = (int)(this.calculationFieldTemplate.FieldType);

            txtCalculationExpression.Text = this.calculationFieldTemplate.CalculationExpression;
            cbxCalculationPrecision.SelectedText = this.calculationFieldTemplate.CalculationExpressionPrecision.ToString();

            if (calculationFieldTemplate.ValidationExpressions != null)
                foreach (var item in calculationFieldTemplate.ValidationExpressions)
                {
                    txtValidationExpressions.Text = txtValidationExpressions.Text + item + Environment.NewLine;
                }
            cbxValidationPrecision.SelectedText = this.calculationFieldTemplate.CalculationExpressionPrecision.ToString();
        }

        private void Localize()
        {
            lblName.Text = Translation.LanguageStrings.CalculationFieldName;
            lblFieldType.Text = Translation.LanguageStrings.CalculationFieldType;
            lblCalculationExpression.Text = Translation.LanguageStrings.CalculationExpression;
            lblValidationExpressions.Text = Translation.LanguageStrings.ValidationExpressions;
            butDeleteCalculationField.Text = Translation.LanguageStrings.ButDeleteCalculationField;
            lbxFieldType.Items[(int)(DataFieldType.Text)] = Translation.LanguageStrings.FieldTypeText;
            lbxFieldType.Items[(int)(DataFieldType.Date)] = Translation.LanguageStrings.FieldTypeDate;
            lbxFieldType.Items[(int)(DataFieldType.Currency)] = Translation.LanguageStrings.FieldTypeCurrency;
            lbxFieldType.Items[(int)(DataFieldType.IBAN)] = Translation.LanguageStrings.FieldTypeIban;
            lbxFieldType.Items[(int)(DataFieldType.AnchorLessIBAN)] = Translation.LanguageStrings.FieldTypeAnchorlessIban;
            lbxFieldType.Items[(int)(DataFieldType.VatId)] = Translation.LanguageStrings.FieldTypeVatId;
            lbxFieldType.Items[(int)(DataFieldType.Term)] = Translation.LanguageStrings.FieldTypeTerm;
        }

        private void butDeleteCalculationField_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (Guid)(this.Tag);
                FireCalculationFieldEraser(id);
            }
            catch (Exception ex)
            { }
        }

        private void FireCalculationFieldEraser(Guid id)
        {
            CalculationFieldEraser?.Invoke(id);
        }
    }
}
