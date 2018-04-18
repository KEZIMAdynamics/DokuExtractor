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
    public partial class ucSingleTemplateEditor : UserControl
    {
        public ucSingleTemplateEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classTemplate"></param>
        public void ShowPropertiesAndDataFields(DocumentClassTemplate classTemplate)
        {
            ShowGeneralProperties(classTemplate);
            ShowDataFields(classTemplate);
        }

        /// <summary>
        /// Adds a new data field to ucDataField
        /// </summary>
        public void AddDataField()
        {
            ucDataFieldEditor1.AddDataField();
        }

        /// <summary>
        /// Deletes the last (added) data field from ucDataField
        /// </summary>
        public void DeleteLastDataField()
        {
            ucDataFieldEditor1.DeleteLastDataField();
        }

        /// <summary>
        /// Returns the class template with changed general properties
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedGeneralProperties()
        {
            return ucGeneralPropertyEditor1.GetDocumentClassTemplateWithChangedGeneralProperties();
        }

        /// <summary>
        /// Returns the class template with changed data fields
        /// </summary>
        public DocumentClassTemplate GetDocumentClassTemplateWithChangedDataFields()
        {
            return ucDataFieldEditor1.GetDocumentClassTemplateWithChangedDataFields();
        }

        /// <summary>
        /// Shows the general properties of a class template
        /// </summary>
        private void ShowGeneralProperties(DocumentClassTemplate classTemplate)
        {
            ucGeneralPropertyEditor1.ShowGeneralProperties(classTemplate);
        }

        /// <summary>
        /// Shows the data fields of a class template
        /// </summary>
        private void ShowDataFields(DocumentClassTemplate classTemplate)
        {
            ucDataFieldEditor1.ShowDataFields(classTemplate);
        }
    }
}
