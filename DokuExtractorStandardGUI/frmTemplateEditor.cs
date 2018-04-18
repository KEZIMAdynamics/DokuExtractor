using DokuExtractorCore;
using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DokuExtractorStandardGUI
{
    public partial class frmTemplateEditor : Form
    {
        private DocumentClassTemplate selectedClassTemplate = new DocumentClassTemplate();
        private List<DocumentClassTemplate> classTemplates = new List<DocumentClassTemplate>();

        public frmTemplateEditor(List<DocumentClassTemplate> classTemplates)
        {
            InitializeComponent();
            this.classTemplates = classTemplates;
            ucTemplateSelector1.SelectionChanged += UcTemplateSelector1_SelectionChanged;

            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
        }

        private void UcTemplateSelector1_SelectionChanged(string templateName)
        {
            this.selectedClassTemplate = this.classTemplates.Where(x => x.TemplateClassName == templateName).FirstOrDefault();
            ucSingleTemplateEditor1.ShowPropertiesAndDataFields(this.selectedClassTemplate);
        }

        private void frmTemplateEditor_Load(object sender, EventArgs e)
        {
            var classTemplateNameList = new List<StringValue>();
            foreach (var item in this.classTemplates)
            {
                classTemplateNameList.Add(new StringValue(item.TemplateClassName));
            }

            ucTemplateSelector1.LoadTemplates(classTemplateNameList);
        }

        private void butSaveTemplate_Click(object sender, EventArgs e)
        {
            this.selectedClassTemplate = ucSingleTemplateEditor1.GetDocumentClassTemplateWithChangedGeneralProperties();
            var classTemplateWithChangedDataFields = ucSingleTemplateEditor1.GetDocumentClassTemplateWithChangedDataFields();
            this.selectedClassTemplate.DataFields = classTemplateWithChangedDataFields.DataFields;


            var oldTemplate = this.classTemplates.Where(x => x.TemplateClassName == this.selectedClassTemplate.TemplateClassName).FirstOrDefault();
            if (oldTemplate != null)
            {
                this.classTemplates.Remove(oldTemplate);
                this.classTemplates.Add(this.selectedClassTemplate);
            }

            var templateProcessor = new TemplateProcessor(Application.StartupPath);

            var templateDummyList = new List<DocumentClassTemplate>();
            templateDummyList.Add(this.selectedClassTemplate);
            templateProcessor.SaveTemplates(templateDummyList);

            MessageBox.Show("Template saved.");
        }


        private void butAddDataField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.AddDataField();
        }

        private void butDeleteDataField_Click(object sender, EventArgs e)
        {
            ucSingleTemplateEditor1.DeleteLastDataField();
        }

        private void frmTemplateEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ucTemplateSelector1.SelectionChanged -= UcTemplateSelector1_SelectionChanged;
            }
            catch (Exception ex)
            { }
        }
    }
}
