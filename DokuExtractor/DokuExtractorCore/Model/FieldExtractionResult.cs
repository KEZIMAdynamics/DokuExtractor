using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Contains the extracted data fields.
    /// </summary>
    public class FieldExtractionResult
    {
        /// <summary>
        /// Identifies the template which was used to create the result
        /// </summary>
        public string TemplateName { get; set; } = string.Empty;

        /// <summary>
        /// Which class or category does the template belong to? (Rechnung, Angebot, Lieferschein etc)
        /// </summary>
        public string TemplateClass { get; set; } = string.Empty;

        /// <summary>
        /// Contains the extracted data fields.
        /// </summary>
        public List<DataFieldResult> DataFields { get; set; } = new List<DataFieldResult>();
    }
}
