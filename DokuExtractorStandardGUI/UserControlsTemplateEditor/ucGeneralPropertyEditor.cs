using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokuExtractorCore.Model;

namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    public partial class ucGeneralPropertyEditor : UserControl
    {
        private DocumentClassTemplate classTemplate = new DocumentClassTemplate();
        private DocumentGroupTemplate groupTemplate = new DocumentGroupTemplate();

        public ucGeneralPropertyEditor()
        {
            InitializeComponent();
        }

        private void ucGeneralPropertyEditor_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
        }

        /// <summary>
        /// Shows the general properties of a class template
        /// </summary>
        public void ShowGeneralProperties(DocumentClassTemplate classTemplate)
        {
            this.classTemplate = classTemplate;

            if (this.classTemplate != null)
            {
                txtClassName.Text = this.classTemplate.TemplateClassName;
                txtGroupName.Text = this.classTemplate.TemplateGroupName;

                txtIban.Text = string.Empty;
                if (this.classTemplate.PreSelectionCondition.IBANs != null)
                    foreach (var item in this.classTemplate.PreSelectionCondition.IBANs)
                    {
                        txtIban.Text = txtIban.Text + item + Environment.NewLine;
                    }

                txtKeyWords.Text = string.Empty;
                if (this.classTemplate.KeyWords != null)
                    foreach (var item in this.classTemplate.KeyWords)
                    {
                        txtKeyWords.Text = txtKeyWords.Text + item + Environment.NewLine;
                    }
            }
        }

        /// <summary>
        /// Shows the general properties of a group template
        /// </summary>
        public void ShowGeneralProperties(DocumentGroupTemplate groupTemplate)
        {
            lblClassName.Visible = false;
            txtClassName.Visible = false;
            lblKeywords.Visible = false;
            txtKeyWords.Visible = false;

            this.groupTemplate = groupTemplate;

            if (this.groupTemplate != null)
            {
                txtGroupName.Text = this.groupTemplate.TemplateGroupName;

                txtIban.Text = string.Empty;
                if (this.groupTemplate.PreSelectionCondition.IBANs != null)
                    foreach (var item in this.groupTemplate.PreSelectionCondition.IBANs)
                    {
                        txtIban.Text = txtIban.Text + item + Environment.NewLine;
                    }
            }
        }

        /// <summary>
        /// Returns the class template with changed general properties
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedGeneralProperties()
        {
            var retVal = this.classTemplate;

            retVal.TemplateClassName = txtClassName.Text;
            retVal.TemplateGroupName = txtGroupName.Text;

            var splitArray = new string[1];
            splitArray[0] = Environment.NewLine;

            var regexArrayIbans = txtIban.Text.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);
            retVal.PreSelectionCondition.IBANs = new List<string>();
            foreach (var item in regexArrayIbans)
            {
                retVal.PreSelectionCondition.IBANs.Add(item);
            }

            var regexArrayKeyWords = txtKeyWords.Text.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);
            retVal.KeyWords = new List<string>();
            foreach (var item in regexArrayKeyWords)
            {
                retVal.KeyWords.Add(item);
            }

            return retVal;
        }

        /// <summary>
        /// Returns the group template with changed general properties
        /// </summary>
        public DocumentGroupTemplate GetDocumentGroupTemplateWithChangedGeneralProperties()
        {
            var retVal = this.groupTemplate;

            retVal.TemplateGroupName = txtGroupName.Text;

            var splitArray = new string[1];
            splitArray[0] = Environment.NewLine;

            var regexArrayIbans = txtIban.Text.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);
            retVal.PreSelectionCondition.IBANs = new List<string>();
            foreach (var item in regexArrayIbans)
            {
                retVal.PreSelectionCondition.IBANs.Add(item);
            }

            return retVal;
        }
    }
}
