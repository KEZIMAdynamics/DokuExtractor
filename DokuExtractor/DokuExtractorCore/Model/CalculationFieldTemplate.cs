using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    public class CalculationFieldTemplate
    {
        public string Name { get; set; } = string.Empty;
        public DataFieldTypes FieldType { get; set; } = DataFieldTypes.Currency;
        public string CalculationExpression { get; set; } = string.Empty;
        public string ValidationExpression { get; set; } = string.Empty;
    }
}
