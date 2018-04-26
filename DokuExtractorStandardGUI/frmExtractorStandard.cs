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

namespace DokuExtractorStandardGUI
{
    public partial class frmExtractorStandard : Form
    {
        private List<DocumentClassTemplate> classTemplates { get; set; } = new List<DocumentClassTemplate>();

        private Guid regexHelperID = Guid.Empty;
        private DataFieldTypes regexHelperFieldType = DataFieldTypes.Text;
        private bool isAnchorSelectionRunning = false;
        private bool isValueSelectionRunning = false;
        private string regexHelperAnchorText = string.Empty;
        private string regexHelperValueText = string.Empty;

        private string selectedFilePath = string.Empty;
        private TemplateProcessor templateProcessor = new TemplateProcessor(Application.StartupPath);

        public frmExtractorStandard(string filePath, bool allowEditTemplates = false)
        {
            InitializeComponent();
            ucFileSelector1.SelectedFileChanged += UcFileSelector1_SelectedFileChanged;
            ucViewer1.TextSelected += UcViewer1_TextSelected;
            ucResultAndEditor1.TabSwitched += UcResultAndEditor1_TabSwitched;
            ucResultAndEditor1.RegexExpressionHelper += UcResultAndEditor1_RegexExpressionHelper;

            var fileInfos = new List<FileInfo>();
            var files = Directory.GetFiles(filePath);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                fileInfos.Add(fileInfo);
            }

            if (allowEditTemplates == false)
                DisableBuiltInEditor();

            ucFileSelector1.LoadFiles(fileInfos);
        }

        public frmExtractorStandard(List<FileInfo> fileInfos, bool allowEditTemplates = false)
        {
            InitializeComponent();
            ucFileSelector1.SelectedFileChanged += UcFileSelector1_SelectedFileChanged;
            ucViewer1.TextSelected += UcViewer1_TextSelected;
            ucResultAndEditor1.TabSwitched += UcResultAndEditor1_TabSwitched;
            ucResultAndEditor1.RegexExpressionHelper += UcResultAndEditor1_RegexExpressionHelper;

            if (allowEditTemplates == false)
                DisableBuiltInEditor();

            ucFileSelector1.LoadFiles(fileInfos);
        }

        public void DisableBuiltInEditor()
        {
            ucResultAndEditor1.DisableBuiltInEditor();
            butAddDataField.Visible = false;
            butSaveTemplate.Visible = false;
            butTemplateEditor.Visible = false;
        }

