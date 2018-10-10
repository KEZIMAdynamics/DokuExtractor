using System;
using System.Collections.Generic;
using System.Text;

namespace DokuExtractorCore.Model
{
   public class PercentalAreaInfo
    {
        /// <summary>
        /// Page number of the document
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Percentual X-Coordinate of the area which is to be extracted
        /// </summary>
        public float TopLeftX { get; set; }

        /// <summary>
        /// Percentual Y-Coordinate of the area which is to be extracted
        /// </summary>
        public float TopLeftY { get; set; }

        /// <summary>
        /// Percentual width of the area which is to be extracted
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Percentual height of the area which is to be extracted
        /// </summary>
        public float Height { get; set; }
    }
}
