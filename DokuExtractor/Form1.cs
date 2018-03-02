using DokuExtractorCore;
using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DokuExtractorGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btLos_Click(object sender, EventArgs e)
        {
            var processor = new TemplateProcessor(Application.StartupPath);

            var templates = processor.LoadTemplatesFromDisk();
            var inputString = tbInhalt.Text;

            var matchingTemplateResult = processor.MatchTemplates(templates, inputString);
            var template = matchingTemplateResult.Template;
            if (matchingTemplateResult.IsMatchSuccessfull == false)
                template = processor.AutoCreateTemplate("NeuesTemplate", inputString);

            if (matchingTemplateResult.IsMatchSuccessfull)
            {
                MessageBox.Show("Yay ich habe " + template.TemplateName + " gefunden!");


            }
            var json = processor.ExtractDataAsJson(template, inputString);
            tbExtractedData.Text = json;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btBeispieltemplateGenerieren_Click(object sender, EventArgs e)
        {
            var proc = new TemplateProcessor(Application.StartupPath);
            var templates = new List<FieldExtractorTemplate>();
            templates.Add(new DokuExtractorCore.Model.FieldExtractorTemplate()
            {
                TemplateName = "StartTemplate",
                KeyWords = new List<string>() { "bla", "blubb|blobb" },
                DataFields = new List<DokuExtractorCore.Model.DataFieldTemplate>()
                   {
                        new DokuExtractorCore.Model.DataFieldTemplate()
                        {
                             Name = "Ein Datenfeld",
                             RegexExpression = "/d/",
                             RegexFullString = "Auto fahren",
                             RegexHalfString = "Auto ",
                              FieldType = DataFieldTypes.Date
                        },
                        new DokuExtractorCore.Model.DataFieldTemplate()
                        {
                            Name = "Noch ein Datenfeld",
                            RegexExpression = "/s/",
                            RegexFullString = "Flugzeug fliegen",
                            RegexHalfString = "Flugzeug ",
                              FieldType = DataFieldTypes.Text
                        }
                   }
            });
            proc.SaveTemplates(templates, Path.Combine(Application.StartupPath, "ExtractorTemplates"));
        }
    }
}
