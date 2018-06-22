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
    public partial class frmValueEditor : Form
    {
        /// <summary>
        /// Fired, when butIndividualConditionalValue has been clicked
        /// </summary>
        public event EventHandler IndividualConditionalValueButtonClicked;

        public string RetVal { get; set; } = string.Empty;
        public string RetValDisplay { get; set; } = string.Empty;

        private bool isComboBoxForm = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private List<string> comboBoxOptions = new List<string>();

        public frmValueEditor()
        {
            InitializeComponent();
        }

        public frmValueEditor(string value, List<string> comboBoxOptions, List<string> comboBoxOptionsDisplay)
        {
            InitializeComponent();
            this.Text = Translation.LanguageStrings.ConditionValue;
            this.isComboBoxForm = true;
            this.txtRetVal.Visible = false;
            if (value != null)
            {
                this.comboBoxOptions = comboBoxOptions;
                cbxRetVal.Items.AddRange(comboBoxOptionsDisplay.ToArray());
                cbxRetVal.SelectedItem = value;
            }
        }

        public frmValueEditor(string value)
        {
            InitializeComponent();
            this.butIndividualConditionalValue.Visible = false;
            this.Text = Translation.LanguageStrings.ConditionValue;
            this.cbxRetVal.Visible = false;
            if (value != null)
            {
                txtRetVal.Text = value;
                txtRetVal.SelectAll();
            }
        }

        private void frmTextEdit_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Localize();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (isComboBoxForm)
            {
                if (string.IsNullOrWhiteSpace(cbxRetVal.SelectedItem?.ToString()))
                {
                    RetVal = string.Empty;
                    RetValDisplay = string.Empty;
                }
                else
                {
                    RetVal = comboBoxOptions[cbxRetVal.SelectedIndex];
                    RetValDisplay = cbxRetVal.SelectedItem.ToString();
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtRetVal.Text))
                    RetValDisplay = string.Empty;
                else
                    RetValDisplay = txtRetVal.Text;
            }

            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            RetVal = null;
            RetValDisplay = null;
            this.Close();
        }

        private void Localize()
        {
            butOk.Text = Translation.LanguageStrings.ButTextEditOk;
            butCancel.Text = Translation.LanguageStrings.ButTextEditCancel;
        }

        private void butIndividualConditionalValue_Click(object sender, EventArgs e)
        {
            IndividualConditionalValueButtonClicked?.Invoke(this, e);
        }
    }
}
