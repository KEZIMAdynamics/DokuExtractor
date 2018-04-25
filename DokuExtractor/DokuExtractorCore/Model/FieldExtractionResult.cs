using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Contains the extracted data fields for a document.
    /// </summary>
    public class FieldExtractionResult
    {
        /// <summary>
        /// Identifies the template which was used to create the result
        /// </summary>
        public string TemplateClassName { get; set; } = string.Empty;

        /// <summary>
        /// Which class or category does the template belong to? (Rechnung, Angebot, Lieferschein etc)
        /// </summary>
        public string TemplateGroupName { get; set; } = string.Empty;

        /// <summary>
        /// Contains the extracted data fields.
        /// </summary>
        public List<DataFieldResult> DataFields { get; set; } = new List<DataFieldResult>();

        /// <summary>
        /// Contains the evaluaed conditional data fields. 
        /// </summary>
        public List<ConditionalFieldResult> ConditionalFields { get; set; } = new List<ConditionalFieldResult>();

        /// <summary>
        /// Contains calculation results based on extracted data fields.
        /// </summary>
        public List<CalculationFieldResult> CalculationFields { get; set; } = new List<CalculationFieldResult>();
    }
}
