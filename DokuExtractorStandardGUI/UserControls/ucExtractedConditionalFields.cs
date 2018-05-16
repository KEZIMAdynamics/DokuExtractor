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

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucExtractedConditionalFields : UserControl
    {
        public delegate void ConditionalFieldCellDoubleClickHandler(object sender, DataGridViewCellEventArgs e);
        /// <summary>
        /// Fired, when a cell in dgvConditionalFields has been double clicked
        /// </summary>
        public event ConditionalFieldCellDoubleClickHandler ConditionalFieldCellDoubleClick;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<ConditionalFieldResult> ConditionalFieldResultBinding { get; set; } = new BindingList<ConditionalFieldResult>();

        public ucExtractedConditionalFields()
        {
            InitializeComponent();
        }

        private void ucExtractedConditionalFields_Load(object sender, EventArgs e)
        {
            Localize();
        }

        public void ShowExtractedConditionalFields(List<ConditionalFieldResult> extractedConditionalFields)
        {
            ConditionalFieldResultBinding = new BindingList<ConditionalFieldResult>(extractedConditionalFields);
            dgvConditionalFields.DataSource = ConditionalFieldResultBinding;
        }

        /// <summary>
        /// Checks, if all data fields are filled with data
        /// </summary>
        public bool CheckIfAllConditionalFieldsAreFilled()
        {
            foreach (ConditionalFieldResult condField in dgvConditionalFields.DataSource as BindingList<ConditionalFieldResult>)
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

            foreach (ConditionalFieldResult condField in dgvConditionalFields.DataSource as BindingList<ConditionalFieldResult>)
            {
                retVal.Add(condField);
            }

            return retVal;
        }

        private void Localize()
        {
            dgvConditionalFields.Columns["colCond" + nameof(ConditionalFieldResult.Name)].HeaderText = Translation.LanguageStrings.ConditionalFieldName;
            dgvConditionalFields.Columns["colCond" + nameof(ConditionalFieldResult.Value)].HeaderText = Translation.LanguageStrings.ConditionValue;
        }

        private void dgvConditionalFields_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FireConditionalFieldCellDoubleClick(sender, e);
        }

        private void FireConditionalFieldCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConditionalFieldCellDoubleClick?.Invoke(sender, e);
        }
    }
}
