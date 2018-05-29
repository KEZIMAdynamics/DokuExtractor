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
    public partial class ucExtractedConditionalFields : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<ConditionalFieldResultDisplay> ConditionalFieldResultDisplayBinding { get; set; } = new BindingList<ConditionalFieldResultDisplay>();

        public ucExtractedConditionalFields()
        {
            InitializeComponent();
        }

        private void ucExtractedConditionalFields_Load(object sender, EventArgs e)
        {
            Localize();
        }

        /// <summary>
        /// Shows the content of the extracted conditional fields
        /// </summary>
        /// <param name="extractedConditionalFields">List of conditional field results</param>
        public void ShowExtractedConditionalFields(List<ConditionalFieldResult> extractedConditionalFields)
        {
            ConditionalFieldResultDisplayBinding = new BindingList<ConditionalFieldResultDisplay>();
            foreach (var condField in extractedConditionalFields)
            {
                ConditionalFieldResultDisplayBinding.Add(new ConditionalFieldResultDisplay()
                {
                    Name = condField.Name,
                    Value = condField.Value,
                    ConditionalFieldType = condField.ConditionalFieldType,
                    ConditionalFieldTypeDisplayValue = Translation.TranslateConditionalFieldTypeEnum(condField.ConditionalFieldType)
                });
            }
            dgvConditionalFields.DataSource = ConditionalFieldResultDisplayBinding;
        }

        /// <summary>
        /// Checks, if all data fields are filled with data
        /// </summary>
        public bool CheckIfAllConditionalFieldsAreFilled()
        {
            foreach (ConditionalFieldResultDisplay condField in dgvConditionalFields.DataSource as BindingList<ConditionalFieldResultDisplay>)
            {
                if (string.IsNullOrWhiteSpace(condField.Value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the shown (and maybe editted) conditional field extraction result
        /// </summary>
        public List<ConditionalFieldResult> GetConditionalFieldExtractionResult()
        {
            var retVal = new List<ConditionalFieldResult>();

            foreach (ConditionalFieldResultDisplay condField in dgvConditionalFields.DataSource as BindingList<ConditionalFieldResultDisplay>)
            {
                retVal.Add(condField);
            }

            return retVal;
        }

        /// <summary>
        /// Overridable function, which is called by a double click within a conditional field cell of dgvConditionalFields
        /// </summary>
        /// <param name="sender">DataGridView</param>
        /// <param name="e">DataGridViewCellEventArgs</param>
        protected virtual void OnDgvConditionalFieldCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Localize()
        {
            dgvConditionalFields.Columns["col" + nameof(ConditionalFieldResultDisplay.Name)].HeaderText = Translation.LanguageStrings.ConditionalFieldName;
            dgvConditionalFields.Columns["col" + nameof(ConditionalFieldResultDisplay.Value)].HeaderText = Translation.LanguageStrings.ConditionValue;
            dgvConditionalFields.Columns["col" + nameof(ConditionalFieldResultDisplay.ConditionalFieldTypeDisplayValue)].HeaderText = Translation.LanguageStrings.ConditionalFieldType;
        }

        private void dgvConditionalFields_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDgvConditionalFieldCellDoubleClick(sender, e);
        }
    }
}
