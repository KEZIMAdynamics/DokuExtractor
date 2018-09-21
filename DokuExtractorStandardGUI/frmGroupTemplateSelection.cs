using DokuExtractorCore.Model;
using DokuExtractorStandardGUI.Localization;
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
    public partial class frmGroupTemplateSelection : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingList<DocumentGroupTemplate> GroupTemplates { get; set; }

        public DocumentGroupTemplate SelectedGrouptTemplate { get; set; }

        public frmGroupTemplateSelection()
        {
            InitializeComponent();
        }

        public frmGroupTemplateSelection(List<DocumentGroupTemplate> groupTemplates)
        {
            InitializeComponent();
            this.CenterToScreen();
            Localize();
            this.GroupTemplates = new BindingList<DocumentGroupTemplate>(groupTemplates);
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            if (selectedRows != null)
            {
                if (selectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        this.SelectedGrouptTemplate = row.DataBoundItem as DocumentGroupTemplate;
                        break;
                    }
                }
            }

            this.Close();
        }

        private void frmGroupTemplateSelection_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.GroupTemplates;
        }

        private void Localize()
        {
            dataGridView1.Columns["col" + nameof(DocumentGroupTemplate.TemplateGroupName)].HeaderText = Translation.LanguageStrings.TemplateGroupName;
        }
    }
}
