using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Template for a single ConditionalField. Used in <see cref="DocumentGroupTemplate"/> and <see cref="DocumentClassTemplate"/>.
    /// </summary>
    public class ConditionalFieldTemplate : FieldTemplateBase
    {
        /// <summary>
        /// Collection of conditions / values the conditional field can have.
        /// </summary>
        public List<ConditionValue> ConditionValues { get; set; } = new List<ConditionValue>();

        /// <summary>
        /// Type of the conditional field.
        /// </summary>
        public ConditionalFieldType ConditionalFieldType { get; set; } = ConditionalFieldType.Text;
    }
}
