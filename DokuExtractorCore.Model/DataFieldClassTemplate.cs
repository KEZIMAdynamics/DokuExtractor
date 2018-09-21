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
    public class DataFieldClassTemplate : FieldTemplateBase
    {
        /// <summary>
        /// Regex expressions that will be used to process the data field.
        /// </summary>
        public List<string> RegexExpressions { get; set; } = new List<string>();
        
        /// <summary>
        /// Type of the data field.
        /// </summary>
        public DataFieldType FieldType { get; set; } = DataFieldType.Text;
    }
}
