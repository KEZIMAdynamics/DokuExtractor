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
            switch (fieldTemplate.ConditionType)
            {
                case ConditionType.SimpleDocumentTextRegex:
                    return ProcessSimpleDocumentTextRegexConditions(inputText, fieldTemplate);
                    //break;
                default:
                    throw new NotImplementedException();
                    //break;
            }
        }

        private ConditionalFieldResult ProcessSimpleDocumentTextRegexConditions(string inputText, ConditionalFieldTemplate fieldTemplate)
        {
            var retVal = new ConditionalFieldResult() { Name = fieldTemplate.Name, ConditionalFieldType = fieldTemplate.ConditionalFieldType };

            var regexOptions = RegexOptions.None;
            if (fieldTemplate.IgnoreCaseForSimpleDocumentTextRegex)
                regexOptions = RegexOptions.IgnoreCase;

            foreach (var item in fieldTemplate.ConditionValues)
            {
                if (string.IsNullOrEmpty(item.Condition))
                {
                    retVal.Value = item.Value;
                }
                else
                {
                    var regexConditions = item.Condition.Split("&&".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    var isMatching = true;
                    foreach (var regexCondition in regexConditions)
                    {
                        if (Regex.IsMatch(inputText, regexCondition, regexOptions) == false)
                        {
                            isMatching = false;
                            break;
                        }

                    }

                    if (isMatching)
                        retVal.Value = item.Value;
                }
            }

            return retVal;
        }
    }
}
