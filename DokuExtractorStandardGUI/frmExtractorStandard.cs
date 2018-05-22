using DokuExtractorCore;
using DokuExtractorCore.Model;
using DokuExtractorStandardGUI.Localization;
using DokuExtractorStandardGUI.Logic;
using DokuExtractorStandardGUI.UserControlsTemplateEditor;
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
        private DataFieldType regexHelperFieldType = DataFieldType.Text;
        private bool isAnchorSelectionRunning = false;
        private bool isValueSelectionRunning = false;
        private string regexHelperAnchorText = string.Empty;
        private string regexHelperValueText = string.Empty;

        private string selectedFilePath = string.Empty;
        private string languageFolderPath = string.Empty;
        private TemplateProcessor templateProcessor = new TemplateProcessor(Application.StartupPath);

        /// <summary>
        /// Main form of DokuExtractor
        /// </summary>
        /// <param name="fileFolderPath">Folder path, which includes the files that have to be processed within the DokuExtractor</param>
        /// <param name="languageFolderPath">Folder path, where the language files are</param>
        /// <param name="culture">Culture info, which defines, which language (of the language folder path) shall be used</param>
        /// <param name="additionalCultureInfo">If there is more than one language file belonging to the given culture info, additional culture info can be used</param>
        /// <param name="allowEditTemplates">Allows or pohibits the access to the template editors</param>
        /// <param name = "accessToAdminTools">Allows or prohibits the access to the global template editor and to the language editor</param>
        public frmExtractorStandard(string fileFolderPath, string languageFolderPath, CultureInfo culture, string additionalCultureInfo = "", bool allowEditTemplates = false, bool accessToAdminTools = false)
        {
            InitializeComponent();
            this.languageFolderPath = languageFolderPath;
            Translation.LoadLanguageFile(culture, additionalCultureInfo, languageFolderPath);
            SubscribeOnEvents();

            var fileInfos = new List<FileInfo>();
            var files = Directory.GetFiles(fileFolderPath);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                fileInfos.Add(fileInfo);
            }

            if (allowEditTemplates == false)
                DisableBuiltInEditor();

            if (accessToAdminTools == false)
                DisableAdminTools();

            ucFileSelector1.LoadFiles(fileInfos);
        }

        /// <summary>
        /// Main form of DokuExtractor
        /// </summary>
        /// <param name="fileInfos">List of file infos, including files that have to be processed within the DokuExtractor</param>
        /// <param name="languageFolderPath">Folder path, where the language files are</param>
        /// <param name="culture">Culture info, which defines, which language (of the language folder path) shall be used</param>
        /// <param name="additionalCultureInfo">If there is more than one language file belonging to the given culture info, additional culture info can be used</param>
        /// <param name="allowEditTemplates">Allows or prohibits the access to the built in template editor</param>
        /// <param name = "accessToAdminTools">Allows or prohibits the access to the global template editor and to the language editor</param>
        public frmExtractorStandard(List<FileInfo> fileInfos, string languageFolderPath, CultureInfo culture, string additionalCultureInfo = "", bool allowEditTemplates = false, bool accessToAdminTools = false)
        {
            InitializeComponent();
            this.languageFolderPath = languageFolderPath;
            Translation.LoadLanguageFile(culture, additionalCultureInfo, languageFolderPath);
            SubscribeOnEvents();

            if (allowEditTemplates == false)
                DisableBuiltInEditor();

            if (accessToAdminTools == false)
                DisableAdminTools();

            ucFileSelector1.LoadFiles(fileInfos);
        }

        private void frmExtractorStandard_Load(object sender, EventArgs e)
        {
            RegisterTemplateUserControls();
            Localize();
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            UcResultAndEditor1_TabSwitched(false);
        }

        private void SubscribeOnEvents()
        {
            ucFileSelector1.SelectedFileChanged += UcFileSelector1_SelectedFileChanged;
            ucViewer1.TextSelected += UcViewer1_TextSelected;
            ucResultAndEditor1.TabSwitched += UcResultAndEditor1_TabSwitched;
            ucResultAndEditor1.RegexExpressionHelper += UcResultAndEditor1_RegexExpressionHelper;
            ucResultAndEditor1.ConditionalFieldCellDoubleClick += UcResultAndEditor1_ConditionalFieldCellDoubleClick;
        }

        public void DisableBuiltInEditor()
        {
            ucResultAndEditor1.DisableBuiltInEditor();
            butAddDataField.Visible = false;
            butSaveTemplate.Visible = false;
        }

        public void DisableAdminTools()
        {
            butTemplateEditor.Visible = false;
            butLanguageEditor.Visible = false;
        }

        private void RegisterTemplateUserControls()
        {
            //To change user controls of the data field templates, change type here (the choosen user control has to be a derivation of the origin user control):
            TemplateUserControlSelector.RegisterDataFieldClassTemplateUserControl<ucDataFieldClassTemplate>();
            TemplateUserControlSelector.RegisterDataFieldGroupTemplateUserControl<ucDataFieldGroupTemplate>();
            TemplateUserControlSelector.RegisterCalculationFieldGroupTemplateUserControl<ucCalculationFieldGroupTemplate>();
            TemplateUserControlSelector.RegisterConditionalFieldGroupTemplateUserControl<ucConditionalFieldTemplate>();
        }

        private void Localize()
        {
            butGo.Text = Translation.LanguageStrings.ButGo;
            butOk.Text = Translation.LanguageStrings.ButOk;
            butAddDataField.Text = Translation.LanguageStrings.ButAddDataField;
            butAddConditionalField.Text = Translation.LanguageStrings.ButAddConditionalField;
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

        /// <summary>
        /// Chagnes a regex expression or adds an addtional regex string to the regex expression list
        /// </summary>
        /// <param name="regexHelperID">ID of the regex expression, which shall be changed</param>
        /// <param name="regex">Regex expression</param>
        /// <param name="additionalRegex">Shall the regex expression be added to the regex expression list or shall it overwrite the list completely?</param>
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
                butAddConditionalField.Enabled = true;
            }
            else
            {
                butSaveTemplate.Enabled = false;
                butAddDataField.Enabled = false;
                butAddConditionalField.Enabled = false;
            }
        }

        private void UcResultAndEditor1_RegexExpressionHelper(Guid id, DataFieldType dataFieldType)
        {
            EnableOrDisableControlsAndButtons(false);

            regexHelperID = id;
            regexHelperFieldType = dataFieldType;
            isAnchorSelectionRunning = true;
            lblInstruction.Text = Translation.LanguageStrings.InstructionSelectAnchor;
        }

        private void UcResultAndEditor1_ConditionalFieldCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EnableOrDisableControlsAndButtons(bool enablingState)
        {
            ucFileSelector1.Enabled = enablingState;
            ucResultAndEditor1.Enabled = enablingState;
            butSaveTemplate.Enabled = enablingState;
            butAddDataField.Enabled = enablingState;
            butAddConditionalField.Enabled = enablingState;
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
            if (ucResultAndEditor1.CheckIfAllDataFieldsAreFilled() == true
                && ucResultAndEditor1.CheckIfAllCalculationResultsEqualValidation() == true
                && ucResultAndEditor1.CheckIfAllConditionalFieldsAreFilled() == true)
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
            var saved = templateProcessor.SaveTemplate(newTemplate);
            if (saved == true)
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

        private void butAddConditionalField_Click(object sender, EventArgs e)
        {
            ucResultAndEditor1.AddConditionalField();
        }

        private void butLanguageEditor_Click(object sender, EventArgs e)
        {
            var languageEditor = new frmLanguageEditor(this.languageFolderPath);
            languageEditor.ShowDialog();
        }
    }
}
