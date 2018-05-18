using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Contains the (first) matching template, if at least one template matched.
    /// </summary>
    public class TemplateMachResult
    {
        /// <summary>
        /// The matching template, if a match was found.
        /// </summary>
        public DocumentClassTemplate Template { get; set; } = new DocumentClassTemplate();

        /// <summary>
        /// Indicates if a match was found.
        /// </summary>
        public bool IsMatchSuccessfull { get; set; }
    }
}
