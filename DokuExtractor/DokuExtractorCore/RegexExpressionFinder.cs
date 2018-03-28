using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        List<string> currencyExpressions = new List<string>()
        {
         @"(\d+.?\d{0,3},\d{2})",
         @"(\d+,\d{2})\D",
         @"(\d+'\d{2})\D",
         @"(\d+\D\d{2})\D",
         @"(\d+.\d{3},\d{2})",
         @"(\d+,\d{2})",
         @"(\d+'\d{2})",
         @"(\d+\D\d{2})"
        };

        List<string> IBANExpressions = new List<string>()
        {
        @"([a-zA-Z]{2}\d{2}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{2})"
        };

        public bool TryFindRegexMatchExpress(string inputText, string targetValue, string textAnchor, DataFieldTypes dataFieldType, out RegexExpressionFinderResult regexResult)
        {
            regexResult = new RegexExpressionFinderResult();


            switch (dataFieldType)
            {
                case DataFieldTypes.Text:
                    regexResult = RegHeart(textAnchor, targetValue, new List<string>() { @"(\w+)" }, new List<string>() { @"\s+" }, inputText);
                    break;
                case DataFieldTypes.Date:
                    regexResult = RegHeart(textAnchor, targetValue, dateExpressions, new List<string>() { @"\s+", @"\s+.\s+", @"\s+\w+\s+", @"\s+\w+\s+\w+\s+", @"\s+\w+\s+\w+\s+\w+\s+", @".+\s+", @".+\s+\w+", @".+\s+\w+\s+", @".+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+", @".+\s+\w+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+\w+\s+", @".+\/" }, inputText);
                    break;
                case DataFieldTypes.Currency:
                    regexResult = RegHeart(textAnchor, targetValue, currencyExpressions, new List<string>() { @"\s+", @"\s+.\s+", @"\s+\w+\s+", @"\s+\w+\s+\w+\s+", @"\s+\w+\s+\w+\s+\w+\s+", @".+\s+", @".+\s+\w+", @".+\s+\w+\s+", @".+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+", @".+\s+\w+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+\w+\s+", @".+\/", @"\s+\w+\s+\d+,\d{2}\s+",
                        @"\s+\d+,\d{2}\s+\w+\s+" }, inputText);
                    break;
                case DataFieldTypes.IBAN:
                    regexResult = RegHeart(textAnchor, targetValue, IBANExpressions, new List<string>() { @"\s+", @"\s+.\s+", @"\s+\w+\s+", @"\s+\w+\s+\w+\s+", @"\s+\w+\s+\w+\s+\w+\s+"/*, @".+\s+", @".+\s+\w+", @".+\s+\w+\s+", @".+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+", @".+\s+\w+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+\w+\s+", @".+\/" */}, inputText);
                    break;
                default:
                    break;
            }

            return regexResult.Success;
        }

        private RegexExpressionFinderResult RegHeart(string textAnchor, string targetValue, List<string> specificExpressions, List<string> generalExpressions, string inputText)
        {
            var loopCounter = 0;
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var retVal = new RegexExpressionFinderResult();

            foreach (var specificExpression in specificExpressions)
            {
                foreach (var generalExpression in generalExpressions)
                {
                    loopCounter++;
                    var regexText = Regex.Escape(textAnchor) + generalExpression + specificExpression;
                    var match = Regex.Match(inputText, regexText);
                    if (match.Success)
                    {
                        if (match.Groups[1].Value == targetValue || targetValue == string.Empty)
                        {
                            retVal.RegexExpression = regexText;
                            retVal.MatchingValue = match.Groups[1].Value;
                            Debug.Print(regexText + Environment.NewLine + "Regex runs until result: " + loopCounter + Environment.NewLine + "Duration: " + stopWatch.Elapsed.ToString());
                            retVal.Success = true;
                            return retVal;
                        }

                    }
                }
            }

            return retVal;
        }
    }
}
