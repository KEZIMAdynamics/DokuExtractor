﻿using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace DokuExtractorCore
{
    public class TemplateProcessor
    {
        public string TemplateDirectory { get; set; }
        string appRootPath;


        public TemplateProcessor(string appRootPath)
        {
            this.appRootPath = appRootPath;
            TemplateDirectory = Path.Combine(appRootPath, "ExtractorTemplates");
        }

        public List<FieldExtractorTemplate> LoadTemplatesFromDisk()
        {
            var retVal = new List<FieldExtractorTemplate>();

            foreach (var item in Directory.GetFiles(TemplateDirectory))
            {
                try
                {
                    var template = JsonConvert.DeserializeObject<FieldExtractorTemplate>(File.ReadAllText(item));
                    retVal.Add(template);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return retVal;
        }

        public void SaveTemplates(List<FieldExtractorTemplate> templates)
        {
            SaveTemplates(templates, TemplateDirectory);
        }
        public void SaveTemplates(List<FieldExtractorTemplate> templates, string templateDirectory)
        {
            if (Directory.Exists(templateDirectory) == false)
                Directory.CreateDirectory(templateDirectory);

            foreach (var template in templates)
            {
                var templateJson = JsonConvert.SerializeObject(template, Formatting.Indented);
                var filePath = Path.Combine(templateDirectory, template.TemplateName + ".json.txt");

                File.WriteAllText(filePath, templateJson);
            }
        }

        public TemplateMachResult MatchTemplates(List<FieldExtractorTemplate> templates, string inputText)
        {
            var retVal = new TemplateMachResult();

            var preselectedTemplates = PreSelectTemplates(templates, inputText);
            if (preselectedTemplates.Count > 0)
            {
                retVal = MatchTemplatesViaKeyWords(preselectedTemplates, inputText);
            }
            if (retVal.IsMatchSuccessfull == false)
            {
                retVal = MatchTemplatesViaKeyWords(templates, inputText);
            }

            return retVal;
        }

        public List<FieldExtractorTemplate> PreSelectTemplates(List<FieldExtractorTemplate> templates, string inputText)
        {
            var retVal = new List<FieldExtractorTemplate>();

            RegexExpressionFinderResult regexResult;
            if (TryFindRegexMatchExpress(inputText, string.Empty, string.Empty, DataFieldTypes.IBAN, out regexResult))
            {
                var iban = regexResult.MatchingValue.Replace(" ", string.Empty).ToUpper();
                retVal.AddRange(templates.Where(x => x.PreSelectionCondition.IBAN == iban));
            }

            return retVal;
        }

        public TemplateMachResult MatchTemplatesViaKeyWords(List<FieldExtractorTemplate> templates, string inputText)
        {
            var checkedWords = new Dictionary<string, int>();

            var retVal = new TemplateMachResult();

            foreach (var template in templates)
            {
                bool isMatchingTemplate = false;
                foreach (var keywordGroup in template.KeyWords)
                {
                    var singleWords = keywordGroup.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    int wordCount = 0;
                    foreach (var singleWord in singleWords)
                    {
                        int singleWordCount;

                        if (checkedWords.TryGetValue(singleWord, out singleWordCount) == false)
                        {
                            var regexMatches = Regex.Matches(inputText, Regex.Escape(singleWord));
                            singleWordCount = regexMatches.Count;
                            checkedWords.Add(singleWord, singleWordCount);

                            if (singleWordCount > 0)
                            {
                                wordCount = 1;
                                break;
                            }
                        }

                        if (singleWordCount >= 1)
                        {
                            wordCount = singleWordCount;
                            break;
                        }
                    }

                    if (wordCount >= 1)
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

        public FieldExtractionResult ExtractData(FieldExtractorTemplate template, string inputText)
        {
            var retVal = new FieldExtractionResult() { TemplateName = template.TemplateName, TemplateClass = template.TemplateClass };

            foreach (var item in template.DataFields)
            {
                var resultItem = new DataFieldResult() { FieldType = item.FieldType, Name = item.Name };
                resultItem.Value = ExecuteRegexExpression(inputText, item.RegexExpressions);
                retVal.DataFields.Add(resultItem);
            }

            return retVal;
        }

        public string ExtractDataAsJson(FieldExtractorTemplate template, string inputText)
        {
            var json = JsonConvert.SerializeObject(ExtractData(template, inputText), Formatting.Indented);
            return json;
        }

        public FieldExtractorTemplate AutoCreateTemplate(string templateName, string inputText)
        {
            var genericRechnung = JsonConvert.DeserializeObject<FieldExtractorTemplate>(File.ReadAllText(Path.Combine(appRootPath, "GenericTemplates", "GenericTemplateRechnungen.json.txt")));

            var retVal = new FieldExtractorTemplate();
            retVal.TemplateName = templateName;

            RegexExpressionFinderResult regexResult;
            if (TryFindRegexMatchExpress(inputText, string.Empty, string.Empty, DataFieldTypes.IBAN, out regexResult))
                retVal.PreSelectionCondition.IBAN = regexResult.MatchingValue.Replace(" ", string.Empty).ToUpper();
            
            foreach (var item in genericRechnung.DataFields.ToList())
            {
                var newDataField = new DataFieldTemplate() { Name = item.Name, FieldType = item.FieldType }; // Ignore text anchors as they are not needed in concrete templates

                foreach (var anchor in item.TextAnchors)
                {
                    RegexExpressionFinderResult expressionResult;
                    if (TryFindRegexMatchExpress(inputText, string.Empty, anchor, item.FieldType, out expressionResult))
                    {
                        newDataField.RegexExpressions = new List<string>() { expressionResult.RegexExpression };
                        break;
                    }
                }

                retVal.DataFields.Add(newDataField);
            }

            return retVal;
        }

        public bool CheckRegexExpression(string inputText, string regexString, string targetValue)
        {
            if (ExecuteRegexExpression(inputText, new List<string>() { regexString }) == targetValue)
                return true;
            else
                return false;
        }

        public string ExecuteRegexExpression(string inputText, List<string> regexExpressions)
        {
            foreach (var expression in regexExpressions)
            {
                var match = Regex.Match(inputText, expression);
                if (match.Groups.Count >= 2)
                    return match.Groups[1].Value;
            }

            return string.Empty;
        }

        public bool TryFindRegexMatchExpress(string inputText, string regexHalfString, string regexFullString, DataFieldTypes dataFieldType, out RegexExpressionFinderResult regexMatchExpression)
        {
            var finder = new RegexExpressionFinder();
            return finder.TryFindRegexMatchExpress(inputText, regexHalfString, regexFullString, dataFieldType, out regexMatchExpression);

        }
    }
}
