using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Result of an evaluated conditional field.
    /// </summary>
    public class ConditionalFieldResult : FieldResultBase
    {
        /// <summary>
        /// Value of the processed conditional field.
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Type of the processed conditional field.
        /// </summary>
        public ConditionalFieldType ConditionalFieldType { get; set; } = ConditionalFieldType.Text;
    }
}
