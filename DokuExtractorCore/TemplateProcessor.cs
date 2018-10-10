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
        public IPdfTextLoaderFull TextLoader { get; set; } = new PdfTextLoaderFull();

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
        TemplateMatcher templateMatcher = new TemplateMatcher();

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
        public void SaveTemplatesToFiles(List<DocumentGroupTemplate> templates)
        {
            SaveTemplatesToFiles(templates, TemplateGroupDirectory);
        }

        /// <summary>
        /// Saves group template to the TemplateGroupDirectory.
        /// </summary>
        /// <param name="template">Group template</param>
        public bool SaveTemplateToFile(DocumentGroupTemplate template)
        {
            return SaveTemplateToFile(template, TemplateGroupDirectory);
        }

        /// <summary>
        /// Saves group templates to the specified directory.
        /// </summary>
        /// <param name="templates">List of group templates</param>
        /// <param name="templateDirectory">Template directory</param>
        public void SaveTemplatesToFiles(List<DocumentGroupTemplate> templates, string templateDirectory)
        {
            if (Directory.Exists(templateDirectory) == false)
                Directory.CreateDirectory(templateDirectory);

            foreach (var template in templates)
            {
                SaveTemplateToFile(template, templateDirectory);
            }
        }

        /// <summary>
        /// Saves group template to the specified directory.
        /// </summary>
        /// <param name="template">Group template</param>
        /// <param name="templateDirectory">Template directory</param>
        public bool SaveTemplateToFile(DocumentGroupTemplate template, string templateDirectory)
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
        public void SaveTemplatesToFiles(List<DocumentClassTemplate> templates)
        {
            SaveTemplatesToFiles(templates, TemplateClassDirectory);
        }

        /// <summary>
        /// Saves class template to the TemplateClassDirectory.
        /// </summary>
        /// <param name="template">Class template</param>
        public bool SaveTemplateToFile(DocumentClassTemplate template)
        {
            return SaveTemplateToFile(template, TemplateClassDirectory);
        }

        /// <summary>
        /// Saves class templates to the specified directory.
        /// </summary>
        /// <param name="templates">List of class templates</param>
        /// <param name="templateDirectory">Template directory</param>
        public void SaveTemplatesToFiles(List<DocumentClassTemplate> templates, string templateDirectory)
        {
            if (Directory.Exists(templateDirectory) == false)
                Directory.CreateDirectory(templateDirectory);

            foreach (var template in templates)
            {
                SaveTemplateToFile(template, templateDirectory);
            }
        }

        /// <summary>
        /// Saves class template to the specified directory.
        /// </summary>
        /// <param name="template">Class template</param>
        /// <param name="templateDirectory">Template directory</param>
        public bool SaveTemplateToFile(DocumentClassTemplate template, string templateDirectory)
        {
            var retVal = false;

            template = CleanClassTemplateBeforeSave(template);

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
        /// Can be called to prepare modified class templates for being saved externally. Takes care removing double blank spaces in <see cref="DocumentClassTemplate.KeyWords"/>.
        /// Will be called automatically if the template is saved by the internally provided methods. (<see cref="SaveTemplateToFile(DocumentClassTemplate, string)"/>) and its derivates.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public DocumentClassTemplate CleanClassTemplateBeforeSave(DocumentClassTemplate template)
        {
            // Clean KeyWords of excessive blank spaces to match a cleaned document text when 
            template.KeyWords = template.KeyWords.Select(x => Regex.Replace(x, " +", " ")).ToList();

            return template;
        }

        /// <summary>
        /// Deletes class template from directory
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public bool DeleteTemplateFile(DocumentClassTemplate template)
        {
            var filePath = Path.Combine(TemplateClassDirectory, template.TemplateClassName + ".json.txt");
            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes group template from directory
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public bool DeleteTemplateFile(DocumentGroupTemplate template)
        {
            var filePath = Path.Combine(TemplateGroupDirectory, template.TemplateGroupName + ".json.txt");
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Matches a template to the input text. Templates will automatically be preselected and than matched via key words.
        /// </summary>
        /// <param name="templates">All class templates that shall be compared</param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public TemplateMatchResult<DocumentClassTemplate> MatchTemplates(List<DocumentClassTemplate> templates, string inputText)
        {
            var retVal = new TemplateMatchResult<DocumentClassTemplate>();

            var preselectedTemplates = templateMatcher.PreSelectTemplates(templates, inputText);
            if (preselectedTemplates.Count > 0)
            {
                retVal = templateMatcher.MatchTemplatesViaKeyWords(preselectedTemplates, inputText);
            }
            if (retVal.IsMatchSuccessfull == false)
            {
                retVal = templateMatcher.MatchTemplatesViaKeyWords(templates, inputText);
            }

            return retVal;
        }

        /// <summary>
        /// Matches a template to the input text. Templates will matched via key words.
        /// </summary>
        /// <param name="templates">All group templates that shall be compared</param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public TemplateMatchResult<DocumentGroupTemplate> MatchTemplates(List<DocumentGroupTemplate> templates, string inputText)
        {
            //  var retVal = new TemplateMatchResult<DocumentGroupTemplate>();

            var retVal = templateMatcher.MatchTemplatesViaKeyWords(templates, inputText);

            return retVal;
        }

        /// <summary>
        /// Selects the group template with the matching group name from TemplateGroupDirectory
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="groupTemplates"></param>
        /// <returns></returns>
        public DocumentGroupTemplate GetDocumentGroupTemplateByName(string groupName, List<DocumentGroupTemplate> groupTemplates)
        {
            //var templates = LoadGroupTemplatesFromDisk();
            return groupTemplates.Where(x => x.TemplateGroupName == groupName).FirstOrDefault();
        }





        /// <summary>
        /// Extracts data from input text based on the given class template and matching group template.
        /// </summary>
        /// <param name="template">The class template to be used</param>
        /// <param name="groupTemplates">Available group templates. The correct group template for the given class template will be selected automatically. If it is the correct one, it's okay if only one group template is in the list.</param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public async Task<FieldExtractionResult> ExtractData(DocumentClassTemplate template, List<DocumentGroupTemplate> groupTemplates, string inputText, string pdfFilePath)
        {
            var retVal = new FieldExtractionResult() { TemplateClassName = template.TemplateClassName, TemplateGroupName = template.TemplateGroupName };

            foreach (var item in template.DataFields)
            {
                var resultItem = new DataFieldResult() { FieldType = item.FieldType, Name = item.Name };
                if (item.FieldMode == DataFieldMode.Regex)
                    resultItem.Value = ExecuteRegexExpression(inputText, item.RegexExpressions);
                retVal.DataFields.Add(resultItem);
            }

            var dataFieldsPosition = await TextLoader.GetTextFromPdfForPositionalDataFields(pdfFilePath, template.DataFields.Where(x => x.FieldMode == DataFieldMode.Position).ToList());
            foreach (var dataFieldPos in dataFieldsPosition)
            {
                var retValDataField = retVal.DataFields.Where(x => x.Name == dataFieldPos.Name).FirstOrDefault();
                if (retValDataField != null)
                    retValDataField.Value = dataFieldPos.Value;
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
            var allConditionalClassFields = template.ConditionalFields;

            // Add conditional fields to class template if necessary.
            var conditionalFieldsHash = allConditionalClassFields.Select(x => x.Name.ToLower()).ToHashSet();
            foreach (var item in groupTemplate.ConditionalFields.Where(x => x.OnlyStoreInGroupTemplate == false))
            {
                var lowerName = item.Name.ToLower();
                if (conditionalFieldsHash.Contains(lowerName) == false)
                {
                    allConditionalClassFields.Add(item);
                }
            }
            //allConditionalFields.AddRange(groupTemplate.ConditionalFields.Where(x => x.OnlyStoreInGroupTemplate));


            foreach (var item in allConditionalClassFields)
            {
                var conditionalFieldResult = conditionProcessor.ProcessConditions(inputText, item);
                if (retVal.ConditionalFields.Where(x => x.Name == conditionalFieldResult.Name).Count() == 0)
                    retVal.ConditionalFields.Add(conditionalFieldResult);
            }

            foreach (var item in groupTemplate.ConditionalFields.Where(x => x.OnlyStoreInGroupTemplate == true))
            {
                var conditionalFieldResult = conditionProcessor.ProcessConditions(inputText, item);
                if (retVal.ConditionalFields.Where(x => x.Name == conditionalFieldResult.Name).Count() == 0)
                    retVal.ConditionalFields.Add(conditionalFieldResult);
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
        public async Task<string> ExtractDataAsJson(DocumentClassTemplate template, List<DocumentGroupTemplate> groupTemplates, string inputText, string pdfFilePath)
        {
            var json = JsonConvert.SerializeObject(await ExtractData(template, groupTemplates, inputText, pdfFilePath), Formatting.Indented);
            return json;
        }

        /// <summary>
        /// Creates a class template for the input text with the given template name. Datafields will be generated based on the group template. Working regex expression for the data fields will be generated based on their text anchors (if possible).
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="inputText"></param>
        /// <param name="baseGroupTemplate"></param>
        /// <returns></returns>
        public DocumentClassTemplate AutoCreateClassTemplate(string templateName, string inputText, DocumentGroupTemplate baseGroupTemplate)
        {
            // var genericRechnung = JsonConvert.DeserializeObject<DocumentGroupTemplate>(File.ReadAllText(Path.Combine(appRootPath, "GenericTemplates", "GenericTemplateRechnungen.json.txt")));
            //var genericRechnung = GetDocumentGroupTemplateByName("Rechnung", baseGroupTemplate);

            var retVal = new DocumentClassTemplate();
            if (baseGroupTemplate != null)
            {
                retVal.TemplateClassName = templateName;
                retVal.TemplateGroupName = baseGroupTemplate.TemplateGroupName;

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


                foreach (var item in baseGroupTemplate.DataFields.ToList())
                {
                    var newDataField = AutoCreateDataFieldClassTemplateFromDataFieldGroupTemplate(item, inputText);

                    retVal.DataFields.Add(newDataField);
                }

                //It's important to create a clone of the List<ConditionalFieldTemplate> to make the reference to the baseGroupTemplate.ConditionalFields disappear
                var baseConditionalFields = baseGroupTemplate.ConditionalFields.Where(x => x.OnlyStoreInGroupTemplate == false).ToList();
                var objectClone = HelperExtensions.JsonDeepClone(baseConditionalFields);
                retVal.ConditionalFields.AddRange(objectClone);
            }

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

            var fieldSet = classTemplate.DataFields.Select(x => x.Name).ToHashSet();

            foreach (var item in groupTemplate.DataFields.ToList())
            {
                if (fieldSet.Contains(item.Name) == false)
                {
                    var newDataField = AutoCreateDataFieldClassTemplateFromDataFieldGroupTemplate(item, inputText);
                    classTemplate.DataFields.Add(newDataField);
                    retVal.Add(newDataField);
                }

            }

            fieldSet = classTemplate.ConditionalFields.Select(x => x.Name).ToHashSet();

            foreach (var item in groupTemplate.ConditionalFields.ToList())
            {
                if (item.OnlyStoreInGroupTemplate == false && fieldSet.Contains(item.Name) == false)
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
