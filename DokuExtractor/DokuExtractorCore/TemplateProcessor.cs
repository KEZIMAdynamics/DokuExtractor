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
    /// <summary>
    /// Extracts data from text based on templates.
    /// </summary>
    public class TemplateProcessor
    {
        /// <summary>
        /// Directory where document class templates are located if they shall be loaded from disk.
        /// </summary>
        public string TemplateClassDirectory { get; set; }

        /// <summary>
        /// Directory where document group templates are located if they shall be loaded from disk.
        /// </summary>
        public string TemplateGroupDirectory { get; set; }
        string appRootPath;
        RegexExpressionFinder finder = new RegexExpressionFinder();

        /// <summary>
        /// For ease of use, Class and Group jsons can be copied to the appRootPath directory into the folders "ExtractorClassTemplates" and "ExtractorGroupTemplates".
        /// </summary>
        /// <param name="appRootPath"></param>

        public TemplateProcessor(string appRootPath)
        {
            this.appRootPath = appRootPath;
            TemplateClassDirectory = Path.Combine(appRootPath, "ExtractorClassTemplates");
            TemplateGroupDirectory = Path.Combine(appRootPath, "ExtractorGroupTemplates");
        }

        /// <summary>
        /// Loads group templates from the TemplateGroupDirectory.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Loads class templates from the TemplateClassDirectory.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Saves group templates to the TemplateGroupDirectory.
        /// </summary>
        /// <param name="templates">List of group templates</param>
        public void SaveTemplates(List<DocumentGroupTemplate> templates)
        {
            SaveTemplates(templates, TemplateGroupDirectory);
        }

        /// <summary>
        /// Saves group template to the TemplateGroupDirectory.
        /// </summary>
        /// <param name="template">Group template</param>
        public bool SaveTemplate(DocumentGroupTemplate template)
        {
            return SaveTemplate(template, TemplateGroupDirectory);
        }

        /// <summary>
        /// Saves group templates to the specified directory.
        /// </summary>
        /// <param name="templates">List of group templates</param>
        /// <param name="templateDirectory">Template directory</param>
        public void SaveTemplates(List<DocumentGroupTemplate> templates, string templateDirectory)
        {
            if (Directory.Exists(templateDirectory) == false)
                Directory.CreateDirectory(templateDirectory);

            foreach (var template in templates)
            {
                SaveTemplate(template, templateDirectory);
            }
        }

        /// <summary>
        /// Saves group template to the specified directory.
        /// </summary>
        /// <param name="template">Group template</param>
        /// <param name="templateDirectory">Template directory</param>
        public bool SaveTemplate(DocumentGroupTemplate template, string templateDirectory)
        {
            var retVal = false;

            if (string.IsNullOrWhiteSpace(template.TemplateGroupName) == false)
            {
                var templateJson = JsonConvert.SerializeObject(template, Formatting.Indented);
                var filePath = Path.Combine(templateDirectory, template.TemplateGroupName + ".json.txt");

                File.WriteAllText(filePath, templateJson);
                retVal = true;
            }

            return retVal;
        }

        /// <summary>
        /// Saves class templates to the TemplateClassDirectory.
        /// </summary>
        /// <param name="templates">List of class templates</param>
        public void SaveTemplates(List<DocumentClassTemplate> templates)
        {
            SaveTemplates(templates, TemplateClassDirectory);
        }

        /// <summary>
        /// Saves class template to the TemplateClassDirectory.
        /// </summary>
        /// <param name="template">Class template</param>
        public bool SaveTemplate(DocumentClassTemplate template)
        {
            return SaveTemplate(template, TemplateClassDirectory);
        }

        /// <summary>
        /// Saves class templates to the specified directory.
        /// </summary>
        /// <param name="templates">List of class templates</param>
        /// <param name="templateDirectory">Template directory</param>
        public void SaveTemplates(List<DocumentClassTemplate> templates, string templateDirectory)
        {
            if (Directory.Exists(templateDirectory) == false)
                Directory.CreateDirectory(templateDirectory);

            foreach (var template in templates)
            {
                SaveTemplate(template, templateDirectory);
            }
        }

        /// <summary>
        /// Saves class template to the specified directory.
        /// </summary>
        /// <param name="template">Class template</param>
        /// <param name="templateDirectory">Template directory</param>
        public bool SaveTemplate(DocumentClassTemplate template, string templateDirectory)
        {
            var retVal = false;

            if (string.IsNullOrWhiteSpace(template.TemplateClassName) == false)
            {
                var templateJson = JsonConvert.SerializeObject(template, Formatting.Indented);
                var filePath = Path.Combine(templateDirectory, template.TemplateClassName + ".json.txt");

                File.WriteAllText(filePath, templateJson);
                retVal = true;
            }

            return retVal;
        }

        /// <summary>
        /// Matches a template to the input text. Templates will automatically be preselected and than matched via key words.
        /// </summary>
        /// <param name="templates">All class templates that shall be compared</param>
        /// <param name="inputText"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Selects the group template with the matching group name from TemplateGroupDirectory
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public DocumentGroupTemplate GetDocumentGroupTemplateByName(string groupName)
        {
            var templates = LoadGroupTemplatesFromDisk();
            return templates.Where(x => x.TemplateGroupName == groupName).FirstOrDefault();
        }

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
            if (TryFindRegexMatchExpress(inputText, string.Empty, string.Empty, DataFieldType.AnchorLessIBAN, false, out regexResult))
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

        /// <summary>
        /// Extracts data from input text based on the given class template and matching group template.
        /// </summary>
        /// <param name="template">The class template to be used</param>
        /// <param name="groupTemplates">Available group templates. The correct group template for the given class template will be selected automatically. If it is the correct one, it's okay if only one group template is in the list.</param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public FieldExtractionResult ExtractData(DocumentClassTemplate template, List<DocumentGroupTemplate> groupTemplates, string inputText)
        {
            var retVal = new FieldExtractionResult() { TemplateClassName = template.TemplateClassName, TemplateGroupName = template.TemplateGroupName };

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

            var conditionProcessor = new ConditionalFieldProcessor();
            foreach (var item in template.ConditionalFields)
            {
                retVal.ConditionalFields.Add(conditionProcessor.ProcessConditions(inputText, item));
            }

            return retVal;
        }

        /// <summary>
        /// Returns extracted data from <see cref=" ExtractData(DocumentClassTemplate, List{DocumentGroupTemplate}, string)"/> as JSON text.
        /// </summary>
        /// <param name="template"></param>
        /// <param name="groupTemplates"></param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string ExtractDataAsJson(DocumentClassTemplate template, List<DocumentGroupTemplate> groupTemplates, string inputText)
        {
            var json = JsonConvert.SerializeObject(ExtractData(template, groupTemplates, inputText), Formatting.Indented);
            return json;
        }

        /// <summary>
        /// Creates a class template for the input text with the given template name. Datafields will be generated based on the group template. Working regex expression for the data fields will be generated based on their text anchors (if possible).
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public DocumentClassTemplate AutoCreateClassTemplate(string templateName, string inputText)
        {
            // var genericRechnung = JsonConvert.DeserializeObject<DocumentGroupTemplate>(File.ReadAllText(Path.Combine(appRootPath, "GenericTemplates", "GenericTemplateRechnungen.json.txt")));
            var genericRechnung = GetDocumentGroupTemplateByName("Rechnung");

            var retVal = new DocumentClassTemplate();
            retVal.TemplateClassName = templateName;
            retVal.TemplateGroupName = genericRechnung.TemplateGroupName;

            RegexExpressionFinderResult regexResult;
            if (TryFindRegexMatchExpress(inputText, string.Empty, string.Empty, DataFieldType.AnchorLessIBAN, false, out regexResult))
            {
                // retVal.PreSelectionCondition.IBANs = regexResult.MatchingValue.Replace(" ", string.Empty).ToUpper();
                foreach (var item in regexResult.AllMatchingValues)
                {
                    var cleaned = item.Replace(" ", string.Empty).ToUpper();
                    retVal.PreSelectionCondition.IBANs.Add(cleaned);
                }

            }


            foreach (var item in genericRechnung.DataFields.ToList())
            {
                var newDataField = AutoCreateDataFieldClassTemplateFromDataFieldGroupTemplate(item, inputText);

                retVal.DataFields.Add(newDataField);
            }

            retVal.ConditionalFields = genericRechnung.ConditionalFields;

            return retVal;
        }

        /// <summary>
        /// Checks if the targetValue can be obtained from inputText by using the regexString
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="regexString"></param>
        /// <param name="targetValue"></param>
        /// <returns></returns>
        public bool CheckRegexExpression(string inputText, string regexString, string targetValue)
        {
            if (ExecuteRegexExpression(inputText, new List<string>() { regexString }) == targetValue)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Executes regexExpressions against input text and returns the first group value of the first match.
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="regexExpressions"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Tries to generate / find a regex expression. <seealso cref="RegexExpressionFinder.TryFindRegexMatchExpress(string, string, string, DataFieldType,bool, out RegexExpressionFinderResult)"/>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="targetValue"></param>
        /// <param name="textAnchor"></param>
        /// <param name="dataFieldType"></param>
        /// <param name="returnFirstMatchOnly"></param>
        /// <param name="regexMatchExpression"></param>
        /// <returns></returns>
        public bool TryFindRegexMatchExpress(string inputText, string textAnchor, string targetValue, DataFieldType dataFieldType, bool returnFirstMatchOnly, out RegexExpressionFinderResult regexMatchExpression)
        {

            return finder.TryFindRegexMatchExpress(inputText, textAnchor, targetValue, dataFieldType, false, out regexMatchExpression);

        }

        /// <summary>
        /// Checks if a group template has datafields that are still missing in the class template. If a data field is missing, it will be added to the class template (including eg. automatic regexExpressionFinder magic).
        /// Added datafields are also returned to indicate which fields were added.
        /// </summary>
        /// <param name="groupTemplate"></param>
        /// <param name="classTemplate"></param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public List<FieldTemplateBase> UpdateFieldsFromGroupTemplate(DocumentGroupTemplate groupTemplate, DocumentClassTemplate classTemplate, string inputText)
        {
            var retVal = new List<FieldTemplateBase>();

            var fieldSet = groupTemplate.DataFields.Select(x => x.Name).ToHashSet();

            foreach (var item in groupTemplate.DataFields.ToList())
            {
                if (fieldSet.Contains(item.Name) == false)
                {
                    var newDataField = AutoCreateDataFieldClassTemplateFromDataFieldGroupTemplate(item, inputText);
                    classTemplate.DataFields.Add(newDataField);
                    retVal.Add(newDataField);
                }

            }

            fieldSet = groupTemplate.ConditionalFields.Select(x => x.Name).ToHashSet();

            foreach (var item in classTemplate.ConditionalFields.ToList())
            {
                if (fieldSet.Contains(item.Name) == false)
                {
                    classTemplate.ConditionalFields.Add(item);
                    retVal.Add(item);
                }

            }

            return retVal;
        }

        private DataFieldClassTemplate AutoCreateDataFieldClassTemplateFromDataFieldGroupTemplate(DataFieldGroupTemplate groupTemplate, string documentInputText)
        {
            var newDataField = new DataFieldClassTemplate() { Name = groupTemplate.Name, FieldType = groupTemplate.FieldType };

            foreach (var anchor in groupTemplate.TextAnchors)
            {
                RegexExpressionFinderResult expressionResult;
                if (TryFindRegexMatchExpress(documentInputText, anchor, string.Empty, groupTemplate.FieldType, true, out expressionResult))
                {
                    newDataField.RegexExpressions = new List<string>() { expressionResult.RegexExpression };
                    break;
                }
            }

            return newDataField;
        }
    }
}
