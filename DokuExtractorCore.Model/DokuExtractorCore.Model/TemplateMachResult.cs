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
    public class TemplateMatchResult<T> where T : DocumentBaseTemplate
    {
        /// <summary>
        /// The matching template, if a match was found.
        /// </summary>
        public DocumentBaseTemplate Template { private get; set; }

        /// <summary>
        /// Indicates if a match was found.
        /// </summary>
        public bool IsMatchSuccessfull { get; set; }

        public T GetTemplate()
        {
            return Template as T;
        }
    }
}
