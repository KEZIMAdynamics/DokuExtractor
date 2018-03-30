using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    public class DataTableDefinition
    {
        public int TablePage { get; set; } = 0;

        public DataTableCoordinates TableFrameCoordinates { get; set; } = new DataTableCoordinates();

        public List<DataTableCoordinates> TableLinesCoordinates { get; set; } = new List<DataTableCoordinates>();
    }
}
