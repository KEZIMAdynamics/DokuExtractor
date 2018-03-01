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
        public FieldExtractorTemplate Template { get; set; } = new FieldExtractorTemplate();
        public bool IsMatchSuccessfull { get; set; }
    }
}
