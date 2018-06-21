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
        public string RetVal { get; set; } = string.Empty;
        private bool isComboBoxForm = false;

        public frmValueEditor()
        {
            InitializeComponent();
        }

        public frmValueEditor(string value, List<string> comboBoxOptions)
        {
            InitializeComponent();
            this.Text = Translation.LanguageStrings.ConditionValue;
            this.isComboBoxForm = true;
            this.txtRetVal.Visible = false;
            if (string.IsNullOrEmpty(value) == false)
            {
                cbxRetVal.Items.AddRange(comboBoxOptions.ToArray());
                cbxRetVal.SelectedItem = value;
            }
        }

        public frmValueEditor(string value)
        {
            InitializeComponent();
            this.Text = Translation.LanguageStrings.ConditionValue;
            this.cbxRetVal.Visible = false;
            if (string.IsNullOrEmpty(value) == false)
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
                    RetVal = string.Empty;
                else
                    RetVal = cbxRetVal.SelectedItem.ToString();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtRetVal.Text))
                    RetVal = string.Empty;
                else
                    RetVal = txtRetVal.Text;
            }

            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            RetVal = null;
            this.Close();
        }

        private void Localize()
        {
            butOk.Text = Translation.LanguageStrings.ButTextEditOk;
            butCancel.Text = Translation.LanguageStrings.ButTextEditCancel;
        }
    }
}
