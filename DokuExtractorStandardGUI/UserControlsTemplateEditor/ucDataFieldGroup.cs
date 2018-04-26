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
    public partial class ucDataFieldGroup : UserControl
    {
        public delegate void DataFieldEraserHandler(Guid id);
        /// <summary>
        /// Fired, when butDeleteDataField was clicked
        /// </summary>
        public event DataFieldEraserHandler DataFieldEraser;
        
        public string NameText { get { return txtName.Text; } }
        public int FieldTypeInt { get { return lbxFieldType.SelectedIndex; } }
        public string TextAnchorsText { get { return txtTextAnchors.Text; } }

        private DataFieldGroupTemplate dataFieldGroup { get; set; } = new DataFieldGroupTemplate();

        public ucDataFieldGroup()
        {
            InitializeComponent();
        }

        public ucDataFieldGroup(DataFieldGroupTemplate dataFieldGroup)
        {
            InitializeComponent();
            this.dataFieldGroup = dataFieldGroup;
        }

        private void ucDataFieldGroup_Load(object sender, EventArgs e)
        {
            txtName.Text = this.dataFieldGroup.Name;

            lbxFieldType.SelectedIndex = (int)(this.dataFieldGroup.FieldType);

            if (dataFieldGroup.TextAnchors != null)
                foreach (var item in dataFieldGroup.TextAnchors)
                {
                    txtTextAnchors.Text = txtTextAnchors.Text + item + Environment.NewLine;
                }
        }

        private void butDeleteDataField_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (Guid)(this.Tag);
                FireDataFieldEraser(id);
            }
            catch (Exception ex)
            { }
        }

        private void FireDataFieldEraser(Guid id)
        {
            DataFieldEraser?.Invoke(id);
        }
    }
}
