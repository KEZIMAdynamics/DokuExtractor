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
    public partial class ucConditionalFieldClassTemplate : UserControl
    {
        public delegate void ConditionalFieldEraserHandler(Guid id);
        /// <summary>
        /// Fired, when butDeleteConditionalField was clicked
        /// </summary>
        public event ConditionalFieldEraserHandler ConditionalFieldEraser;

        public string NameText { get { return txtName.Text; } }
        public BindingList<ConditionValue> ConditionsBindingList { get; set; } = new BindingList<ConditionValue>();

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

        public ucConditionalFieldClassTemplate()
        {
            InitializeComponent();
        }

        public ucConditionalFieldClassTemplate(ConditionalFieldTemplate dataFieldClassTemplate)
        {
            InitializeComponent();
            this.conditionalFieldTemplate = dataFieldClassTemplate;
        }

        private void ucConditionalFieldClassTemplate_Load(object sender, EventArgs e)
        {
            Localize();

            txtName.Text = this.conditionalFieldTemplate.Name;
            this.ConditionsList = this.conditionalFieldTemplate.ConditionValues;
            dgvConditions.DataSource = this.ConditionsBindingList;
        }

        private void Localize()
        {
            lblName.Text = Translation.LanguageStrings.ConditionalFieldName;
            lblConditionValues.Text = Translation.LanguageStrings.ConditionalFieldConditions;
            butAddCondition.Text = Translation.LanguageStrings.ButAddCondition;
            butDeleteCondition.Text = Translation.LanguageStrings.ButDeleteCondition;
            butDeleteConditionalField.Text = Translation.LanguageStrings.ButDeleteConditionalField;

            dgvConditions.Columns["col" + nameof(ConditionValue.Condition)].HeaderText = Translation.LanguageStrings.Condition;
            dgvConditions.Columns["col" + nameof(ConditionValue.Value)].HeaderText = Translation.LanguageStrings.ConditionValue;
        }

        private void butAddCondition_Click(object sender, EventArgs e)
        {
            this.ConditionsBindingList.AddNew();
        }

        private void butDeleteCondition_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvConditions.SelectedRows;
            if (selectedRows != null)
                foreach (DataGridViewRow row in selectedRows)
                {
                    var conditionValue = row.DataBoundItem as ConditionValue;
                    this.ConditionsBindingList.Remove(conditionValue);
                    break;
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
    }
}
