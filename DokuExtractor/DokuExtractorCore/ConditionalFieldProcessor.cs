using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    public class ConditionalFieldProcessor
    {
        public ConditionalFieldResult ProcessConditions(string inputText, ConditionalFieldTemplate fieldTemplate)
        {
            var retVal = new ConditionalFieldResult() { Name = fieldTemplate.Name };

            foreach (var item in fieldTemplate.ConditionValues)
            {
                if (string.IsNullOrEmpty(item.Condition) || Regex.IsMatch(inputText, item.Condition))
                {
                    retVal.Value = item.Value;
                }
            }

            return retVal;
        }
    }
}
