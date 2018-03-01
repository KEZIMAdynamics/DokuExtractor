using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    public class RegexExpressionFinder
    {
        public bool TryFindRegexMatchExpress(string inputText, string regexHalfString, string regexFullString, DataFieldTypes dataFieldType, out string regexMatchExpression)
        {
            switch (dataFieldType)
            {
                case DataFieldTypes.Text:
                    break;
                case DataFieldTypes.Date:
                    break;
                default:
                    break;
            }

            regexMatchExpression = string.Empty;
            return false;
        }
    }
}
