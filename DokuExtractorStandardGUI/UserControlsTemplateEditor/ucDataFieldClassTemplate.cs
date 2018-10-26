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
        public delegate void RegexOrPositionHelperHandler(Guid id, DataFieldType dataFieldType, DataFieldMode dataFieldMode);
        /// <summary>
        /// Fired, when user wishes to start the regex expression helper or area position helper
        /// </summary>
        public event RegexOrPositionHelperHandler RegexOrPositionHelper;

        public delegate void DataFieldEraserHandler(Guid id);
        /// <summary>
        /// Fired, when butDeleteDataField has been clicked
        /// </summary>
        public event DataFieldEraserHandler DataFieldEraser;

        /// <summary>
        /// Gets the name of the data field from the text box
        /// </summary>
        public string NameText { get { return txtName.Text; } }
        /// <summary>
        /// Gets the field type of the data field from the combo box as integer
        /// </summary>
        public int FieldTypeInt { get { return cbxFieldType.SelectedIndex; } }
        /// <summary>
        /// Gets the field mode of the data field from the combo box as integer
        /// </summary>
        public int FieldModeInt { get { return cbxFieldMode.SelectedIndex; } }
        /// <summary>
        /// Gets the regex expressions of the data field from the text box
        /// </summary>
        public string RegexText { get { return txtRegexOrPosition.Text; } }
        /// <summary>
        /// Percental area info of the given data field class template
        /// </summary>
        public PercentalAreaInfo ValueArea { get; set; } = new PercentalAreaInfo();

        private DataFieldClassTemplate dataFieldClassTemplate { get; set; } = new DataFieldClassTemplate();
        private bool isRegexExpressionHelperActivated = false;

        /// <summary>
        /// Data field user control for class templates
        /// </summary>
        public ucDataFieldClassTemplate()
        {
            InitializeComponent();
            cbxFieldType.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
        }

        /// <summary>
        /// Data field user control for class templates with data
        /// </summary>
        public ucDataFieldClassTemplate(DataFieldClassTemplate dataFieldClassTemplate)
        {
            InitializeComponent();
            cbxFieldType.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
            this.dataFieldClassTemplate = dataFieldClassTemplate;
            ChangeValueArea(dataFieldClassTemplate.ValueArea);
        }

        private void ucDataField_Load(object sender, EventArgs e)
        {
            cbxFieldMode.SelectedIndex = (int)(this.dataFieldClassTemplate.FieldMode);
            Localize();

            txtName.Text = this.dataFieldClassTemplate.Name;

            cbxFieldType.SelectedIndex = (int)(this.dataFieldClassTemplate.FieldType);

            if (dataFieldClassTemplate.RegexExpressions != null)
                foreach (var item in dataFieldClassTemplate.RegexExpressions)
                {
                    txtRegexOrPosition.Text = txtRegexOrPosition.Text + item + Environment.NewLine;
                }
        }

        /// <summary>
        /// Activates the regex expression helper for defining regex expressions
        /// </summary>
        public void ActivateRegexExpressionHelper()
        {
            txtRegexOrPosition.Enabled = false;
            lblRegexOrPosition.Font = new Font(lblRegexOrPosition.Font.Name, lblRegexOrPosition.Font.SizeInPoints, FontStyle.Underline);
            if (isRegexExpressionHelperActivated == false)
            {
                lblRegexOrPosition.DoubleClick += LblRegexOrPosition_DoubleClick;
                isRegexExpressionHelperActivated = true;
            }
        }

        /// <summary>
        /// Chagnes a regex expression or adds an addtional regex string to the regex expression list
        /// </summary>
        /// <param name="regex">Regex expression</param>
        /// <param name="additionalRegex">Shall the regex expression be added to the regex expression list or shall it overwrite the list completely?</param>
        public void ChangeOrAddRegexExpression(string regex, bool additionalRegex)
        {
            if (additionalRegex)
                txtRegexOrPosition.Text = txtRegexOrPosition.Text + regex + Environment.NewLine;
            else
                txtRegexOrPosition.Text = regex;
        }

        /// <summary>
        /// Changes or defines a new value area
        /// </summary>
        /// <param name="areaInfo">percental area info</param>
        public void ChangeValueArea(PercentalAreaInfo areaInfo)
        {
            this.ValueArea = areaInfo;

            txtRegexOrPosition.Text = "page\t" + areaInfo.PageNumber + Environment.NewLine + "x\t" + Math.Round(areaInfo.TopLeftX * 100, 1) + " %"
                                      + Environment.NewLine + "y\t" + Math.Round(areaInfo.TopLeftY * 100, 1) + " %" + Environment.NewLine + "width\t" + Math.Round(areaInfo.Width * 100, 1) + " %"
                                      + Environment.NewLine + "height\t" + Math.Round(areaInfo.Height * 100, 1) + " %";
        }

        private void Localize()
        {
            lblName.Text = Translation.LanguageStrings.DataFieldName;
            lblFieldType.Text = Translation.LanguageStrings.DataFieldType;
            lblFieldMode.Text = Translation.LanguageStrings.DataFieldMode;
            butDeleteDataField.Text = Translation.LanguageStrings.ButDeleteDataField;

            LocalizeConditionally();

            cbxFieldType.Items[(int)(DataFieldType.Text)] = Translation.LanguageStrings.FieldTypeText;
            cbxFieldType.Items[(int)(DataFieldType.Date)] = Translation.LanguageStrings.FieldTypeDate;
            cbxFieldType.Items[(int)(DataFieldType.Currency)] = Translation.LanguageStrings.FieldTypeCurrency;
            cbxFieldType.Items[(int)(DataFieldType.IBAN)] = Translation.LanguageStrings.FieldTypeIban;
            cbxFieldType.Items[(int)(DataFieldType.AnchorLessIBAN)] = Translation.LanguageStrings.FieldTypeAnchorlessIban;
            cbxFieldType.Items[(int)(DataFieldType.VatId)] = Translation.LanguageStrings.FieldTypeVatId;
            cbxFieldType.Items[(int)(DataFieldType.Term)] = Translation.LanguageStrings.FieldTypeTerm;
        }

        private void LocalizeConditionally()
        {
            if ((DataFieldMode)FieldModeInt == DataFieldMode.Regex)
            {
                lblRegexOrPosition.Text = Translation.LanguageStrings.DataFieldRegexExpressions;
                butStartRegexOrPositionHelper.Text = Translation.LanguageStrings.ButStartRegexExpressionHelper;
            }
            else if ((DataFieldMode)FieldModeInt == DataFieldMode.Position)
            {
                lblRegexOrPosition.Text = Translation.LanguageStrings.DataFieldAreaPosition;
                butStartRegexOrPositionHelper.Text = Translation.LanguageStrings.ButStartAreaPositionHelper;
            }
        }

        private void LblRegexOrPosition_DoubleClick(object sender, EventArgs e)
        {
            StartRegexOrPositionHelper();
        }

        private void StartRegexOrPositionHelper()
        {
            var result = DialogResult.No;
            if ((DataFieldMode)FieldModeInt == DataFieldMode.Regex)
                result = MessageBox.Show(Translation.LanguageStrings.MsgAskStartRegexExpressionHelper, string.Empty, MessageBoxButtons.YesNo);
            else if ((DataFieldMode)FieldModeInt == DataFieldMode.Position)
                result = MessageBox.Show(Translation.LanguageStrings.MsgAskStartAreaPositionHelper, string.Empty, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var id = (Guid)(this.Tag);
                    FireRegexOrPositionHelper(id, (DataFieldType)FieldTypeInt, (DataFieldMode)FieldModeInt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
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
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FireRegexOrPositionHelper(Guid id, DataFieldType dataFieldType, DataFieldMode dataFieldMode)
        {
            RegexOrPositionHelper?.Invoke(id, dataFieldType, dataFieldMode);
        }

        private void FireDataFieldEraser(Guid id)
        {
            DataFieldEraser?.Invoke(id);
        }

        private void butStartRegexOrPositionHelper_Click(object sender, EventArgs e)
        {
            StartRegexOrPositionHelper();
        }

        private void txtRegexOrPosition_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegexOrPosition.Text))
                txtRegexOrPosition.BackColor = Color.Yellow;
            else
                txtRegexOrPosition.BackColor = Color.White;
        }

        private void cbxFieldMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalizeConditionally();
            txtRegexOrPosition.Text = string.Empty;
        }
    }
}
