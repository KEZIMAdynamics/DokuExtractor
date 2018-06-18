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
using DokuExtractorStandardGUI.Localization;

namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    public partial class ucGroupTemplateEditor : UserControl
    {
        public delegate void GroupTemplateSavedInGroupTemplateEditorHandler(DocumentGroupTemplate savedGroupTemplate);
        /// <summary>
        /// Fired, when user has pressed save button in group template editor
        /// </summary>
        public event GroupTemplateSavedInGroupTemplateEditorHandler GroupTemplateSavedInGroupTemplateEditor;

        public delegate void GroupTemplateDeletedInGroupTemplateEditorHandler(DocumentGroupTemplate deletedGroupTemplate);
        /// <summary>
        /// Fired, when user has pressed delete button in group template editor
        /// </summary>
        public event GroupTemplateDeletedInGroupTemplateEditorHandler GroupTemplateDeletedInGroupTemplateEditor;

        private DocumentGroupTemplate selectedGroupTemplate = new DocumentGroupTemplate();
        private List<DocumentGroupTemplate> groupTemplates = new List<DocumentGroupTemplate>();

        public ucGroupTemplateEditor()
        {
            InitializeComponent();
        }

        private void ucGroupTemplateEditor_Load(object sender, EventArgs e)
        {
            Localize();
        }

        /// <summary>
        /// Initializes the group template editor
        /// </summary>
        /// <param name="groupTemplates"></param>
        public void InitializeGroupTemplateEditor(List<DocumentGroupTemplate> groupTemplates)
        {
            this.groupTemplates = groupTemplates;
            ucTemplateSelector1.SelectionChanged += UcTemplateSelector1_SelectionChanged;

            var groupTemplateNameList = new List<StringValue>();
            foreach (var item in this.groupTemplates)
            {
                groupTemplateNameList.Add(new StringValue(item.TemplateGroupName));
            }

            ucTemplateSelector1.LoadTemplates(groupTemplateNameList);
        }

        private void Localize()
        {
            butAddDataField.Text = Translation.LanguageStrings.ButAddDataField;
            butAddCalculationField.Text = Translation.LanguageStrings.ButAddCalculationField;
            butAddConditionalField.Text = Translation.LanguageStrings.ButAddConditionalField;
            butSaveTemplate.Text = Translation.LanguageStrings.ButSaveTemplate;
            butDeleteTemplate.Text = Translation.LanguageStrings.ButDeleteTemplate;
        }

        private void UcTemplateSelector1_SelectionChanged(string templateName)
        {
            if (this.selectedGroupTemplate.TemplateGroupName != templateName)
            {
                this.selectedGroupTemplate = this.groupTemplates.Where(x => x.TemplateGroupName == templateName).FirstOrDefault();
                ucSingleTemplateEditor1.ShowPropertiesAndDataFields(this.selectedGroupTemplate);
            }
        }

        private void butSaveTemplate_Click(object sender, EventArgs e)
        {
            this.selectedGroupTemplate = ucSingleTemplateEditor1.GetDocumentGroupTemplateWithChangedGeneralProperties();
            var groupTemplateWithChangedFields = ucSingleTemplateEditor1.GetDocumentGroupTemplateWithChangedFields();
            this.selectedGroupTemplate.DataFields = groupTemplateWithChangedFields.DataFields;
            this.selectedGroupTemplate.CalculationFields = groupTemplateWithChangedFields.CalculationFields;
            this.selectedGroupTemplate.ConditionalFields = groupTemplateWithChangedFields.ConditionalFields;

            var templateProcessor = new TemplateProcessor(Directories.AppRootPath);
            if (Directories.AllowSaveTemplatesToFiles)
            {
                this.selectedGroupTemplate.TemplateGroupName = System.Text.RegularExpressions.Regex.Replace(this.selectedGroupTemplate.TemplateGroupName, @"[^0-9a-zA-Z]", string.Empty);
                var saved = templateProcessor.SaveTemplateToFile(this.selectedGroupTemplate);
                if (saved == true)
                    GroupTemplateSavedInGroupTemplateEditor?.Invoke(this.selectedGroupTemplate);
            }
            else
            {
                this.selectedGroupTemplate.TemplateGroupName = System.Text.RegularExpressions.Regex.Replace(this.selectedGroupTemplate.TemplateGroupName, @"[^0-9a-zA-Z]", string.Empty);
                GroupTemplateSavedInGroupTemplateEditor?.Invoke(this.selectedGroupTemplate);
            }
        }

        private void butAddDataField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddDataFieldGroupTemplate();
        }

        private void butAddCalculationField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddCalculationField();
        }

        private void butAddConditionalField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddConditionalField(true);
        }

        private void butDeleteTemplate_Click(object sender, EventArgs e)
        {
            var delete = MessageBox.Show(Translation.LanguageStrings.MsgAskDeleteTemplate, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (delete == DialogResult.Yes)
            {
                var templateProcessor = new TemplateProcessor(Directories.AppRootPath);
                if (Directories.AllowSaveTemplatesToFiles)
                {
                    var deleted = templateProcessor.DeleteTemplateFile(this.selectedGroupTemplate);
                    if (deleted == true)
                    {
                        GroupTemplateDeletedInGroupTemplateEditor?.Invoke(this.selectedGroupTemplate);
                        ucTemplateSelector1.RemoveSelectedTemplate();
                    }
                }
                else
                {
                    GroupTemplateDeletedInGroupTemplateEditor?.Invoke(this.selectedGroupTemplate);
                    ucTemplateSelector1.RemoveSelectedTemplate();
                }
            }
        }
    }
}
