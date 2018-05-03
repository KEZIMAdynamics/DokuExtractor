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
using DokuExtractorStandardGUI.Localization;

namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    public partial class ucGroupTemplateEditor : UserControl
    {
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
            butSaveTemplate.Text = Translation.LanguageStrings.ButSaveTemplate;
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
            var groupTemplateWithChangedDataFields = ucSingleTemplateEditor1.GetDocumentGroupTemplateWithChangedDataFields();
            this.selectedGroupTemplate.DataFields = groupTemplateWithChangedDataFields.DataFields;


            var oldTemplate = this.groupTemplates.Where(x => x.TemplateGroupName == this.selectedGroupTemplate.TemplateGroupName).FirstOrDefault();
            if (oldTemplate != null)
            {
                this.groupTemplates.Remove(oldTemplate);
                this.groupTemplates.Add(this.selectedGroupTemplate);
            }

            var templateProcessor = new TemplateProcessor(Application.StartupPath);

            var templateDummyList = new List<DocumentGroupTemplate>();
            templateDummyList.Add(this.selectedGroupTemplate);
            templateProcessor.SaveTemplates(templateDummyList);

            MessageBox.Show(Translation.LanguageStrings.MsgGroupTemplateSaved, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butAddDataField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddDataFieldGroupTemplate();
        }

        private void butAddCalculationField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddCalculationField();
        }
    }
}
