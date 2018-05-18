using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Base class for field results in case enumerations are needed
    /// </summary>
    public abstract class FieldResultBase
    {
        /// <summary>
        /// Field name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
