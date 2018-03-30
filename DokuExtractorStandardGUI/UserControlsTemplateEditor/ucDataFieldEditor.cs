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
        private DocumentClassTemplate classTemplate = new DocumentClassTemplate();

        public ucDataFieldEditor()
        {
            InitializeComponent();
        }

        public void AddDataField()
        {
            flowLayoutPanel1.Controls.Add(new ucDataField());
        }

        public void DeleteLastDataField()
        {
            List<Control> listControls = new List<Control>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                listControls.Add(control);
            }

            var lastControl = listControls.LastOrDefault();
            if (lastControl != null)
                flowLayoutPanel1.Controls.Remove(lastControl);
        }

        public void ShowDataFields(DocumentClassTemplate classTemplate)
        {
            this.classTemplate = classTemplate;

            List<Control> listControls = new List<Control>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                listControls.Add(control);
            }

            foreach (Control control in listControls)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }

            if (this.classTemplate != null && this.classTemplate.DataFields != null)
                foreach (var item in this.classTemplate.DataFields)
                {
                    flowLayoutPanel1.Controls.Add(new ucDataField(item));
                }
        }

        public DocumentClassTemplate GetDocumentClassTemplateWithChangedDataFields()
        {
            var retVal = this.classTemplate;
            var newDataFields = new List<DataFieldTemplate>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                var newDataField = GetDataFieldTemplateFromUcDataField(control);
                newDataFields.Add(newDataField);
            }

            retVal.DataFields = newDataFields;

            return retVal;
        }

        private DataFieldTemplate GetDataFieldTemplateFromUcDataField(Control ucDataFieldControl)
        {
            var retVal = new DataFieldTemplate();
            var ucDataField = ucDataFieldControl as ucDataField;

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
    }
}
