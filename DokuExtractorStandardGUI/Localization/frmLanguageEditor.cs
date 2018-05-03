using Newtonsoft.Json;
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

namespace DokuExtractorStandardGUI.Localization
{
    public partial class frmLanguageEditor : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<LanguageStrings> LanguageFiles { get; set; } = new BindingList<LanguageStrings>();

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
            this.LanguageFiles = new BindingList<LanguageStrings>(languageFilesList);
            dataGridView1.DataSource = this.LanguageFiles;
            dataGridView1.AutoGenerateColumns = true;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void Localize()
        {
            butAddLanguage.Text = Translation.LanguageStrings.ButAddLanguage;
            butDeleteLanguage.Text = Translation.LanguageStrings.ButDeleteLanguage;
            butSave.Text = Translation.LanguageStrings.ButSaveLanguage;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            Translation.SaveAllLanguageFiles(this.LanguageFiles.ToList(), this.languageFolderPath);

            this.Close();
        }

        private void butAddLanguage_Click(object sender, EventArgs e)
        {
            this.LanguageFiles.AddNew();
        }

        private void butDeleteLanguage_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            if (selectedRows != null)
                foreach (DataGridViewRow row in selectedRows)
                {
                    var language = row.DataBoundItem as LanguageStrings;
                    this.LanguageFiles.Remove(language);
                    break;
                }
        }
    }
}
