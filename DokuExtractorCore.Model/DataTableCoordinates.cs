using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Contains the coordinates for a data table. They tell size and position of a table in a document.
    /// </summary>
    public class DataTableCoordinates
    {
        /// <summary>
        /// x-Position of top left pixel.
        /// </summary>
        public float Left { get; set; } = 0;

        /// <summary>
        /// y-Position of top left pixel.
        /// </summary>
        public float Top { get; set; } = 0;

        /// <summary>
        /// Table width
        /// </summary>
        public float Width { get; set; } = 0;

        /// <summary>
        /// Table height
        /// </summary>
        public float Height { get; set; } = 0;
    }
}
