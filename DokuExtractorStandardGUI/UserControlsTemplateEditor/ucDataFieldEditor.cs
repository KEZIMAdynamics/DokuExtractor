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

            var ucConditionalFieldTemplateList = new List<ucConditionalFieldClassTemplate>();
            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control.GetType() == typeof(ucConditionalFieldClassTemplate))
                    ucConditionalFieldTemplateList.Add(control as ucConditionalFieldClassTemplate);

            }

            foreach (var condControl in ucConditionalFieldTemplateList)
            {
                var id = (Guid)(condControl.Tag);
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control.GetType() == typeof(ucConditionalFieldClassTemplate))
                        if (id == (Guid)(((ucConditionalFieldClassTemplate)control).Tag))
                            flowLayoutPanel1.Controls.Remove(control);
                }
            }

            flowLayoutPanel1.Controls.Add(newDataField);

            foreach (var condControl in ucConditionalFieldTemplateList)
            {
                flowLayoutPanel1.Controls.Add(condControl);
            }
        }

        /// <summary>
        /// Adds a new conditional field (class template) to the user control
        /// </summary>
        public void AddConditionalField()
        {
            var newConditionalField = new ucConditionalFieldClassTemplate();
            newConditionalField.Tag = Guid.NewGuid();
            newConditionalField.ConditionalFieldEraser += DeleteConditionalField;
            flowLayoutPanel1.Controls.Add(newConditionalField);
        }

        /// <summary>
        /// Adds a new data field (group template) to the user control
        /// </summary>
        public void AddDataFieldGroupTemplate()
        {
            var newDataField = new ucDataFieldGroupTemplate();
            newDataField.Tag = Guid.NewGuid();
            newDataField.DataFieldEraser += DeleteDataFieldClassTemplate;

            var ucCalculationFieldTemplateList = new List<ucCalculationFieldGroupTemplate>();
            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control.GetType() == typeof(ucCalculationFieldGroupTemplate))
                    ucCalculationFieldTemplateList.Add(control as ucCalculationFieldGroupTemplate);
            }

            foreach (var calcControl in ucCalculationFieldTemplateList)
            {
                var id = (Guid)(calcControl.Tag);
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control.GetType() == typeof(ucCalculationFieldGroupTemplate))
                        if (id == (Guid)(((ucCalculationFieldGroupTemplate)control).Tag))
                            flowLayoutPanel1.Controls.Remove(control);
                }
            }

            flowLayoutPanel1.Controls.Add(newDataField);

            foreach (var calcControl in ucCalculationFieldTemplateList)
            {
                flowLayoutPanel1.Controls.Add(calcControl);
            }
        }

        /// <summary>
        /// Adds a new calculation field to the user control
        /// </summary>
        public void AddCalculationField()
        {
            var newCalculationField = new ucCalculationFieldGroupTemplate();
            newCalculationField.Tag = Guid.NewGuid();
            newCalculationField.CalculationFieldEraser += DeleteCalculationField;
            flowLayoutPanel1.Controls.Add(newCalculationField);
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
        /// Deletes a conditional field (class template) from the user control
        /// </summary>
        public void DeleteConditionalField(Guid toDeleteID)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                var conditionalFieldControl = control as ucConditionalFieldClassTemplate;
                if (conditionalFieldControl != null)
                {
                    try
                    {
                        var id = (Guid)(conditionalFieldControl.Tag);
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
        /// Deletes a calculation field from the user control
        /// </summary>
        /// <param name="toDeleteID"></param>
        public void DeleteCalculationField(Guid toDeleteID)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                var dataFieldControl = control as ucCalculationFieldGroupTemplate;
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
            {
                foreach (var item in this.classTemplate.DataFields)
                {
                    var newDataField = new ucDataFieldClassTemplate(item);
                    newDataField.Tag = Guid.NewGuid();
                    newDataField.RegexExpressionHelper += FireRegexExpressionHelper;
                    newDataField.DataFieldEraser += DeleteDataFieldClassTemplate;
                    flowLayoutPanel1.Controls.Add(newDataField);
                }

                foreach (var item in this.classTemplate.ConditionalFields)
                {
                    var newConditionalField = new ucConditionalFieldClassTemplate(item);
                    newConditionalField.Tag = Guid.NewGuid();
                    newConditionalField.ConditionalFieldEraser += DeleteConditionalField;
                    flowLayoutPanel1.Controls.Add(newConditionalField);
                }
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

            if (this.groupTemplate != null && this.groupTemplate.CalculationFields != null)
                foreach (var item in this.groupTemplate.CalculationFields)
                {
                    var newCalculationField = new ucCalculationFieldGroupTemplate(item);
                    newCalculationField.Tag = Guid.NewGuid();
                    newCalculationField.CalculationFieldEraser += DeleteCalculationField;
                    flowLayoutPanel1.Controls.Add(newCalculationField);
                }
        }

        /// <summary>
        /// Returns the class template with changed data fields and conditional fields
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedFields()
        {
            var retVal = this.classTemplate;
            var newDataFields = new List<DataFieldClassTemplate>();
            var newConditionalFields = new List<ConditionalFieldTemplate>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control.GetType() == typeof(ucDataFieldClassTemplate))
                {
                    var newDataField = GetDataFieldClassTemplateFromUcDataField(control);
                    newDataFields.Add(newDataField);
                }
                else if (control.GetType() == typeof(ucConditionalFieldClassTemplate))
                {
                    var newConditionalField = GetConditionalFieldTemplateFromUcConditianalField(control);
                    newConditionalFields.Add(newConditionalField);
                }
            }

            retVal.DataFields = newDataFields;
            retVal.ConditionalFields = newConditionalFields;

            return retVal;
        }

        /// <summary>
        /// Returns the group template with changed data fields and calculation fields
        /// </summary>
        public DocumentGroupTemplate GetDocumentGroupTemplateWithChangedFields()
        {
            var retVal = this.groupTemplate;
            var newDataFields = new List<DataFieldGroupTemplate>();
            var newCalculationFields = new List<CalculationFieldTemplate>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control.GetType() == typeof(ucDataFieldGroupTemplate))
                {
                    var newDataField = GetDataFieldGroupTemplateFromUcDataField(control);
                    newDataFields.Add(newDataField);
                }
                else if (control.GetType() == typeof(ucCalculationFieldGroupTemplate))
                {
                    var newCalculaionField = GetCalculationFieldTemplateFromUcCalculationField(control);
                    newCalculationFields.Add(newCalculaionField);
                }
            }

            retVal.DataFields = newDataFields;
            retVal.CalculationFields = newCalculationFields;

            return retVal;
        }

        /// <summary>
        /// Activates the regex expression helper for defining regex expressions
        /// </summary>
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

        private ConditionalFieldTemplate GetConditionalFieldTemplateFromUcConditianalField(Control ucConditionalFieldControl)
        {
            var retVal = new ConditionalFieldTemplate();
            var ucConditionalField = ucConditionalFieldControl as ucConditionalFieldClassTemplate;

            if (ucConditionalField != null)
            {
                retVal.Name = ucConditionalField.NameText;
                retVal.ConditionValues = ucConditionalField.ConditionsList;
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

        private CalculationFieldTemplate GetCalculationFieldTemplateFromUcCalculationField(Control ucCalculationFieldControl)
        {
            var retVal = new CalculationFieldTemplate();
            var ucCalculationFieldGroupTemplate = ucCalculationFieldControl as ucCalculationFieldGroupTemplate;

            if (ucCalculationFieldGroupTemplate != null)
            {
                retVal.Name = ucCalculationFieldGroupTemplate.NameText;
                retVal.FieldType = (DataFieldTypes)(ucCalculationFieldGroupTemplate.FieldTypeInt);
                retVal.CalculationExpression = ucCalculationFieldGroupTemplate.CalculationExpressionText;
                retVal.CalculationExpressionPrecision = ucCalculationFieldGroupTemplate.CalculationPrecisionInt;
                retVal.ValidationExpressionPrecision = ucCalculationFieldGroupTemplate.ValidationPrecisionInt;

                var splitArray = new string[1];
                splitArray[0] = Environment.NewLine;
                var valexArray = ucCalculationFieldGroupTemplate.ValidationExpressionText.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in valexArray)
                {
                    retVal.ValidationExpressions.Add(item);
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
