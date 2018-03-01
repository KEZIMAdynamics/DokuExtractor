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
        string appRootPath;

        public TemplateProcessor(string appRootPath)
        {
            this.appRootPath = appRootPath;
        }

        public List<FieldExtractorTemplate> LoadTemplatesFromDisk()
        {
            var retVal = new List<FieldExtractorTemplate>();

            var templateDirectory = Path.Combine(appRootPath, "ExtractorTemplates");
            foreach (var item in Directory.GetFiles(templateDirectory))
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
                            if (inputText.Contains(singleWord))
                            {
                                singleWordCount = 1;
                                checkedWords.Add(singleWord, singleWordCount);
                                wordCount = 1;
                                break;
                            }
                            else
                                checkedWords.Add(singleWord, 0);
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
                resultItem.Value = ExecuteRegexExpression(inputText, item.RegexExpression);
                retVal.DataFields.Add(resultItem);
            }

            return retVal;
        }

        public FieldExtractorTemplate AutoCreateTemplate(string templateName, string inputText)
        {
            var genericRechnung = JsonConvert.DeserializeObject<FieldExtractorTemplate>(File.ReadAllText(Path.Combine(appRootPath, "GenericTemplates", "GenericTemplateRechnungen.json.txt")));

            var retVal = new FieldExtractorTemplate();
            retVal.TemplateName = templateName;

            foreach (var item in genericRechnung.DataFields)
            {
                string expression;
                if (TryFindRegexMatchExpress(inputText, item.RegexHalfString, item.RegexFullString, item.FieldType, out expression))
                {
                    item.RegexExpression = expression;
                    retVal.DataFields.Add(item);
                }
            }

            return retVal;
        }

        public bool CheckRegexExpression(string inputText, string regexString, string targetValue)
        {
            if (ExecuteRegexExpression(inputText, regexString) == targetValue)
                return true;
            else
                return false;
        }

        public string ExecuteRegexExpression(string inputText, string regexExpression)
        {
            var match = Regex.Match(inputText, regexExpression);
            // TODO: Regexstring ausführen
            return match.Value;
        }

        public bool TryFindRegexMatchExpress(string inputText, string regexHalfString, string regexFullString, DataFieldTypes dataFieldType, out string regexMatchExpression)
        {
            var finder = new RegexExpressionFinder();
            return finder.TryFindRegexMatchExpress(inputText, regexHalfString, regexFullString, dataFieldType, out regexMatchExpression);

        }
    }
}
