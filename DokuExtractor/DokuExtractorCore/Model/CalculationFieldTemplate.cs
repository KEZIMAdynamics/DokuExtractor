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
    public class CalculationFieldTemplate
    {

        /// <summary>
        /// Field name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Field type. Currently only <see cref="DataFieldTypes.Currency"/> operations are supported by the calculator.
        /// </summary>
        public DataFieldTypes FieldType { get; set; } = DataFieldTypes.Currency;

        /// <summary>
        /// Allows common arithmetic operations with data field values. Data field values need to be enclosed by [].
        /// If the value of a data field called "A" shall be added to the value of a data field named "B" the correct expression would be "[A]+[B]".
        /// </summary>
        public string CalculationExpression { get; set; } = string.Empty;

        /// <summary>
        /// Allows common arithmetic operations with data field values. Data field values need to be enclosed by [].
        /// If the value of a data field called "A" shall be added to the value of a data field named "B" the correct expression would be "[A]+[B]".
        /// </summary>
        public string ValidationExpression { get; set; } = string.Empty;
    }
}
