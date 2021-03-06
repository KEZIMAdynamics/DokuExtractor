﻿using DokuExtractorCore.Model;
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
    /// <summary>
    /// Finds matching regex expressions based on supplied information.
    /// </summary>
    public class RegexExpressionFinder
    {
        RegexExpressions expressions = new RegexExpressions();
        //List<string> dateExpressions = new List<string>()
        //{
        // @"(\d+.\d{2}.\d+)",@"([a-zA-Z]+ \d+ , \d+)",@"(\d{2}-\d{2}-\d{4})",
        // @"([\s,\d]+-[A-Z,a-z]{3}-\d{4})",@"(\d{1,2}\w+,\d{4})",@"(\d{1,2}\. \w+ \d{4})",
        // @"(\d{4}-\d{2}-\d{2})",@"(\w+,\d{4})",@"(\d{1,2}\w+,\d{4})",@"(\d{1,2}\.\w+\d{4})",
        // @"(\d+\D+\s+\w+\s+\d+)",@"(\d+\. .+ \d{4})",
        // @"(\d{2}-\w+-\d{4})",@"(\w{1,10}\d+,\d{4})",@"(\w{3,}\d{1,2},\d{4})",@"(\d{1,2}.+\s+\d{4})",
        // @"(\d{2}\/\d{2}\/\d{4})",@"(\d+/\d+/\d+)",@"(\d+/\d+/\d{4})",@"(\d{1,2}\/\d{1,2}\/\d{4})",
        // @"(\d{4}-\d{2}-\d{2})",@"(\d{4}-\d{2}-\d{2})",@"(\d{1,2}\/\d{1,2}\/\d{4})",@"(\d{2}\,\d{2}\,\d{4})",
        // @"(\w+\s*\d+,\s*\d{4})",@"(\d{1,2}-\d{1,2}-\d{4})",@"(\d{2}/\d{2}/\d{4})",@"(\d{1,2}\.\d{1,2}\.\d{4})",@"(\d{2}.+,\s\d{4})",@"(\d+\.\d+\s\d+\s\d)"

        //};

        //List<string> currencyExpressions = new List<string>()
        //{
        // @"(\d+.?\d{0,3},\d{2})",
        // @"(\d+,\d{2})\D",
        // @"(\d+'\d{2})\D",
        // @"(\d+\D\d{2})\D",
        // @"(\d+.\d{3},\d{2})",
        // @"(\d+,\d{2})",
        // @"(\d+'\d{2})",
        // @"(\d+\D\d{2})"
        //};

        //List<string> IBANExpressions = new List<string>()
        //{
        //@"([a-zA-Z]{2}\d{2}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{2})"
        //};

        //List<string> WildCardIBANExpressions = new List<string>()
        //{
        //@"([a-zA-Z]{2}\d{2}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{2})"
        //};

        //List<string> VatIdExpressions = new List<string>()
        //{
        //@"([a-zA-Z]{2}\s?[0-9a-zA-Z]{3}\s?[0-9]{3}\s?[0-9a-zA-Z]{3,4})\s",
        //@"([a-zA-Z]{2}\s?[0-9a-zA-Z]{3}\s?[0-9]{3}\s?[0-9a-zA-Z]{3,4})"
        //};

        //List<string> termExpressions = new List<string>()
        //{
        // @"(.+?)\s",
        // @"(.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
        // @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s"
        // //@"(\d+.\d{3},\d{2})",
        // //@"(\d+,\d{2})",
        // //@"(\d+'\d{2})",
        // //@"(\d+\D\d{2})"
        //};

        /// <summary>
        /// Tries to find a regex expression to match the target value in an input text based on a text anchor and the type of the target value. 
        /// </summary>
        /// <param name="inputText">The text against which the regex expression will be matched</param>
        /// <param name="targetValue">The value that the regex expression needs to find. If targetValue is empty, the expression will match the next occurence of the correct dataFieldType after the text anchor.</param>
        /// <param name="textAnchor">The text anchor associated to the regex expression</param>
        /// <param name="dataFieldType">Indicates the type of data that the regex expression shall match. Different types (e.g. dates and currencies) are matched with different regex expressions. Therefore it is important to specify the correct type.</param>
        /// <param name="returnFirstMatchOnly"></param>
        /// <param name="regexResult">The result containing the regex expression and matching value (if any)</param>
        /// <returns></returns>
        public bool TryFindRegexMatchExpress(string inputText, string textAnchor, string targetValue, DataFieldType dataFieldType, bool returnFirstMatchOnly, out RegexExpressionFinderResult regexResult)
        {
            regexResult = new RegexExpressionFinderResult();

            textAnchor = textAnchor.Trim();
            targetValue = targetValue.Trim();


            switch (dataFieldType)
            {
                case DataFieldType.Text:
                    regexResult = RegHeart(textAnchor, targetValue, new List<string>() { @"(\w+)" }, new List<string>() { @"\s+" }, inputText, returnFirstMatchOnly);
                    break;
                case DataFieldType.Date:
                    regexResult = RegHeart(textAnchor, targetValue, expressions.GeneralDateExpressions, expressions.SpecificDateExpressions, inputText, returnFirstMatchOnly);
                    break;
                case DataFieldType.Currency:
                    regexResult = RegHeart(textAnchor, targetValue, expressions.GeneralCurrencyExpressions, expressions.SpecificCurrencyExpressions, inputText, returnFirstMatchOnly);
                    break;
                case DataFieldType.IBAN:
                    regexResult = RegHeart(textAnchor, targetValue, expressions.GeneralIBANExpressions, expressions.SpecificIBANExpressions, inputText, returnFirstMatchOnly);
                    break;
                case DataFieldType.AnchorLessIBAN:
                    regexResult = RegHeart(textAnchor, targetValue, expressions.GeneralAnchorlessIBANExpressions, expressions.SpecificAnchorlessIBANExpressions, inputText, returnFirstMatchOnly);
                    break;
                case DataFieldType.VatId:
                    regexResult = RegHeart(textAnchor, targetValue, expressions.GeneralVatIdExpressions, expressions.SpecificVatIdExpressions, inputText, returnFirstMatchOnly);
                    break;
                case DataFieldType.Term:
                    regexResult = RegHeart(textAnchor, targetValue, expressions.GeneralTermExpressions, expressions.SpecificTermExpressions, inputText, returnFirstMatchOnly);
                    break;
                default:
                    break;
            }

            return regexResult.Success;
        }

        private RegexExpressionFinderResult RegHeart(string textAnchor, string targetValue, List<string> generalExpressions, List<string> specificExpressions, string inputText, bool returnFirstMatchOnly)
        {
            var loopCounter = 0;
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var retVal = new RegexExpressionFinderResult();

            if (Regex.IsMatch(inputText, Regex.Escape(textAnchor)))
                foreach (var specificExpression in specificExpressions)
                {
                    foreach (var generalExpression in generalExpressions)
                    {
                        loopCounter++;
                        var regexText = Regex.Escape(textAnchor) + generalExpression + specificExpression;
                        if (returnFirstMatchOnly)
                        {
                            var match = Regex.Match(inputText, regexText);
                            if (match.Success)
                            {
                                if (match.Groups[1].Value == targetValue || targetValue == string.Empty)
                                {
                                    retVal.RegexExpression = regexText;
                                    retVal.MatchingValue = match.Groups[1].Value;
                                    retVal.AllMatchingValues = new List<string>() { match.Groups[1].Value };
                                    Debug.Print(regexText + Environment.NewLine + "Regex runs until result: " + loopCounter + Environment.NewLine + "Duration: " + stopWatch.Elapsed.ToString());
                                    retVal.Success = true;
                                    return retVal;
                                }

                            }
                        }
                        else
                        {
                            var matches = Regex.Matches(inputText, regexText);
                            if (matches.Count > 0)
                            {
                                if (matches[0].Groups[1].Value == targetValue || targetValue == string.Empty)
                                {
                                    retVal.RegexExpression = regexText;
                                    retVal.MatchingValue = matches[0].Groups[1].Value;
                                    retVal.AllMatchingValues = new List<string>();
                                    foreach (Match item in matches)
                                    {
                                        retVal.AllMatchingValues.Add(item.Groups[1].Value);
                                    }
                                    Debug.Print(regexText + Environment.NewLine + "Regex runs until result for '" + textAnchor + "': " + loopCounter + Environment.NewLine + "Duration: " + stopWatch.Elapsed.ToString());
                                    retVal.Success = true;
                                    return retVal;
                                }
                            }
                        }

                    }
                }

       //     Debug.Print("Regex expression for " + textAnchor + " not found. Regex runs: " + loopCounter + Environment.NewLine + "Duration: " + stopWatch.Elapsed.ToString());

            return retVal;
        }
    }
}
