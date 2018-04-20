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
using DokuExtractorCore;

namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    public partial class ucTemplateSelector : UserControl
    {
        public BindingList<StringValue> TemplateNames { get; set; } = new BindingList<StringValue>();

        public delegate void SelectionChangedHandler(string templateName);
        public event SelectionChangedHandler SelectionChanged;

        private TemplateProcessor templateProcessor = new TemplateProcessor(Application.StartupPath);

        public ucTemplateSelector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads a string value list of template names to the TemplateSelector
        /// </summary>
        /// <param name="templateNames">List of template names</param>
        public void LoadTemplates(List<StringValue> templateNames)
        {
            TemplateNames = new BindingList<StringValue>(templateNames);
            dataGridView1.DataSource = TemplateNames;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            if(selectedRows != null)
                foreach (DataGridViewRow row in selectedRows)
                {
                    var templateName = row.DataBoundItem as StringValue;
                    if (templateName != null)
                        FireSelectionChanged(templateName.Value);
                    break;
                }

            //foreach (DataGridViewRow row in selectedRows)
            //{
            //    var className = row.Cells["Value"]?.Value?.ToString();
            //    SelectionChanged?.Invoke(className);
            //    break;
            //}
        }

        private void FireSelectionChanged(string templateName)
        {
            SelectionChanged?.Invoke(templateName);
        }
    }
}
