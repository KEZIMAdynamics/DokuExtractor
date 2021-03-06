﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Represents a template for data extraction and contains all necessary information to extract data from a matching input text.
    /// </summary>
    public class DocumentClassTemplate : DocumentBaseTemplate
    {
        /// <summary>
        /// Identifies a template
        /// </summary>
        public string TemplateClassName { get; set; } = string.Empty;

        /// <summary>
        /// Can be used by external programs to identify a certain template
        /// </summary>
        public string ExternalId { get; set; } = string.Empty;

        /// <summary>
        /// Which group or category does the template belong to? (Rechnung, Angebot, Lieferschein etc)
        /// </summary>
        public string TemplateGroupName { get; set; } = string.Empty;

        /// <summary>
        /// Before the normal KeyWord matching, templates of interests can be pre selected based on certain conditions.
        /// </summary>
        public PreKeyWordSelectionArgs PreSelectionCondition { get; set; } = new PreKeyWordSelectionArgs();

        /// <summary>
        /// Contains the data fields which shall be extracted.
        /// </summary>
        public List<DataFieldClassTemplate> DataFields { get; set; } = new List<DataFieldClassTemplate>();

        /// <summary>
        /// Contains the conditional data fields which will be evaluated during the data extraction. 
        /// </summary>
        public List<ConditionalFieldTemplate> ConditionalFields { get; set; } = new List<ConditionalFieldTemplate>();

        /// <summary>
        /// Contains the definitions of the data tables which shall be extracted.
        /// </summary>
        public List<DataTableDefinition> DataTables { get; set; } = new List<DataTableDefinition>();
    }
}
