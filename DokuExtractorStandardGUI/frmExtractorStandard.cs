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

        private string selectedFilePath = string.Empty;
        private TemplateProcessor templateProcessor = new TemplateProcessor(Application.StartupPath);

        public frmExtractorStandard(string filePath)
        {
            InitializeComponent();
            ucFileSelector1.SelectedFileChanged += UcFileSelector1_SelectedFileChanged;
            ucViewer1.TextSelected += UcViewer1_TextSelected;
            ucResultAndEditor1.TabSwitched += UcResultAndEditor1_TabSwitched;

            var fileInfos = new List<FileInfo>();
            var files = Directory.GetFiles(filePath);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                fileInfos.Add(fileInfo);
            }

            ucFileSelector1.LoadFiles(fileInfos);
        }

        public frmExtractorStandard(List<FileInfo> fileInfos)
        {
            InitializeComponent();
            ucFileSelector1.SelectedFileChanged += UcFileSelector1_SelectedFileChanged;
            ucViewer1.TextSelected += UcViewer1_TextSelected;
            ucResultAndEditor1.TabSwitched += UcResultAndEditor1_TabSwitched;

            ucFileSelector1.LoadFiles(fileInfos);
        }

        private void frmExtractorStandard_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            UcResultAndEditor1_TabSwitched(false);
        }

        private void UcViewer1_TextSelected(string selectedText)
        {
            //TODO
            MessageBox.Show(selectedText);
        }

        private void UcFileSelector1_SelectedFileChanged(string newPath)
        {
            this.selectedFilePath = newPath;
            ucViewer1.LoadPdf(newPath);
        }


        private void UcResultAndEditor1_TabSwitched(bool switchedToSingleTemplateEditor)
        {
            if (switchedToSingleTemplateEditor)
            {
                butSaveTemplate.Enabled = true;
                butAddDataField.Enabled = true;
                butDeleteDataField.Enabled = true;
            }
            else
            {
                butSaveTemplate.Enabled = false;
                butAddDataField.Enabled = false;
                butDeleteDataField.Enabled = false;
            }
        }

        private void butTemplateEditor_Click(object sender, EventArgs e)
        {
            var templateProcessor = new TemplateProcessor(Application.StartupPath);
            var classTemplates = templateProcessor.LoadClassTemplatesFromDisk();

            var templateEditor = new frmTemplateEditor(classTemplates);
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

        private void butDeleteDataField_Click(object sender, EventArgs e)
        {
            ucResultAndEditor1.DeleteDataField();
        }
    }
}
