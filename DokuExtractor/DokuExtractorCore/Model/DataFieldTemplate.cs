using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Template for a single DataField. Used in FieldExtractorTemplates.
    /// </summary>
    public class DataFieldTemplate
    {
        public string Name { get; set; } = string.Empty;
        public List<string> RegexExpressions { get; set; } = new List<string>();
        public string RegexFullString { get; set; } = string.Empty; // TODO: Think of better name
        public string RegexHalfString { get; set; } = string.Empty; // TODO: Think of better name
        public DataFieldTypes FieldType { get; set; }
    }
}