        private void frmExtractorStandard_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            UcResultAndEditor1_TabSwitched(false);
        }

        private async void UcViewer1_TextSelected(string selectedText)
        {
            //TODO
            if (isAnchorSelectionRunning)
            {
                this.regexHelperAnchorText = selectedText;
                isAnchorSelectionRunning = false;
                isValueSelectionRunning = true;
                lblInstruction.Text = "Select a value!";
            }
            else if (isValueSelectionRunning)
            {
                this.regexHelperValueText = selectedText;
                isValueSelectionRunning = false;
                lblInstruction.Text = string.Empty;

                var loader = new PdfTextLoader();
                var inputString = await loader.GetTextFromPdf(selectedFilePath, false);

                var regexResult = new RegexExpressionFinderResult();
                if (templateProcessor.TryFindRegexMatchExpress(inputString, regexHelperValueText, regexHelperAnchorText, regexHelperFieldType, false, out regexResult))
                {
                    var matchingValues = string.Empty;
                    foreach (var matchingValue in regexResult.AllMatchingValues)
                    {
                        matchingValues = matchingValues + Environment.NewLine + matchingValue;
                    }

                    var result = MessageBox.Show("Do you accept the following result?" + Environment.NewLine + Environment.NewLine + "Regex Expression: " + regexResult.RegexExpression
                                 + Environment.NewLine + "Matching Values: " + matchingValues, "", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        var additionalRegex = MessageBox.Show("Do you want to add this expression as an ADDITIONAL expression?", "", MessageBoxButtons.YesNo);
                        if (additionalRegex == DialogResult.Yes)
                            ChangeOrAddRegexExpression(this.regexHelperID, regexResult.RegexExpression, true);
                        else
                            ChangeOrAddRegexExpression(this.regexHelperID, regexResult.RegexExpression, false);
                    }
                }
                else
                {
                    MessageBox.Show("Could not get a regex expression finder result!");
                }

                EnableOrDisableControlsAndButtons(true);
            }
        }

        private void ChangeOrAddRegexExpression(Guid regexHelperID, string regex, bool additionalRegex)
        {
            ucResultAndEditor1.ChangeOrAddRegexExpression(regexHelperID, regex, additionalRegex);
        }

        private void UcFileSelector1_SelectedFileChanged(string newPath)
        {
            this.selectedFilePath = newPath;
            ucViewer1.LoadPdf(newPath);
            ucResultAndEditor1.ShowPropertiesAndDataFields(new DocumentClassTemplate());
        }


        private void UcResultAndEditor1_TabSwitched(bool switchedToSingleTemplateEditor)
        {
            if (switchedToSingleTemplateEditor)
            {
                butSaveTemplate.Enabled = true;
                butAddDataField.Enabled = true;
            }
            else
            {
                butSaveTemplate.Enabled = false;
                butAddDataField.Enabled = false;
            }
        }

        private void UcResultAndEditor1_RegexExpressionHelper(Guid id, DataFieldTypes dataFieldType)
        {
            //TODO
            EnableOrDisableControlsAndButtons(false);

            regexHelperID = id;
            regexHelperFieldType = dataFieldType;
            isAnchorSelectionRunning = true;
            lblInstruction.Text = "Select an anchor!";
        }

        private void EnableOrDisableControlsAndButtons(bool enablingState)
        {
            ucFileSelector1.Enabled = enablingState;
            ucResultAndEditor1.Enabled = enablingState;
            butSaveTemplate.Enabled = enablingState;
            butAddDataField.Enabled = enablingState;
            butGo.Enabled = enablingState;
            butOk.Enabled = enablingState;
        }

        private void butTemplateEditor_Click(object sender, EventArgs e)
        {
            var templateProcessor = new TemplateProcessor(Application.StartupPath);
            var classTemplates = templateProcessor.LoadClassTemplatesFromDisk();
            var groupTemplates = templateProcessor.LoadGroupTemplatesFromDisk();

            var templateEditor = new frmTemplateEditor(classTemplates, groupTemplates);
            templateEditor.Show();
        }

        private async void butGo_Click(object sender, EventArgs e)
        {
            classTemplates = templateProcessor.LoadClassTemplatesFromDisk();
            var groupTemplates = templateProcessor.LoadGroupTemplatesFromDisk();

            var loader = new PdfTextLoader();
            var inputString = await loader.GetTextFromPdf(selectedFilePath, false);

            var matchingTemplateResult = templateProcessor.MatchTemplates(classTemplates, inputString);
            var template = matchingTemplateResult.Template;

            if (matchingTemplateResult.IsMatchSuccessfull)
            {
                ucResultAndEditor1.SwitchTab(false);
                MessageBox.Show("Yay, template found: " + template.TemplateClassName);
                var result = templateProcessor.ExtractData(template, groupTemplates, inputString);
                ucResultAndEditor1.ShowExtractedData(result, template);
            }
            else
            {
                ucResultAndEditor1.SwitchTab(true);
                template = templateProcessor.AutoCreateClassTemplate("NewTemplate", inputString);
                var json = templateProcessor.ExtractDataAsJson(template, groupTemplates, inputString);

                ucResultAndEditor1.ShowPropertiesAndDataFields(template);
            }
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            var result = ucResultAndEditor1.GetFieldExtractionResult();
            ucFileSelector1.RemoveFileFromQueue(selectedFilePath);
        }

        private void butSaveTemplate_Click(object sender, EventArgs e)
        {
            var newTemplate = ucResultAndEditor1.GetChangedDocumentClassTemplate();

            var oldTemplate = this.classTemplates.Where(x => x.TemplateClassName == newTemplate.TemplateClassName).FirstOrDefault();
            if (oldTemplate != null)
            {
                this.classTemplates.Remove(oldTemplate);
                this.classTemplates.Add(newTemplate);
            }

            var templateProcessor = new TemplateProcessor(Application.StartupPath);

            var templateDummyList = new List<DocumentClassTemplate>();
            templateDummyList.Add(newTemplate);
            templateProcessor.SaveTemplates(templateDummyList);

            MessageBox.Show("Template saved.");
        }

        private void frmExtractorStandard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ucFileSelector1.SelectedFileChanged -= UcFileSelector1_SelectedFileChanged;
                ucViewer1.TextSelected -= UcViewer1_TextSelected;
                ucResultAndEditor1.TabSwitched -= UcResultAndEditor1_TabSwitched;
            }
            catch (Exception ex)
            { }
        }

        private void butAddDataField_Click(object sender, EventArgs e)
        {
            ucResultAndEditor1.AddDataField();
        }
    }
}
