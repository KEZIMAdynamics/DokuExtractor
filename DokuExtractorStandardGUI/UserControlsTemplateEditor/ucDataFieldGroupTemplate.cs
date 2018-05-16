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
using DokuExtractorStandardGUI.Localization;

namespace DokuExtractorStandardGUI.UserControlsTemplateEditor
{
    public partial class ucDataFieldGroupTemplate : UserControl
    {
        public delegate void DataFieldEraserHandler(Guid id);
        /// <summary>
        /// Fired, when butDeleteDataField was clicked
        /// </summary>
        public event DataFieldEraserHandler DataFieldEraser;

        public string NameText { get { return txtName.Text; } }
        public int FieldTypeInt { get { return lbxFieldType.SelectedIndex; } }
        public string TextAnchorsText { get { return txtTextAnchors.Text; } }

        private DataFieldGroupTemplate dataFieldGroupTemplate { get; set; } = new DataFieldGroupTemplate();

        public ucDataFieldGroupTemplate()
        {
            InitializeComponent();
        }

        public ucDataFieldGroupTemplate(DataFieldGroupTemplate dataFieldGroupTemplate)
        {
            InitializeComponent();
            this.dataFieldGroupTemplate = dataFieldGroupTemplate;
        }

        private void ucDataFieldGroup_Load(object sender, EventArgs e)
        {
            txtName.Text = this.dataFieldGroupTemplate.Name;

            Localize();

            lbxFieldType.SelectedIndex = (int)(this.dataFieldGroupTemplate.FieldType);

            if (dataFieldGroupTemplate.TextAnchors != null)
                foreach (var item in dataFieldGroupTemplate.TextAnchors)
                {
                    txtTextAnchors.Text = txtTextAnchors.Text + item + Environment.NewLine;
                }
        }

        private void Localize()
        {
            lblName.Text = Translation.LanguageStrings.DataFieldName;
            lblFieldType.Text = Translation.LanguageStrings.DataFieldType;
            lblTextAnchors.Text = Translation.LanguageStrings.DataFieldGroupTemplateTextAnchors;
            butDeleteDataField.Text = Translation.LanguageStrings.ButDeleteDataField;
            lbxFieldType.Items[(int)(DataFieldTypes.Text)] = Translation.LanguageStrings.FieldTypeText;
            lbxFieldType.Items[(int)(DataFieldTypes.Date)] = Translation.LanguageStrings.FieldTypeDate;
            lbxFieldType.Items[(int)(DataFieldTypes.Currency)] = Translation.LanguageStrings.FieldTypeCurrency;
            lbxFieldType.Items[(int)(DataFieldTypes.IBAN)] = Translation.LanguageStrings.FieldTypeIban;
            lbxFieldType.Items[(int)(DataFieldTypes.AnchorLessIBAN)] = Translation.LanguageStrings.FieldTypeAnchorlessIban;
            lbxFieldType.Items[(int)(DataFieldTypes.VatId)] = Translation.LanguageStrings.FieldTypeVatId;
            lbxFieldType.Items[(int)(DataFieldTypes.Term)] = Translation.LanguageStrings.FieldTypeTerm;
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
