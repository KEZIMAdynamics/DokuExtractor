using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    public class CalculationFieldResult
    {
        public string Name { get; set; } = string.Empty;
        public DataFieldTypes FieldType { get; set; } = DataFieldTypes.Currency;
        public double CalculationValue { get; set; }
        public double ValidationValue { get; set; }
        public bool CalculationEqualsValidation { get; set; }
    }
}
