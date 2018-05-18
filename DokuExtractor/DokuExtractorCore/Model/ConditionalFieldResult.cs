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
    public class ConditionalFieldResult
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

    }
}
