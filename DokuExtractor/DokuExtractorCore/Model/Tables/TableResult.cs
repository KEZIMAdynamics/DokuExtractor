using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model.Tables
{
    public class TableResult
    {
        /// <summary>
        /// Structure: [Lines][Columns]
        /// </summary>
        public string[,] Table { get; set; } //= new string[,] { { "" }, { "" } };
        public Dictionary<int, int> TableCountDictionary { get; set; }

        public int LineCount { get; set; }
        public int ColumnCount { get; set; }
    }
}
