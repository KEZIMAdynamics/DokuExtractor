using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    public class DocumentGroupTemplate
    {
        /// <summary>
        /// Which group or category does the template belong to? (Rechnung, Angebot, Lieferschein etc)
        /// </summary>
        public string TemplateGroupName { get; set; } = string.Empty;

        /// <summary>
        /// Before the normal KeyWord matching, templates of interests can be pre selected based on certain conditions.
        /// </summary>
        public PreKeyWordSelectionArgs PreSelectionCondition { get; set; } = new PreKeyWordSelectionArgs();

        /// <summary>
        /// Contains the data fields which shall be extracted.
        /// </summary>
        public List<DataFieldGroupTemplate> DataFields { get; set; } = new List<DataFieldGroupTemplate>();

        /// <summary>
        /// Contains the conditional data fields which will be evaluated during the data extraction. 
        /// </summary>
        public List<ConditionalFieldTemplate> ConditionalFields { get; set; } = new List<ConditionalFieldTemplate>();

        /// <summary>
        /// Contains calculated fields based on the extracted data fields.
        /// </summary>
        public List<CalculationFieldTemplate> CalculationFields { get; set; } = new List<CalculationFieldTemplate>();
    }
}
