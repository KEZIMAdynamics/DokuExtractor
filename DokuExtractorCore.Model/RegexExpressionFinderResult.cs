using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Represents the result of an attempt to automatically find a regular expression.
    /// </summary>
    public class RegexExpressionFinderResult
    {
        /// <summary>
        /// Indicates if an expression has been found
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The regex expression ;-)
        /// </summary>
        public string RegexExpression { get; set; } = string.Empty;

        /// <summary>
        /// The value of the first match, that the RegexExpression generates. Contains targetValue if provided. May be used for validating the expression if no targetValue was provided.
        /// </summary>
        public string MatchingValue { get; set; } = string.Empty;

        /// <summary>
        /// All matching values, that the RegexExpression generates. Contains targetValue if provided. May be used if value collections are required (e.g. Anchorless IBANs for pre-key-word-selection)
        /// </summary>
        public List<string> AllMatchingValues { get; set; } = new List<string>();
    }
}
