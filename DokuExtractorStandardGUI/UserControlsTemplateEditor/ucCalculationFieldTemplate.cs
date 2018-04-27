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
    public partial class ucCalculationFieldTemplate : UserControl
    {
        public delegate void CalculationFieldEraserHandler(Guid id);
        /// <summary>
        /// Fired, when butDeleteCalculationField was clicked
        /// </summary>
        public event CalculationFieldEraserHandler CalculationFieldEraser;

        public string NameText { get { return txtName.Text; } }
        public int FieldTypeInt { get { return lbxFieldType.SelectedIndex; } }
        public string TextCalculationExpression { get { return txtCalculationExpression.Text; } }
        public int CalculationPrecision { get { var retVal = -1; int.TryParse(cbxCalculationPrecision.SelectedText, out retVal); return retVal; } }
        public string TextValidationExpression { get { return txtValidationExpressions.Text; } }
        public int ValidationPrecision { get { var retVal = -1; int.TryParse(cbxValidationPrecision.SelectedText, out retVal); return retVal; } }

        private CalculationFieldTemplate calculationFieldTemplate { get; set; } = new CalculationFieldTemplate();

        public ucCalculationFieldTemplate()
        {
            InitializeComponent();
        }

        public ucCalculationFieldTemplate(CalculationFieldTemplate calculationFieldTemplate)
        {
            InitializeComponent();
            this.calculationFieldTemplate = calculationFieldTemplate;
        }

        private void ucCalculationFieldTemplate_Load(object sender, EventArgs e)
        {
            txtName.Text = this.calculationFieldTemplate.Name;

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
