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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private List<ConditionalFieldTemplate> conditionalFieldsTemplate = new List<ConditionalFieldTemplate>();

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
        public void ShowExtractedConditionalFields(List<ConditionalFieldResult> extractedConditionalFields, List<ConditionalFieldTemplate> conditionalFieldsTemplate)
        {
            this.conditionalFieldsTemplate = conditionalFieldsTemplate;

            ConditionalFieldResultDisplayBinding = new BindingList<ConditionalFieldResultDisplay>();
            foreach (var condField in extractedConditionalFields)
            {
                ConditionalFieldResultDisplayBinding.Add(new ConditionalFieldResultDisplay()
                {
                    Name = condField.Name,
                    Value = condField.Value,
                    DisplayValue = condField.DisplayValue,
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
            var row = dgvConditionalFields.Rows[e.RowIndex];
            var column = dgvConditionalFields.Columns[e.ColumnIndex];
            var cell = row.Cells[e.ColumnIndex];

            if (cell != null && cell.Value != null)
            {
                var cellValueString = cell.Value.ToString();
                var nameCell = row.Cells["col" + nameof(ConditionalFieldResultDisplay.Name)];

                var condFieldTemplate = this.conditionalFieldsTemplate.Where(x => x.Name == nameCell.Value.ToString()).FirstOrDefault();
                if (condFieldTemplate != null)
                {
                    var conditionOptions = new List<string>();
                    var conditionOptionsDisplay = new List<string>();
                    foreach (var conditionValue in condFieldTemplate.ConditionValues)
                    {
                        conditionOptions.Add(conditionValue.Value);
                        conditionOptionsDisplay.Add(conditionValue.DisplayValue);
                    }

                    using (var frmCbx = new frmValueEditor(cellValueString, conditionOptions, conditionOptionsDisplay))
                    {
                        if (column.Name == "col" + nameof(ConditionalFieldResultDisplay.DisplayValue))
                        {
                            var dexForm = FindForm();
                            if (dexForm != null)
                            {
                                frmCbx.Icon = dexForm.Icon;
                                frmCbx.Font = dexForm.Font;
                            }

                            frmCbx.IndividualConditionalValueButtonClicked += FrmCbx_IndividualConditionalValueButtonClicked;

                            frmCbx.ShowDialog();
                            if (string.IsNullOrWhiteSpace(frmCbx.RetVal) == false)
                            {
                                cell.Value = frmCbx.RetValDisplay;
                                var valueCell = row.Cells["col" + nameof(ConditionalFieldResultDisplay.Value)];
                                if (valueCell != null)
                                    valueCell.Value = frmCbx.RetVal;
                            }
                        }
                    }
                }
            }
        }

        protected virtual void OnFrmComboBoxIndividualConditionalValueButtonClick(object sender, EventArgs e)
        {
            var frmValEdit = sender as frmValueEditor;
            if (frmValEdit != null)
            {
                using (var individualFrmValEdit = new frmValueEditor("..."))
                {
                    var dexForm = FindForm();
                    if (dexForm != null)
                    {
                        individualFrmValEdit.Icon = dexForm.Icon;
                        individualFrmValEdit.Font = dexForm.Font;
                    }
                    individualFrmValEdit.ShowDialog();
                    if (string.IsNullOrWhiteSpace(individualFrmValEdit.RetValDisplay) == false)
                    {
                        frmValEdit.RetVal = individualFrmValEdit.RetValDisplay;
                        frmValEdit.RetValDisplay = individualFrmValEdit.RetValDisplay;
                        frmValEdit.Close();
                    }
                }
            }
        }

        private void Localize()
        {
            dgvConditionalFields.Columns["col" + nameof(ConditionalFieldResultDisplay.Name)].HeaderText = Translation.LanguageStrings.ConditionalFieldName;
            dgvConditionalFields.Columns["col" + nameof(ConditionalFieldResultDisplay.DisplayValue)].HeaderText = Translation.LanguageStrings.ConditionValue;
            dgvConditionalFields.Columns["col" + nameof(ConditionalFieldResultDisplay.ConditionalFieldTypeDisplayValue)].HeaderText = Translation.LanguageStrings.ConditionalFieldType;
        }

        private void dgvConditionalFields_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDgvConditionalFieldCellDoubleClick(sender, e);
        }

        private void FrmCbx_IndividualConditionalValueButtonClicked(object sender, EventArgs e)
        {
            OnFrmComboBoxIndividualConditionalValueButtonClick(sender, e);
        }
    }
}
