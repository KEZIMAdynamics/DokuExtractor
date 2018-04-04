using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Result for a single DataField. Used in FielExtractionResult.
    /// </summary>
    public class DataFieldResult
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public DataFieldTypes FieldType { get; set; }
    }
}
