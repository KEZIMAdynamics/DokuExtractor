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
    public partial class ucDataFieldClassTemplate : UserControl
    {
        public delegate void RegexExpressionHelperHandler(Guid id, DataFieldType dataFieldType);
        /// <summary>
        /// Fired, when user wishes to start the regex expression helper
        /// </summary>
        public event RegexExpressionHelperHandler RegexExpressionHelper;

        public delegate void DataFieldEraserHandler(Guid id);
        /// <summary>
        /// Fired, when butDeleteDataField was clicked
        /// </summary>
        public event DataFieldEraserHandler DataFieldEraser;

        public string NameText { get { return txtName.Text; } }
        public int FieldTypeInt { get { return lbxFieldType.SelectedIndex; } }
        public string RegexText { get { return txtRegexExpression.Text; } }

        private DataFieldClassTemplate dataFieldClassTemplate { get; set; } = new DataFieldClassTemplate();
        private bool isRegexExpressionHelperActivated = false;

        public ucDataFieldClassTemplate()
        {
            InitializeComponent();
        }

        public ucDataFieldClassTemplate(DataFieldClassTemplate dataFieldClassTemplate)
        {
            InitializeComponent();
            this.dataFieldClassTemplate = dataFieldClassTemplate;
        }

        private void ucDataField_Load(object sender, EventArgs e)
        {
            Localize();

            txtName.Text = this.dataFieldClassTemplate.Name;

            lbxFieldType.SelectedIndex = (int)(this.dataFieldClassTemplate.FieldType);

            if (dataFieldClassTemplate.RegexExpressions != null)
                foreach (var item in dataFieldClassTemplate.RegexExpressions)
                {
                    txtRegexExpression.Text = txtRegexExpression.Text + item + Environment.NewLine;
                }
        }

        /// <summary>
        /// Activates the regex expression helper for defining regex expressions
        /// </summary>
        public void ActivateRegexExpressionHelper()
        {
            txtRegexExpression.Enabled = false;
            lblRegexExpression.Font = new Font(lblRegexExpression.Font.Name, lblRegexExpression.Font.SizeInPoints, FontStyle.Underline);
            if (isRegexExpressionHelperActivated == false)
            {
                lblRegexExpression.DoubleClick += LblRegexExpression_DoubleClick;
                isRegexExpressionHelperActivated = true;
            }
        }

        public void ChangeOrAddRegexExpression(string regex, bool additionalRegex)
        {
            if (additionalRegex)
                txtRegexExpression.Text = txtRegexExpression.Text + regex + Environment.NewLine;
            else
                txtRegexExpression.Text = regex;
        }

        private void Localize()
        {
            lblName.Text = Translation.LanguageStrings.DataFieldName;
            lblFieldType.Text = Translation.LanguageStrings.DataFieldType;
            lblRegexExpression.Text = Translation.LanguageStrings.DataFieldRegexExpressions;
            butDeleteDataField.Text = Translation.LanguageStrings.ButDeleteDataField;
            lbxFieldType.Items[(int)(DataFieldType.Text)] = Translation.LanguageStrings.FieldTypeText;
            lbxFieldType.Items[(int)(DataFieldType.Date)] = Translation.LanguageStrings.FieldTypeDate;
            lbxFieldType.Items[(int)(DataFieldType.Currency)] = Translation.LanguageStrings.FieldTypeCurrency;
            lbxFieldType.Items[(int)(DataFieldType.IBAN)] = Translation.LanguageStrings.FieldTypeIban;
            lbxFieldType.Items[(int)(DataFieldType.AnchorLessIBAN)] = Translation.LanguageStrings.FieldTypeAnchorlessIban;
            lbxFieldType.Items[(int)(DataFieldType.VatId)] = Translation.LanguageStrings.FieldTypeVatId;
            lbxFieldType.Items[(int)(DataFieldType.Term)] = Translation.LanguageStrings.FieldTypeTerm;
        }

        private void LblRegexExpression_DoubleClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show(Translation.LanguageStrings.MsgAskStartRegexExpressionHelper, string.Empty, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var id = (Guid)(this.Tag);
                    FireRegexExpressionHelper(id, (DataFieldType)FieldTypeInt);
                }
                catch (Exception ex)
                { }
            }
        }

        private void butDeleteDataField_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (Guid)(this.Tag);
                FireDataFieldEraser(id);
            }
            catch (Exception ex)
            { }
        }

        private void FireRegexExpressionHelper(Guid id, DataFieldType dataFieldType)
        {
            RegexExpressionHelper?.Invoke(id, dataFieldType);
        }

        private void FireDataFieldEraser(Guid id)
        {
            DataFieldEraser?.Invoke(id);
        }
    }
}
