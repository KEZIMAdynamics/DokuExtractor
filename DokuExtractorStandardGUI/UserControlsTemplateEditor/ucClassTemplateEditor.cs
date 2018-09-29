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
        public delegate void ClassTemplateSavedInClassTemplateEditorHandler(DocumentClassTemplate savedClassTemplate);
        /// <summary>
        /// Fired, when user has pressed save button in class template editor
        /// </summary>
        public event ClassTemplateSavedInClassTemplateEditorHandler ClassTemplateSavedInClassTemplateEditor;

        public delegate void ClassTemplateDeletedInClassTemplateEditorHandler(DocumentClassTemplate deletedClassTemplate);
        /// <summary>
        /// Fired, when user has pressed delete button in class template editor
        /// </summary>
        public event ClassTemplateDeletedInClassTemplateEditorHandler ClassTemplateDeletedInClassTemplateEditor;

        private DocumentClassTemplate selectedClassTemplate = new DocumentClassTemplate();
        private List<DocumentClassTemplate> classTemplates = new List<DocumentClassTemplate>();

        public ucClassTemplateEditor()
        {
            InitializeComponent();
            ucSingleTemplateEditor1.IsInClassTemplateEditor = true;
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
            butDeleteTemplate.Text = Translation.LanguageStrings.ButDeleteTemplate;
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


            //var oldTemplate = this.classTemplates.Where(x => x.TemplateClassName == this.selectedClassTemplate.TemplateClassName).FirstOrDefault();
            //if (oldTemplate != null)
            //{
            //    this.classTemplates.Remove(oldTemplate);
            //    this.classTemplates.Add(this.selectedClassTemplate);
            //}

            var templateProcessor = new TemplateProcessor(Directories.AppRootPath);
            if (Directories.AllowSaveTemplatesToFiles)
            {
                this.selectedClassTemplate.TemplateClassName = System.Text.RegularExpressions.Regex.Replace(this.selectedClassTemplate.TemplateClassName, @"[^0-9a-zA-Z]", string.Empty);
                var saved = templateProcessor.SaveTemplateToFile(this.selectedClassTemplate);
                if (saved == true)
                    ClassTemplateSavedInClassTemplateEditor?.Invoke(this.selectedClassTemplate);
            }
            else
            {
                this.selectedClassTemplate.TemplateClassName = System.Text.RegularExpressions.Regex.Replace(this.selectedClassTemplate.TemplateClassName, @"[^0-9a-zA-Z]", string.Empty);
                templateProcessor.CleanClassTemplateBeforeSave(this.selectedClassTemplate);
                ClassTemplateSavedInClassTemplateEditor?.Invoke(this.selectedClassTemplate);
            }
        }

        private void butAddDataField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddDataFieldClassTemplate();
        }

        private void butAddConditionalField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddConditionalField(false);
        }

        private void butDeleteTemplate_Click(object sender, EventArgs e)
        {
            var delete = MessageBox.Show(Translation.LanguageStrings.MsgAskDeleteTemplate, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (delete == DialogResult.Yes)
            {
                var templateProcessor = new TemplateProcessor(Directories.AppRootPath);
                if (Directories.AllowSaveTemplatesToFiles)
                {
                    var deleted = templateProcessor.DeleteTemplateFile(this.selectedClassTemplate);
                    if (deleted == true)
                    {
                        ClassTemplateDeletedInClassTemplateEditor?.Invoke(this.selectedClassTemplate);
                        ucTemplateSelector1.RemoveSelectedTemplate();
                    }
                }
                else
                {
                    ClassTemplateDeletedInClassTemplateEditor?.Invoke(this.selectedClassTemplate);
                    ucTemplateSelector1.RemoveSelectedTemplate();
                }
            }
        }
    }
}
