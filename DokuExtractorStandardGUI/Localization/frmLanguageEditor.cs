using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DokuExtractorStandardGUI.Localization
{
    public partial class frmLanguageEditor : Form
    {
        private string languageFolderPath = string.Empty;

        /// <summary>
        /// Editor to create, edit or delete translations of DokuExtractor content
        /// </summary>
        /// <param name="languageFolderPath">Folder path, where the language files are</param>
        public frmLanguageEditor(string languageFolderPath)
        {
            InitializeComponent();
            this.languageFolderPath = languageFolderPath;
        }

        private void frmLanguageEditor_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            Localize();

            var languageFilesList = Translation.LoadAllLanguageFiles(languageFolderPath);

            TransformLanguageFilesToRotatedArrayAndDisplayInDgv(languageFilesList);
            var headerColumn = true;
            foreach (DataGridViewColumn column in dgvRotatedLanguages.Columns)
            {
                if (headerColumn == true)
                {
                    column.ReadOnly = true;
                    headerColumn = false;
                }

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void Localize()
        {
            butAddLanguage.Text = Translation.LanguageStrings.ButAddLanguage;
            butDeleteLanguage.Text = Translation.LanguageStrings.ButDeleteLanguage;
            butSave.Text = Translation.LanguageStrings.ButSaveLanguage;
        }

        /// <summary>
        /// Transforms a list of language strings into a rotated array and displays that array within the data grid view (every language string now fills one column of the grid)
        /// </summary>
        /// <param name="languageFiles">List of languange strings</param>
        private void TransformLanguageFilesToRotatedArrayAndDisplayInDgv(List<LanguageStrings> languageFiles)
        {
            var propertyCount = typeof(LanguageStrings).GetProperties().Count();
            var rotatedLanguageFiles = new string[propertyCount, languageFiles.Count + 1];

            var languageFileCounter = 0;
            foreach (LanguageStrings languageFile in languageFiles)
            {
                var propertyCounter = 0;
                var properties = languageFile.GetType().GetProperties();
                foreach (var property in properties)
                {
                    if (languageFileCounter == 0)
                        rotatedLanguageFiles[propertyCounter, 0] = property.Name;

                    rotatedLanguageFiles[propertyCounter, languageFileCounter + 1] = property.GetValue(languageFile)?.ToString();
                    propertyCounter++;
                }
                languageFileCounter++;
            }

            for (int lfNumber = 0; lfNumber < languageFiles.Count + 1; lfNumber++)
            {
                var headerText = string.Empty;
                if (lfNumber > 0)
                    headerText = rotatedLanguageFiles[0, lfNumber] + " " + rotatedLanguageFiles[1, lfNumber];

                dgvRotatedLanguages.Columns.Add(lfNumber.ToString(), headerText);
            }

            for (int propNumber = 0; propNumber < propertyCount; propNumber++)
            {
                var row = new object[languageFiles.Count + 1];
                for (int lfNumber = 0; lfNumber < languageFiles.Count + 1; lfNumber++)
                {
                    row[lfNumber] = rotatedLanguageFiles[propNumber, lfNumber];
                }

                dgvRotatedLanguages.Rows.Add(row);
            }
        }

        /// <summary>
        /// Transforms the data grid view values into a list of language strings and returns that list of language strings
        /// </summary>
        private List<LanguageStrings> TransformDgvValuesToLanguageStrings()
        {
            var retVal = new List<LanguageStrings>();

            foreach (DataGridViewColumn column in dgvRotatedLanguages.Columns)
            {
                if (column.Index > 0)
                {
                    var languageFile = new LanguageStrings();
                    for (int rowIndex = 0; rowIndex < dgvRotatedLanguages.RowCount; rowIndex++)
                    {
                        var property = languageFile.GetType().GetProperties().Where(x => x.Name == dgvRotatedLanguages.Rows[rowIndex].Cells[0].Value?.ToString()).FirstOrDefault();
                        if (property.Name == "Culture")
                            property.SetValue(languageFile, new CultureInfo(dgvRotatedLanguages.Rows[rowIndex].Cells[column.Index].Value?.ToString()));
                        else
                            property.SetValue(languageFile, dgvRotatedLanguages.Rows[rowIndex].Cells[column.Index].Value?.ToString());
                    }
                    retVal.Add(languageFile);
                }
            }

            return retVal;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            var languageStrings = TransformDgvValuesToLanguageStrings();
            Translation.SaveAllLanguageFiles(languageStrings, this.languageFolderPath);
            this.Close();
        }

        private void butAddLanguage_Click(object sender, EventArgs e)
        {
            var random = new Guid();
            dgvRotatedLanguages.Columns.Add(random.ToString(), "new");
        }

        private void butDeleteLanguage_Click(object sender, EventArgs e)
        {
            var delete = MessageBox.Show(Translation.LanguageStrings.MsgAskDeleteLanguage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (delete == DialogResult.Yes)
            {
                var selectedCells = dgvRotatedLanguages.SelectedCells;
                if (selectedCells != null)
                    foreach (DataGridViewCell cell in selectedCells)
                    {
                        if (cell.ColumnIndex > 0)
                        {
                            var column = dgvRotatedLanguages.Columns[cell.ColumnIndex];
                            dgvRotatedLanguages.Columns.Remove(column);
                        }
                        break;
                    }
            }
        }
    }
}
