using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Represents a template for data extraction and contains all necessary information to extract data from a matching input text.
    /// </summary>
    public class DocumentClassTemplate
    {
        /// <summary>
        /// Identifies a template
        /// </summary>
        public string TemplateClassName { get; set; } = string.Empty;

        /// <summary>
        /// Which group or category does the template belong to? (Rechnung, Angebot, Lieferschein etc)
        /// </summary>
        public string TemplateGroupName { get; set; } = string.Empty;

        /// <summary>
        /// Before the normal KeyWord matching, templates of interests can be pre selected based on certain conditions.
        /// </summary>
        public PreKeyWordSelectionArgs PreSelectionCondition { get; set; } = new PreKeyWordSelectionArgs();

        /// <summary>
        /// Key words are matched against the input text to check if the template is the right one. Each string has to be present in the input text for a successfull match (AND condition).
        /// Each string may consist of a group of several words, seperated by '|' (pipe). It is enough for one word of the group to be present in the input text (OR condition).
        /// </summary>
        public List<string> KeyWords { get; set; } = new List<string>();

        /// <summary>
        /// Contains the data fields which shall be extracted.
        /// </summary>
        public List<DataFieldTemplate> DataFields { get; set; } = new List<DataFieldTemplate>();
    }
}
