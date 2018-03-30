﻿using DokuExtractorCore;
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
        public frmExtractorStandard()
        {
            InitializeComponent();
            ucFileSelector1.SelectedFileChanged += UcFileSelector1_SelectedFileChanged;
            ucViewer1.TextSelected += UcViewer1_TextSelected;

            var fileInfos = new List<FileInfo>();
            var filePath = Path.Combine(Application.StartupPath, "Files");
            var files = Directory.GetFiles(filePath);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                fileInfos.Add(fileInfo);
            }

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
            ucViewer1.LoadPdf(newPath);
        }

        private void butTemplateEditor_Click(object sender, EventArgs e)
        {
            var templateProcessor = new TemplateProcessor(Application.StartupPath);
            var classTemplates = templateProcessor.LoadClassTemplatesFromDisk();

            var templateEditor = new frmTemplateEditor(classTemplates);
            templateEditor.Show();
        }
    }
}
