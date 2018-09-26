using System;
using System.Collections.Generic;
using System.Text;

namespace DokuExtractorCore.Model
{
   public class PercentalAreaInfo
    {
        //Page number of the document
        public int PageNumber { get; set; }

        //Percentual X-Coordinate of the area which is to be extracted
        public float TopLeftX { get; set; }

        //Percentual Y-Coordinate of the area which is to be extracted
        public float TopLeftY { get; set; }

        //Percentual width of the area which is to be extracted
        public float Width { get; set; }

        //Percentual height of the area which is to be extracted
        public float Height { get; set; }
    }
}
