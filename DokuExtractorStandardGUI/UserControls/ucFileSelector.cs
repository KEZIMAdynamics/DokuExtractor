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

        public ucFileSelector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads files into the data grid's data source of the file selector
        /// </summary>
        /// <param name="fileInfos"></param>
        public void LoadFiles(List<FileInfo> fileInfos)
        {
            dataGridView1.DataSource = fileInfos;
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
