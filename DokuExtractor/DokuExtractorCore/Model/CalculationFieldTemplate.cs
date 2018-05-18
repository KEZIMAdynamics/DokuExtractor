using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Template for a single CalculationField. Used in DocumentGroupTemplate. Two expressions, with values based on data fields, can be calculated. Their result will be returned in a CalculationFieldResult.
    /// </summary>
    public class CalculationFieldTemplate : FieldTemplateBase
    {
        /// <summary>
        /// Field type. Currently only <see cref="DataFieldType.Currency"/> operations are supported by the calculator.
        /// </summary>
        public DataFieldType FieldType { get; set; } = DataFieldType.Currency;

        /// <summary>
        /// Allows common arithmetic operations with data field values. Data field values need to be enclosed by [].
        /// If the value of a data field called "A" shall be added to the value of a data field named "B" the correct expression would be "[A]+[B]".
        /// </summary>
        public string CalculationExpression { get; set; } = string.Empty;

        /// <summary>
        /// Allows to round the calculated value to the given precision. Rounding takes place before value validation. "-1" Disables explicit rounding.
        /// </summary>
        public int CalculationExpressionPrecision { get; set; } = -1;

        /// <summary>
        /// Allows common arithmetic operations with data field values. Data field values need to be enclosed by [].
        /// If the value of a data field called "A" shall be added to the value of a data field named "B" the correct expression would be "[A]+[B]".
        /// Multiple expressions can be set. If a calculation value matches any of the resulting validation values, the validation will be successful.
        /// </summary>
        public List<string> ValidationExpressions { get; set; } = new List<string>();

        /// <summary>
        /// Allows to round the calculated validation value to the given precision. Rounding takes place before calculation value validation. "-1" Disables explicit rounding.
        /// </summary>
        public int ValidationExpressionPrecision { get; set; } = -1;
    }
}
