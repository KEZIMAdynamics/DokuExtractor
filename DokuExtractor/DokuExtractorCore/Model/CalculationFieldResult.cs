using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Result for a single CalculationField. Used in FieldExtractionResult. Contains the result of two expressions, with values based on data fields. Also indicates whether the two expressions in the according template produced the same value.
    /// </summary>
    public class CalculationFieldResult
    {
        /// <summary>
        /// Fieldname
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Field type. Currently only <see cref="DataFieldTypes.Currency"/> operations are supported by the calculator.
        /// </summary>
        public DataFieldTypes FieldType { get; set; } = DataFieldTypes.Currency;

        /// <summary>
        /// The resulting value of the first expression.
        /// </summary>
        public double CalculationValue { get; set; }

        /// <summary>
        /// The resulting value of the second / validation expression.
        /// </summary>
        public List<double> ValidationValues { get; set; }

        /// <summary>
        /// Does the calculation value equal the validation value?
        /// </summary>
        public bool CalculationEqualsValidation { get; set; }
    }
}
