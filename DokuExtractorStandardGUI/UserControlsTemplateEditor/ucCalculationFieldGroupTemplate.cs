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
        /// Fired, when butDeleteCalculationField has been clicked
        /// </summary>
        public event CalculationFieldEraserHandler CalculationFieldEraser;

        /// <summary>
        /// Gets the name of the calculation field from the text box
        /// </summary>
        public string NameText { get { return txtName.Text; } }
        /// <summary>
        /// Gets the field type of the calculation field from the combo box as integer
        /// </summary>
        public int FieldTypeInt { get { return cbxFieldType.SelectedIndex; } }
        /// <summary>
        /// Gets the calculation expression of the calculation field from the text box
        /// </summary>
        public string CalculationExpressionText { get { return txtCalculationExpression.Text; } }
        /// <summary>
        /// Gets the calculation precision of the calculation field from the combo box as integer
        /// </summary>
        public int CalculationPrecisionInt { get { var retVal = -1; int.TryParse(cbxCalculationPrecision.Text, out retVal); return retVal; } }
        /// <summary>
        /// Gets the validation expression of the calculation field from the text box
        /// </summary>
        public string ValidationExpressionText { get { return txtValidationExpressions.Text; } }
        /// <summary>
        /// Gets the validation precision of the calculation field from the combo box as integer
        /// </summary>
        public int ValidationPrecisionInt { get { var retVal = -1; int.TryParse(cbxValidationPrecision.Text, out retVal); return retVal; } }

        private CalculationFieldTemplate calculationFieldTemplate { get; set; } = new CalculationFieldTemplate();

        /// <summary>
        /// Calculation field user control for group templates
        /// </summary>
        public ucCalculationFieldGroupTemplate()
        {
            InitializeComponent();
            cbxCalculationPrecision.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
            cbxFieldType.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
            cbxValidationPrecision.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
        }

        /// <summary>
        /// Calculation field user control for group templates with data
        /// </summary>
        public ucCalculationFieldGroupTemplate(CalculationFieldTemplate calculationFieldTemplate)
        {
            InitializeComponent();
            cbxCalculationPrecision.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
            cbxFieldType.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
            cbxValidationPrecision.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
            this.calculationFieldTemplate = calculationFieldTemplate;
        }

        private void ucCalculationFieldTemplate_Load(object sender, EventArgs e)
        {
            txtName.Text = this.calculationFieldTemplate.Name;

            Localize();

            cbxFieldType.SelectedIndex = (int)(this.calculationFieldTemplate.FieldType);

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
            cbxFieldType.Items[(int)(DataFieldType.Text)] = Translation.LanguageStrings.FieldTypeText;
            cbxFieldType.Items[(int)(DataFieldType.Date)] = Translation.LanguageStrings.FieldTypeDate;
            cbxFieldType.Items[(int)(DataFieldType.Currency)] = Translation.LanguageStrings.FieldTypeCurrency;
            cbxFieldType.Items[(int)(DataFieldType.IBAN)] = Translation.LanguageStrings.FieldTypeIban;
            cbxFieldType.Items[(int)(DataFieldType.AnchorLessIBAN)] = Translation.LanguageStrings.FieldTypeAnchorlessIban;
            cbxFieldType.Items[(int)(DataFieldType.VatId)] = Translation.LanguageStrings.FieldTypeVatId;
            cbxFieldType.Items[(int)(DataFieldType.Term)] = Translation.LanguageStrings.FieldTypeTerm;
        }

        private void butDeleteCalculationField_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (Guid)(this.Tag);
                FireCalculationFieldEraser(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FireCalculationFieldEraser(Guid id)
        {
            CalculationFieldEraser?.Invoke(id);
        }
    }
}
