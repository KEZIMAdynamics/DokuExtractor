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
using DokuExtractorStandardGUI.Logic;

namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    public partial class ucDataFieldEditor : UserControl
    {
        public delegate void RegexExpressionHelperHandler(Guid id, DataFieldType dataFieldType);
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
            var newDataField = (ucDataFieldClassTemplate)Activator.CreateInstance(UserControlSelector.DataFieldClassTemplateUserControl);
            newDataField.Tag = Guid.NewGuid();
            newDataField.RegexExpressionHelper += FireRegexExpressionHelper;
            newDataField.DataFieldEraser += DeleteDataFieldClassTemplate;

            var ucConditionalFieldTemplateList = new List<ucConditionalFieldTemplate>();
            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control.GetType() == UserControlSelector.ConditionalFieldTemplateUserControl)
                    ucConditionalFieldTemplateList.Add(control as ucConditionalFieldTemplate);

            }

            foreach (var condControl in ucConditionalFieldTemplateList)
            {
                var id = (Guid)(condControl.Tag);
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control.GetType() == UserControlSelector.ConditionalFieldTemplateUserControl)
                        if (id == (Guid)(((ucConditionalFieldTemplate)control).Tag))
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
        /// Adds a new conditional field to the user control
        /// </summary>
        public void AddConditionalField(bool isGroupTemplate)
        {
            var newConditionalField = (ucConditionalFieldTemplate)Activator.CreateInstance(UserControlSelector.ConditionalFieldTemplateUserControl);

            newConditionalField.Tag = Guid.NewGuid();
            newConditionalField.ConditionalFieldEraser += DeleteConditionalField;
            flowLayoutPanel1.Controls.Add(newConditionalField);

            if (isGroupTemplate == false)
                newConditionalField.HideGroupTemplateSpecificComponents();
        }

        /// <summary>
        /// Adds a new data field (group template) to the user control
        /// </summary>
        public void AddDataFieldGroupTemplate()
        {
            var newDataField = (ucDataFieldGroupTemplate)Activator.CreateInstance(typeof(ucDataFieldGroupTemplate));
            newDataField.Tag = Guid.NewGuid();
            newDataField.DataFieldEraser += DeleteDataFieldClassTemplate;

            var ucConditionalFieldTemplateList = new List<ucConditionalFieldTemplate>();
            var ucCalculationFieldTemplateList = new List<ucCalculationFieldGroupTemplate>();
            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control.GetType() == UserControlSelector.ConditionalFieldTemplateUserControl)
                    ucConditionalFieldTemplateList.Add(control as ucConditionalFieldTemplate);

                if (control.GetType() == UserControlSelector.CalculationFieldGroupTemplateUserControl)
                    ucCalculationFieldTemplateList.Add(control as ucCalculationFieldGroupTemplate);
            }

            foreach (var condControl in ucConditionalFieldTemplateList)
            {
                var id = (Guid)(condControl.Tag);
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control.GetType() == UserControlSelector.ConditionalFieldTemplateUserControl)
                        if (id == (Guid)(((ucConditionalFieldTemplate)control).Tag))
                            flowLayoutPanel1.Controls.Remove(control);
                }
            }

            foreach (var calcControl in ucCalculationFieldTemplateList)
            {
                var id = (Guid)(calcControl.Tag);
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control.GetType() == UserControlSelector.CalculationFieldGroupTemplateUserControl)
                        if (id == (Guid)(((ucCalculationFieldGroupTemplate)control).Tag))
                            flowLayoutPanel1.Controls.Remove(control);
                }
            }

            flowLayoutPanel1.Controls.Add(newDataField);

            foreach (var condControl in ucConditionalFieldTemplateList)
            {
                flowLayoutPanel1.Controls.Add(condControl);
            }

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
            var newCalculationField = (ucCalculationFieldGroupTemplate)(Activator.CreateInstance(UserControlSelector.CalculationFieldGroupTemplateUserControl));
            newCalculationField.Tag = Guid.NewGuid();
            newCalculationField.CalculationFieldEraser += DeleteCalculationField;

            var ucConditionalFieldTemplateList = new List<ucConditionalFieldTemplate>();
            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control.GetType() == UserControlSelector.ConditionalFieldTemplateUserControl)
                    ucConditionalFieldTemplateList.Add(control as ucConditionalFieldTemplate);
            }

            foreach (var condControl in ucConditionalFieldTemplateList)
            {
                var id = (Guid)(condControl.Tag);
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control.GetType() == UserControlSelector.ConditionalFieldTemplateUserControl)
                        if (id == (Guid)(((ucConditionalFieldTemplate)control).Tag))
                            flowLayoutPanel1.Controls.Remove(control);
                }
            }

            flowLayoutPanel1.Controls.Add(newCalculationField);

            foreach (var condControl in ucConditionalFieldTemplateList)
            {
                flowLayoutPanel1.Controls.Add(condControl);
            }
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
                var conditionalFieldControl = control as ucConditionalFieldTemplate;
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
                foreach (var item in this.classTemplate.DataFields)
                {
                    var newDataField = (ucDataFieldClassTemplate)Activator.CreateInstance(UserControlSelector.DataFieldClassTemplateUserControl, item);
                    newDataField.Tag = Guid.NewGuid();
                    newDataField.RegexExpressionHelper += FireRegexExpressionHelper;
                    newDataField.DataFieldEraser += DeleteDataFieldClassTemplate;
                    flowLayoutPanel1.Controls.Add(newDataField);
                }

            if (this.classTemplate != null && this.classTemplate.ConditionalFields != null)
                foreach (var item in this.classTemplate.ConditionalFields)
                {
                    var newConditionalField = (ucConditionalFieldTemplate)Activator.CreateInstance(UserControlSelector.ConditionalFieldTemplateUserControl, item);
                    newConditionalField.HideGroupTemplateSpecificComponents();
                    newConditionalField.Tag = Guid.NewGuid();
                    newConditionalField.ConditionalFieldEraser += DeleteConditionalField;
                    flowLayoutPanel1.Controls.Add(newConditionalField);
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
                    var newDataField = (ucDataFieldGroupTemplate)Activator.CreateInstance(UserControlSelector.DataFieldGroupTemplateUserControl, item);
                    newDataField.Tag = Guid.NewGuid();
                    newDataField.DataFieldEraser += DeleteDataFieldGroupTemplate;
                    flowLayoutPanel1.Controls.Add(newDataField);
                }

            if (this.groupTemplate != null && this.groupTemplate.CalculationFields != null)
                foreach (var item in this.groupTemplate.CalculationFields)
                {
                    var newCalculationField = (ucCalculationFieldGroupTemplate)Activator.CreateInstance(UserControlSelector.CalculationFieldGroupTemplateUserControl, item);
                    newCalculationField.Tag = Guid.NewGuid();
                    newCalculationField.CalculationFieldEraser += DeleteCalculationField;
                    flowLayoutPanel1.Controls.Add(newCalculationField);
                }

            if (this.groupTemplate != null && this.groupTemplate.ConditionalFields != null)
                foreach (var item in this.groupTemplate.ConditionalFields)
                {
                    var newConditionalField = (ucConditionalFieldTemplate)Activator.CreateInstance(UserControlSelector.ConditionalFieldTemplateUserControl, item);
                    newConditionalField.Tag = Guid.NewGuid();
                    newConditionalField.ConditionalFieldEraser += DeleteConditionalField;
                    flowLayoutPanel1.Controls.Add(newConditionalField);
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
                if (control.GetType() == UserControlSelector.DataFieldClassTemplateUserControl)
                {
                    var newDataField = GetDataFieldClassTemplateFromUcDataField(control);
                    newDataFields.Add(newDataField);
                }
                else if (control.GetType() == UserControlSelector.ConditionalFieldTemplateUserControl)
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
            var newConditionalFields = new List<ConditionalFieldTemplate>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control.GetType() == UserControlSelector.DataFieldGroupTemplateUserControl)
                {
                    var newDataField = GetDataFieldGroupTemplateFromUcDataField(control);
                    newDataFields.Add(newDataField);
                }
                else if (control.GetType() == UserControlSelector.CalculationFieldGroupTemplateUserControl)
                {
                    var newCalculationField = GetCalculationFieldTemplateFromUcCalculationField(control);
                    newCalculationFields.Add(newCalculationField);
                }
                else if (control.GetType() == UserControlSelector.ConditionalFieldTemplateUserControl)
                {
                    var newConditionalField = GetConditionalFieldTemplateFromUcConditianalField(control);
                    newConditionalFields.Add(newConditionalField);
                }
            }

            retVal.DataFields = newDataFields;
            retVal.CalculationFields = newCalculationFields;
            retVal.ConditionalFields = newConditionalFields;

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

        /// <summary>
        /// Chagnes a regex expression or adds an addtional regex string to the regex expression list
        /// </summary>
        /// <param name="regexHelperID">ID of the regex expression, which shall be changed</param>
        /// <param name="regex">Regex expression</param>
        /// <param name="additionalRegex">Shall the regex expression be added to the regex expression list or shall it overwrite the list completely?</param>
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
            var ucDataFieldClassTemplate = ucDataFieldControl as ucDataFieldClassTemplate;

            if (ucDataFieldClassTemplate != null)
            {
                retVal.Name = ucDataFieldClassTemplate.NameText;
                retVal.FieldType = (DataFieldType)(ucDataFieldClassTemplate.FieldTypeInt);

                var splitArray = new string[1];
                splitArray[0] = Environment.NewLine;
                var regexArray = ucDataFieldClassTemplate.RegexText.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);

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
            var ucConditionalField = ucConditionalFieldControl as ucConditionalFieldTemplate;

            if (ucConditionalField != null)
            {
                retVal.Name = ucConditionalField.NameText;
                retVal.ConditionalFieldType = (ConditionalFieldType)(ucConditionalField.ConditionalFieldTypeInt);
                retVal.ConditionValues = ucConditionalField.ConditionsList;
                retVal.OnlyStoreInGroupTemplate = ucConditionalField.OnlyStoreInGroupTemplateBool;
                retVal.IgnoreCaseForSimpleDocumentTextRegex = ucConditionalField.IgnoreCaseForSimpleDocumentTextRegexBool;
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
                retVal.FieldType = (DataFieldType)(ucDataFieldGroupTemplate.FieldTypeInt);

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
                retVal.FieldType = (DataFieldType)(ucCalculationFieldGroupTemplate.FieldTypeInt);
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

        private void FireRegexExpressionHelper(Guid id, DataFieldType dataFieldType)
        {
            RegexExpressionHelper?.Invoke(id, dataFieldType);
        }
    }
}
