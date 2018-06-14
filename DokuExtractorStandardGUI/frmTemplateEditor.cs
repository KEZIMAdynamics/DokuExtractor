using DokuExtractorCore;
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
    public partial class frmTemplateEditor : Form
    {
        public delegate void GroupTemplateSavedInGroupTemplateEditorHandler(DocumentGroupTemplate savedGroupTemplate);
        /// <summary>
        /// Fired, when user has pressed save button in group template editor
        /// </summary>
        public event GroupTemplateSavedInGroupTemplateEditorHandler GroupTemplateSavedInGroupTemplateEditor;

        public delegate void ClassTemplateSavedInClassTemplateEditorHandler(DocumentClassTemplate savedClassTemplate);
        /// <summary>
        /// Fired, when user has pressed save button in class template editor
        /// </summary>
        public event ClassTemplateSavedInClassTemplateEditorHandler ClassTemplateSavedInClassTemplateEditor;

        private List<DocumentClassTemplate> classTemplates = new List<DocumentClassTemplate>();
        private List<DocumentGroupTemplate> groupTemplates = new List<DocumentGroupTemplate>();

        /// <summary>
        /// Editor to edit group templates and class templates
        /// </summary>
        public frmTemplateEditor(List<DocumentClassTemplate> classTemplates, List<DocumentGroupTemplate> groupTemplates)
        {
            InitializeComponent();

            this.classTemplates = classTemplates;
            this.groupTemplates = groupTemplates;

            ucGroupTemplateEditor1.GroupTemplateSavedInGroupTemplateEditor += UcGroupTemplateEditor1_GroupTemplateSavedInGroupTemplateEditor;
            ucClassTemplateEditor1.ClassTemplateSavedInClassTemplateEditor += UcClassTemplateEditor1_ClassTemplateSavedInClassTemplateEditor;

            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmTemplateEditor_Load(object sender, EventArgs e)
        {
            Localize();
            ucClassTemplateEditor1.InitializeClassTemplateEditor(classTemplates);
            ucGroupTemplateEditor1.InitializeGroupTemplateEditor(groupTemplates);
        }

        private void Localize()
        {
            tabClassTemplateEditor.Text = Translation.LanguageStrings.ClassTemplateEditor;
            tabGroupTemplateEditor.Text = Translation.LanguageStrings.GroupTemplateEditor;
        }

        private void UcClassTemplateEditor1_ClassTemplateSavedInClassTemplateEditor(DocumentClassTemplate savedClassTemplate)
        {
            ClassTemplateSavedInClassTemplateEditor?.Invoke(savedClassTemplate);
        }

        private void UcGroupTemplateEditor1_GroupTemplateSavedInGroupTemplateEditor(DocumentGroupTemplate savedGroupTemplate)
        {
            GroupTemplateSavedInGroupTemplateEditor?.Invoke(savedGroupTemplate);
        }

        private void frmTemplateEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ucGroupTemplateEditor1.GroupTemplateSavedInGroupTemplateEditor -= UcGroupTemplateEditor1_GroupTemplateSavedInGroupTemplateEditor;
                ucClassTemplateEditor1.ClassTemplateSavedInClassTemplateEditor -= UcClassTemplateEditor1_ClassTemplateSavedInClassTemplateEditor;
            }
            catch (Exception ex)
            { }
        }
    }
}
