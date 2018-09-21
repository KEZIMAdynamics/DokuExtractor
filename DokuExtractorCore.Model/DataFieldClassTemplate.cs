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

        /// <summary>
        /// Defines whether data is extracted based on regex expressions or based on area in the input document
        /// </summary>
        public DataFieldMode FieldMode { get; set; } = DataFieldMode.Regex;

        /// <summary>
        /// Defines the area (position and width) in which the value is located in the input document. Used if field mode is set to <see cref="DataFieldMode.Position"/>
        /// </summary>
        public PercentalAreaInfo ValueArea { get; set; } = new PercentalAreaInfo();
    }
}
