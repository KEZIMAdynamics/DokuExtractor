﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokuExtractorCore.Model;

namespace DokuExtractorStandardGUI.UserControls
{
    public partial class ucResultAndEditor : UserControl
    {
        public delegate void TabSwitchedHandler(bool switchedToSingleTemplateEditor);
        /// <summary>
        /// Fired, when user or program switched to another tab of the tab control
        /// </summary>
        public event TabSwitchedHandler TabSwitched;

        public ucResultAndEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Switches to single template editor tab or to extracted data tab
        /// </summary>
        public void SwitchTab(bool switchToSingleTemplateEditor)
        {
            if (switchToSingleTemplateEditor == true)
                tabControl1.SelectedTab = tabSingleTemplateEditor;
            else
                tabControl1.SelectedTab = tabExtractedData;
        }

        /// <summary>
        /// Shows the extracted date within ucExtractedData and the used template within ucSingleTemplateEditor
        /// </summary>
        /// <param name="result">Extracted data</param>
        /// <param name="classTemplate">Used class template</param>
        public void ShowExtractedData(FieldExtractionResult result, DocumentClassTemplate classTemplate)
        {
            ucExtractedData1.ShowExtractedData(result);
            ucSingleTemplateEditor1.ShowPropertiesAndDataFields(classTemplate);
        }

        /// <summary>
        /// Shows a class template (general properties and data fields) within ucSingleTemplateEditor
        /// </summary>
        public void ShowPropertiesAndDataFields(DocumentClassTemplate classTemplate)
        {
            ucSingleTemplateEditor1.ShowPropertiesAndDataFields(classTemplate);
            ucExtractedData1.ShowExtractedData(new FieldExtractionResult());
        }

        /// <summary>
        /// Returns the class (changed) class template, which is shown within ucSingleTemplateEditor
        /// </summary>
        public DocumentClassTemplate GetChangedDocumentClassTemplate()
        {
            var retVal = new DocumentClassTemplate();
            retVal = ucSingleTemplateEditor1.GetDocumentClassTemplateWithChangedGeneralProperties();
            var classTemplateWithChangedDataFields = ucSingleTemplateEditor1.GetDocumentClassTemplateWithChangedDataFields();
            retVal.DataFields = classTemplateWithChangedDataFields.DataFields;

            return retVal;
        }

        /// <summary>
        /// Adds a new data field to ucDataField
        /// </summary>
        public void AddDataField()
        {
            ucSingleTemplateEditor1.AddDataField();
        }

        /// <summary>
        /// Deletes the last (added) data field from ucDataField
        /// </summary>
        public void DeleteDataField()
        {
            ucSingleTemplateEditor1.DeleteLastDataField();
        }

        /// <summary>
        /// Returns the shown (and maybe editted) extraction result of ucExtractedData
        /// </summary>
        public FieldExtractionResult GetFieldExtractionResult()
        {
            return ucExtractedData1.GetFieldExtractionResult();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabSingleTemplateEditor)
                FireTabSwitched(true);
            else if (tabControl1.SelectedTab == tabExtractedData)
                FireTabSwitched(false);
        }

        private void FireTabSwitched(bool switchedToSingleTemplateEditor)
        {
            TabSwitched?.Invoke(switchedToSingleTemplateEditor);
        }
    }
}
