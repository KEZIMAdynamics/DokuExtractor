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
        private string selectedFilePath = string.Empty;
        private TemplateProcessor templateProcessor = new TemplateProcessor(Application.StartupPath);

        public frmExtractorStandard(string filePath)
        {
            InitializeComponent();
            ucFileSelector1.SelectedFileChanged += UcFileSelector1_SelectedFileChanged;
            ucViewer1.TextSelected += UcViewer1_TextSelected;

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

            ucFileSelector1.LoadFiles(fileInfos);
        }

        private void frmExtractorStandard_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
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

        private void butTemplateEditor_Click(object sender, EventArgs e)
        {
            var templateProcessor = new TemplateProcessor(Application.StartupPath);
            var classTemplates = templateProcessor.LoadClassTemplatesFromDisk();

            var templateEditor = new frmTemplateEditor(classTemplates);
            templateEditor.Show();
        }

        private async void butGo_Click(object sender, EventArgs e)
        {
            var classTemplates = templateProcessor.LoadClassTemplatesFromDisk();
            var groupTemplates = templateProcessor.LoadGroupTemplatesFromDisk();

            var loader = new PdfTextLoader();
            var inputString = await loader.GetTextFromPdf(selectedFilePath, false);

            var matchingTemplateResult = templateProcessor.MatchTemplates(classTemplates, inputString);
            var template = matchingTemplateResult.Template;
            //if (matchingTemplateResult.IsMatchSuccessfull == false)
            //    template = processor.AutoCreateTemplate("NeuesTemplate", inputString);

            if (matchingTemplateResult.IsMatchSuccessfull)
            {
                MessageBox.Show("Yay, template found: " + template.TemplateClassName);
                var result = templateProcessor.ExtractData(template, groupTemplates, inputString);
                //tbExtractedData.Text = json;
                ucExtractedData1.ShowExtractedData(result);
            }
            else
            {
                template = templateProcessor.AutoCreateTemplate("NeuesTemplate", inputString);
                var json = templateProcessor.ExtractDataAsJson(template, groupTemplates, inputString);
                //tbExtractedData.Text = json;

                //TODO: Show an UC on right side to edit new template

                //var editor = new frmTemplateEditor(classTemplates);
                //editor.Text = "New template";
                //editor.Show();
            }
        }

        private void frmExtractorStandard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ucFileSelector1.SelectedFileChanged -= UcFileSelector1_SelectedFileChanged;
                ucViewer1.TextSelected -= UcViewer1_TextSelected;
            }
            catch(Exception ex)
            { }
        }
    }
}
