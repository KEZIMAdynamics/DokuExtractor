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
        public string Name { get; set; } = string.Empty;
        public DataFieldTypes FieldType { get; set; } = DataFieldTypes.Currency;
        public double CalculationValue { get; set; }
        public double ValidationValue { get; set; }
        public bool CalculationEqualsValidation { get; set; }
    }
}
