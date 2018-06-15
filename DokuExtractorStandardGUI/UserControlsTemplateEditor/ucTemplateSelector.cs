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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<StringValue> TemplateNames { get; set; } = new BindingList<StringValue>();

        public delegate void SelectionChangedHandler(string templateName);
        /// <summary>
        /// Fired, when selected template has been changed
        /// </summary>
        public event SelectionChangedHandler SelectionChanged;

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

        public void RemoveSelectedTemplate()
        {
            var selectedRows = dataGridView1.SelectedRows;
            if (selectedRows != null)
                foreach (DataGridViewRow row in selectedRows)
                {
                    var templateName = row.DataBoundItem as StringValue;
                    if (templateName != null)
                        TemplateNames.Remove(templateName);
                    break;
                }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            if (selectedRows != null)
                foreach (DataGridViewRow row in selectedRows)
                {
                    var templateName = row.DataBoundItem as StringValue;
                    if (templateName != null)
                        FireSelectionChanged(templateName.Value);
                    break;
                }
        }

        private void FireSelectionChanged(string templateName)
        {
            SelectionChanged?.Invoke(templateName);
        }
    }
}
