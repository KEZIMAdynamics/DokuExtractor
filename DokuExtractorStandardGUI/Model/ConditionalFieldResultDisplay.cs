using DokuExtractorCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorStandardGUI.Model
{
    public class ConditionalFieldResultDisplay : ConditionalFieldResult
    {
        public string ConditionalFieldTypeDisplayValue { get; set; } = string.Empty;
    }
}
