using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model.Tables
{
    public class TableColumn
    {
        public List<TableLine> Lines { get; set; } = new List<TableLine>();
    }
}
