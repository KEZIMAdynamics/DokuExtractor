using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    /// <summary>
    /// Template Matcher
    /// </summary>
    public class TemplateMatcher
    {
        RegexExpressionFinder finder = new RegexExpressionFinder();

        /// <summary>
        /// Preselection of templates the possibly match. Based on IBAN. Maybe more conditions in the future.
        /// </summary>
        /// <param name="templates"></param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public List<DocumentClassTemplate> PreSelectTemplates(List<DocumentClassTemplate> templates, string inputText)
        {
            var retVal = new List<DocumentClassTemplate>();

            RegexExpressionFinderResult regexResult;
            if (finder.TryFindRegexMatchExpress(inputText, string.Empty, string.Empty, DataFieldType.AnchorLessIBAN, false, out regexResult))
            {
                var templateDict = new Dictionary<string, DocumentClassTemplate>();
                foreach (var item in templates)
                {
                    foreach (var itemIban in item.PreSelectionCondition.IBANs)
                    {
                        if (templateDict.ContainsKey(itemIban) == false)
                        {
                            templateDict.Add(itemIban, item);
                        }
                    }
                }

                foreach (var item in regexResult.AllMatchingValues)
                {
                    var iban = item.Replace(" ", string.Empty).ToUpper();
                    DocumentClassTemplate outTemplate;
                    if (templateDict.TryGetValue(iban, out outTemplate))
                        retVal.Add(outTemplate);
                }

                //   retVal.AddRange(templates.Where(x => x.PreSelectionCondition.IBANs.Contains(iban)));
            }

            return retVal;
        }

        /// <summary>
        /// Matches a template to the input text based on the template's key words.
        /// </summary>
        /// <param name="templates"></param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public TemplateMatchResult<T> MatchTemplatesViaKeyWords<T>(List<T> templates, string inputText) where T : DocumentBaseTemplate
        {
            var checkedWords = new Dictionary<string, int>();

            var retVal = new TemplateMatchResult<T>();

            inputText = Regex.Replace(inputText, " +", " ");

            foreach (var template in templates)
            {
                bool isMatchingTemplate = false;
                foreach (var keywordGroup in template.KeyWords)
                {
                    var keyWordsInGroup = keywordGroup.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    var doesAnyKeyWordInGroupMatch = CheckIfAnyKeyWordInKeyWordGroupMatches(keyWordsInGroup, inputText, checkedWords);

                    if (doesAnyKeyWordInGroupMatch == true)
                    {
                        isMatchingTemplate = true;
                    }
                    else
                    {
                        isMatchingTemplate = false;
                        break;
                    }
                }

                if (isMatchingTemplate)
                {
                    retVal.Template = template;
                    retVal.IsMatchSuccessfull = true;
                    break;
                }
            }

            return retVal;
        }

        private bool CheckIfAnyKeyWordInKeyWordGroupMatches(string[] keyWordsInGroup, string inputText, Dictionary<string, int> checkedWords)
        {
            //bool doesAnyKeyWordInGroupMatch = false;
            foreach (var keyword in keyWordsInGroup)
            {
                int keyWordCount;

                var mustNotMatch = false;
                string matchWord;
                if (keyword.StartsWith("!"))
                {
                    mustNotMatch = true;
                    matchWord = keyword.Remove(0, 1);
                }
                else
                    matchWord = keyword;


                if (checkedWords.TryGetValue(matchWord, out keyWordCount) == false)
                {
                    var regexMatches = Regex.Matches(inputText, Regex.Escape(matchWord));
                    keyWordCount = regexMatches.Count;
                    checkedWords.Add(matchWord, keyWordCount);
                }

                if ((keyWordCount > 0 && mustNotMatch == false) || (keyWordCount == 0 && mustNotMatch == true))
                {
                    //doesAnyKeyWordInGroupMatch = true;
                    //break;
                    return true;
                }

                //if (keyWordCount == 0 && mustNotMatch == true)
                //{
                //    wordCount = 1;
                //    break;
                //}
                //if (singleWordCount >= 1)
                //{
                //    wordCount = singleWordCount;
                //    break;
                //}
            }

            return false;
        }
    }
}
