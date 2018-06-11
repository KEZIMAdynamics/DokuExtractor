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
    public partial class frmTextEdit : Form
    {
        public string RetVal { get; set; } = string.Empty;

        public frmTextEdit()
        {
            InitializeComponent();
        }

        public frmTextEdit(string value)
        {
            InitializeComponent();
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
            if (string.IsNullOrWhiteSpace(txtRetVal.Text))
                RetVal = null;
            else
                RetVal = txtRetVal.Text;

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
