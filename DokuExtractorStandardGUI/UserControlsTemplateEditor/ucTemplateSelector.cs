﻿using System;
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
        public delegate void SelectionChangedHandler(string templateName);
        public event SelectionChangedHandler SelectionChanged;

        private TemplateProcessor templateProcessor = new TemplateProcessor(Application.StartupPath);

        public ucTemplateSelector()
        {
            InitializeComponent();
        }

        public void LoadTemplates(List<StringValue> templateNames)
        {
            dataGridView1.DataSource = templateNames;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var className = row.Cells["Value"]?.Value?.ToString();
                SelectionChanged?.Invoke(className);                
                break;
            }
        }
    }
}
