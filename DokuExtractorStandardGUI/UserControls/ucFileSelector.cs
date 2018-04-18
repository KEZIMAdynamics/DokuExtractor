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

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucFileSelector : UserControl
    {
        public delegate void SelectedFileChangedHandler(string newPath);
        /// <summary>
        /// Fired, when selected file changed (contains path of the now selected file)
        /// </summary>
        public event SelectedFileChangedHandler SelectedFileChanged;

        private BindingList<FileInfo> fileInfos = new BindingList<FileInfo>();

        public ucFileSelector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads files into the data grid's data source of the file selector
        /// </summary>
        public void LoadFiles(List<FileInfo> fileInfos)
        {
            this.fileInfos = new BindingList<FileInfo>(fileInfos);
            dataGridView1.DataSource = this.fileInfos;
        }

        /// <summary>
        /// Adds an additional list of FileInfos to the FileSelector
        /// </summary>
        public void AddFilesToQueue(List<FileInfo> additionalFileInfos)
        {
            foreach (var fileInfo in additionalFileInfos)
            {
                this.fileInfos.Add(fileInfo);
            }
        }

        /// <summary>
        /// Removes a file from the list of FileInfos of the FileSelctor
        /// </summary>
        public void RemoveFileFromQueue(string filePath)
        {
            var removableFileInfo = fileInfos.Where(x => x.FullName == filePath).FirstOrDefault();
            if (removableFileInfo != null)
                this.fileInfos.Remove(removableFileInfo);
        }

        /// <summary>
        /// Deletes a file physically and removes the file from the list of FileInfos of the FileSelector
        /// </summary>
        /// <param name="filePath"></param>
        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            RemoveFileFromQueue(filePath);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            if (selectedRows != null)
                foreach (DataGridViewRow row in selectedRows)
                {
                    var newPath = row.Cells["FullName"]?.Value?.ToString();
                    if (newPath != null)
                        FireSelectedFileChanged(newPath);
                    break;
                }
        }

        private void FireSelectedFileChanged(string newPath)
        {
            SelectedFileChanged?.Invoke(newPath);
        }
    }
}
