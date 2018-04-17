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
            txtClassName.Text = extractionResult.TemplateClass;
            txtGroupName.Text = extractionResult.TemplateName;

            dgvDataFields.DataSource = extractionResult.DataFields;
            dgvCalculationFields.DataSource = extractionResult.CalculationFields;
        }
    }
}
