using DokuExtractorCore.Model;
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
        public string TemplateClassDirectory { get; set; }
        public string TemplateGroupDirectory { get; set; }
        string appRootPath;


        public TemplateProcessor(string appRootPath)
        {
            this.appRootPath = appRootPath;
            TemplateClassDirectory = Path.Combine(appRootPath, "ExtractorClassTemplates");
            TemplateGroupDirectory = Path.Combine(appRootPath, "ExtractorGroupTemplates");
        }

        public List<DocumentGroupTemplate> LoadGroupTemplatesFromDisk()
        {
            var retVal = new List<DocumentGroupTemplate>();

            foreach (var item in Directory.GetFiles(TemplateGroupDirectory))
            {
                try
                {
                    var template = JsonConvert.DeserializeObject<DocumentGroupTemplate>(File.ReadAllText(item));
                    retVal.Add(template);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return retVal;
        }

        public List<DocumentClassTemplate> LoadClassTemplatesFromDisk()
        {
            var retVal = new List<DocumentClassTemplate>();

            foreach (var item in Directory.GetFiles(TemplateClassDirectory))
            {
                try
                {
                    var template = JsonConvert.DeserializeObject<DocumentClassTemplate>(File.ReadAllText(item));
                    retVal.Add(template);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return retVal;
        }

        public void SaveTemplates(List<DocumentGroupTemplate> templates)
        {
            SaveTemplates(templates, TemplateGroupDirectory);
        }

        public void SaveTemplates(List<DocumentGroupTemplate> templates, string templateDirectory)
        {
            if (Directory.Exists(templateDirectory) == false)
                Directory.CreateDirectory(templateDirectory);

            foreach (var template in templates)
            {
                var templateJson = JsonConvert.SerializeObject(template, Formatting.Indented);
                var filePath = Path.Combine(templateDirectory, template.TemplateGroupName + ".json.txt");

                File.WriteAllText(filePath, templateJson);
            }
        }

        public void SaveTemplates(List<DocumentClassTemplate> templates)
        {
            SaveTemplates(templates, TemplateClassDirectory);
        }
        public void SaveTemplates(List<DocumentClassTemplate> templates, string templateDirectory)
        {
            if (Directory.Exists(templateDirectory) == false)
                Directory.CreateDirectory(templateDirectory);

            foreach (var template in templates)
            {
                var templateJson = JsonConvert.SerializeObject(template, Formatting.Indented);
                var filePath = Path.Combine(templateDirectory, template.TemplateClassName + ".json.txt");

                File.WriteAllText(filePath, templateJson);
            }
        }

        public TemplateMachResult MatchTemplates(List<DocumentClassTemplate> templates, string inputText)
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

        public DocumentGroupTemplate GetDocumentGroupTemplateByName(string groupName)
        {
            var templates = LoadGroupTemplatesFromDisk();

            return templates.Where(x => x.TemplateGroupName == groupName).FirstOrDefault();
        }

        public List<DocumentClassTemplate> PreSelectTemplates(List<DocumentClassTemplate> templates, string inputText)
        {
            var retVal = new List<DocumentClassTemplate>();

            RegexExpressionFinderResult regexResult;
            if (TryFindRegexMatchExpress(inputText, string.Empty, string.Empty, DataFieldTypes.AnchorLessIBAN, out regexResult))
            {
                var iban = regexResult.MatchingValue.Replace(" ", string.Empty).ToUpper();
                retVal.AddRange(templates.Where(x => x.PreSelectionCondition.IBAN == iban));
            }

            return retVal;
        }

        public TemplateMachResult MatchTemplatesViaKeyWords(List<DocumentClassTemplate> templates, string inputText)
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

        public FieldExtractionResult ExtractData(DocumentClassTemplate template, List<DocumentGroupTemplate> groupTemplates, string inputText)
        {
            var retVal = new FieldExtractionResult() { TemplateName = template.TemplateClassName, TemplateClass = template.TemplateGroupName };

            foreach (var item in template.DataFields)
            {
                var resultItem = new DataFieldResult() { FieldType = item.FieldType, Name = item.Name };
                resultItem.Value = ExecuteRegexExpression(inputText, item.RegexExpressions);
                retVal.DataFields.Add(resultItem);
            }

            //var groupTemplate = GetDocumentGroupTemplateByName(template.TemplateGroupName);
            var groupTemplate = groupTemplates.Where(x => x.TemplateGroupName == template.TemplateGroupName).FirstOrDefault();

            if (groupTemplate != null)
            {
                var fieldCalculator = new FieldCalculator();
                foreach (var item in groupTemplate.CalculationFields)
                {
                    retVal.CalculationFields.Add(fieldCalculator.CompareExpressionResults(item, retVal.DataFields));
                }
            }


            return retVal;
        }

        public string ExtractDataAsJson(DocumentClassTemplate template, List<DocumentGroupTemplate> groupTemplates, string inputText)
        {
            var json = JsonConvert.SerializeObject(ExtractData(template, groupTemplates, inputText), Formatting.Indented);
            return json;
        }

        public DocumentClassTemplate AutoCreateTemplate(string templateName, string inputText)
        {
            // var genericRechnung = JsonConvert.DeserializeObject<DocumentGroupTemplate>(File.ReadAllText(Path.Combine(appRootPath, "GenericTemplates", "GenericTemplateRechnungen.json.txt")));
            var genericRechnung = GetDocumentGroupTemplateByName("Rechnung");

            var retVal = new DocumentClassTemplate();
            retVal.TemplateClassName = templateName;
            retVal.TemplateGroupName = genericRechnung.TemplateGroupName;

            RegexExpressionFinderResult regexResult;
            if (TryFindRegexMatchExpress(inputText, string.Empty, string.Empty, DataFieldTypes.AnchorLessIBAN, out regexResult))
                retVal.PreSelectionCondition.IBAN = regexResult.MatchingValue.Replace(" ", string.Empty).ToUpper();

            foreach (var item in genericRechnung.DataFields.ToList())
            {
                var newDataField = new DataFieldTemplate() { Name = item.Name, FieldType = item.FieldType };

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
