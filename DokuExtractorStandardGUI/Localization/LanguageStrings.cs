using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorStandardGUI.Localization
{
    public class LanguageStrings
    {
        public CultureInfo Culture { get; set; } = new CultureInfo("en-US");

        #region FormButtons
        public string ButGo { get; set; } = "Go!";
        public string ButOk { get; set; } = "OK!";
        public string ButAddDataField { get; set; } = "Add data field";
        public string ButSaveTemplate { get; set; } = "Save template";
        public string ButTemplateEditor { get; set; } = "Template editor";
        public string ButLanguageEditor { get; set; } = "Language editor";
        public string InstructionSelectAnchor { get; set; } = "Select an anchor";
        public string InstructionSelectValue { get; set; } = "Select a value!";
        #endregion FormButtons

        #region FileSelector
        public string FileName { get; set; } = "Name";
        public string FileLength { get; set; } = "Length";
        public string LastWriteTime { get; set; } = "Last write time";
        #endregion FileSelector

        #region ResultAndEditor
        public string ExtractedData { get; set; } = "Extracted data";
        public string SingleTemplateEditor { get; set; } = "Single template editor";
        #endregion ResultAndEditor

        #region Templates
        public string TemplateClassName { get; set; } = "Template class name";
        public string TemplateGroupName { get; set; } = "Template group name";
        #endregion Templates

        #region DataField
        public string DataFieldName { get; set; } = "Name";
        public string DataFieldValue { get; set; } = "Value";
        public string DataFieldType { get; set; } = "Type";

        public string DataFieldRegexExpressions { get; set; } = "Regex expressions";
        public string ButDeleteDataField { get; set; } = "Delete data field";
        #endregion DataField

        #region CalculationField
        public string CalculationFieldName { get; set; } = "Name";
        public string CalculationFieldType { get; set; } = "Type";
        public string CalculationValue { get; set; } = "Calculation value";
        public string CalculationEqualsValidation { get; set; } = "Calculation OK";
        #endregion CalculationField

        #region FieldType
        public string FieldTypeText = "Text";
        public string FieldTypeDate = "Date";
        public string FieldTypeCurrency = "Currency";
        public string FieldTypeIban = "IBAN";
        public string FieldTypeAnchorlessIban = "Anchorless IBAN";
        public string FieldTypeVatId = "VAT ID";
        public string FieldTypeTerm = "Term";
        #endregion FieldType

        #region GeneralPropertyEditor
        public string Iban { get; set; } = "IBAN";
        public string Keywords { get; set; } = "Keywords";
        #endregion GeneralPropertyEditor
    }
}
