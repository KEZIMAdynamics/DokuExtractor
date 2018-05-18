using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Template for a single DataField. Used in DocumentGroupTemplate.
    /// </summary>
    public class DataFieldGroupTemplate
    {

        /// <summary>
        /// Field name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        public List<string> TextAnchors { get; set; } = new List<string>();
        public DataFieldType FieldType { get; set; }
    }
}
