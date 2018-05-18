using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    public class ConditionalFieldTemplate : FieldTemplateBase
    {
        public List<ConditionValue> ConditionValues { get; set; } = new List<ConditionValue>();
        public ConditionalFieldType ConditionalFieldType { get; set; } = ConditionalFieldType.Text;
    }
}
