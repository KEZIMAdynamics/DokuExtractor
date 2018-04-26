using DokuExtractorCore;
using DokuExtractorCore.Model;
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
    public partial class frmTemplateEditor : Form
    {
        private List<DocumentClassTemplate> classTemplates = new List<DocumentClassTemplate>();
        private List<DocumentGroupTemplate> groupTemplates = new List<DocumentGroupTemplate>();

        public frmTemplateEditor(List<DocumentClassTemplate> classTemplates, List<DocumentGroupTemplate> groupTemplates)
        {
            InitializeComponent();

            this.classTemplates = classTemplates;
            this.groupTemplates = groupTemplates;

            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmTemplateEditor_Load(object sender, EventArgs e)
        {
            ucClassTemplateEditor1.InitializeClassTemplateEditor(classTemplates);
            ucGroupTemplateEditor1.InitializeGroupTemplateEditor(groupTemplates);
        }
    }
}
