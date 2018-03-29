using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    public class DataFieldGroupTemplate
    {
        public string Name { get; set; } = string.Empty;
        public List<string> TextAnchors { get; set; } = new List<string>();
        public DataFieldTypes FieldType { get; set; }
    }
}
