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
        public string AdditionalCultureInfo { get; set; } = string.Empty;

        #region FormButtons
        public string ButGo { get; set; } = "Go!";
        public string ButOk { get; set; } = "OK!";
        public string ButDeleteFile { get; set; } = "Delete file";
        public string ButAddDataField { get; set; } = "Add data field";
        public string ButAddConditionalField { get; set; } = "Add conditional field";
        public string ButSaveTemplate { get; set; } = "Save template";
        public string ButTemplateEditor { get; set; } = "Template editor";
        public string ButLanguageEditor { get; set; } = "Language editor";
        public string InstructionSelectAnchor { get; set; } = "Select an anchor!";
        public string InstructionSelectValue { get; set; } = "Select a value!";

        public string ButTextEditOk { get; set; } = "OK";
        public string ButTextEditCancel { get; set; } = "Cancel";
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

        public string DataFieldGroupTemplateTextAnchors { get; set; } = "Text anchors";
        #endregion DataField

        #region ConditionalField
        public string ConditionalFieldName { get; set; } = "Name";
        public string ConditionalFieldConditions { get; set; } = "Conditions";
        public string ConditionalFieldType { get; set; } = "Type";
        public string Condition { get; set; } = "Condition";
        public string ConditionValue { get; set; } = "Value";

        public string ButAddCondition { get; set; } = "+";
        public string ButDeleteCondition { get; set; } = "-";
        public string ButDeleteConditionalField { get; set; } = "Delete conditional field";

        public string CheckOnlyStoreInGroupTemplate { get; set; } = "Only in Group Template";
        public string CheckIgnoreCaseForSimpleDocumentTextRegex { get; set; } = "Ignore Case";
        #endregion ConditionalField

        #region CalculationField
        public string CalculationFieldName { get; set; } = "Name";
        public string CalculationFieldType { get; set; } = "Type";
        public string CalculationValue { get; set; } = "Calculation value";
        public string CalculationEqualsValidation { get; set; } = "Calculation OK";

        public string CalculationExpression { get; set; } = "Calculation expression (and precision)";
        public string ValidationExpressions { get; set; } = "Validation expressions (and precision)";
        public string ButDeleteCalculationField { get; set; } = "Delete calculation field";
        #endregion CalculationField

        #region FieldType
        public string FieldTypeText { get; set; } = "Text";
        public string FieldTypeDate { get; set; } = "Date";
        public string FieldTypeCurrency { get; set; } = "Currency";
        public string FieldTypeIban { get; set; } = "IBAN";
        public string FieldTypeAnchorlessIban { get; set; } = "Anchorless IBAN";
        public string FieldTypeVatId { get; set; } = "VAT ID";
        public string FieldTypeTerm { get; set; } = "Term";
        #endregion FieldType

        #region ConditionalFieldType
        public string ConditionalFieldTypeText { get; set; } = "Text";
        public string ConditionalFieldTypeBool { get; set; } = "Bool";
        public string ConditionalFieldTypeNumber { get; set; } = "Number";
        public string ConditionalFieldTypeDate { get; set; } = "Date";
        public string ConditionalFieldTypeUserId { get; set; } = "User ID";
        public string ConditionalFieldTypeUserGroupId { get; set; } = "User group ID";
        public string ConditionalFieldTypeUserOrUserGroupId { get; set; } = "User or user group ID";
        #endregion ConditionalFieldType

        #region GeneralPropertyEditor
        public string Iban { get; set; } = "IBAN";
        public string Keywords { get; set; } = "Keywords";
        #endregion GeneralPropertyEditor

        #region TemplateEditor
        public string ClassTemplateEditor { get; set; } = "Class template editor";
        public string GroupTemplateEditor { get; set; } = "Group template editor";

        public string ButAddCalculationField { get; set; } = "Add calculation field";
        #endregion TemplateEditor

        #region LanguageEditor
        public string ButAddLanguage { get; set; } = "Add language";
        public string ButDeleteLanguage { get; set; } = "Delete language";
        public string ButSaveLanguage { get; set; } = "Save";
        #endregion LanguageEditor

        #region MessageBoxes
        public string MsgDllNotFound { get; set; } = "DLL not found!";
        public string MsgClassTemplateSaved { get; set; } = "Class template saved.";
        public string MsgGroupTemplateSaved { get; set; } = "Group template saved.";
        public string MsgAskDeleteFile { get; set; } = "Do you really want to delete this file?";
        public string MsgAskStartRegexExpressionHelper { get; set; } = "Start regex expression helper?";
        public string MsgAskAcceptRegexExpressionHelperResult { get; set; } = "Do you accept the following result?";
        public string MsgAskAdditionalRegexExpression { get; set; } = "Do you want to add this expression as an ADDITIONAL expression?";
        public string MsgNoRegexExpressionFinderResult { get; set; } = "Could not get a regex expression finder result. No regex expression found!";
        public string MsgTemplateFound { get; set; } = "Template found: ";
        public string MsgNoTemplateFound { get; set; } = "No template found! New Template was generated.";
        public string MsgEmptyOrInvalidValues { get; set; } = "Empty/Invalid values detected! Please fill values of all data fields.";
        public string MsgEmptyOrInvalidGeneralProperties { get; set; } = "Empty/Invalid properties detected! Pleas fill class and group name and define keywords.";
        #endregion MessageBoxes
    }
}
