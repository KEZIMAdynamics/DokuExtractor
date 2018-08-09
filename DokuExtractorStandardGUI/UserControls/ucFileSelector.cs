using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DokuExtractorStandardGUI.Localization;

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucFileSelector : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<FileInfo> FileInfos { get; set; } = new BindingList<FileInfo>();

        public delegate void SelectedFileChangedHandler(string newPath);
        /// <summary>
        /// Fired, when selected file has been changed (contains path of the now selected file)
        /// </summary>
        public event SelectedFileChangedHandler SelectedFileChanged;

        public ucFileSelector()
        {
            InitializeComponent();
        }


        private void ucFileSelector_Load(object sender, EventArgs e)
        {
            Localize();
        }

        /// <summary>
        /// Loads files into the data grid's data source of the file selector
        /// </summary>
        public void LoadFiles(List<FileInfo> fileInfos)
        {
            this.FileInfos = new BindingList<FileInfo>(fileInfos);
            dataGridView1.DataSource = this.FileInfos;
        }

        /// <summary>
        /// Adds an additional list of FileInfos to the FileSelector
        /// </summary>
        public void AddFilesToQueue(List<FileInfo> additionalFileInfos)
        {
            foreach (var fileInfo in additionalFileInfos)
            {
                this.FileInfos.Add(fileInfo);
            }
        }

        /// <summary>
        /// Removes a file from the list of FileInfos of the FileSelctor
        /// </summary>
        public void RemoveFileFromQueue(string filePath)
        {
            var removableFileInfo = FileInfos.Where(x => x.FullName == filePath).FirstOrDefault();
            if (removableFileInfo != null)
                this.FileInfos.Remove(removableFileInfo);
        }

        /// <summary>
        /// Deletes a file physically and removes the file from the list of FileInfos of the FileSelector
        /// </summary>
        /// <param name="filePath"></param>
        public async Task DeleteFile(string filePath)
        {
            //IMPORTANT: First Remove file from queue, then delete it physically
            RemoveFileFromQueue(filePath);

            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    var retryCounter = 0;
                    while (retryCounter < 10)
                    {
                        await Task.Delay(10000);
                        try
                        {
                            File.Delete(filePath);
                            break;
                        }
                        catch (Exception e)
                        {
                            retryCounter++;
                        }
                    }
                    if (retryCounter >= 10)
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Localize()
        {
            dataGridView1.Columns["col" + nameof(FileInfo.Name)].HeaderText = Translation.LanguageStrings.FileName;
            dataGridView1.Columns["col" + nameof(FileInfo.Length)].HeaderText = Translation.LanguageStrings.FileLength;
            dataGridView1.Columns["col" + nameof(FileInfo.LastWriteTime)].HeaderText = Translation.LanguageStrings.LastWriteTime;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            if (selectedRows != null)
            {
                if (selectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        var fileInfo = row.DataBoundItem as FileInfo;
                        if (fileInfo != null)
                            FireSelectedFileChanged(fileInfo.FullName);
                        break;
                    }
                }
                else
                    FireSelectedFileChanged(null);
            }
        }

        private void FireSelectedFileChanged(string newPath)
        {
            SelectedFileChanged?.Invoke(newPath);
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var selectedRows = dataGridView1.SelectedRows;
                if (selectedRows != null)
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        try
                        {
                            var fileInfo = row.DataBoundItem as FileInfo;
                            var dragDropDaten = new DataObject();
                            string[] pfad = new string[1];
                            pfad[0] = fileInfo.FullName;
                            dragDropDaten.SetData(DataFormats.FileDrop, pfad);
                            DoDragDrop(dragDropDaten, DragDropEffects.Copy);
                        }
                        catch (Exception ex)
                        { }

                        break;
                    }
            }
        }
    }
}
