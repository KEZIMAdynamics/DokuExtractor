using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    public class RegexExpressionFinder
    {
        List<string> dateExpressions = new List<string>()
        {
         @"(\d+.\d{2}.\d+)",@"([a-zA-Z]+ \d+ , \d+)",@"(\d{2}-\d{2}-\d{4})",
         @"([\s,\d]+-[A-Z,a-z]{3}-\d{4})",@"(\d{1,2}\w+,\d{4})",@"(\d{1,2}\. \w+ \d{4})",
         @"(\d{4}-\d{2}-\d{2})",@"(\w+,\d{4})",@"(\d{1,2}\w+,\d{4})",@"(\d{1,2}\.\w+\d{4})",
         @"(\d+\D+\s+\w+\s+\d+)",@"(\d+\. .+ \d{4})",
         @"(\d{2}-\w+-\d{4})",@"(\w{1,10}\d+,\d{4})",@"(\w{3,}\d{1,2},\d{4})",@"(\d{1,2}.+\s+\d{4})",
         @"(\d{2}\/\d{2}\/\d{4})",@"(\d+/\d+/\d+)",@"(\d+/\d+/\d{4})",@"(\d{1,2}\/\d{1,2}\/\d{4})",
         @"(\d{4}-\d{2}-\d{2})",@"(\d{4}-\d{2}-\d{2})",@"(\d{1,2}\/\d{1,2}\/\d{4})",@"(\d{2}\,\d{2}\,\d{4})",
         @"(\w+\s*\d+,\s*\d{4})",@"(\d{1,2}-\d{1,2}-\d{4})",@"(\d{2}/\d{2}/\d{4})",@"(\d{1,2}\.\d{1,2}\.\d{4})",@"(\d{2}.+,\s\d{4})",@"(\d+\.\d+\s\d+\s\d)"

        };

        public bool TryFindRegexMatchExpress(string inputText, string regexHalfString, string regexFullString, DataFieldTypes dataFieldType, out string regexMatchExpression)
        {


            regexMatchExpression = string.Empty;
            switch (dataFieldType)
            {
                case DataFieldTypes.Text:
                    regexMatchExpression = RegHeart(regexFullString, regexHalfString, new List<string>() { @"\w+" }, new List<string>() { @"\s+" }, inputText);
                    break;
                case DataFieldTypes.Date:
                    regexMatchExpression = RegHeart(regexFullString, regexHalfString, dateExpressions, new List<string>() { @"\s+", @"\s+.\s+", @"\s+\w+\s+", @"\s+\w+\s+\w+\s+", @"\s+\w+\s+\w+\s+\w+\s+", @".+\s+", @".+\s+\w+", @".+\s+\w+\s+", @".+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+", @".+\s+\w+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+\w+\s+", @".+\/" }, inputText);
                    break;
                default:
                    break;
            }


            if (regexMatchExpression == string.Empty)
                return false;
            else
                return true;
        }
        // TODO: auf group[1] ausdruck testen und "Groupstring" aufnehmen
        private string RegHeart(string regexFullString, string regexHalfString, List<string> specificExpressions, List<string> generalExpressions, string inputText)
        {
            var loopCounter = 0;
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (var specificExpression in specificExpressions)
            {
                foreach (var generalExpression in generalExpressions)
                {
                    loopCounter++;
                    var regexText = regexHalfString + generalExpression + specificExpression;
                    var match = Regex.Match(inputText, regexText);

                    if (match.Success)
                    {
                        if (match.Value == regexFullString)
                        {
                            Debug.Print(regexText + Environment.NewLine +"Regex runs until result: " + loopCounter + Environment.NewLine + "Duration: " + stopWatch.Elapsed.ToString());

                            return regexText;
                        }

                    }
                }
            }

            return string.Empty;
        }
    }
}
