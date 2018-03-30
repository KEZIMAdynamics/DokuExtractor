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
    public partial class ucDataField : UserControl
    {
        public string NameText { get { return txtName.Text; }  }
        public int FieldTypeInt { get { return lbxFieldType.SelectedIndex; } }
        public string RegexText { get { return txtRegexExpression.Text; } }

        private DataFieldTemplate dataField { get; set; } = new DataFieldTemplate();

        public ucDataField()
        {
            InitializeComponent();
        }

        public ucDataField(DataFieldTemplate dataField)
        {
            InitializeComponent();
            this.dataField = dataField;
        }

        private void ucDataField_Load(object sender, EventArgs e)
        {
            txtName.Text = this.dataField.Name;

            lbxFieldType.SelectedIndex = (int)(this.dataField.FieldType);

            if (dataField.RegexExpressions != null)
                foreach (var item in dataField.RegexExpressions)
                {
                    txtRegexExpression.Text = txtRegexExpression.Text + item + Environment.NewLine;
                }
        }
    }
}
