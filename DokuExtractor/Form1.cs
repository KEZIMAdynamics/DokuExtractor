using DokuExtractorCore;
using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        TemplateProcessor processor = new TemplateProcessor(Application.StartupPath);

        public Form1()
        {
            InitializeComponent();
            listBox1.SelectedIndex = 0;
        }

        private void btLos_Click(object sender, EventArgs e)
        {
            //  var processor = new TemplateProcessor(Application.StartupPath);

            var templates = processor.LoadTemplatesFromDisk();
            var inputString = tbInhalt.Text;

            var matchingTemplateResult = processor.MatchTemplates(templates, inputString);
            var template = matchingTemplateResult.Template;
            if (matchingTemplateResult.IsMatchSuccessfull == false)
                template = processor.AutoCreateTemplate("NeuesTemplate", inputString);

            if (matchingTemplateResult.IsMatchSuccessfull)
            {
                MessageBox.Show("Yay ich habe " + template.TemplateName + " gefunden!");
                var json = processor.ExtractDataAsJson(template, inputString);
                tbExtractedData.Text = json;
            }
            else
            {
                template = processor.AutoCreateTemplate("NeuesTemplate", inputString);
                var json = processor.ExtractDataAsJson(template, inputString);
                tbExtractedData.Text = json;

                var editor = new frmTemplateEditor();
                editor.Text = "Neues Template entdeckt";
                editor.LoadTemplate(template);
                editor.Show();

            }


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

        private void btOpenTemplateDir_Click(object sender, EventArgs e)
        {
            Process.Start(processor.TemplateDirectory);
        }

        private void btFindRegexExpression_Click(object sender, EventArgs e)
        {
            var finder = new RegexExpressionFinder();

            DataFieldTypes type = (DataFieldTypes)Enum.Parse(typeof(DataFieldTypes), listBox1.SelectedItem.ToString(), true);

            string expression;
            if (finder.TryFindRegexMatchExpress(tbInhalt.Text, tbRegexHalfString.Text, tbRegexFullString.Text, type, out expression))
            {
                tbExtractedData.Text = expression;
            }
            else
            {
                tbExtractedData.Text = "Kein Match gefunden -.-";
            }
        }

        private void btStartTableParser_Click(object sender, EventArgs e)
        {
            var form = new frmTableProcessor();
            form.Show();
        }
    }
}
