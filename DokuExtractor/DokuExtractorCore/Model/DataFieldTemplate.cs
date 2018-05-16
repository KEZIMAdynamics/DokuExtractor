using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Template for a single DataField. Used in DocumentClassTemplate.
    /// </summary>
    public class DataFieldTemplate : FieldTemplateBase
    {
        public List<string> RegexExpressions { get; set; } = new List<string>();
        public DataFieldTypes FieldType { get; set; }
    }
}
