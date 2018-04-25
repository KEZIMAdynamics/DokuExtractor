using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    public class ConditionalFieldTemplate
    {
        public string Name { get; set; } = string.Empty;
        public List<ConditionValue> ConditionValues { get; set; } = new List<ConditionValue>();
    }
}
