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
    public class DataFieldResult : FieldResultBase
    {
        /// <summary>
        /// Value of the processed data field.
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Type of the processed data field.
        /// </summary>
        public DataFieldType FieldType { get; set; } = DataFieldType.Text;
    }
}
