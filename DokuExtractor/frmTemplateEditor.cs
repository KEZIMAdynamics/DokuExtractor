using DokuExtractorCore;
using DokuExtractorCore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DokuExtractorGUI
{
    public partial class frmTemplateEditor : Form
    {
        public frmTemplateEditor()
        {
            InitializeComponent();
        }

        public void LoadTemplate(FieldExtractorTemplate template)
        {
            tbTemplateBox.Text = JsonConvert.SerializeObject(template, Formatting.Indented);
        }

        private void btIgnoreTemplate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSaveTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                var template = JsonConvert.DeserializeObject<FieldExtractorTemplate>(tbTemplateBox.Text);
                new TemplateProcessor(Application.StartupPath).SaveTemplates(new List<FieldExtractorTemplate>() { template });
                MessageBox.Show("Template " + template.TemplateName + " gespeichert.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }
    }
}
