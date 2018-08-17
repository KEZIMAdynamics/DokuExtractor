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
        bool isNightModeEnabled = false;

        public Form1()
        {
            InitializeComponent();
            listBox1.SelectedIndex = 0;
        }

        private void btLos_Click(object sender, EventArgs e)
        {
            //  var processor = new TemplateProcessor(Application.StartupPath);

            var classTemplates = processor.LoadClassTemplatesFromDisk();
            var groupTemplates = processor.LoadGroupTemplatesFromDisk();

            var inputString = tbInhalt.Text;

            var matchingTemplateResult = processor.MatchTemplates(classTemplates, inputString);
            var template = matchingTemplateResult.GetTemplate();
            //if (matchingTemplateResult.IsMatchSuccessfull == false)
            //    template = processor.AutoCreateTemplate("NeuesTemplate", inputString);

            if (matchingTemplateResult.IsMatchSuccessfull)
            {
                MessageBox.Show("Yay ich habe " + template.TemplateClassName + " gefunden!");
                var json = processor.ExtractDataAsJson(template, groupTemplates, inputString);
                tbExtractedData.Text = json;
            }
            else
            {
                var baseGroupTemplateMatchResult = processor.MatchTemplates(groupTemplates, inputString);
                if (baseGroupTemplateMatchResult.IsMatchSuccessfull)
                    template = processor.AutoCreateClassTemplate("NeuesTemplate", inputString, baseGroupTemplateMatchResult.GetTemplate());
                else
                    // TODO: Show group template selection dialog instead of defaulting to "Rechnung"
                    template = processor.AutoCreateClassTemplate("NeuesTemplate", inputString, groupTemplates.Where(x => x.TemplateGroupName == "Rechnung").FirstOrDefault());
                var json = processor.ExtractDataAsJson(template, groupTemplates, inputString);
                tbExtractedData.Text = json;

                var editor = new frmTemplateEditor();
                editor.Text = "Neues Template entdeckt";
                editor.LoadTemplate(template);
                if (isNightModeEnabled)
                {
                    PaintAllControls(editor, Color.PaleGreen, Color.Black);
                    editor.BackColor = Color.Black;
                }
                editor.Show();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (isNightModeEnabled)
            {
                PaintAllControls(this, Color.PaleGreen, Color.Black);
                BackColor = Color.Black;
            }
        }

        private void btBeispieltemplateGenerieren_Click(object sender, EventArgs e)
        {
            var proc = new TemplateProcessor(Application.StartupPath);
            var templates = new List<DocumentGroupTemplate>();
            templates.Add(new DokuExtractorCore.Model.DocumentGroupTemplate()
            {
                TemplateGroupName = "StartTemplate",
                //KeyWords = new List<string>() { "bla", "blubb|blobb" },
                DataFields = new List<DokuExtractorCore.Model.DataFieldGroupTemplate>()
                   {
                        new DokuExtractorCore.Model.DataFieldGroupTemplate()
                        {
                             Name = "Ein Datumsfeld",
                  //           RegexExpressions = new List<string>(){ "/d/" },
                             TextAnchors = new List<string>(){ "Datum", "Datum:" },
                             //RegexHalfString = "Auto ",
                              FieldType = DataFieldType.Date
                        },
                        new DokuExtractorCore.Model.DataFieldGroupTemplate()
                        {
                            Name = "Ein Währungsfeld",
                    //        RegexExpressions = new List<string>(){"/s/" },
                            TextAnchors = new List<string>(){ "Summe", "Summe:" },
                            //RegexHalfString = "Flugzeug ",
                              FieldType = DataFieldType.Currency
                        }
                   },
                CalculationFields = new List<CalculationFieldTemplate>()
                    {
                        new CalculationFieldTemplate()
                        {
                            Name = "Netto Brutto Vergleich",
                            CalculationExpression = "[Rechnungssumme Netto]+[Betrag MwSt]",
                            ValidationExpressions = new List<string>(){ "[Rechnungssumme Brutto]"},
                            FieldType = DataFieldType.Currency
                        }
                    },
                ConditionalFields = new List<ConditionalFieldTemplate>()
                {
                    new ConditionalFieldTemplate()
                    {
                        Name = "Bedingung",
                         ConditionValues = new List<ConditionValue>()
                         {
                              new ConditionValue()
                              {
                                   Condition = "hello",
                                    Value = "ERFÜLlt"
                              }
                         }
                    }
                }

            });

            proc.SaveTemplatesToFiles(templates);// Path.Combine(Application.StartupPath, "ExtractorTemplates"));
        }

        private void btOpenTemplateDir_Click(object sender, EventArgs e)
        {
            Process.Start(processor.TemplateClassDirectory);
        }

        private void btFindRegexExpression_Click(object sender, EventArgs e)
        {
            tbRegexTextAnchor.Text = tbRegexTextAnchor.Text.Trim(' ');
            var finder = new RegexExpressionFinder();

            DataFieldType type = (DataFieldType)Enum.Parse(typeof(DataFieldType), listBox1.SelectedItem.ToString(), true);

            RegexExpressionFinderResult expressionResult;
            if (finder.TryFindRegexMatchExpress(tbInhalt.Text, tbRegexTextAnchor.Text, tbRegexTargetValue.Text, type, false, out expressionResult))
            {
                tbExtractedData.Text = "Regex expression found:" + Environment.NewLine + expressionResult.RegexExpression + Environment.NewLine
                    + Environment.NewLine + "First matching value:" + Environment.NewLine + expressionResult.MatchingValue + Environment.NewLine + Environment.NewLine
                    + Environment.NewLine + "All matching values: " + expressionResult.AllMatchingValues.ConcatList("; ");
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

        private async void btLoadPdf_Click(object sender, EventArgs e)
        {
            var loader = new PdfTextLoader();

            var pdfContent = await loader.GetTextFromPdf(tbInputPfad.Text, false);
            tbInhalt.Font = new Font("Consolas", 8);
            tbInhalt.Text = pdfContent;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var text = string.Empty;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var item in files)
            {
                tbInputPfad.Text = item;
            }


        }

        private void btTwoLineTableTest_Click(object sender, EventArgs e)
        {
            new TwoLineTableProcessor().RunTest();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            isNightModeEnabled = !isNightModeEnabled;

            if (isNightModeEnabled)
            {
                PaintAllControls(this, Color.PaleGreen, Color.Black);
                BackColor = Color.Black;
            }
            else
            {
                PaintAllControls(this, Color.Black, SystemColors.Control);
                BackColor = SystemColors.Control;
            }
            //else
            //    foreach (Control item in this.Controls)
            //    {
            //        item.ForeColor = Color.DarkGreen;
            //        item.BackColor = Color.Black;
            //    }

        }

        void PaintAllControls(Control control, Color front, Color back)
        {
            foreach (Control item in control.Controls)
            {
                item.ForeColor = front;
                item.BackColor = back;
                PaintAllControls(item, front, back);
            }
        }
    }
}
