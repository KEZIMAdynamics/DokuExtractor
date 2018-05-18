using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Contains a value and its corresponding condition
    /// </summary>
    public class ConditionValue
    {
        /// <summary>
        /// Condition that has to be matched (for now: string that has to exist in the document which will be processed).
        /// If no condition is set, the condition will be evaluated as positive. -> Leaving the property empty allows a fallback value
        /// </summary>
        public string Condition { get; set; } = string.Empty;

        /// <summary>
        /// The text that will be written to the ConditionalFieldResult when condition is accepted.
        /// </summary>
        public string Value { get; set; } = string.Empty;
    }
}
