using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Contains information which can be used to preselect templates before matching them via key words.
    /// </summary>
    public class PreKeyWordSelectionArgs
    {
        /// <summary>
        /// IBANs are quite unique (both in structure itself and content linking to a certain company / supplier). 
        /// </summary>
        public List<string> IBANs { get; set; } = new List<string>();
    }
}
