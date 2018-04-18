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

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucExtractedData : UserControl
    {
        public ucExtractedData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the content of the extraction result
        /// </summary>
        /// <param name="extractionResult">Extraction result of type FieldExtractionResult</param>
        public void ShowExtractedData(FieldExtractionResult extractionResult)
        {
            txtClassName.Text = extractionResult.TemplateClassName;
            txtGroupName.Text = extractionResult.TemplateGroupName;

            dgvDataFields.DataSource = extractionResult.DataFields;
            dgvCalculationFields.DataSource = extractionResult.CalculationFields;
        }

        /// <summary>
        /// Returns the shown (and maybe editted) extraction result
        /// </summary>
        public FieldExtractionResult GetFieldExtractionResult()
        {
            var retVal = new FieldExtractionResult();

            retVal.TemplateClassName = txtClassName.Text;
            retVal.TemplateGroupName = txtGroupName.Text;

            foreach (DataFieldResult dataField in dgvDataFields.DataSource as List<DataFieldResult>)
            {
                retVal.DataFields.Add(dataField);
            }

            foreach (CalculationFieldResult calcField in dgvCalculationFields.DataSource as List<CalculationFieldResult>)
            {
                retVal.CalculationFields.Add(calcField);
            }

            return retVal;
        }
    }
}
