﻿using DokuExtractorCore.Model;
using DokuExtractorStandardGUI.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorStandardGUI.Model
{
    public class DataFieldResultDisplay : DataFieldResult
    {
        public string FieldTypeDisplayValue { get; set; } = string.Empty;
    }
}
