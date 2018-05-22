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
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public BindingList<LanguageStrings> LanguageFiles { get; set; } = new BindingList<LanguageStrings>();
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[,] RotatedLanguageFiles { get; set; } = new string[0, 0];

        private string languageFolderPath = string.Empty;

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
            //this.LanguageFiles = new BindingList<LanguageStrings>(languageFilesList);
            //dataGridView1.DataSource = this.LanguageFiles;
            //dataGridView1.AutoGenerateColumns = true;

            //foreach (DataGridViewColumn column in dataGridView1.Columns)
            //{
            //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //}

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

        private void TransformLanguageFilesToRotatedArrayAndDisplayInDgv(List<LanguageStrings> languageFiles)
        {
            var propertyCount = typeof(LanguageStrings).GetProperties().Count();
            RotatedLanguageFiles = new string[propertyCount, languageFiles.Count + 1];

            var languageFileCounter = 0;
            foreach (LanguageStrings languageFile in languageFiles)
            {
                var propertyCounter = 0;
                var properties = languageFile.GetType().GetProperties();
                foreach (var property in properties)
                {
                    if (languageFileCounter == 0)
                        RotatedLanguageFiles[propertyCounter, 0] = property.Name;

                    RotatedLanguageFiles[propertyCounter, languageFileCounter + 1] = property.GetValue(languageFile)?.ToString();
                    propertyCounter++;
                }
                languageFileCounter++;
            }

            for (int lfNumber = 0; lfNumber < languageFiles.Count + 1; lfNumber++)
            {
                var headerText = string.Empty;
                if (lfNumber > 0)
                    headerText = RotatedLanguageFiles[0, lfNumber] + " " + RotatedLanguageFiles[1, lfNumber];

                dgvRotatedLanguages.Columns.Add(lfNumber.ToString(), headerText);
            }

            for (int propNumber = 0; propNumber < propertyCount; propNumber++)
            {
                var row = new object[languageFiles.Count + 1];
                for (int lfNumber = 0; lfNumber < languageFiles.Count + 1; lfNumber++)
                {
                    row[lfNumber] = RotatedLanguageFiles[propNumber, lfNumber];
                }

                dgvRotatedLanguages.Rows.Add(row);
            }
        }

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
            //Translation.SaveAllLanguageFiles(this.LanguageFiles.ToList(), this.languageFolderPath);

            var languageStrings = TransformDgvValuesToLanguageStrings();
            Translation.SaveAllLanguageFiles(languageStrings, this.languageFolderPath);
            this.Close();
        }

        private void butAddLanguage_Click(object sender, EventArgs e)
        {
            //this.LanguageFiles.AddNew();

            var random = new Guid();
            dgvRotatedLanguages.Columns.Add(random.ToString(), "new");
        }

        private void butDeleteLanguage_Click(object sender, EventArgs e)
        {
            //var selectedRows = dataGridView1.SelectedRows;
            //if (selectedRows != null)
            //    foreach (DataGridViewRow row in selectedRows)
            //    {
            //        var language = row.DataBoundItem as LanguageStrings;
            //        this.LanguageFiles.Remove(language);
            //        break;
            //    }

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
