using DokuExtractorCore;
using DokuExtractorCore.Model;
using DokuExtractorStandardGUI.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private string languageFolderPath = string.Empty;

        public frmExtractorStandard(string filePath, string languageFolderPath, CultureInfo culture, string additionalCultureInfo = "", bool allowEditTemplates = false)
        {
            InitializeComponent();
            this.languageFolderPath = languageFolderPath;
            Translation.LoadLanguageFile(culture, additionalCultureInfo, languageFolderPath);
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

        public frmExtractorStandard(List<FileInfo> fileInfos, string languageFolderPath, CultureInfo culture, string additionalCultureInfo = "", bool allowEditTemplates = false)
        {
            InitializeComponent();
            this.languageFolderPath = languageFolderPath;
            Translation.LoadLanguageFile(culture, additionalCultureInfo, languageFolderPath);
            ucFileSelector1.SelectedFileChanged += UcFileSelector1_SelectedFileChanged;
            ucViewer1.TextSelected += UcViewer1_TextSelected;
            ucResultAndEditor1.TabSwitched += UcResultAndEditor1_TabSwitched;
            ucResultAndEditor1.RegexExpressionHelper += UcResultAndEditor1_RegexExpressionHelper;

            if (allowEditTemplates == false)
                DisableBuiltInEditor();

            ucFileSelector1.LoadFiles(fileInfos);
        }

        private void frmExtractorStandard_Load(object sender, EventArgs e)
        {
            Localize();
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            UcResultAndEditor1_TabSwitched(false);
        }

        public void DisableBuiltInEditor()
        {
            ucResultAndEditor1.DisableBuiltInEditor();
            butAddDataField.Visible = false;
            butSaveTemplate.Visible = false;
            butTemplateEditor.Visible = false;
        }

        private void Localize()
        {
            butGo.Text = Translation.LanguageStrings.ButGo;
            butOk.Text = Translation.LanguageStrings.ButOk;
            butAddDataField.Text = Translation.LanguageStrings.ButAddDataField;
            butSaveTemplate.Text = Translation.LanguageStrings.ButSaveTemplate;
            butTemplateEditor.Text = Translation.LanguageStrings.ButTemplateEditor;
            butLanguageEditor.Text = Translation.LanguageStrings.ButLanguageEditor;
        }

        private async void UcViewer1_TextSelected(string selectedText)
        {
            if (isAnchorSelectionRunning)
            {
                this.regexHelperAnchorText = selectedText;
                isAnchorSelectionRunning = false;
                isValueSelectionRunning = true;
                lblInstruction.Text = Translation.LanguageStrings.InstructionSelectValue;
            }
            else if (isValueSelectionRunning)
            {
                this.regexHelperValueText = selectedText;
                isValueSelectionRunning = false;
                lblInstruction.Text = string.Empty;

                var loader = new PdfTextLoader();
                var inputString = await loader.GetTextFromPdf(selectedFilePath, false);

                var regexResult = new RegexExpressionFinderResult();
                if (templateProcessor.TryFindRegexMatchExpress(inputString, regexHelperAnchorText, regexHelperValueText, regexHelperFieldType, false, out regexResult))
                {
                    var matchingValues = string.Empty;
                    foreach (var matchingValue in regexResult.AllMatchingValues)
                    {
                        matchingValues = matchingValues + Environment.NewLine + matchingValue;
                    }

                    var result = MessageBox.Show(Translation.LanguageStrings.MsgAskAcceptRegexExpressionHelperResult + Environment.NewLine + Environment.NewLine + "Regex Expression: " + regexResult.RegexExpression
                                 + Environment.NewLine + "Matching Values: " + matchingValues, string.Empty, MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {

                        var additionalRegex = MessageBox.Show(Translation.LanguageStrings.MsgAskAdditionalRegexExpression, string.Empty, MessageBoxButtons.YesNo);
                        if (additionalRegex == DialogResult.Yes)
                            ChangeOrAddRegexExpression(this.regexHelperID, regexResult.RegexExpression, true);
                        else
                            ChangeOrAddRegexExpression(this.regexHelperID, regexResult.RegexExpression, false);
                    }
                }
                else
                {
                    MessageBox.Show(Translation.LanguageStrings.MsgNoRegexExpressionFinderResult, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            EnableOrDisableControlsAndButtons(false);

            regexHelperID = id;
            regexHelperFieldType = dataFieldType;
            isAnchorSelectionRunning = true;
            lblInstruction.Text = Translation.LanguageStrings.InstructionSelectAnchor;
        }

        private void EnableOrDisableControlsAndButtons(bool enablingState)
        {
            ucFileSelector1.Enabled = enablingState;
            ucResultAndEditor1.Enabled = enablingState;
            butSaveTemplate.Enabled = enablingState;
            butAddDataField.Enabled = enablingState;
            butGo.Enabled = enablingState;
            butOk.Enabled = enablingState;
            butLanguageEditor.Enabled = enablingState;
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
                MessageBox.Show(Translation.LanguageStrings.MsgTemplateFound + template.TemplateClassName, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                var result = templateProcessor.ExtractData(template, groupTemplates, inputString);
                ucResultAndEditor1.ShowExtractedData(result, template);
            }
            else
            {
                ucResultAndEditor1.SwitchTab(true);

                template = templateProcessor.AutoCreateClassTemplate("NewTemplate", inputString);
                var json = templateProcessor.ExtractDataAsJson(template, groupTemplates, inputString);
                ucResultAndEditor1.ShowPropertiesAndDataFields(template);

                MessageBox.Show(Translation.LanguageStrings.MsgNoTemplateFound, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (ucResultAndEditor1.CheckIfAllDataFieldsAreFilled() == true && ucResultAndEditor1.CheckIfAllCalculationResultsEqualValidation() == true)
            {
                var result = ucResultAndEditor1.GetFieldExtractionResult();
                ucFileSelector1.RemoveFileFromQueue(selectedFilePath);
            }
            else
                MessageBox.Show(Translation.LanguageStrings.MsgEmptyOrInvalidValues, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            MessageBox.Show(Translation.LanguageStrings.MsgClassTemplateSaved, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmExtractorStandard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ucFileSelector1.SelectedFileChanged -= UcFileSelector1_SelectedFileChanged;
                ucViewer1.TextSelected -= UcViewer1_TextSelected;
                ucResultAndEditor1.TabSwitched -= UcResultAndEditor1_TabSwitched;
                ucResultAndEditor1.RegexExpressionHelper -= UcResultAndEditor1_RegexExpressionHelper;

            }
            catch (Exception ex)
            { }
        }

        private void butAddDataField_Click(object sender, EventArgs e)
        {
            ucResultAndEditor1.AddDataField();
        }

        private void butLanguageEditor_Click(object sender, EventArgs e)
        {
            var languageEditor = new frmLanguageEditor(this.languageFolderPath);
            languageEditor.ShowDialog();
        }
    }
}
