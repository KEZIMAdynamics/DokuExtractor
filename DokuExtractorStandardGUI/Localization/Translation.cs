using DokuExtractorCore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorStandardGUI.Localization
{
    public static class Translation
    {
        public static LanguageStrings LanguageStrings { get; set; } = new LanguageStrings();

        public static void LoadLanguageFile(CultureInfo culture, string additionalCultureInfo, string languageFolderPath)
        {
            try
            {
                var languageFiles = Directory.GetFiles(languageFolderPath);
                foreach (var languageFile in languageFiles)
                {
                    var fileInfo = new FileInfo(languageFile);
                    if (fileInfo.Name.ToLower().Contains("_" + culture.Name.ToLower()))
                    {
                        if (string.IsNullOrWhiteSpace(additionalCultureInfo) == false && fileInfo.Name.ToLower().Contains("_" + additionalCultureInfo.ToLower()))
                        {
                            var languageJson = File.ReadAllText(fileInfo.FullName);
                            Translation.LanguageStrings = JsonConvert.DeserializeObject<LanguageStrings>(languageJson);
                            break;
                        }
                        else if (string.IsNullOrWhiteSpace(additionalCultureInfo) == true)
                        {
                            var languageJson = File.ReadAllText(fileInfo.FullName);
                            Translation.LanguageStrings = JsonConvert.DeserializeObject<LanguageStrings>(languageJson);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        public static List<LanguageStrings> LoadAllLanguageFiles(string languageFolderPath)
        {
            var retVal = new List<LanguageStrings>();

            try
            {
                var languageFiles = Directory.GetFiles(languageFolderPath);
                foreach (var languageFile in languageFiles)
                {
                    var fileInfo = new FileInfo(languageFile);
                    var languageJson = File.ReadAllText(fileInfo.FullName);
                    var languageObject = JsonConvert.DeserializeObject<LanguageStrings>(languageJson);
                    retVal.Add(languageObject);
                }
            }
            catch (Exception ex)
            { }

            return retVal;
        }

        public static void SaveAllLanguageFiles(List<LanguageStrings> languageFiles, string languageFolderPath)
        {
            foreach (var file in Directory.GetFiles(languageFolderPath))
            {
                File.Delete(file);
            }

            foreach (var language in languageFiles)
            {
                var languageJson = JsonConvert.SerializeObject(language, Formatting.Indented);
                var filePath = string.Empty;

                if (string.IsNullOrWhiteSpace(language.AdditionalCultureInfo))
                    filePath = Path.Combine(languageFolderPath, "DokuExtractorLanguage_" + language.Culture.Name + ".json");
                else
                    filePath = Path.Combine(languageFolderPath, "DokuExtractorLanguage_" + language.Culture.Name + "_" + language.AdditionalCultureInfo + ".json");

                File.WriteAllText(filePath, languageJson);
            }
        }

        public static string TranslateDataFieldTypeEnum(DataFieldType fieldType)
        {
            switch (fieldType)
            {
                case DataFieldType.Text:
                    return LanguageStrings.FieldTypeText;
                case DataFieldType.Date:
                    return LanguageStrings.FieldTypeDate;
                case DataFieldType.Currency:
                    return LanguageStrings.FieldTypeCurrency;
                case DataFieldType.IBAN:
                    return LanguageStrings.FieldTypeIban;
                case DataFieldType.AnchorLessIBAN:
                    return LanguageStrings.FieldTypeAnchorlessIban;
                case DataFieldType.VatId:
                    return LanguageStrings.FieldTypeVatId;
                case DataFieldType.Term:
                    return LanguageStrings.FieldTypeTerm;
                default:
                    return string.Empty;
            }
        }

        public static string TranslateConditionalFieldTypeEnum(ConditionalFieldType conditionalFieldType)
        {
            switch (conditionalFieldType)
            {
                case ConditionalFieldType.Text:
                    return LanguageStrings.ConditionalFieldTypeText;
                case ConditionalFieldType.Bool:
                    return LanguageStrings.ConditionalFieldTypeBool;
                case ConditionalFieldType.Number:
                    return LanguageStrings.ConditionalFieldTypeNumber;
                case ConditionalFieldType.Date:
                    return LanguageStrings.ConditionalFieldTypeDate;
                case ConditionalFieldType.UserId:
                    return LanguageStrings.ConditionalFieldTypeUserId;
                case ConditionalFieldType.UserGroupId:
                    return LanguageStrings.ConditionalFieldTypeUserGroupId;
                case ConditionalFieldType.UserOrUserGroupId:
                    return LanguageStrings.ConditionalFieldTypeUserOrUserGroupId;
                default:
                    return string.Empty;
            }
        }
    }
}
