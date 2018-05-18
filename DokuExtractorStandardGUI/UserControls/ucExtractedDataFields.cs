using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokuExtractorStandardGUI.Model;
using DokuExtractorStandardGUI.Localization;
using DokuExtractorCore.Model;

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucExtractedDataFields : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<DataFieldResultDisplay> DataFieldResultsDisplayBinding { get; set; } = new BindingList<DataFieldResultDisplay>();

        public ucExtractedDataFields()
        {
            InitializeComponent();
        }

        private void ucExtractedDataFields_Load(object sender, EventArgs e)
        {
            Localize();
        }

        public void ShowExtractedDataFields(List<DataFieldResult> extractedDataFields)
        {
            DataFieldResultsDisplayBinding = new BindingList<DataFieldResultDisplay>();
            foreach (var dataField in extractedDataFields)
            {
                DataFieldResultsDisplayBinding.Add(new DataFieldResultDisplay()
                {
                    Name = dataField.Name,
                    Value = dataField.Value,
                    FieldType = dataField.FieldType,
                    FieldTypeDisplayValue = Translation.TranslateFieldTypeEnum(dataField.FieldType)
                });
            }

            dgvDataFields.DataSource = DataFieldResultsDisplayBinding;
        }

        /// <summary>
        /// Checks, if all data fields are filled with data
        /// </summary>
        public bool CheckIfAllDataFieldsAreFilled()
        {
            foreach (DataFieldResultDisplay dataField in dgvDataFields.DataSource as BindingList<DataFieldResultDisplay>)
            {
                if (string.IsNullOrWhiteSpace(dataField.Value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the shown (and maybe editted) data field extraction result
        /// </summary>
        public List<DataFieldResult> GetDataFieldExtractionResult()
        {
            var retVal = new List<DataFieldResult>();

            foreach (DataFieldResultDisplay dataField in dgvDataFields.DataSource as BindingList<DataFieldResultDisplay>)
            {
                retVal.Add(dataField);
            }

            return retVal;
        }

        private void Localize()
        {
            dgvDataFields.Columns["colDat" + nameof(DataFieldResultDisplay.Name)].HeaderText = Translation.LanguageStrings.DataFieldName;
            dgvDataFields.Columns["colDat" + nameof(DataFieldResultDisplay.Value)].HeaderText = Translation.LanguageStrings.DataFieldValue;
            dgvDataFields.Columns["colDat" + nameof(DataFieldResultDisplay.FieldTypeDisplayValue)].HeaderText = Translation.LanguageStrings.DataFieldType;
        }
    }
}
