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
    public partial class ucClassTemplateEditor : UserControl
    {
        private DocumentClassTemplate selectedClassTemplate = new DocumentClassTemplate();
        private List<DocumentClassTemplate> classTemplates = new List<DocumentClassTemplate>();

        public ucClassTemplateEditor()
        {
            InitializeComponent();
        }

        private void ucClassTemplateEditor_Load(object sender, EventArgs e)
        {
            Localize();
        }

        /// <summary>
        /// Initializes the class template editor
        /// </summary>
        /// <param name="classTemplates">Class template</param>
        public void InitializeClassTemplateEditor(List<DocumentClassTemplate> classTemplates)
        {
            this.classTemplates = classTemplates;
            ucTemplateSelector1.SelectionChanged += UcTemplateSelector1_SelectionChanged;

            var classTemplateNameList = new List<StringValue>();
            foreach (var item in this.classTemplates)
            {
                classTemplateNameList.Add(new StringValue(item.TemplateClassName));
            }

            ucTemplateSelector1.LoadTemplates(classTemplateNameList);
        }

        private void Localize()
        {
            butAddDataField.Text = Translation.LanguageStrings.ButAddDataField;
            butAddConditionalField.Text = Translation.LanguageStrings.ButAddConditionalField;
            butSaveTemplate.Text = Translation.LanguageStrings.ButSaveTemplate;
        }

        private void UcTemplateSelector1_SelectionChanged(string templateName)
        {
            if (this.selectedClassTemplate.TemplateClassName != templateName)
            {
                this.selectedClassTemplate = this.classTemplates.Where(x => x.TemplateClassName == templateName).FirstOrDefault();
                ucSingleTemplateEditor1.ShowPropertiesAndDataFields(this.selectedClassTemplate);
            }
        }

        private void butSaveTemplate_Click(object sender, EventArgs e)
        {
            this.selectedClassTemplate = ucSingleTemplateEditor1.GetDocumentClassTemplateWithChangedGeneralProperties();
            var classTemplateWithChangedDataFields = ucSingleTemplateEditor1.GetDocumentClassTemplateWithChangedFields();
            this.selectedClassTemplate.DataFields = classTemplateWithChangedDataFields.DataFields;


            var oldTemplate = this.classTemplates.Where(x => x.TemplateClassName == this.selectedClassTemplate.TemplateClassName).FirstOrDefault();
            if (oldTemplate != null)
            {
                this.classTemplates.Remove(oldTemplate);
                this.classTemplates.Add(this.selectedClassTemplate);
            }

            var templateProcessor = new TemplateProcessor(Directories.AppRootPath);
            var saved = templateProcessor.SaveTemplate(this.selectedClassTemplate);
            if (saved == true)
                MessageBox.Show(Translation.LanguageStrings.MsgClassTemplateSaved, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butAddDataField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddDataFieldClassTemplate();
        }

        private void butAddConditionalField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddConditionalField();
        }
    }
}
