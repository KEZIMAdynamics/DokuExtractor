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
using DokuExtractorCore;

namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    public partial class ucDataFieldEditor : UserControl
    {
        public delegate void RegexExpressionHelperHandler(Guid id, DataFieldTypes dataFieldType);
        /// <summary>
        /// Fired, when user wishes to start the regex expression helper
        /// </summary>
        public event RegexExpressionHelperHandler RegexExpressionHelper;

        private DocumentClassTemplate classTemplate = new DocumentClassTemplate();
        private DocumentGroupTemplate groupTemplate = new DocumentGroupTemplate();

        public ucDataFieldEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds a new data field (class template) to the user control
        /// </summary>
        public void AddDataFieldClassTemplate()
        {
            var newDataField = new ucDataFieldClassTemplate();
            newDataField.Tag = Guid.NewGuid();
            newDataField.RegexExpressionHelper += FireRegexExpressionHelper;
            newDataField.DataFieldEraser += DeleteDataFieldClassTemplate;
            flowLayoutPanel1.Controls.Add(newDataField);
        }

        /// <summary>
        /// Adds a new data field (group template) to the user control
        /// </summary>
        public void AddDataFieldGroupTemplate()
        {
            var newDataField = new ucDataFieldGroupTemplate();
            newDataField.Tag = Guid.NewGuid();
            newDataField.DataFieldEraser += DeleteDataFieldClassTemplate;
            flowLayoutPanel1.Controls.Add(newDataField);
        }

        /// <summary>
        /// Deletes a data field (class template) from the user control
        /// </summary>
        public void DeleteDataFieldClassTemplate(Guid toDeleteID)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                var dataFieldControl = control as ucDataFieldClassTemplate;
                if (dataFieldControl != null)
                {
                    try
                    {
                        var id = (Guid)(dataFieldControl.Tag);
                        if (id == toDeleteID)
                        {
                            flowLayoutPanel1.Controls.Remove(control);
                            return;
                        }
                    }
                    catch (Exception ex)
                    { }
                }
            }
        }

        /// <summary>
        /// Deletes a data field (group template) from the user control
        /// </summary>
        public void DeleteDataFieldGroupTemplate(Guid toDeleteID)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                var dataFieldControl = control as ucDataFieldGroupTemplate;
                if (dataFieldControl != null)
                {
                    try
                    {
                        var id = (Guid)(dataFieldControl.Tag);
                        if (id == toDeleteID)
                        {
                            flowLayoutPanel1.Controls.Remove(control);
                            return;
                        }
                    }
                    catch (Exception ex)
                    { }
                }
            }
        }

        /// <summary>
        /// Shows the data fields of a class template
        /// </summary>
        public void ShowDataFields(DocumentClassTemplate classTemplate)
        {
            this.classTemplate = classTemplate;

            var controlList = new List<Control>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                controlList.Add(control);
            }

            foreach (Control control in controlList)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }

            if (this.classTemplate != null && this.classTemplate.DataFields != null)
                foreach (var item in this.classTemplate.DataFields)
                {
                    var newDataField = new ucDataFieldClassTemplate(item);
                    newDataField.Tag = Guid.NewGuid();
                    newDataField.RegexExpressionHelper += FireRegexExpressionHelper;
                    newDataField.DataFieldEraser += DeleteDataFieldClassTemplate;
                    flowLayoutPanel1.Controls.Add(newDataField);
                }
        }

        /// <summary>
        /// Shows the data fields of a group template
        /// </summary>
        public void ShowDataFields(DocumentGroupTemplate groupTemplate)
        {
            this.groupTemplate = groupTemplate;

            var controlList = new List<Control>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                controlList.Add(control);
            }

            foreach (Control control in controlList)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }

            if (this.groupTemplate != null && this.groupTemplate.DataFields != null)
                foreach (var item in this.groupTemplate.DataFields)
                {
                    var newDataField = new ucDataFieldGroupTemplate(item);
                    newDataField.Tag = Guid.NewGuid();
                    newDataField.DataFieldEraser += DeleteDataFieldGroupTemplate;
                    flowLayoutPanel1.Controls.Add(newDataField);
                }
        }

        /// <summary>
        /// Returns the class template with changed data fields
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedDataFields()
        {
            var retVal = this.classTemplate;
            var newDataFields = new List<DataFieldClassTemplate>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                var newDataField = GetDataFieldClassTemplateFromUcDataField(control);
                newDataFields.Add(newDataField);
            }

            retVal.DataFields = newDataFields;

            return retVal;
        }

        /// <summary>
        /// Returns the group template with changed data fields
        /// </summary>
        public DocumentGroupTemplate GetDocumentGroupTemplateWithChangedDataFields()
        {
            var retVal = this.groupTemplate;
            var newDataFields = new List<DataFieldGroupTemplate>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                var newDataField = GetDataFieldGroupTemplateFromUcDataField(control);
                newDataFields.Add(newDataField);
            }

            retVal.DataFields = newDataFields;

            return retVal;
        }

        public void ActivateRegexExpressionHelper()
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                var dataFieldControl = control as ucDataFieldClassTemplate;
                if (dataFieldControl != null)
                {
                    dataFieldControl.ActivateRegexExpressionHelper();
                }
            }
        }

        public void ChangeOrAddRegexExpression(Guid regexHelperID, string regex, bool additionalRegex)
        {
            //TODO
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                var dataFieldControl = control as ucDataFieldClassTemplate;
                if (dataFieldControl != null)
                {
                    try
                    {
                        var id = (Guid)(dataFieldControl.Tag);
                        if (id == regexHelperID)
                        {
                            dataFieldControl.ChangeOrAddRegexExpression(regex, additionalRegex);
                            return;
                        }
                    }
                    catch (Exception ex)
                    { }
                }
            }
        }

        private DataFieldClassTemplate GetDataFieldClassTemplateFromUcDataField(Control ucDataFieldControl)
        {
            var retVal = new DataFieldClassTemplate();
            var ucDataField = ucDataFieldControl as ucDataFieldClassTemplate;

            if (ucDataField != null)
            {
                retVal.Name = ucDataField.NameText;
                retVal.FieldType = (DataFieldTypes)(ucDataField.FieldTypeInt);

                var splitArray = new string[1];
                splitArray[0] = Environment.NewLine;
                var regexArray = ucDataField.RegexText.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in regexArray)
                {
                    retVal.RegexExpressions.Add(item);
                }
            }
            return retVal;
        }

        private DataFieldGroupTemplate GetDataFieldGroupTemplateFromUcDataField(Control ucDataFieldGroupControl)
        {
            var retVal = new DataFieldGroupTemplate();
            var ucDataFieldGroupTemplate = ucDataFieldGroupControl as ucDataFieldGroupTemplate;

            if (ucDataFieldGroupTemplate != null)
            {
                retVal.Name = ucDataFieldGroupTemplate.NameText;
                retVal.FieldType = (DataFieldTypes)(ucDataFieldGroupTemplate.FieldTypeInt);

                var splitArray = new string[1];
                splitArray[0] = Environment.NewLine;
                var regexArray = ucDataFieldGroupTemplate.TextAnchorsText.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in regexArray)
                {
                    retVal.TextAnchors.Add(item);
                }
            }
            return retVal;
        }

        private void FireRegexExpressionHelper(Guid id, DataFieldTypes dataFieldType)
        {
            RegexExpressionHelper?.Invoke(id, dataFieldType);
        }
    }
}
