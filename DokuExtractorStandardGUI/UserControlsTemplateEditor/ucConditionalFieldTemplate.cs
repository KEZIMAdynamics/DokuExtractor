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
    public partial class ucConditionalFieldTemplate : UserControl
    {
        public delegate void ConditionalFieldEraserHandler(Guid id);
        /// <summary>
        /// Fired, when butDeleteConditionalField has been clicked
        /// </summary>
        public event ConditionalFieldEraserHandler ConditionalFieldEraser;

        /// <summary>
        /// Gets the name of the conditional field from the text box
        /// </summary>
        public string NameText { get { return txtName.Text; } }
        /// <summary>
        /// Gets the field type of the conditional field from the combo box as integer
        /// </summary>
        public int ConditionalFieldTypeInt { get { return cbxConditionalFieldType.SelectedIndex; } }
        /// <summary>
        /// Gets the OnlyStoreInGroupTemplateBool
        /// </summary>
        public bool OnlyStoreInGroupTemplateBool { get { return chbOnlyInGroupTemplate.Checked; } }
        /// <summary>
        /// Gets the IgnoreCaseForSimpleDocumentTextRegexBool
        /// </summary>
        public bool IgnoreCaseForSimpleDocumentTextRegexBool { get { return chbIgnoreCaseForSimpleDocumentText.Checked; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<ConditionValue> ConditionsBindingList { get; set; } = new BindingList<ConditionValue>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Gets or sets the (binding) list of condition-value pairs
        /// </summary>
        public List<ConditionValue> ConditionsList
        {
            get
            {
                return (dgvConditions.DataSource as BindingList<ConditionValue>)?.ToList();
            }

            set
            {
                this.ConditionsBindingList = new BindingList<ConditionValue>(value);
            }
        }

        private ConditionalFieldTemplate conditionalFieldTemplate { get; set; } = new ConditionalFieldTemplate();

        /// <summary>
        /// Conditional field user control for class and group templates
        /// </summary>
        public ucConditionalFieldTemplate()
        {
            InitializeComponent();
            cbxConditionalFieldType.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
        }

        /// <summary>
        /// Conditional field user control for class and group templates with data
        /// </summary>
        public ucConditionalFieldTemplate(ConditionalFieldTemplate dataFieldClassTemplate)
        {
            InitializeComponent();
            cbxConditionalFieldType.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
            this.conditionalFieldTemplate = dataFieldClassTemplate;
        }

        protected virtual void OnDgvConditionsCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvConditions.Rows[e.RowIndex];
            var column = dgvConditions.Columns[e.ColumnIndex];
            var cell = row.Cells[e.ColumnIndex];

            if (cell != null && cell.Value != null)
            {
                var cellValueString = cell.Value.ToString();
                using (var frmString = new frmValueEditor(cellValueString))
                {
                    if (column.Name == "col" + nameof(ConditionValue.Condition))
                    {
                        frmString.ShowDialog();
                        if (frmString.RetValDisplay != null)
                            cell.Value = frmString.RetValDisplay;
                    }
                    else if (column.Name == "col" + nameof(ConditionValue.DisplayValue))
                    {
                        frmString.ShowDialog();
                        if (frmString.RetValDisplay != null)
                        {
                            cell.Value = frmString.RetValDisplay;
                            var valueCell = row.Cells["col" + nameof(ConditionValue.Value)];
                            if (valueCell != null)
                                valueCell.Value = frmString.RetValDisplay;
                        }
                    }
                }
            }
        }

        public void HideGroupTemplateSpecificComponents()
        {
            chbOnlyInGroupTemplate.Enabled = false;
            if (this.conditionalFieldTemplate.OnlyStoreInGroupTemplate == true)
            {
                this.BackColor = Color.LightGray;
                txtName.Enabled = false;
                cbxConditionalFieldType.Enabled = false;
                chbIgnoreCaseForSimpleDocumentText.Enabled = false;
                dgvConditions.Enabled = false;
                butAddCondition.Enabled = false;
                butDeleteCondition.Enabled = false;
                butDeleteConditionalField.Enabled = false;
            }
        }

        private void ucConditionalFieldClassTemplate_Load(object sender, EventArgs e)
        {
            Localize();

            txtName.Text = this.conditionalFieldTemplate.Name;

            cbxConditionalFieldType.SelectedIndex = (int)(this.conditionalFieldTemplate.ConditionalFieldType);

            chbOnlyInGroupTemplate.Checked = this.conditionalFieldTemplate.OnlyStoreInGroupTemplate;

            chbIgnoreCaseForSimpleDocumentText.Checked = this.conditionalFieldTemplate.IgnoreCaseForSimpleDocumentTextRegex;

            this.ConditionsList = this.conditionalFieldTemplate.ConditionValues;
            dgvConditions.DataSource = this.ConditionsBindingList;
        }

        private void Localize()
        {
            lblName.Text = Translation.LanguageStrings.ConditionalFieldName;
            lblConditionalFieldType.Text = Translation.LanguageStrings.ConditionalFieldType;
            butAddCondition.Text = Translation.LanguageStrings.ButAddCondition;
            butDeleteCondition.Text = Translation.LanguageStrings.ButDeleteCondition;
            butDeleteConditionalField.Text = Translation.LanguageStrings.ButDeleteConditionalField;

            cbxConditionalFieldType.Items[(int)(ConditionalFieldType.Text)] = Translation.LanguageStrings.ConditionalFieldTypeText;
            cbxConditionalFieldType.Items[(int)(ConditionalFieldType.Bool)] = Translation.LanguageStrings.ConditionalFieldTypeBool;
            cbxConditionalFieldType.Items[(int)(ConditionalFieldType.Number)] = Translation.LanguageStrings.ConditionalFieldTypeNumber;
            cbxConditionalFieldType.Items[(int)(ConditionalFieldType.Date)] = Translation.LanguageStrings.ConditionalFieldTypeDate;
            cbxConditionalFieldType.Items[(int)(ConditionalFieldType.UserId)] = Translation.LanguageStrings.ConditionalFieldTypeUserId;
            cbxConditionalFieldType.Items[(int)(ConditionalFieldType.UserGroupId)] = Translation.LanguageStrings.ConditionalFieldTypeUserGroupId;
            cbxConditionalFieldType.Items[(int)(ConditionalFieldType.UserOrUserGroupId)] = Translation.LanguageStrings.ConditionalFieldTypeUserOrUserGroupId;

            dgvConditions.Columns["col" + nameof(ConditionValue.Condition)].HeaderText = Translation.LanguageStrings.Condition;
            dgvConditions.Columns["col" + nameof(ConditionValue.DisplayValue)].HeaderText = Translation.LanguageStrings.ConditionValue;

            chbOnlyInGroupTemplate.Text = Translation.LanguageStrings.CheckOnlyStoreInGroupTemplate;
            chbIgnoreCaseForSimpleDocumentText.Text = Translation.LanguageStrings.CheckIgnoreCaseForSimpleDocumentTextRegex;
        }

        private void butAddCondition_Click(object sender, EventArgs e)
        {
            this.ConditionsBindingList.AddNew();
        }

        private void butDeleteCondition_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvConditions.SelectedRows;
            if (selectedRows != null && selectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    var conditionValue = row.DataBoundItem as ConditionValue;
                    this.ConditionsBindingList.Remove(conditionValue);
                    break;
                }
            }
            else if (selectedRows != null && selectedRows.Count == 0)
            {
                var selectedCells = dgvConditions.SelectedCells;
                if (selectedCells != null && selectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in selectedCells)
                    {
                        var row = dgvConditions.Rows[cell.RowIndex];
                        var conditionValue = row.DataBoundItem as ConditionValue;
                        this.ConditionsBindingList.Remove(conditionValue);
                        break;
                    }
                }
            }
        }

        private void butDeleteConditionalField_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (Guid)(this.Tag);
                FireConditionalFieldEraser(id);
            }
            catch (Exception ex)
            { }
        }

        private void FireConditionalFieldEraser(Guid id)
        {
            ConditionalFieldEraser?.Invoke(id);
        }

        private void dgvConditions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDgvConditionsCellDoubleClick(sender, e);
        }
    }
}
